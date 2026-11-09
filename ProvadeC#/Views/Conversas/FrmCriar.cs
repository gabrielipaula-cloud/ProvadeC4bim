using ProvadeC_.Data;
using ProvadeC_.Models;
using ProvadeC_.Presenters;

namespace ProvadeC_
{
    public partial class FrmCriar : Form
    {
        Contexto db;
        ConversaPresenter presenter;
        Usuario usuario;
        List<Contato> selecionados = new List<Contato>();

        public Conversa? ConversaCriada { get; private set; }

        public FrmCriar(Contexto db, ConversaPresenter presenter, Usuario usuario)
        {
            InitializeComponent();
            this.db = db;
            this.presenter = presenter;
            this.usuario = usuario;
        }

        private void btnAddContato_Click(object sender, EventArgs e)
        {
            FrmBuscarContato f = new FrmBuscarContato(new ContatoPresenter(db), usuario);
            f.ShowDialog();

            Contato? contato = f.Selecionado;
            if (contato == null)
            {
                return;
            }

            if (selecionados.Any(c => c.ContatoId == contato.ContatoId))
            {
                MessageBox.Show("Esse contato já foi adicionado.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selecionados.Add(contato);
            flowLayoutPanel1.Controls.Add(new ContatoCtr(this, contato));
        }

        public void RemoverContato(ContatoCtr ctr, Contato contato)
        {
            selecionados.Remove(contato);
            flowLayoutPanel1.Controls.Remove(ctr);
            ctr.Dispose();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                MessageBox.Show("Informe o nome da conversa.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (selecionados.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um contato.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<int> ids = selecionados.Select(c => c.ContatoId).ToList();
            ConversaCriada = presenter.Criar(titulo, usuario.Id, ids);

            if (ConversaCriada != null)
            {
                Close();
            }
            else
            {
                MessageBox.Show("Erro ao criar conversa!");
            }
        }
    }
}
