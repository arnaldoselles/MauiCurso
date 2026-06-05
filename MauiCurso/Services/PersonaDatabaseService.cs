using MauiCurso.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCurso.Services
{
    public class PersonaDatabaseService
    {
        private SQLiteAsyncConnection? _database;

        private async Task Init()
        {
            if (_database is not null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "personas.db3");
            _database = new SQLiteAsyncConnection(databasePath);
            await _database.CreateTableAsync<Persona>();
        }

        public async Task<int> InsertarAsync(Persona persona)
        {
            await Init();
            return await _database!.InsertAsync(persona);
        }

        public async Task<List<Persona>> ObtenerTodosAsync()
        {
            await Init();
            return await _database!.Table<Persona>().ToListAsync();
        }

        public async Task<int> EliminarAsync(int id)
        {
            await Init();
            return await _database!.DeleteAsync<Persona>(id);
        }

        public async Task<int> ActualizarAsync(Persona persona)
        {
            await Init();
            return await _database!.UpdateAsync(persona);
        }
    }
}
