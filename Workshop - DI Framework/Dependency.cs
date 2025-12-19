using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Workshop___DI_Framework
{
    public class Dependency
    {
        public Dependency(Type type)
        {
            if (type == null)
            {
                throw new ArgumentException($"Type cannot be null.");
            }

            this.Type = type;
        }
        public Type Type { get; set; }

        public Dependency(object instance)
        {
            if (instance == null)
            {
                throw new ArgumentException($"Instance cannot be null.");
            }

            this.Instance = instance;
        }

        public Dependency(Func<DependencyProvider, object> factoryFunc)
        {
            if (factoryFunc == null)
            {
                throw new ArgumentException($"Factory function cannot be null.");
            }

            this.FactoryFunc = factoryFunc;
        }

        public object Instance { get; private set; }

        public Func<DependencyProvider, object> FactoryFunc { get; private set; }
    }
}
