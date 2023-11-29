using ITLab2.MAUI.App.Services;
using ITLab2.MAUI.App.Views;
using Microsoft.Extensions.Logging;

namespace ITLab2.MAUI.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IRestService, RestService>();

            builder.Services.AddSingleton<DatabasesPage>();
            builder.Services.AddSingleton<CreateDatabasePage>();
            builder.Services.AddSingleton<TablesPage>();
            builder.Services.AddSingleton<AddUpdateTablePage>();
            builder.Services.AddSingleton<ColumnsPage>();
            builder.Services.AddSingleton<AddUpdateColumnPage>();
            builder.Services.AddSingleton<RowsPage>();
            builder.Services.AddSingleton<AddRowPage>();

            return builder.Build();
        }
    }
}
