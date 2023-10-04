using ProjetoEmpreendeMaster.Models;

namespace ProjetoEmpreendeMaster.Interfaces
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
        void PostUsuario(Usuario usuario);
        Usuario AutenticarUsuario(string email, string senha);
        List<Usuario> UsuariosEstudantes();
    }
}
