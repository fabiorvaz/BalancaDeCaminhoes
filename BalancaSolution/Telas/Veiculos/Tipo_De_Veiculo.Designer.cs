namespace BalancaSolution.Telas.Veiculos
{
    partial class Tipo_De_Veiculo
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
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsv_dados = new BrightIdeasSoftware.DataListView();
            this.olv_id = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olv_nome = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.txt_nome);
            this.groupBox1.Controls.Add(this.txt_codigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 140);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de veiculo";
            // 
            // btn_excluir
            // 
            this.btn_excluir.Enabled = false;
            this.btn_excluir.Image = global::BalancaSolution.Properties.Resources.edit_delete_delete_x16;
            this.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_excluir.Location = new System.Drawing.Point(266, 87);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(75, 47);
            this.btn_excluir.TabIndex = 11;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.btn_excluir_Click);
            this.btn_excluir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_De_Veiculo_KeyDown);
            // 
            // btn_fechar
            // 
            this.btn_fechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_fechar.Image = global::BalancaSolution.Properties.Resources.close_x16;
            this.btn_fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_fechar.Location = new System.Drawing.Point(428, 87);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(75, 47);
            this.btn_fechar.TabIndex = 6;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            this.btn_fechar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_De_Veiculo_KeyDown);
            // 
            // btn_novo
            // 
            this.btn_novo.Image = global::BalancaSolution.Properties.Resources.new_x16;
            this.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_novo.Location = new System.Drawing.Point(347, 87);
            this.btn_novo.Name = "btn_novo";
            this.btn_novo.Size = new System.Drawing.Size(75, 47);
            this.btn_novo.TabIndex = 5;
            this.btn_novo.Text = "Novo";
            this.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_novo.UseVisualStyleBackColor = true;
            this.btn_novo.Click += new System.EventHandler(this.btn_novo_Click);
            this.btn_novo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_De_Veiculo_KeyDown);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Image = global::BalancaSolution.Properties.Resources.cancel_x16;
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(87, 87);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 47);
            this.btn_cancelar.TabIndex = 4;
            this.btn_cancelar.Text = "Cancelar edição";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            this.btn_cancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_De_Veiculo_KeyDown);
            // 
            // btn_salvar
            // 
            this.btn_salvar.Image = global::BalancaSolution.Properties.Resources.save_x16;
            this.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salvar.Location = new System.Drawing.Point(6, 87);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(75, 47);
            this.btn_salvar.TabIndex = 3;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            this.btn_salvar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_De_Veiculo_KeyDown);
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(70, 48);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(411, 20);
            this.txt_nome.TabIndex = 2;
            this.txt_nome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_De_Veiculo_KeyDown);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Enabled = false;
            this.txt_codigo.Location = new System.Drawing.Point(70, 22);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(143, 20);
            this.txt_codigo.TabIndex = 1;
            this.txt_codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_De_Veiculo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // lsv_dados
            // 
            this.lsv_dados.AllColumns.Add(this.olv_id);
            this.lsv_dados.AllColumns.Add(this.olv_nome);
            this.lsv_dados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olv_id,
            this.olv_nome});
            this.lsv_dados.DataSource = null;
            this.lsv_dados.FullRowSelect = true;
            this.lsv_dados.GridLines = true;
            this.lsv_dados.HideSelection = false;
            this.lsv_dados.Location = new System.Drawing.Point(12, 12);
            this.lsv_dados.Name = "lsv_dados";
            this.lsv_dados.ShowGroups = false;
            this.lsv_dados.Size = new System.Drawing.Size(523, 110);
            this.lsv_dados.TabIndex = 0;
            this.lsv_dados.UseCompatibleStateImageBehavior = false;
            this.lsv_dados.View = System.Windows.Forms.View.Details;
            this.lsv_dados.SelectedIndexChanged += new System.EventHandler(this.lsv_dados_SelectedIndexChanged);
            this.lsv_dados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_De_Veiculo_KeyDown);
            // 
            // olv_id
            // 
            this.olv_id.AspectName = "ID";
            this.olv_id.IsEditable = false;
            this.olv_id.Text = "Código";
            this.olv_id.Width = 100;
            // 
            // olv_nome
            // 
            this.olv_nome.AspectName = "Nome";
            this.olv_nome.IsEditable = false;
            this.olv_nome.Text = "Tipo de veiculo";
            this.olv_nome.Width = 399;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Tipo_De_Veiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_fechar;
            this.ClientSize = new System.Drawing.Size(547, 279);
            this.Controls.Add(this.lsv_dados);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Tipo_De_Veiculo";
            this.Text = "Tipo De Veiculo";
            this.Load += new System.EventHandler(this.Tipo_De_Veiculo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_De_Veiculo_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lsv_dados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.DataListView lsv_dados;
        private BrightIdeasSoftware.OLVColumn olv_id;
        private BrightIdeasSoftware.OLVColumn olv_nome;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Button btn_novo;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Button btn_excluir;
    }
}