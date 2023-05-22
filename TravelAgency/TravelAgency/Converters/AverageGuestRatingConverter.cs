﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TravelAgency.Domain.Models;

namespace TravelAgency.Converters
{
    class AverageGuestRatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AccommodationGuestRating rating = (AccommodationGuestRating)value;
            double average = (double)(rating.Cleanliness + rating.Compliance + rating.Noisiness + rating.Friendliness + rating.Responsivenes) / 5;
            return Math.Round(average, 2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
