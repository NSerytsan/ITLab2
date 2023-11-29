using ITLab2.MAUI.App.DTO;
using ITLab2.MAUI.App.Services;

namespace ITLab2.MAUI.App.Views;

[QueryProperty((nameof(DatabaseName)), "dbName")]
[QueryProperty((nameof(TableName)), "tableName")]
public partial class AddRowPage : ContentPage
{
    private readonly IRestService _restService;

    private CreateRowDTO _createRowDTO;

    private List<ColumnDTO> _columns = [];

    public CreateRowDTO CreateRowDTO
    {
        get => _createRowDTO;
        set
        {
            _createRowDTO = value;
            OnPropertyChanged();
        }
    }

    public string DatabaseName { get; set; } = String.Empty;

    public string TableName { get; set; } = String.Empty;

    public AddRowPage(IRestService restService)
    {
        InitializeComponent();

        _restService = restService;

        _createRowDTO = new CreateRowDTO();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BuildEntryForm();
    }

    private async void BuildEntryForm()
    {
        RowLayout.Children.Clear();
        _columns = await _restService.GetColumnsAsync(DatabaseName, TableName);

        foreach (var column in _columns)
        {
            var label = new Label { Text = column.Name + "(" + column.Type + ")" };
            RowLayout.Children.Add(label);
            var entry = new Entry { Placeholder = column.Name };
            RowLayout.Children.Add(entry);
        }
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var entries = RowLayout.Children.Where(c => c is Entry);
        foreach (var entry in entries)
        { 
            var name = ((Entry)entry).Placeholder;
            var column = _columns.First(c => c.Name.Equals(name));
            CreateRowDTO.Items.Add(column.Id, ((Entry)entry).Text);
        }

        await _restService.CreateRowAsync(CreateRowDTO, DatabaseName, TableName);

        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}