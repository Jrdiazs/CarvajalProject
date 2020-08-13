using Carvajal.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Carvajal.Services
{
    public class ConfigureInitServices
    {
        /// <summary>
        /// Inicia el contenedor de servicios 
        /// </summary>
        /// <param name="services">servicios</param>
        public static void InitServices(IServiceCollection services)
        {
            Container(services);
        }

        /// <summary>
        /// Inicia el contenedor de servicios y repositorios
        /// </summary>
        /// <param name="services"></param>
        private static void Container(IServiceCollection services)
        {
            //DataBase
            services.AddScoped<IUserAppData, UserAppData>();
            services.AddScoped<ITypeIdData, TypeIdData>();
            services.AddScoped<IGamePieceData, GamePieceData>();
            services.AddScoped<IMatchData, MatchData>();
            services.AddScoped<IMatchDetailData, MatchDetailData>();
            services.AddScoped<ITypeIdData, TypeIdData>();

            //Services
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IAuthServices, AuthServices>();
        }
    }
}