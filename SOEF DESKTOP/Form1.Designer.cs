namespace ORCAMENTOS_FOCKINK
{
    partial class Form1
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
            this.btnIncluir = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dpes_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empr_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone_ramal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celular_ddd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bntAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(171, 313);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 0;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.dpes_codigo,
            this.empr_codigo,
            this.nome,
            this.setor,
            this.cargo,
            this.ddd,
            this.telefone,
            this.telefone_ramal,
            this.celular_ddd,
            this.num_celular,
            this.EMAIL,
            this.ATIVO});
            this.dgvLista.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.dgvLista.Location = new System.Drawing.Point(3, 12);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(445, 279);
            this.dgvLista.TabIndex = 11;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "CODIGO";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 75;
            // 
            // dpes_codigo
            // 
            this.dpes_codigo.DataPropertyName = "DPES_CODIGO";
            this.dpes_codigo.HeaderText = "DPES_CODIGO";
            this.dpes_codigo.Name = "dpes_codigo";
            this.dpes_codigo.Width = 160;
            // 
            // empr_codigo
            // 
            this.empr_codigo.DataPropertyName = "EMPR_CODIGO";
            this.empr_codigo.HeaderText = "EMPR_CODIGO";
            this.empr_codigo.Name = "empr_codigo";
            this.empr_codigo.Width = 160;
            // 
            // nome
            // 
            this.nome.DataPropertyName = "NOME";
            this.nome.HeaderText = "NOME";
            this.nome.Name = "nome";
            this.nome.Width = 400;
            // 
            // setor
            // 
            this.setor.DataPropertyName = "SETOR";
            this.setor.HeaderText = "SETOR";
            this.setor.Name = "setor";
            // 
            // cargo
            // 
            this.cargo.DataPropertyName = "CARGO";
            this.cargo.HeaderText = "CARGO";
            this.cargo.Name = "cargo";
            // 
            // ddd
            // 
            this.ddd.DataPropertyName = "DDD";
            this.ddd.HeaderText = "DDD";
            this.ddd.Name = "ddd";
            // 
            // telefone
            // 
            this.telefone.DataPropertyName = "TELEFONE";
            this.telefone.HeaderText = "TELEFONE";
            this.telefone.Name = "telefone";
            // 
            // telefone_ramal
            // 
            this.telefone_ramal.DataPropertyName = "TELEFONE_RAMAL";
            this.telefone_ramal.HeaderText = "TELEFONE_RAMAL";
            this.telefone_ramal.Name = "telefone_ramal";
            // 
            // celular_ddd
            // 
            this.celular_ddd.DataPropertyName = "CELULAR_DDD";
            this.celular_ddd.HeaderText = "CELULAR_DDD";
            this.celular_ddd.Name = "celular_ddd";
            // 
            // num_celular
            // 
            this.num_celular.DataPropertyName = "CELULAR";
            this.num_celular.HeaderText = "CELULAR";
            this.num_celular.Name = "num_celular";
            // 
            // EMAIL
            // 
            this.EMAIL.DataPropertyName = "email";
            this.EMAIL.HeaderText = "EMAIL";
            this.EMAIL.Name = "EMAIL";
            // 
            // ATIVO
            // 
            this.ATIVO.DataPropertyName = "ATIVO";
            this.ATIVO.HeaderText = "ATIVO";
            this.ATIVO.Name = "ATIVO";
            // 
            // bntAtualizar
            // 
            this.bntAtualizar.Location = new System.Drawing.Point(274, 313);
            this.bntAtualizar.Name = "bntAtualizar";
            this.bntAtualizar.Size = new System.Drawing.Size(75, 23);
            this.bntAtualizar.TabIndex = 12;
            this.bntAtualizar.Text = "Atualizar";
            this.bntAtualizar.UseVisualStyleBackColor = true;
            this.bntAtualizar.Click += new System.EventHandler(this.bntAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(382, 313);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 13;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(579, 313);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 14;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(454, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(410, 279);
            this.dataGridView1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 346);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.bntAtualizar);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.btnIncluir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Button bntAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dpes_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn empr_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn setor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddd;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone_ramal;
        private System.Windows.Forms.DataGridViewTextBoxColumn celular_ddd;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATIVO;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

