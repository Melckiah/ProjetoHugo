using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Entity;
using Moq;
using Domain.Model.Contrato;
using Applications.Services.Contrato;
using Applications.Services.Servico;
using System.Collections.Generic;

namespace TestSolutionProject.Application
{
    [TestClass]
    public class VinhoAplicationTest
    {
        [TestMethod]
        public void CriarVinhoNaAplicacaoTeste()
        {
            Vinho vinho = new Vinho();

            vinho.Coloracao = "Roxo";
            vinho.Descricao = "Bom";
            vinho.Graduacao = "14.0";
            vinho.Nome = "Vinhoja";
            vinho.Familia = VinhoFamilia.Cabernet;

            var repositorioFake = new Mock<IVinhoRepositorio>();
            repositorioFake.Setup(x => x.Salvar(vinho)).Returns(new Vinho());

            IVinhoAplicacao servico = new VinhoAplicacao(repositorioFake.Object);


            Vinho novaVinho = servico.Criar(vinho);


            repositorioFake.Verify(x => x.Salvar(vinho));
        }

            [TestMethod]
        public void RetornarVinhoAplicacaoTeste()
        {
            var repositorioVinhoFake = new Mock<IVinhoRepositorio>();
            repositorioVinhoFake.Setup(x => x.Buscar(1)).Returns(new Vinho());

            IVinhoAplicacao servico = new VinhoAplicacao(repositorioVinhoFake.Object);

            Vinho vinho = servico.Retornar(1);

            repositorioVinhoFake.Verify(x => x.Buscar(1));
        }

        [TestMethod]
        public void RetornarTodosOsVinhosAplicacaoTeste()
        {
            var repositorioVinhoFake = new Mock<IVinhoRepositorio>();
            repositorioVinhoFake.Setup(x => x.BuscarTodos()).Returns(new List<Vinho>());

            IVinhoAplicacao servico = new VinhoAplicacao(repositorioVinhoFake.Object);

            List<Vinho> clientes = servico.RetornarTodos();

            repositorioVinhoFake.Verify(x => x.BuscarTodos());
        }

        [TestMethod]
        public void AtualizarVinhoAplicacaoTeste()
        {
            Vinho vinho = new Vinho()
            {
                Coloracao = "",
                Graduacao = "",
                Descricao = "",
                Nome = ""
            };

            var repositorioVinhoFake = new Mock<IVinhoRepositorio>();
            repositorioVinhoFake.Setup(x => x.Atualizar(vinho)).Returns(new Vinho());


            IVinhoAplicacao servico = new VinhoAplicacao(repositorioVinhoFake.Object);

            Vinho novoVinho = servico.Atualizar(vinho);

            repositorioVinhoFake.Verify(x => x.Atualizar(vinho));
        }

        [TestMethod]
        public void DeletarVinhoAplicacaoTeste()
        {
            Vinho vinho = new Vinho()
            {
                Coloracao = "",
                Graduacao = "",
                Descricao = "",
                Nome = ""
            };

            var repositorioVinhoFake = new Mock<IVinhoRepositorio>();
            repositorioVinhoFake.Setup(x => x.Deletar(vinho));


            IVinhoAplicacao servico = new VinhoAplicacao(repositorioVinhoFake.Object);

            servico.Deletar(vinho);

            repositorioVinhoFake.Verify(x => x.Deletar(vinho));
        }
    }
}