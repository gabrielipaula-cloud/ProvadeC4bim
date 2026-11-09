using ProvadeC_.Models;
using ProvadeC_.Presenters;

namespace ProvadeC_
{
    public partial class FrmConversa : Form
    {
        ConversaPresenter presenter;
        Conversa conversa;
        Usuario usuario;
        UsuarioConversa? participacao;
        Dictionary<int, string> apelidos;
        int ultimaMensagemId = 0;

        public FrmConversa(ConversaPresenter presenter, Conversa conversa, Usuario usuario)
        {
            InitializeComponent();
            this.presenter = presenter;
            this.conversa = conversa;
            this.usuario = usuario;

            label1.Text = conversa.Titulo;
            Text = $"C#at - {conversa.Titulo}";
            textBox1.Text = "";
            textBox1.PlaceholderText = "Novo texto para envio...";

            apelidos = presenter.Apelidos(usuario.Id);
            participacao = presenter.Participacao(conversa.Id, usuario.Id);
        }

        private void FrmConversa_Load(object sender, EventArgs e)
        {
            if (participacao == null || participacao.SaiuEm != null)
            {
                BloquearEnvio();
            }

            CarregarMensagens();
            timer1.Start();
        }

        private void FrmConversa_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                CarregarMensagens();
                Text = $"C#at - {conversa.Titulo}";
            }
            catch
            {
                Text = $"C#at - {conversa.Titulo} (sem conexão)";
            }
            timer1.Start();
        }

        private void CarregarMensagens()
        {
            List<Mensagem> novas = presenter.BuscarMensagens(conversa.Id, ultimaMensagemId);
            if (novas.Count == 0)
            {
                return;
            }

            foreach (Mensagem m in novas)
            {
                int remetenteId = m.UsuarioConversa!.UsuarioId;
                string nome;
                if (remetenteId == usuario.Id)
                {
                    nome = "Você";
                }
                else if (apelidos.ContainsKey(remetenteId))
                {
                    nome = apelidos[remetenteId];
                }
                else
                {
                    nome = m.UsuarioConversa.Usuario!.Codigo;
                }

                flowLayoutPanel1.Controls.Add(new MensagemCtr(m, nome, remetenteId == usuario.Id));
                ultimaMensagemId = m.Id;
            }

            flowLayoutPanel1.ScrollControlIntoView(flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1]);
        }

        private void BloquearEnvio()
        {
            textBox1.Enabled = false;
            btnEnviar.Enabled = false;
            btnSair.Enabled = false;
            textBox1.PlaceholderText = "Você saiu desta conversa";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string texto = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(texto))
            {
                return;
            }

            if (participacao == null || participacao.SaiuEm != null)
            {
                MessageBox.Show("Você saiu desta conversa e não pode mais enviar mensagens.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (presenter.Enviar(participacao.Id, texto))
            {
                textBox1.Clear();
                textBox1.Focus();
                CarregarMensagens();
            }
            else
            {
                MessageBox.Show("Erro ao enviar mensagem! Verifique a conexão ou se você ainda está na conversa.");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (participacao == null || participacao.SaiuEm != null)
            {
                return;
            }

            DialogResult r = MessageBox.Show("Deseja sair desta conversa? Você não poderá mais enviar mensagens.",
                "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes)
            {
                return;
            }

            if (presenter.Sair(participacao.Id))
            {
                participacao.SaiuEm = DateTime.Now;
                BloquearEnvio();
            }
            else
            {
                MessageBox.Show("Erro ao sair da conversa!");
            }
        }
    }
}
