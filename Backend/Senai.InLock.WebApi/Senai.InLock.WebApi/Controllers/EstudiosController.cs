using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudioRepository estudioRepository = new EstudioRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estudioRepository.Listar());
        }

        [Authorize]
        [HttpGet("jogos")]
        public IActionResult ListarEstudiosEJogos()
        {
            return Ok(estudioRepository.ListarEstudiosEJogos());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("buscarpornome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            Estudios estudio = estudioRepository.BuscarPorNome(nome);

            if (estudio == null)
            {
                return NotFound();
            }
            return Ok(estudio);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("buscarporpais/{pais}")]
        public IActionResult BuscarPorPais(string pais)
        {
            return Ok(estudioRepository.BuscarPorPais(pais));
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estudios estudio = estudioRepository.BuscarPorId(id);

            if(estudio == null)
            {
                return NotFound();
            }

            return Ok(estudio);

        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                estudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita" + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Estudios estudio)
        {
            try
            {
                Estudios EstudioBuscado = estudioRepository.BuscarPorId(estudio.EstudioId);

                if (EstudioBuscado == null)
                {
                    return NotFound();
                }   

                estudioRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Estudios EstudioBuscado = estudioRepository.BuscarPorId(id);

                if (EstudioBuscado == null)
                {
                    return NotFound();
                }

                estudioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}