using System;
using System.Collections.Generic;

namespace PrimerParcial.EF;

public partial class Titulare
{
    public int IdTitulares { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Dni { get; set; }

    public string NumeroTramite { get; set; } = null!;
}
