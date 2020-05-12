using Maps.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Maps.ViewModels
{
    class NearestStoresViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public long UserId;
        public long Latitude;
        public long  Longitude;
        public INavigation navigation { get; set; }
        public NearestStoresViewModel(INavigation _navigation,
            long UserId,
            long Latitude,
            long Longitude)
        {
            navigation = _navigation;
            this.UserId = UserId;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
           // this.SearchStore = new Command(this.StoreClick);
            
        }

        public Command SearchStore { set; get; }

        public async void StoreClick()
        {

            using (var client = new HttpClient())
            {
                var uri = "http://192.168.1.3:8080/api/StoreSearch/FindStores?UserId="+this.UserId+"&Latitude="+this.Latitude+"&Longitude="+this.Longitude;
                var response = await client.GetStringAsync(uri);
                var Store = JsonConvert.DeserializeObject<List<StoreInfo>>(response);
                StoreInfo = new ObservableCollection<StoreInfo>(Store);
            }

        }

        ObservableCollection<StoreInfo> _stores;
        public ObservableCollection<StoreInfo> StoreInfo
        {
            get
            {
                return _stores;
            }
            set
            {
                _stores = value;
                NotifyPropertyChanged();
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
