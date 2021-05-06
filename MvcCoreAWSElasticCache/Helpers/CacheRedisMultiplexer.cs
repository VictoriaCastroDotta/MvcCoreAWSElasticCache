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
            return ConnectionMultiplexer.Connect("");
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
