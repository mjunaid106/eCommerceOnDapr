using Microsoft.AspNetCore.Builder;
using Product.API.Services;
using Dapr;
using Order.API.Actors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddDapr();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSubscribeHandler();

app.UseCloudEvents();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
