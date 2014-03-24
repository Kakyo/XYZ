using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.Utils.DependencyInjection
{
    using XYZ.Interfaces.Dependencies;

    public static class DependencyInjectFactory
    {
        public static IDependencyContainer GetInstance()
        {
            //  When more IoC where implemented change to it;
            return new LightInjectorContainer();
        }

        public static IDependencyContainer _current;
        public static IDependencyContainer Current
        {
            get { return _current = _current ?? GetInstance(); }
        }
    }
}
