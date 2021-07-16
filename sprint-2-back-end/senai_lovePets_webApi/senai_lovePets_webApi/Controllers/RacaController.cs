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
    public class RacaController : ControllerBase
    {

        private IRacaRepository _RacaRepository { get; set; }

        public RacaController()
        {
            _RacaRepository = new RacaRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_RacaRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        [HttpGet("{idRaca}")]
        public IActionResult BuscarPorId(int idRaca)
        {
            try
            {
                return Ok(_RacaRepository.BuscarPorId(idRaca));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        [HttpPost]
        public IActionResult Atualizar(int idRaca, Raca RacaAtualizada)
        {
            try
            {
                _RacaRepository.Atualizar(idRaca, RacaAtualizada);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        [HttpDelete("{idRaca}")]
        public IActionResult Deletar(int idRaca)
        {
            try
            {
                _RacaRepository.Deletar(idRaca);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
