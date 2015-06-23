using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSolutionProject.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_POST_TABLE = "TRUNCATE TABLE [dbo].[Posts] ";
        private const string INSERT_POST = "INSERT INTO Posts(PostMessage,PostDate)VALUES('Post de Teste', GETDATE())";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_POST_TABLE);
            Db.Update(INSERT_POST);
        }
    }
}
