using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Utils.DependencyInjection
{
    using System.Linq.Expressions;
    using Interfaces.Dependencies;

    public class LightInjectorContainer : IDependencyContainer
    {
        private readonly LightInject.ServiceContainer _container;
        private static LightInject.ILifetime GetLifetime(DependencyLifetime lifetime)
        {
            switch (lifetime)
            {
                default:
                case DependencyLifetime.Request:
                    return new LightInject.PerRequestLifeTime();

                case DependencyLifetime.Container:
                    return new LightInject.PerContainerLifetime();

                case DependencyLifetime.Scope:
                    return new LightInject.PerScopeLifetime();
            }
        }

        public LightInjectorContainer()
        {
            _container = new LightInject.ServiceContainer();
        }


        #region IDependencyRegistry Members

        #region [ Whitout generic parameter ]

        public void Register(Type interfaceType)
        {
            _container.Register(interfaceType);
        }

        public void Register(Type interfaceType, DependencyLifetime lifetime)
        {
            _container.Register(interfaceType, GetLifetime(lifetime));
        }

        public void Register(Type interfaceType, Type implementingType)
        {
            _container.Register(interfaceType, implementingType);
        }

        public void Register(Type interfaceType, Type implementingType, DependencyLifetime lifetime)
        {
            _container.Register(interfaceType, implementingType, GetLifetime(lifetime));
        }

        public void Register(Type interfaceType, Type implementingType, string name)
        {
            _container.Register(interfaceType, implementingType, name);
        }

        public void Register(Type interfaceType, Type implementingType, string name, DependencyLifetime lifetime)
        {
            _container.Register(interfaceType, implementingType, name, GetLifetime(lifetime));
        }

        #endregion
        #region [ Interface gerenic parameter ]

        public void Register<TInterface>(DependencyLifetime lifetime)
        {
            _container.Register<TInterface>(GetLifetime(lifetime));
        }

        //public void Register<TInterface>(Expression<Func<IDependencyFactory, TInterface>> factory)
        //{
        //    container.Register<TInterface>(factory);
        //}
        //
        //public void Register<TInterface>(Expression<Func<IDependencyFactory, TInterface>> factory, DependencyLifetime lifetime)
        //{
        //    container.Register<TInterface>(factory, GetLifetime(lifetime));
        //}
        //
        //public void Register<TInterface>(Expression<Func<IDependencyFactory, TInterface>> factory, string name)
        //{
        //    container.Register<TInterface>(factory, name);
        //}
        //
        //public void Register<TInterface>(Expression<Func<IDependencyFactory, TInterface>> factory, string name, DependencyLifetime lifetime)
        //{
        //    container.Register<TInterface>(factory, name, GetLifetime(lifetime));
        //}

        #endregion
        #region [ Interface/Concrete generic parameter ]

        public void Register<TInterface, TConcrete>() where TConcrete : TInterface
        {
            _container.Register<TInterface, TConcrete>();
        }

        public void Register<TInterface, TConcrete>(DependencyLifetime lifetime) where TConcrete : TInterface
        {
            _container.Register<TInterface, TConcrete>(GetLifetime(lifetime));
        }

        public void Register<TInterface, TConcrete>(string name) where TConcrete : TInterface
        {
            _container.Register<TInterface, TConcrete>(name);
        }

        public void Register<TInterface, TConcrete>(string name, DependencyLifetime lifetime) where TConcrete : TInterface
        {
            _container.Register<TInterface, TConcrete>(name, GetLifetime(lifetime));
        }

        //public void Register<TInterface, TConcrete>(Expression<Func<IDependencyFactory, TConcrete, TInterface>> factory)
        //{
        //    container.Register<TInterface, TConcrete>(factory);
        //}
        //
        //public void Register<TInterface, TConcrete>(Expression<Func<IDependencyFactory, TConcrete, TInterface>> factory, string name)
        //{
        //    container.Register<TInterface, TConcrete>(factory, name);
        //}

        #endregion

        #endregion
        #region IDependencyResolver Members

        public IEnumerable<TInterface> GetAllInstances<TInterface>()
        {
            return _container.GetAllInstances<TInterface>();
        }
        public IEnumerable<object> GetAllInstances(Type interfaceType)
        {
            return _container.GetAllInstances(interfaceType);
        }

        public TInterface GetInstance<TInterface>()
        {
            return _container.GetInstance<TInterface>();
        }
        public TInterface GetInstance<TInterface>(string name)
        {
            return _container.GetInstance<TInterface>(name);
        }
        public TInterface GetInstance<TInterface, TConcrete>(TConcrete value)
        {
            return _container.GetInstance<TConcrete, TInterface>(value);
        }
        public TInterface GetInstance<TInterface, TConcrete>(TConcrete value, string name)
        {
            return _container.GetInstance<TConcrete, TInterface>(value, name);
        }

        public object GetInstance(Type interfaceType)
        {
            return _container.GetInstance(interfaceType);
        }
        public object GetInstance(Type interfaceType, object[] arguments)
        {
            return _container.GetInstance(interfaceType, arguments);
        }
        public object GetInstance(Type interfaceType, string name)
        {
            return _container.GetInstance(interfaceType, name);
        }
        public object GetInstance(Type interfaceType, string name, object[] arguments)
        {
            return _container.GetInstance(interfaceType, name, arguments);
        }

        public TInterface TryGetInstance<TInterface>()
        {
            return _container.TryGetInstance<TInterface>();
        }
        public TInterface TryGetInstance<TInterface>(string name)
        {
            return _container.TryGetInstance<TInterface>(name);
        }
        public object TryGetInstance(Type interfaceType)
        {
            return _container.TryGetInstance(interfaceType);
        }
        public object TryGetInstance(Type interfaceType, string name)
        {
            return _container.TryGetInstance(interfaceType, name);
        }

        #endregion
    }
}
