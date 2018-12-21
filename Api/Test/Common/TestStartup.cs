using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApi;

namespace Common
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }
        public override void SetupDatabase(IServiceCollection services)
        {
            Data.Configure.ConfigureServices(services, @"Server=localhost;Database=ClinicApp;Trusted_Connection=True;MultipleActiveResultSets=true");
           

        }
    }
}
