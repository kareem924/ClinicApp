using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace IntegrationTest
{
    public class ServerFixture : IDisposable
    {
        private const string BaseAddress = "http://localhost:500";
        private const string RequestVerificationToken = "__RequestVerificationToken";
        private readonly TestServer _server;

        protected const string Email = "yusuf";
        protected const string Password = "kareem924";
        protected HttpClient Client { get; }
        protected IServiceProvider ServiceProvider { get; }

        //protected IUserService UserTaxRepository { get; }

        public ServerFixture()
        {
            const string environemnt = "Development";
            var rootLocation =
                $@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.Parent?.FullName}\UserManagement.WebUi";

            var builder = new WebHostBuilder()
                .UseEnvironment(environemnt)
                .UseContentRoot(rootLocation)
                .UseStartup<Startup>();

            _server = new TestServer(builder);
            Client = _server.CreateClient();

            //Client.BaseAddress = new Uri(BaseAddress);
            // Client.DefaultRequestHeaders.Add("Authorization", "407c6567d7b4f1e766939715f6c67c18");

            ServiceProvider = _server.Host.Services;



            //UserTaxRepository = ServiceProvider.GetService(typeof(IUserService)) as IUserService;
        }

        protected async Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> formData, string email = null, string password = null)
        {
            IList<string> cookies = new List<string>();
            if (email != null && password != null)
            {
                //cookies = (await GetAuthTokenAsync(email, password)).ToList();
            }




            var content = new FormUrlEncodedContent(formData);

            //content.Headers.ContentType = new MediaTypeHeaderValue("form-data");
            var x = await Client.GetAsync("http://localhost:54508/api/User/AllUser");
            return await Client.PostAsync(url, content);
        }

        private async Task<IEnumerable<string>> GetAuthTokenAsync(string email, string password)
        {
            const string authTokenCookieName = ".AspNetCore.Identity.Application";
            //var payload = new LoginModel
            //{
            //    UserName = email,
            //    Password = password
            //}.ToDictionary();
            //var response = await PostAsync("/api/Auth/Login", payload);

            //var setCookies = response
            //    .Headers
            //    .GetValues("Set-Cookie");
            //return setCookies.Where(x => x.Contains(authTokenCookieName));
            return null;
        }



        public virtual void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
