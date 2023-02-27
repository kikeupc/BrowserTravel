using BrowserTravel.Entidades;

namespace BrowserTravel.Models
{
    public class LibroViewModel
    {
        public int Isbn { get; set; }

        public int EditorialesId { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Sinopsis { get; set; }

        public string? NPaginas { get; set; }

        public Editoriale Editoriales { get; set; } = null!;

        public ICollection<Autore> Autores { get; set; } = new List<Autore>();
    }
}
