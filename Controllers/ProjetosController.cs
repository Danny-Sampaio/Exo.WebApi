using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository projetoRepository;

        public ProjetosController(ProjetoRepository projetoRepository)
        {
            this.projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(projetoRepository.Listar());
        }

        // Cadastrar projeto
        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            projetoRepository.Cadastrar(projeto);
            return StatusCode(201);
        }

        // Buscar projeto por ID
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Projeto projeto = projetoRepository.BuscarPorId(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return Ok(projeto);
        }

        // Atualizar projeto
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            projetoRepository.Atualizar(id, projeto);
            return StatusCode(204);
        }

        // Deletar projeto
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                projetoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}