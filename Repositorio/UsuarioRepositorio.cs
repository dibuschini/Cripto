using Dimensiona.Data;
using Dimensiona.Models;

namespace Dimensiona.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuario.ToList();
        }

        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);

            if(usuarioDb == null ) throw new System.Exception("Erro ao atualizar");

            usuarioDb.Id = usuario.Id;
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Celular = usuario.Celular;
            usuarioDb.Rua = usuario.Rua;
            usuarioDb.Bairro = usuario.Bairro;
            usuarioDb.Cidade = usuario.Cidade;
            _bancoContext.Usuario.Update(usuarioDb);
            _bancoContext.SaveChanges();
            return usuarioDb;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Id == id);
        }
    }
}
