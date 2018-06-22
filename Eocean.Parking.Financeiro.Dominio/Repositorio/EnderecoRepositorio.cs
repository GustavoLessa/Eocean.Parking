using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eocean.Parking.Financeiro.Dominio.Entidades;

namespace Eocean.Parking.Financeiro.Dominio.Repositorio
{
    public class EnderecoRepositorio
    {
        private readonly ParkingDbEntities _context = new ParkingDbEntities();

        public IEnumerable<Endereco> Enderecos => _context.Endereco;

        public void Salvar(Mensalista mensalista)
        {
            if (mensalista.IdMensalista == 0)
            {
                //novo
                if (mensalista.DtCadastro == DateTime.Parse("01/01/0001 00:00:00"))
                {
                    mensalista.DtCadastro = DateTime.Now;
                }

                _context.Mensalista.Add(mensalista);
            }
            else
            {
                //Alteracao
                Mensalista mensal = _context.Mensalista.Find(mensalista.IdMensalista);

                if (mensal != null)
                {
                    mensal.PlacaVeiculo = mensalista.PlacaVeiculo;
                    mensal.MarcaModeloVeiculo = mensalista.MarcaModeloVeiculo;
                    mensal.Cor = mensalista.Cor;
                    mensal.TipoVeiculo = mensalista.TipoVeiculo;
                    mensal.DtInicio = mensalista.DtInicio;
                    mensal.Status = mensalista.Status;
                    mensal.DtAlteracao = DateTime.Now;
                    mensal.IdUsuario = mensalista.IdUsuario;
                }

                Pessoa pessoa = _context.Pessoa.Find(mensalista.IdPessoa);

                if (pessoa != null)
                {
                    pessoa.Nome = mensalista.Pessoa.Nome;
                    pessoa.CpfCnpj = mensalista.Pessoa.CpfCnpj;
                    pessoa.DtNascimento = mensalista.Pessoa.DtNascimento;
                    pessoa.NrIdentidade = mensalista.Pessoa.NrIdentidade;
                    pessoa.NrTelefoneCelular = mensalista.Pessoa.NrTelefoneCelular;
                    pessoa.NrTelefoneFixo = mensalista.Pessoa.NrTelefoneFixo;
                }

                Endereco endereco = _context.Endereco.Find(pessoa.IdEndereco);

                if (endereco != null)
                {
                    endereco.Logradouro = pessoa.Endereco.Logradouro;
                    endereco.NrLogradouro = pessoa.Endereco.NrLogradouro;
                    endereco.Complemento = pessoa.Endereco.Complemento;
                    endereco.Bairro = pessoa.Endereco.Bairro;
                    endereco.Cidade = pessoa.Endereco.Cidade;
                    endereco.Estado = pessoa.Endereco.Estado;
                    endereco.UF = pessoa.Endereco.UF;
                    endereco.Cep = pessoa.Endereco.Cep;
                }
            }

            _context.SaveChanges();

        }

        public Mensalista Excluir(int idMensalista)
        {
            Mensalista mensalista = _context.Mensalista.Find(idMensalista);

            if (mensalista != null)
            {
                _context.Mensalista.Remove(mensalista);
                _context.SaveChanges();
            }

            return mensalista;
        }
    }
}
