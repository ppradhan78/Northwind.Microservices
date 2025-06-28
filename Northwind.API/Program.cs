using Microsoft.EntityFrameworkCore;
using Northwind.Data.BusinessObject;
using Northwind.Data.Data;
using Northwind.Data.Mappers;
using Northwind.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

#region Dependency Injection
// Add AutoMapper
builder.Services.AddAutoMapper(typeof(SupplierProfile));
// Dependency Injection
builder.Services.AddScoped<ISuppliersService, SuppliersService>();
builder.Services.AddScoped<ISuppliersBo, SuppliersBo>();

#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Optional: Automatically apply migrations on startup in development
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate(); // Applies any pending migrations
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
