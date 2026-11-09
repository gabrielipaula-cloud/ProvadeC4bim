namespace ProvadeC_
{
    partial class ContatoCtr
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
            btnApagar = new Button();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(6, 14);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(38, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "label1";
            // 
            // btnApagar
            // 
            btnApagar.Location = new Point(92, 9);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(60, 23);
            btnApagar.TabIndex = 1;
            btnApagar.Text = "Apagar";
            btnApagar.UseVisualStyleBackColor = true;
            btnApagar.Click += btnApagar_Click;
            // 
            // ContatoCtr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnApagar);
            Controls.Add(lblNome);
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Name = "ContatoCtr";
            Size = new Size(160, 44);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Button btnApagar;
    }
}
