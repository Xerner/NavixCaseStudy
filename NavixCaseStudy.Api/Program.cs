using Microsoft.OpenApi.Models;
using NavixCaseStudy.Application.Repositories;
using NavixCaseStudy.CaseStudyApiWrapper.Interfaces;
using NavixCaseStudy.CaseStudyApiWrapper.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen(swaggerOptions =>
{
    swaggerOptions.SwaggerDoc("v1.0", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "Case Study",
        Description = "The Navix Case Study API"
    });
    swaggerOptions.EnableAnnotations();
});

builder.Services.AddSingleton<IManufacturerService, ManufacturerService>();
builder.Services.AddSingleton<IManufacturerRepository, ManufacturerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swaggerOptions =>
    {
        swaggerOptions.SwaggerEndpoint("/swagger/v1.0/swagger.json", "v1.0");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
