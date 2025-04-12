using FastEndpointsApi.DataAccess.Repositories;
using FastEndpoints;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints(options =>
{
    // Explicitly add the assembly that contains your endpoints
    options.Assemblies = [typeof(Program).Assembly];
});

builder.Services.AddSingleton<IWarehouseRepository, DummyWarehouseRepository>();

var app = builder.Build();
app.UseFastEndpoints();
app.Run();

// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// builder.Services.AddSingleton<IWarehouseRepository, DummyWarehouseRepository>();
//
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseHttpsRedirection();
