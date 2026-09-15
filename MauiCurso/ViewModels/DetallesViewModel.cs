using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCurso.Models;
using MauiCurso.Pages;
using MauiCurso.Services;
using System.Collections.ObjectModel;

namespace MauiCurso.ViewModels
{
    public partial class DetallesViewModel : ObservableObject 
    {
        private readonly HimnoDataService _himnoService;
        private List<Himno> _todoLosHimnos = new();

        [ObservableProperty]
        private ObservableCollection<Himno> himnos = new();

        [ObservableProperty]
        private bool noHayHimnos = true;

        [ObservableProperty]
        private string textoBusqueda = string.Empty;

        [ObservableProperty]
        private Himno? himnoSeleccionado;

        public DetallesViewModel(HimnoDataService himnoService)
        {
            _himnoService = himnoService;
        }

        partial void OnTextoBusquedaChanged(string value)
        {
            FiltrarHimnos();
        }

        [RelayCommand]
        public async Task CargarHimnos()
        {
            try
            {
                _todoLosHimnos = await _himnoService.ObtenerHimnosAsync();
                FiltrarHimnos();
            }
            catch (Exception ex)
            {
                await Application.Current!.MainPage!.DisplayAlert("Error", $"Error al cargar: {ex.Message}", "OK");
            }
        }

        private void FiltrarHimnos()
        {
            Himnos.Clear();

            var filtrados = _todoLosHimnos;

            if (!string.IsNullOrWhiteSpace(TextoBusqueda))
            {
                var busqueda = TextoBusqueda.ToLower().Trim();

                filtrados = _todoLosHimnos.Where(h =>
                    h.Nombre.ToLower().Contains(busqueda) ||
                    h.Numero.ToString().Contains(busqueda)
                ).ToList();
            }

            foreach (var himno in filtrados)
            {
                Himnos.Add(himno);
            }

            NoHayHimnos = Himnos.Count == 0;
        }

        [RelayCommand]
        public async Task VerDetalleHimno(Himno himno)
        {
            if (himno is not null)
            {
                await Shell.Current.GoToAsync($"detallehimno?himnoId={himno.Id}");
            }
        }

        [RelayCommand]
        public async Task EliminarHimno(int id)
        {
            // Buscar el himno en la colección
            var himno = Himnos.FirstOrDefault(h => h.Id == id);

            if (himno != null && himno.Numero <= 192)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Aviso",
                    $"El himno número {himno.Numero} no puede eliminarse porque es parte del original, solo se pueden eliminar los himnos creados por usted",
                    "OK"
                );
                return; // salir sin eliminar
            }

            bool confirmar = await Application.Current.MainPage.DisplayAlert(
                "Confirmar eliminación",
                "¿Deseas eliminar este himno?",
                "Sí",
                "No");

            if (!confirmar)
                return;

            try
            {
                await _himnoService.EliminarHimnoAsync(id);
                await CargarHimnosCommand.ExecuteAsync(null);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al eliminar: {ex.Message}", "OK");
            }
        }



        [RelayCommand]
        private async Task IrANuevoHimno()
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
            
        }

        [RelayCommand]
        public void LimpiarBusqueda()
        {
            TextoBusqueda = string.Empty;
        }

        
    }
}
