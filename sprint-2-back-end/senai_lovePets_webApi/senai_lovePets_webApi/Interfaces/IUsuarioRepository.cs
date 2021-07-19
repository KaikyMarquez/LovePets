using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IUsuarioRepository
    {

        List<Usuario> ListarTodos();
        
        /// <summary>
        /// Busca um Usuario Existente
        /// </summary>
        /// <param name="email"> O e-mail que o usuario digitou</param>
        /// <param name="Senha">A senha que o usuario digitou</param>
        /// <returns>Um usuario encontrado</returns>
        
        Usuario Login(string email, string Senha);


        Usuario BuscarPorId(int idUsuario);


        void Cadastrar(Usuario novoUsuario);


        void Atualizar(int idUsuario, Usuario UsuarioAtualizado);


        void Deletar(int idUsuario);
    }
}
