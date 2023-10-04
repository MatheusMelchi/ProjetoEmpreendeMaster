using ProjetoEmpreendeMaster.Models;

namespace ProjetoEmpreendeMaster.DTO
{
    public class AtividadesUsuarioDTO
    {
        public Usuario Usuario { get; set; }
        public List<Atividade> Atividades { get; set; }
    }
}
