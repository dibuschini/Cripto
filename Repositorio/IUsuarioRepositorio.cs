using Dimensiona.Models;

namespace Dimensiona.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> BuscarTodos();


        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel ListarPorId(int id);

        UsuarioModel Editar(UsuarioModel usuario);
    }
}
