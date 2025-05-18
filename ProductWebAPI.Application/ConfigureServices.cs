using System.Reflection;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Convey.Docs.Swagger;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductWebAPI.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddConvey().AddSwaggerDocs();
        services.AddConvey().AddCommandHandlers().AddInMemoryCommandDispatcher();
        services.AddConvey().AddQueryHandlers().AddInMemoryQueryDispatcher();
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation(config =>
        {
            config.DisableDataAnnotationsValidation = true;
        });
        services.AddFluentValidationClientsideAdapters();
        return services;
    }
    
}