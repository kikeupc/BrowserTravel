using System;
using System.Collections.Generic;

namespace BrowserTravel.Entidades;

public partial class Autore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public virtual ICollection<Libro> LibrosIsbns { get; } = new List<Libro>();
}
