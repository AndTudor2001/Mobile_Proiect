using Mobile_Proiect.Models;

namespace Mobile_Proiect;

public partial class OrasePage : ContentPage
{
	Tara tara;
	public OrasePage(Tara t)
	{
		InitializeComponent();
		tara = t;
	}
	async void OnSaveButtonClicked(object sender,EventArgs e)
	{
		var oras = (Orase)BindingContext;
		await App.Database.SaveOrasAsync(oras);
		listView.ItemsSource = await App.Database.GetOraseAsync();
	}
	async void OnDeleteButtonClicked(object sender,EventArgs e)
	{
		var oras = listView.SelectedItem as Orase;
		await App.Database.DeleteOrasAsync(oras);
		listView.ItemsSource = await App.Database.GetOraseAsync();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource=await App.Database.GetOraseAsync();
	}
	async void OnAddButtonClicked(object sender,EventArgs e)
	{
        Orase p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Orase;
            var lp = new ListOrase()
            {
                TaraID = tara.ID,
                OrasID = p.ID
            };
            await App.Database.SaveListOraseAsync(lp);
            p.Orases = new List<ListOrase> { lp };
            await Navigation.PopAsync();
        }
    }
}