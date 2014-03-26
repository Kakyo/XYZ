
namespace XYZ.Ui.Web
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using XYZ.Interfaces.Dependencies;
    using XYZ.Interfaces.Services;
    using XYZ.Services.Clients;

    public class DependencyConfig
    {
        internal static void RegisterDependencies(IDependencyContainer container)
        {
            ControllerBuilder.Current.SetControllerFactory(new InjectorControllerFactory(container));
        }
    }

    public class InjectorControllerFactory : DefaultControllerFactory
    {
        private readonly IDependencyContainer _container;
        public InjectorControllerFactory(IDependencyContainer container)
        {
            this._container = container;
            AddBindings();
        }

        private void AddBindings()
        {
            this._container.Register<IContatoService, ContatoClient>();

            this._container.Register<IController, Controllers.ParceirosController>
                (typeof(Controllers.ParceirosController).Name);
        }

        protected override IController GetControllerInstance
            (RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : this._container.GetInstance<IController>(controllerType.Name);
        }
    }
}