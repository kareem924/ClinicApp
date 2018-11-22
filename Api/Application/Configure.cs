using Abstract.Service;
using Application.SecurityService;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
     public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //Context lifetime defaults to "scoped"
            //services.AddDbContext<UserManagementDbContext>(options => options.UseSqlServer(connectionString));
             
             services.AddTransient<IAuthenticationService,AuthenticationService>();

           
        }

    }
}