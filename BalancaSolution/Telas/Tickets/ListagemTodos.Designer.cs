namespace BalancaSolution.Telas.Tickets
{
    partial class ListagemTodos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListagemTodos));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNovaPesagem = new System.Windows.Forms.ToolStripButton();
            this.BtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.BtnImprimir = new System.Windows.Forms.ToolStripButton();
            this.BtnVisualizarImpressao = new System.Windows.Forms.ToolStripButton();
            this.BtnFechar = new System.Windows.Forms.ToolStripButton();
            this.dlvDados = new BrightIdeasSoftware.DataListView();
            this.DlvCCodigo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DlvCPlaca = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DlvCTipo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DlvCData = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DlvCStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DlvCTransportadora = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DlvCObservacao = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BtnFecharForm = new System.Windows.Forms.Button();
            this.btnVisualizarTicket = new System.Windows.Forms.ToolStripButton();
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
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
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
            this.splitContainer1.Panel2.Controls.Add(this.BtnFecharForm);
            this.splitContainer1.Size = new System.Drawing.Size(773, 447);
            this.splitContainer1.SplitterDistance = 29;
            this.splitContainer1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNovaPesagem,
            this.btnVisualizarTicket,
            this.BtnRefresh,
            this.BtnImprimir,
            this.BtnVisualizarImpressao,
            this.BtnFechar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(773, 29);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNovaPesagem
            // 
            this.BtnNovaPesagem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnNovaPesagem.Image = ((System.Drawing.Image)(resources.GetObject("BtnNovaPesagem.Image")));
            this.BtnNovaPesagem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNovaPesagem.Name = "BtnNovaPesagem";
            this.BtnNovaPesagem.Size = new System.Drawing.Size(90, 26);
            this.BtnNovaPesagem.Text = "Nova pesagem";
            this.BtnNovaPesagem.Click += new System.EventHandler(this.BtnNovaPesagem_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.Image")));
            this.BtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(57, 26);
            this.BtnRefresh.Text = "Atualizar";
            this.BtnRefresh.Click += new System.EventHandler(this.TsbBtnRefresh_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Image")));
            this.BtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(57, 26);
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.Click += new System.EventHandler(this.TsbImprimir_Click);
            // 
            // BtnVisualizarImpressao
            // 
            this.BtnVisualizarImpressao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnVisualizarImpressao.Image = ((System.Drawing.Image)(resources.GetObject("BtnVisualizarImpressao.Image")));
            this.BtnVisualizarImpressao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnVisualizarImpressao.Name = "BtnVisualizarImpressao";
            this.BtnVisualizarImpressao.Size = new System.Drawing.Size(117, 26);
            this.BtnVisualizarImpressao.Text = "Visualizar impressão";
            this.BtnVisualizarImpressao.Click += new System.EventHandler(this.BtnVisualizarImpressao_Click);
            // 
            // BtnFechar
            // 
            this.BtnFechar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnFechar.Image = ((System.Drawing.Image)(resources.GetObject("BtnFechar.Image")));
            this.BtnFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnFechar.Name = "BtnFechar";
            this.BtnFechar.Size = new System.Drawing.Size(46, 26);
            this.BtnFechar.Text = "Fechar";
            this.BtnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // dlvDados
            // 
            this.dlvDados.AllColumns.Add(this.DlvCCodigo);
            this.dlvDados.AllColumns.Add(this.DlvCPlaca);
            this.dlvDados.AllColumns.Add(this.DlvCTipo);
            this.dlvDados.AllColumns.Add(this.DlvCData);
            this.dlvDados.AllColumns.Add(this.DlvCStatus);
            this.dlvDados.AllColumns.Add(this.DlvCTransportadora);
            this.dlvDados.AllColumns.Add(this.DlvCObservacao);
            this.dlvDados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DlvCCodigo,
            this.DlvCPlaca,
            this.DlvCTipo,
            this.DlvCData,
            this.DlvCStatus,
            this.DlvCTransportadora,
            this.DlvCObservacao});
            this.dlvDados.DataSource = null;
            this.dlvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvDados.FullRowSelect = true;
            this.dlvDados.GridLines = true;
            this.dlvDados.Location = new System.Drawing.Point(0, 0);
            this.dlvDados.MultiSelect = false;
            this.dlvDados.Name = "dlvDados";
            this.dlvDados.ShowGroups = false;
            this.dlvDados.Size = new System.Drawing.Size(773, 414);
            this.dlvDados.TabIndex = 0;
            this.dlvDados.UseCompatibleStateImageBehavior = false;
            this.dlvDados.View = System.Windows.Forms.View.Details;
            this.dlvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DlvDados_MouseDoubleClick);
            // 
            // DlvCCodigo
            // 
            this.DlvCCodigo.AspectName = "Codigo";
            this.DlvCCodigo.IsEditable = false;
            this.DlvCCodigo.Text = "Codigo";
            this.DlvCCodigo.Width = 100;
            // 
            // DlvCPlaca
            // 
            this.DlvCPlaca.AspectName = "Veiculo_Placa";
            this.DlvCPlaca.Text = "Placa";
            this.DlvCPlaca.Width = 90;
            // 
            // DlvCTipo
            // 
            this.DlvCTipo.AspectName = "Tipo";
            this.DlvCTipo.IsEditable = false;
            this.DlvCTipo.Text = "Tipo";
            // 
            // DlvCData
            // 
            this.DlvCData.AspectName = "Data";
            this.DlvCData.IsEditable = false;
            this.DlvCData.Text = "Data";
            this.DlvCData.Width = 140;
            // 
            // DlvCStatus
            // 
            this.DlvCStatus.AspectName = "Status";
            this.DlvCStatus.Text = "Status";
            // 
            // DlvCTransportadora
            // 
            this.DlvCTransportadora.AspectName = "Veiculo_Transportadora";
            this.DlvCTransportadora.Text = "Trasnportadora";
            this.DlvCTransportadora.Width = 127;
            // 
            // DlvCObservacao
            // 
            this.DlvCObservacao.AspectName = "Observacao";
            this.DlvCObservacao.Text = "Observação";
            this.DlvCObservacao.Width = 150;
            // 
            // BtnFecharForm
            // 
            this.BtnFecharForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnFecharForm.Location = new System.Drawing.Point(420, 86);
            this.BtnFecharForm.Name = "BtnFecharForm";
            this.BtnFecharForm.Size = new System.Drawing.Size(75, 23);
            this.BtnFecharForm.TabIndex = 2;
            this.BtnFecharForm.Text = "button1";
            this.BtnFecharForm.UseVisualStyleBackColor = true;
            this.BtnFecharForm.Click += new System.EventHandler(this.BtnFecharForm_Click);
            // 
            // btnVisualizarTicket
            // 
            this.btnVisualizarTicket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnVisualizarTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualizarTicket.Image")));
            this.btnVisualizarTicket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVisualizarTicket.Name = "btnVisualizarTicket";
            this.btnVisualizarTicket.Size = new System.Drawing.Size(95, 26);
            this.btnVisualizarTicket.Text = "Visualizar Ticket";
            this.btnVisualizarTicket.Click += new System.EventHandler(this.btnVisualizarTicket_Click);
            // 
            // ListagemTodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnFecharForm;
            this.ClientSize = new System.Drawing.Size(773, 447);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "ListagemTodos";
            this.ShowIcon = false;
            this.Text = "Tickets";
            this.Load += new System.EventHandler(this.ListagemTodos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListagemTodos_KeyDown);
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
        private BrightIdeasSoftware.OLVColumn DlvCCodigo;
        private BrightIdeasSoftware.OLVColumn DlvCTipo;
        private BrightIdeasSoftware.OLVColumn DlvCData;
        private BrightIdeasSoftware.OLVColumn DlvCStatus;
        private BrightIdeasSoftware.OLVColumn DlvCObservacao;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNovaPesagem;
        private System.Windows.Forms.ToolStripButton BtnRefresh;
        private System.Windows.Forms.ToolStripButton BtnImprimir;
        private System.Windows.Forms.ToolStripButton BtnVisualizarImpressao;
        private System.Windows.Forms.ToolStripButton BtnFechar;
        private System.Windows.Forms.Button BtnFecharForm;
        private BrightIdeasSoftware.OLVColumn DlvCPlaca;
        private BrightIdeasSoftware.OLVColumn DlvCTransportadora;
        private System.Windows.Forms.ToolStripButton btnVisualizarTicket;
    }
}