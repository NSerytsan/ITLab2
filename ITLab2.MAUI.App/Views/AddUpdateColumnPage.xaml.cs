using ITLab2.MAUI.App.DTO;
using ITLab2.MAUI.App.Services;

namespace ITLab2.MAUI.App.Views;
[QueryProperty((nameof(DatabaseName)), "dbName")]
[QueryProperty((nameof(TableName)), "tableName")]
public partial class AddUpdateColumnPage : ContentPage
{
    readonly IRestService _restService;
    private CreateColumnDTO _createColumnDTO;

    public string DatabaseName { get; set; } = String.Empty;

    public string TableName { get; set; } = String.Empty;

    public CreateColumnDTO CreateColumnDTO
    {
        get => _createColumnDTO;
        set
        {
            _createColumnDTO = value;
            OnPropertyChanged();
        }
    }

    public AddUpdateColumnPage(IRestService restService)
    {
        InitializeComponent();

        _restService = restService;

        _createColumnDTO = new CreateColumnDTO() { Name = string.Empty, Type = "String" };

        BindingContext = this;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        //await _restService.CreateColumnAsync(CreateColumnDTO, DatabaseName, TableName);

        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}