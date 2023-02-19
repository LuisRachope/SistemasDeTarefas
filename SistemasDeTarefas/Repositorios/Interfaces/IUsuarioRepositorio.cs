using SistemasDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasDeTarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario, int id);
        Task<bool> Apagar(int id);
    }
}
