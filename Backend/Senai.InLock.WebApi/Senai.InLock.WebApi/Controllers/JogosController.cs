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
    public class JogosController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogoRepository.Listar());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Jogos jogo = jogoRepository.BuscarPorId(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return Ok(jogo);

        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Jogos jogo)
        {
            try
            {
                jogoRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita" + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Jogos jogo)
        {
            try
            {
                Jogos JogoBuscado = jogoRepository.BuscarPorId(jogo.JogosId);

                if (JogoBuscado == null)
                {
                    return NotFound();
                }

                jogoRepository.Atualizar(jogo);
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
                Jogos JogoBuscado = jogoRepository.BuscarPorId(id);

                if (JogoBuscado == null)
                {
                    return NotFound();
                }

                jogoRepository.Atualizar(JogoBuscado);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}