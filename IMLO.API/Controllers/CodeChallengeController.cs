using IMLO.API.Filters;
using IMLO.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IMLO.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(GlobalExceptionFilter))]
[ServiceFilter(typeof(ModelStateFilter))]
public class CodeChallengeController : BaseController
{
    private readonly ICodeChallengeService _codeChallengeService;

    public CodeChallengeController(ICodeChallengeService codeChallengeService)
    {
        _codeChallengeService = codeChallengeService;
    }

    [HttpGet]
    [Route("GetEvolucionMDAMTR")]
    public async Task<IActionResult> GetEvolucionMDAMTR(string nodo)
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.GetEvolucionPrecioNodo(nodo);

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("GetDiferenciaPromedioMDA_MTR")]
    public async Task<IActionResult> GetDiferenciaPromedioMDA_MTR()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.GetDiferenciaPromedioMDA_MTR();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("UnionMemTraMdaMtrDet")]
    public async Task<IActionResult> UnionMemTraMdaMtrDet()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.UnionMemTraMdaMtrDet();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("UnionMemTraMdaMtrTcDet")]
    public async Task<IActionResult> UnionMemTraMdaMtrTcDet()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.UnionMemTraMdaMtrTcDet();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("GeneraDatosPMLMayorQueTbFin")]
    public async Task<IActionResult> GeneraDatosPMLMayorQueTbFin()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.GeneraDatosPMLMayorQueTbFin();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("GeneraPromedioDiarioPML")]
    public async Task<IActionResult> GeneraPromedioDiarioPML()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.GeneraPromedioDiarioPML();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("GraficaPrecioNodoTBFin")]
    public async Task<IActionResult> GraficaPrecioNodoTBFin()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.GraficaPrecioNodoTBFin();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("PrecioNodoMDA_MTR")]
    public async Task<IActionResult> PrecioNodoMDA_MTR()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.PrecioNodoMDA_MTR();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("PrecioPromedioPorNodo")]
    public async Task<IActionResult> PrecioPromedioPorNodo()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.PrecioPromedioPorNodo();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("PrecioNodoEnDlls")]
    public async Task<IActionResult> PrecioNodoEnDlls()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.PrecioNodoEnDlls();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }

    [HttpGet]
    [Route("ListadoNodosPorFechaHora")]
    public async Task<IActionResult> ListadoNodosPorFechaHora()
    {
        return await ExecuteAsync(async () =>
        {
            var data = await _codeChallengeService.ListadoNodosPorFechaHora();

            if (data.Any())
                return CreateResponse("success", data, "success");

            return CreateNotFoundResponse<object>(null, "Registers not founds");
        });
    }
}
