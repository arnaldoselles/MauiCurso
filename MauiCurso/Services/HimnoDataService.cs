using MauiCurso.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCurso.Services
{
    public class HimnoDataService
    {
        private readonly HimnoDatabaseService _databaseService;

        public HimnoDataService(HimnoDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task GuardarHimnoAsync(Himno himno)
        {
            await _databaseService.InsertarAsync(himno);
        }

        public async Task<List<Himno>> ObtenerHimnosAsync()
        {
            return await _databaseService.ObtenerTodosAsync();
        }

        public async Task<Himno?> ObtenerHimnoPorIdAsync(int id)
        {
            return await _databaseService.ObtenerPorIdAsync(id);
        }

        public async Task EliminarHimnoAsync(int id)
        {
            await _databaseService.EliminarAsync(id);
        }

        public async Task ActualizarHimnoAsync(Himno himno)
        {
            await _databaseService.ActualizarAsync(himno);
        }
    }
}
