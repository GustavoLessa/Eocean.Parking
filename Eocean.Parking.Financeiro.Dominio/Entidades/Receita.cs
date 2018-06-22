//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eocean.Parking.Financeiro.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Receita
    {
        public int IdReceita { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Nullable<int> IdReceitaGrupo { get; set; }
        public Nullable<System.DateTime> DtRecebimento { get; set; }
        public Nullable<int> IdMensalista { get; set; }
        public Nullable<System.DateTime> DtCadastro { get; set; }
        public Nullable<System.DateTime> DtAlteracao { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        public virtual ReceitaGrupo ReceitaGrupo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Mensalista Mensalista { get; set; }
    }
}