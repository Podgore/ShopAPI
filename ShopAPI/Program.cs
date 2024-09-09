using Microsoft.EntityFrameworkCore;
using ShopAPI.BLL.Profiles;
using ShopAPI.BLL.Services;
using ShopAPI.BLL.Services.Interfaces;
using ShopAPI.DAL.DBContext;
using ShopAPI.DAL.Repository;
using ShopAPI.DAL.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ProductProfile));

builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Service
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
