using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Workshop___DI_Framework
{
    internal class DependencyProvider
    {
        private readonly Dictionary<Type, Dependency> mappedDepedencies;

        public DependencyProvider()
        {
            this.mappedDepedencies = new Dictionary<Type, Dependency>();
        }

        public DependencyProvider Register<TAbstracType, TImplementationType>()
            where TImplementationType : class, TAbstracType
        {

            var abstractType = typeof(TAbstracType);
            var implementationType = typeof(TImplementationType);

            this.ValidateTypeDoesNotHaveMapping(abstractType);

            this.mappedDepedencies[abstractType] = new Dependency(implementationType);

            return this;
        }

        public DependencyProvider Register<TAbstracType, TImplementationType>(Func<DependencyProvider, TImplementationType> factoryFunc)
            where TImplementationType : class, TAbstracType
        {

            var abstractType = typeof(TAbstracType);

            this.ValidateTypeDoesNotHaveMapping(abstractType);

            this.mappedDepedencies[abstractType] = new Dependency(factoryFunc);

            return this;
        }

        public DependencyProvider Register<TAbstracType>(object implementationInstance)
            where TAbstracType : class
        {
            var abstractType = typeof(TAbstracType);

            this.ValidateTypeDoesNotHaveMapping(abstractType);

            this.mappedDepedencies[abstractType] = new Dependency(implementationInstance);

            return this;

        }

        public TType Create<TType>()
            where TType : class
        {
            var type = typeof(TType);


            return (TType)this.Create(type);
        }

        public object Create(Type type)
        {
            if (type.IsInterface)
            {

                if (!this.mappedDepedencies.ContainsKey(type))
                {
                    throw new InvalidOperationException($"'{type.FullName}' type is not registered.");
                }

                    return this.ResolveDpependency(type);
            }

            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            if (constructors.Length == 0)
            {
                throw new InvalidOperationException($"{type.FullName} does not have public instance constructors.");
            }


            if (constructors.Length > 1)
            {
                throw new InvalidOperationException($"{type.FullName} has more than 1 public instance constructor.");
            }

            var construtcor = constructors.First();
            var parameters = construtcor.GetParameters();

            var parameterInstances = new List<Object>();

            foreach (var paramter in parameters)
            {
                var parameterType = paramter.ParameterType;

                if (this.mappedDepedencies.ContainsKey(parameterType))
                {
                    throw new InvalidOperationException($"'{type.FullName}' depends on '{parameterType}', which is not registered");
                }

                var parameterInsttance = this.ResolveDpependency(parameterType);

                parameterInstances.Add(parameterInsttance);

            }

            var result = construtcor.Invoke(parameterInstances.ToArray());

            this.PopulateInjectableFields(type, result);

            return result;
        }

        private object ResolveDpependency(Type type)
        {
            var dependency = this.mappedDepedencies[type];

            if (dependency.Instance != null)
            {
                return dependency.Instance;

            }
            else if (dependency.Type != null)
            {
                var parameterInstance = this.Create(dependency.Type);
                return parameterInstance;
            }
            else if (dependency.FactoryFunc != null)
            {
                var parameterInstance = dependency.FactoryFunc(this);

                return parameterInstance;
            }
            else
            {
                throw new InvalidOperationException($"Dependency is not in a valid state.");
            }
        }

        private void ValidateTypeDoesNotHaveMapping(Type abstractType)
        {
            if (this.mappedDepedencies.ContainsKey(abstractType))
            {
                throw new InvalidOperationException($"{abstractType.FullName} is already registered.");
            }
        }

        private void PopulateInjectableFields(Type type, object instance)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            if (!fields.Any())
            {
                return;
            }

            var injectableFields = fields.Where(f => f.GetCustomAttribute<InjectAttribute>() != null).ToList();

            foreach (var field in injectableFields)
            {
                var fieldType = field.FieldType;

                var fieldValue = this.Create(fieldType);

                field.SetValue(instance, fieldValue);
            }

        }
    }
}
