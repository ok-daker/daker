using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DChat.Framework.Cache
{
    public class RedisCache : IRedisCache
    {
        private readonly PooledRedisClientManager clientManager;
        private object root = new object();
        private readonly string host;
        private SemaphoreSlim _slim = new SemaphoreSlim(10);
        public RedisCache()
        {
            ConfigurationFileMap filemap = new ConfigurationFileMap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/redis.config"));
            RedisConfig config = ConfigurationManager.OpenMappedMachineConfiguration(filemap).GetSection("redis") as RedisConfig;
            host = config.Host;
            if (!string.IsNullOrEmpty(host))
            {
                clientManager = new PooledRedisClientManager(host.Split(';'));
            }
        }
        public void Add<T>(string key, T value)
        {
            _slim.Wait(TimeSpan.FromTicks(1000));
            using (var client = clientManager.GetClient())
            {
                if (!client.ContainsKey(key))
                {
                    client.Add<T>(key, value);
                    lock (root)
                    {
                        client.Save();
                        
                    }
               
                }
                else
                {
                    client.Set<T>(key, value);
                    lock (root)
                    {
                        client.Save();

                    }

                }
            }
            _slim.Release();
        }

        public void Add<T>(string key, T value, TimeSpan span)
        {
            _slim.Wait(TimeSpan.FromTicks(1000));
            using (var client = clientManager.GetClient())
            {
                if (!client.ContainsKey(key))
                {
                    client.Add<T>(key, value, span);
                    lock (root)
                    {
                        client.Save();

                    }
                }
                else
                {
                    client.Set<T>(key, value, span);
                    lock (root)
                    {
                        client.Save();

                    }
                }

            }
            _slim.Release();
        }

        public void AddToList(string key, string value)
        {
            _slim.Wait(TimeSpan.FromTicks(1000));
            using (var client = clientManager.GetClient())
            {
                if (client.ContainsKey(key))
                {
                    client.AddItemToList(key, value);
                    client.Save();
                }

            }
            _slim.Release();
        }

        public T Get<T>(string key)
        {
            _slim.Wait(TimeSpan.FromTicks(1000));
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
            _slim.Release();
        }

        public void Remove(string key)
        {
            _slim.Wait(TimeSpan.FromTicks(1000));
            using (var client = clientManager.GetClient())
            {
                if (client.ContainsKey(key))
                {
                    client.Remove(key);
                    client.Save();
                }


            }
            _slim.Release();
        }

        public void RemoveByRegex(string key)
        {
            _slim.Wait(TimeSpan.FromTicks(1000));
            using (var client = clientManager.GetClient())
            {
                var keys = client.SearchKeys(key);
                if (keys!=null&&keys.Count>0)
                {
                    client.RemoveAll(keys);
                    client.Save();
                }
            
            
            }
            _slim.Release();
        }
    }
}
