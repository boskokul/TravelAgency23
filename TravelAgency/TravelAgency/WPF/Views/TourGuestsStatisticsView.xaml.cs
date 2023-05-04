﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelAgency.WPF.ViewModels;

namespace TravelAgency.WPF.Views
{
    /// <summary>
    /// Interaction logic for TourGuestsStatisticsView.xaml
    /// </summary>
    public partial class TourGuestsStatisticsView : Page
    {
        public TourGuestsStatisticsView(Domain.Models.TourOccurrence selectedTourOccurrence)
        {
            InitializeComponent();
            this.DataContext = new TourStatisticsDetailsViewModel(selectedTourOccurrence);
        }
    }
}