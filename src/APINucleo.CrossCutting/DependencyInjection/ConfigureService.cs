using APINucleo.Domain.Interfaces.Repository.Services;
using APINucleo.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection {
    public class ConfigureService {
        public static void ConfigureDependenciesService (IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<IUsuarioService, UsuarioService> ();
            serviceCollection.AddTransient<ILoginService, LoginService> ();
        }
    }
}
