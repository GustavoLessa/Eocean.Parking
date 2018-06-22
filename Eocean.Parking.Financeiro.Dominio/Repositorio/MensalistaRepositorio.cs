using System;
using System.Collections.Generic;
using Eocean.Parking.Financeiro.Dominio.Entidades;

namespace Eocean.Parking.Financeiro.Dominio.Repositorio
{
    public class MensalistaRepositorio
    {
        private readonly ParkingDbEntities _context = new ParkingDbEntities();

        public IEnumerable<Mensalista> Mensalistas => _context.Mensalista;

        public void Salvar(Mensalista mensalista)
        {
            if (mensalista.IdMensalista == 0)
            {
                //var endereco = new Endereco
                //{
                //    Logradouro = mensalista.Pessoa.Endereco.Logradouro,
                //    NrLogradouro = mensalista.Pessoa.Endereco.NrLogradouro,
                //    Complemento = mensalista.Pessoa.Endereco.Complemento,
                //    Bairro = mensalista.Pessoa.Endereco.Bairro,
                //    Cidade = mensalista.Pessoa.Endereco.Cidade,
                //    Estado = mensalista.Pessoa.Endereco.Estado,
                //    UF = mensalista.Pessoa.Endereco.UF,
                //    Cep = mensalista.Pessoa.Endereco.Cep
                //};

                //_context.Endereco.Add(endereco);
                //_context.SaveChanges();

                //var pessoa = new Pessoa
                //{
                //    Nome = mensalista.Pessoa.Nome,
                //    CpfCnpj = mensalista.Pessoa.CpfCnpj,
                //    DtNascimento = mensalista.Pessoa.DtNascimento,
                //    NrIdentidade = mensalista.Pessoa.NrIdentidade,
                //    NrTelefoneCelular = mensalista.Pessoa.NrTelefoneCelular,
                //    NrTelefoneFixo = mensalista.Pessoa.NrTelefoneFixo,
                //    IdEndereco = endereco.IdEndereco
                //};

                //_context.Pessoa.Add(pessoa);
                //_context.SaveChanges();


                //novo
                if (mensalista.DtCadastro == null)
                {
                    mensalista.DtCadastro = DateTime.Now;
                }

                //mensalista.IdPessoa = pessoa.IdPessoa;
                _context.Mensalista.Add(mensalista);
                //_context.SaveChanges();
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
                    mensal.Pessoa = mensalista.Pessoa;
                }

                //Pessoa pessoa = _context.Pessoa.Find(mensalista.IdPessoa);

                //if (pessoa != null)
                //{
                //    pessoa.Nome = mensalista.Pessoa.Nome;
                //    pessoa.CpfCnpj = mensalista.Pessoa.CpfCnpj;
                //    pessoa.DtNascimento = mensalista.Pessoa.DtNascimento;
                //    pessoa.NrIdentidade = mensalista.Pessoa.NrIdentidade;
                //    pessoa.NrTelefoneCelular = mensalista.Pessoa.NrTelefoneCelular;
                //    pessoa.NrTelefoneFixo = mensalista.Pessoa.NrTelefoneFixo;

                //    _context.Pessoa.Add(pessoa);
                //}

                //Endereco endereco = _context.Endereco.Find(pessoa.IdEndereco);

                //if (endereco != null)
                //{
                //    endereco.Logradouro = pessoa.Endereco.Logradouro;
                //    endereco.NrLogradouro = pessoa.Endereco.NrLogradouro;
                //    endereco.Complemento = pessoa.Endereco.Complemento;
                //    endereco.Bairro = pessoa.Endereco.Bairro;
                //    endereco.Cidade = pessoa.Endereco.Cidade;
                //    endereco.Estado = pessoa.Endereco.Estado;
                //    endereco.UF = pessoa.Endereco.UF;
                //    endereco.Cep = pessoa.Endereco.Cep;

                //    _context.Endereco.Add(endereco);
                //}
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
