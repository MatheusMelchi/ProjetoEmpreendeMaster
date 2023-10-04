using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEmpreendeMaster.Models
{
    public class Usuario
    {
        [Column("USUARIO_ID")]
        public int Id { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("SENHA")]
        public string Senha { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("TIPO_USUARIO")]
        public int TipoUsuarioId { get; set; }

        [Column("NOME_COMPLETO")]
        public string NomeCompleto { get; set; }
        public int Idade { get
            {
                if (this.DataNascimento == new DateTime(0001,01,01))
                    return 0;
                return (DateTime.Now - this.DataNascimento).Days / 365;
            } }
    }
}
