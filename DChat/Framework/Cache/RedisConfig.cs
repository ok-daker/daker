using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Cache
{
    public class RedisConfig : ConfigurationSection
    {
        [ConfigurationProperty("Host")]
        public string Host
        {
            get
            {
                return this["Host"].ToString();
            }
            set
            {
                this["Host"] = value;
            }
        }
        [ConfigurationProperty("InitialDB")]
        public long InitialDB
        {
            get
            {
                return (long)this["InitialDB"];
            }
            set
            {
                this["InitialDB"] = value;
            }
        }
        public int ConnectTimeout
        {
            get
            {
                return (int)this["ConnectTimeout"];
            }
            set
            {
                this["ConnectTimeout"] = value;
            }

        }
        public string Port
        {
            get
            {
                return this["Port"].ToString();
            }
            set
            {
                this["Port"] = value;
            }


        }

    }
}
