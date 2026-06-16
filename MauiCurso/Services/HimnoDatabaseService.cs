using SQLite;
using MauiCurso.Models;

namespace MauiCurso.Services
{
    public class HimnoDatabaseService
    {
        private SQLiteAsyncConnection? _database;

        private async Task Init()
        {
            if (_database is not null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "himnario.db3");
            _database = new SQLiteAsyncConnection(databasePath);
            await _database.CreateTableAsync<Himno>();
        }

        public async Task<int> InsertarAsync(Himno himno)
        {
            await Init();
            return await _database!.InsertAsync(himno);
        }

        public async Task<List<Himno>> ObtenerTodosAsync()
        {
            await Init();
            return await _database!.Table<Himno>().OrderBy(h => h.Numero).ToListAsync();
        }

        public async Task<Himno?> ObtenerPorIdAsync(int id)
        {
            await Init();
            return await _database!.Table<Himno>()
                .Where(h => h.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> EliminarAsync(int id)
        {
            await Init();
            return await _database!.DeleteAsync<Himno>(id);
        }

        public async Task<int> ActualizarAsync(Himno himno)
        {
            await Init();
            return await _database!.UpdateAsync(himno);
        }
    }
}
