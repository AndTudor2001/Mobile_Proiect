using Mobile_Proiect.Models;

namespace Mobile_Proiect;

public partial class HotelPage : ContentPage
{
	public HotelPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var hotel = (Hotel)BindingContext;
        await App.Database.SaveHotelAsync(hotel);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var hotel = (Hotel)BindingContext;
        await App.Database.DeleteHotelAsync(hotel);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CityPage((Hotel)
            this.BindingContext)
        {
            BindingContext = new City()
        });
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var h = (Hotel)BindingContext;
        listView.ItemsSource = await App.Database.GetListCitiessAsync(h.ID);
    }
    async void OnDeleteListCitiesClicked(object sender, EventArgs e)
    {
        var hotel = (Hotel)BindingContext;
        var p = listView.SelectedItem as City;
        var lp = App.Database.GetListCitiesAsync(hotel.ID, p.ID);
        await App.Database.DeleteListCitiesAsync(await lp);
        await Navigation.PopAsync();
    }


}