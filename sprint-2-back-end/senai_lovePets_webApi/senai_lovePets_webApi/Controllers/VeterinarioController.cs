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
    public class VeterinarioController : ControllerBase
    {
        private IVeterinarioRepository _VeterinarioRepository { get; set; }

        public VeterinarioController()
        {
            _VeterinarioRepository = new VeterinarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_VeterinarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpGet("{idVeterinario}")]
        public IActionResult BuscarPorId(int idVeterinario)
        {
            try
            {
                return Ok(_VeterinarioRepository.BuscarPorId(idVeterinario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpPost]
        public IActionResult Atualizar(int idVeterinario, Veterinario VeterinarioAtualizada)
        {
            try
            {
                _VeterinarioRepository.Atualizar(idVeterinario, VeterinarioAtualizada);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpDelete("{idVeterinario}")]
        public IActionResult Deletar(int idVeterinario)
        {
            try
            {
                _VeterinarioRepository.Deletar(idVeterinario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }







    }
}
