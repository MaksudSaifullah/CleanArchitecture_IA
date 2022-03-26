using Internal.Audit.Api.Extensions;
using Internal.Audit.Api.Middlewares;
using Internal.Audit.Application;
using Internal.Audit.Infrastructure.Notification;
using Internal.Audit.Infrastructure.Persistent;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddPersistentInfrastructureServices(builder.Configuration);
builder.Services.AddInfrastructureNotificationsServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Database migration and seeding operations
app.MigrateDatabase<InternalAuditContext>((context, services) =>
{
    InternalAuditContextSeed.SeedAsync(context).Wait();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRequestLogging();

app.MapControllers();

app.Run();
