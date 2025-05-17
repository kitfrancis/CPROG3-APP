using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CPROG3_APP.Data;
using CPROG3_APP.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure the main DbContext with SQL Server
var connectionString = builder.Configuration.GetConnectionString("CPROG3_APPDbContextConnection")
    ?? throw new InvalidOperationException("Connection string 'CPROG3_APPDbContextConnection' not found.");

builder.Services.AddDbContext<CPROG3_APPDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Identity services
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false; // As per your config
})
.AddEntityFrameworkStores<CPROG3_APPDbContext>();

// Add Controllers, Razor Pages, and Views
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // Important: Must come before UseAuthorization
app.UseAuthorization();

// Map routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();