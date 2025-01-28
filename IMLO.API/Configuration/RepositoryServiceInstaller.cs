using IMLO.Data;
using IMLO.Data.Interfaces;
using IMLO.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IMLO.API.Configuration;

public class RepositoryServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IMLODbContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(IMLODbContext))));
        services.AddScoped<DbContext, IMLODbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}