using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Framework.Models;
using WebApi;
using Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IntegrationTest
{

    public class ServerFixture : IDisposable
    {
        private const string BaseAddress = "http://localhost:13389";
        private readonly TestServer _server;

        protected const string Email = "kareem";
        protected const string Password = "MIKO900";
        protected HttpClient Client { get; }
        protected IServiceProvider ServiceProvider { get; }

        //protected IUserService UserTaxRepository { get; }

        public ServerFixture()
        {
            const string environemnt = "Development";
            var rootLocation =
                $@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.Parent?.Parent?.FullName}\WebApi";

            var builder = new WebHostBuilder()
                .UseEnvironment(environemnt)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(rootLocation)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environemnt}.json", optional: true)
                    .Build()
                )
                .UseContentRoot(rootLocation)
                .UseStartup<Startup>();

            _server = new TestServer(builder);
        
            Client = _server.CreateClient();

            Client.BaseAddress = new Uri(BaseAddress);
            // Client.DefaultRequestHeaders.Add("Authorization", "407c6567d7b4f1e766939715f6c67c18");

            ServiceProvider = _server.Host.Services;



            //UserTaxRepository = ServiceProvider.GetService(typeof(IUserService)) as IUserService;
        }

        protected async Task<HttpResponseMessage> PostAsync(string url, object formData, string email = null, string password = null)
        {
            IList<string> cookies = new List<string>();
            if (email != null && password != null)
            {
                //cookies = (await GetAuthTokenAsync(email, password)).ToList();
            }




            //var content = new FormUrlEncodedContent(formData);
            var myContent = JsonConvert.SerializeObject(formData);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            return await Client.PostAsync(url, byteContent);
        }

        private async Task<string> GetAuthTokenAsync(string email, string password, string loginProvider)
        {

            var payload = new LoginModel
            {
                UserName = email,
                Password = password,
                LoginProvider = loginProvider
            }.ToDictionary();
            var response = await PostAsync("/api/Security/Login", payload);

            return null;
        }



        public virtual void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
