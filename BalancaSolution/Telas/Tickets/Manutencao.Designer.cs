namespace BalancaSolution.Telas.Tickets
{
    partial class Manutencao
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_manut = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ticket = new System.Windows.Forms.ComboBox();
            this.btn_aplicar = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de manutenção:";
            // 
            // cb_manut
            // 
            this.cb_manut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_manut.FormattingEnabled = true;
            this.cb_manut.Location = new System.Drawing.Point(38, 30);
            this.cb_manut.Name = "cb_manut";
            this.cb_manut.Size = new System.Drawing.Size(542, 21);
            this.cb_manut.TabIndex = 0;
            this.cb_manut.SelectedIndexChanged += new System.EventHandler(this.cb_manut_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ticket:";
            // 
            // cb_ticket
            // 
            this.cb_ticket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ticket.FormattingEnabled = true;
            this.cb_ticket.Location = new System.Drawing.Point(38, 87);
            this.cb_ticket.Name = "cb_ticket";
            this.cb_ticket.Size = new System.Drawing.Size(380, 21);
            this.cb_ticket.TabIndex = 1;
            // 
            // btn_aplicar
            // 
            this.btn_aplicar.Image = global::BalancaSolution.Properties.Resources.ok_x16;
            this.btn_aplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aplicar.Location = new System.Drawing.Point(424, 85);
            this.btn_aplicar.Name = "btn_aplicar";
            this.btn_aplicar.Size = new System.Drawing.Size(75, 23);
            this.btn_aplicar.TabIndex = 2;
            this.btn_aplicar.Text = "Aplicar";
            this.btn_aplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aplicar.UseVisualStyleBackColor = true;
            this.btn_aplicar.Click += new System.EventHandler(this.btn_aplicar_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_fechar.Image = global::BalancaSolution.Properties.Resources.close_x16;
            this.btn_fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_fechar.Location = new System.Drawing.Point(505, 85);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(75, 23);
            this.btn_fechar.TabIndex = 3;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // Manutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_fechar;
            this.ClientSize = new System.Drawing.Size(590, 129);
            this.Controls.Add(this.btn_fechar);
            this.Controls.Add(this.btn_aplicar);
            this.Controls.Add(this.cb_ticket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_manut);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Manutencao";
            this.Text = "Manutencao";
            this.Load += new System.EventHandler(this.Manutencao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Manutencao_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_manut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ticket;
        private System.Windows.Forms.Button btn_aplicar;
        private System.Windows.Forms.Button btn_fechar;
    }
}