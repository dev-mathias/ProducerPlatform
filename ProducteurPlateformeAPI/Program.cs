using Common.Repositories;
using D = DAL_Producteur;
using B = BLL_Producteur;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string allowOrigins = "allowOrigins";
builder.Services.AddControllers();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: allowOrigins, policy =>
//    {
//        policy.WithOrigins("*");
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowOrigins,
                      builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAdressRepository<D.Entities.Address>, D.Services.AddressService>();
builder.Services.AddScoped<IAdressRepository<B.Entities.Address>, B.Service.AdressService>();

builder.Services.AddScoped<ICustomerRepository<D.Entities.Customer>, D.Services.CustomerService>();
builder.Services.AddScoped<ICustomerRepository<B.Entities.Customer>, B.Service.CustomerService>();

builder.Services.AddScoped<IProducerRepository<D.Entities.Producer>, D.Services.ProducerService>();
builder.Services.AddScoped<IProducerRepository<B.Entities.Producer>, B.Service.ProducerService>();

builder.Services.AddScoped<IProductRepository<D.Entities.Product>, D.Services.ProductService>();
builder.Services.AddScoped<IProductRepository<B.Entities.Product>, B.Service.ProductService>();

builder.Services.AddScoped<IPurchaseRepository<D.Entities.Purchase>, D.Services.PurchaseService>();
builder.Services.AddScoped<IPurchaseRepository<B.Entities.Purchase>, B.Service.PurchaseService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
