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
    
    public partial class DespesaCategoriaGrupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DespesaCategoriaGrupo()
        {
            this.DespesaCategoria = new HashSet<DespesaCategoria>();
        }
    
        public int IdDespesaCategoriaGrupo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public Nullable<System.DateTime> DtAlteracao { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DespesaCategoria> DespesaCategoria { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
