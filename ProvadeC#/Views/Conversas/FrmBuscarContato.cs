using ProvadeC_.Models;
using ProvadeC_.Presenters;

namespace ProvadeC_
{
    public partial class FrmBuscarContato : Form
    {
        ContatoPresenter presenter;
        Usuario usuario;

        public Contato? Selecionado { get; private set; }

        public FrmBuscarContato(ContatoPresenter presenter, Usuario usuario)
        {
            InitializeComponent();
            this.presenter = presenter;
            this.usuario = usuario;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Add("nome", "NOME");
            dataGridView1.Columns.Add("codigo", "CÓDIGO");
        }

        private void FrmBuscarContato_Load(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void Atualizar()
        {
            List<Contato> lista = presenter.Buscar(usuario.Id, textBox1.Text.Trim());

            dataGridView1.Rows.Clear();
            foreach (Contato c in lista)
            {
                int linha = dataGridView1.Rows.Add(c.Nome, c.UsuarioContato?.Codigo ?? "");
                dataGridView1.Rows[linha].Tag = c;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione um contato.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Selecionado = (Contato)dataGridView1.CurrentRow.Tag!;
            Close();
        }
    }
}
