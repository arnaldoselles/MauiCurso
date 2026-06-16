using Microsoft.Maui.Controls;
using MauiCurso.Pages;

namespace MauiCurso;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(DetallesPage), typeof(DetallesPage));
        Routing.RegisterRoute(nameof(DetalleHimnoPage), typeof(DetalleHimnoPage));
        Routing.RegisterRoute("detallehimno", typeof(DetalleHimnoPage));
        
    }
}
