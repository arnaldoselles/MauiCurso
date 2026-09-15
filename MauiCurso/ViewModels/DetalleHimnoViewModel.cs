using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCurso.Models;
using MauiCurso.Pages;
using MauiCurso.Services;

namespace MauiCurso.ViewModels
{
    [QueryProperty(nameof(HimnoId), "himnoId")]
    public partial class DetalleHimnoViewModel : ObservableObject
    {
        private readonly HimnoDataService _himnoService;

        [ObservableProperty]
        private Himno? himnoSeleccionado;

        [ObservableProperty]
        private int himnoId;

        // ?? Nueva propiedad para el tamaño de letra
        [ObservableProperty]
        private double fontSize = 17;

        public DetalleHimnoViewModel(HimnoDataService himnoService)
        {
            _himnoService = himnoService;
        }

        partial void OnHimnoIdChanged(int value)
        {
            CargarHimnoCommand.Execute(null);
        }

        [RelayCommand]
        public async Task CargarHimno()
        {
            try
            {
                if (HimnoId > 0)
                {
                    HimnoSeleccionado = await _himnoService.ObtenerHimnoPorIdAsync(HimnoId);
                }
            }
            catch (Exception ex)
            {
                await Application.Current!.MainPage!.DisplayAlert("Error", $"Error al cargar: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task Volver()
        {
            await Shell.Current.GoToAsync("..");
        }

        // ?? Comandos para aumentar/disminuir letra
        [RelayCommand]
        private void AumentarLetra()
        {
            FontSize += 2;
        }

        [RelayCommand]
        private void DisminuirLetra()
        {
            if (FontSize > 10)
                FontSize -= 2;
        }

        //Nuevo comando para compartir himno
        [RelayCommand]
        public async Task CompartirHimno(Himno himno)
        {
            if (himno == null) return;

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = $"Himno #{himno.Numero}\n{himno.Nombre}\n\n{himno.Letra}",
                Title = "Compartir himno"
            });
        }

    }
}
