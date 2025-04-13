using FastEndpointsApi.DataAccess.Repositories;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();
builder.Services
    .AddFastEndpoints(options =>
    {
        // Auto discovery did not work here, so explicitly add the assembly that contains endpoints
        options.Assemblies = [typeof(Program).Assembly];
    })
    .SwaggerDocument(); // define a swagger document

builder.Services.AddSingleton<IWarehouseRepository, DummyWarehouseRepository>();

var app = builder.Build();
app.UseDefaultExceptionHandler()
    .UseFastEndpoints(config => 
        config.Endpoints.RoutePrefix = "api") // sets api base route for all endpoints
    .UseSwaggerGen();

app.Run();

