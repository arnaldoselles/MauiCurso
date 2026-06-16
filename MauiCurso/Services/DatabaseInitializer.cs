using System.IO;

namespace MauiCurso.Services
{
    public static class DatabaseInitializer
    {
        public static void CopyDatabaseIfNeeded()
        {
            string dbName = "himnario.db3";
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);

            if (!File.Exists(dbPath))
            {
                using var stream = FileSystem.OpenAppPackageFileAsync(dbName).Result;
                using var fileStream = File.Create(dbPath);
                stream.CopyTo(fileStream);
            }
        }
    }
}