using ProjetoEmpreendeMaster.Data;
using ProjetoEmpreendeMaster.DTO;
using ProjetoEmpreendeMaster.Interfaces;
using ProjetoEmpreendeMaster.Models;

namespace ProjetoEmpreendeMaster.Repositories
{
    public class AtividadeRepository : IAtividadeRepository
    {
        private readonly DataContext _context;

        public AtividadeRepository(DataContext context)
        {
            _context = context;
        }

        public List<Atividade> getAtividades()
        {
            List<Atividade> atividades = _context.Atividades.OrderBy(x => x.Id).ToList();

            return atividades;
        }

        public Atividade GetAtividade(int id)
        {
            Atividade atividade = _context.Atividades.FirstOrDefault(x => x.Id == id);

            return atividade;
        }

        public List<Atividade> GetAtividadeByEstudante(int estudante_id)
        {
            List<Atividade> atividadesUsuario = _context.Atividades.Where(x => x.EstudanteId == estudante_id).ToList();

            return atividadesUsuario;
        }

        public List<Atividade> GetAtividadeByEducador(int educador_id)
        {
            List<Atividade> atividadesUsuario = _context.Atividades.Where(x => x.EducadorId == educador_id).ToList();

            return atividadesUsuario;
        }

        public AtividadesUsuarioDTO GetAtividadesEstudante(int estudante_id)
        {
            AtividadesUsuarioDTO retorno = new();

            var atividades = from u in _context.Usuarios
                             join at in _context.Atividades on u.Id equals at.EstudanteId
                             into at1
                             from at in at1.DefaultIfEmpty()
                             where u.Id == estudante_id
                             select new
                             {
                                 usuario = u,
                                 Atividade = at
                             };

            if (atividades.Any())
            {
                retorno = new AtividadesUsuarioDTO
                {
                    Usuario = atividades.FirstOrDefault().usuario,
                    Atividades = atividades.Select(x => x.Atividade).ToList(),
                };
            }
            else
            {
                retorno = new AtividadesUsuarioDTO
                {
                    Usuario = _context.Usuarios.FirstOrDefault(x => x.Id == estudante_id),
                    Atividades = new List<Atividade>()
                };
            }

            return retorno;
        }

        public AtividadesUsuarioDTO GetAtividadesEducador(int educador_id)
        {
            AtividadesUsuarioDTO retorno = new();

            var atividades = from u in _context.Usuarios
                             join at in _context.Atividades on u.Id equals at.EducadorId
                             into at1
                             from at in at1.DefaultIfEmpty()
                             where u.Id == educador_id
                             select new
                             {
                                 usuario = u,
                                 Atividade = at
                             };

            if (atividades.Any())
            {
                retorno = new AtividadesUsuarioDTO
                {
                    Usuario = atividades.FirstOrDefault().usuario,
                    Atividades = atividades.Select(x => x.Atividade).ToList(),
                };
            }
            else
            {
                retorno = new AtividadesUsuarioDTO
                {
                    Usuario = _context.Usuarios.FirstOrDefault(x => x.Id == educador_id),
                    Atividades = new List<Atividade>()
                };
            }

            return retorno;
        }

        public void AdicionarAtividade(Atividade atividade)
        {
            _context.Atividades.Add(atividade);

            _context.SaveChanges();
        }

        public void UpdateAtividade(Atividade atividade)
        {
            _context.Atividades.Update(atividade);

            _context.SaveChanges(); 
        }

        public ArquivoDTO GetArquivoAtividadeCorrecao(int atividadeId)
        {
            ArquivoDTO arquivoCorrecao = new ArquivoDTO
            {
                Arquivo = _context.Atividades.FirstOrDefault(x => x.Id.Equals(atividadeId)).ArquivoAtividadeCorrecao,
                ExtensaoArquivo = "pdf"
            };

            return arquivoCorrecao;
        }

        public byte[] GetArquivoAtividade(int atividadeId)
        {
            byte[] arquivoCorrecao = _context.Atividades.FirstOrDefault(x => x.Id.Equals(atividadeId)).ArquivoAtividade;

            return arquivoCorrecao;
        }

    }
}
