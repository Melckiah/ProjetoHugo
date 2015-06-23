using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model;
using Data.Access;
using System.Data.Entity;
using Domain.Model.Entity;
using Domain.Model.Repository;
using Data.Access.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace TestSolutionProject
{
    [TestClass]
    public class PostEFDataAccesTest 
    {
        private IPostRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new BaseEFTest());
            _repository = new PostRepositoryEntityFrameworkImpl();
        }

        [TestMethod]
        public void Post_Insert_With_EF_Test()
        {
            Post post = ObjectMother.GetPost();            

            post = _repository.SaveOrUpdate(post);

            Assert.IsTrue(post.PostId > 0);
        }

        [TestMethod]
        public void Post_Get_With_EF_Test()
        {
            Post post = _repository.Get(1);

            Assert.IsNotNull(post);
        }

        [TestMethod]
        public void Post_Update_With_EF_Test()
        {
            Post post = _repository.Get(1);

            post.PostMessage = "Post de Teste da atualização";

            Post postEdited = _repository.SaveOrUpdate(post);

            Assert.AreEqual("Post de Teste da atualização", postEdited.PostMessage);
        }

        [TestMethod]
        public void Post_Delete_With_EF_Test()
        {
            Post post = _repository.Get(1);

            _repository.Delete(post);

            Post postDeleted = _repository.Get(1);

            Assert.IsNull(postDeleted);
        }

        [TestMethod]
        public void Post_GetAll_With_EF_Test()
        {
            IEnumerable<Post> posts = _repository.GetAll();

            Assert.IsTrue(posts.Count() > 0);
        }
    }


}
