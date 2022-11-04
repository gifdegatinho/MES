using AtomosHyla.Core.Library;
using NLog.Extensions.Logging;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
   .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowSpecificOrigins = "allowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowSpecificOrigins, policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(allowSpecificOrigins);

app.MapControllers();

string loggerConfig = "log.config";
NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(loggerConfig);

ServiceProviderFactory.ServiceCollection.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddNLog().SetMinimumLevel(LogLevel.Trace);
});

ServiceProviderFactory.ServiceCollection.AddSingleton<IConfiguration>((provider) =>
     new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build()
);
ServiceProviderFactory.BuildServiceProvider();

app.Run();
