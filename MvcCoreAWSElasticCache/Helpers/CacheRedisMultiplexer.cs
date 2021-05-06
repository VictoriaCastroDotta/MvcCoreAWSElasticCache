using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSElasticCache.Helpers
{
    public class CacheRedisMultiplexer
    {
        private static Lazy<ConnectionMultiplexer> CrearConexion = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("cache-personajes-vc-0001-001.ol7hbo.0001.use1.cache.amazonaws.com:6379");
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return CrearConexion.Value;
            }
        }
    }
}
