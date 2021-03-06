﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MegaDesk_3._0_Jesus_MC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewAllQuotes : Page
    {
        public ViewAllQuotes()
        {
            this.InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void AddQuotesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddQuote));
        }

        private void SearchQuotesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchAllQuotes));
        }
    }
}
