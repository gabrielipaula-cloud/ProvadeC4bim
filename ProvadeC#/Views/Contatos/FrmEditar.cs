using ProvadeC_.Models;
using ProvadeC_.Presenters;

namespace ProvadeC_
{
    public partial class FrmEditar : Form
    {
        ContatoPresenter presenter;
        Usuario usuario;
        Contato contato;

        public FrmEditar(ContatoPresenter presenter, Usuario usuario, Contato contato)
        {
            InitializeComponent();
            this.presenter = presenter;
            this.usuario = usuario;
            this.contato = contato;

            txtNome.Text = contato.Nome;
            txtCodigo.Text = contato.UsuarioContato?.Codigo ?? "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (presenter.Selecionar(contato.Id) == null)
            {
                MessageBox.Show("O contato não existe mais.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

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

            if (presenter.JaCadastrado(usuario.Id, pessoa.Id, contato.Id))
            {
                MessageBox.Show("Esse usuário já está nos seus contatos.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            contato.Nome = nome;
            contato.ContatoId = pessoa.Id;

            if (presenter.Editar(contato))
            {
                MessageBox.Show("Contato editado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Erro ao editar contato!");
            }
        }
    }
}
