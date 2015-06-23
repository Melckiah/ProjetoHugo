using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entity;

namespace Data.Access.EntityFramework.Context
{
    public class PostContext : DbContext
    {
        //public PostContext():base("PostDataBase") { }

        public DbSet<Post> Posts { get; set; }
    }
}
