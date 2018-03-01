namespace BalancaSolution.Telas.Veiculos
{
    partial class Veiculo
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
            this.cb_motorista_padrao = new System.Windows.Forms.ComboBox();
            this.cb_tipo_de_veiculo = new System.Windows.Forms.ComboBox();
            this.cb_transportadora = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_placa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lsv_dados = new BrightIdeasSoftware.DataListView();
            this.olv_placa = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olv_transportadora = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olv_tipo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsv_dados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_excluir);
            this.groupBox1.Controls.Add(this.btn_fechar);
            this.groupBox1.Controls.Add(this.btn_novo);
            this.groupBox1.Controls.Add(this.btn_cancelar);
            this.groupBox1.Controls.Add(this.btn_salvar);
            this.groupBox1.Controls.Add(this.cb_motorista_padrao);
            this.groupBox1.Controls.Add(this.cb_tipo_de_veiculo);
            this.groupBox1.Controls.Add(this.cb_transportadora);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_placa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 194);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Veiculo";
            // 
            // btn_excluir
            // 
            this.btn_excluir.Enabled = false;
            this.btn_excluir.Image = global::BalancaSolution.Properties.Resources.edit_delete_delete_x16;
            this.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_excluir.Location = new System.Drawing.Point(288, 137);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(75, 47);
            this.btn_excluir.TabIndex = 13;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.btn_excluir_Click);
            this.btn_excluir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // btn_fechar
            // 
            this.btn_fechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_fechar.Image = global::BalancaSolution.Properties.Resources.close_x16;
            this.btn_fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_fechar.Location = new System.Drawing.Point(475, 137);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(75, 47);
            this.btn_fechar.TabIndex = 7;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            this.btn_fechar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // btn_novo
            // 
            this.btn_novo.Image = global::BalancaSolution.Properties.Resources.new_x16;
            this.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_novo.Location = new System.Drawing.Point(382, 137);
            this.btn_novo.Name = "btn_novo";
            this.btn_novo.Size = new System.Drawing.Size(75, 47);
            this.btn_novo.TabIndex = 6;
            this.btn_novo.Text = "Novo";
            this.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_novo.UseVisualStyleBackColor = true;
            this.btn_novo.Click += new System.EventHandler(this.btn_cancelar_Click);
            this.btn_novo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Image = global::BalancaSolution.Properties.Resources.cancel_x16;
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(101, 137);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 47);
            this.btn_cancelar.TabIndex = 5;
            this.btn_cancelar.Text = "Cancelar edição";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            this.btn_cancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // btn_salvar
            // 
            this.btn_salvar.Image = global::BalancaSolution.Properties.Resources.save_x16;
            this.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salvar.Location = new System.Drawing.Point(16, 137);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(75, 47);
            this.btn_salvar.TabIndex = 4;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            this.btn_salvar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // cb_motorista_padrao
            // 
            this.cb_motorista_padrao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_motorista_padrao.FormattingEnabled = true;
            this.cb_motorista_padrao.Location = new System.Drawing.Point(101, 101);
            this.cb_motorista_padrao.Name = "cb_motorista_padrao";
            this.cb_motorista_padrao.Size = new System.Drawing.Size(431, 21);
            this.cb_motorista_padrao.TabIndex = 3;
            this.cb_motorista_padrao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // cb_tipo_de_veiculo
            // 
            this.cb_tipo_de_veiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tipo_de_veiculo.FormattingEnabled = true;
            this.cb_tipo_de_veiculo.Location = new System.Drawing.Point(101, 75);
            this.cb_tipo_de_veiculo.Name = "cb_tipo_de_veiculo";
            this.cb_tipo_de_veiculo.Size = new System.Drawing.Size(431, 21);
            this.cb_tipo_de_veiculo.TabIndex = 2;
            this.cb_tipo_de_veiculo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // cb_transportadora
            // 
            this.cb_transportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_transportadora.FormattingEnabled = true;
            this.cb_transportadora.Location = new System.Drawing.Point(101, 48);
            this.cb_transportadora.Name = "cb_transportadora";
            this.cb_transportadora.Size = new System.Drawing.Size(431, 21);
            this.cb_transportadora.TabIndex = 1;
            this.cb_transportadora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Motorista padrão:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo de veiculo:";
            // 
            // txt_placa
            // 
            this.txt_placa.Location = new System.Drawing.Point(101, 22);
            this.txt_placa.Name = "txt_placa";
            this.txt_placa.Size = new System.Drawing.Size(257, 20);
            this.txt_placa.TabIndex = 0;
            this.txt_placa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Transportadora:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placa:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lsv_dados
            // 
            this.lsv_dados.AllColumns.Add(this.olv_placa);
            this.lsv_dados.AllColumns.Add(this.olv_transportadora);
            this.lsv_dados.AllColumns.Add(this.olv_tipo);
            this.lsv_dados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olv_placa,
            this.olv_transportadora,
            this.olv_tipo});
            this.lsv_dados.DataSource = null;
            this.lsv_dados.FullRowSelect = true;
            this.lsv_dados.GridLines = true;
            this.lsv_dados.HideSelection = false;
            this.lsv_dados.Location = new System.Drawing.Point(12, 12);
            this.lsv_dados.Name = "lsv_dados";
            this.lsv_dados.ShowGroups = false;
            this.lsv_dados.Size = new System.Drawing.Size(568, 110);
            this.lsv_dados.TabIndex = 0;
            this.lsv_dados.UseCompatibleStateImageBehavior = false;
            this.lsv_dados.View = System.Windows.Forms.View.Details;
            this.lsv_dados.SelectedIndexChanged += new System.EventHandler(this.lsv_dados_SelectedIndexChanged);
            this.lsv_dados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            // 
            // olv_placa
            // 
            this.olv_placa.AspectName = "Placa";
            this.olv_placa.Text = "Placa";
            this.olv_placa.Width = 100;
            // 
            // olv_transportadora
            // 
            this.olv_transportadora.AspectName = "Transportadora";
            this.olv_transportadora.Text = "Transportadora";
            this.olv_transportadora.Width = 180;
            // 
            // olv_tipo
            // 
            this.olv_tipo.AspectName = "Tipo";
            this.olv_tipo.Text = "Tipo de veiculo";
            this.olv_tipo.Width = 180;
            // 
            // Veiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_fechar;
            this.ClientSize = new System.Drawing.Size(589, 333);
            this.Controls.Add(this.lsv_dados);
            this.Controls.Add(this.groupBox1);
            this.Name = "Veiculo";
            this.ShowIcon = false;
            this.Text = "Veiculos";
            this.Load += new System.EventHandler(this.Veiculo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Veiculo_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsv_dados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_motorista_padrao;
        private System.Windows.Forms.ComboBox cb_tipo_de_veiculo;
        private System.Windows.Forms.ComboBox cb_transportadora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_placa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private BrightIdeasSoftware.DataListView lsv_dados;
        private BrightIdeasSoftware.OLVColumn olv_placa;
        private BrightIdeasSoftware.OLVColumn olv_transportadora;
        private BrightIdeasSoftware.OLVColumn olv_tipo;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Button btn_novo;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Button btn_excluir;
    }
}