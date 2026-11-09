using Microsoft.EntityFrameworkCore;
using ProvadeC_.Data;
using ProvadeC_.Models;

namespace ProvadeC_.Presenters
{
    public class ContatoPresenter
    {
        Contexto db;

        public ContatoPresenter(Contexto db)
        {
            this.db = db;
        }

        public List<Contato> Buscar(int usuarioId, string nome)
        {
            return db.Contatos
                .AsNoTracking()
                .Include(c => c.UsuarioContato)
                .Where(c => c.UsuarioId == usuarioId)
                .Where(c => c.Nome.ToUpper().Contains(nome.ToUpper()))
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public Contato? Selecionar(int id)
        {
            return db.Contatos
                .Include(c => c.UsuarioContato)
                .FirstOrDefault(c => c.Id == id);
        }

        public Usuario? SelecionarUsuario(string codigo)
        {
            return db.Usuarios.FirstOrDefault(u => u.Codigo == codigo);
        }

        public bool JaCadastrado(int usuarioId, int contatoId, int idIgnorado)
        {
            return db.Contatos.Any(c => c.UsuarioId == usuarioId
                                     && c.ContatoId == contatoId
                                     && c.Id != idIgnorado);
        }

        public bool Cadastrar(Contato contato)
        {
            if (string.IsNullOrWhiteSpace(contato.Nome))
            {
                return false;
            }

            db.Contatos.Add(contato);
            return Salvar();
        }

        public bool Editar(Contato contato)
        {
            if (string.IsNullOrWhiteSpace(contato.Nome))
            {
                return false;
            }

            Contato? contatoAtual = Selecionar(contato.Id);
            if (contatoAtual == null)
            {
                return false;
            }

            contatoAtual.Nome = contato.Nome;
            contatoAtual.ContatoId = contato.ContatoId;
            return Salvar();
        }

        public bool Remover(Contato contato)
        {
            Contato? contatoAtual = Selecionar(contato.Id);
            if (contatoAtual == null)
            {
                return false;
            }

            db.Contatos.Remove(contatoAtual);
            return Salvar();
        }

        private bool Salvar()
        {
            try
            {
                return db.SaveChanges() > 0;
            }
            catch
            {
                db.ChangeTracker.Clear();
                return false;
            }
        }
    }
}
