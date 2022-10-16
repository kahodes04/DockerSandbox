using Microsoft.EntityFrameworkCore;
using WCBackend.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<wcContext>(options =>
           options.UseNpgsql(@"Host=dpg-cd4t4o1gp3jqpbpgfad0-a.frankfurt-postgres.render.com;Database=wc;Username=wc_user;Password=OuefQHd7QLpYk19A0bPuY9FfiD9v14fu"));

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
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
