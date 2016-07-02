using Domain.Model.Contrato;
using Domain.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using VinhoDados.Contexto;

namespace VinhoDados.Repositorio
{
    public class VinhoRepositorio : IVinhoRepositorio
    {
        private VinhoContexto _context;

        public VinhoRepositorio()
        {
            _context = new VinhoContexto();
        }

        public Vinho Atualizar(Vinho vinho)
        {
            var entry = _context.Entry<Vinho>(vinho);
            entry.State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return vinho;
        }

        public Vinho Buscar(int id)
        {
            return _context.Vinhos.Find(id);
        }

        public List<Vinho> BuscarTodos()
        {
            return _context.Vinhos.ToList();
        }

        public void Deletar(Vinho vinho)
        {
            var entry = _context.Entry<Vinho>(vinho);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        public Vinho Salvar(Vinho vinho)
        {
            var novaVinho = _context.Vinhos.Add(vinho);
            _context.SaveChanges();
            return novaVinho;
        }

    }
}