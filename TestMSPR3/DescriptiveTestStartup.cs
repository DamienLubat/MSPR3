using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestMSPR3
{
    public class DescriptiveTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddSingleton<DescriptiveRepo>();
        }

        private readonly string configurationString;

        public DescriptiveTestStartup(IConfiguration configuration)
            => configurationString = configuration.GetConnectionString("SQL");

        public void Configure(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPut("/CreatedDescriptive", async context =>
                {
                    IActionResult res;
                    var model = await context.Request.ReadFromJsonAsync<DescriptiveEntity>();
                    try
                    {
                        // Injection de DescriptiveRepo
                        DescriptiveRepo repo = context.RequestServices.GetRequiredService<DescriptiveRepo>();
                        repo.Created(model);
                        res = new OkResult();
                    }
                    catch (Exception ex)
                    {
                        res = new BadRequestObjectResult($"Une erreur s'est produite : {ex.Message}");
                    }
                    await res.ExecuteResultAsync(new Microsoft.AspNetCore.Mvc.ActionContext
                    {
                        HttpContext = context
                    });
                }).WithTags("Descriptive");
                endpoints.MapGet("/ReadDescriptive", async context =>
                {
                    var id = int.Parse(context.Request.Query["id"].ToString());
                    var item = GetDescriptiveById(id);
                    var json = JsonSerializer.Serialize(item);
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(json);
                });
                endpoints.MapPost("/UpdateDescriptive", async context =>
                {
                    IResult res;
                    var model = await context.Request.ReadFromJsonAsync<DescriptiveEntity>();
                    try
                    {
                        DescriptiveRepo repo = new DescriptiveRepo(configuration);
                        repo.Update(model);
                        res = Results.Ok();
                    }
                    catch (Exception ex)
                    {
                        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
                    }
                    await res.ExecuteAsync(context);
                }).WithTags("Descriptive");



                endpoints.MapDelete("/DeleteDescriptive", async context =>
                {
                    IResult res;
                    var id = int.Parse(context.Request.Query["IDDescriptive"].ToString());
                    try
                    {
                        DescriptiveRepo repo = new DescriptiveRepo(configuration);
                        repo.Delete(id);
                        res = Results.Ok();
                    }
                    catch (Exception ex)
                    {
                        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
                    }
                    await res.ExecuteAsync(context);
                }).WithTags("Descriptive");
            });
        }


        private DescriptiveEntity GetDescriptiveById(int id)
        {
            // Simule la récupération d'un élément
            return new DescriptiveEntity { IDDescriptive = 1 };
        }

    }

}
