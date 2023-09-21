using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSPR3_TEST
{
    [TestClass]
    public class UnitTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        [TestInitialize]
        public ApiTest()
        {
            _server = new TestServer( new WebHostBuilder().UseStartup<TestStartup>() );
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async void ReadItem_ReturnsCorrectItem()
        {
            var response = await _client.GetAsync("/ReadItem?id=1");
            response.EnsureSuccessStatusCode();
            var item = await response.Content.ReadFromJsonAsync<Item>();

            Assert.IsNotNull(item);
            Assert.AreEqual(1, item.Id);
            // ... D'autres assertions bas�es sur vos attentes ...
        }
    }
}
