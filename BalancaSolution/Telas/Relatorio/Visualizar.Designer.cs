namespace BalancaSolution.Telas.Relatorio
{
    partial class Visualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualizar));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.btn_fechar = new System.Windows.Forms.ToolStripButton();
            this.wb_relatorio = new System.Windows.Forms.WebBrowser();
            this.btn_fechar_form = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btn_fechar_form);
            this.splitContainer1.Panel2.Controls.Add(this.wb_relatorio);
            this.splitContainer1.Size = new System.Drawing.Size(634, 485);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_imprimir,
            this.btn_fechar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(634, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_imprimir.Image")));
            this.btn_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(57, 22);
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_fechar.Image = ((System.Drawing.Image)(resources.GetObject("btn_fechar.Image")));
            this.btn_fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(46, 22);
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // wb_relatorio
            // 
            this.wb_relatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb_relatorio.Location = new System.Drawing.Point(0, 0);
            this.wb_relatorio.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_relatorio.Name = "wb_relatorio";
            this.wb_relatorio.Size = new System.Drawing.Size(634, 453);
            this.wb_relatorio.TabIndex = 0;
            // 
            // btn_fechar_form
            // 
            this.btn_fechar_form.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_fechar_form.Location = new System.Drawing.Point(515, 52);
            this.btn_fechar_form.Name = "btn_fechar_form";
            this.btn_fechar_form.Size = new System.Drawing.Size(75, 23);
            this.btn_fechar_form.TabIndex = 2;
            this.btn_fechar_form.Text = "button1";
            this.btn_fechar_form.UseVisualStyleBackColor = true;
            this.btn_fechar_form.Visible = false;
            this.btn_fechar_form.Click += new System.EventHandler(this.btn_fechar_form_Click);
            // 
            // Visualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_fechar_form;
            this.ClientSize = new System.Drawing.Size(634, 485);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Visualizar";
            this.Text = "Visualização de relatorio";
            this.Shown += new System.EventHandler(this.Visualizar_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Visualizar_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.WebBrowser wb_relatorio;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripButton btn_fechar;
        private System.Windows.Forms.Button btn_fechar_form;

    }
}