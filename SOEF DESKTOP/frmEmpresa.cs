using System;
using System.Data;
using System.Windows.Forms;
using Fockink.ACE;

namespace ORCAMENTOS_FOCKINK
{
    public partial class frmEmpresa : Form
    {
        string usuarioLogado;
        string v_empresa = "";
        public frmEmpresa()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            try
            {
                this.Hide();
                menu.gravaRodape(txtUsuario.Text, comboEmpresas.Text, comboEmpresas.SelectedValue.ToString());
                menu.atualizaBases(); //Chama os métodos para atualizar a base de clientes e contatos do representante
                menu.ShowDialog();          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void populaListaEmpresas()
        {
            try
            {
                Representantes.Seguranca login = new Representantes.Seguranca();
                login.Usuario = "Fockink";
                login.Senha = "fockink147@1!";
                Representantes.RepresentantesSoapClient usuario = new Representantes.RepresentantesSoapClient();
                DataSet ds = new DataSet();
                ds = usuario.listaEmpresaUsuarioSOEF(login, txtUsuario.Text);
                if (ds != null && ds.Tables.Count > 0)
                {
                    comboEmpresas.DataSource = ds.Tables[0];
                    comboEmpresas.DisplayMember = "COD_NOME_EMPRESA";
                    comboEmpresas.ValueMember = "COD_REPRESENTANTE";
                }
                else
                {
                    MessageBox.Show("Usuário sem empresa associada.", "Acesso SOEF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu menu = new frmMenu();
            menu.ShowDialog();
        }


        internal void gravaUsuario(string usuario)
        {
            txtUsuario.Text = usuario;
        }

        internal void recebeUsuario(string p_usuario)
        {
            usuarioLogado = p_usuario;
        }
        
        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            populaListaEmpresas();
        }
    }
}
