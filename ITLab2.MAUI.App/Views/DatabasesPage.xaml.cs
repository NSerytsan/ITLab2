using ITLab2.MAUI.App.Services;

namespace ITLab2.MAUI.App.Views;

public partial class DatabasesPage : ContentPage
{
    readonly IRestService _restService;
    public DatabasesPage(IRestService restService)
    {
        InitializeComponent();
        _restService = restService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        listDatabases.ItemsSource = await _restService.GetDatabasesAsync();
    }
    private void listDatabases_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
    }

    private void listDatabases_ItemTapped(object sender, ItemTappedEventArgs e)
    {
    }

    private void btnCreate_clicked(object sender, EventArgs e)
    {
    }
}