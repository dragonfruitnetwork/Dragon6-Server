// Dragon6 Server Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under a modified BSD-3 Clause License. Please refer to the licence file in the root of this repo for more details

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DragonFruit.Six.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}
