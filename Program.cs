var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<InventoryContext>(opt => opt.UseInMemoryDatabase("InventoryHubDB"));
builder.Services.AddScoped<InventoryService>();
builder.Services.AddHttpClient<InventoryService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AppBaseUrl"] ?? "https://localhost:5001/");
});
builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();