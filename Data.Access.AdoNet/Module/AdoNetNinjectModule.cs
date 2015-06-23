using Domain.Model.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.AdoNet
{
    public class AdoNetNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IPostRepository>().To<PostRepositorySqlImpl>();
        }

    }
}
