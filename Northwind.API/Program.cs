using Microsoft.EntityFrameworkCore;
using Northwind.Data.BusinessObject;
using Northwind.Data.Data;
using Northwind.Data.Mappers;
using Northwind.Data.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Suppliers API",
        Version = "v1"
    });
    c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Suppliers API",
        Version = "v2"
    });

    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        //if (!apiDesc.TryGetMethodInfo(out var methodInfo)) return false;

        //var controllerNamespace = methodInfo.DeclaringType?.Namespace;
        //if (controllerNamespace == null) return false;

        //// Use namespace to associate controllers with versions
        //return controllerNamespace.EndsWith($".V{docName}");

        var groupName = apiDesc.GroupName;
        return groupName == docName;
    });
});
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Suppliers API v1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Suppliers API v2");
    // c.RoutePrefix = string.Empty; // Swagger at root (localhost:5000)
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
  
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
