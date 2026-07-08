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
            var lista = await _database!.Table<Himno>().OrderBy(h => h.Numero).ToListAsync();

            foreach (var h in lista)
            {
                h.Letra = h.Letra
                    .Replace("\r\n", "\n")
                    .Replace("\r", "\n");
            }

            return lista;
        }


        public async Task<Himno?> ObtenerPorIdAsync(int id)
        {
            await Init();
            var himno = await _database!.Table<Himno>()
                .Where(h => h.Id == id)
                .FirstOrDefaultAsync();

            if (himno is not null)
            {
                himno.Letra = himno.Letra
                    .Replace("\r\n", "\n")
                    .Replace("\r", "\n");
            }

            return himno;
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
