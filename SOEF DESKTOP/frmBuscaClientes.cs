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
    public partial class frmBuscaClientes : Form
    {
        public frmBuscaClientes()
        {
            InitializeComponent();

        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDadosCliente.Text))
            {
                MessageBox.Show("Informe um código, razão social ou CPF/CNPJ para ralizar a busca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CadSolicitacao csolicitacao = new CadSolicitacao();
                DataSet ds = new DataSet();
                DataTable da = new DataTable();
                da = csolicitacao.getCliente(txtDadosCliente.Text, "lista"); //RC - Busca por razão social e cpj/cnpj

                if(da.Rows.Count <= 0)
                {
                    MessageBox.Show("Não foi encontrado nenhum cliente com o parâmetro passado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDadosCliente.Focus();
                }
                else
                {
                    dgvListaClientes.DataSource = da;
                }
            }
        }

        private void btnConfirmaCliente_Click(object sender, EventArgs e)
        {
            if(dgvListaClientes.SelectedRows.Count > 0)
            {
                try
                {
                    string CodCliente = "";
                    foreach (DataGridViewRow r in dgvListaClientes.SelectedRows)
                    {
                        CodCliente = dgvListaClientes["CodCli", r.Index].Value.ToString();
                    }

                    //Devolve o valor do código do cliente para o form que chamou a tela
                    frmNovaSolicitacao.CodCliente = CodCliente;
                    this.DialogResult = DialogResult.OK;  //Fecha o form atual e retorna ao anterior..

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro para prosseguir.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmBuscaClientes_Load(object sender, EventArgs e)
        {
         
        }

        private void txtDadosCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnBuscarClientes_Click(sender, e);
            }
        }
    }
}
