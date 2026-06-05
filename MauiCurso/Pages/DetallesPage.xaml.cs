using MauiCurso.ViewModels;

namespace MauiCurso;

public partial class DetallesPage : ContentPage
{
    public DetallesPage(DetallesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;   //SIN ESTO LA VISTA NO VE EL VIEWMODEL
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Cargar personas cada vez que se muestra la página
        if (BindingContext is DetallesViewModel vm)
        {
            await vm.CargarPersonasCommand.ExecuteAsync(null);
        }
    }
}