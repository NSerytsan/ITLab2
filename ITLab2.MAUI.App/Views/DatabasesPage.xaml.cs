using ITLab2.MAUI.App.DTO;
using ITLab2.MAUI.App.Services;
using System.Collections.ObjectModel;

namespace ITLab2.MAUI.App.Views;

public partial class DatabasesPage : ContentPage
{
    readonly IRestService _restService;
    public DatabasesPage(IRestService restService)
    {
        InitializeComponent();
        _restService = restService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadDatabases();
    }
    private void listDatabases_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listDatabases.SelectedItem != null)
        {
            Shell.Current.GoToAsync($"{nameof(TablesPage)}?dbName={((DatabaseDTO)listDatabases.SelectedItem).Name}");
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

    private async void OnDeleteDatabaseClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menuItem)
        {
            if (menuItem.CommandParameter is string dbName)
            {
                await _restService.DeleteDatabaseAsync(dbName);

                LoadDatabases();
            }
        }
    }

    private async void LoadDatabases()
    {
        var databases = new ObservableCollection<DatabaseDTO>(await _restService.GetDatabasesAsync());
        listDatabases.ItemsSource = databases;
    }
}