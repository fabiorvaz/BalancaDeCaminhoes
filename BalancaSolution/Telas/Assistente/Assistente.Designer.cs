namespace BalancaSolution.Telas.Assistente
{
    partial class Assistente
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
            this.btn_nova_pesagem = new System.Windows.Forms.Button();
            this.btn_aberto = new System.Windows.Forms.Button();
            this.btn_manutencao_ticket = new System.Windows.Forms.Button();
            this.btn_sair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_nova_pesagem
            // 
            this.btn_nova_pesagem.Image = global::BalancaSolution.Properties.Resources.Truck_x64;
            this.btn_nova_pesagem.Location = new System.Drawing.Point(15, 22);
            this.btn_nova_pesagem.Name = "btn_nova_pesagem";
            this.btn_nova_pesagem.Size = new System.Drawing.Size(110, 104);
            this.btn_nova_pesagem.TabIndex = 0;
            this.btn_nova_pesagem.Text = "Nova pesagem";
            this.btn_nova_pesagem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_nova_pesagem.UseVisualStyleBackColor = true;
            this.btn_nova_pesagem.Click += new System.EventHandler(this.btn_nova_pesagem_Click);
            // 
            // btn_aberto
            // 
            this.btn_aberto.Image = global::BalancaSolution.Properties.Resources.open_box_x64;
            this.btn_aberto.Location = new System.Drawing.Point(163, 22);
            this.btn_aberto.Name = "btn_aberto";
            this.btn_aberto.Size = new System.Drawing.Size(110, 104);
            this.btn_aberto.TabIndex = 1;
            this.btn_aberto.Text = "Tickets em aberto";
            this.btn_aberto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_aberto.UseVisualStyleBackColor = true;
            this.btn_aberto.Click += new System.EventHandler(this.btn_aberto_Click);
            // 
            // btn_manutencao_ticket
            // 
            this.btn_manutencao_ticket.Image = global::BalancaSolution.Properties.Resources.fix_x64;
            this.btn_manutencao_ticket.Location = new System.Drawing.Point(306, 22);
            this.btn_manutencao_ticket.Name = "btn_manutencao_ticket";
            this.btn_manutencao_ticket.Size = new System.Drawing.Size(110, 104);
            this.btn_manutencao_ticket.TabIndex = 2;
            this.btn_manutencao_ticket.Text = "Manutenção de tickets";
            this.btn_manutencao_ticket.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_manutencao_ticket.UseVisualStyleBackColor = true;
            this.btn_manutencao_ticket.Click += new System.EventHandler(this.btn_manutencao_ticket_Click);
            // 
            // btn_sair
            // 
            this.btn_sair.Image = global::BalancaSolution.Properties.Resources.Sair_x64;
            this.btn_sair.Location = new System.Drawing.Point(451, 22);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(110, 104);
            this.btn_sair.TabIndex = 3;
            this.btn_sair.Text = "Sair";
            this.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_sair.UseVisualStyleBackColor = true;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // Assistente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 138);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_manutencao_ticket);
            this.Controls.Add(this.btn_aberto);
            this.Controls.Add(this.btn_nova_pesagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Assistente";
            this.ShowIcon = false;
            this.Text = "Assistente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_nova_pesagem;
        private System.Windows.Forms.Button btn_aberto;
        private System.Windows.Forms.Button btn_manutencao_ticket;
        private System.Windows.Forms.Button btn_sair;
    }
}