using Eocean.Parking.Financeiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Eocean.Parking.Financeiro.Dominio.Repositorio
{
    public class ReceitaRepositorio
    {
        private readonly ParkingDbEntities _context = new ParkingDbEntities();

        public IEnumerable<Receita> Receitas
        {
            get { return _context.Receita; }
        }

        public IEnumerable<Receita> ObterReceitas()
        {
            IEnumerable<Receita> receitas = _context.Receita.ToList();

            return receitas;
        }

        public void Salvar(Receita receita)
        {
            if (receita.IdReceita == 0)
            {
                //novo
                if (receita.DtCadastro == DateTime.Parse("01/01/0001 00:00:00"))
                {
                    receita.DtCadastro = DateTime.Now;
                }

                _context.Receita.Add(receita);
            }
            else
            {
                //Alteracao
                Receita rece = _context.Receita.Find(receita.IdReceita);

                if (rece != null)
                {
                    rece.IdReceita = receita.IdReceita;
                    rece.Nome = receita.Nome;
                    rece.Valor = receita.Valor;
                    rece.IdReceitaGrupo = receita.IdReceitaGrupo;
                    rece.DtRecebimento = receita.DtRecebimento;
                    rece.IdMensalista = receita.IdMensalista;
                    rece.DtAlteracao = DateTime.Now;
                    rece.IdUsuario = receita.IdUsuario;
                }
            }

            _context.SaveChanges();

        }

        public Receita Excluir(int idReceita)
        {
            Receita receita = _context.Receita.Find(idReceita);

            if (receita != null)
            {
                _context.Receita.Remove(receita);
                _context.SaveChanges();
            }

            return receita;
        }
    }
}
