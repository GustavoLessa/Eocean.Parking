using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eocean.Parking.Financeiro.Dominio.Entidades;

namespace Eocean.Parking.Financeiro.Dominio.Repositorio
{
    public class DespesaCategoriaRepositorio
    {
        private readonly ParkingDbEntities _context = new ParkingDbEntities();

        public IEnumerable<DespesaCategoria> DespesaCategorias
        {
            get { return _context.DespesaCategoria; }
        }

        public void Salvar(DespesaCategoria despesaCategoria)
        {
            if (despesaCategoria.IdDespesaCategoria == 0)
            {
                //novo
                despesaCategoria.DtCadastro = DateTime.Now;
                _context.DespesaCategoria.Add(despesaCategoria);
            }
            else
            {
                //Alteracao
                DespesaCategoria categoria = _context.DespesaCategoria.Find(despesaCategoria.IdDespesaCategoria);

                if (categoria != null)
                {
                    categoria.DtAlteracao = DateTime.Now;
                    categoria.Nome = despesaCategoria.Nome;
                    categoria.Descricao = despesaCategoria.Descricao;
                    categoria.IdDespesaCategoriaGrupo = despesaCategoria.IdDespesaCategoriaGrupo;
                }
            }

            _context.SaveChanges();

        }

        public DespesaCategoria Excluir(int idDespesaCategoria)
        {
            DespesaCategoria categoria = _context.DespesaCategoria.Find(idDespesaCategoria);

            if (categoria != null)
            {
                _context.DespesaCategoria.Remove(categoria);
                _context.SaveChanges();
            }

            return categoria;
        }
    }
}
