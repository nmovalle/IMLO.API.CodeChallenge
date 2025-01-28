using IMLO.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace IMLO.Services;

public class StoredProcedureExecutor
{
    private readonly IMLODbContext _imloBdContext;

    public StoredProcedureExecutor(IMLODbContext imloBdContext)
    {
        _imloBdContext = imloBdContext;
    }

    public async Task<IEnumerable<dynamic>> ExecuteStoredProcedureAsync(string storedProcedureName, params SqlParameter[] parameters)
    {
        using var command = _imloBdContext.Database.GetDbConnection().CreateCommand();
        command.CommandText = storedProcedureName;
        command.CommandType = System.Data.CommandType.StoredProcedure;

        if (parameters != null && parameters.Length > 0)
        {
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }

        if (command.Connection.State != System.Data.ConnectionState.Open)
        {
            await command.Connection.OpenAsync();
        }

        using var result = await command.ExecuteReaderAsync();
        var dynamicResults = new List<dynamic>();

        while (await result.ReadAsync())
        {
            dynamic dynamicResult = new ExpandoObject();
            var rowDict = (IDictionary<string, object>)dynamicResult;

            for (int i = 0; i < result.FieldCount; i++)
            {
                rowDict[result.GetName(i)] = result.GetValue(i);
            }

            dynamicResults.Add(dynamicResult);
        }

        return dynamicResults;
    }

    public async Task<Dictionary<string, object>> ExecuteStoredProcedureWithOutputParametersAsync(
        string storedProcedureName, params SqlParameter[] parameters)
    {
        using var command = _imloBdContext.Database.GetDbConnection().CreateCommand();
        command.CommandText = storedProcedureName;
        command.CommandType = System.Data.CommandType.StoredProcedure;

        if (parameters != null && parameters.Length > 0)
        {
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }

        if (command.Connection.State != System.Data.ConnectionState.Open)
        {
            await command.Connection.OpenAsync();
        }

        await command.ExecuteNonQueryAsync();

        var outputParameters = new Dictionary<string, object>();

        foreach (var param in parameters)
        {
            if (param.Direction == System.Data.ParameterDirection.Output || param.Direction == System.Data.ParameterDirection.InputOutput)
            {
                outputParameters[param.ParameterName] = param.Value;
            }
        }

        return outputParameters;
    }
}