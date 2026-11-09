namespace ProvadeC_
{
    partial class MensagemCtr
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNome = new Label();
            lblDia = new Label();
            lblHora = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(4, 6);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(38, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "label1";
            lblNome.Click += label1_Click;
            // 
            // lblDia
            // 
            lblDia.AutoSize = true;
            lblDia.Location = new Point(4, 24);
            lblDia.Name = "lblDia";
            lblDia.Size = new Size(38, 15);
            lblDia.TabIndex = 1;
            lblDia.Text = "label2";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(4, 42);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(38, 15);
            lblHora.TabIndex = 2;
            lblHora.Text = "label3";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(78, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(156, 60);
            textBox1.TabIndex = 3;
            textBox1.Multiline = true;
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            // 
            // MensagemCtr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox1);
            Controls.Add(lblHora);
            Controls.Add(lblDia);
            Controls.Add(lblNome);
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Name = "MensagemCtr";
            Size = new Size(240, 70);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblDia;
        private Label lblHora;
        private TextBox textBox1;
    }
}
