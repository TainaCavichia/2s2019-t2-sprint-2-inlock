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
    [Authorize(Roles = "ADMINISTRADOR")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudioRepository estudioRepository = new EstudioRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estudioRepository.Listar());
        }

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

                estudioRepository.Atualizar(EstudioBuscado);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}