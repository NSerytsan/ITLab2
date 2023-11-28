using ITLab2.MAUI.App.Services;

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
        Shell.Current.GoToAsync($"{nameof(AddUpdateColumnPage)}?dbName={DatabaseName}&tableName={TableName}");
    }

    private void listColumns_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
    }

    private void listColumns_ItemTapped(object sender, ItemTappedEventArgs e)
    {
    }

    private void OnDeleteColumnClicked(object sender, EventArgs e)
    {
    }

    private void LoadColumns()
    {
    }
}