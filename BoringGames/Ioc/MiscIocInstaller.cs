using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Data;
using TicTacToe.Data.Implementation;

namespace BoringGames.API.Ioc
{
    /// <summary>
    /// IoC installer for misc components
    /// </summary>
    public class MiscIocInstaller
    {
        private readonly IServiceCollection _services;

        /// <summary>
        /// Constructor
        /// </summary>
        public MiscIocInstaller(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// Install procedure
        /// </summary>
        /// <param name="services">Services config object</param>
        public void Install()
        {
            _services.AddTransient<IGrid, Grid>();
        }
    }
}
