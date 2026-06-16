using MauiCurso.Pages;
using MauiCurso.Services;
using MauiCurso.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiCurso
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

            // Copiar base de datos prellenada al iniciar la app
            DatabaseInitializer.CopyDatabaseIfNeeded();

            // Páginas 
            builder.Services.AddSingleton<DetallesPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DetalleHimnoPage>();
            

            // ViewModels
            builder.Services.AddSingleton<DetallesViewModel>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<DetalleHimnoViewModel>();
            

            // Servicios
            builder.Services.AddSingleton<HimnoDatabaseService>();
            builder.Services.AddSingleton<HimnoDataService>();

            return builder.Build();
        }
    }
}
