using AiTestApp.Config;
using AiTestApp.Repositories.Config;

// Create and configure the web application builder.
var builder = WebApplication.CreateBuilder(args);

// Register application services.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationDependencies()
                .AddRepositoryDependencies();

// Build the configured application.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error")
       .UseHsts();
}

app.UseHttpsRedirection()
   .UseRouting()
   .UseAuthorization();

app.MapStaticAssets();

// Conventional routing for MVC controllers.
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Start the application.
app.Run();
