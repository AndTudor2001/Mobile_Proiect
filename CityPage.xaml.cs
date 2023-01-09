using Mobile_Proiect.Models;

namespace Mobile_Proiect;

public partial class CityPage : ContentPage
{
	Hotel hotel;
	public CityPage(Hotel h)
	{
		InitializeComponent();
		hotel = h;
	}
	async void OnSaveButtonClicked(object sender,EventArgs e)
	{
		var city = (City)BindingContext;
		await App.Database.SaveCityAsync(city);
		listView.ItemsSource = await App.Database.GetCityAsync();
	}
	async void OnDeleteButtonClicked(object sender,EventArgs e)
	{
		var city = listView.SelectedItem as City;
		await App.Database.DeleteCityAsync(city);
		listView.ItemsSource = await App.Database.GetCityAsync();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource=await App.Database.GetCityAsync();
	}
	async void OnAddButtonClicked(object sender,EventArgs e)
	{
        City c;
        if (listView.SelectedItem != null)
        {
            c = listView.SelectedItem as City;
            var lc = new ListCities()
            {
                HotelID = hotel.ID,
                CityID = c.ID
            };
            await App.Database.SaveListCitiesAsync(lc);
            c.Cities = new List<ListCities> { lc };
            await Navigation.PopAsync();
        }
    }
}