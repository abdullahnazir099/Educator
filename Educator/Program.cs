using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Educator.Data;
using Educator.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EducatordbContextConnection") ?? throw new InvalidOperationException("Connection string 'EducatordbContextConnection' not found.");

builder.Services.AddDbContext<EducatordbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<EducatorUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<EducatordbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
