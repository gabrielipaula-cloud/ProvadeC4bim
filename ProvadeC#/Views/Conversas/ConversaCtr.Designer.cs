namespace ProvadeC_
{
    partial class ConversaCtr
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
            btnVer = new Button();
            btnApagar = new Button();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(6, 16);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(38, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "label1";
            lblNome.Click += label1_Click;
            // 
            // btnVer
            // 
            btnVer.Location = new Point(92, 12);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(55, 23);
            btnVer.TabIndex = 1;
            btnVer.Text = "Ver";
            btnVer.UseVisualStyleBackColor = true;
            btnVer.Click += btnVer_Click;
            // 
            // btnApagar
            // 
            btnApagar.Location = new Point(150, 12);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(60, 23);
            btnApagar.TabIndex = 2;
            btnApagar.Text = "Apagar";
            btnApagar.UseVisualStyleBackColor = true;
            btnApagar.Click += btnApagar_Click;
            // 
            // ConversaCtr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnApagar);
            Controls.Add(btnVer);
            Controls.Add(lblNome);
            BackColor = Color.White;
            Name = "ConversaCtr";
            Size = new Size(215, 48);
            Load += ConversaCtr_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Button btnVer;
        private Button btnApagar;
    }
}
