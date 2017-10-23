using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class SearchAllQuotes : Page
    {

        Page mainMenu;
        public string criteria { get; set; }
        public string searchBy { get; set; }

        public SearchAllQuotes()
        {
            this.InitializeComponent();
        }


        public string getSearchBy()
        {
            ComboBoxItem item = (ComboBoxItem) SearchComboBox.SelectedItem;
            string value = item.Content.ToString();
            return this.searchBy = value;
        }

        public string getCriteria()
        {
            return this.criteria = this.Criteria.Text;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void AddQuotesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddQuote));
        }

        private void ViewQuotesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewAllQuotes));
        }

        private void SearchQuotesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchAllQuotes));
        }

        private void Search_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DeskQuote deskQuote = new DeskQuote();
            List<DeskQuote> deskQuotes = new List<DeskQuote>();
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            string file = storageFolder.Path + "\\Quotes.json";

            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            deskQuotes = deskQuote.searchQuotes(fs, this.searchBy, this);

            this.Results.Text += "Date" + "\t\t";
            this.Results.Text += "Client" + "\t";
            this.Results.Text += "Depth" + "\t";
            this.Results.Text += "Width" + "\t";
            this.Results.Text += "Sice" + "\t";
            this.Results.Text += "Material" + "\t\t";
            this.Results.Text += "Price" + "\n";

            for (int i = 0; i < deskQuotes.Count; i++)
            {

                this.Results.Text += deskQuotes.ElementAt(i).date + "\t";
                this.Results.Text += deskQuotes.ElementAt(i).clientName + "\t";
                this.Results.Text += deskQuotes.ElementAt(i).desk.width + "\t";
                this.Results.Text += deskQuotes.ElementAt(i).desk.depth + "\t";
                this.Results.Text += deskQuotes.ElementAt(i).desk.size + "\t";
                if (deskQuotes.ElementAt(i).desk.material.Equals("Rossewood"))
                {
                    this.Results.Text += deskQuotes.ElementAt(i).desk.material + "\t";
                }
                else
                {
                    this.Results.Text += deskQuotes.ElementAt(i).desk.material + "\t\t";
                }
                this.Results.Text = "$" + string.Format("{0:n0}", deskQuotes.ElementAt(i).price) + "\n";
            }

            this.Search.IsEnabled = false;
        }
    }
}
