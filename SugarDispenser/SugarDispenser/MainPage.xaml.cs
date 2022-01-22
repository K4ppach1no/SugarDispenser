using System;
using SugarDispenser.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SugarDispenser
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Settings();
        }

        private void Drop_Now(object sender, EventArgs e)
        {
            Client client = new Client();
            if (Settings.DistanceSensor)
            {
                string response = client.StartClient(Settings.IPEntryValue, Int32.Parse("11000"), "Suiker deponeren");
                if (response.StartsWith("NOK: geen kopje gedetecteerd"))
                {
                    DisplayAlert("Alert", "Geen kopje gevonden", "OK");
                }
            } else
            {
                string response = client.StartClient(Settings.IPEntryValue, Int32.Parse("11000"), "Suiker deponeren NoSensor");
            }
        }
    }
}
