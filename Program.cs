using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Claudiu_Cojocaru_Lab2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Am schimbat serverul de la  SQL Server la SQLite
// Folosesc macOS si rulez Visual Studio 2022 in VM Ware Fusion
// Cu Windows 11 ARM si sunt probleme de compatibilitate
builder.Services.AddDbContext<Claudiu_Cojocaru_Lab2Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Claudiu_Cojocaru_Lab2Context")
                      ?? throw new InvalidOperationException("Connection string 'Claudiu_Cojocaru_Lab2Context' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
