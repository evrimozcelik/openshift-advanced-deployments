using Microsoft.Extensions.DependencyInjection;
using BeatPulse;
using System;
using BeatPulse.Core;
using System.Collections.Generic;

namespace Ibm.Jtc.Health
{
    public class HealthChecker : IHealthChecker, IHealthCheckBuilder
    {
        private IServiceCollection _services;
         
        private IList<Action<BeatPulseContext>> _setups;

        internal HealthChecker()
        {
        }

        /// <summary>
        /// Initializes healthcheck services.
        /// Needs to be called first.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IHealthChecker Begin(IServiceCollection services)
        {
            _services = services;
            _setups = new List<Action<BeatPulseContext>>();

            return this;
        }

        /// <summary>
        /// Registers rabbit mq with connection string
        /// </summary>
        /// <param name="rabbitMqConnectionString"></param>
        /// <returns></returns>
        public IHealthChecker AddRabbitMqHealthCheck(string rabbitMqConnectionString)
        {
            Action<BeatPulseContext> setup = options => options.AddRabbitMQ(rabbitMqConnectionString);

            _setups.Add(setup);

            return this;
        }

        /// <summary>
        /// registers redis health check via connections tring
        /// </summary>
        /// <param name="redisConnectionString"></param>
        /// <returns></returns>
        public IHealthChecker AddRedisHealtCheck(string redisConnectionString)
        {
            Action<BeatPulseContext> setup = options => options.AddRedis(redisConnectionString);

            _setups.Add(setup);

            return this;
        }

        /// <summary>
        /// Registers sqlserver health check via connections string
        /// </summary>
        /// <param name="sqlServerConnectionString"></param>
        /// <returns></returns>
        public IHealthChecker AddSqlServerHealthCheck(string sqlServerConnectionString)
        {
            Action<BeatPulseContext> setup = options => options.AddSqlServer(sqlServerConnectionString);

            _setups.Add(setup);

            return this;
        }

        /// <summary>
        /// Register a URI for health checking
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public IHealthChecker AddUri(string uri, string displayname)
        {
            Action<BeatPulseContext> setup = options => options.AddUrlGroup(new Uri(uri),name: displayname);

            _setups.Add(setup);

            return this;
        }

        public IServiceCollection Build()
        {
            Action<BeatPulseContext> combinedSetup = null;

            foreach (var setup in _setups)
            {
                combinedSetup += setup;
            } 

            _services.AddBeatPulse(combinedSetup);
            return _services;
        }

    }
}
