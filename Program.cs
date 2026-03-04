using EzovionAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
    throw new Exception("DefaultConnection is not set! Make sure environment variable is configured.");

builder.Services.AddDbContext<AppDBcontext>(options =>
    options.UseNpgsql(
        "Host=dpg-d6k3lc15pdvs73dr1nt0-a;Port=5432;Database=crud_db_72sm;Username=crud_db_72sm_user;Password=uitORmgfgLhTD629wrWsJN6MpPhKmo35;SSL Mode=Require;Trust Server Certificate=true"
    )
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDBcontext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();