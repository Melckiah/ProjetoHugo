using Domain.Model.Entity;
using Domain.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Access.EntityFramework.Context;

namespace Data.Access.EntityFramework
{
    public class PostRepositoryEntityFrameworkImpl : IPostRepository
    {
        private PostContext _context = new PostContext();

        public Post SaveOrUpdate(Post post)
        {
            Post p = _context.Posts.Add(post);
            _context.SaveChanges();
            return p;
        }

        public Post Get(long id)
        {
            return _context.Posts.Find(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
