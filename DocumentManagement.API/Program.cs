using DocumentManagement.Application.Interfaces.Application;
using DocumentManagement.Application.Interfaces.Infrastructure;
using DocumentManagement.Application.Interfaces.Validators;
using DocumentManagement.Application.Services;
using DocumentManagement.Application.Validators;
using DocumentManagement.Infrastructure.Services.CRM;
using DocumentManagement.Infrastructure.Services.Sharepoint;
using DocumentManagement.Infrastructure.Services.Sharepoint.Configuration;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("appsettings.Development.json", false, true);

    // Add services to the container.
    builder.Services.AddScoped<IDocumentService, SharepointIntegrationService>();
    builder.Services.AddScoped<IDocumentHandler, DocumentHandler>();
    builder.Services.AddScoped<ISharePointConfiguration, SharePointConfiguration>();
    builder.Services.AddScoped<IDocumentValidator, DocumentValidator>();
    builder.Services.AddScoped<ICRMService, CRMService>();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    builder.Services.AddAutoMapper(typeof(Program).Assembly);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}
