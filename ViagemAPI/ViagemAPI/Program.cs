using Microsoft.OpenApi.Models;
using System.Reflection;
using ViagemAPI.Data;
using ViagemAPI.Data.Repository;
using ViagemAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LinhaServices, LinhaServices>();
builder.Services.AddScoped<LinhaRepository, LinhaRepository>();
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddScoped<MotoristaServices, MotoristaServices>(); 
builder.Services.AddScoped<MotoristaRepository, MotoristaRepository>();
builder.Services.AddScoped<VeiculoServices, VeiculoServices>();
builder.Services.AddScoped<VeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<ViagemServices, ViagemServices>();
builder.Services.AddScoped<ViagemRepository, ViagemRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo
    {

        Version = "1.0.0",
        Title = "ViagemApi",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
