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
    public partial class frmBuscaContatos : Form
    {
        public string CodCliente;
        public string TipoContato;
        public string EmprRepresentante;
        public frmBuscaContatos(string p_dpes_codigo, string p_empr_representante, string p_tipo_contato) //Código do contato cliente e tipo de contato (comercial ou técnico)
        {
            InitializeComponent();
            CodCliente = p_dpes_codigo;
            TipoContato = p_tipo_contato;
            EmprRepresentante = p_empr_representante; 
        }

    private void btnBuscarContato_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscaContato.Text))
            {
                MessageBox.Show("Informe um código, razão social ou CPF/CNPJ para ralizar a busca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CadSolicitacao csolicitacao = new CadSolicitacao();
                DataSet ds = new DataSet();
                DataTable da = new DataTable();
                da = csolicitacao.getContato(txtBuscaContato.Text, this.EmprRepresentante, this.CodCliente, "lista"); //N = Busca pelo nome do cliente 

                if (da.Rows.Count <= 0)
                {
                    MessageBox.Show("Não foi encontrado nenhum contato com o parâmetro passado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscaContato.Focus();
                }
                else
                {
                    dgvListaContatos.DataSource = da;
                }
            }
        }

        private void btnConfirmaCliente_Click(object sender, EventArgs e)
        {
            if (dgvListaContatos.SelectedRows.Count > 0)
            {
                try
                {
                    string CodContato = "";

                    foreach (DataGridViewRow r in dgvListaContatos.SelectedRows)
                    {
                        CodContato = dgvListaContatos["CODIGO", r.Index].Value.ToString();
                    }

                    if(this.TipoContato == "T") //Contato Técnico
                    {
                        frmNovaSolicitacao.CodContatoTecnico = CodContato;
                        this.DialogResult = DialogResult.OK;
                    }
                    else if(this.TipoContato == "C") //Contato Comercial
                    {
                        frmNovaSolicitacao.CodContatoComercial = CodContato;
                        this.DialogResult = DialogResult.OK;
                    }
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

        private void txtBuscaContato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnBuscarContato_Click(sender, e);
            }

        }
    }
}
