using ProvadeC_.Data;
using ProvadeC_.Models;
using ProvadeC_.Presenters;

namespace ProvadeC_
{
    public partial class FrmLogin : Form
    {
        Contexto db;
        UsuarioPresenter presenter;

        public FrmLogin()
        {
            InitializeComponent();
            db = new Contexto();
            presenter = new UsuarioPresenter(db);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string codigo = txtcod.Text.Trim();
            string pin = txtpin.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Informe o código.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcod.Focus();
                return;
            }

            if (codigo.Length > 15)
            {
                MessageBox.Show("O código pode ter no máximo 15 caracteres.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcod.Focus();
                return;
            }

            if (pin.Length != 4 || !pin.All(char.IsDigit))
            {
                MessageBox.Show("O PIN deve ter 4 números.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpin.Focus();
                return;
            }

            Usuario? usuario = presenter.Selecionar(codigo);

            if (usuario == null)
            {
                DialogResult r = MessageBox.Show($"O código {codigo} não existe. Deseja criar o usuário?",
                    "Novo usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r != DialogResult.Yes)
                {
                    return;
                }

                usuario = presenter.Cadastrar(codigo, pin);
                if (usuario == null)
                {
                    MessageBox.Show("Erro ao criar usuário!");
                    return;
                }
            }
            else if (!presenter.VerificarPin(usuario, pin))
            {
                MessageBox.Show("ERRO: PIN incorreto.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Hide();
            FrmListas f = new FrmListas(usuario);
            f.ShowDialog();
            Close();
        }
    }
}
