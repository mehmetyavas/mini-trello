using System.Globalization;
using System.Reflection;
using AspNetCoreRateLimit;
using Core.Attributes;
using Core.Configuration;
using Core.Data;
using Core.Data.Enum;
using Core.Utilities.Helpers;
using Core.Utilities.Middleware;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebAPI.Configuration;
using WebAPI.Services.OpenAI;

var builder = WebApplication.CreateBuilder(args);


AppConfig.Build(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.ConfigureFilters();



builder.Services.ConfigureCors();

builder.Services.ConfigureAuthentication();

builder.Services.ConfigureSwagger();



builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("Application"));

 builder.ConfigureRateLimiter();    




builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<UnitOfWork>();

builder.Services.ConfigureServices();

builder.Services.AddScoped<OpenAiService>();
var app = builder.Build();


var supportedCultures = new List<CultureInfo>
{
    new("tr-TR"),
    new("en-US"),
};
app.UseRequestLocalization(new RequestLocalizationOptions
{
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    DefaultRequestCulture = new RequestCulture(new CultureInfo("tr-TR")),
});


ServiceTool.ServiceProvider = app.Services;

//permissions 
_ = app.ActionData();

app.CreateFiles();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // DefaultArea Swagger belgesi
        typeof(ApiGroupNames).GetFields()
            .Skip(1)
            .ToList()
            .ForEach(f =>
            {
                //Gets the attribute on the enumeration value
                var info = f.GetCustomAttributes(typeof(GroupInfoAttribute), false)
                    .OfType<GroupInfoAttribute>()
                    .FirstOrDefault();
                c.SwaggerEndpoint($"/swagger/{f.Name}/swagger.json", info != null ? info.Title : f.Name);
            });
        c.DocExpansion(DocExpansion.None);
    });
}

app.UseIpRateLimiting();

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();


app.UseAuthorization();


app.MapControllers();

app.UseStaticFiles();

app.Run();