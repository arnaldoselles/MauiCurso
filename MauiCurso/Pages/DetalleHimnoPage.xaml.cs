namespace MauiCurso.Pages;
using MauiCurso.ViewModels;

public partial class DetalleHimnoPage : ContentPage
{
	public DetalleHimnoPage(DetalleHimnoViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
        
    }
}