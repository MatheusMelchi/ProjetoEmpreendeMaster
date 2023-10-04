using ProjetoEmpreendeMaster.DTO;
using ProjetoEmpreendeMaster.Models;

namespace ProjetoEmpreendeMaster.Interfaces
{
    public interface IAtividadeRepository
    {
        public List<Atividade> getAtividades();

        public Atividade GetAtividade(int id);

        public List<Atividade> GetAtividadeByEstudante(int estudante_id);

        public List<Atividade> GetAtividadeByEducador(int educador_id);

        public AtividadesUsuarioDTO GetAtividadesEstudante(int estudante_id);

        public void AdicionarAtividade(Atividade atividade);

        public AtividadesUsuarioDTO GetAtividadesEducador(int educador_id);

        public void UpdateAtividade(Atividade atividade);

        public ArquivoDTO GetArquivoAtividadeCorrecao(int atividadeId);

        public byte[] GetArquivoAtividade(int atividadeId);
    }
}
