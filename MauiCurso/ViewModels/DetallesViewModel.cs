using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCurso.Models;
using MauiCurso.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCurso.ViewModels
{
    
    public partial class DetallesViewModel : ObservableObject 
    {
        private readonly PersonaDataService _personaService;

        [ObservableProperty]
        private ObservableCollection<Persona> personaslist = new();

        [ObservableProperty]
        private bool noHayPersonas = true;

        [ObservableProperty]
        private Persona persona;

        public DetallesViewModel(PersonaDataService personaService)
        {
            _personaService = personaService;
        }

        [RelayCommand]
        public async Task CargarPersonas()
        {
            try
            {
                var listaPersonas = await _personaService.ObtenerPersonasAsync();

                Personaslist.Clear();
                foreach (var persona in listaPersonas)
                {
                    Personaslist.Add(persona);
                }

                NoHayPersonas = Personaslist.Count == 0;
            }
            catch (Exception ex)
            {
                await Application.Current!.MainPage!.DisplayAlert("Error", $"Error al cargar: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        public async Task EliminarPersona(int id)
        {
            try
            {
                await _personaService.EliminarPersonaAsync(id);
                await CargarPersonasCommand.ExecuteAsync(null);
            }
            catch (Exception ex)
            {
                await Application.Current!.MainPage!.DisplayAlert("Error", $"Error al eliminar: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task Volver()
        {
            await Shell.Current.GoToAsync("..");
        }

       
    }
}
