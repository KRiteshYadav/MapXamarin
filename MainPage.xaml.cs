using Maps.Models;
using Maps.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Maps
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public double latitude { get; set; }
        public double longitude { get; set; }


        public MainPage()
        {
            InitializeComponent();
            DisplayCurrentLocation();
            BindingContext = new NearestStoresViewModel(Navigation,1,Convert.ToInt64(latitude), Convert.ToInt64(longitude));
           // DisplayCurrentLocation();
        }


       //public  void Button_Clicked(object sender, EventArgs args) 
       // {
       //     (this.BindingContext as NearestStoresViewModel).StoreClick();
       // }


        //protected override void OnAppearing()
        //{
        //    (this.BindingContext as StoreInfo).GetStores();
        //}

        public async void DisplayCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    Position p = new Position(location.Latitude, location.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(.444));
                    //map.MoveToRegion(mapSpan);
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    latitude = location.Latitude;
                    longitude = location.Longitude;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            (this.BindingContext as NearestStoresViewModel).StoreClick();
        }
    }
}
