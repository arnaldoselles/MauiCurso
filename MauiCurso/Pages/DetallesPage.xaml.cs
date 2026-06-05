using MauiCurso.ViewModels;

namespace MauiCurso;

public partial class DetallesPage : ContentPage
{
    public DetallesPage(DetallesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;   // ? SIN ESTO LA VISTA NO VE EL VIEWMODEL
    }
}