using Microsoft.EntityFrameworkCore;
using Web_Report.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddControllersWithViews();
var connectString = builder.Configuration.GetConnectionString("local");
builder.Services.AddDbContext<UseDbcontext>(option => option.UseMySql(connectString, ServerVersion.AutoDetect(connectString)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
