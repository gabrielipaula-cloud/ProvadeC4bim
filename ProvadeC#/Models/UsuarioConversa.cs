using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvadeC_.Models
{
    [Table("usuario_conversas", Schema = "public")]
    public class UsuarioConversa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("conversa_id")]
        public int ConversaId { get; set; }

        [Column("saiu_em", TypeName = "timestamp without time zone")]
        public DateTime? SaiuEm { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuario? Usuario { get; set; }

        [ForeignKey(nameof(ConversaId))]
        public Conversa? Conversa { get; set; }

        public List<Mensagem> Mensagens { get; set; } = new List<Mensagem>();

    }
}
