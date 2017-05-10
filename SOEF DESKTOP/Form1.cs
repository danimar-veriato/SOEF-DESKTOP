using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;
using Microsoft.VisualBasic;

namespace ORCAMENTOS_FOCKINK
{
    public partial class Form1 : Form
    {
        public Form1(string empr_cod, string representante)
        {
            InitializeComponent();
            label1.Text = empr_cod;
            label2.Text = representante;
        }

        public Form1()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
                //ManipulaBD mBD = new ManipulaBD();
                //ClientesRepresentante solicitacao = new ClientesRepresentante();
                //solicitacao.codSolicitacao = txtCodOrc.Text;
                //solicitacao.representante = txtRepresentante.Text;
                //solicitacao.cliente = txtCliente.Text;
                //solicitacao.descricao = txtDescricao.Text;

                //mBD.insereRegistro(solicitacao, "insert into SOLICITACOES(REPRESENTANTE, CLIENTE, DESCRICAO) values (@representante, @cliente, @descricao)");
                //MessageBox.Show("Registro inserido com sucesso!");
                //listaDados();
        }

        public void listaDados()
        {
           ManipulaBD mBD = new ManipulaBD();
           // dgvLista.DataSource = mBD.selectSOF("SELECT * FROM DOM_CLIENTE WHERE EMPR_CODIGO_REPRES = '" + label1.Text + "' AND COD_REPRESENTANTE = '" + label2.Text + "' ", "DOM_CLIENTE");
           dataGridView1.DataSource = mBD.selectSOF1("SELECT * FROM DOM_CONTATO WHERE [EMPR_CODIGO] = '730'", "DOM_CONTATO"); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaDados();

        }

        private void bntAtualizar_Click(object sender, EventArgs e)
        {
            listaDados();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Testa alguma célula foi selecionada
            //if (dgvLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    txtCodOrc.Text = dgvLista.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
            //    txtCliente.Text = dgvLista.Rows[e.RowIndex].Cells["cliente"].Value.ToString();
            //    txtRepresentante.Text = dgvLista.Rows[e.RowIndex].Cells["representante"].Value.ToString();
            //    txtDescricao.Text = dgvLista.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
            //}
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //ManipulaBD mBD = new ManipulaBD();
            //Abre a conexão com o BD local
        //    mBD.openConnection();

            //mBD.deleteSOF("DELETE FROM DOM_CLIENTE WHERE COD_REPRESENTANTE = '" + label2.Text + "' AND EMPR_CODIGO_REPRES = '" + label1.Text + "' ");

           // mBD.deleteContatosRepresentantes("delete from dom_contato where dpes_codigo = @DPES_CODIGO and empr_codigo = @EMPR_CODIGO", label2.Text, label1.Text);

            //mBD.deleteSOF("DELETE FROM DOM_CONTATO WHERE DPES_CODIGO = '" + label2.Text + "' AND EMPR_CODIGO = '" + label1.Text + "' ");
       //     listaDados();

            ////Verifica se deseja excluir o registro
            //DialogResult result = MessageBox.Show("Confirma a exclusão deste registro?", "Exclusão de registro", MessageBoxButtons.YesNo);
            //if (result == System.Windows.Forms.DialogResult.Yes)
            //{
            //    ManipulaBD mBD = new ManipulaBD();
            //    mBD.deleteRegistro(txtCodOrc.Text, "DELETE FROM SOLICITACOES WHERE ID=@codigo");
            //    MessageBox.Show("Registro apagado com sucesso!");

            //}





        //    public int deleteRegistro(string codigo, string sql)
        //{
        //    ManipulaBD objManipulaBD = ManipulaBD.GetInstance(stringConn);
        //    objManipulaBD.openConnection();
        //    SqlCeCommand cmd = new SqlCeCommand(sql, objSqlCeConnection);
        //    cmd.CommandType = CommandType.Text;
        //    try
        //    {
        //        cmd.Parameters.AddWithValue("@codigo", codigo);
        //        return cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



    }


    }
}
