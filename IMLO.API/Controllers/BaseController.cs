using IMLO.Entity.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace IMLO.API.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IActionResult CreateResponse<T>(string status, T data, string message)
    {
        var response = new Response<T>
        {
            Status = status,
            Data = data,
            Message = message
        };
        return Ok(response);
    }

    protected IActionResult CreateNotFoundResponse<T>(T data, string message)
    {
        var response = new Response<T>
        {
            Status = "99",
            Data = data,
            Message = message
        };

        return NotFound(response);
    }

    protected IActionResult CreateBadRequestResponse<T>(T data, string message)
    {
        var response = new Response<T>
        {
            Status = "99",
            Data = data,
            Message = message
        };

        return BadRequest(response);
    }

    protected async Task<IActionResult> ExecuteAsync(Func<Task<IActionResult>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    public async Task<IActionResult> ExecuteAsync<T>(Func<Task<HttpResponseMessage>> action)
    {
        try
        {
            var response = await action();
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var jsonResponseOk = await response.Content.ReadAsStringAsync();
                    var responseDataOk = JsonConvert.DeserializeObject<Response<T>>(jsonResponseOk);
                    return Ok(responseDataOk);
                case HttpStatusCode.NotFound:
                    var jsonResponseNotFound = await response.Content.ReadAsStringAsync();
                    var responseDataNotFound = JsonConvert.DeserializeObject<Response<T>>(jsonResponseNotFound);
                    return NotFound(responseDataNotFound);
                case HttpStatusCode.BadRequest:
                    var jsonResponseBadRequest = await response.Content.ReadAsStringAsync();
                    var responseDataBadRequest = JsonConvert.DeserializeObject<Response<T>>(jsonResponseBadRequest);
                    return BadRequest(responseDataBadRequest);
                default:
                    var jsonResponseDefault = await response.Content.ReadAsStringAsync();
                    var responseDataDefault = JsonConvert.DeserializeObject<Response<T>>(jsonResponseDefault);
                    return StatusCode((int)response.StatusCode, responseDataDefault);
            }
        }
        catch (HttpRequestException ex)
        {
            return BadRequest("Error al realizar la solicitud HTTP: " + ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest("Error inesperado: " + ex.Message);
        }
    }

    protected async Task<(string fileType, byte[] fileBytes)> ProcessFileAsync(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();
            var fileType = file.ContentType;
            return (fileType, fileBytes);
        }
    }

    protected async Task<IActionResult> HandleClientOperationAsync<T>(string dto, IFormFile? file, Func<T, Task<IActionResult>> clientOperation) where T : class
    {
        try
        {
            var model = JsonConvert.DeserializeObject<T>(dto);
            if (model == null)
            {
                return BadRequest("Invalid client data");
            }

            if (file != null && file.Length > 0)
            {
                (string fileType, byte[] fileBytes) = await ProcessFileAsync(file);
                var modelProperties = typeof(T).GetProperties();
                var logoProperty = modelProperties.FirstOrDefault(p => p.Name.Equals("Image", StringComparison.OrdinalIgnoreCase) || p.Name.Equals("Logo", StringComparison.OrdinalIgnoreCase));
                var fileTypeProperty = modelProperties.FirstOrDefault(p => p.Name.Equals("FileType", StringComparison.OrdinalIgnoreCase));
                if (logoProperty != null && fileTypeProperty != null)
                {
                    logoProperty.SetValue(model, fileBytes);
                    fileTypeProperty.SetValue(model, fileType);
                }
            }

            return await clientOperation(model);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing the client");
        }
    }
}