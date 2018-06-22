using Eocean.Parking.Financeiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eocean.Parking.Financeiro.Dominio.Repositorio
{
    public class DespesaRepositorio
    {
        private readonly ParkingDbEntities _context = new ParkingDbEntities();

        public IEnumerable<Despesa> Despesas
        {
            get { return _context.Despesa; }
        }

        public IEnumerable<Despesa> ObterDespesas(string pago, int? anoCadastro, int? mesCadastro)
        {
            IEnumerable<Despesa> despesas;
            
            if (pago == "null" || pago==null)
            {
                despesas = from c in _context.Despesa
                    orderby c.DtPagamento descending
                    where c.DtCadastro.Year == anoCadastro || anoCadastro.Equals(null)
                    where c.DtCadastro.Month == mesCadastro || mesCadastro.Equals(null)
                           select c;
                return despesas;
            }

            bool pg = bool.Parse(pago);

            despesas = from c in _context.Despesa
                orderby c.DtPagamento descending
                where c.Pago == pg// || pago.Equals(null) || pago.Equals("")
                where c.DtCadastro.Year == anoCadastro || anoCadastro.Equals(null)
                where c.DtCadastro.Month == mesCadastro || mesCadastro.Equals(null)
                select c;
            return despesas;


        }

        public void Salvar(Despesa despesa)
        {
            if (despesa.IdDespesa == 0)
            {
                //novo
                if (despesa.DtCadastro == DateTime.Parse("01/01/0001 00:00:00"))
                {
                    despesa.DtCadastro = DateTime.Now;
                }
                
                _context.Despesa.Add(despesa);
            }
            else
            {
                //Alteracao
                Despesa desp = _context.Despesa.Find(despesa.IdDespesa);

                if (desp != null)
                {
                    desp.DtAlteracao = DateTime.Now;
                    desp.Descricao = despesa.Descricao;
                    desp.ValorDespesa = despesa.ValorDespesa;
                    desp.DtVencimento = despesa.DtVencimento;
                    desp.Pago = despesa.Pago;
                    desp.DtPagamento = despesa.DtPagamento;
                    desp.PossuiParcelas = despesa.PossuiParcelas;
                    desp.QtParcelas = despesa.QtParcelas;
                    desp.IdDespesaCategoria = despesa.IdDespesaCategoria;
                    desp.IdFuncionario = despesa.IdFuncionario;
                    desp.IdUsuario = despesa.IdUsuario;
                    desp.CodDespesa = despesa.CodDespesa;
                    desp.IdFornecedor = despesa.IdFornecedor;
                }
            }

            _context.SaveChanges();

        }

        public Despesa Excluir(int idDespesa)
        {
            Despesa despesa = _context.Despesa.Find(idDespesa);

            if (despesa != null)
            {
                _context.Despesa.Remove(despesa);
                _context.SaveChanges();
            }

            return despesa;
        }

        public int? ObterQuantidadeParcelas(int idDespesa)
        {
            return _context.Despesa.Find(idDespesa)?.QtParcelas;
        }

        public void ExcluirTodasParcelas(string codDespesa)
        {
            int i = 0;

            IEnumerable<Despesa> lstDespesaParcelas = _context.Despesa.Where(x => x.CodDespesa == codDespesa).OrderBy(x =>x.IdDespesa);

            foreach (var despesa in lstDespesaParcelas)
            {
                if (i > 0)
                {
                    _context.Despesa.Remove(despesa);
                }

                i++;
            }
            _context.SaveChanges();
        }
    }
}
