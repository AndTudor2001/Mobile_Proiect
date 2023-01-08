using Mobile_Proiect.Models;

namespace Mobile_Proiect;

public partial class TariEntryPage : ContentPage
{
	public TariEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetTariAsync();
    }
    async void OnTariAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TariPage
        {
            BindingContext = new Tara()
        });
    }
    async void OnTariListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) 
        { await Navigation.PushAsync(new TariPage 
            { 
            BindingContext = e.SelectedItem as Tara
            }); 
        }
    }
}