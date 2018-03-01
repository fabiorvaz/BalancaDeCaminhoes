namespace BalancaSolution.Telas.Relatorio
{
    partial class Listagem
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_data_fim = new System.Windows.Forms.MaskedTextBox();
            this.txt_data_ini = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.txt_destino = new System.Windows.Forms.TextBox();
            this.txt_procedencia = new System.Windows.Forms.TextBox();
            this.txt_produto = new System.Windows.Forms.TextBox();
            this.txt_placa = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rb_tipo_todos = new System.Windows.Forms.RadioButton();
            this.rb_tipo_descarga = new System.Windows.Forms.RadioButton();
            this.rb_tipo_carga = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_data_bruto_fim = new System.Windows.Forms.MaskedTextBox();
            this.txt_data_bruto_ini = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_data_tara_fim = new System.Windows.Forms.MaskedTextBox();
            this.txt_data_tara_ini = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_gerar = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Produto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Procedência:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Destino:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Placa:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_data_fim);
            this.groupBox3.Controls.Add(this.txt_data_ini);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(16, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 77);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data ticket";
            // 
            // txt_data_fim
            // 
            this.txt_data_fim.Location = new System.Drawing.Point(140, 37);
            this.txt_data_fim.Mask = "00/00/00";
            this.txt_data_fim.Name = "txt_data_fim";
            this.txt_data_fim.Size = new System.Drawing.Size(58, 20);
            this.txt_data_fim.TabIndex = 1;
            // 
            // txt_data_ini
            // 
            this.txt_data_ini.Location = new System.Drawing.Point(26, 37);
            this.txt_data_ini.Mask = "00/00/00";
            this.txt_data_ini.Name = "txt_data_ini";
            this.txt_data_ini.Size = new System.Drawing.Size(54, 20);
            this.txt_data_ini.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(129, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Final";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Início";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(89, 12);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(176, 20);
            this.txt_codigo.TabIndex = 0;
            // 
            // txt_destino
            // 
            this.txt_destino.Location = new System.Drawing.Point(89, 38);
            this.txt_destino.Name = "txt_destino";
            this.txt_destino.Size = new System.Drawing.Size(176, 20);
            this.txt_destino.TabIndex = 1;
            // 
            // txt_procedencia
            // 
            this.txt_procedencia.Location = new System.Drawing.Point(89, 64);
            this.txt_procedencia.Name = "txt_procedencia";
            this.txt_procedencia.Size = new System.Drawing.Size(176, 20);
            this.txt_procedencia.TabIndex = 2;
            // 
            // txt_produto
            // 
            this.txt_produto.Location = new System.Drawing.Point(89, 90);
            this.txt_produto.Name = "txt_produto";
            this.txt_produto.Size = new System.Drawing.Size(176, 20);
            this.txt_produto.TabIndex = 3;
            // 
            // txt_placa
            // 
            this.txt_placa.Location = new System.Drawing.Point(89, 116);
            this.txt_placa.Name = "txt_placa";
            this.txt_placa.Size = new System.Drawing.Size(176, 20);
            this.txt_placa.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rb_tipo_todos);
            this.groupBox4.Controls.Add(this.rb_tipo_descarga);
            this.groupBox4.Controls.Add(this.rb_tipo_carga);
            this.groupBox4.Location = new System.Drawing.Point(16, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(249, 56);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo";
            // 
            // rb_tipo_todos
            // 
            this.rb_tipo_todos.AutoSize = true;
            this.rb_tipo_todos.Checked = true;
            this.rb_tipo_todos.Location = new System.Drawing.Point(158, 19);
            this.rb_tipo_todos.Name = "rb_tipo_todos";
            this.rb_tipo_todos.Size = new System.Drawing.Size(55, 17);
            this.rb_tipo_todos.TabIndex = 2;
            this.rb_tipo_todos.TabStop = true;
            this.rb_tipo_todos.Text = "Todos";
            this.rb_tipo_todos.UseVisualStyleBackColor = true;
            // 
            // rb_tipo_descarga
            // 
            this.rb_tipo_descarga.AutoSize = true;
            this.rb_tipo_descarga.Location = new System.Drawing.Point(73, 19);
            this.rb_tipo_descarga.Name = "rb_tipo_descarga";
            this.rb_tipo_descarga.Size = new System.Drawing.Size(71, 17);
            this.rb_tipo_descarga.TabIndex = 1;
            this.rb_tipo_descarga.Text = "Descarga";
            this.rb_tipo_descarga.UseVisualStyleBackColor = true;
            // 
            // rb_tipo_carga
            // 
            this.rb_tipo_carga.AutoSize = true;
            this.rb_tipo_carga.Location = new System.Drawing.Point(14, 19);
            this.rb_tipo_carga.Name = "rb_tipo_carga";
            this.rb_tipo_carga.Size = new System.Drawing.Size(53, 17);
            this.rb_tipo_carga.TabIndex = 0;
            this.rb_tipo_carga.Text = "Carga";
            this.rb_tipo_carga.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_data_bruto_fim);
            this.groupBox1.Controls.Add(this.txt_data_bruto_ini);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(16, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 77);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data bruto";
            // 
            // txt_data_bruto_fim
            // 
            this.txt_data_bruto_fim.Location = new System.Drawing.Point(140, 37);
            this.txt_data_bruto_fim.Mask = "00/00/00";
            this.txt_data_bruto_fim.Name = "txt_data_bruto_fim";
            this.txt_data_bruto_fim.Size = new System.Drawing.Size(58, 20);
            this.txt_data_bruto_fim.TabIndex = 1;
            // 
            // txt_data_bruto_ini
            // 
            this.txt_data_bruto_ini.Location = new System.Drawing.Point(26, 37);
            this.txt_data_bruto_ini.Mask = "00/00/00";
            this.txt_data_bruto_ini.Name = "txt_data_bruto_ini";
            this.txt_data_bruto_ini.Size = new System.Drawing.Size(54, 20);
            this.txt_data_bruto_ini.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Final";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Início";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_data_tara_fim);
            this.groupBox2.Controls.Add(this.txt_data_tara_ini);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(16, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 77);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data tara";
            // 
            // txt_data_tara_fim
            // 
            this.txt_data_tara_fim.Location = new System.Drawing.Point(140, 37);
            this.txt_data_tara_fim.Mask = "00/00/00";
            this.txt_data_tara_fim.Name = "txt_data_tara_fim";
            this.txt_data_tara_fim.Size = new System.Drawing.Size(58, 20);
            this.txt_data_tara_fim.TabIndex = 1;
            // 
            // txt_data_tara_ini
            // 
            this.txt_data_tara_ini.Location = new System.Drawing.Point(26, 37);
            this.txt_data_tara_ini.Mask = "00/00/00";
            this.txt_data_tara_ini.Name = "txt_data_tara_ini";
            this.txt_data_tara_ini.Size = new System.Drawing.Size(54, 20);
            this.txt_data_tara_ini.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(129, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Final";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Início";
            // 
            // btn_gerar
            // 
            this.btn_gerar.Image = global::BalancaSolution.Properties.Resources.preview_x16;
            this.btn_gerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_gerar.Location = new System.Drawing.Point(104, 465);
            this.btn_gerar.Name = "btn_gerar";
            this.btn_gerar.Size = new System.Drawing.Size(75, 42);
            this.btn_gerar.TabIndex = 10;
            this.btn_gerar.Text = "Gerar";
            this.btn_gerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_gerar.UseVisualStyleBackColor = true;
            this.btn_gerar.Click += new System.EventHandler(this.btn_gerar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Image = global::BalancaSolution.Properties.Resources.print_x16;
            this.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_imprimir.Location = new System.Drawing.Point(16, 465);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(75, 42);
            this.btn_imprimir.TabIndex = 9;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_fechar.Image = global::BalancaSolution.Properties.Resources.close_x16;
            this.btn_fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_fechar.Location = new System.Drawing.Point(190, 465);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(75, 42);
            this.btn_fechar.TabIndex = 11;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // Listagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_fechar;
            this.ClientSize = new System.Drawing.Size(277, 526);
            this.Controls.Add(this.btn_fechar);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.btn_gerar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txt_placa);
            this.Controls.Add(this.txt_produto);
            this.Controls.Add(this.txt_procedencia);
            this.Controls.Add(this.txt_destino);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Listagem";
            this.ShowIcon = false;
            this.Text = "Relatorio de listagem";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Listagem_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.TextBox txt_destino;
        private System.Windows.Forms.TextBox txt_procedencia;
        private System.Windows.Forms.TextBox txt_produto;
        private System.Windows.Forms.MaskedTextBox txt_data_fim;
        private System.Windows.Forms.MaskedTextBox txt_data_ini;
        private System.Windows.Forms.TextBox txt_placa;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rb_tipo_todos;
        private System.Windows.Forms.RadioButton rb_tipo_descarga;
        private System.Windows.Forms.RadioButton rb_tipo_carga;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txt_data_bruto_fim;
        private System.Windows.Forms.MaskedTextBox txt_data_bruto_ini;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox txt_data_tara_fim;
        private System.Windows.Forms.MaskedTextBox txt_data_tara_ini;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_gerar;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_fechar;
    }
}