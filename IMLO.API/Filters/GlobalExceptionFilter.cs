﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IMLO.API.Filters;

public class GlobalExceptionFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        var result = new ObjectResult($"Internal server error: {context.Exception.Message}")
        {
            StatusCode = 500
        };
        context.Result = result;
        return Task.CompletedTask;
    }
}