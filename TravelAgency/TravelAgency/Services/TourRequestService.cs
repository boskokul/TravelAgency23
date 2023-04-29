﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Models;
using TravelAgency.Domain.RepositoryInterfaces;
using TravelAgency.Repositories;

namespace TravelAgency.Services
{
    public class TourRequestService
    {
        private ILocationRepository ILocationRepository;
        private ITourRequestRepository ITourRequestRepository;
        public TourRequestService()
        {
            ILocationRepository = Injector.Injector.CreateInstance<ILocationRepository>();
            ITourRequestRepository = Injector.Injector.CreateInstance<ITourRequestRepository>();
            LinkRequestLocation();
        }

        private void LinkRequestLocation()
        {
            foreach (var request in ITourRequestRepository.GetAll())
            {
                Location location = ILocationRepository.GetAll().Find(l => l.Id == request.LocationId);
                if (location != null)
                {
                    request.Location = location;
                }
            }
        }
        public List<TourRequest> GetPendings()
        {
            List<TourRequest> pendings = new List<TourRequest>();
            foreach (var request in ITourRequestRepository.GetAll())
            {
                if(request.Status == RequestStatus.Pending)
                {
                    pendings.Add(request);
                }
            }
            return pendings;
        }
        public List<string> getCountries()
        {
            return ILocationRepository.GetAllCountries();
        }
        public List<string> getCities(string country)
        {
            return ILocationRepository.GetCitiesByCountry(country);
        }

        public bool SaveRequest(string selectedCountry, string selectedCity, string language, string numberOfGuests, DateTime minDate, DateTime maxDate, string description, int guestId)
        {
            Location location = ILocationRepository.GetLocationForCountryAndCity(selectedCountry, selectedCity);
            TourRequest request = new TourRequest();
            if (request.Valid(language, numberOfGuests))
            {
                request.Location = location;
                request.LocationId = location.Id;
                request.MinDate = minDate;
                request.MaxDate = maxDate;
                request.Description = description;
                request.GuestId = guestId;
                request.Status = RequestStatus.Pending;
                TourRequestRepository repository = new TourRequestRepository();
                repository.Save(request);
                return true;
            }
            return false;
        }
    }
}
