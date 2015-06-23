using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model;
using Data.Access;
using Domain.Model.Repository;
using TestSolutionProject.Base;
using Data.Access.AdoNet;
using Domain.Model.Entity;
using System.Collections.Generic;
using System.Linq;

namespace TestSolutionProject
{
    [TestClass]
    public class PostSqlDataAccessTest
    {
        private IPostRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new PostRepositorySqlImpl();
        }

        [TestMethod]
        public void Post_Insert_With_ADO_Test()
        {
            Post post = ObjectMother.GetPost();

            post = _repository.SaveOrUpdate(post);

            Assert.IsTrue(post.PostId > 0);
        }

        [TestMethod]
        public void Post_Get_With_ADO_Test()
        {
            Post post = _repository.Get(1);

            Assert.IsNotNull(post);
        }

        [TestMethod]
        public void Post_Update_With_ADO_Test()
        {
            Post post = _repository.Get(1);

            post.PostMessage = "Post de Teste da atualização";

            Post postEdited = _repository.SaveOrUpdate(post);

            Assert.AreEqual("Post de Teste da atualização", postEdited.PostMessage);
        }

        [TestMethod]
        public void Post_Delete_With_ADO_Test()
        {
            Post post = _repository.Get(1);

            _repository.Delete(post);

            Post postDeleted = _repository.Get(1);

            Assert.IsNull(postDeleted);
        }

        [TestMethod]
        public void Post_GetAll_With_ADO_Test()
        {
            IEnumerable<Post> posts = _repository.GetAll();

            Assert.IsTrue(posts.Count() > 0);
        }
    }
}
