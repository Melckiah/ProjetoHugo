using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Repository;
using Data.Access.Twitter;
using Domain.Model.Entity;
using System.Collections.Generic;
using System.Linq;

namespace TestSolutionProject.Data
{
    [TestClass]
    public class PostTwitterDataAccessTest
    {
        private IPostRepository _repository;

        [TestInitialize]
        public void Initialize()
        {            
            _repository = new PostRepositoryTwitterImpl();
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
            Post post = _repository.Get(350468179560120320);

            Assert.IsNotNull(post);
        }

        [TestMethod]
        public void Post_GetAll_With_ADO_Test()
        {
            IEnumerable<Post> posts = _repository.GetAll();

            Assert.IsTrue(posts.Count() > 0);
        }
    }
}
