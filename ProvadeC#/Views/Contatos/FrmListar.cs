using ProvadeC_.Data;
using ProvadeC_.Models;
using ProvadeC_.Presenters;

namespace ProvadeC_
{
    public partial class FrmListar : Form
    {
        Contexto db;
        ContatoPresenter presenter;
        Usuario usuario;

        public FrmListar(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            db = new Contexto();
            presenter = new ContatoPresenter(db);

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Add("nome", "NOME");
            dataGridView1.Columns.Add("codigo", "CÓDIGO");
        }

        private void FrmListar_Load(object sender, EventArgs e)
        {
            Atualizar();
        }

        public void Atualizar()
        {
            List<Contato> lista = presenter.Buscar(usuario.Id, txtNome.Text.Trim());

            dataGridView1.Rows.Clear();
            foreach (Contato c in lista)
            {
                int linha = dataGridView1.Rows.Add(c.Nome, c.UsuarioContato?.Codigo ?? "");
                dataGridView1.Rows[linha].Tag = c;
            }
        }

        private Contato? ContatoSelecionado()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione um contato.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            Contato contato = (Contato)dataGridView1.CurrentRow.Tag!;
            Contato? contatoAtual = presenter.Selecionar(contato.Id);
            if (contatoAtual == null)
            {
                MessageBox.Show("O contato não existe mais.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Atualizar();
            }
            return contatoAtual;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FrmCadastrar f = new FrmCadastrar(presenter, usuario);
            f.ShowDialog();
            Atualizar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Contato? contato = ContatoSelecionado();
            if (contato == null)
            {
                return;
            }

            FrmEditar f = new FrmEditar(presenter, usuario, contato);
            f.ShowDialog();
            Atualizar();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Contato? contato = ContatoSelecionado();
            if (contato == null)
            {
                return;
            }

            DialogResult r = MessageBox.Show($"Deseja realmente remover {contato.Nome}?",
                "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes)
            {
                return;
            }

            if (presenter.Remover(contato))
            {
                MessageBox.Show("Contato removido com sucesso!");
                Atualizar();
            }
            else
            {
                MessageBox.Show("Erro ao remover contato!");
            }
        }
    }
}
