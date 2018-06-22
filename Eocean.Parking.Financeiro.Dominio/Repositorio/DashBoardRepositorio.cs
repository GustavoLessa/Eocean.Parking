using Eocean.Parking.Financeiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eocean.Parking.Financeiro.Dominio.Repositorio
{
    public class DashBoardRepositorio
    {
        private readonly ParkingDbEntities _context = new ParkingDbEntities();

        public decimal ObterTotalDespesasMes(int? mes, int? ano)
        {
            var despesas = _context.Despesa
                .Where(x => x.DtCadastro.Month == mes || mes.Equals(null))
                .Where(x => x.DtCadastro.Year == ano || ano.Equals(null))
                .Select(s => s.ValorDespesa)
                .DefaultIfEmpty(0)
                .Sum();

            return despesas;
        }

        public decimal ObterTotalDespesasPendentes(int? mes, int? ano)
        {
            var despesas = _context.Despesa
                .Where(x => x.DtCadastro.Month == mes || mes.Equals(null))
                .Where(x => x.DtCadastro.Year == ano || ano.Equals(null))
                .Where(x => x.Pago==false)
                .Select(s => s.ValorDespesa)
                .DefaultIfEmpty(0)
                .Sum();

            return despesas;
        }
        
        public decimal ObterTotalDespesasPagas(int? mes, int? ano)
        {
            
            var total = _context.Despesa
                .Where(x => x.DtCadastro.Month == mes || mes.Equals(null))
                .Where(x => x.DtCadastro.Year == ano || ano.Equals(null))
                .Where(x => x.Pago)
                .Select(s => s.ValorDespesa)
                .DefaultIfEmpty(0)
                .Sum();


            return total;
        }

        public IEnumerable<CategoriaValor> ObterTotalDespesaPorCategoria(int? mesCadastro, int? ano)
        {
            var query = from bs in _context.Despesa
                where(bs.DtCadastro.Month == mesCadastro || mesCadastro.Equals(null))
                where (bs.DtCadastro.Year == ano || ano.Equals(null))
                group bs by bs.IdDespesaCategoria into g
                //orderby g.Sum(x => x.MQTY)
                select new CategoriaValor
                {
                    IdCategoria = g.Key,
                    Categoria = g.FirstOrDefault().DespesaCategoria.Nome,
                    Valor = g.Sum(x => x.ValorDespesa)
                };
            

            return query.ToList();
        }

        public IEnumerable<CategoriaValor> ObterTotalDespesaPorSubCategoria(int? mes, int? ano)
        {
            var despesas = _context.Despesa
                .Where(x => x.DtCadastro.Month == mes || mes.Equals(null))
                .Where(x => x.DtCadastro.Year == ano || ano.Equals(null))
                .GroupBy(d => d.DespesaCategoria.IdDespesaCategoriaGrupo)
                .Select(g => new CategoriaValor
                {
                    IdCategoria = g.Key,
                    Categoria = g.FirstOrDefault().DespesaCategoria.DespesaCategoriaGrupo.Nome,
                    Valor = g.Sum(x => x.ValorDespesa)
                }).ToList();

            return despesas;
        }



        public decimal ObterTotalReceitasMes(int? mesCadastro, int? ano)
        {
           var total = _context.Receita
                .Where(x => x.DtCadastro.Value.Month == mesCadastro || mesCadastro.Equals(null))
                .Where(x => x.DtCadastro.Value.Year == ano || ano.Equals(null))
                .Select(s => s.Valor)
                .DefaultIfEmpty(0)
                .Sum();

            return total;
        }

        public decimal ObterTotalReceitasPendentes(int? mes, int? ano)
        {

            var total = _context.Receita
                .Where(x => x.DtCadastro.Value.Month == mes || mes.Equals(null))
                .Where(x => x.DtCadastro.Value.Year == ano || ano.Equals(null))
                .Where(x => x.DtRecebimento.Equals(null))
                .Select(s => s.Valor)
                .DefaultIfEmpty(0)
                .Sum();

            return total;
        }

        public decimal ObterTotalReceitasRecebidas(int? mes, int? ano)
        {
            var despesas = _context.Receita
                .Where(x => x.DtCadastro.Value.Month == mes || mes.Equals(null))
                .Where(x => x.DtCadastro.Value.Year == ano || ano.Equals(null))
                .Where(x => x.DtRecebimento != null)
                .Select(s => s.Valor)
                .DefaultIfEmpty(0)
                .Sum();

            return despesas;
        }

        public IEnumerable<CategoriaValor> ObterTotalReceitaPorCategoria(int? mesCadastro, int? ano)
        {
            var query = from bs in _context.Receita
                where (bs.DtCadastro.Value.Month == mesCadastro || mesCadastro.Equals(null))
                where (bs.DtCadastro.Value.Year == ano || ano.Equals(null))
                        group bs by bs.IdReceitaGrupo into g
                select new CategoriaValor
                {
                    IdCategoria = g.Key,
                    Categoria = g.FirstOrDefault().ReceitaGrupo.Nome,
                    Valor = g.Sum(x => x.Valor)
                };

            return query.ToList();
        }
    }

    public class CategoriaValor
    {
        public int? IdCategoria { get; set; }

        public string Categoria { get; set; }
        public decimal Valor { get; set; }
    }
}
