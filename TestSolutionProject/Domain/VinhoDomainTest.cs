using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Entity;

namespace TestSolutionProject.Domain
{
    [TestClass]
    public class VinhoDomainTest
    {
        [TestMethod]
        public void CriarVinhoTeste()
        {
            Vinho vinho = new Vinho();

            vinho.Coloracao = "Roxo";
            vinho.Descricao = "Bom";
            vinho.Graduacao = "14.0";
            vinho.Nome = "Vinhoja";
            vinho.Familia = VinhoFamilia.Cabernet;

            Assert.AreEqual("Vinhoja - Bom - Roxo - 14", vinho.ToString());
        }

    }
}
