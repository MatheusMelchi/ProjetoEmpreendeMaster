using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEmpreendeMaster.Models
{
    public class TipoUsuario
    {
        [Column("TIPO_USUARIO_ID")]
        public int Id { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
