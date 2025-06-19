using GeolocalizacionMaui.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GeolocalizacionMaui.ViewModels
{
    internal class WeatherViewModel : INotifyPropertyChanged
    {
        private WeatherData _weatherData = new WeatherData();
        public WeatherData WeatherDataInfo 
        {
            get => _weatherData; 
            set
            {
                if (_weatherData != value)
                ///Si _weatherData es distinto de value, entonces asigna el valor a _weatherData y notifica el cambio.
                {
                    _weatherData = value;
                    OnPropertyChanged();
                    //Oye cambio el valor, porfavor asegurate de cambiar la vista.
                    
                }
            }
        }
        //Primero este se ejecuta el constructor de la clase WeatherViewModel, y luego se ejecuta el método GetCurrentWeatherFromLocation.
        public ICommandMapper RecalculateWeather { get; set; }
        public WeatherViewModel()
        {
            //Porfavor ejecuta lo que se encuentra aki dentro de esta función.
            GetCurrentWeatherFromLocation();
        }

        //La función anterior le llama a esta funcion de conseguir el clima acutal en la locacion y es acutlizadod por OnporpertyChangedd.
        public async void GetCurrentWeatherFromLocation()
        {
            WeatherDataInfo = await WeatherServices.GetCurrentLotacionWeatherAsync();
        }
        public async void GetWeatherFromLocation(double latitude, double longitude)
        {
            WeatherServices weatherSerices = new WeatherServices();
            WeatherDataInfor = await weatherSerices.GetWeatherDataFromLocationAsync(WeatherData.latitude, _weatherData.longitud);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
