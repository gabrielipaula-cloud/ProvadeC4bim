using Microsoft.EntityFrameworkCore;
using ProvadeC_.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvadeC_.Data
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(
                "Host=projetoscti.com.br;" +
                "Port=54432;" +
                "Database=cti_db;" +
                "Username=" + Credenciais.Usuario + ";" +
                "Password=" + Credenciais.Senha + ";"
                );
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Conversa> Conversas { get; set; }
        public DbSet<UsuarioConversa> UsuarioConversas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
    }
}

