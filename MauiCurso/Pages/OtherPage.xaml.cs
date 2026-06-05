using MauiCurso.ViewModels;

namespace MauiCurso.Pages;

public partial class OtherPage : ContentPage
{
	public OtherPage(OtherViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}