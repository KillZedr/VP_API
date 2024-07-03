using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using ILogger = Serilog.ILogger;
using System.Data.Common;
using VapeShop.Application.VapeShop_DAL.Interfaces;
using VapeShop.Application.VapeShop_DAL.RealisationInterfaces;
using Microsoft.Extensions.Options;
using VapeShop.Application;


namespace VapeShop_API
{
    public static class TestWebApiModule
    {
 
        internal static void AddServices(WebApplicationBuilder builder)
        {
            AddSerilog(builder);
            RegisterDal(builder);
            
        }
        public static void RegisterDal(WebApplicationBuilder builder)
        {

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


            builder.Services.AddTransient(provider =>
            {
                var builder = new DbContextOptionsBuilder<VapeShop_DbContext>();
                builder.UseSqlServer(connectionString);
                return builder.Options;
            });
            builder.Services.AddScoped<DbContext, VapeShop_DbContext>();
            builder.Services.AddScoped<IUnitOfWork>(provider =>
            {
                var context = provider.GetRequiredService<DbContext>();
                return new UnitOfWork(context);
            });
        }



        internal static void AddSerilog(WebApplicationBuilder builder)
        {
            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Month,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
            if (builder.Environment.IsDevelopment())
            {
                loggerConfig = loggerConfig.MinimumLevel.Debug();
            }
            else
            {
                loggerConfig = loggerConfig.MinimumLevel.Warning();
            }
            var logger = loggerConfig.CreateLogger();
            builder.Services.AddSingleton<ILogger>(logger);
        }


        /* private static void MigrateDb();*/

       /* private static bool TestConnection(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var logger = provider.GetRequiredService<ILogger>();
            logger.Information("Test the DB connection... ");

            var context = provider.GetRequiredService<DbContext>();
            try
            {
                var createdAnew = context.Database.EnsureCreated();
                if (createdAnew)
                {
                    logger.Information("Successfully created the Db");
                }
                else
                {
                    logger.Information("The Db is already there");
                }
            }
            catch (Exception ex)
            {
                logger.Information("EnsureCreated failed");
                logger.Information(ex.ToString());
                return false;
            }
 *//*           return true;*//*
        }
*/

    }
}
