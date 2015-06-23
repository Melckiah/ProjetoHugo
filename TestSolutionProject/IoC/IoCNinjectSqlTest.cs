using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Entity;
using Domain.Model.Repository;
using Infrastructure.Services.IoC;

namespace TestSolutionProject.IoC
{
    [TestClass]
    public class IoCNinjectSqlTest
    {
        [TestMethod]
        public void Save_Post_IoC_SQL_Test()
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
