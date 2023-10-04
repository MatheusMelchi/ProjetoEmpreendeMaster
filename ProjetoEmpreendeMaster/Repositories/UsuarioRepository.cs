using ProjetoEmpreendeMaster.Data;
using ProjetoEmpreendeMaster.Interfaces;
using ProjetoEmpreendeMaster.Models;
using System.Collections.ObjectModel;

namespace ProjetoEmpreendeMaster.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = _context.Usuarios.OrderBy(x => x.Id).ToList();

            return usuarios;    
        }

        public Usuario GetUsuario(int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            return usuario;
        }

        public void PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }

        public Usuario AutenticarUsuario(string email, string senha)
        {
            Usuario usuario = _context.Usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            return usuario;
        }

        public List<Usuario> UsuariosEstudantes()
        {
            List<Usuario> estudantes = _context.Usuarios.Where(x => x.TipoUsuarioId == 3).ToList();

            return estudantes;
        }

    }
}
