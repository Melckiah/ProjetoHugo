using Domain.Model.Entity;
using Domain.Model.Repository;
using Infrastructure.Services.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TestSolutionProject
{
    [TestClass]
    public class IoCNinjectEntityFrameworkTest
    {
        [TestInitialize]
        public void Initialize()
        {
            ConfigurationManager.AppSettings["Data.Access"] = "Data.Access.EntityFramework.dll";
        }

        [TestMethod]
        public void Save_Post_IoC_EF_Test()
        {
            //Instancia da classe Post para ser salva
            Post p = ObjectMother.GetPost();
            
            //Através do IoC Ninject busca um implementação do Repositório
            IPostRepository repository
                = Container.Get<IPostRepository>();

            Post posted = repository.SaveOrUpdate(p);

            Assert.IsTrue(posted.PostId > 0);
        }

        
    }
}
