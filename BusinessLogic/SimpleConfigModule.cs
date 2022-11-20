using Ninject.Modules;
using DataAccessLayer;
using Model;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IRepository<Student>>().To<EntityRepository<Student>>()
            //    .InSingletonScope().WithConstructorArgument("context", new DBContext());
            Bind<IRepository<Student>>().To<DapperRepository>()
            .InSingletonScope();
        }
    }
}
