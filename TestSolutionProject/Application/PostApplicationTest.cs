using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model;
using Data.Access;
using System.Data.Entity;
using Moq;
using Domain.Model.Repository;
using Domain.Model.Entity;
using Applications.Services;
using Domain.Model.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace TestSolutionProject
{
    [TestClass]
    public class PostApplicationTest
    {
        private Mock<IPostRepository> _mockRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostRepository>();
        }

        [TestMethod]
        public void Create_Post_Service_Test()
        {
            Post post = ObjectMother.GetPost();

            _mockRepository
                .Setup(x => x.SaveOrUpdate(post))
                .Returns(new Post { PostId = 1 });

            //TODO: Aplicar o conceito de Mock Objects para isolar o teste da camada de aplicação
            IPostService _service =
                new PostService(_mockRepository.Object);

            Post posted = _service.SaveOrUpdate(post);

            _mockRepository
                .Verify(x => x.SaveOrUpdate(post));

            Assert.IsTrue(posted.PostId > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(PostMessageException))]
        public void Create_Post_With_Validation_ServiceTest()
        {
            Post post = new Post();

            _mockRepository
                .Setup(x => x.SaveOrUpdate(post))
                .Returns(new Post { PostId = 1 });

            //TODO: Aplicar o conceito de Mock Objects para isolar o teste da camada de aplicação
            IPostService _service =
                new PostService(_mockRepository.Object);

            Post posted = _service.SaveOrUpdate(post);
        }

        [TestMethod]
        public void Get_All_Posts_Service_Test()
        {            
            _mockRepository
                .Setup(x => x.GetAll())
                .Returns(
                    new List<Post>()
                        {
                            new Post { PostId = 1 },
                            new Post { PostId = 2 },
                            new Post { PostId = 3 }
                        });
            
            IPostService _service =
                new PostService(_mockRepository.Object);

            IEnumerable<Post> posts = _service.GetAll();

            _mockRepository
                .Verify(x => x.GetAll());

            Assert.IsTrue(posts.Count() == 3);
        }
    }
}
