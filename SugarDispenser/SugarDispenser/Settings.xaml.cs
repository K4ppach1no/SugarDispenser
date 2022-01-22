using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SugarDispenser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            if(Application.Current.Properties.ContainsKey("ServerIP"))
                IPEntry.Text = (string)Application.Current.Properties["ServerIP"];
            if (Application.Current.Properties.ContainsKey("DistanceSensor"))
                DistanceSensorButton.IsToggled = (bool)Application.Current.Properties["DistanceSensor"];

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
            Application.Current.Properties["ServerIP"] = IPEntryValue;
            Application.Current.Properties["DistanceSensor"] = DistanceSensor;
        }

        public static string IPEntryValue = ""; 
        private void IPEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            IPEntryValue = e.NewTextValue;
        }

        public static bool DistanceSensor = false;
        private void DistanceSensorToggle(object sender, ToggledEventArgs e)
        {
            DistanceSensor = e.Value;
        }
    }
}