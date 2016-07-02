using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Entity;
using System.Collections.Generic;
using TestSolutionProject.Base;
using System.Data.Entity;
using Domain.Model.Contrato;
using VinhoDados.Contexto;
using VinhoDados.Repositorio;

namespace TestSolutionProject.Dados
{
    [TestClass]
    public class VinhosDadosTest
    {
        private VinhoContexto _contextoTeste;
        private IVinhoRepositorio _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoVinho<VinhoContexto>());

            _contextoTeste = new VinhoContexto();
            _repositorio = new VinhoRepositorio();

            _contextoTeste.Database.Initialize(true);

            _contextoTeste.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        [TestCleanup]
        public void Clear()
        {

        }

        [TestMethod]
        public void CriarVinhoNoBancoTeste()
        {
            IVinhoRepositorio repositorio = new VinhoRepositorio();
            Vinho vinho = new Vinho();

            vinho.Coloracao = "Roxo";
            vinho.Descricao = "Bom";
            vinho.Graduacao = "14.0";
            vinho.Nome = "Vinhoja";
            vinho.Familia = VinhoFamilia.Cabernet;

            Vinho novaVinho = repositorio.Salvar(vinho);

            Assert.IsTrue(novaVinho.Id > 0);
        }

        [TestMethod]
        public void RetornarVinhoRepositorioTest()
        {
            // Action - Busca no Banco
            Vinho vinho = _repositorio.Buscar(1);

            // Assert 
            Assert.IsNotNull(vinho);
        }

        [TestMethod]
        public void RetornaTodosOsVinhosRepositorioTeste()
        {
            // Action - Busca no banco
            List<Vinho> vinhos = _repositorio.BuscarTodos();

            Assert.AreEqual(10, vinhos.Count);
        }

        [TestMethod]
        public void AtualizaVinhoRepositorioTeste()
        {
            // Arrange - Busca no Banco
            Vinho vinho = _contextoTeste.Vinhos.Find(1);

            vinho.Nome = "Vinhoba";
            vinho.Descricao = "Ruim";

            //Action
            _repositorio.Atualizar(vinho);

            //Assert 
            Vinho vinhoAtualizada = _contextoTeste.Vinhos.Find(1);
            Assert.AreEqual("Vinhoba", vinhoAtualizada.Nome);
            Assert.AreEqual("Ruim", vinhoAtualizada.Descricao);
        }

        [TestMethod]
        public void DeletarVinhoRepositorioTeste()
        {
            //Arrange
            Vinho vinho = _repositorio.Buscar(1);

            //Action
            _repositorio.Deletar(vinho);

            //Assert
            Vinho vinhoDeletada = _contextoTeste.Vinhos.Find(1);
            Assert.IsNull(vinhoDeletada);
        }

    }

}

