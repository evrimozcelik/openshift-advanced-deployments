using Microsoft.AspNetCore.Hosting;

namespace Ibm.Jtc.Health
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder AddHealth(this IWebHostBuilder webhost)
        {
            webhost.UseBeatPulse(options =>
            {
                options.ConfigurePath(path: "health")
                     .ConfigureTimeout(milliseconds: 2000)
                     .ConfigureDetailedOutput(detailedOutput: true, includeExceptionMessages: true);
            });

            return webhost;
        }
    }
}
