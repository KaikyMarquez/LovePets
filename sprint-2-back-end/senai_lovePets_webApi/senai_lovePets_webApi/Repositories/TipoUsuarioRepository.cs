using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = BuscarPorId(idTipoUsuario);

            if (TipoUsuarioAtualizado.NomeTipoUsuario != null)
            {
                TipoUsuarioBuscado.NomeTipoUsuario = TipoUsuarioAtualizado.NomeTipoUsuario;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);
            ctx.SaveChanges();

        }

        public TipoUsuario BuscarPorId(int idTipoUsuario)
        {
            return ctx.TipoUsuarios.Find(idTipoUsuario);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            ctx.TipoUsuarios.Remove(BuscarPorId(idTipoUsuario));
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
