using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Entity;
using Infrastructure.Services.Validation;
using Domain.Model.Exceptions;

namespace TestSolutionProject
{
    [TestClass]    
    public class PostDomainTest
    {        
        [TestMethod]
        public void Create_Post_Instance_Test()
        {
            Post post = new Post();
            post.PostId = 0;
            post.PostMessage = "Post de Teste";
            post.PostDate = DateTime.Now.AddHours(-1);           

            Assert.AreEqual(0, post.PostId);
            Assert.AreEqual("Post de Teste", post.PostMessage);
            Assert.AreEqual("1 hora atrás", post.DisplayPostDate);            
        }

        [TestMethod]
        public void Valid_Post_Test()
        {
            Post post = new Post();
            post.PostId = 0;
            post.PostMessage = "Post de Teste";
            post.PostDate = DateTime.Now.AddHours(-1);

            Validator.Validate(post);
        }

        [TestMethod]
        [ExpectedException(typeof(PostMessageException))]
        public void InValid_Post_Exceed_Characters_Test()
        {
            Post post = new Post();
            post.PostId = 0;
            post.PostMessage = "RT @lerolero: A prática cotidiana prova que o desafiador cenário globalizado estimula a padronização da gestão inovadora da qual fazemos parte.";
            post.PostDate = DateTime.Now.AddHours(-1);

            Validator.Validate(post);
        }

        [TestMethod]
        [ExpectedException(typeof(PostMessageException))]
        public void InValid_Post_Exceed_DateTime_Test()
        {
            Post post = new Post();
            post.PostId = 0;
            post.PostMessage = "RT @lerolero: A prática cotidiana prova que o desafiador cenário globalizado estimula a padronização da gestão inovadora.";
            post.PostDate = DateTime.Now.AddHours(+1);

            Validator.Validate(post);
        }
    }
}
