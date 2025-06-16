using Application.Factory;
using Application.Factory.Interfaces;
using Application.Parser;
using Application.Services;
using Application.Services.Interfaces;
using Application.Transformer;
using Application.Transformer.Interface;
using Infrastructure.Facade;
using Infrastructure.Facade.Interface;
using Infrastructure.Handlers;
using Infrastructure.Handlers.Interface;
using Infrastructure.Provider;
using Infrastructure.Provider.Interface;
using ScannerService.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Setup Logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .MinimumLevel.Debug()
    .CreateLogger();

builder.Host.UseSerilog(); // Replace default .NET logger

// Add services to the container.
builder.Services.AddSingleton<IVulnerabilityScannerTransformer, VulnerabilityScannerTransformer>();
builder.Services.AddSingleton<IPackageFileParserFactory, PackageFileParserFactory>();
builder.Services.AddSingleton<IVulnerabilityScannerService, VulnerabilityScannerService>();
builder.Services.AddSingleton<IVulnerabilityProvider, GitHubVulnerabilityProvider>();
builder.Services.AddSingleton<IProcessVulnerabilityHandler, ProcessVulnerabilityHandler>();
builder.Services.AddSingleton<IPackageVersionComparator, PackageVersionComparator>();
builder.Services.AddSingleton<NpmPackageParser>();

builder.Services.AddControllers();

//Register HttpCliet
builder.Services.AddHttpGithubGraphQLClient(builder.Configuration);

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