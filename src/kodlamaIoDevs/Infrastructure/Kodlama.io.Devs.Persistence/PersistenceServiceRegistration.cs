using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;
using Kodlama.io.Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<KodlamaIoDevsDbContext>(
            options => options
                .UseSqlServer(configuration.GetConnectionString("SqlServer")
        ));

        services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
        
        return services;
    }
}