using System;
using System.Collections.Generic;
using Applications.Services.Contrato;
using Domain.Model.Contrato;
using Domain.Model.Entity;

namespace Applications.Services.Servico
{
    public class VinhoAplicacao : IVinhoAplicacao
    {
        private IVinhoRepositorio _repositorio;

        public VinhoAplicacao(IVinhoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        public Vinho Atualizar(Vinho vinho)
        {
            return _repositorio.Atualizar(vinho);
        }

        public Vinho Criar(Vinho vinho)
        {
            return _repositorio.Salvar(vinho);
        }

        public Vinho CriarVinho(Vinho vinho)
        {
            return _repositorio.Salvar(vinho);
        }

        public void Deletar(Vinho vinho)
        {
            _repositorio.Deletar(vinho);
        }

        public Vinho Retornar(int id)
        {
            return _repositorio.Buscar(id);
        }

        public List<Vinho> RetornarTodos()
        {
            return _repositorio.BuscarTodos();
        }
    }
}