using System;
using System.Collections;
using MauiCurso.ViewModels;

namespace MauiCurso;

public partial class DetallesPage : ContentPage
{
    private int _currentIndex = 0;
    private const int ScrollStep = 10;

    public DetallesPage(DetallesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;   //SIN ESTO LA VISTA NO VE EL VIEWMODEL
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is DetallesViewModel vm)
        {
            await vm.CargarHimnosCommand.ExecuteAsync(null);
        }

        // Reiniciar índice al mostrar la página
        _currentIndex = 0;
    }

    private void ScrollLinesUp_Clicked(object sender, EventArgs e)
    {
        if (HimnosCollectionView?.ItemsSource is IList items && items.Count > 0)
        {
            _currentIndex = Math.Max(0, _currentIndex - ScrollStep);
            HimnosCollectionView.ScrollTo(_currentIndex, position: ScrollToPosition.Start, animate: true);
        }
    }

    private void ScrollLinesDown_Clicked(object sender, EventArgs e)
    {
        if (HimnosCollectionView?.ItemsSource is IList items && items.Count > 0)
        {
            _currentIndex = Math.Min(items.Count - 1, _currentIndex + ScrollStep);
            HimnosCollectionView.ScrollTo(_currentIndex, position: ScrollToPosition.Start, animate: true);
        }
    }
}