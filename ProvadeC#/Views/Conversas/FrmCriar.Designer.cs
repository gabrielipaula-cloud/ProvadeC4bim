namespace ProvadeC_
{
    partial class FrmCriar
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
            label1 = new Label();
            textBox1 = new TextBox();
            btnAddContato = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCriar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 34);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(84, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // btnAddContato
            // 
            btnAddContato.Location = new Point(39, 80);
            btnAddContato.Name = "btnAddContato";
            btnAddContato.Size = new Size(125, 23);
            btnAddContato.TabIndex = 2;
            btnAddContato.Text = "Adicionar Contato";
            btnAddContato.UseVisualStyleBackColor = true;
            btnAddContato.Click += btnAddContato_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(12, 136);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Size = new Size(172, 203);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // btnCriar
            // 
            btnCriar.Location = new Point(59, 355);
            btnCriar.Name = "btnCriar";
            btnCriar.Size = new Size(75, 23);
            btnCriar.TabIndex = 4;
            btnCriar.Text = "Criar";
            btnCriar.UseVisualStyleBackColor = true;
            btnCriar.Click += btnCriar_Click;
            // 
            // FrmCriar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(211, 390);
            Controls.Add(btnCriar);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnAddContato);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "FrmCriar";
            Text = "Nova conversa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button btnAddContato;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCriar;
    }
}