namespace ITLab2.MAUI.App.Views;

public partial class AddUpdateTablePage : ContentPage
{
    public AddUpdateTablePage()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        //await _restService.CreateDatabaseAsync(CreateDatabaseDTO);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}