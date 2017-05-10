namespace ORCAMENTOS_FOCKINK
{
    partial class frmBuscaContatos
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
            this.dgvListaContatos = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEFONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CELULAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarContato = new System.Windows.Forms.Button();
            this.txtBuscaContato = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaContatos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBuscaCliInformacao
            // 
            this.lblBuscaCliInformacao.AutoSize = true;
            this.lblBuscaCliInformacao.ForeColor = System.Drawing.Color.Red;
            this.lblBuscaCliInformacao.Location = new System.Drawing.Point(-20, -16);
            this.lblBuscaCliInformacao.Name = "lblBuscaCliInformacao";
            this.lblBuscaCliInformacao.Size = new System.Drawing.Size(242, 13);
            this.lblBuscaCliInformacao.TabIndex = 9;
            this.lblBuscaCliInformacao.Text = "* Busca pelo Código, Razão Social ou CPF/CNPJ";
            // 
            // btnConfirmaCliente
            // 
            this.btnConfirmaCliente.Location = new System.Drawing.Point(257, 289);
            this.btnConfirmaCliente.Name = "btnConfirmaCliente";
            this.btnConfirmaCliente.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmaCliente.TabIndex = 8;
            this.btnConfirmaCliente.Text = "Confirmar";
            this.btnConfirmaCliente.UseVisualStyleBackColor = true;
            this.btnConfirmaCliente.Click += new System.EventHandler(this.btnConfirmaCliente_Click);
            // 
            // dgvListaContatos
            // 
            this.dgvListaContatos.AllowUserToAddRows = false;
            this.dgvListaContatos.AllowUserToDeleteRows = false;
            this.dgvListaContatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaContatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.Nome,
            this.TELEFONE,
            this.CELULAR,
            this.EMAIL});
            this.dgvListaContatos.Location = new System.Drawing.Point(10, 66);
            this.dgvListaContatos.MultiSelect = false;
            this.dgvListaContatos.Name = "dgvListaContatos";
            this.dgvListaContatos.ReadOnly = true;
            this.dgvListaContatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaContatos.Size = new System.Drawing.Size(558, 217);
            this.dgvListaContatos.TabIndex = 7;
            // 
            // CODIGO
            // 
            this.CODIGO.DataPropertyName = "CODIGO";
            this.CODIGO.HeaderText = "Código";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            this.CODIGO.Width = 80;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nome.DataPropertyName = "NOME";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 60;
            // 
            // TELEFONE
            // 
            this.TELEFONE.DataPropertyName = "FONE";
            this.TELEFONE.HeaderText = "TELEFONE";
            this.TELEFONE.Name = "TELEFONE";
            this.TELEFONE.ReadOnly = true;
            // 
            // CELULAR
            // 
            this.CELULAR.DataPropertyName = "CELULAR";
            this.CELULAR.HeaderText = "CELULAR";
            this.CELULAR.Name = "CELULAR";
            this.CELULAR.ReadOnly = true;
            // 
            // EMAIL
            // 
            this.EMAIL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EMAIL.DataPropertyName = "EMAIL";
            this.EMAIL.HeaderText = "E-MAIL";
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.ReadOnly = true;
            this.EMAIL.Width = 67;
            // 
            // btnBuscarContato
            // 
            this.btnBuscarContato.Location = new System.Drawing.Point(359, 38);
            this.btnBuscarContato.Name = "btnBuscarContato";
            this.btnBuscarContato.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarContato.TabIndex = 6;
            this.btnBuscarContato.Text = "Buscar";
            this.btnBuscarContato.UseVisualStyleBackColor = true;
            this.btnBuscarContato.Click += new System.EventHandler(this.btnBuscarContato_Click);
            // 
            // txtBuscaContato
            // 
            this.txtBuscaContato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscaContato.Location = new System.Drawing.Point(105, 40);
            this.txtBuscaContato.MaxLength = 20;
            this.txtBuscaContato.Name = "txtBuscaContato";
            this.txtBuscaContato.Size = new System.Drawing.Size(227, 20);
            this.txtBuscaContato.TabIndex = 5;
            this.txtBuscaContato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaContato_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "* Busca pelo Código ou Nome do contato";
            // 
            // frmBuscaContatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 321);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBuscaCliInformacao);
            this.Controls.Add(this.btnConfirmaCliente);
            this.Controls.Add(this.dgvListaContatos);
            this.Controls.Add(this.btnBuscarContato);
            this.Controls.Add(this.txtBuscaContato);
            this.Name = "frmBuscaContatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEOEF - Busca Contatos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaContatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBuscaCliInformacao;
        private System.Windows.Forms.Button btnConfirmaCliente;
        private System.Windows.Forms.DataGridView dgvListaContatos;
        private System.Windows.Forms.Button btnBuscarContato;
        private System.Windows.Forms.TextBox txtBuscaContato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEFONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CELULAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
    }
}