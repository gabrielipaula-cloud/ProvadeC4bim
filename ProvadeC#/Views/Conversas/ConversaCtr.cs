using ProvadeC_.Models;
using ProvadeC_.Presenters;

namespace ProvadeC_
{
    public partial class ConversaCtr : UserControl
    {
        FrmListas grid;
        ConversaPresenter presenter;
        Conversa conversa;
        Usuario usuario;

        public ConversaCtr(FrmListas grid, ConversaPresenter presenter, Conversa conversa, Usuario usuario)
        {
            InitializeComponent();
            this.grid = grid;
            this.presenter = presenter;
            this.conversa = conversa;
            this.usuario = usuario;

            lblNome.Text = conversa.Titulo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConversaCtr_Load(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (presenter.Participacao(conversa.Id, usuario.Id) == null)
            {
                MessageBox.Show("A conversa não existe mais.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                grid.Atualizar();
                return;
            }

            grid.AbrirConversa(conversa);
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            string aviso = conversa.CriadoPor == usuario.Id
                ? $"Deseja apagar a conversa {conversa.Titulo} para todos?"
                : $"Deseja apagar a conversa {conversa.Titulo}? Você sairá dela.";

            DialogResult r = MessageBox.Show(aviso, "Apagar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes)
            {
                return;
            }

            if (presenter.Apagar(conversa.Id, usuario.Id))
            {
                MessageBox.Show("Conversa apagada com sucesso!");
            }
            else
            {
                MessageBox.Show("A conversa não existe mais.");
            }
            grid.Atualizar();
        }
    }
}
