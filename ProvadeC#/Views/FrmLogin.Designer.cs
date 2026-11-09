namespace ProvadeC_
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtcod = new TextBox();
            txtpin = new TextBox();
            btnEntrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 63);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Código:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 106);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 1;
            label2.Text = "PIN:";
            // 
            // txtcod
            // 
            txtcod.Location = new Point(87, 55);
            txtcod.Name = "txtcod";
            txtcod.Size = new Size(138, 23);
            txtcod.MaxLength = 15;
            txtcod.TabIndex = 2;
            // 
            // txtpin
            // 
            txtpin.Location = new Point(87, 98);
            txtpin.Name = "txtpin";
            txtpin.Size = new Size(138, 23);
            txtpin.PasswordChar = '*';
            txtpin.MaxLength = 4;
            txtpin.TabIndex = 3;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(71, 143);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(117, 23);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 207);
            Controls.Add(btnEntrar);
            Controls.Add(txtpin);
            Controls.Add(txtcod);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "FrmLogin";
            Text = "C#at - Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtcod;
        private TextBox txtpin;
        private Button btnEntrar;
    }
}
