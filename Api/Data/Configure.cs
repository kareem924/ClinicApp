
using Microsoft.Extensions.DependencyInjection;
namespace Data
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            //Context lifetime defaults to "scoped"
            //services.AddDbContext<UserManagementDbContext>(options => options.UseSqlServer(connectionString));


           
        }

    }
}