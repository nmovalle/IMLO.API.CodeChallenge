namespace IMLO.Entity.Models;

public partial class MemTraMtrdet
{
    public long? IdMtr { get; set; }

    public string ClaNodo { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public byte Hora { get; set; }

    public decimal? Pml { get; set; }

    public decimal? PmlEne { get; set; }

    public decimal? PmlPer { get; set; }

    public decimal? PmlCng { get; set; }

    public DateTime? FechaUltimaMod { get; set; }

    public string? NombrePcMod { get; set; }

    public int? ClaUsuarioMod { get; set; }
}
