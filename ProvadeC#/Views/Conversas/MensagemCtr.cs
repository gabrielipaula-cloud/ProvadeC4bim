using ProvadeC_.Models;

namespace ProvadeC_
{
    public partial class MensagemCtr : UserControl
    {
        public MensagemCtr(Mensagem mensagem, string nome, bool minha)
        {
            InitializeComponent();

            lblNome.Text = nome + ":";
            lblDia.Text = mensagem.DataHora.ToString("dd/MM/yyyy");
            lblHora.Text = mensagem.DataHora.ToString("HH:mm");
            textBox1.Text = mensagem.Texto;

            if (minha)
            {
                BackColor = Color.FromArgb(220, 248, 198);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
