using System;
using System.Collections.Generic;

namespace BrowserTravel.Entidades;

public partial class Editoriale
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Sede { get; set; }

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
