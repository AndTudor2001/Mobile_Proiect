using Mobile_Proiect.Models;

namespace Mobile_Proiect;

public partial class TariPage : ContentPage
{
    public TariPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var tara = (Tara)BindingContext;
        await App.Database.SaveTaraAsync(tara);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var tara = (Tara)BindingContext;
        await App.Database.DeleteTaraAsync(tara);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OrasePage((Tara)
            this.BindingContext) 
        { 
            BindingContext = new Orase() 
        });
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var tr = (Tara)BindingContext;
        listView.ItemsSource = await App.Database.GetListOrasesAsync(tr.ID);
    }
    async void OnDeleteListOraseClicked(object sender, EventArgs e)
    {
        var tara = (Tara)BindingContext;
        var p = listView.SelectedItem as Orase;
        var lp = App.Database.GetListOraseAsync(tara.ID, p.ID);
        await App.Database.DeleteListOraseAsync(await lp);
        await Navigation.PopAsync();
    }
}