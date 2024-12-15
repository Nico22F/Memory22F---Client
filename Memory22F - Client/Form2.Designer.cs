namespace Memory22F___Client
{
    partial class Form2
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
            this.listBox_utenti_connessi = new System.Windows.Forms.ListBox();
            this.label_lista_utenti = new System.Windows.Forms.Label();
            this.button_PRONTO = new System.Windows.Forms.Button();
            this.listBox_chat = new System.Windows.Forms.ListBox();
            this.textBox_chat = new System.Windows.Forms.TextBox();
            this.label_chat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox_utenti_connessi
            // 
            this.listBox_utenti_connessi.FormattingEnabled = true;
            this.listBox_utenti_connessi.ItemHeight = 16;
            this.listBox_utenti_connessi.Location = new System.Drawing.Point(102, 60);
            this.listBox_utenti_connessi.Name = "listBox_utenti_connessi";
            this.listBox_utenti_connessi.Size = new System.Drawing.Size(592, 84);
            this.listBox_utenti_connessi.TabIndex = 0;
            // 
            // label_lista_utenti
            // 
            this.label_lista_utenti.AutoSize = true;
            this.label_lista_utenti.Location = new System.Drawing.Point(321, 22);
            this.label_lista_utenti.Name = "label_lista_utenti";
            this.label_lista_utenti.Size = new System.Drawing.Size(129, 16);
            this.label_lista_utenti.TabIndex = 1;
            this.label_lista_utenti.Text = "UTENTI CONNESSI";
            // 
            // button_PRONTO
            // 
            this.button_PRONTO.Location = new System.Drawing.Point(236, 164);
            this.button_PRONTO.Name = "button_PRONTO";
            this.button_PRONTO.Size = new System.Drawing.Size(295, 28);
            this.button_PRONTO.TabIndex = 2;
            this.button_PRONTO.Text = "PRONTO";
            this.button_PRONTO.UseVisualStyleBackColor = true;
            // 
            // listBox_chat
            // 
            this.listBox_chat.FormattingEnabled = true;
            this.listBox_chat.ItemHeight = 16;
            this.listBox_chat.Location = new System.Drawing.Point(222, 60);
            this.listBox_chat.Name = "listBox_chat";
            this.listBox_chat.Size = new System.Drawing.Size(332, 324);
            this.listBox_chat.TabIndex = 3;
            // 
            // textBox_chat
            // 
            this.textBox_chat.Location = new System.Drawing.Point(222, 397);
            this.textBox_chat.Name = "textBox_chat";
            this.textBox_chat.Size = new System.Drawing.Size(332, 22);
            this.textBox_chat.TabIndex = 4;
            this.textBox_chat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_chat_KeyPress);
            // 
            // label_chat
            // 
            this.label_chat.AutoSize = true;
            this.label_chat.Location = new System.Drawing.Point(358, 22);
            this.label_chat.Name = "label_chat";
            this.label_chat.Size = new System.Drawing.Size(47, 16);
            this.label_chat.TabIndex = 5;
            this.label_chat.Text = "CHAT:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_chat);
            this.Controls.Add(this.textBox_chat);
            this.Controls.Add(this.listBox_chat);
            this.Controls.Add(this.button_PRONTO);
            this.Controls.Add(this.label_lista_utenti);
            this.Controls.Add(this.listBox_utenti_connessi);
            this.Name = "Form2";
            this.Text = "Premi \"t\" per mostrare la chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form2_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_utenti_connessi;
        private System.Windows.Forms.Label label_lista_utenti;
        private System.Windows.Forms.Button button_PRONTO;
        private System.Windows.Forms.ListBox listBox_chat;
        private System.Windows.Forms.TextBox textBox_chat;
        private System.Windows.Forms.Label label_chat;
    }
}