using Microsoft.Extensions.DependencyInjection;

namespace Ibm.Jtc.Health
{
    public static class HealthCheckBuilder
    {
        public static IHealthChecker Create(IServiceCollection services)
        {
            return new HealthChecker().Begin(services);
        }
    }
}
