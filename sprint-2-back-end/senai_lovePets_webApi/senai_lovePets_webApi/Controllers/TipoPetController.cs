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
    public class TipoPetController : ControllerBase
    {
        private ITipoPetRepository _TipoPetRepository { get; set; }

    public TipoPetController()
    {
        _TipoPetRepository = new TipoPetRepository();
    }



    [HttpGet]
    public IActionResult ListarTodos()
    {
        try
        {
            return Ok(_TipoPetRepository.ListarTodos());
        }
        catch (Exception erro)
        {
            return BadRequest(erro);
        }
    }


    [HttpGet("{idTipoPet}")]
    public IActionResult BuscarPorId(int idTipoPet)
    {
        try
        {
            return Ok(_TipoPetRepository.BuscarPorId(idTipoPet));
        }
        catch (Exception erro)
        {
            return BadRequest(erro);
        }
    }



    [HttpPost]
    public IActionResult Atualizar(int idTipoPet, TipoPet TipoPetAtualizada)
    {
        try
        {
            _TipoPetRepository.Atualizar(idTipoPet, TipoPetAtualizada);

            return StatusCode(201);
        }
        catch (Exception erro)
        {
            return BadRequest(erro);
        }
    }



    [HttpDelete("{idTipoPet}")]
    public IActionResult Deletar(int idTipoPet)
    {
        try
        {
            _TipoPetRepository.Deletar(idTipoPet);

            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro);
        }
    }





}
}
