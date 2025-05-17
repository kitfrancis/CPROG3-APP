using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CPROG3_APP.Data;
using CPROG3_APP.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CPROG3_APPDbContextConnection") ?? throw new InvalidOperationException("Connection string 'CPROG3_APPDbContextConnection' not found.");

builder.Services.AddDbContext<CPROG3_APPDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CPROG3_APPDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<CPROG3_APPDbContext>(options =>
//    options.UseInMemoryDatabase("DineroDb"));

builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.....
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
