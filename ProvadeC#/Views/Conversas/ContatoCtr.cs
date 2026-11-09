using ProvadeC_.Models;

namespace ProvadeC_
{
    public partial class ContatoCtr : UserControl
    {
        FrmCriar form;
        Contato contato;

        public ContatoCtr(FrmCriar form, Contato contato)
        {
            InitializeComponent();
            this.form = form;
            this.contato = contato;

            lblNome.Text = contato.Nome;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            form.RemoverContato(this, contato);
        }
    }
}
