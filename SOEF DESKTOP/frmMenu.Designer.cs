namespace ORCAMENTOS_FOCKINK
{
    partial class frmMenu
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
            this.toolStripStatusLabel0 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuarioLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEmprLogada = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLoading = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.orçamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaSolicitaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSolicitaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mudarDeDivisãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarSolicitaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel0
            // 
            this.toolStripStatusLabel0.Name = "toolStripStatusLabel0";
            this.toolStripStatusLabel0.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabel0.Text = "USUÁRIO: ";
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.Margin = new System.Windows.Forms.Padding(-6, 3, 0, 2);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(12, 17);
            this.lblUsuarioLogado.Text = "-";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel1.Text = "EMPRESA:";
            // 
            // lblEmprLogada
            // 
            this.lblEmprLogada.Name = "lblEmprLogada";
            this.lblEmprLogada.Size = new System.Drawing.Size(12, 17);
            this.lblEmprLogada.Text = "-";
            // 
            // lblLoading
            // 
            this.lblLoading.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoading.ForeColor = System.Drawing.Color.Red;
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel0,
            this.lblUsuarioLogado,
            this.toolStripStatusLabel1,
            this.lblEmprLogada,
            this.lblLoading});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orçamentosToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.form1ToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1008, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // orçamentosToolStripMenuItem
            // 
            this.orçamentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaSolicitaçãoToolStripMenuItem,
            this.consultarSolicitaçãoToolStripMenuItem});
            this.orçamentosToolStripMenuItem.Name = "orçamentosToolStripMenuItem";
            this.orçamentosToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.orçamentosToolStripMenuItem.Text = "Orçamentos";
            // 
            // novaSolicitaçãoToolStripMenuItem
            // 
            this.novaSolicitaçãoToolStripMenuItem.Name = "novaSolicitaçãoToolStripMenuItem";
            this.novaSolicitaçãoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.novaSolicitaçãoToolStripMenuItem.Text = "Nova Solicitação";
            this.novaSolicitaçãoToolStripMenuItem.Click += new System.EventHandler(this.novaSolicitaçãoToolStripMenuItem_Click);
            // 
            // consultarSolicitaçãoToolStripMenuItem
            // 
            this.consultarSolicitaçãoToolStripMenuItem.Name = "consultarSolicitaçãoToolStripMenuItem";
            this.consultarSolicitaçãoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.consultarSolicitaçãoToolStripMenuItem.Text = "Consultar Solicitação";
            this.consultarSolicitaçãoToolStripMenuItem.Click += new System.EventHandler(this.consultarSolicitaçãoToolStripMenuItem_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mudarDeDivisãoToolStripMenuItem,
            this.enviarSolicitaçõesToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // mudarDeDivisãoToolStripMenuItem
            // 
            this.mudarDeDivisãoToolStripMenuItem.Name = "mudarDeDivisãoToolStripMenuItem";
            this.mudarDeDivisãoToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.mudarDeDivisãoToolStripMenuItem.Text = "Sincronizar base de dados";
            this.mudarDeDivisãoToolStripMenuItem.Click += new System.EventHandler(this.mudarDeDivisãoToolStripMenuItem_Click);
            // 
            // enviarSolicitaçõesToolStripMenuItem
            // 
            this.enviarSolicitaçõesToolStripMenuItem.Name = "enviarSolicitaçõesToolStripMenuItem";
            this.enviarSolicitaçõesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.enviarSolicitaçõesToolStripMenuItem.Text = "Enviar Solicitações";
            // 
            // form1ToolStripMenuItem
            // 
            this.form1ToolStripMenuItem.Name = "form1ToolStripMenuItem";
            this.form1ToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.form1ToolStripMenuItem.Text = "Sair";
            this.form1ToolStripMenuItem.Click += new System.EventHandler(this.form1ToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "SISTEMA DE ORÇAMENTOS ELÉTRICOS FOCKINK";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel0;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioLogado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblEmprLogada;
        private System.Windows.Forms.ToolStripStatusLabel lblLoading;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem orçamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaSolicitaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mudarDeDivisãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarSolicitaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarSolicitaçãoToolStripMenuItem;
    }
}