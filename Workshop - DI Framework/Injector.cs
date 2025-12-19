using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop___DI_Framework
{
    public static class Injector
    {
        public static DependencyProvider Register<TAbstracType, TImplementationType>()
            where TImplementationType : class, TAbstracType
        {
            var dependencyProvider = new DependencyProvider();

            dependencyProvider.Register<TAbstracType, TImplementationType>();

            return dependencyProvider;
        }

        public static DependencyProvider Register<TAbstracType>(object implementationInstance)
            where TAbstracType : class
        {
            var dependencyProvider = new DependencyProvider();

            dependencyProvider.Register<TAbstracType>(implementationInstance);

            return dependencyProvider;
        }

        public static DependencyProvider Register<TAbstracType, TImplementationType>(Func<DependencyProvider, TImplementationType> factoryFunc)
            where TImplementationType : class, TAbstracType
        {
            var dependencyProvider = new DependencyProvider();

            dependencyProvider.Register<TAbstracType, TImplementationType>(factoryFunc);

            return dependencyProvider;
        }
    }
}
