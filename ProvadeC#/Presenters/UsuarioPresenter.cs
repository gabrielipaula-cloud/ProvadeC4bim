using ProvadeC_.Data;
using ProvadeC_.Models;

namespace ProvadeC_.Presenters
{
    public class UsuarioPresenter
    {
        Contexto db;

        public UsuarioPresenter(Contexto db)
        {
            this.db = db;
        }

        public Usuario? Selecionar(string codigo)
        {
            return db.Usuarios.FirstOrDefault(u => u.Codigo == codigo);
        }

        public bool VerificarPin(Usuario usuario, string pin)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(pin, usuario.Pin);
            }
            catch
            {
                return false;
            }
        }

        public Usuario? Cadastrar(string codigo, string pin)
        {
            Usuario novo = new Usuario()
            {
                Codigo = codigo,
                Pin = BCrypt.Net.BCrypt.HashPassword(pin)
            };

            db.Usuarios.Add(novo);
            try
            {
                db.SaveChanges();
                return novo;
            }
            catch
            {
                db.ChangeTracker.Clear();
                return null;
            }
        }
    }
}
