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
    public class PetController : ControllerBase
    {

        private IPetRepository _PetRepository { get; set; }

        public PetController()
        {
            _PetRepository = new PetRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_PetRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idpet}")]
        public IActionResult BuscarPorId(int idPet)
        {
            try
            {
                return Ok(_PetRepository.BuscarPorId(idPet));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Atualizar(int idPet, Pet PetAtualizado)
        {
            try
            {
                _PetRepository.Atualizar(idPet, PetAtualizado);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idPet}")]
        public IActionResult Deletar(int idPet)
        {
            try
            {
                _PetRepository.Deletar(idPet);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



    }
}
