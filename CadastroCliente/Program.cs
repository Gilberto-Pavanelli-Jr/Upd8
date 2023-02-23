using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Domain.Entities;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(
          options =>
          {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          }
    );
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Upd8DbContext>(options =>
options.UseSqlServer(
   builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("Data")));
builder.Services.AddScoped<DbContext, Upd8DbContext>();
builder.Services.AddRepositories<Upd8DbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddTransient<IRepository, Repository>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    using var context = scope.ServiceProvider.GetRequiredService<Upd8DbContext>();
    context.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
