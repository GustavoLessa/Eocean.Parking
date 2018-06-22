using System;
using System.Collections.Generic;
using Eocean.Parking.Financeiro.Dominio.Entidades;

namespace Eocean.Parking.Financeiro.Dominio.Repositorio
{
    public class ReceitaGrupoRepositorio
    {
        private readonly ParkingDbEntities _context = new ParkingDbEntities();

        public IEnumerable<ReceitaGrupo> ReceitaGrupos
        {
            get { return _context.ReceitaGrupo; }
        }

        public void Salvar(ReceitaGrupo receitaGrupo)
        {
            if (receitaGrupo.IdReceitaGrupo == 0)
            {
                //novo
                if (receitaGrupo.DtCadastro == DateTime.Parse("01/01/0001 00:00:00") || receitaGrupo.DtCadastro == null)
                {
                    receitaGrupo.DtCadastro = DateTime.Now;
                }

                _context.ReceitaGrupo.Add(receitaGrupo);
            }
            else
            {
                //Alteracao
                ReceitaGrupo receGrupo = _context.ReceitaGrupo.Find(receitaGrupo.IdReceitaGrupo);

                if (receGrupo != null)
                {
                    receGrupo.IdReceitaGrupo = receitaGrupo.IdReceitaGrupo;
                    receGrupo.Nome = receitaGrupo.Nome;
                    receGrupo.Descricao = receitaGrupo.Descricao;
                    receGrupo.DtAlteracao = DateTime.Now;
                    receGrupo.IdUsuario = receitaGrupo.IdUsuario;
                }
            }

            _context.SaveChanges();

        }

        public ReceitaGrupo Excluir(int idReceitaGrupo)
        {
            ReceitaGrupo receitaGrupo = _context.ReceitaGrupo.Find(idReceitaGrupo);

            if (receitaGrupo != null)
            {
                _context.ReceitaGrupo.Remove(receitaGrupo);
                _context.SaveChanges();
            }

            return receitaGrupo;
        }
    }
}
