using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eocean.Parking.Financeiro.Dominio.Entidades;

namespace Eocean.Parking.Financeiro.Dominio.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly ParkingDbEntities _context = new ParkingDbEntities();

        //public IEnumerable<Usuario> Usuarios
        //{
        //    get { return _context.Usuario; }
        //}
        public Usuario ObterAdministrador(Usuario usuario)
        {
            return _context.Usuario.FirstOrDefault(a => a.Login == usuario.Login);
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                //novo   
                _context.Usuario.Add(usuario);
            }
            else
            {
                Usuario usua = _context.Usuario.Find(usuario.IdUsuario);

                if (usua != null)
                {
                    usua.Login = usuario.Login;
                    usua.Email = usuario.Email;
                    usua.Perfil = usuario.Perfil;
                    usua.IdUsuarioCadastro = usuario.IdUsuarioCadastro;
                    usua.DtAlteracao = DateTime.Now;
                    //usua.DtCadastro = usuario.DtCadastro;
                }
            }

            _context.SaveChanges();

        }

        //public Usuario Excluir(int produtoId)
        //{
        //    Produto prod = _context.Produtos.Find(produtoId);

        //    if (prod != null)
        //    {
        //        _context.Produtos.Remove(prod);
        //        _context.SaveChanges();
        //    }

        //    return prod;
        //}
    }
}
