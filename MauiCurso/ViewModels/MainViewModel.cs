using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCurso.Models;
using MauiCurso.Pages;
using MauiCurso.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiCurso.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly PersonaDataService personaService;

        public MainViewModel(PersonaDataService personaService)
        {
            this.personaService = personaService;
        }

        [ObservableProperty]
        private string nombre= string.Empty;

        [ObservableProperty]
        private string apellidos=string.Empty;

        [ObservableProperty]
        private string edad= string.Empty;

        [ObservableProperty]
        private string mensajeError= string.Empty;

        [ObservableProperty]
        private bool hayError;

        [RelayCommand]
        private async Task IrADetalles()
        {
            // Validación
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                MostrarError("El nombre no puede estar vacío");
                return;
            }

            if (string.IsNullOrWhiteSpace(Apellidos))
            {
                MostrarError("Los apellidos no pueden estar vacíos");
                return;
            }

            if (!int.TryParse(Edad, out int edadNum) || edadNum <= 0)
            {
                MostrarError("La edad debe ser un número mayor que 0");
                return;
            }

            // Crear persona y guardar en BD
            var persona = new Persona
            {
                Nombre = Nombre,
                Apellidos = Apellidos,
                Edad = edadNum
            };

            try
            {
                await personaService.GuardarPersonaAsync(persona);
                HayError = false;

                // Limpiar campos
                Nombre = string.Empty;
                Apellidos = string.Empty;
                Edad = string.Empty;

                // Navegar a detalles
                await Shell.Current.GoToAsync(nameof(DetallesPage));
            }
            catch (Exception ex)
            {
                MostrarError($"Error al guardar: {ex.Message}");
            }

            ////  LIMPIAR LOS ENTRYS
            //Nombre = string.Empty;
            //Apellidos = string.Empty;
            //Edad = string.Empty;
        }

        private void MostrarError(string mensaje)
        {
            MensajeError = mensaje;
            HayError = true;
        }

        [RelayCommand]
        private async Task IrAOtra()
        {
            
            await Shell.Current.GoToAsync(nameof(OtherPage));
        }


    }

}

