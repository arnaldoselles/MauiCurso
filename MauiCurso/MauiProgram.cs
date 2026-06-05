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
            // Páginas
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DetallesPage>();
            builder.Services.AddTransient<OtherPage>();

            // ViewModels
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<DetallesViewModel>();
            builder .Services.AddTransient<OtherViewModel>();

            //Servicios
            builder.Services.AddSingleton<PersonaDataService>();
            builder.Services.AddSingleton<PersonaDatabaseService>();

            return builder.Build();
        }
    }
}
