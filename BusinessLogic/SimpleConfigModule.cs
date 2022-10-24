using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DataAccessLayer;
using Model;
using Ninject;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Student>>().To<EntityRepository<Student>>().InSingletonScope().WithConstructorArgument("context", new DBContext());
            //Bind<IRepository<Student>>().To<DapperRepository>().InSingletonScope();
        }
    }
}
