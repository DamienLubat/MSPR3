using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestProject1;
using Microsoft.Extensions.DependencyInjection;

namespace TestMSPR3
{
    [TestClass]
    public class DescriptiveApiTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public DescriptiveApiTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<DescriptiveTestStartup>());
            _client = _server.CreateClient();
        }

        [TestInitialize]
        public void Setup()
        {
            // Réinitialisez la "base de données" avant chaque test
            _server.Host.Services.GetRequiredService<DescriptiveRepo>().InitializeTestData();
        }

        [TestMethod]
        public async Task CreateDescriptive_ReturnsOk()
        {
            var model = new DescriptiveEntity { IDDescriptive = 123, IDLanguage = 1, descriptionShort = "Test short description", descriptionLong = "Test long description" };
            var response = await _client.PutAsJsonAsync("/CreatedDescriptive", model);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task ReadDescriptive_ReturnsOk()
        {
            var response = await _client.GetAsync("/ReadDescriptive?id=1");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<DescriptiveEntity>();
            Assert.IsNotNull(result);
            // Vous pouvez ajouter d'autres assertions basées sur vos attentes
        }

        [TestMethod]
        public async Task UpdateDescriptive_ReturnsOk()
        {
            var model = new DescriptiveEntity { IDDescriptive = 123, IDLanguage = 1, descriptionShort = "Test short", descriptionLong = "Test long description" };
            var response = await _client.PostAsJsonAsync("/UpdateDescriptive", model);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteDescriptive_ReturnsOk()
        {
            var response = await _client.DeleteAsync("/DeleteDescriptive?IDDescriptive=1");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
