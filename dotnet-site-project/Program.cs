using dotnet_site_project.Middlewares;
using InvertedSoftware.PLogger.Core;
using dotnet_site_project.services;

var builder = WebApplication.CreateBuilder(args);

var settings = new PLoggerSettings(builder.Configuration);
builder.Logging.ClearProviders();
builder.Logging.AddPLogger(settings);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmailService,EmailService>();
builder.Services.AddScoped<IFileService, FileService>();


var app = builder.Build();

app.UseMiddleware<LogsMiddleware>();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "email",
    pattern: "{controller=Mail}/{action=Index}");

app.Run();