namespace ProvadeC_
{
    partial class FrmConversa
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
            label1 = new Label();
            btnSair = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            textBox1 = new TextBox();
            btnEnviar = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 35);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome da conversa";
            // 
            // btnSair
            // 
            btnSair.Location = new Point(220, 31);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(75, 23);
            btnSair.TabIndex = 1;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(31, 76);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Size = new Size(264, 229);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(31, 330);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "Novo texto para envio...";
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(220, 330);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(75, 23);
            btnEnviar.TabIndex = 4;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // FrmConversa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 384);
            Controls.Add(btnEnviar);
            Controls.Add(textBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnSair);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            Load += FrmConversa_Load;
            FormClosing += FrmConversa_FormClosing;
            AcceptButton = btnEnviar;
            Name = "FrmConversa";
            Text = "Conversa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSair;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBox1;
        private Button btnEnviar;
        private System.Windows.Forms.Timer timer1;
    }
}