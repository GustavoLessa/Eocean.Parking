using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eocean.Parking.Financeiro.Dominio.Entidades;

namespace Eocean.Parking.Financeiro.Dominio.Repositorio
{
    public class DespesaCategoriaGrupoRepositorio
    {
        private readonly ParkingDbEntities _context = new ParkingDbEntities();

        public IEnumerable<DespesaCategoriaGrupo> DespesaCategoriaGrupos
        {
            get { return _context.DespesaCategoriaGrupo; }
        }

        public void Salvar(DespesaCategoriaGrupo despesaCategoriaGrupo)
        {
            if (despesaCategoriaGrupo.IdDespesaCategoriaGrupo == 0)
            {
                //novo
                despesaCategoriaGrupo.DtCadastro = DateTime.Now; 
                _context.DespesaCategoriaGrupo.Add(despesaCategoriaGrupo);
            }
            else
            {
                //Alteracao
                DespesaCategoriaGrupo grupo = _context.DespesaCategoriaGrupo.Find(despesaCategoriaGrupo.IdDespesaCategoriaGrupo);
                
                if (grupo != null)
                {
                    grupo.DtAlteracao = DateTime.Now;
                    grupo.Nome = despesaCategoriaGrupo.Nome;
                    grupo.Descricao = despesaCategoriaGrupo.Descricao;
                }
            }

            _context.SaveChanges();

        }

        public DespesaCategoriaGrupo Excluir(int idDespesaCategoriaGrupo)
        {
            DespesaCategoriaGrupo grupo = _context.DespesaCategoriaGrupo.Find(idDespesaCategoriaGrupo);

            if (grupo != null)
            {
                _context.DespesaCategoriaGrupo.Remove(grupo);
                _context.SaveChanges();
            }

            return grupo;
        }
    }
}
