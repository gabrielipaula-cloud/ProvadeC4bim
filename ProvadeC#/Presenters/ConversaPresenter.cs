using Microsoft.EntityFrameworkCore;
using ProvadeC_.Data;
using ProvadeC_.Models;

namespace ProvadeC_.Presenters
{
    public class ConversaPresenter
    {
        Contexto db;

        public ConversaPresenter(Contexto db)
        {
            this.db = db;
        }

        public List<Conversa> Buscar(int usuarioId)
        {
            var conversas = db.UsuarioConversas
                .AsNoTracking()
                .Where(uc => uc.UsuarioId == usuarioId)
                .Select(uc => new
                {
                    Conversa = uc.Conversa!,
                    Ultima = db.Mensagens
                        .Where(m => m.UsuarioConversa!.ConversaId == uc.ConversaId)
                        .Max(m => (DateTime?)m.DataHora)
                })
                .ToList();

            return conversas
                .OrderByDescending(c => c.Ultima ?? c.Conversa.CriadoEm)
                .Select(c => c.Conversa)
                .ToList();
        }

        public Conversa? Selecionar(int id)
        {
            return db.Conversas
                .Include(c => c.Participantes)
                .FirstOrDefault(c => c.Id == id);
        }

        public Conversa? Criar(string titulo, int criadorId, List<int> participantesIds)
        {
            if (string.IsNullOrWhiteSpace(titulo) || participantesIds.Count == 0)
            {
                return null;
            }

            Conversa nova = new Conversa()
            {
                Titulo = titulo,
                CriadoPor = criadorId,
                CriadoEm = DateTime.Now
            };

            nova.Participantes.Add(new UsuarioConversa() { UsuarioId = criadorId });
            foreach (int id in participantesIds.Distinct())
            {
                if (id != criadorId)
                {
                    nova.Participantes.Add(new UsuarioConversa() { UsuarioId = id });
                }
            }

            db.Conversas.Add(nova);
            if (Salvar())
            {
                return nova;
            }
            return null;
        }

        public bool Apagar(int conversaId, int usuarioId)
        {
            Conversa? conversa = db.Conversas
                .Include(c => c.Participantes)
                .ThenInclude(p => p.Mensagens)
                .FirstOrDefault(c => c.Id == conversaId);
            if (conversa == null)
            {
                return false;
            }

            List<UsuarioConversa> participacoes;
            if (conversa.CriadoPor == usuarioId)
            {
                participacoes = conversa.Participantes.ToList();
            }
            else
            {
                participacoes = conversa.Participantes.Where(p => p.UsuarioId == usuarioId).ToList();
            }

            foreach (UsuarioConversa p in participacoes)
            {
                db.Mensagens.RemoveRange(p.Mensagens);
                db.UsuarioConversas.Remove(p);
            }

            if (conversa.CriadoPor == usuarioId)
            {
                db.Conversas.Remove(conversa);
            }

            return Salvar();
        }

        public UsuarioConversa? Participacao(int conversaId, int usuarioId)
        {
            return db.UsuarioConversas
                .AsNoTracking()
                .FirstOrDefault(uc => uc.ConversaId == conversaId && uc.UsuarioId == usuarioId);
        }

        public List<Mensagem> BuscarMensagens(int conversaId, int depoisDoId)
        {
            return db.Mensagens
                .AsNoTracking()
                .Include(m => m.UsuarioConversa)
                .ThenInclude(uc => uc!.Usuario)
                .Where(m => m.UsuarioConversa!.ConversaId == conversaId && m.Id > depoisDoId)
                .OrderBy(m => m.Id)
                .ToList();
        }

        public Dictionary<int, string> Apelidos(int usuarioId)
        {
            return db.Contatos
                .AsNoTracking()
                .Where(c => c.UsuarioId == usuarioId)
                .ToList()
                .GroupBy(c => c.ContatoId)
                .ToDictionary(g => g.Key, g => g.First().Nome);
        }

        public bool Enviar(int usuConvId, string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }

            bool ativo = db.UsuarioConversas.Any(uc => uc.Id == usuConvId && uc.SaiuEm == null);
            if (!ativo)
            {
                return false;
            }

            Mensagem nova = new Mensagem()
            {
                UsuConvId = usuConvId,
                Texto = texto,
                DataHora = DateTime.Now
            };

            db.Mensagens.Add(nova);
            return Salvar();
        }

        public bool Sair(int usuConvId)
        {
            UsuarioConversa? participacao = db.UsuarioConversas.FirstOrDefault(uc => uc.Id == usuConvId);
            if (participacao == null)
            {
                return false;
            }

            participacao.SaiuEm = DateTime.Now;
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
