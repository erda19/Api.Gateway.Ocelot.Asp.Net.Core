using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ocelot.Api.Gateway.Asp.Net.Core
{
    public class Program
    {
        private static string _environmentName;

        public static void Main(string[] args)
        {
            // Set up configuration sources.
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", optional: true, reloadOnChange: true).Build();

            CreateWebHostBuilder(args, config).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, IConfiguration config) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((builderContext, configs) =>
            {
                IHostingEnvironment env = builderContext.HostingEnvironment;

                configs.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("ocelot.json").AddEnvironmentVariables();//.AddJsonFile("hosting.json", optional: true);
            })
            .UseConfiguration(config)
            //.UseUrls(config.GetSection("urls").Value)
            .UseStartup<Startup>();

    }
}
