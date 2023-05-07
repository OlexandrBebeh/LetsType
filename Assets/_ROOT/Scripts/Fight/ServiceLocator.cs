namespace _ROOT.Scripts.Fight
{
    using System.Collections.Generic;
    using System.Linq;
    public class ServiceLocator
    {
        private static List<object> services = new ();

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