using ITLab2.MAUI.App.Services;

namespace ITLab2.MAUI.App.Views;
[QueryProperty((nameof(DatabaseName)), "dbName")]
[QueryProperty((nameof(TableName)), "tableName")]
public partial class AddUpdateColumnPage : ContentPage
{
    readonly IRestService _restService;

    public string DatabaseName { get; set; } = String.Empty;

    public string TableName { get; set; } = String.Empty;

    public AddUpdateColumnPage(IRestService restService)
    {
        InitializeComponent();
        _restService = restService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Title = DatabaseName + " > " + TableName + " Add Column";
    }
}