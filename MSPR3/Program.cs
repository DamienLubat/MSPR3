using MSPR3.Model;
using MSPR3.Repo;

var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ajoutez le service CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithMethods("PUT", "DELETE", "GET");
        });
});

// Ajouter les services d'autorisation
builder.Services.AddAuthorization();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();


app.MapGet("/", () =>
{
    return "Salut";
}).WithTags("Default");

// Media
app.MapPut("/CreatedMedia", (IConfiguration configuration, MediaEntity model) =>
{
    IResult res;
    try
    {
        MediaRepo repo = new MediaRepo(configuration);
        repo.Created(model);
        res = Results.Ok();
    }
    catch(Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Media");
app.MapGet("/ReadMedia", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        MediaRepo repo = new MediaRepo(configuration);
        res = Results.Ok(repo.Read(id));
    }
    catch(Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Media");
app.MapPost("/UpdateMedia", (IConfiguration configuration, MediaEntity model) =>
{
    IResult res;
    try
    {  
        MediaRepo repo = new MediaRepo(configuration);
        repo.Update(model);
        res = Results.Ok();
    }
    catch(Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Media");
app.MapDelete("/DeleteMedia", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {  
        MediaRepo repo = new MediaRepo(configuration);
        repo.Delete(id);
        res = Results.Ok();
    }
    catch(Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Media");
// Tax
app.MapPut("/CreatedTax", (IConfiguration configuration, TaxEntity model) =>
{
    IResult res;
    try
    {
        TaxRepo repo = new TaxRepo(configuration);
        repo.Created(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Taxe");
app.MapGet("/ReadTax", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        TaxRepo repo = new TaxRepo(configuration);
        res = Results.Ok(repo.Read(id));
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Taxe");
app.MapPost("/UpdateTax", (IConfiguration configuration, TaxEntity model) =>
{
    IResult res;
    try
    {
        TaxRepo repo = new TaxRepo(configuration);
        repo.Update(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Taxe");
app.MapDelete("/DeleteTax", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        TaxRepo repo = new TaxRepo(configuration);
        repo.Delete(id);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Taxe");
// Language
app.MapPut("/CreatedLanguage", (IConfiguration configuration, LanguageEntity model) =>
{
    IResult res;
    try
    {
        LanguageRepo repo = new LanguageRepo(configuration);
        repo.Created(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Language");
app.MapGet("/ReadLanguage", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        LanguageRepo repo = new LanguageRepo(configuration);
        res = Results.Ok(repo.Read(id));
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Language");
app.MapPost("/UpdateLanguage", (IConfiguration configuration, LanguageEntity model) =>
{
    IResult res;
    try
    {
        LanguageRepo repo = new LanguageRepo(configuration);
        repo.Update(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Language");
app.MapDelete("/DeleteLanguage", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        LanguageRepo repo = new LanguageRepo(configuration);
        repo.Delete(id);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Language");
// Descriptive
app.MapPut("/CreatedDescriptive", (IConfiguration configuration, DescriptiveEntity model) =>
{
    IResult res;
    try
    {
        DescriptiveRepo repo = new DescriptiveRepo(configuration);
        repo.Created(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Descriptive");
app.MapGet("/ReadDescriptive", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        DescriptiveRepo repo = new DescriptiveRepo(configuration);
        res = Results.Ok(repo.Read(id));
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Descriptive");
app.MapPost("/UpdateDescriptive", (IConfiguration configuration, DescriptiveEntity model) =>
{
    IResult res;
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
    return res;
}).WithTags("Descriptive");
app.MapDelete("/DeleteDescriptive", (IConfiguration configuration, int id) =>
{
    IResult res;
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
    return res;
}).WithTags("Descriptive");
// Volume
app.MapPut("/CreatedVolume", (IConfiguration configuration, VolumeEntity model) =>
{
    IResult res;
    try
    {
        VolumeRepo repo = new VolumeRepo(configuration);
        repo.Created(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Volume");
app.MapGet("/ReadVolume", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        VolumeRepo repo = new VolumeRepo(configuration);
        res = Results.Ok(repo.Read(id));
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Volume");
app.MapPost("/UpdateVolume", (IConfiguration configuration, VolumeEntity model) =>
{
    IResult res;
    try
    {
        VolumeRepo repo = new VolumeRepo(configuration);
        repo.Update(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Volume");
app.MapDelete("/DeleteVolume", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        VolumeRepo repo = new VolumeRepo(configuration);
        repo.Delete(id);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Volume");
// Keyword
app.MapPut("/CreatedKeyword", (IConfiguration configuration, KeywordEntity model) =>
{
    IResult res;
    try
    {
        KeywordRepo repo = new KeywordRepo(configuration);
        repo.Created(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Keyword");
app.MapGet("/ReadKeyword", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        KeywordRepo repo = new KeywordRepo(configuration);
        res = Results.Ok(repo.Read(id));
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Keyword");
app.MapPost("/UpdateKeyword", (IConfiguration configuration, KeywordEntity model) =>
{
    IResult res;
    try
    {
        KeywordRepo repo = new KeywordRepo(configuration);
        repo.Update(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Keyword");
app.MapDelete("/DeleteKeyword", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        KeywordRepo repo = new KeywordRepo(configuration);
        repo.Delete(id);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Keyword");
// Price
app.MapPut("/CreatedPrice", (IConfiguration configuration, PriceEntity model) =>
{
    IResult res;
    try
    {
        PriceRepo repo = new PriceRepo(configuration);
        repo.Created(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Price");
app.MapGet("/ReadPrice", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        PriceRepo repo = new PriceRepo(configuration);
        res = Results.Ok(repo.Read(id));
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Price");
app.MapPost("/UpdatePrice", (IConfiguration configuration, PriceEntity model) =>
{
    IResult res;
    try
    {
        PriceRepo repo = new PriceRepo(configuration);
        repo.Update(model);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Price");
app.MapDelete("/DeletePrice", (IConfiguration configuration, int id) =>
{
    IResult res;
    try
    {
        PriceRepo repo = new PriceRepo(configuration);
        repo.Delete(id);
        res = Results.Ok();
    }
    catch (Exception ex)
    {
        res = Results.BadRequest($"Une erreur s'est produite : {ex.Message}");
    }
    return res;
}).WithTags("Price");

app.Run();
