using System;
using Komis.Infrastructure.EF;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Komis
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DBContext>();
                    //context.Database.Migrate();
                    DBInitializer.Seed(context);

                }
                catch (Exception ex)
                {
                    
                }

                host.Run();
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
                

    }
}
