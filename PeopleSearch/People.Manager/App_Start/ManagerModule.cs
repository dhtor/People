using Autofac;
using People.DataLayer;

namespace People.Manager
{
    public class ManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Autowire the classes with interfaces
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
            builder.RegisterModule(new DataLayerModule());
        }
    }
}
