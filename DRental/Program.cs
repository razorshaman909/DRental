using System.Data;
using DRental.Data;
using DRental.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*var connectionString2 = builder.Configuration.GetConnectionString("DVDRentalContext") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString2));*/

/*builder.Services.AddDbContext<DVDRentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DVDRentalContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));*/

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var connectionString = builder.Configuration.GetConnectionString("IdentityContext") ?? throw new InvalidOperationException("Connection string 'IdentityContext' not found.");
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
/*builder.Services.AddMvc();*/


//add db connections for services to access db directly
builder.Services.AddTransient<IDbConnection>(c => new SqlConnection(builder.Configuration.GetConnectionString("DVDRentalContext")));

//add custom services
builder.Services.AddScoped<MovieService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    //SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
