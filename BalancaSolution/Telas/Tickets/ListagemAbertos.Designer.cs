namespace BalancaSolution.Telas.Tickets
{
    partial class ListagemAbertos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListagemAbertos));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNovaPesagem = new System.Windows.Forms.ToolStripButton();
            this.tsbConcluirPesagem = new System.Windows.Forms.ToolStripButton();
            this.tsbExcluirPesagem = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbFechar = new System.Windows.Forms.ToolStripButton();
            this.dlvDados = new BrightIdeasSoftware.DataListView();
            this.dlv_c_codigo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dlv_c_placa = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dlv_c_tipo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dlv_c_data = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dlv_c_status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btn_fechar_form = new System.Windows.Forms.Button();
            this.DlvCTransportadora = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvDados)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dlvDados);
            this.splitContainer1.Panel2.Controls.Add(this.btn_fechar_form);
            this.splitContainer1.Size = new System.Drawing.Size(624, 421);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNovaPesagem,
            this.tsbConcluirPesagem,
            this.tsbExcluirPesagem,
            this.tsbRefresh,
            this.tsbFechar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_nova_pesagem
            // 
            this.tsbNovaPesagem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNovaPesagem.Image = ((System.Drawing.Image)(resources.GetObject("tsb_nova_pesagem.Image")));
            this.tsbNovaPesagem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNovaPesagem.Name = "tsb_nova_pesagem";
            this.tsbNovaPesagem.Size = new System.Drawing.Size(90, 22);
            this.tsbNovaPesagem.Text = "Nova pesagem";
            this.tsbNovaPesagem.Click += new System.EventHandler(this.BtnNovaPesagem_Click);
            // 
            // tsb_concluir_pesagem
            // 
            this.tsbConcluirPesagem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbConcluirPesagem.Image = ((System.Drawing.Image)(resources.GetObject("tsb_concluir_pesagem.Image")));
            this.tsbConcluirPesagem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConcluirPesagem.Name = "tsb_concluir_pesagem";
            this.tsbConcluirPesagem.Size = new System.Drawing.Size(107, 22);
            this.tsbConcluirPesagem.Text = "Concluir Pesagem";
            this.tsbConcluirPesagem.Click += new System.EventHandler(this.BtnPesagem_Click);
            // 
            // tsb_excluir_pesagem
            // 
            this.tsbExcluirPesagem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExcluirPesagem.Image = ((System.Drawing.Image)(resources.GetObject("tsb_excluir_pesagem.Image")));
            this.tsbExcluirPesagem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcluirPesagem.Name = "tsb_excluir_pesagem";
            this.tsbExcluirPesagem.Size = new System.Drawing.Size(96, 22);
            this.tsbExcluirPesagem.Text = "Excluir pesagem";
            this.tsbExcluirPesagem.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // tsb_refresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsb_refresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsb_refresh";
            this.tsbRefresh.Size = new System.Drawing.Size(81, 22);
            this.tsbRefresh.Text = "Atualizar lista";
            this.tsbRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btn_fechar
            // 
            this.tsbFechar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFechar.Image = ((System.Drawing.Image)(resources.GetObject("btn_fechar.Image")));
            this.tsbFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFechar.Name = "btn_fechar";
            this.tsbFechar.Size = new System.Drawing.Size(46, 22);
            this.tsbFechar.Text = "Fechar";
            this.tsbFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // dlv_dados
            // 
            this.dlvDados.AllColumns.Add(this.dlv_c_codigo);
            this.dlvDados.AllColumns.Add(this.dlv_c_placa);
            this.dlvDados.AllColumns.Add(this.dlv_c_tipo);
            this.dlvDados.AllColumns.Add(this.dlv_c_data);
            this.dlvDados.AllColumns.Add(this.dlv_c_status);
            this.dlvDados.AllColumns.Add(this.DlvCTransportadora);
            this.dlvDados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dlv_c_codigo,
            this.dlv_c_placa,
            this.dlv_c_tipo,
            this.dlv_c_data,
            this.dlv_c_status,
            this.DlvCTransportadora});
            this.dlvDados.DataSource = null;
            this.dlvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvDados.FullRowSelect = true;
            this.dlvDados.GridLines = true;
            this.dlvDados.Location = new System.Drawing.Point(0, 0);
            this.dlvDados.MultiSelect = false;
            this.dlvDados.Name = "dlv_dados";
            this.dlvDados.ShowGroups = false;
            this.dlvDados.Size = new System.Drawing.Size(624, 392);
            this.dlvDados.TabIndex = 0;
            this.dlvDados.UseCompatibleStateImageBehavior = false;
            this.dlvDados.View = System.Windows.Forms.View.Details;
            this.dlvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DlvDados_MouseDoubleClick);
            // 
            // dlv_c_codigo
            // 
            this.dlv_c_codigo.AspectName = "Codigo";
            this.dlv_c_codigo.IsEditable = false;
            this.dlv_c_codigo.Text = "Codigo";
            this.dlv_c_codigo.Width = 100;
            // 
            // dlv_c_placa
            // 
            this.dlv_c_placa.AspectName = "Veiculo_Placa";
            this.dlv_c_placa.Text = "Placa";
            this.dlv_c_placa.Width = 90;
            // 
            // dlv_c_tipo
            // 
            this.dlv_c_tipo.AspectName = "Tipo";
            this.dlv_c_tipo.IsEditable = false;
            this.dlv_c_tipo.Text = "Tipo";
            // 
            // dlv_c_data
            // 
            this.dlv_c_data.AspectName = "Data";
            this.dlv_c_data.IsEditable = false;
            this.dlv_c_data.Text = "Data";
            this.dlv_c_data.Width = 140;
            // 
            // dlv_c_status
            // 
            this.dlv_c_status.AspectName = "Status";
            this.dlv_c_status.Text = "Situação";
            // 
            // btn_fechar_form
            // 
            this.btn_fechar_form.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_fechar_form.Location = new System.Drawing.Point(423, 73);
            this.btn_fechar_form.Name = "btn_fechar_form";
            this.btn_fechar_form.Size = new System.Drawing.Size(75, 23);
            this.btn_fechar_form.TabIndex = 1;
            this.btn_fechar_form.Text = "button1";
            this.btn_fechar_form.UseVisualStyleBackColor = true;
            this.btn_fechar_form.Click += new System.EventHandler(this.BtnFecharForm_Click);
            // 
            // DlvCTransportadora
            // 
            this.DlvCTransportadora.AspectName = "Veiculo_Transportadora";
            this.DlvCTransportadora.Text = "Transportadora";
            this.DlvCTransportadora.Width = 131;
            // 
            // ListagemAbertos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_fechar_form;
            this.ClientSize = new System.Drawing.Size(624, 421);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "ListagemAbertos";
            this.ShowIcon = false;
            this.Text = "Tickets Abertos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListagemAbertos_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private BrightIdeasSoftware.DataListView dlvDados;
        private BrightIdeasSoftware.OLVColumn dlv_c_codigo;
        private BrightIdeasSoftware.OLVColumn dlv_c_tipo;
        private BrightIdeasSoftware.OLVColumn dlv_c_data;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNovaPesagem;
        private System.Windows.Forms.ToolStripButton tsbConcluirPesagem;
        private System.Windows.Forms.ToolStripButton tsbExcluirPesagem;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbFechar;
        private System.Windows.Forms.Button btn_fechar_form;
        private BrightIdeasSoftware.OLVColumn dlv_c_placa;
        private BrightIdeasSoftware.OLVColumn dlv_c_status;
        private BrightIdeasSoftware.OLVColumn DlvCTransportadora;
    }
}