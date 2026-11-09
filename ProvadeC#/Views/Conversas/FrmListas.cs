using ProvadeC_.Data;
using ProvadeC_.Models;
using ProvadeC_.Presenters;

namespace ProvadeC_
{
    public partial class FrmListas : Form
    {
        Contexto db;
        ConversaPresenter presenter;
        Usuario usuario;

        public FrmListas(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            db = new Contexto();
            presenter = new ConversaPresenter(db);
            Text = $"C#at - {usuario.Codigo}";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmListas_Load(object sender, EventArgs e)
        {
            Atualizar();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Atualizar();
        }

        public void Atualizar()
        {
            List<Conversa> lista;
            try
            {
                lista = presenter.Buscar(usuario.Id);
            }
            catch
            {
                Text = $"C#at - {usuario.Codigo} (sem conexão)";
                return;
            }
            Text = $"C#at - {usuario.Codigo}";

            flpConversas.SuspendLayout();
            flpConversas.Controls.Clear();
            foreach (Conversa c in lista)
            {
                ConversaCtr ctr = new ConversaCtr(this, presenter, c, usuario);
                flpConversas.Controls.Add(ctr);
            }
            flpConversas.ResumeLayout();
        }

        public void AbrirConversa(Conversa conversa)
        {
            timer1.Stop();
            FrmConversa f = new FrmConversa(presenter, conversa, usuario);
            f.ShowDialog();
            Atualizar();
            timer1.Start();
        }

        private void btnContatos_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            FrmListar f = new FrmListar(usuario);
            f.ShowDialog();
            timer1.Start();
        }

        private void btnConversa_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            FrmCriar f = new FrmCriar(db, presenter, usuario);
            f.ShowDialog();
            timer1.Start();

            if (f.ConversaCriada != null)
            {
                AbrirConversa(f.ConversaCriada);
            }
            else
            {
                Atualizar();
            }
        }
    }
}
