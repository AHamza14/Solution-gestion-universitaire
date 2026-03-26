namespace SolutionGestionUniversitaire.WindowsApp
{
    partial class AjouterProfForm
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
            btnAjouter = new Button();
            label1 = new Label();
            label2 = new Label();
            txtBoxNom = new TextBox();
            txtBoxDepartement = new TextBox();
            SuspendLayout();
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(341, 280);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(112, 34);
            btnAjouter.TabIndex = 0;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 146);
            label1.Name = "label1";
            label1.Size = new Size(56, 25);
            label1.TabIndex = 1;
            label1.Text = "Nom:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(240, 207);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 2;
            label2.Text = "Departement:";
            // 
            // txtBoxNom
            // 
            txtBoxNom.Location = new Point(393, 146);
            txtBoxNom.Name = "txtBoxNom";
            txtBoxNom.Size = new Size(150, 31);
            txtBoxNom.TabIndex = 3;
            // 
            // txtBoxDepartement
            // 
            txtBoxDepartement.Location = new Point(393, 207);
            txtBoxDepartement.Name = "txtBoxDepartement";
            txtBoxDepartement.Size = new Size(150, 31);
            txtBoxDepartement.TabIndex = 4;
            // 
            // AjouterProfForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBoxDepartement);
            Controls.Add(txtBoxNom);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAjouter);
            Name = "AjouterProfForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAjouter;
        private Label label1;
        private Label label2;
        private TextBox txtBoxNom;
        private TextBox txtBoxDepartement;
    }
}
