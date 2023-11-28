using ITLab2.MAUI.App.DTO;
using ITLab2.MAUI.App.Services;
using System.Collections.ObjectModel;

namespace ITLab2.MAUI.App.Views;

[QueryProperty(nameof(DatabaseName), "dbName")]
public partial class TablesPage : ContentPage
{
    public string DatabaseName { get; set; } = String.Empty;

    private readonly IRestService _restService;

    public TablesPage(IRestService restService)
    {
        InitializeComponent();

        _restService = restService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Title = DatabaseName + " Tables";
        LoadTables();
    }

    private void OnAddTableClicked(object sender, EventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { nameof(CreateTableDTO), new CreateTableDTO { Name = String.Empty } },
                { "dbName", DatabaseName}
            };
        Shell.Current.GoToAsync(nameof(AddUpdateTablePage), navigationParameter);
    }

    private void OnColumnsClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menuItem)
        {
            if (menuItem.CommandParameter is string tableName)
            {
                Shell.Current.GoToAsync($"{nameof(ColumnsPage)}?dbName={DatabaseName}&tableName={tableName}");
            }
        }
    }
    private void listTables_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listTables.SelectedItem != null)
        {
            
        }
    }

    private void listTables_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listTables.SelectedItem = null;
    }

    private async void OnDeleteTableClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menuItem)
        {
            if (menuItem.CommandParameter is string tableName)
            {
                await _restService.DeleteTableAsync(DatabaseName, tableName);
                LoadTables();
            }
        }
    }

    private async void LoadTables()
    {
        var tables = new ObservableCollection<TableDTO>(await _restService.GetTablesAsync(DatabaseName));
        listTables.ItemsSource = tables;
    }
}