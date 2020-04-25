using BoringGames.Core.Services;
using BoringGames.Core.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BoringGames.API.Ioc
{
    /// <summary>
    /// IoC installer for services
    /// </summary>
    public class ServicesIocInstaller
    {
        private readonly IServiceCollection _services;

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesIocInstaller(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// Install procedure
        /// </summary>
        /// <param name="services">Services config object</param>
        public void Install()
        {
            _services.AddSingleton<IPlayerService, PlayerService>();
            _services.AddSingleton<IBoringToeService, BoringToeService>();
        }
    }
}
