using Marketplace.main.Infrastructure;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = Environment.GetEnvironmentVariable("CatalogusDb")
                       ?? "Host=localhost; Database=marketplace_db; Port=15432; Username=admin; Password=test123";

builder.Services.AddControllers();
// builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
// {
//     optionsBuilder.UseMySql(connectionString,
//         ServerVersion.AutoDetect(connectionString));
// });
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)
);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();