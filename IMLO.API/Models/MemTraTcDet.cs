using System;
using System.Collections.Generic;

namespace IMLO.API.Models;

public partial class MemTraTcDet
{
    public int? IdTc { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? Valor { get; set; }

    public DateTime? FechaUltimaMod { get; set; }

    public string? NombrePcMod { get; set; }

    public int? ClaUsuarioMod { get; set; }
}
