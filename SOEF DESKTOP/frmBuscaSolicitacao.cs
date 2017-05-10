using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORCAMENTOS_FOCKINK
{
    public partial class frmBuscaSolicitacao : Form
    {
        public frmBuscaSolicitacao()
        {
            InitializeComponent();
        }

        private void frmBuscaSolicitacao_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscaVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu fmenu = new frmMenu();
            fmenu.ShowDialog();
        }

        private void btnBuscaSolic_Click(object sender, EventArgs e)
        {
            string pBusca = "";
            if (rbtnBuscaTodas.Checked)
            {
                pBusca = "T";
            }
            else if (rbtnBuscaEnviadas.Checked)
            {
                pBusca = "E";
            }
            else if (rbtnBuscaPendentes.Checked)
            {
                pBusca = "P";
            }
            CadSolicitacao cSolicitacao = new CadSolicitacao();
           
            dgvListaSolicitacoes.DataSource = cSolicitacao.listaCabecalhoSolic(null, null, null, pBusca);

          
        }

        private void dgvListaSolicitacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                frmNovaSolicitacao frmNS = new frmNovaSolicitacao("C", dgvListaSolicitacoes.CurrentRow.Cells[5].Value.ToString(), null, dgvListaSolicitacoes.CurrentRow.Cells[1].Value.ToString(), "1");
                frmNS.ShowDialog();
            }
        }
    }
}
