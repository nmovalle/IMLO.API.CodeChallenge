using System;
using System.Collections.Generic;

namespace IMLO.API.Models;

public partial class MemTraTbfinVw
{
    public DateOnly? Fecha { get; set; }

    public decimal? TbFin { get; set; }

    public decimal? TbFinTgr { get; set; }
}
