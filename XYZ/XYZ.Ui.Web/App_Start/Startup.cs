namespace XYZ.Ui.Web
{
    using Microsoft.AspNet.SignalR;
    using Owin;
    using XYZ.Utils.DependencyInjection;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = DependencyInjectFactory.Current;

            GlobalHost.DependencyResolver.Register(typeof(Hub.ContatoHub)
                , () =>
                {
                    var service = container.GetInstance<Interfaces.Services.IContatoService>();
                    return new Hub.ContatoHub(service);
                });

            app.MapSignalR();
        }
    }
}