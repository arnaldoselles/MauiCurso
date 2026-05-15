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
            // Registro de ViewModels
            builder.Services.AddTransient<MainViewModel>();

            // Registro de Pages
            builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }
    }
}
