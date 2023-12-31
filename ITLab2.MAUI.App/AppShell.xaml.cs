﻿using ITLab2.MAUI.App.Views;

namespace ITLab2.MAUI.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DatabasesPage), typeof(DatabasesPage));
            Routing.RegisterRoute(nameof(CreateDatabasePage), typeof(CreateDatabasePage));
            Routing.RegisterRoute(nameof(TablesPage), typeof(TablesPage));
            Routing.RegisterRoute(nameof(AddUpdateTablePage), typeof(AddUpdateTablePage));
            Routing.RegisterRoute(nameof(ColumnsPage), typeof(ColumnsPage));
            Routing.RegisterRoute(nameof(AddUpdateColumnPage), typeof(AddUpdateColumnPage));
            Routing.RegisterRoute(nameof(RowsPage), typeof(RowsPage));
            Routing.RegisterRoute(nameof(AddRowPage), typeof(AddRowPage));
        }
    }
}
