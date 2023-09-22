using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject1
{
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/ReadItem", async context =>
                {
                    var id = int.Parse(context.Request.Query["id"].ToString());
                    var item = GetItemById(id);
                    var json = JsonSerializer.Serialize(item);
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(json);
                });
            });
        }

        private ItemEntity GetItemById(int id)
        {
            // Simule la récupération d'un élément
            return new ItemEntity { Id = 1 };
        }
    }

    public class ItemEntity
    {
        public int Id { get; set; }
    }
}

   

