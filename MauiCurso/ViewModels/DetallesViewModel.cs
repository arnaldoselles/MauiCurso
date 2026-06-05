using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCurso.Models;
using MauiCurso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCurso.ViewModels
{
    
    public partial class DetallesViewModel : ObservableObject 
    {

        [ObservableProperty]
        private Persona persona;

        public DetallesViewModel(PersonaDataService personaService)
        {
            Persona = personaService.ObjetoPersona;
            //System.Diagnostics.Debug.WriteLine($"Persona: {Persona?.nombre} {Persona?.apellidos} {Persona?.edad}");
        }

        
        [RelayCommand]
        private async Task Volver()
        {
            await Shell.Current.GoToAsync("..");
        }

       
    }
}
