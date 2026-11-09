using ProvadeC_.Models;
using ProvadeC_.Presenters;

namespace ProvadeC_
{
    public partial class FrmCadastrar : Form
    {
        ContatoPresenter presenter;
        Usuario usuario;

        public FrmCadastrar(ContatoPresenter presenter, Usuario usuario)
        {
            InitializeComponent();
            this.presenter = presenter;
            this.usuario = usuario;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string codigo = txtCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Informe o nome e o código do contato.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            Usuario? pessoa = presenter.SelecionarUsuario(codigo);
            if (pessoa == null)
            {
                MessageBox.Show($"Não existe usuário com o código {codigo}.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (pessoa.Id == usuario.Id)
            {
                MessageBox.Show("Você não pode se adicionar como contato.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (presenter.JaCadastrado(usuario.Id, pessoa.Id, 0))
            {
                MessageBox.Show("Esse usuário já está nos seus contatos.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            Contato novo = new Contato()
            {
                Nome = nome,
                ContatoId = pessoa.Id,
                UsuarioId = usuario.Id
            };

            if (presenter.Cadastrar(novo))
            {
                MessageBox.Show("Contato cadastrado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar contato!");
            }
        }
    }
}
