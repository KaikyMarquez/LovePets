using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using senai_lovePets_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Controllers
{   [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {

            _TipoUsuarioRepository = new TipoUsuarioRepository();

        }


        [HttpGet]
        public IActionResult ListarTodos()
        {

            try
            {
                return Ok(_TipoUsuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarPorId(int idTipoUsuario)
        {

            try
            {
                return Ok(_TipoUsuarioRepository.BuscarPorId(idTipoUsuario));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPost]
        public IActionResult Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado)
        {
            try
            {

                _TipoUsuarioRepository.Atualizar(idTipoUsuario, TipoUsuarioAtualizado);

                return StatusCode(201);

            }
            catch (Exception erro)

            {

                return BadRequest(erro);
            }


        }

        [HttpDelete("{idTipoUsuario}")]
        public IActionResult Deletar(int idTipoUsuario)
        {
            try
            {

                _TipoUsuarioRepository.Deletar(idTipoUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }





        }







    }
}
