using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DChat.Framework.IOC
{
    public class Resolver
    {
        private static string _configpath;
        private IUnityContainer _container;
        private static Resolver _instance;
        public Resolver()
        {
            ConfigurationFileMap filemap = new ConfigurationFileMap(_configpath);
            UnityConfigurationSection config = ConfigurationManager.OpenMappedMachineConfiguration(filemap).GetSection("unity") as UnityConfigurationSection;
            if (config != null)
            {
                config.Configure(Container);

            }

        }
        public static void configure(string path)
        {
            _configpath = path;
        }
        public IUnityContainer Container
        {
            get
            {

                _container = new UnityContainer();
                // IUnityContainer unityContainer = HttpContext.Current.Items[(object)"perRequestContainer"] as IUnityContainer;
                return _container;

            }
        }
        public void Register<T>()
        {
            _container.RegisterType(typeof(T));
        }
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
        public static Resolver Current
        {
            get
            {

                if (_instance == null)
                {
                    _instance = new Resolver();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
    }
}
