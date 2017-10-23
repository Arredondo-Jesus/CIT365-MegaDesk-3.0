using System;
using System.Collections;
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
    public sealed partial class AddQuote : Page
    {
        const int MIN_WITH = 24;
        public int MAX_WITH = 96;
        const int MIN_DEPTH = 12;
        const int MAX_DEPTH = 48;

        public AddQuote()
        {
            this.InitializeComponent();
            this.SaveQuote.IsEnabled = true;

            DateTime currentDate = new DateTime();

            currentDate = DateTime.Now;

            string stringDate = currentDate.ToString("MM/dd/yyyy");

            this.setDate(stringDate);

            //Setting ArrayList of desktopMaterials
            ArrayList materials = new ArrayList();
            int enumlen = Enum.GetValues(typeof(Desk.desktopMaterials)).Length;
            Array materialNames = Enum.GetValues(typeof(Desk.desktopMaterials));

            for (int i = 0; i < enumlen; i++)
            {
                materials.Add(materialNames.GetValue(i));
            }

            this.Material.ItemsSource = materials;
        }


        public string getDate()
        {
            return this.TodayDate.Text;
        }

        public int getDeskWidth()
        {
            return Convert.ToInt32(this.DeskWidth.Text);
        }

        public int getDeskDepth()
        {
            return Convert.ToInt32(this.DeskDepth.Text);
        }

        public int getDeskDrawers()
        {
            ComboBoxItem item = (ComboBoxItem)this.DeskDrawers.SelectedItem;
            string value = item.Content.ToString();
            return Convert.ToInt32(value);
        }

        public String getClientName()
        {
            return this.ClientName.Text;
        }

        public int getRushDays()
        {
            ComboBoxItem item = (ComboBoxItem)this.rushDays.SelectedItem;
            string value = item.Content.ToString();
            return Convert.ToInt32(value);
        }

        public string getMaterial()
        {
            return this.Material.SelectedItem.ToString();
        }

        public void checkFields()
        {
            if (this.ClientName.Text != "" && this.DeskDepth.Text != "" && this.DeskWidth.Text != ""
                && !this.DeskDrawers.SelectedItem.Equals("") && !this.rushDays.SelectedItem.Equals(""))
            {
                this.SaveQuote.IsEnabled = true;
            }
        }

        public bool checkWidth()
        {
            int width = Convert.ToInt32(this.DeskWidth.Text);

            if (width < MIN_WITH || width > MAX_WITH)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool checkDepth()
        {
            int depth = Convert.ToInt32(this.DeskDepth.Text);

            if (depth < MIN_DEPTH || depth > MAX_DEPTH)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setSize(int size)
        {
            this.size.Text = string.Format("{0:n0}", size.ToString());
        }

        public void setPrice(int price)
        {
            this.Price.Text = "$" + string.Format("{0:n0}", price.ToString());
        }

        public void setDate(string date)
        {
            this.TodayDate.Text = date;
        }


        private void ClientName_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskWidth_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskDepth_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void rushDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void Material_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskDrawers_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskSurface_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskWidth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool result = checkWidth();
            string errorMessage = "Width not correct";

            if (!result)
            {
                e.Cancel = true;
                DeskWidth.Select(0, DeskWidth.Text.Length);
                //System.Windows.Forms.MessageBox.Show(errorMessage);
            }
        }

        private void DeskDepth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool result = checkDepth();
            string errorMessage = "Depth not correct";

            if (!result)
            {
                e.Cancel = true;
                DeskWidth.Select(0, DeskWidth.Text.Length);
                //System.Windows.Forms.MessageBox.Show(errorMessage);
            }

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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void SaveQuote_Click(object sender, RoutedEventArgs e)
        {
            DeskQuote deskQuote = new DeskQuote();
            deskQuote.saveQuote(this);
            this.SaveQuote.IsEnabled = false;
            //System.Windows.Forms.MessageBox.Show("The quote has been saved successfully");
        }
    }
}
