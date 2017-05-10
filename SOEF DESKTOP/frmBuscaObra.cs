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
    public partial class frmBuscaObra : Form
    {
        public frmBuscaObra()
        {
            InitializeComponent();
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDadosObra.Text))
            {
                MessageBox.Show("Por favor, informe o código, razão social ou CNPJ da obra para realizar a busca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CadSolicitacao csolicitacao = new CadSolicitacao();
                DataSet ds = new DataSet();
                DataTable da = new DataTable();
                da = csolicitacao.getObra(txtDadosObra.Text, "lista");
                if (da.Rows.Count <= 0)
                {
                    MessageBox.Show("Não foi encontrado nenhuma obra com o parâmetro passado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDadosObra.Focus();
                }
                else
                {
                    dgvListaObra.DataSource = da;
                }
            }
        }

        private void btnConfirmaCliente_Click(object sender, EventArgs e)
        {
            if (dgvListaObra.SelectedRows.Count > 0)
            {
                try
                {
                    string CodClienteObra = "";
                    foreach (DataGridViewRow r in dgvListaObra.SelectedRows)
                    {
                        CodClienteObra = dgvListaObra["CodCli", r.Index].Value.ToString();
                    }

                    //Devolve o valor do código do cliente para o form que chamou a tela
                    frmNovaSolicitacao.CodClienteObra = CodClienteObra;
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

        private void txtDadosObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnBuscarClientes_Click(sender, e);
            }
        }
    }
}
