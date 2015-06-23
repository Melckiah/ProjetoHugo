using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model.Entity;

namespace TestSolutionProject
{
    public static class ObjectMother
    {
        public static Post GetPost()
        {
            return new Post()
            {
                PostMessage = "Alô galera da 5 Fase!!! Vão passar de semestre???",
                PostDate = DateTime.Now
            };
        }


    }
}
