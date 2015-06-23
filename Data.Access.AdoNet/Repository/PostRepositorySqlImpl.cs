using Domain.Model.Entity;
using Domain.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Services;
using System.Data;

namespace Data.Access.AdoNet
{
    public class PostRepositorySqlImpl : IPostRepository
    {
        public Post SaveOrUpdate(Post post)
        {
            //Verifica se Insere ou Atualiza
            if (post.PostId == 0)
            {
                //Configurar o comando SQL
                string sql = "INSERT INTO Posts(PostMessage,PostDate)VALUES(@PostMessage, @PostDate)";

                post.PostId = Db.Insert(sql, Take(post));

                return post;
            }
            else
            {
                //Configurar o comando SQL
                string sql = "UPDATE Posts SET PostMessage = @PostMessage, PostDate = @PostDate WHERE PostId = @PostId";

                Db.Update(sql, Take(post));

                return post;
            }
        }

        public Post Get(long id)
        {
            //Configurar o comando SQL
            string sql = "SELECT PostId, PostMessage, PostDate FROM Posts WHERE PostId = @PostId";
            //Configurar os parametros
            object[] parms = { "@PostId", id };

            return Db.Get(sql, Make, parms);
        }

        public IEnumerable<Post> GetAll()
        {
            //Configurar o comando SQL
            string sql = "SELECT PostId, PostMessage, PostDate FROM Posts";

            return Db.GetAll(sql, Make);
        }

        public void Delete(Post post)
        {
            //Configurar o comando SQL
            string sql = "DELETE FROM Posts WHERE PostId = @PostId";
            //Configurar os parametros
            object[] parms = { "@PostId", post.PostId };

            Db.Delete(sql, parms);
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Post> Make = reader =>
           new Post
           {
               PostId = Convert.ToInt64(reader["PostId"]),
               PostMessage = reader["PostMessage"].ToString(),
               PostDate = Convert.ToDateTime(reader["PostDate"])
           };

        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Post post)
        {
            return new object[]  
            {
                "@PostId", post.PostId,
                "@PostMessage", post.PostMessage,
                "@PostDate", post.PostDate
            };
        }
    }
}
