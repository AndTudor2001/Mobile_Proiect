using Mobile_Proiect.Models;

namespace Mobile_Proiect;

public partial class ReviewPage : ContentPage
{
	public ReviewPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e) 
	{ 
		var review = (Review)BindingContext; 
		review.Date = DateTime.UtcNow; 
		await App.Database.SaveShopListAsync(review);
		await Navigation.PopAsync(); }
    async void OnDeleteButtonClicked(object sender, EventArgs e) 
	{ var review = (Review)BindingContext; 
		await App.Database.DeleteShopListAsync(review);
		await Navigation.PopAsync(); 
	}
}