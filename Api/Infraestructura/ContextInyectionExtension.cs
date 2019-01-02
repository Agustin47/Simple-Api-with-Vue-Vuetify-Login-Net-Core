
namespace Infraestructura
{
    using Context;
    using Microsoft.Extensions.DependencyInjection;

    public static class ContextInyectionExtension
    {

        public static void ContextInyections(this IServiceCollection services)
        {
            // Base de datos.
            services.InstallContext();

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<LivyContext.LivyDbContext>();

        }
    }
}
