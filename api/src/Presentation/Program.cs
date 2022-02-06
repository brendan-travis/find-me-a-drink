using Core.Factories;
using Core.Repositories;
using Core.Services;
using Infrastructure.Factories;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Find me a drink API",
            Description = "Find a pub/bar/restaurant in Leeds where best to go for a drink.",
            Version = "v1"
        });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Presentation.xml"));
});
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAll", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddTransient<ILocationRepository, LocationRepository>();
builder.Services.AddSingleton<IMockLocationRepository, MockLocationRepository>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Find me a drink V1"); });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");

app.Run();