using MauiCurso.Pages;

namespace MauiCurso
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DetallesPage), typeof(DetallesPage));
            Routing.RegisterRoute(nameof(OtherPage), typeof(OtherPage));
        }
    }
}
