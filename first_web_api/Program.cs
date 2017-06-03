﻿using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace first_devwarsztaty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://*:5050")
                .Build();

            host.Run();
        }
    }
}
