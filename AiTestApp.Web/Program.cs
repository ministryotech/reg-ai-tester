using AiTestApp.Config;
using AiTestApp.Repositories.Config;

// Create and configure the web application builder.
var builder = WebApplication.CreateBuilder(args);

// Register application services.
// - MVC controllers with views
builder.Services.AddControllersWithViews();

// Register project-specific dependencies.
builder.Services.AddApplicationDependencies();
builder.Services.AddRepositoryDependencies();

// Build the configured application.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // In production, use the error handler and enable HSTS for security.
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirect HTTP to HTTPS and enable routing.
app.UseHttpsRedirection();
app.UseRouting();

// Authorization middleware (no authentication configured for this sample).
app.UseAuthorization();

// Serve static files mapped via the new static assets pipeline.
app.MapStaticAssets();

// Conventional routing for MVC controllers.
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Start the application.
app.Run();