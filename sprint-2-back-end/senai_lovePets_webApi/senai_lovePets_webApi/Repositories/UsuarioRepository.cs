using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idUsuario, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = BuscarPorId(idUsuario);

            if (UsuarioAtualizado.IdTipoUsuario > 0)
            {
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;
            }

            if (UsuarioAtualizado.Email != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
            }

            if (UsuarioAtualizado.Senha != null)
            {
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(UsuarioBuscado);
            ctx.SaveChanges();


        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.Find(idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
