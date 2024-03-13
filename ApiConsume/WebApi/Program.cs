using Microsoft.AspNetCore.OData;
using System.Text.Json.Serialization;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(i => i.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
    .AddOData(conf =>
    {
        conf.EnableQueryFeatures();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterSqlContext(builder.Configuration);
builder.Services.AddScopedEfDals();
builder.Services.RegisterManagers();
builder.Services.ConfigureServiceManager();
builder.Services.AddApiCors();
//builder.Services.AddAutoMapper();
builder.Services.ConfigureMapping();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PharmacyApiCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
