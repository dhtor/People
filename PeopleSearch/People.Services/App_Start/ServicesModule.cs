using Autofac;
using People.Manager;

namespace People.Services
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Autowire the classes with interfaces
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();

            builder.RegisterModule(new ManagerModule());
        }
    }
}
