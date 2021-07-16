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
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DonoController : ControllerBase
    {
        private IDonoRepository _DonoRepository { get; set; }

        public DonoController()
        {
            _DonoRepository = new DonoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_DonoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idDono}")]
        public IActionResult BuscarPorId(int idDono)
        {
            try
            {
                return Ok(_DonoRepository.BuscarPorId(idDono));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Atualizar(int idDono, Dono DonoAtualizado)
        {
            try
            {
                _DonoRepository.Atualizar(idDono, DonoAtualizado);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idDono}")]
        public IActionResult Deletar(int idDono)
        {
            try
            {
                _DonoRepository.Deletar(idDono);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



    }
}
