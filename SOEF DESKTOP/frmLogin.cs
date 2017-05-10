using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fockink.ACE;

namespace ORCAMENTOS_FOCKINK
{
    public partial class frmLogin : Form
    {
        Login login = new Fockink.ACE.Login();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Informe o usuário e senha para prosseguir.", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Representantes.Seguranca login = new Representantes.Seguranca();
                    login.Usuario = "Fockink";
                    login.Senha = "fockink147@1!";
                    Representantes.RepresentantesSoapClient usuarios = new Representantes.RepresentantesSoapClient();
                    string retorno = usuarios.validaLogin(login, txtUsuario.Text, txtSenha.Text);
                    
                    //Se encontrou o usuário cadastrado
                    if(!string.IsNullOrEmpty(retorno))
                    {
                        this.Hide();
                        frmEmpresa empr = new frmEmpresa();
                        empr.gravaUsuario(txtUsuario.Text);
                        empr.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usuário e/ou senha inválidos.", "Retorno login SOEF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSenha.Text = "";
                        txtSenha.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Retorno login SOEF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                              
            }
        }        

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
               btnEntrar_Click(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu menu = new frmMenu();
            menu.ShowDialog();
        }
    }
}
