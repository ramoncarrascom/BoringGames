using BoringGames.Core.Repositories;
using BoringGames.Core.Repositories.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BoringGames.API.Ioc
{
    /// <summary>
    /// IoC installer for repositories
    /// </summary>
    public class RepositoriesIocInstaller
    {
        private readonly IServiceCollection _services;

        /// <summary>
        /// Constructor
        /// </summary>
        public RepositoriesIocInstaller(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// Install procedure
        /// </summary>
        /// <param name="services">Services config object</param>
        public void Install()
        {
            _services.AddSingleton<IBoringToeRepository, BoringToeSetRepository>();
            _services.AddSingleton<IPlayerRepository, PlayerSetRepository>();
        }
    }
}
