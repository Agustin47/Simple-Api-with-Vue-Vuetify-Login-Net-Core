
namespace Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ContextInstaller
    {

        private static string _conectionString = "Server=(localdb)\\mssqllocaldb;Database=LivyDataBase;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static IServiceCollection InstallContext(this IServiceCollection services)
        =>
            services.AddDbContext<LivyDbContext>(options =>
                options.UseSqlServer(_conectionString));

    }
}
