using Data.Access;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data.Access.EntityFramework.Context;
using Domain.Model.Entity;


namespace TestSolutionProject
{
    public class BaseEFTest : DropCreateDatabaseAlways<PostContext>
    {
        protected override void Seed(PostContext context)
        {
            base.Seed(context);

            Post post = ObjectMother.GetPost();

            context.Set<Post>().Add(post);                        

            context.SaveChanges();
        }
    }
}
