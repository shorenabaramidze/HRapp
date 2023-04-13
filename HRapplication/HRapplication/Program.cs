using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HRapplication.Areas.Identity.Data;
using HRapplication.DAL;

var builder = WebApplication.CreateBuilder(args);
//register HRapplicationContext
var connectionString = builder.Configuration.GetConnectionString("HRapplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'HRapplicationContextConnection' not found.");

builder.Services.AddDbContext<HRapplicationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<HRapplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<HRapplicationContext>();

//register EmployeeDbContext
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeContextConnection")));



// Add services to the container.
builder.Services.AddControllersWithViews();

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


app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
