namespace ORCAMENTOS_FOCKINK
{
    partial class frmBuscaClientes
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
            this.txtDadosCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarClientes = new System.Windows.Forms.Button();
            this.dgvListaClientes = new System.Windows.Forms.DataGridView();
            this.CodCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGC_CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidade_uf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_representante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirmaCliente = new System.Windows.Forms.Button();
            this.lblBuscaCliInformacao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDadosCliente
            // 
            this.txtDadosCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDadosCliente.Location = new System.Drawing.Point(79, 38);
            this.txtDadosCliente.MaxLength = 20;
            this.txtDadosCliente.Name = "txtDadosCliente";
            this.txtDadosCliente.Size = new System.Drawing.Size(227, 20);
            this.txtDadosCliente.TabIndex = 0;
            this.txtDadosCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDadosCliente_KeyPress);
            // 
            // btnBuscarClientes
            // 
            this.btnBuscarClientes.Location = new System.Drawing.Point(333, 36);
            this.btnBuscarClientes.Name = "btnBuscarClientes";
            this.btnBuscarClientes.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarClientes.TabIndex = 1;
            this.btnBuscarClientes.Text = "Buscar";
            this.btnBuscarClientes.UseVisualStyleBackColor = true;
            this.btnBuscarClientes.Click += new System.EventHandler(this.btnBuscarClientes_Click);
            // 
            // dgvListaClientes
            // 
            this.dgvListaClientes.AllowUserToAddRows = false;
            this.dgvListaClientes.AllowUserToDeleteRows = false;
            this.dgvListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodCli,
            this.RazSocial,
            this.CGC_CPF,
            this.IE,
            this.cidade_uf,
            this.cod_representante});
            this.dgvListaClientes.Location = new System.Drawing.Point(6, 64);
            this.dgvListaClientes.MultiSelect = false;
            this.dgvListaClientes.Name = "dgvListaClientes";
            this.dgvListaClientes.ReadOnly = true;
            this.dgvListaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaClientes.Size = new System.Drawing.Size(568, 217);
            this.dgvListaClientes.TabIndex = 2;
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
            // cod_representante
            // 
            this.cod_representante.DataPropertyName = "cod_representante";
            this.cod_representante.HeaderText = "Cód. Representante";
            this.cod_representante.Name = "cod_representante";
            this.cod_representante.ReadOnly = true;
            this.cod_representante.Visible = false;
            // 
            // btnConfirmaCliente
            // 
            this.btnConfirmaCliente.Location = new System.Drawing.Point(258, 287);
            this.btnConfirmaCliente.Name = "btnConfirmaCliente";
            this.btnConfirmaCliente.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmaCliente.TabIndex = 3;
            this.btnConfirmaCliente.Text = "Confirmar";
            this.btnConfirmaCliente.UseVisualStyleBackColor = true;
            this.btnConfirmaCliente.Click += new System.EventHandler(this.btnConfirmaCliente_Click);
            // 
            // lblBuscaCliInformacao
            // 
            this.lblBuscaCliInformacao.AutoSize = true;
            this.lblBuscaCliInformacao.ForeColor = System.Drawing.Color.Red;
            this.lblBuscaCliInformacao.Location = new System.Drawing.Point(12, 9);
            this.lblBuscaCliInformacao.Name = "lblBuscaCliInformacao";
            this.lblBuscaCliInformacao.Size = new System.Drawing.Size(242, 13);
            this.lblBuscaCliInformacao.TabIndex = 4;
            this.lblBuscaCliInformacao.Text = "* Busca pelo Código, Razão Social ou CPF/CNPJ";
            // 
            // frmBuscaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 320);
            this.Controls.Add(this.lblBuscaCliInformacao);
            this.Controls.Add(this.btnConfirmaCliente);
            this.Controls.Add(this.dgvListaClientes);
            this.Controls.Add(this.btnBuscarClientes);
            this.Controls.Add(this.txtDadosCliente);
            this.Name = "frmBuscaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOEF - BUSCA CLIENTES";
            this.Load += new System.EventHandler(this.frmBuscaClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDadosCliente;
        private System.Windows.Forms.Button btnBuscarClientes;
        private System.Windows.Forms.DataGridView dgvListaClientes;
        private System.Windows.Forms.Button btnConfirmaCliente;
        private System.Windows.Forms.Label lblBuscaCliInformacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGC_CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn IE;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidade_uf;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_representante;
    }
}