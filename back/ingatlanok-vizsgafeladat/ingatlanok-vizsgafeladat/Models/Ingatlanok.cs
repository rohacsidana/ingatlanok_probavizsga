using System;
using System.Collections.Generic;

namespace ingatlanok_vizsgafeladat.Models;

public partial class Ingatlanok
{
    public int Id { get; set; }

    public int Kategoria { get; set; }

    public string? Leiras { get; set; }

    public DateTime? HirdetesDatuma { get; set; }

    public bool Tehermentes { get; set; }

    public int Ar { get; set; }

    public string? KepUrl { get; set; }

    public virtual Kategoriak KategoriaNavigation { get; set; } = null!;
}
