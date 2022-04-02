using Microsoft.EntityFrameworkCore;

namespace Internal.Audit.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MigrateDatabase<TContext>(this WebApplication app,
        Action<TContext, IServiceProvider> seeder, int retry = 0) where TContext : DbContext
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<TContext>();

            try
            {
                InvokeSeeder(seeder, context, services);
            }
            catch (Exception ex)
            {
                if (retry <= 10) //TODO: will integrate Polly for circuit breaker pattern
                {
                    retry++;
                    System.Threading.Thread.Sleep(2000);
                    MigrateDatabase<TContext>(app, seeder, retry);
                }
            }
        }
        return app;
    }

    private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder,
                                               TContext context, IServiceProvider services) where TContext : DbContext
    {
        context.Database.Migrate();
        seeder(context, services);
    }
}
