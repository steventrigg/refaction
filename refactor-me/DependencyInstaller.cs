using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using refactor_me.DataModel;
using refactor_me.ViewModel;

namespace refactor_me
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ProductsViewModel>()
                .LifestylePerWebRequest());
            container.Register(Component.For<ProductRepository>()
                .LifestylePerWebRequest());
            container.Register(Component.For<ProductOptionRepository>()
                .LifestylePerWebRequest());
            container.Register(Component.For<RefactorMeContext>()
                .LifestylePerWebRequest());
        }
    }
}