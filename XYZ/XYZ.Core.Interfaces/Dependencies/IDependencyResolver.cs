using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Interfaces.Dependencies
{
    public interface IDependencyResolver
    {
        IEnumerable<TInterface> GetAllInstances<TInterface>();
        IEnumerable<object> GetAllInstances(Type serviceType);

        TInterface GetInstance<TInterface>();
        TInterface GetInstance<TInterface>(string name);
        TInterface GetInstance<TInterface, TConcrete>(TConcrete value);
        TInterface GetInstance<TInterface, TConcrete>(TConcrete value, string name);

        object GetInstance(Type serviceType);
        object GetInstance(Type serviceType, object[] arguments);
        object GetInstance(Type serviceType, string name);
        object GetInstance(Type serviceType, string name, object[] arguments);
        
        TInterface TryGetInstance<TInterface>();
        TInterface TryGetInstance<TInterface>(string name);
        object TryGetInstance(Type serviceType);
        object TryGetInstance(Type serviceType, string name);
    }
}
