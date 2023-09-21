using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace TestProject1
{
    //[TestClass]
    //internal class TestStartup
    //{
    //    [TestMethod]
    //    public void Configure(IApplicationBuilder app)
    //    {
    //        app.UseRouting();

    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapGet("/ReadItem", async context =>
    //            {
    //                var id = context.Request.Query["id"];
    //                // ... Votre logique pour obtenir l'élément ...
    //                await context.Response.WriteAsJsonAsync(item);
    //            });
    //        });
    //    }
    //    public class ApiTest
    //    {
    //        private readonly TestServer _server;
    //        private readonly HttpClient _client;

    //        public ApiTest()
    //        {
    //            _server = new TestServer(new WebHostBuilder()
    //                .UseStartup<TestStartup>());
    //            _client = _server.CreateClient();
    //        }
    //        // ... Méthodes de test à suivre ...
    //    }

    //    [TestMethod]
    //    public async Task ReadItem_ReturnsCorrectItem()
    //    {
    //        var response = await _client.GetAsync("/ReadItem?id=1");
    //        response.EnsureSuccessStatusCode();
    //        var item = await response.Content.ReadFromJsonAsync<Item>();

    //        Assert.IsNotNull(item);
    //        Assert.AreEqual(1, item.Id);
    //        // ... D'autres assertions basées sur vos attentes ...
    //    }
    //}
}
