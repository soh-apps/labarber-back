using System.Reflection;
using LaBarber.Domain.Configuration;
using LaBarber.Infra.Configuration;
using LaBarber.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});
var logger = loggerFactory.CreateLogger<Program>();


builder.Services.AddControllers();
string connectionString = string.Empty;
string secret = string.Empty;

if (builder.Environment.IsProduction())
{
logger.LogInformation("Ambiente de produção detectado.");
}
else
{
    logger.LogInformation("Ambiente de Desenvolvimento/Local detectado.");
    builder.Services.Configure<Secrets>(builder.Configuration);
    connectionString = builder.Configuration.GetSection("ConnectionString").Value ?? string.Empty;
}

var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

builder.Services.AddDbContext<ContextBase>(
    options => options.UseNpgsql(connectionString));

builder.Services.AddAuthenticationJwt(builder.Configuration.GetSection("ClientSecret").Value!);
builder.Services.AddServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenConfig(xmlFile);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    logger.LogInformation("Swagger configurado");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<ContextBase>();
await db!.Database.MigrateAsync();

app.Run();
