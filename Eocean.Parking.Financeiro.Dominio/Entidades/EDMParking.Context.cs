﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ParkingDbEntities : DbContext
    {
        public ParkingDbEntities()
            : base("name=ParkingDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Despesa> Despesa { get; set; }
        public virtual DbSet<DespesaCategoria> DespesaCategoria { get; set; }
        public virtual DbSet<DespesaCategoriaGrupo> DespesaCategoriaGrupo { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Receita> Receita { get; set; }
        public virtual DbSet<ReceitaGrupo> ReceitaGrupo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Mensalista> Mensalista { get; set; }
    }
}
