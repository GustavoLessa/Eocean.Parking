using System.Collections.Generic;
using System.Globalization;
using Eocean.Parking.Financeiro.Dominio.Repositorio;

namespace Eocean.Parking.Financeiro.Dominio.Entidades
{
    public class DashBoard
    {
        private readonly DashBoardRepositorio _repositorio = new DashBoardRepositorio();

        public string Mes;
        public string Ano;

        //Total de despesa (mes)
        public decimal TotalDespesasMes { get; set; }

        public decimal TotalDespesasPendentes { get; set; }

        public decimal TotalDespesasPagas { get; set; }

        public IEnumerable<CategoriaValor> DespesasPorCategoria { get; set; }

        public IEnumerable<CategoriaValor> DespesasPorSubCategoria { get; set; }


        public decimal? TotalReceitaMes { get; set; }

        public decimal? TotalReceitasRecebidas { get; set; }

        public decimal? TotalReceitaPendentes { get; set; }

        public IEnumerable<CategoriaValor> ReceitaPorCategoria { get; set; }


        public DashBoard(int? mes, int? ano)
        {
            if (mes != null)
            {
                Mes = new CultureInfo("pt-BR").DateTimeFormat.GetMonthName((int)mes);
            }

            Ano = ano.ToString();

            TotalDespesasMes = _repositorio.ObterTotalDespesasMes(mes, ano);
            TotalDespesasPendentes = _repositorio.ObterTotalDespesasPendentes(mes, ano);
            TotalDespesasPagas = _repositorio.ObterTotalDespesasPagas(mes, ano);
            DespesasPorCategoria = _repositorio.ObterTotalDespesaPorCategoria(mes, ano);
            DespesasPorSubCategoria = _repositorio.ObterTotalDespesaPorSubCategoria(mes, ano);

            TotalReceitaMes = _repositorio.ObterTotalReceitasMes(mes, ano);
            TotalReceitasRecebidas = _repositorio.ObterTotalReceitasRecebidas(mes, ano);
            TotalReceitaPendentes = _repositorio.ObterTotalReceitasPendentes(mes, ano);
            ReceitaPorCategoria = _repositorio.ObterTotalReceitaPorCategoria(mes, ano);

        }


    //Média de carros por dia

    //Média de valor de rotativos do mes

    //Média de valor de rotativo geral

    //Total de valor de rotativo do mes

    //Total de valor de rotativo ano

    //Total de receita agrupada por categoria



    //Total de despesa agrupada por categoria (mes)

    //Total de despesa agrupada por sub categoria (mes)
}
}
