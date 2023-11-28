using ITLab2.MAUI.App.DTO;
using ITLab2.MAUI.App.Services;
using System.Collections.ObjectModel;

namespace ITLab2.MAUI.App.Views;

[QueryProperty(nameof(DatabaseName), "dbName")]
[QueryProperty(nameof(TableName), "tableName")]
public partial class ColumnsPage : ContentPage
{
    readonly IRestService _restService;

    public string DatabaseName { get; set; } = String.Empty;
    public string TableName { get; set; } = String.Empty;

    public ColumnsPage(IRestService restService)
    {
        InitializeComponent();
        _restService = restService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Title = DatabaseName + " > " + TableName + " Columns";

        LoadColumns();
    }

    private void OnAddColumnClicked(object sender, EventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { nameof(CreateColumnDTO), new CreateColumnDTO { Name = String.Empty , Type = "String"} },
                { "dbName", DatabaseName},
                { "tableName", TableName }
            };

        Shell.Current.GoToAsync($"{nameof(AddUpdateColumnPage)}", navigationParameter);
    }

    private void listColumns_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
    }

    private void listColumns_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listColumns.SelectedItem = null;
    }

    private async void OnDeleteColumnClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menuItem)
        {
            if (menuItem.CommandParameter is string columnName)
            {
                await _restService.DeleteColumnAsync(DatabaseName, TableName, columnName);
                LoadColumns();
            }
        }
    }

    private async void LoadColumns()
    {
        var columns = new ObservableCollection<ColumnDTO>(await _restService.GetColumnsAsync(DatabaseName, TableName));
        listColumns.ItemsSource = columns;
    }
}