using Microsoft.EntityFrameworkCore;
using Store.Api.Dal;


namespace Store.Api.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DatabaseConnection")
                );
            });

           

        }
    }
}
