var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name:"Default",
    pattern:"{controller=Auth}/{action=Login}/{id?}"
    );

app.Run();
