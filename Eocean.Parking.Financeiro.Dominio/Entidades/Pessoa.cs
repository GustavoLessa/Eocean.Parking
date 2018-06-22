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
    
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            this.Funcionario = new HashSet<Funcionario>();
            this.Mensalista = new HashSet<Mensalista>();
        }
    
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string NrIdentidade { get; set; }
        public Nullable<System.DateTime> DtNascimento { get; set; }
        public string NrTelefoneCelular { get; set; }
        public string NrTelefoneFixo { get; set; }
        public Nullable<int> IdEndereco { get; set; }
        public string Email { get; set; }
    
        public virtual Endereco Endereco { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcionario> Funcionario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mensalista> Mensalista { get; set; }
    }
}