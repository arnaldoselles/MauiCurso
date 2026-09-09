using System;
using System.Collections;
using Microsoft.Maui.Controls;
using MauiCurso.ViewModels;

namespace MauiCurso;

public partial class DetallesPage : ContentPage
{
    private int _firstVisibleIndex = 0;
    private int _lastVisibleIndex = 0;

    public DetallesPage(DetallesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is DetallesViewModel vm)
        {
            await vm.CargarHimnosCommand.ExecuteAsync(null);
        }

        // Suscribirse para conocer los índices visibles reales
        HimnosCollectionView.Scrolled += HimnosCollectionView_Scrolled;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        HimnosCollectionView.Scrolled -= HimnosCollectionView_Scrolled;
    }

    private void HimnosCollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        if (e.FirstVisibleItemIndex >= 0)
            _firstVisibleIndex = e.FirstVisibleItemIndex;
        if (e.LastVisibleItemIndex >= 0)
            _lastVisibleIndex = e.LastVisibleItemIndex;
    }

    private void ScrollLinesUp_Clicked(object sender, EventArgs e)
    {
        if (HimnosCollectionView?.ItemsSource is IList items && items.Count > 0)
        {
            int pageSize = Math.Max(1, _lastVisibleIndex - _firstVisibleIndex + 1);
            int targetIndex = Math.Max(0, _firstVisibleIndex - pageSize);
            var item = items[targetIndex];
            HimnosCollectionView.ScrollTo(item, position: ScrollToPosition.Start, animate: true);
        }
    }

    private void ScrollLinesDown_Clicked(object sender, EventArgs e)
    {
        if (HimnosCollectionView?.ItemsSource is IList items && items.Count > 0)
        {
            int pageSize = Math.Max(1, _lastVisibleIndex - _firstVisibleIndex + 1);
            int targetIndex = Math.Min(items.Count - 1, _firstVisibleIndex + pageSize);
            var item = items[targetIndex];
            HimnosCollectionView.ScrollTo(item, position: ScrollToPosition.Start, animate: true);
        }
    }
}