using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    internal class TestStartup
    {
        [TestMethod]
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/ReadItem", async context =>
                {
                    var id = context.Request.Query["id"];
                    // ... Votre logique pour obtenir l'élément ...
                    await context.Response.WriteAsJsonAsync(item);
                });
            });
        }
    }
}
