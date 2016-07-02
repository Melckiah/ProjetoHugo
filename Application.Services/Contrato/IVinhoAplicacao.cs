using Domain.Model.Entity;
using System.Collections.Generic;

namespace Applications.Services.Contrato
{
    public interface IVinhoAplicacao
    {
        Vinho Criar(Vinho vinho);
        Vinho Atualizar(Vinho vinho);
        void Deletar(Vinho vinho);
        Vinho Retornar(int v);
        List<Vinho> RetornarTodos();
    }

}