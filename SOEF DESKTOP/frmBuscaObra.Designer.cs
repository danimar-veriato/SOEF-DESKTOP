namespace ORCAMENTOS_FOCKINK
{
    partial class frmBuscaObra
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
            this.lblBuscaCliInformacao = new System.Windows.Forms.Label();
            this.btnConfirmaCliente = new System.Windows.Forms.Button();
            this.dgvListaObra = new System.Windows.Forms.DataGridView();
            this.CodCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGC_CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidade_uf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarClientes = new System.Windows.Forms.Button();
            this.txtDadosObra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaObra)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBuscaCliInformacao
            // 
            this.lblBuscaCliInformacao.AutoSize = true;
            this.lblBuscaCliInformacao.ForeColor = System.Drawing.Color.Red;
            this.lblBuscaCliInformacao.Location = new System.Drawing.Point(-60, -22);
            this.lblBuscaCliInformacao.Name = "lblBuscaCliInformacao";
            this.lblBuscaCliInformacao.Size = new System.Drawing.Size(242, 13);
            this.lblBuscaCliInformacao.TabIndex = 9;
            this.lblBuscaCliInformacao.Text = "* Busca pelo Código, Razão Social ou CPF/CNPJ";
            // 
            // btnConfirmaCliente
            // 
            this.btnConfirmaCliente.Location = new System.Drawing.Point(274, 305);
            this.btnConfirmaCliente.Name = "btnConfirmaCliente";
            this.btnConfirmaCliente.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmaCliente.TabIndex = 8;
            this.btnConfirmaCliente.Text = "Confirmar";
            this.btnConfirmaCliente.UseVisualStyleBackColor = true;
            this.btnConfirmaCliente.Click += new System.EventHandler(this.btnConfirmaCliente_Click);
            // 
            // dgvListaObra
            // 
            this.dgvListaObra.AllowUserToAddRows = false;
            this.dgvListaObra.AllowUserToDeleteRows = false;
            this.dgvListaObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaObra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodCli,
            this.RazSocial,
            this.CGC_CPF,
            this.IE,
            this.cidade_uf});
            this.dgvListaObra.Location = new System.Drawing.Point(12, 61);
            this.dgvListaObra.MultiSelect = false;
            this.dgvListaObra.Name = "dgvListaObra";
            this.dgvListaObra.ReadOnly = true;
            this.dgvListaObra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaObra.Size = new System.Drawing.Size(582, 232);
            this.dgvListaObra.TabIndex = 7;
            // 
            // CodCli
            // 
            this.CodCli.DataPropertyName = "COD_CLIENTE";
            this.CodCli.HeaderText = "Código";
            this.CodCli.Name = "CodCli";
            this.CodCli.ReadOnly = true;
            this.CodCli.Width = 80;
            // 
            // RazSocial
            // 
            this.RazSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RazSocial.DataPropertyName = "RAZAO_SOCIAL";
            this.RazSocial.HeaderText = "Razão Social";
            this.RazSocial.Name = "RazSocial";
            this.RazSocial.ReadOnly = true;
            this.RazSocial.Width = 87;
            // 
            // CGC_CPF
            // 
            this.CGC_CPF.DataPropertyName = "CGC_CPF";
            this.CGC_CPF.HeaderText = "CPF/CNPJ";
            this.CGC_CPF.Name = "CGC_CPF";
            this.CGC_CPF.ReadOnly = true;
            // 
            // IE
            // 
            this.IE.DataPropertyName = "INSCRICAO_ESTADUAL";
            this.IE.HeaderText = "Inscrição Estadual";
            this.IE.Name = "IE";
            this.IE.ReadOnly = true;
            // 
            // cidade_uf
            // 
            this.cidade_uf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cidade_uf.DataPropertyName = "CIDADE";
            this.cidade_uf.HeaderText = "Cidade - UF";
            this.cidade_uf.Name = "cidade_uf";
            this.cidade_uf.ReadOnly = true;
            this.cidade_uf.Width = 69;
            // 
            // btnBuscarClientes
            // 
            this.btnBuscarClientes.Location = new System.Drawing.Point(339, 30);
            this.btnBuscarClientes.Name = "btnBuscarClientes";
            this.btnBuscarClientes.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarClientes.TabIndex = 6;
            this.btnBuscarClientes.Text = "Buscar";
            this.btnBuscarClientes.UseVisualStyleBackColor = true;
            this.btnBuscarClientes.Click += new System.EventHandler(this.btnBuscarClientes_Click);
            // 
            // txtDadosObra
            // 
            this.txtDadosObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDadosObra.Location = new System.Drawing.Point(85, 32);
            this.txtDadosObra.MaxLength = 20;
            this.txtDadosObra.Name = "txtDadosObra";
            this.txtDadosObra.Size = new System.Drawing.Size(227, 20);
            this.txtDadosObra.TabIndex = 5;
            this.txtDadosObra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDadosObra_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "* Busca pelo Código, Razão Social ou CNPJ";
            // 
            // frmBuscaObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 340);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBuscaCliInformacao);
            this.Controls.Add(this.btnConfirmaCliente);
            this.Controls.Add(this.dgvListaObra);
            this.Controls.Add(this.btnBuscarClientes);
            this.Controls.Add(this.txtDadosObra);
            this.Name = "frmBuscaObra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOEF - Busca Informações da Obra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaObra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBuscaCliInformacao;
        private System.Windows.Forms.Button btnConfirmaCliente;
        private System.Windows.Forms.DataGridView dgvListaObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGC_CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn IE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidade_uf;
        private System.Windows.Forms.Button btnBuscarClientes;
        private System.Windows.Forms.TextBox txtDadosObra;
        private System.Windows.Forms.Label label1;
    }
}