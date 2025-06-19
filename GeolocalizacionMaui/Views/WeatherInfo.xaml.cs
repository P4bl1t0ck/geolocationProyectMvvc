using GeolocalizacionMaui.ViewModels;

namespace GeolocalizacionMaui.Views;

public partial class WeatherInfo : ContentPage
{
	public WeatherInfo()
	{
		InitializeComponent();
		BindingContext = new WeatherViewModel();	
    }
}