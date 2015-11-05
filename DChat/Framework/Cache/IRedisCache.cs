using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Framework.Cache
{
    public interface IRedisCache
    {
        void Add<T>(string key, T value);
        void Add<T>(string key, T value, TimeSpan span);
        void AddToList(string key, string value);
        T Get<T>(string key);
        void Remove(string key);
        void RemoveByRegex(string key);
    }
}
