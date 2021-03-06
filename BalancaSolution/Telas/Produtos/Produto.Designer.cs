﻿namespace BalancaSolution.Telas.Produtos
{
    partial class Produto
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.btn_novo = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_salvar = new System.Windows.Forms.Button();
            this.rb_kilos = new System.Windows.Forms.RadioButton();
            this.rb_porcentagem = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.nup_margem = new System.Windows.Forms.NumericUpDown();
            this.txt_produto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsv_dados = new BrightIdeasSoftware.DataListView();
            this.olv_produto = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olv_margem = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olv_tipo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_margem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsv_dados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_excluir);
            this.groupBox1.Controls.Add(this.btn_fechar);
            this.groupBox1.Controls.Add(this.btn_novo);
            this.groupBox1.Controls.Add(this.btn_cancelar);
            this.groupBox1.Controls.Add(this.btn_salvar);
            this.groupBox1.Controls.Add(this.rb_kilos);
            this.groupBox1.Controls.Add(this.rb_porcentagem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nup_margem);
            this.groupBox1.Controls.Add(this.txt_produto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 178);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produto";
            // 
            // btn_excluir
            // 
            this.btn_excluir.Enabled = false;
            this.btn_excluir.Image = global::BalancaSolution.Properties.Resources.edit_delete_delete_x16;
            this.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_excluir.Location = new System.Drawing.Point(289, 50);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(75, 47);
            this.btn_excluir.TabIndex = 9;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.btn_excluir_Click);
            this.btn_excluir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // btn_fechar
            // 
            this.btn_fechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_fechar.Image = global::BalancaSolution.Properties.Resources.close_x16;
            this.btn_fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_fechar.Location = new System.Drawing.Point(382, 110);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(75, 47);
            this.btn_fechar.TabIndex = 8;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            this.btn_fechar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // btn_novo
            // 
            this.btn_novo.Image = global::BalancaSolution.Properties.Resources.new_x16;
            this.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_novo.Location = new System.Drawing.Point(289, 110);
            this.btn_novo.Name = "btn_novo";
            this.btn_novo.Size = new System.Drawing.Size(75, 47);
            this.btn_novo.TabIndex = 7;
            this.btn_novo.Text = "Novo";
            this.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_novo.UseVisualStyleBackColor = true;
            this.btn_novo.Click += new System.EventHandler(this.btn_novo_Click);
            this.btn_novo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Image = global::BalancaSolution.Properties.Resources.cancel_x16;
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(109, 110);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 47);
            this.btn_cancelar.TabIndex = 6;
            this.btn_cancelar.Text = "Cancelar edição";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            this.btn_cancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // btn_salvar
            // 
            this.btn_salvar.Image = global::BalancaSolution.Properties.Resources.save_x16;
            this.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salvar.Location = new System.Drawing.Point(10, 110);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(75, 47);
            this.btn_salvar.TabIndex = 5;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            this.btn_salvar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // rb_kilos
            // 
            this.rb_kilos.AutoSize = true;
            this.rb_kilos.Location = new System.Drawing.Point(148, 76);
            this.rb_kilos.Name = "rb_kilos";
            this.rb_kilos.Size = new System.Drawing.Size(38, 17);
            this.rb_kilos.TabIndex = 4;
            this.rb_kilos.Text = "Kg";
            this.rb_kilos.UseVisualStyleBackColor = true;
            this.rb_kilos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // rb_porcentagem
            // 
            this.rb_porcentagem.AutoSize = true;
            this.rb_porcentagem.Checked = true;
            this.rb_porcentagem.Location = new System.Drawing.Point(109, 74);
            this.rb_porcentagem.Name = "rb_porcentagem";
            this.rb_porcentagem.Size = new System.Drawing.Size(33, 17);
            this.rb_porcentagem.TabIndex = 3;
            this.rb_porcentagem.TabStop = true;
            this.rb_porcentagem.Text = "%";
            this.rb_porcentagem.UseVisualStyleBackColor = true;
            this.rb_porcentagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo de margem:";
            // 
            // nup_margem
            // 
            this.nup_margem.DecimalPlaces = 5;
            this.nup_margem.Location = new System.Drawing.Point(109, 48);
            this.nup_margem.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nup_margem.Name = "nup_margem";
            this.nup_margem.Size = new System.Drawing.Size(151, 20);
            this.nup_margem.TabIndex = 2;
            this.nup_margem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nup_margem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // txt_produto
            // 
            this.txt_produto.Location = new System.Drawing.Point(109, 19);
            this.txt_produto.Name = "txt_produto";
            this.txt_produto.Size = new System.Drawing.Size(318, 20);
            this.txt_produto.TabIndex = 1;
            this.txt_produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Margem:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto:";
            // 
            // lsv_dados
            // 
            this.lsv_dados.AllColumns.Add(this.olv_produto);
            this.lsv_dados.AllColumns.Add(this.olv_margem);
            this.lsv_dados.AllColumns.Add(this.olv_tipo);
            this.lsv_dados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olv_produto,
            this.olv_margem,
            this.olv_tipo});
            this.lsv_dados.DataSource = null;
            this.lsv_dados.FullRowSelect = true;
            this.lsv_dados.GridLines = true;
            this.lsv_dados.HideSelection = false;
            this.lsv_dados.Location = new System.Drawing.Point(12, 13);
            this.lsv_dados.Name = "lsv_dados";
            this.lsv_dados.ShowGroups = false;
            this.lsv_dados.Size = new System.Drawing.Size(475, 109);
            this.lsv_dados.TabIndex = 0;
            this.lsv_dados.UseCompatibleStateImageBehavior = false;
            this.lsv_dados.View = System.Windows.Forms.View.Details;
            this.lsv_dados.SelectedIndexChanged += new System.EventHandler(this.lsv_dados_SelectedIndexChanged);
            this.lsv_dados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            // 
            // olv_produto
            // 
            this.olv_produto.AspectName = "Nome";
            this.olv_produto.Text = "Produto";
            this.olv_produto.Width = 180;
            // 
            // olv_margem
            // 
            this.olv_margem.AspectName = "Margem";
            this.olv_margem.Text = "Margem";
            this.olv_margem.Width = 120;
            // 
            // olv_tipo
            // 
            this.olv_tipo.AspectName = "Tipo_Margem";
            this.olv_tipo.Text = "";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Produto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_fechar;
            this.ClientSize = new System.Drawing.Size(499, 318);
            this.Controls.Add(this.lsv_dados);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Produto";
            this.Text = "Produto";
            this.Load += new System.EventHandler(this.Produto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Produto_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_margem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsv_dados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_kilos;
        private System.Windows.Forms.RadioButton rb_porcentagem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nup_margem;
        private System.Windows.Forms.TextBox txt_produto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.DataListView lsv_dados;
        private BrightIdeasSoftware.OLVColumn olv_produto;
        private BrightIdeasSoftware.OLVColumn olv_margem;
        private BrightIdeasSoftware.OLVColumn olv_tipo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Button btn_novo;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Button btn_excluir;
    }
}