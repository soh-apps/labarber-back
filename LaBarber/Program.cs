using LaBarber.Domain.Configuration;
using LaBarber.Infra.Configuration;
using LaBarber.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionString = string.Empty;
string secret = string.Empty;

if (builder.Environment.IsProduction())
{

}
else
{
    builder.Services.Configure<Secrets>(builder.Configuration);
    connectionString = builder.Configuration.GetSection("ConnectionString").Value ?? string.Empty;
}

builder.Services.AddDbContext<ContextBase>(
    options => options.UseNpgsql(connectionString));

builder.Services.AddAuthenticationJwt(builder.Configuration.GetSection("ClientSecret").Value!);
builder.Services.AddServices();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<ContextBase>();
await db!.Database.MigrateAsync();

app.Run();
