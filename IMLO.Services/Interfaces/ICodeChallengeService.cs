namespace IMLO.Services.Interfaces;

public interface ICodeChallengeService
{
    Task<IEnumerable<dynamic>> GetEvolucionPrecioNodo(string nodo);
    Task<IEnumerable<dynamic>> GetDiferenciaPromedioMDA_MTR();
    Task<IEnumerable<dynamic>> UnionMemTraMdaMtrDet();
    Task<IEnumerable<dynamic>> UnionMemTraMdaMtrTcDet();
    Task<IEnumerable<dynamic>> GeneraDatosPMLMayorQueTbFin();
    Task<IEnumerable<dynamic>> GeneraPromedioDiarioPML();
    Task<IEnumerable<dynamic>> GraficaPrecioNodoTBFin();
    Task<IEnumerable<dynamic>> PrecioNodoMDA_MTR();
    Task<IEnumerable<dynamic>> PrecioPromedioPorNodo();
    Task<IEnumerable<dynamic>> PrecioNodoEnDlls();
    Task<IEnumerable<dynamic>> ListadoNodosPorFechaHora();
}
