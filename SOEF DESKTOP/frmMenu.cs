using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORCAMENTOS_FOCKINK
{
    public partial class frmMenu : Form
    {
        protected string cod_representante; //Código do representante logado
        protected string empresa_logada; //Empresa logada

        public frmMenu()
        {
            InitializeComponent();
        }

        public void fechaForm()
        {
            this.Close();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente encerrar o sistema?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }            
        }



        /// <summary>
        ///Método que grava o usuário e a empresa logada no rodapé do menu principal
        /// </summary>
        /// <param name="p_usuario"></param>
        /// <param name="p_empr_codigo"></param>
        internal void gravaRodape(string p_usuario, string p_empr_codigo, string p_cod_representante)
        {
            lblUsuarioLogado.Text = p_usuario + "    |   ";
            string[] empr = p_empr_codigo.Split(' '); //Quebra a string e separa a empresa da descrição
            this.empresa_logada = empr[0];
            lblEmprLogada.Text = p_empr_codigo;
            //Grava o código do representante na variável local
            this.cod_representante = p_cod_representante;
        }

        internal void atualizaBases()
        {
            try
            {
                lblLoading.Text = "Atualizando base de dados...";
                AtualizaBases updateBases = new AtualizaBases();
                updateBases.atualizaContatos(this.empresa_logada, this.cod_representante); //Atualiza os contatos do representante
                updateBases.atualizaClientes(this.empresa_logada, this.cod_representante); //Atualiza a lista de clientes do representante
                updateBases.atualizaTipoNegocio(); //Atualiza lista de tipos de negócios - Cabeçalho Solicitação
                updateBases.atualizaIndicadorNegocio(this.empresa_logada); //Atualiza lista de indicador de negócios - Cabeçalho Solicitação
                updateBases.atualizaEventoPagamento();
                MessageBox.Show("Base de dados atualizada com sucesso.", "Sincronização de dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblLoading.Text = "";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }


        private void frmMenu_Load(object sender, EventArgs e)
        {
            //ManipulaBD mBD = new ManipulaBD();
            //dgvLista.DataSource = mBD.selectSOF("SELECT * FROM DOM_CLIENTE WHERE EMPR_CODIGO_REPRES = '" + label1.Text + "' AND COD_REPRESENTANTE = '" + label2.Text + "' ", "DOM_CLIENTE");
            //dataGridView1.DataSource = mBD.selectSOF("SELECT * FROM DOM_CONTATO"); 
        }

        private void mudarDeDivisãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja realmente atualizar a base de Clientes e Contatos?", "Sincronização base de dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //Verifica se o usuário está logado
                if (lblUsuarioLogado.Text == "-" && lblEmprLogada.Text == "-")
                {
                    frmLogin frmLog = new frmLogin();
                    this.Hide();
                    frmLog.ShowDialog();
                }
                else
                {
                    lblLoading.Text = "Atualizando base de dados...";
                    AtualizaBases updateBases = new AtualizaBases();
                    atualizaBases(); //Método que atualiza o banco de dados
                    MessageBox.Show("Base de dados atualizada com sucesso.", "Sincronização de dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblLoading.Text = "";
                }
            }
        }


        private void enviarSolicitaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void novaSolicitaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovaSolicitacao frmNS = new frmNovaSolicitacao("N", this.empresa_logada, this.cod_representante);
            this.Hide();
            frmNS.ShowDialog();
        }

        private void consultarSolicitaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmNovaSolicitacao frmNS = new frmNovaSolicitacao("C", this.empresa_logada, this.cod_representante, "10", "1");
            frmBuscaSolicitacao frmBuscaSolic = new frmBuscaSolicitacao();
            this.Hide();
            frmBuscaSolic.ShowDialog();
        }
    }
}
