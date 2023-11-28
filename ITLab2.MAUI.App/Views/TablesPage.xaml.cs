namespace ITLab2.MAUI.App.Views;

public partial class TablesPage : ContentPage
{
    public TablesPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

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