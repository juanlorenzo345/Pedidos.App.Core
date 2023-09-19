var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("ApiPedidos", client =>
{
    var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
    client.BaseAddress = new Uri(appSettings.ApiPedidos);
});

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
    pattern: "{controller=Ventas}/{action=Index}/{id?}");

app.Run();

public class AppSettings
{
    public string? ApiPedidos { get; set; }
}