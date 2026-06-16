using SQLite;

namespace MauiCurso.Models
{
    [Table("himnos")]
    public class Himno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public int Numero { get; set; }

        [NotNull]
        public string Nombre { get; set; }

        [NotNull]
        public string Letra { get; set; }
    }
}
