using Api.Data.Context;
using APINucleo.Data.Repository;
using APINucleo.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository {
        
        public static void ConfigureDependenciesRepository (IServiceCollection serviceCollection) {
            serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository> ();
             serviceCollection.AddDbContext<MyContext> (options => options
            .UseOracle("Data Source=10.200.203.13:1521/fpwdev; User Id=grails;Password=grailsnew", b => b.UseOracleSQLCompatibility("11")));
        }
    }
}
