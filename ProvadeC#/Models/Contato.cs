using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvadeC_.Models
{
    [Table("contatos", Schema = "public")]
    public class Contato
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("contato_id")]
        public int ContatoId { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = "";

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [ForeignKey(nameof(ContatoId))]

        public Usuario? UsuarioContato { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        public Usuario? Dono { get; set; }

    }
}