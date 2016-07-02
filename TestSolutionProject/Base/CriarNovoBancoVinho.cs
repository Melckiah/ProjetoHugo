using Domain.Model.Entity;
using System.Data.Entity;
using VinhoDados.Contexto;

namespace TestSolutionProject.Base
{
    public class CriarNovoBancoVinho<T> : DropCreateDatabaseAlways<VinhoContexto>
    {
        protected override void Seed(VinhoContexto context)
        {
            for (int i = 0; i < 10; i++)
            {
                //Criar Vinho
                Vinho vinho = new Vinho();
                vinho.Coloracao = "Roxo";
                vinho.Descricao = "Bom";
                vinho.Graduacao = "14.0";
                vinho.Nome = "Vinhoja";
                vinho.Familia = VinhoFamilia.Cabernet;

                //Adicionar no contexto
                context.Vinhos.Add(vinho);
            }

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }
    }

}