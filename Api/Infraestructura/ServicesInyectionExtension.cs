
namespace Infraestructura
{
    using Contracts.Services;
    using Contracts.Security;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Security;

    public static class ServicesInyectionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ServicesInyections(this IServiceCollection services)
        {

            services.AddMediatR();

            services.AddTransient<IGetServices, GetServices>();
            services.AddTransient<ILoginService, LoginService>();
        }
    }
}
