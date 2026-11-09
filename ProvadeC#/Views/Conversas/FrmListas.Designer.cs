namespace ProvadeC_
{
    partial class FrmListas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnContatos = new Button();
            btnConversa = new Button();
            flpConversas = new FlowLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnContatos
            // 
            btnContatos.Location = new Point(12, 23);
            btnContatos.Name = "btnContatos";
            btnContatos.Size = new Size(75, 23);
            btnContatos.TabIndex = 0;
            btnContatos.Text = "Contatos";
            btnContatos.UseVisualStyleBackColor = true;
            btnContatos.Click += btnContatos_Click;
            // 
            // btnConversa
            // 
            btnConversa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConversa.Location = new Point(133, 23);
            btnConversa.Name = "btnConversa";
            btnConversa.Size = new Size(117, 23);
            btnConversa.TabIndex = 1;
            btnConversa.Text = "Nova Conversa";
            btnConversa.UseVisualStyleBackColor = true;
            btnConversa.Click += btnConversa_Click;
            // 
            // flpConversas
            // 
            flpConversas.AutoScroll = true;
            flpConversas.FlowDirection = FlowDirection.TopDown;
            flpConversas.Location = new Point(12, 81);
            flpConversas.Name = "flpConversas";
            flpConversas.Size = new Size(238, 296);
            flpConversas.TabIndex = 2;
            flpConversas.WrapContents = false;
            flpConversas.Paint += flowLayoutPanel1_Paint;
            // 
            // FrmListas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 405);
            Controls.Add(btnContatos);
            Controls.Add(flpConversas);
            Controls.Add(btnConversa);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = 30000;
            timer1.Tick += timer1_Tick;
            Name = "FrmListas";
            Text = "C#at";
            Load += FrmListas_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnContatos;
        private Button btnConversa;
        private FlowLayoutPanel flpConversas;
        private System.Windows.Forms.Timer timer1;
    }
}