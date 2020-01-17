using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using sample_dotnetcore_console_ef_bulk.Services;
using System;

namespace sample_dotnetcore_console_ef_bulk
{
    class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            
            serviceProvider
                .GetService<ILoggerFactory>();            

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();            

            logger.LogDebug("Logger is working!");

            var service = serviceProvider.GetService<IBulk>();
            //service.InsertBulkData(50000);
            service.UpdateBulkData();
        }       
    }
}
