using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using MathPreparationApp.Data;
using MathPreparationApp.Data.Models;
using MathPreparationApp.Web.Infrastructure.Extensions;
using static MathPreparationApp.Common.EntityValidationConstants.User;
using static MathPreparationApp.Common.GeneralApplicationConstants;
using MathPreparationApp.Services.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MathPreparationAppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{   
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = PasswordMinLength;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<MathPreparationAppDbContext>();

builder.Services.AddApplicationServices(typeof(IQuestionService));

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/User/Login";
});

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjust the timeout as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.SeedAdministrator(AdminEmail);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
