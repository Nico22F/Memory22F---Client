namespace Memory22F___Client
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_nome = new System.Windows.Forms.Label();
            this.button_accedi = new System.Windows.Forms.Button();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_nome
            // 
            this.label_nome.AutoSize = true;
            this.label_nome.Location = new System.Drawing.Point(239, 136);
            this.label_nome.Name = "label_nome";
            this.label_nome.Size = new System.Drawing.Size(304, 16);
            this.label_nome.TabIndex = 0;
            this.label_nome.Text = "INSERISCI IL TUO NOME PER POTER GIOCARE";
            // 
            // button_accedi
            // 
            this.button_accedi.Location = new System.Drawing.Point(315, 218);
            this.button_accedi.Name = "button_accedi";
            this.button_accedi.Size = new System.Drawing.Size(143, 36);
            this.button_accedi.TabIndex = 1;
            this.button_accedi.Text = "Accedi al gioco";
            this.button_accedi.UseVisualStyleBackColor = true;
            this.button_accedi.Click += new System.EventHandler(this.button_accedi_Click);
            // 
            // textBox_nome
            // 
            this.textBox_nome.Location = new System.Drawing.Point(281, 177);
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.Size = new System.Drawing.Size(206, 22);
            this.textBox_nome.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.button_accedi);
            this.Controls.Add(this.label_nome);
            this.Name = "Form1";
            this.Text = "Memory22F - Menù";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nome;
        private System.Windows.Forms.Button button_accedi;
        private System.Windows.Forms.TextBox textBox_nome;
    }
}

