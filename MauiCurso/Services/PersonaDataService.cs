using MauiCurso.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCurso.Services
{
    public class PersonaDataService
    {
        private readonly PersonaDatabaseService _databaseService;

        public PersonaDataService(PersonaDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task GuardarPersonaAsync(Persona persona)
        {
            await _databaseService.InsertarAsync(persona);
        }

        public async Task<List<Persona>> ObtenerPersonasAsync()
        {
            return await _databaseService.ObtenerTodosAsync();
        }

        public async Task EliminarPersonaAsync(int id)
        {
            await _databaseService.EliminarAsync(id);
        }

    }
}
