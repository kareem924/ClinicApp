
using Abstract.Entities;
using Abstract.Infrastructure;
using Abstract.Repositry;
using Data.Connection;
using Data.Repositry;
using Framework.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
namespace Data
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            //Context lifetime defaults to "scoped"
            //services.AddDbContext<UserManagementDbContext>(options => options.UseSqlServer(connectionString));
             services.AddScoped<IConnectionFactory>(sp=>
             {return new SqlConnectionFactory(connectionString); });
             

           
        }

    }
}