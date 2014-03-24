using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Interfaces.Dependencies
{
    public interface IDependencyRegistry
    {
        #region [ Whitout generic parameter ]

        void Register(Type interfaceType);

        void Register(Type interfaceType
           , DependencyLifetime lifetime);

        void Register(Type interfaceType
           , Type implementingType);

        void Register(Type interfaceType
            , Type implementingType, DependencyLifetime lifetime);

        void Register(Type interfaceType
            , Type implementingType, string name);

        void Register(Type interfaceType
            , Type implementingType, string name, DependencyLifetime lifetime);

        #endregion
        #region [ Interface gerenic parameter ]

        void Register<TInterface>(DependencyLifetime lifetime);

        //void Register<TInterface>(Expression<Func<IDependencyResolver, TInterface>> factory);
        //
        //void Register<TInterface>(Expression<Func<IDependencyResolver, TInterface>> factory
        //    , DependencyLifetime lifetime);
        //
        //void Register<TInterface>(Expression<Func<IDependencyResolver, TInterface>> factory
        //    , string name);
        //
        //void Register<TInterface>(Expression<Func<IDependencyResolver, TInterface>> factory
        //    , string name, DependencyLifetime lifetime);

        #endregion
        #region [ Interface/Concrete generic parameter ]

        void Register<TInterface, TConcrete>()
            where TConcrete : TInterface;

        void Register<TInterface, TConcrete>(DependencyLifetime lifetime)
            where TConcrete : TInterface;

        void Register<TInterface, TConcrete>(string name)
            where TConcrete : TInterface;

        void Register<TInterface, TConcrete>(string name, DependencyLifetime lifetime)
            where TConcrete : TInterface;

        //void Register<TInterface, TConcrete>
        //    (Expression<Func<IDependencyResolver, TConcrete, TInterface>> factory);
        //
        //void Register<TInterface, TConcrete>
        //    (Expression<Func<IDependencyResolver, TConcrete, TInterface>> factory, string name);

        #endregion
    }
}
