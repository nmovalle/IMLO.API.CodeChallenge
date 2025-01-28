using IMLO.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace IMLO.Services.Services;

public class CodeChallengeService : ICodeChallengeService
{
    private readonly StoredProcedureExecutor _storedProcedureExecutor;
    public CodeChallengeService(StoredProcedureExecutor storedProcedureExecutor)
    {
        _storedProcedureExecutor = storedProcedureExecutor;

    }

    public async Task<IEnumerable<dynamic>> GetEvolucionPrecioNodo(string nodo)
    {
        var parameters = new[]
        {
            new SqlParameter("@Nodo", SqlDbType.NVarChar) { Value = nodo }
        };

        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_GetEvolucionPrecioNodo", parameters);
    }

    public async Task<IEnumerable<dynamic>> GetDiferenciaPromedioMDA_MTR()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_GetDiferenciaPromedioMDA_MTR", null);
    }
    public async Task<IEnumerable<dynamic>> UnionMemTraMdaMtrDet()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_UnionMemTraMdaMtrDet", null);
    }
    public async Task<IEnumerable<dynamic>> UnionMemTraMdaMtrTcDet()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_UnionMemTraMdaMtrTcDet", null);
    }
    public async Task<IEnumerable<dynamic>> GeneraDatosPMLMayorQueTbFin()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_GeneraDatosPMLMayorQueTbFin", null);
    }
    public async Task<IEnumerable<dynamic>> GeneraPromedioDiarioPML()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_GeneraPromedioDiarioPML", null);
    }
    public async Task<IEnumerable<dynamic>> GraficaPrecioNodoTBFin()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_GraficaPrecioNodoTBFin", null);
    }
    public async Task<IEnumerable<dynamic>> PrecioNodoMDA_MTR()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_PrecioNodoMDA_MTR", null);
    }
    public async Task<IEnumerable<dynamic>> PrecioPromedioPorNodo()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_PrecioPromedioPorNodo", null);
    }
    public async Task<IEnumerable<dynamic>> PrecioNodoEnDlls()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_PrecioNodoEnDlls", null);
    }
    public async Task<IEnumerable<dynamic>> ListadoNodosPorFechaHora()
    {
        return await _storedProcedureExecutor.ExecuteStoredProcedureAsync("MemSch.SP_ListadoNodosPorFechaHora", null);
    }
}
