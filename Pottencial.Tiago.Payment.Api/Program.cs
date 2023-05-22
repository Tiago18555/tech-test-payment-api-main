using Microsoft.EntityFrameworkCore;

using Pottencial.Tiago.Payment.Api.Data;
using Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda;
using Pottencial.Tiago.Payment.Api.Application.UseCases.BuscarVenda;
using Pottencial.Tiago.Payment.Api.Repositories.Impl;
using Pottencial.Tiago.Payment.Api.Repositories;
using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVendedor;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(o => o.UseInMemoryDatabase("Database"));
//builder.Services.AddDbContext<DataContext>(o => o.UseSqlite($"Data Source=../database.db"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Payment Api", Version = "v1" });
    
});

#region DEPENDENCY INJECTION SETUP

builder.Services.AddScoped<IFindOrderService, FindOrderService>();
builder.Services.AddScoped<ICreateOrderService, CreateOrderService>();
builder.Services.AddScoped<IUpdateOrderService, UpdateOrderService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISellRepository, SellRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<IRegisterProductService, RegisterProductService>();
builder.Services.AddScoped<IRegisterItemService, RegisterItemService>();
builder.Services.AddScoped<IRegisterSellerService, RegisterSellerService>();

//builder.Services.AddControllers().AddJsonOptions(x =>
//                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s => 
        {
            s.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Api");
            s.RoutePrefix = "api-docs";
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Console.WriteLine(@"
 _____   ____ _______ _______ ______ _   _  _____ _____          _      
|  __ \ / __ \__   __|__   __|  ____| \ | |/ ____|_   _|   /\   | |     
| |__) | |  | | | |     | |  | |__  |  \| | |      | |    /  \  | |     
|  ___/| |  | | | |     | |  |  __| | . ` | |      | |   / /\ \ | |     
| |    | |__| | | |     | |  | |____| |\  | |____ _| |_ / ____ \| |____ 
|_|     \____/  |_|     |_|  |______|_| \_|\_____|_____/_/    \_\______|
");

app.Run();