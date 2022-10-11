using Microsoft.EntityFrameworkCore;
using WCBackend.model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<d88ppm3o06b3t8Context>(options =>
           options.UseNpgsql(@"Host=ec2-34-249-161-200.eu-west-1.compute.amazonaws.com;Database=d88ppm3o06b3t8;Username=kempbthugvslhv
                                ;Password=96f643d9f55c1740541991d49fe88548581a62749a397b08c52f02a98051bb4a"));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
