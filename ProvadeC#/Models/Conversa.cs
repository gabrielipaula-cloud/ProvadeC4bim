using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvadeC_.Models
{
    [Table("conversas", Schema = "public")]
    public class Conversa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; } = "";

        [Column("criado_por")]
        public int CriadoPor { get; set; }

        [Column("criado_em", TypeName = "timestamp without time zone")]
        public DateTime CriadoEm { get; set; }

        [ForeignKey(nameof(CriadoPor))]
        public Usuario? Criador { get; set; }
        public List<UsuarioConversa> Participantes { get; set; } = new List<UsuarioConversa>();

    }
}
