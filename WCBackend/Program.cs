using Microsoft.EntityFrameworkCore;
using WCBackend.model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<da33cbrr9f9g7gContext>(options =>
           options.UseNpgsql(@"Host=ec2-63-32-248-14.eu-west-1.compute.amazonaws.com;Database=da33cbrr9f9g7g;Username=uvrmwdzujsjqup
                                ;Password=44d80ab1b562f8b747cefb2c8b10b85a47980d68428f92e9769fe720c79874f1"));

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
