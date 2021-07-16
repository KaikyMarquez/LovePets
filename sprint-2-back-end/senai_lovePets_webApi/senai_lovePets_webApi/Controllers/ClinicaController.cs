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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _ClinicaRepository { get; set; }

        public ClinicaController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_ClinicaRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idClinica}")]
        public IActionResult BuscarPorId (int idClinica)
        {
            try
            {
                return Ok(_ClinicaRepository.BuscarPorId(idClinica));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Atualizar(int idClinica, Clinica ClinicaAtualizada)
        {
            try
            {
                _ClinicaRepository.Atualizar(idClinica, ClinicaAtualizada);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idClinica}")]
        public IActionResult Deletar(int idClinica)
        {
            try
            {
                _ClinicaRepository.Deletar(idClinica);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
