using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoEmpreendeMaster.Models
{
    public class Atividade
    {
        [Column("ATIVIDADE_ID")]
        public int Id { get; set; }

        [Column("EDUCADOR_ID")]
        public int EducadorId { get; set; }

        [Column("ESTUDANTE_ID")]
        public int EstudanteId { get; set; }

        [Column("ARQUIVO_ATIVIDADE", TypeName = "BLOB")]
        public byte[] ArquivoAtividade { get; set; }

        [Column("ARQUIVO_ATIVIDADE_CORRECAO", TypeName = "BLOB")]
        [AllowNull]
        public byte[]? ArquivoAtividadeCorrecao { get; set; }

        [Column("NOTA")]
        public decimal Nota { get; set; }

        [Column("CONCLUIDO")]
        public bool Concluido { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }
    }
}
