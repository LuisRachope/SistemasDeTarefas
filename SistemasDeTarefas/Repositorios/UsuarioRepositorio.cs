using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _sistemaTarefasDBContext;

        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _sistemaTarefasDBContext = sistemaTarefasDBContext;
        }


        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _sistemaTarefasDBContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _sistemaTarefasDBContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _sistemaTarefasDBContext.Usuarios.AddAsync(usuario);
            await _sistemaTarefasDBContext.SaveChangesAsync();

            return usuario;
        }


        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _sistemaTarefasDBContext.Usuarios.Update(usuarioPorId);
            await _sistemaTarefasDBContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _sistemaTarefasDBContext.Usuarios.Remove(usuarioPorId);
            await _sistemaTarefasDBContext.SaveChangesAsync();

            return true;
        }
    }
}
