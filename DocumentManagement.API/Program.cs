using DocumentManagement.Application.Interfaces.Application;
using DocumentManagement.Application.Interfaces.Infrastructure;
using DocumentManagement.Application.Interfaces.Validators;
using DocumentManagement.Application.Services;
using DocumentManagement.Application.Validators;
using DocumentManagement.Infrastructure.Services.CRM;
using DocumentManagement.Infrastructure.Services.Sharepoint;
using DocumentManagement.Infrastructure.Services.Sharepoint.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDocumentService, SharepointIntegrationService>();
builder.Services.AddScoped<IDocumentHandler, DocumentHandler>();
builder.Services.AddScoped<ISharePointConfiguration, SharePointConfiguration>();
builder.Services.AddScoped<IDocumentValidator, DocumentValidator>();
builder.Services.AddScoped<ICRMService, CRMService>();

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
