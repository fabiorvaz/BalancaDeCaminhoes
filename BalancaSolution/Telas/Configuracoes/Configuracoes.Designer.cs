namespace BalancaSolution.Telas.Configuracoes
{
    partial class Configuracoes
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tb_balanca = new System.Windows.Forms.TabPage();
            this.balanca_btn_usar_selecionada = new System.Windows.Forms.Button();
            this.balanca_txt_atual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.balanca_lsb_modelo = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.balanca_lsb_marca = new System.Windows.Forms.ListBox();
            this.tb_log = new System.Windows.Forms.TabPage();
            this.log_btn_ver = new System.Windows.Forms.Button();
            this.log_chk_ativar = new System.Windows.Forms.CheckBox();
            this.tb_comunicacao = new System.Windows.Forms.TabPage();
            this.comunicacao_chk_balanca_fake = new System.Windows.Forms.CheckBox();
            this.comunicacao_cb_porta_serial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.btn_salvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tb_balanca.SuspendLayout();
            this.tb_log.SuspendLayout();
            this.tb_comunicacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_fechar);
            this.splitContainer1.Panel2.Controls.Add(this.btn_salvar);
            this.splitContainer1.Size = new System.Drawing.Size(669, 405);
            this.splitContainer1.SplitterDistance = 355;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tb_balanca);
            this.tabControl1.Controls.Add(this.tb_log);
            this.tabControl1.Controls.Add(this.tb_comunicacao);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(669, 355);
            this.tabControl1.TabIndex = 0;
            // 
            // tb_balanca
            // 
            this.tb_balanca.Controls.Add(this.balanca_btn_usar_selecionada);
            this.tb_balanca.Controls.Add(this.balanca_txt_atual);
            this.tb_balanca.Controls.Add(this.label3);
            this.tb_balanca.Controls.Add(this.balanca_lsb_modelo);
            this.tb_balanca.Controls.Add(this.label2);
            this.tb_balanca.Controls.Add(this.label1);
            this.tb_balanca.Controls.Add(this.balanca_lsb_marca);
            this.tb_balanca.Location = new System.Drawing.Point(4, 22);
            this.tb_balanca.Name = "tb_balanca";
            this.tb_balanca.Padding = new System.Windows.Forms.Padding(3);
            this.tb_balanca.Size = new System.Drawing.Size(661, 329);
            this.tb_balanca.TabIndex = 0;
            this.tb_balanca.Text = "Balança";
            this.tb_balanca.UseVisualStyleBackColor = true;
            // 
            // balanca_btn_usar_selecionada
            // 
            this.balanca_btn_usar_selecionada.Image = global::BalancaSolution.Properties.Resources.ok_x16;
            this.balanca_btn_usar_selecionada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.balanca_btn_usar_selecionada.Location = new System.Drawing.Point(414, 68);
            this.balanca_btn_usar_selecionada.Name = "balanca_btn_usar_selecionada";
            this.balanca_btn_usar_selecionada.Size = new System.Drawing.Size(93, 49);
            this.balanca_btn_usar_selecionada.TabIndex = 2;
            this.balanca_btn_usar_selecionada.Text = "Usar balança selecionada";
            this.balanca_btn_usar_selecionada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.balanca_btn_usar_selecionada.UseVisualStyleBackColor = true;
            this.balanca_btn_usar_selecionada.Click += new System.EventHandler(this.balanca_btn_usar_selecionada_Click);
            // 
            // balanca_txt_atual
            // 
            this.balanca_txt_atual.Enabled = false;
            this.balanca_txt_atual.Location = new System.Drawing.Point(414, 29);
            this.balanca_txt_atual.Name = "balanca_txt_atual";
            this.balanca_txt_atual.Size = new System.Drawing.Size(213, 20);
            this.balanca_txt_atual.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Balança atual:";
            // 
            // balanca_lsb_modelo
            // 
            this.balanca_lsb_modelo.FormattingEnabled = true;
            this.balanca_lsb_modelo.Location = new System.Drawing.Point(206, 29);
            this.balanca_lsb_modelo.Name = "balanca_lsb_modelo";
            this.balanca_lsb_modelo.Size = new System.Drawing.Size(191, 290);
            this.balanca_lsb_modelo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Modelo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Marca:";
            // 
            // balanca_lsb_marca
            // 
            this.balanca_lsb_marca.FormattingEnabled = true;
            this.balanca_lsb_marca.Location = new System.Drawing.Point(8, 29);
            this.balanca_lsb_marca.Name = "balanca_lsb_marca";
            this.balanca_lsb_marca.Size = new System.Drawing.Size(176, 290);
            this.balanca_lsb_marca.TabIndex = 0;
            this.balanca_lsb_marca.SelectedIndexChanged += new System.EventHandler(this.balanca_lsb_marca_SelectedIndexChanged_1);
            // 
            // tb_log
            // 
            this.tb_log.Controls.Add(this.log_btn_ver);
            this.tb_log.Controls.Add(this.log_chk_ativar);
            this.tb_log.Location = new System.Drawing.Point(4, 22);
            this.tb_log.Name = "tb_log";
            this.tb_log.Padding = new System.Windows.Forms.Padding(3);
            this.tb_log.Size = new System.Drawing.Size(661, 329);
            this.tb_log.TabIndex = 1;
            this.tb_log.Text = "Log de eventos";
            this.tb_log.UseVisualStyleBackColor = true;
            // 
            // log_btn_ver
            // 
            this.log_btn_ver.Image = global::BalancaSolution.Properties.Resources.open_x16;
            this.log_btn_ver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.log_btn_ver.Location = new System.Drawing.Point(25, 79);
            this.log_btn_ver.Name = "log_btn_ver";
            this.log_btn_ver.Size = new System.Drawing.Size(127, 64);
            this.log_btn_ver.TabIndex = 1;
            this.log_btn_ver.Text = "Ver log de eventos";
            this.log_btn_ver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.log_btn_ver.UseVisualStyleBackColor = true;
            this.log_btn_ver.Click += new System.EventHandler(this.log_btn_ver_Click);
            // 
            // log_chk_ativar
            // 
            this.log_chk_ativar.AutoSize = true;
            this.log_chk_ativar.Location = new System.Drawing.Point(25, 26);
            this.log_chk_ativar.Name = "log_chk_ativar";
            this.log_chk_ativar.Size = new System.Drawing.Size(117, 17);
            this.log_chk_ativar.TabIndex = 0;
            this.log_chk_ativar.Text = "Ativar modo de log.";
            this.log_chk_ativar.UseVisualStyleBackColor = true;
            // 
            // tb_comunicacao
            // 
            this.tb_comunicacao.Controls.Add(this.comunicacao_chk_balanca_fake);
            this.tb_comunicacao.Controls.Add(this.comunicacao_cb_porta_serial);
            this.tb_comunicacao.Controls.Add(this.label4);
            this.tb_comunicacao.Location = new System.Drawing.Point(4, 22);
            this.tb_comunicacao.Name = "tb_comunicacao";
            this.tb_comunicacao.Padding = new System.Windows.Forms.Padding(3);
            this.tb_comunicacao.Size = new System.Drawing.Size(661, 329);
            this.tb_comunicacao.TabIndex = 2;
            this.tb_comunicacao.Text = "Comunicação";
            this.tb_comunicacao.UseVisualStyleBackColor = true;
            // 
            // comunicacao_chk_balanca_fake
            // 
            this.comunicacao_chk_balanca_fake.AutoSize = true;
            this.comunicacao_chk_balanca_fake.Location = new System.Drawing.Point(11, 68);
            this.comunicacao_chk_balanca_fake.Name = "comunicacao_chk_balanca_fake";
            this.comunicacao_chk_balanca_fake.Size = new System.Drawing.Size(172, 17);
            this.comunicacao_chk_balanca_fake.TabIndex = 1;
            this.comunicacao_chk_balanca_fake.Text = "Usar balança falsa para testes.";
            this.comunicacao_chk_balanca_fake.UseVisualStyleBackColor = true;
            // 
            // comunicacao_cb_porta_serial
            // 
            this.comunicacao_cb_porta_serial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comunicacao_cb_porta_serial.FormattingEnabled = true;
            this.comunicacao_cb_porta_serial.Location = new System.Drawing.Point(76, 13);
            this.comunicacao_cb_porta_serial.Name = "comunicacao_cb_porta_serial";
            this.comunicacao_cb_porta_serial.Size = new System.Drawing.Size(287, 21);
            this.comunicacao_cb_porta_serial.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Porta serial:";
            // 
            // btn_fechar
            // 
            this.btn_fechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_fechar.Image = global::BalancaSolution.Properties.Resources.close_x16;
            this.btn_fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_fechar.Location = new System.Drawing.Point(12, 11);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(75, 23);
            this.btn_fechar.TabIndex = 0;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // btn_salvar
            // 
            this.btn_salvar.Image = global::BalancaSolution.Properties.Resources.save_x16;
            this.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salvar.Location = new System.Drawing.Point(568, 11);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(75, 23);
            this.btn_salvar.TabIndex = 1;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // Configuracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_fechar;
            this.ClientSize = new System.Drawing.Size(669, 405);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "Configuracoes";
            this.ShowIcon = false;
            this.Text = "Configuracoes";
            this.Load += new System.EventHandler(this.Configuracoes_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tb_balanca.ResumeLayout(false);
            this.tb_balanca.PerformLayout();
            this.tb_log.ResumeLayout(false);
            this.tb_log.PerformLayout();
            this.tb_comunicacao.ResumeLayout(false);
            this.tb_comunicacao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tb_balanca;
        private System.Windows.Forms.TabPage tb_log;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Button balanca_btn_usar_selecionada;
        private System.Windows.Forms.TextBox balanca_txt_atual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox balanca_lsb_modelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox balanca_lsb_marca;
        private System.Windows.Forms.CheckBox log_chk_ativar;
        private System.Windows.Forms.Button log_btn_ver;
        private System.Windows.Forms.TabPage tb_comunicacao;
        private System.Windows.Forms.ComboBox comunicacao_cb_porta_serial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.CheckBox comunicacao_chk_balanca_fake;
    }
}