using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Ibm.Jtc.Health;

namespace TailSpin.SpaceGame.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .AddHealth()
                .UseStartup<Startup>();
    }
}
