﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Serializer;
using TravelAgency.Model;

namespace TravelAgency.Repository
{
    public class TourReservationRepository
    {
        private const string FilePath = "../../../Resources/Data/tourReservations.csv";

        private readonly Serializer<TourReservation> _serializer;

        private List<TourReservation> tourReservations;

        public TourReservationRepository()
        {
            _serializer = new Serializer<TourReservation>();
            tourReservations = _serializer.FromCSV(FilePath);
        }

        public List<TourReservation> GetTourReservations()
        {
            return tourReservations;
        }

        private int GetNewId()
        {
            if (tourReservations.Count == 0)
            {
                return 1;
            }
            return tourReservations[tourReservations.Count - 1].Id + 1;
        }

        public void SaveTourReservation(TourReservation tourReservation)
        {
            tourReservation.Id = GetNewId();
            tourReservations.Add(tourReservation);
            _serializer.ToCSV(FilePath, tourReservations);
        }
    }
}