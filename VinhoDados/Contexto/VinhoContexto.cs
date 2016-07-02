using Domain.Model.Entity;
using System.Data.Entity;

namespace VinhoDados.Contexto
{
    public class VinhoContexto : DbContext
    {

        public VinhoContexto() : base("VinhoBanco")
        {
        }

        public DbSet<Vinho> Vinhos { get; set; }
    }
}