using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Framework.Cache
{
    public class RedisCache : IRedisCache
    {
        private readonly PooledRedisClientManager clientManager;
        private readonly string host;
        public RedisCache()
        {
            ConfigurationFileMap filemap = new ConfigurationFileMap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "/config/redis.config"));
            RedisConfig config = ConfigurationManager.OpenMappedMachineConfiguration(filemap).GetSection("redis") as RedisConfig;
            host = config.Host;
            if (!string.IsNullOrEmpty(host))
            {
                clientManager = new PooledRedisClientManager(host.Split(';'));
            }
        }
        public void Add<T>(string key, T value)
        {
            using (var client = clientManager.GetClient())
            {
                if (!client.ContainsKey(key))
                {
                    client.Add<T>(key, value);
                    client.Save();
                }
                else
                {
                    client.Set<T>(key, value);
                    client.Save();

                }
            }
        }

        public void Add<T>(string key, T value, TimeSpan span)
        {
            using (var client = clientManager.GetClient())
            {
                if (!client.ContainsKey(key))
                {
                    client.Add<T>(key, value, span);
                    client.Save();
                }
                else
                {
                    client.Set<T>(key, value, span);
                    client.Save();
                }

            }
        }

        public void AddToList(string key, string value)
        {
            using (var client = clientManager.GetClient())
            {
                if (client.ContainsKey(key))
                {
                    client.AddItemToList(key, value);
                    client.Save();
                }

            }
        }

        public T Get<T>(string key)
        {
            using (var client = clientManager.GetClient())
            {
                if (client.ContainsKey(key))
                {
                    return client.Get<T>(key);
                }
                else
                {
                    return default(T);
                }

            }
        }

        public void Remove(string key)
        {
            using (var client = clientManager.GetClient())
            {
                if (client.ContainsKey(key))
                {
                    client.Remove(key);
                    client.Save();
                }


            }
        }

        public void RemoveByRegex(string key)
        {
            using (var client = clientManager.GetClient())
            {
                var keys = client.SearchKeys(key);
                if (keys!=null&&keys.Count>0)
                {
                    client.RemoveAll(keys);
                    client.Save();
                }
            
            
            }
        }
    }
}
