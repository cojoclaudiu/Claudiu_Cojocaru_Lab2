using Microsoft.EntityFrameworkCore;
using Claudiu_Cojocaru_Lab2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Claudiu_Cojocaru_Lab2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Am schimbat serverul de la SQL Server la SQLite
// Folosesc macOS si rulez Visual Studio 2022 in VM Ware Fusion
// Cu Windows 11 ARM si sunt probleme de compatibilitate
builder.Services.AddDbContext<Claudiu_Cojocaru_Lab2Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Claudiu_Cojocaru_Lab2Context")
                      ?? throw new InvalidOperationException("Connection string 'Claudiu_Cojocaru_Lab2Context' not found.")));

// SQLite database pentru Identity (folosim aceeasi baza)
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Claudiu_Cojocaru_Lab2Context")));

// Identity registration
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddSingleton<IEmailSender, FakeEmailSender>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
