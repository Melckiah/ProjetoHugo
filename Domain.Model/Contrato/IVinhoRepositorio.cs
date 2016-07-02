using Domain.Model.Entity;
using System.Collections.Generic;

namespace Domain.Model.Contrato
{
    public interface IVinhoRepositorio
    {
        Vinho Salvar(Vinho vinho);
        Vinho Buscar(int id);
        List<Vinho> BuscarTodos();
        Vinho Atualizar(Vinho vinho);
        void Deletar(Vinho vinho);
    }
}