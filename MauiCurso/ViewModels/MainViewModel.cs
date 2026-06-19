using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCurso.Models;
using MauiCurso.Services;

namespace MauiCurso.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly HimnoDataService _himnoService;

        public MainViewModel(HimnoDataService himnoService)
        {
            _himnoService = himnoService;
        }

        [ObservableProperty]
        private string numero = string.Empty;

        [ObservableProperty]
        private string nombre = string.Empty;

        [ObservableProperty]
        private string letra = string.Empty;

        [ObservableProperty]
        private string mensajeError = string.Empty;

        [ObservableProperty]
        private bool hayError;

        [RelayCommand]
        private async Task IrADetalles()
        {
            // Validación
            if (string.IsNullOrWhiteSpace(Numero))
            {
                MostrarError("El número del himno no puede estar vacío");
                return;
            }

            if (!int.TryParse(Numero, out int numeroHimno) || numeroHimno <= 0)
            {
                MostrarError("El número debe ser un número mayor que 0");
                return;
            }

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                MostrarError("El nombre del himno no puede estar vacío");
                return;
            }

            if (string.IsNullOrWhiteSpace(Letra))
            {
                MostrarError("La letra del himno no puede estar vacía");
                return;
            }

            // Crear himno y guardar en BD
            var himno = new Himno
            {
                Numero = numeroHimno,
                Nombre = Nombre.Trim(),
                Letra = Letra.Trim()
            };

            try
            {
                await _himnoService.GuardarHimnoAsync(himno);
                HayError = false;

                // Limpiar campos
                Numero = string.Empty;
                Nombre = string.Empty;
                Letra = string.Empty;

                // Navegar a detalles
                await Shell.Current.GoToAsync("//detalles");
            }
            catch (Exception ex)
            {
                MostrarError($"Error al guardar: {ex.Message}");
            }
        }

        private void MostrarError(string mensaje)
        {
            MensajeError = mensaje;
            HayError = true;
        }

        [RelayCommand]
        private async Task VolverALista()
        {
            HayError = false;
            await Shell.Current.GoToAsync("//detalles");
            //await Shell.Current.GoToAsync(nameof(DetallesPage));
        }



    }
}

