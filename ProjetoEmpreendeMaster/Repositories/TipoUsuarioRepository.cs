using ProjetoEmpreendeMaster.Data;
using ProjetoEmpreendeMaster.Interfaces;
using ProjetoEmpreendeMaster.Models;

namespace ProjetoEmpreendeMaster.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly DataContext _context;

        public TipoUsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public List<TipoUsuario> GetTipoUsuarios()
        {
            List<TipoUsuario> tipoUsuarios = _context.TipoUsuarios.OrderBy(x => x.Id).ToList();

            return tipoUsuarios;
        }

    }
}
