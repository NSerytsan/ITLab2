using ITLab2.MAUI.App.DTO;
using ITLab2.MAUI.App.Services;

namespace ITLab2.MAUI.App.Views;

[QueryProperty(nameof(CreateDatabaseDTO), "CreateDatabaseDTO")]
public partial class CreateDatabasePage : ContentPage
{
    readonly IRestService _restService;
    CreateDatabaseDTO _createDatabaseDTO;
    public CreateDatabaseDTO CreateDatabaseDTO
    {
        get => _createDatabaseDTO;
        set
        {
            _createDatabaseDTO = value;
            OnPropertyChanged();
        }
    }

    public CreateDatabasePage(IRestService restService)
    {
        InitializeComponent();
        _restService = restService;
        _createDatabaseDTO = new() { Name = String.Empty };
        BindingContext = this;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        await _restService.CreateDatabaseAsync(CreateDatabaseDTO);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}