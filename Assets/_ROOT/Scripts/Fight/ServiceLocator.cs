using System.Collections.Generic;
using System.Linq;

namespace _ROOT.Scripts
{
    public class ServiceLocator
    {
        private static List<object> services = new List<object>();

        public static void Register<T>(T service)
        {
            services.Add(service);
        }

        public static T Get<T>()
        {
            return (T) services.First(s => s is T);
        }
    }
}