using Kotas.Pokemon.Domain.Handlers;
using Kotas.Pokemon.Domain.Repositories;
using Kotas.Pokemon.Infra.Data.Repositories;
using Kotas.Pokemon.Infra.Interfaces;
using Kotas.Pokemon.Infra.Services;
using Kotas.Pokemon.Ioc.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;

namespace Kotas.Pokemon.Ioc;

public static class ServiceIoC
{
    public static void SolveDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        #region Db
        Batteries.Init();
        #endregion

        #region Helpers

        #endregion

        #region Handlers
        services.AddTransient<PokemonHandler>();
        services.AddTransient<PokeMasterHandler>();
        #endregion

        #region Serviços
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IPokemonService, PokemonService>();

        services.AddHttpClient<IPokemonService, PokemonService>();
        #endregion

        #region Repositórios
        services.AddTransient<IPokemonRepository, PokemonRepository>();
        services.AddTransient<IPokeMasterRepository, PokeMasterRepository>();
        #endregion

        #region Global Exception
        services.AddTransient<ConfigureGlobalException>();
        #endregion

    }

    public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ConfigureGlobalException>();
        return app;
    }
}
