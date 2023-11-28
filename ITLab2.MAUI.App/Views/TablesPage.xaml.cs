using ITLab2.MAUI.App.Services;

namespace ITLab2.MAUI.App.Views;

[QueryProperty(nameof(DatabaseName), "dbName")]
public partial class TablesPage : ContentPage
{
    public string DatabaseName { get; set; } = String.Empty;

    private IRestService _restService;

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

    private void OnDeleteTableClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menuItem)
        {
            if (menuItem.CommandParameter is string dbName)
            {

                LoadTables();
            }
        }
    }

    private void LoadTables()
    {
    }
}