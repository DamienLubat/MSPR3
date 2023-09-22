using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using TestProject1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace MSPR3_TEST
{
    [TestClass]
    public class ApiTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ApiTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task ReadItem_ReturnsCorrectItem()
        {
            var response = await _client.GetAsync("/ReadItem?id=1");
            response.EnsureSuccessStatusCode();
            var item = await response.Content.ReadFromJsonAsync<ItemEntity>(); 

            Assert.IsNotNull(item);
            Assert.AreEqual(1, item.Id);
        }
    }
}