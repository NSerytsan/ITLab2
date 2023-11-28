using ITLab2.MAUI.App.DTO;
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
        if (listDatabases.SelectedItem != null)
        {

        }
    }

    private void listDatabases_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listDatabases.SelectedItem = null;
    }

    private void OnCreateDatabaseClicked(object sender, EventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { nameof(CreateDatabaseDTO), new CreateDatabaseDTO { Name = String.Empty } }
            };
        Shell.Current.GoToAsync(nameof(CreateDatabasePage), navigationParameter);
    }

    private void DeleteMenuItem_Clicked(object sender, EventArgs e)
    {

    }
}