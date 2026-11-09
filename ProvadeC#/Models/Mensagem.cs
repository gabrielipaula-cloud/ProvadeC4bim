using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvadeC_.Models
{
    [Table("mensagens", Schema = "public")]
    public class Mensagem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("usu_conv_id")] 
        public int UsuConvId { get; set; }

        [Column("texto")]
        public string Texto { get; set; } = "";

        [Column("data_hora", TypeName = "timestamp without time zone")]
        public DateTime DataHora { get; set; }

        [ForeignKey(nameof(UsuConvId))]
        public UsuarioConversa? UsuarioConversa { get; set; }

    }
}
