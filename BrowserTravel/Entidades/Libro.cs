using System;
using System.Collections.Generic;

namespace BrowserTravel.Entidades;

public partial class Libro
{
    public int Isbn { get; set; }

    public int EditorialesId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Sinopsis { get; set; }

    public string? NPaginas { get; set; }

    public virtual Editoriale Editoriales { get; set; } = null!;

    public virtual ICollection<Autore> Autores { get; } = new List<Autore>();
}
