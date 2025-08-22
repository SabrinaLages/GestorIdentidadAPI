using System;
using System.Collections.Generic;

namespace PrimerParcial.EF;

public partial class Tramite
{
    public int IdTramite { get; set; }

    public string Name { get; set; } = null!;

    public int Costo { get; set; }

    public bool EstaActivo { get; set; }
}
