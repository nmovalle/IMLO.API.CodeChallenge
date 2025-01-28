namespace IMLO.Entity.DTO;

public partial class MemTraTcDetDTO
{
    public int? IdTc { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? Valor { get; set; }

    public DateTime? FechaUltimaMod { get; set; }

    public string? NombrePcMod { get; set; }

    public int? ClaUsuarioMod { get; set; }
}
