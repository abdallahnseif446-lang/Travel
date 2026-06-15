using Microsoft.EntityFrameworkCore;
using Travel.Data;
using Travel.Services;
using Travel.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CheckService>();
builder.Services.AddScoped<Ioperation, operation>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services
builder.Services.AddRazorPages();


builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();