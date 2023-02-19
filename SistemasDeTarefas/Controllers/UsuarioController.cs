using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List<Usuario> usarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            Usuario usario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuario)
        {
            Usuario user = await _usuarioRepositorio.Adicionar(usuario);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar([FromBody] Usuario usuario, int id)
        {
            usuario.Id = id;
            Usuario user = await _usuarioRepositorio.Atualizar(usuario, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
