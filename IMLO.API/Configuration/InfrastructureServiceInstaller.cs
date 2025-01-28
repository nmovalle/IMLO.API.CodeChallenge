using IMLO.API.Filters;
using IMLO.API.Middlewares;
using IMLO.Services;
using IMLO.Services.Interfaces;
using IMLO.Services.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IMLO.API.Configuration;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();

        services.AddScoped<StoredProcedureExecutor>();
        services.AddScoped<ViewExecutor>();

        //services for features
        services.AddScoped<ICodeChallengeService, CodeChallengeService>();

        services.AddScoped(typeof(IMapperService<,>), typeof(MapperService<,>));

        services.AddAutoMapper(typeof(Program));
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddScoped<GlobalExceptionFilter>();
        services.AddScoped<ModelStateFilter>();
    }
}