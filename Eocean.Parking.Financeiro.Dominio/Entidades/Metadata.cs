using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eocean.Parking.Financeiro.Dominio.Entidades
{
    public class UsuarioMetadata
    {
        [StringLength(20)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [StringLength(20)]
        [Display(Name = "Perfil")]
        public string Perfil { get; set; }

        [Display(Name = "Dt. Cadastro")]
        public DateTime DtCadastro { get; set; }

        [Display(Name = "Dt. Alteração")]
        public DateTime? DtAlteracao { get; set; }

        [Display(Name = "Usuário")]
        public int? IdUsuarioCadastro { get; set; }
    }

    public class DespesaCategoriaGrupoMetadata
    {

        public int IdDespesaCategoriaGrupo { get; set; }

        [Required(ErrorMessage = "Digite o nome")]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a descrição")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public DateTime DtCadastro { get; set; }

        public DateTime? DtAlteracao { get; set; }

        public int? IdUsuario { get; set; }
    }

    public class DespesaCategoriaMetadata
    {
        [Display(Name = "Sub Categoria")]
        public int IdDespesaCategoria { get; set; }

        //public string Nome { get; set; }

        //public string Descricao { get; set; }

        //public DateTime DtCadastro { get; set; }
        //public DateTime? DtAlteracao { get; set; }
        //public int? IdUsuario { get; set; }
        [Display(Name = "Categoria")]
        public int? IdDespesaCategoriaGrupo { get; set; }

        
        //public virtual ICollection<Despesa> Despesa { get; set; }
        //public virtual DespesaCategoriaGrupo DespesaCategoriaGrupo { get; set; }
        //public virtual Usuario Usuario { get; set; }
    }

    public class DespesaMetadata
    {
        [Required(ErrorMessage = "Informe o nome da despesa")]
        [Display(Name = "Despesa")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal ValorDespesa { get; set; }
        
        [Display(Name = "Dt. Pagamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DtPagamento { get; set; }

        [Display(Name = "Dt. Vencimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DtVencimento { get; set; }

        [Display(Name = "Pago?")]
        public bool Pago { get; set; }

        [Display(Name = "Possui parcelas?")]
        public bool PossuiParcelas { get; set; }

        //[Required(ErrorMessage = "Digite o número de parcelas")]
        [Display(Name = "Qtd. parcelas")]
        public int? QtParcelas { get; set; }

        [Display(Name = "Categoria")]
        public int? IdDespesaCategoria { get; set; }

        [Display(Name = "Funcionario")]
        public int? IdFuncionario { get; set; }

        [Display(Name = "Dt. Cadastro")]
        public DateTime DtCadastro { get; set; }

        [Display(Name = "Dt. Alteração")]
        public DateTime? DtAlteracao { get; set; }

        [Display(Name = "Usuario")]
        public int? IdUsuario { get; set; }

        [Display(Name = "Código despesa")]
        public string CodDespesa { get; set; }

        [Display(Name = "Fornecedor")]
        public int? IdFornecedor { get; set; }       
    }

    public class ReceitaMetadata
    {
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal Valor { get; set; }

        [Display(Name = "Dt. Recebimento")]
        [DataType(DataType.DateTime)]
        public DateTime? DtRecebimento { get; set; }

        [Display(Name = "Dt. Cadastro")]
        public DateTime? DtCadastro { get; set; }

        [Display(Name = "Dt. Alteração")]
        public DateTime? DtAlteracao { get; set; }

        [Display(Name = "Usuario")]
        public int? IdUsuario { get; set; }

        [Display(Name = "Grupo de Receita")]
        public int? IdReceitaGrupo { get; set; }

        [Display(Name = "Mensalista")]
        public int? IdMensalista { get; set; }
    }

    public class ReceitaGrupoMetadata
    {
        [Required]
        [Display(Name = "Grupo Receita")]
        public string Nome { get; set; }
        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Dt. Cadastro")]
        public DateTime? DtCadastro { get; set; }

        [Display(Name = "Dt. Alteração")]
        public DateTime? DtAlteracao { get; set; }

        [Display(Name = "Usuário")]
        public int? IdUsuario { get; set; }
    }

    public class EnderecoMetadata
    {
        public string Logradouro { get; set; }

        [Display(Name = "Nr. Logradouro")]
        public string NrLogradouro { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "UF")]
        public string UF { get; set; }

        [Display(Name = "Cep")]
        public string Cep { get; set; }
    }

    public class PessoaMetadata
    {
        [Required(ErrorMessage = "O Nome Completo é obrigatório.")]
        [Display(Name = "Nome Completo*", Description = "Nome e Sobrenome.")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage ="Números e caracteres especiais não são permitidos no nome.")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "Limite máximo de 150 caracteres")]
        [MaxLength(10)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Cpf ou Cnpj")]
        [Display(Name = "Cpf/Cnpj*")]
        public string CpfCnpj { get; set; }
        
        [MaxLength(10)]
        [Display(Name = "Nr. Identidade")]
        [StringLength(10, ErrorMessage = "Limite máximo de 10 caracteres")]
        public string NrIdentidade { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Dt. Nascimento")]
        [DisplayFormat(DataFormatString= "{0:dd/MM/yyyy}")]
        public DateTime? DtNascimento { get; set; }

        [Required(ErrorMessage = "Informe o número do celular")]
        [Display(Name = "Nr. Celular")]
        public string NrTelefoneCelular { get; set; }

        [Display(Name = "Nr. Fixo")]
        public string NrTelefoneFixo { get; set; }

        [Display(Name = "Endereço")]
        public int? IdEndereco { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe o e-mail")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "O Email deve ter no mínimo 5 e no máximo 15 caracteres.")]
        public string Email { get; set; }

    }

    public class MensalistaMetadata
    {
        [Display(Name = "Pessoa")]
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "Informe a placa do veículo")]
        [Display(Name = "Placa do veículo")]
        [MaxLength(7)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string PlacaVeiculo { get; set; }

        [Display(Name = "Marca/Modelo")]
        public string MarcaModeloVeiculo { get; set; }

        [Display(Name = "Cor", Description = "Cor do veículo")]
        public string Cor { get; set; }

        [Display(Name = "Tipo de veículo", Description = "Carro, moto, bicicleta...")]
        public string TipoVeiculo { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor Mensalidade")]
        public decimal ValorMensalidade { get; set; }

        [Display(Name = "Dt. Início")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DtInicio { get; set; }

        [Display(Name = "Status*", Description = "Status do mensalista (Ativo, Inativo, Bloqueado...)")]
        public string Status { get; set; }

        [Display(Name = "Dt. Cadastro")]
        public DateTime? DtCadastro { get; set; }

        [Display(Name = "Dt. Alteração")]
        public DateTime? DtAlteracao { get; set; }

        [Display(Name = "Usuário")]
        public int? IdUsuario { get; set; }
    }
}