using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake.Repositories;
using DAL.Repositories;
using DAL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            //kernel.Bind<IRepository<Account>>().To<FakeRepository>();
            kernel.Bind<IRepository<Account>>().To<BaseRepository>();
            //kernel.Bind<IRepository>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountService>().To<AccountService>().WithConstructorArgument(kernel.Get<IRepository<Account>>());
            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
