using Mobile_Proiect.Models;

namespace Mobile_Proiect;

public partial class ReviewEntryPage : ContentPage
{
	public ReviewEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetReviewsAsync();
    }
    async void OnShopListAddedClicked(object sender, EventArgs e) 
    { 
        await Navigation.PushAsync(new ReviewPage
        { 
            BindingContext = new Review() 
        }); }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) 
        { 
            await Navigation.PushAsync(new ReviewPage
            { 
                BindingContext = e.SelectedItem as Review
            }); 
        }
    }
}