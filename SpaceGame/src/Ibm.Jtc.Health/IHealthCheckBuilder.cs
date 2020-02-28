using Microsoft.Extensions.DependencyInjection;

namespace Ibm.Jtc.Health
{
    public interface IHealthCheckBuilder
    {
        IHealthChecker Begin(IServiceCollection services);
    }
}
