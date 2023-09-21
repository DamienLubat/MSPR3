using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using TestProject1;

namespace MSPR3_TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsTrue(false);
        }
        //private readonly WebApplicationFactory<TestStartup> _factory;
        //private readonly HttpClient _client;

        //public ApiTest()
        //{
        //    _factory = new ItemEntity<TestStartup>();
        //    _client = _factory.CreateClient();
        //}

        //[TestMethod]
        //public async Task ReadItem_ReturnsCorrectItem()
        //{
        //    var response = await _client.GetAsync("/ReadItem?id=1");
        //    response.EnsureSuccessStatusCode();
        //    var item = await response.Content.ReadFromJsonAsync<ItemEntity>();

        //    Assert.IsNotNull(item);
        //    Assert.AreEqual(1, item.Id);
        //    // ... D'autres assertions basées sur vos attentes ...
        //}
    }
}
