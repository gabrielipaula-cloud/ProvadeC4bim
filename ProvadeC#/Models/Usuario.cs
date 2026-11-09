using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvadeC_.Models
{
    [Table("usuarios", Schema ="public")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("codigo")]
        public string Codigo { get; set; } = "";

        [Column("pin")]
        public string Pin { get; set; } = "";

    }
}
