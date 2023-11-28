using ITLab2.MAUI.App.DTO;
using ITLab2.MAUI.App.Services;

namespace ITLab2.MAUI.App.Views;

[QueryProperty(nameof(CreateTableDTO), "CreateTableDTO")]
[QueryProperty(nameof(DatabaseName), "dbName")]
public partial class AddUpdateTablePage : ContentPage
{
    readonly IRestService _restService;
    
    CreateTableDTO _createTableDTO;

    public string DatabaseName { get; set; } = String.Empty;

    public CreateTableDTO CreateTableDTO
    {
        get => _createTableDTO;
        set
        {
            _createTableDTO = value;
            OnPropertyChanged();
        }
    }

    public AddUpdateTablePage(IRestService restService)
    {
        InitializeComponent();

        _restService = restService;

        _createTableDTO = new() { Name = String.Empty };

        BindingContext = this;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        await _restService.CreateTableAsync(CreateTableDTO, DatabaseName);
    
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}