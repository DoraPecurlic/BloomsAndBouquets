using FlowerShop.Repository.Common;
using FlowerShop.Repository;
using FlowerShop.Service.Common;
using FlowerShop.Service;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});



string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddScoped<IOrderRepository>(provider => new OrderRepository(connectionString));
builder.Services.AddScoped<IUserRepository>(provider => new UserRepository(connectionString));


builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("corsapp");


app.UseAuthorization();

app.MapControllers();

app.Run();
