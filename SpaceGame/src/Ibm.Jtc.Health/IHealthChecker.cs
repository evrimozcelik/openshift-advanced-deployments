using Microsoft.Extensions.DependencyInjection;

namespace Ibm.Jtc.Health
{
    public interface IHealthChecker
    {
        IHealthChecker AddRedisHealtCheck(string redisConnectionString);
        IHealthChecker AddSqlServerHealthCheck(string sqlServerConnectionString);
        IHealthChecker AddRabbitMqHealthCheck(string rabbitMqConnectionString);
        IHealthChecker AddUri(string uri, string displayname);

        IServiceCollection Build();
    }
}
