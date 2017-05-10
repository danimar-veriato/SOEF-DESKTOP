namespace ORCAMENTOS_FOCKINK
{
    partial class frmBuscaSolicitacao
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnBuscaPendentes = new System.Windows.Forms.RadioButton();
            this.rbtnBuscaEnviadas = new System.Windows.Forms.RadioButton();
            this.rbtnBuscaTodas = new System.Windows.Forms.RadioButton();
            this.btnBuscaSolic = new System.Windows.Forms.Button();
            this.dgvListaSolicitacoes = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.negocio_associado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_estimado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acao = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBuscaVoltar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSolicitacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbtnBuscaPendentes);
            this.panel1.Controls.Add(this.rbtnBuscaEnviadas);
            this.panel1.Controls.Add(this.rbtnBuscaTodas);
            this.panel1.Controls.Add(this.btnBuscaSolic);
            this.panel1.Location = new System.Drawing.Point(242, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 35);
            this.panel1.TabIndex = 0;
            // 
            // rbtnBuscaPendentes
            // 
            this.rbtnBuscaPendentes.AutoSize = true;
            this.rbtnBuscaPendentes.Location = new System.Drawing.Point(197, 9);
            this.rbtnBuscaPendentes.Name = "rbtnBuscaPendentes";
            this.rbtnBuscaPendentes.Size = new System.Drawing.Size(76, 17);
            this.rbtnBuscaPendentes.TabIndex = 9;
            this.rbtnBuscaPendentes.TabStop = true;
            this.rbtnBuscaPendentes.Text = "Pendentes";
            this.rbtnBuscaPendentes.UseVisualStyleBackColor = true;
            // 
            // rbtnBuscaEnviadas
            // 
            this.rbtnBuscaEnviadas.AutoSize = true;
            this.rbtnBuscaEnviadas.Location = new System.Drawing.Point(103, 9);
            this.rbtnBuscaEnviadas.Name = "rbtnBuscaEnviadas";
            this.rbtnBuscaEnviadas.Size = new System.Drawing.Size(69, 17);
            this.rbtnBuscaEnviadas.TabIndex = 8;
            this.rbtnBuscaEnviadas.TabStop = true;
            this.rbtnBuscaEnviadas.Text = "Enviadas";
            this.rbtnBuscaEnviadas.UseVisualStyleBackColor = true;
            // 
            // rbtnBuscaTodas
            // 
            this.rbtnBuscaTodas.AutoSize = true;
            this.rbtnBuscaTodas.Checked = true;
            this.rbtnBuscaTodas.Location = new System.Drawing.Point(20, 9);
            this.rbtnBuscaTodas.Name = "rbtnBuscaTodas";
            this.rbtnBuscaTodas.Size = new System.Drawing.Size(55, 17);
            this.rbtnBuscaTodas.TabIndex = 7;
            this.rbtnBuscaTodas.TabStop = true;
            this.rbtnBuscaTodas.Text = "Todas";
            this.rbtnBuscaTodas.UseVisualStyleBackColor = true;
            // 
            // btnBuscaSolic
            // 
            this.btnBuscaSolic.Location = new System.Drawing.Point(327, 6);
            this.btnBuscaSolic.Name = "btnBuscaSolic";
            this.btnBuscaSolic.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaSolic.TabIndex = 6;
            this.btnBuscaSolic.Text = "Buscar";
            this.btnBuscaSolic.UseVisualStyleBackColor = true;
            this.btnBuscaSolic.Click += new System.EventHandler(this.btnBuscaSolic_Click);
            // 
            // dgvListaSolicitacoes
            // 
            this.dgvListaSolicitacoes.AllowUserToAddRows = false;
            this.dgvListaSolicitacoes.AllowUserToDeleteRows = false;
            this.dgvListaSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaSolicitacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.status,
            this.cliente,
            this.negocio_associado,
            this.empresa,
            this.valor_estimado,
            this.acao});
            this.dgvListaSolicitacoes.Location = new System.Drawing.Point(31, 53);
            this.dgvListaSolicitacoes.MultiSelect = false;
            this.dgvListaSolicitacoes.Name = "dgvListaSolicitacoes";
            this.dgvListaSolicitacoes.Size = new System.Drawing.Size(935, 490);
            this.dgvListaSolicitacoes.TabIndex = 1;
            this.dgvListaSolicitacoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaSolicitacoes_CellContentClick);
            // 
            // numero
            // 
            this.numero.DataPropertyName = "numero";
            this.numero.HeaderText = "Número";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 70;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 70;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "cliente";
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 375;
            // 
            // negocio_associado
            // 
            this.negocio_associado.DataPropertyName = "negocio_associado";
            this.negocio_associado.HeaderText = "Negócio";
            this.negocio_associado.Name = "negocio_associado";
            this.negocio_associado.ReadOnly = true;
            // 
            // empresa
            // 
            this.empresa.DataPropertyName = "empresa";
            this.empresa.HeaderText = "Empresa";
            this.empresa.Name = "empresa";
            this.empresa.ReadOnly = true;
            this.empresa.Width = 70;
            // 
            // valor_estimado
            // 
            this.valor_estimado.DataPropertyName = "valor_estimado";
            this.valor_estimado.HeaderText = "Valor Estimado";
            this.valor_estimado.Name = "valor_estimado";
            this.valor_estimado.ReadOnly = true;
            // 
            // acao
            // 
            this.acao.HeaderText = "";
            this.acao.Name = "acao";
            this.acao.Text = "Editar";
            this.acao.ToolTipText = "Editar Registro";
            this.acao.UseColumnTextForButtonValue = true;
            // 
            // btnBuscaVoltar
            // 
            this.btnBuscaVoltar.Location = new System.Drawing.Point(31, 568);
            this.btnBuscaVoltar.Name = "btnBuscaVoltar";
            this.btnBuscaVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaVoltar.TabIndex = 3;
            this.btnBuscaVoltar.Text = "Voltar";
            this.btnBuscaVoltar.UseVisualStyleBackColor = true;
            this.btnBuscaVoltar.Click += new System.EventHandler(this.btnBuscaVoltar_Click);
            // 
            // frmBuscaSolicitacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.btnBuscaVoltar);
            this.Controls.Add(this.dgvListaSolicitacoes);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmBuscaSolicitacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOEF - BUSCA SOLICITAÇÃO";
            this.Load += new System.EventHandler(this.frmBuscaSolicitacao_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSolicitacoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscaSolic;
        private System.Windows.Forms.DataGridView dgvListaSolicitacoes;
        private System.Windows.Forms.Button btnBuscaVoltar;
        private System.Windows.Forms.RadioButton rbtnBuscaPendentes;
        private System.Windows.Forms.RadioButton rbtnBuscaEnviadas;
        private System.Windows.Forms.RadioButton rbtnBuscaTodas;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn negocio_associado;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_estimado;
        private System.Windows.Forms.DataGridViewButtonColumn acao;
    }
}