using ProjetoEmpreendeMaster.Models;

namespace ProjetoEmpreendeMaster.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        public List<TipoUsuario> GetTipoUsuarios();
    }
}
