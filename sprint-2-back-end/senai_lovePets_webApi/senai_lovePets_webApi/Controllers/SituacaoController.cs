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
    public class SituacaoController : ControllerBase
    {
        private ISituacaoRepository _SituacaoRepository { get; set; }

        public SituacaoController()
        {
            _SituacaoRepository = new SituacaoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_SituacaoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpGet("{idSituacao}")]
        public IActionResult BuscarPorId(int idSituacao)
        {
            try
            {
                return Ok(_SituacaoRepository.BuscarPorId(idSituacao));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpPost]
        public IActionResult Atualizar(int idSituacao, Situacao SituacaoAtualizada)
        {
            try
            {
                _SituacaoRepository.Atualizar(idSituacao, SituacaoAtualizada);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpDelete("{idSituacao}")]
        public IActionResult Deletar(int idSituacao)
        {
            try
            {
                _SituacaoRepository.Deletar(idSituacao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }





    }
}
