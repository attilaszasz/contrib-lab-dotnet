using System.Globalization;
using ContribLab.Web.Services;

var builder = WebApplication.CreateBuilder(args);

var storeCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = storeCulture;
CultureInfo.DefaultThreadCurrentUICulture = storeCulture;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<NotificationService>();
builder.Services.AddHttpClient<CatalogApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.MapControllers();

app.Run();
