using System.Buffers.Text;
using System.Reflection.Metadata;

namespace ProjetoEmpreendeMaster.DTO
{
    public class AdicionarAtividadeDTO
    {
        public string Nome { get; set; }
        public string Arquivo { get; set; }
        public int EstudanteId { get; set; }
        public int EducadorId { get; set; }
    }
}
