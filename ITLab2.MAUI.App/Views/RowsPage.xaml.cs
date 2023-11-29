using ITLab2.MAUI.App.DTO;
using ITLab2.MAUI.App.Services;

namespace ITLab2.MAUI.App.Views;

public class ShowRow
{
    public string FormattedRow {get;set;} = String.Empty;
    public int Id { get;set;}
}


[QueryProperty((nameof(DatabaseName)), "dbName")]
[QueryProperty((nameof(TableName)), "tableName")]
public partial class RowsPage : ContentPage
{
    private readonly IRestService _restService;

    public string DatabaseName { get; set; } = String.Empty;

    public string TableName { get; set; } = String.Empty;

    public RowsPage(IRestService restService)
    {
        InitializeComponent();

        _restService = restService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadRows();
    }
    private void OnAddRowTableClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"{nameof(AddRowPage)}?dbName={DatabaseName}&tableName={TableName}");
    }

    private async void LoadRows()
    { 
        var rowObjects = await _restService.GetRowsAsync(DatabaseName, TableName);
        var rows = new List<ShowRow>();
        foreach (var row in rowObjects)
        {
            var fields = row.Items.Values.Cast<string>().ToList();

            rows.Add(new ShowRow() { FormattedRow = String.Join(", ", fields), Id = row.Id });
        }

        listRows.ItemsSource = rows;
    }

    private async void OnDeleteRowClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menuItem)
        {
            if (menuItem.CommandParameter is int rowId)
            {
                await _restService.DeleteRowAsync(DatabaseName, TableName, rowId);
                LoadRows();
            }
        }
    }
}