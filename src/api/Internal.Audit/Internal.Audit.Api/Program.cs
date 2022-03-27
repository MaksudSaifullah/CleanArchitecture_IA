using Internal.Audit.Api.Extensions;
using Internal.Audit.Api.Middlewares;
using Internal.Audit.Application;
using Internal.Audit.Application.Common;
using Internal.Audit.Infrastructure.Notification;
using Internal.Audit.Infrastructure.Persistent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//CORS Policy
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
     .WithHeaders(HeaderNames.ContentType));
});

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddPersistentInfrastructureServices(builder.Configuration);
builder.Services.AddInfrastructureNotificationsServices(builder.Configuration);

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(int.Parse(builder.Configuration["Api:Version:Major"]), int.Parse(builder.Configuration["Api:Version:Minor"]));
    config.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = c =>
    {
        var errors = string.Join('\n', c.ModelState.Values.Where(v => v.Errors.Count > 0)
          .SelectMany(v => v.Errors)
          .Select(v => v.ErrorMessage));

        return new BadRequestObjectResult(new BaseResponseDTO
        (
            Id:0,
            Success: false,
            Message: errors
        ));
    };
});

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

app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLogging();

app.MapControllers();

app.Run();
