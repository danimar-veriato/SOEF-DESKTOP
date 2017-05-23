using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOEFC;

namespace ORCAMENTOS_FOCKINK
{
    public partial class frmNovaSolicitacao : Form
    {
        //Passa os dados do representante e empresa logada
        public string empr_logada;
        public string representante;
        //public string cod_cliente = "";
        public string cod_representante;
        public string empr_representante;
        public int NumSolicitacao; //Numero da solicitação
        public string SeqSolicitacao;
        public string NumRevisaoSolic; //N° da revisão (hra do cadastro)

        //Parâmetro Novo Registro / Alteração
        public string AcaoTela;
        
        //Campos do formulário de cadastro
        public int numero_solic;
        public string status_solic;
        public string cod_cliente;
        public string cod_obra;
        public string observacao;
        public string nome_projeto;
        public string cod_tecnico;
        public string cod_comercial;
        public string tipo_negocio;
        public string finalidade;
        public string empreendimento;

        public string idioma;
        public string outro_idioma;
        public string dt_proposta;
        public string valor;
        public string dt_obra;
        public string concorrentes;
        public string resp_padrao_solucao;
        public string frete;
        public string faturamento;
        public string vendaPara;
        public string contICMS;
        public string incentFiscal;
        public string desc_incentivo;
        public string formaPagamento;
        public string financiamento;
        public string instFinanceira;
        public string indic_dpes_codigo;
        public string indic_empr_codigo;
        public string indicComissao;
        public string margemDesconto;
        public string moeda;

        public static string CodCliente { get; set; }
        public static string CodClienteObra { get; set; }
        public static string CodContatoTecnico { get; set; }
        public static string CodPessoaContatoTecnico { get; set; }
        public static string CodContatoComercial { get; set; }
        public static string CodPessoaContatoComercial { get; set; }

        public frmNovaSolicitacao(string param_form_tipo_acesso_tela, string param_form_empr_codigo = null, string param_form_representante = null, string param_form_num_solic = null, string param_form_rev_solic = null)
        {
            InitializeComponent();
            AcaoTela = param_form_tipo_acesso_tela;
            if(AcaoTela == "N") //N - Novo Registro 
            {
                empr_logada = param_form_empr_codigo;
                representante = param_form_representante;
                //Inicializa combos cabeçalho
                inicializaCombos();
                //Seta a Revisão p/ Novo Registro como 1 por default
                this.NumRevisaoSolic = "1";
                //Oculta as tabs do cabeçalho
                tbCabecalho.Controls.Remove(tabCabecalhoCondPgto);
                txtStatusSolic.Text = "GER";
                //Marca os radiobuttons por padrão
                radioContICMSSim.Checked = true;
                radioIncentFiscalSim.Checked = true;
                this.dtpkCabDataObra.Value = DateTime.Now.Date;
                this.dtpkPrazoProposta.Value = DateTime.Now.Date;
            }
            else //C - Consulta / Alteração
            {
                /*this.NumSolicitacao*/
                this.empr_logada = param_form_empr_codigo;
                this.numero_solic = Convert.ToInt32(param_form_num_solic);
                this.NumRevisaoSolic = param_form_rev_solic;
                //Chama o método que busca os dados da solicitação
                caregaCampos(empr_logada, numero_solic.ToString(), NumRevisaoSolic);
                //Preenche o DataGrid - Aba 3
                atualizaGridCondPag(numero_solic.ToString(), NumRevisaoSolic, empr_logada);
                //  Atualiza txt com o pecentual - ABA 3
                txtCondPgtoTotal.Text = getPercentualPagto(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (txtCondPgtoTotal.Text == "100")
                {
                    btnGravaCondPgto.Enabled = false;
                }
                else
                {
                    btnGravaCondPgto.Enabled = true;
                }
                //Desabilita botão de Gravação
                btnCabGravaCabecalho.Enabled = false;
                //Ativa o botão de Alteração
                btnSalvaAlteracao.Enabled = true;
                btnSalvaAlteracao.Visible = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu principal = new frmMenu();
            principal.ShowDialog();
        }

        private void frmNovaSolicitacao_Load(object sender, EventArgs e)
        {
            //Oculta as tabs do escopo da solicitação
           // tabNovaSolicitacao.Controls.Remove(tabDefEscopo);
            tabNovaSolicitacao.Controls.Remove(tabEscopo1);
            tabNovaSolicitacao.Controls.Remove(tabEscopo2);
            tabNovaSolicitacao.Controls.Remove(tabEscopo3);
            tabNovaSolicitacao.Controls.Remove(tabEscopo4);
            tabNovaSolicitacao.Controls.Remove(tabEscopo5);
            tabNovaSolicitacao.Controls.Remove(tabEscopo6);
            tabNovaSolicitacao.Controls.Remove(tabEscopo7);
            tabNovaSolicitacao.Controls.Remove(tabEscopo8);
            tabNovaSolicitacao.Controls.Remove(tabEscopo9);
            tabNovaSolicitacao.Controls.Remove(tabEscopo10);
            tabNovaSolicitacao.Controls.Remove(tabEscopo11);
            tabNovaSolicitacao.Controls.Remove(tabEscopo12);
            tabNovaSolicitacao.Controls.Remove(tabEscopo13);
            tabNovaSolicitacao.Controls.Remove(tabEscopo14);
            tabNovaSolicitacao.Controls.Remove(tabEscopo15);
            tabNovaSolicitacao.Controls.Remove(tabEscopo16);
            tabNovaSolicitacao.Controls.Remove(tabEscopo17);
            tabNovaSolicitacao.Controls.Remove(tabEscopo18);
            tabNovaSolicitacao.Controls.Remove(tabEscopo19);
        }


        private void checkEscopo1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo1.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo1);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo1);
            }
        }

        private void checkEscopo2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo2.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo2);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo2);
            }
        }

        private void checkEscopo3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo3.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo3);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo3);
            }
        }

        private void checkEscopo4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo4.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo4);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo4);
            }
        }

        private void checkEscopo5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo5.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo5);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo5);
            }
        }

        private void checkEscopo6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo6.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo6);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo6);
            }
        }

        private void checkEscopo7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo7.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo7);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo7);
            }
        }

        private void checkEscopo8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo8.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo8);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo8);
            }
        }

        private void checkEscopo9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo9.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo9);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo9);
            }
        }

        private void checkEscopo10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo10.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo10);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo10);
            }
        }

        private void checkEscopo11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo11.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo11);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo11);
            }
        }

        private void checkEscopo12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo12.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo12);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo12);
            }
        }

        private void checkEscopo13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo13.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo13);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo13);
            }
        }

        private void checkEscopo14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo14.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo14);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo14);
            }
        }

        private void checkEscopo15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo15.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo15);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo15);
            }
        }

        private void checkEscopo16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo16.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo16);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo16);
            }
        }

        private void checkEscopo17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo17.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo17);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo17);
            }
        }

        private void checkEscopo18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo18.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo18);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo18);
            }
        }

        private void checkEscopo19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo19.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo19);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo19);
            }
        }

        private void txtCampoBuscaCliente_TextChanged(object sender, EventArgs e)
        {
            //Limpa os campos caso o código do cliente do campo de busca seja apagado
            if (string.IsNullOrEmpty(txtCabecalhoCodCliente.Text))
            {
                txtCabecalhoCli.Text = "";
                txtCabecalhoCNPJCPF.Text = "";
                txtCabecalhoInscEst.Text = "";
                cod_cliente = "";  //Zera a variável do código do cliente
                //btnCabecalhoBuscaObra.Enabled = false;
                //txtCabecalhoCodObra.Enabled = false;
                txtCodTecnico.Text = "";
                txtCodComercial.Text = "";
                txtCodTecnico.Enabled = false;
                btnBuscaTecnico.Enabled = false;
                txtCodComercial.Enabled = false;
                btnBuscaComercial.Enabled = false;

                //Limpa os campos de contato
                txtCodTecnico.Text = "";
                txtContatoTecnico.Text = "";
                txtFoneTecnico.Text = "";
                txtCelularTecnico.Text = "";
                txtEmailTecnico.Text = "";
                txtCodComercial.Text = "";
                txtContatoComercial.Text = "";
                txtFoneComercial.Text = "";
                txtCelularComercial.Text = "";
                txtEmailComercial.Text = "";
            }
        }


        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            frmBuscaClientes buscaClientes = new frmBuscaClientes();
            if(buscaClientes.ShowDialog() == DialogResult.OK)
            {
                txtCabecalhoCodCliente.Text = CodCliente;
                txtCabecalhoCodCliente.Focus();
            }
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica se o caractere digitado corresponde a algum número ou a tecla BackSpace (apagar)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true; //Habilita digitação de número

                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(txtCabecalhoCodCliente.Text))
                        {
                            CadSolicitacao csolicitacao = new CadSolicitacao();
                            DataSet ds = new DataSet();
                            DataTable da = new DataTable();
                            da = csolicitacao.getCliente(txtCabecalhoCodCliente.Text, "cod");
                            if (da.Rows.Count > 0)
                            {
                                foreach (DataRow dr in da.Rows)
                                {
                                    txtCabecalhoCli.Text = "Cód: " + dr["COD_CLIENTE"].ToString() + " | " + dr["RAZAO_SOCIAL"].ToString() + " | " + dr["CIDADE"].ToString() + "-" + dr["SIGLA_UF"].ToString();
                                    txtCabecalhoCNPJCPF.Text = dr["CGC_CPF"].ToString();
                                    txtCabecalhoInscEst.Text = dr["INSCRICAO_ESTADUAL"].ToString();
                                    cod_cliente = dr["COD_CLIENTE"].ToString();
                                    CodCliente = dr["COD_CLIENTE"].ToString();
                                    txtCabecalhoCodCliente.Text = dr["COD_CLIENTE"].ToString();
                                    empr_representante = dr["EMPR_CODIGO_REPRES"].ToString();
                                    cod_representante = dr["COD_REPRESENTANTE"].ToString();
                                }
                                btnCabecalhoBuscaObra.Enabled = true;
                                txtCabecalhoCodObra.Enabled = true;
                                txtCodTecnico.Enabled = true;
                                btnBuscaTecnico.Enabled = true;
                                txtCodComercial.Enabled = true;
                                btnBuscaComercial.Enabled = true;

                                //Buscando Indicadores de Negócios - Aba 2
                                DataTable dt1 = new DataTable();
                                dt1 = csolicitacao.getIndicNegocios(this.empr_representante);

                                //Adiciona o "Selecione" antes de preencher o combo com os dados do banco
                                DataRow dr2 = dt1.NewRow();
                                dr2["DPES_CODIGO"] = 0;
                                dr2["COD_RAZAO_SOCIAL"] = "SELECIONE...";
                                dt1.Rows.InsertAt(dr2, 0);
                                comboCabIndicNegocio.DataSource = dt1;
                                comboCabIndicNegocio.ValueMember = "DPES_CODIGO";
                                comboCabIndicNegocio.DisplayMember = "COD_RAZAO_SOCIAL";
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível identificar um cliente com o código informado. Tente novamente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCabecalhoCli.Text = "";
                                txtCabecalhoCNPJCPF.Text = "";
                                txtCabecalhoInscEst.Text = "";
                                cod_cliente = "";  //Zera a variável do código do cliente
                                txtCabecalhoCodCliente.Text = "";
                                txtCabecalhoCodCliente.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, informe um código de cliente para realizar a busca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCabecalhoCodCliente.Focus();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void txtCabecalhoCodObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica se o caractere digitado corresponde a algum número ou a tecla BackSpace (apagar)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true; //Habilita digitação de número

                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(txtCabecalhoCodObra.Text))
                        {
                            CadSolicitacao csolicitacao = new CadSolicitacao();
                            DataSet ds = new DataSet();
                            DataTable da = new DataTable();
                            da = csolicitacao.getObra(txtCabecalhoCodObra.Text, "cod");
                            if(da.Rows.Count > 0)
                            {
                                foreach(DataRow dr in da.Rows)
                                {
                                    txtCabecalhoObra.Text = dr["COD_CLIENTE"].ToString() + " | " + dr["RAZAO_SOCIAL"].ToString() + " | " + dr["CIDADE"].ToString() + "-" + dr["SIGLA_UF"].ToString();
                                    txtObraCPFCNPJ.Text = dr["CGC_CPF"].ToString();
                                    txtObraIE.Text = dr["INSCRICAO_ESTADUAL"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível identificar o código informado. Tente novamente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCabecalhoCodObra.Text = "";
                                txtCabecalhoCodObra.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Por favor, informe o código da obra para realizar a busca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCabecalhoCodObra.Focus();
                        }               
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void txtCabecalhoCodObra_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCabecalhoCodObra.Text))
            {
                txtCabecalhoObra.Text = "";
                txtObraCPFCNPJ.Text = "";
                txtObraIE.Text = "";
                txtCabecalhoCodObra.Focus();
            }
        }

        private void btnCabecalhoBuscaObra_Click(object sender, EventArgs e)
        {
            frmBuscaObra frmObra = new frmBuscaObra();
            if(frmObra.ShowDialog() == DialogResult.OK)
            {
                txtCabecalhoCodObra.Text = CodClienteObra;
                txtCabecalhoCodObra.Focus();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(AcaoTela == "N")
            {
                frmMenu fmenu = new frmMenu();
                fmenu.ShowDialog();
            }
            
        }

        private void txtCodTecnico_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodTecnico.Text))
            {
                txtContatoTecnico.Text = "";
                txtFoneTecnico.Text = "";
                txtCelularTecnico.Text = "";
                txtEmailTecnico.Text = "";
                CodContatoTecnico = "";
                CodPessoaContatoTecnico = "";
            }
        }

        private void txtCodTecnico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtCabecalhoCodCliente.Text))
                {
                    MessageBox.Show("Por favor, informe primeiramente o código do cliente para realizar a busca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCabecalhoCodCliente.Focus();
                }
                else
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(txtCodTecnico.Text))
                        {
                            CadSolicitacao csolicitacao = new CadSolicitacao();
                            DataSet ds = new DataSet();
                            DataTable da = new DataTable();
                            da = csolicitacao.getContato(txtCodTecnico.Text, this.empr_representante, txtCabecalhoCodCliente.Text, "N"); //N = Busca pelo nome do cliente 
                            if (da.Rows.Count > 0)
                            {
                                foreach (DataRow dr in da.Rows)
                                {
                                    txtContatoTecnico.Text = "Cód: " + dr["CODIGO"].ToString() + " | " + dr["NOME"].ToString();
                                    txtFoneTecnico.Text = dr["FONE"].ToString();
                                    txtCelularTecnico.Text = dr["CELULAR"].ToString();
                                    txtEmailTecnico.Text = dr["EMAIL"].ToString();
                                    CodContatoTecnico = dr["CODIGO"].ToString();
                                    CodPessoaContatoTecnico = dr["DPES_CODIGO"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível identificar o contato informado. Tente novamente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCodTecnico.Text = "";
                                txtCodTecnico.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, informe o nome de um contato para realizar a busca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCabecalhoCodCliente.Focus();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void btnBuscaTecnico_Click(object sender, EventArgs e)
        {
            frmBuscaContatos fBuscaContatos = new frmBuscaContatos(CodCliente, this.empr_representante, "T");//T = Técnico
            if (fBuscaContatos.ShowDialog() == DialogResult.OK)
            {
                txtCodTecnico.Text = CodContatoTecnico;
                txtCodTecnico.Focus();
            }
        }

        private void txtCodComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtCabecalhoCodCliente.Text))
                {
                    MessageBox.Show("Por favor, informe primeiramente o código do cliente para realizar a busca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCabecalhoCodCliente.Focus();
                }
                else
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(txtCodComercial.Text))
                        {
                            CadSolicitacao csolicitacao = new CadSolicitacao();
                            DataSet ds = new DataSet();
                            DataTable da = new DataTable();
                            da = csolicitacao.getContato(txtCodComercial.Text, this.empr_representante, txtCabecalhoCodCliente.Text, "N"); //N = Busca pelo nome do cliente 

                            if (da.Rows.Count > 0)
                            {
                                foreach (DataRow dr in da.Rows)
                                {
                                    txtContatoComercial.Text = "Cód: " + dr["CODIGO"].ToString() + " | " + dr["NOME"].ToString();
                                    txtFoneComercial.Text = dr["FONE"].ToString();
                                    txtCelularComercial.Text = dr["CELULAR"].ToString();
                                    txtEmailComercial.Text = dr["EMAIL"].ToString();
                                    CodContatoComercial = dr["CODIGO"].ToString();
                                    CodPessoaContatoComercial = dr["DPES_CODIGO"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível identificar o contato informado. Tente novamente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCodComercial.Text = "";
                                txtCodComercial.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, informe o nome de um contato para realizar a busca.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCodComercial.Focus();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void txtCodComercial_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodComercial.Text))
            {
                txtContatoComercial.Text = "";
                txtFoneComercial.Text = "";
                txtCelularComercial.Text = "";
                txtEmailComercial.Text = "";
                CodContatoComercial = "";
                CodPessoaContatoComercial = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBuscaContatos fBuscaContatos = new frmBuscaContatos(CodCliente, this.empr_representante, "C");//C = Comercial
            if (fBuscaContatos.ShowDialog() == DialogResult.OK)
            {
                txtCodComercial.Text = CodContatoComercial;
                txtCodComercial.Focus();
            }
        }

        private void comboCabIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboCabIdioma.SelectedIndex == 3)
            {
                txtCabOutroIdioma.Enabled = true;
            }
            else
            {
                txtCabOutroIdioma.Enabled = false;
                txtCabOutroIdioma.Text = "";
            }
        }

        private void radioIncentFiscalNao_CheckedChanged(object sender, EventArgs e)
        {
            if (radioIncentFiscalNao.Checked == true)
            {
                txtCabIncentivo.Text = "";
                txtCabIncentivo.Enabled = false;
            }
        }

        private void radioIncentFiscalSim_CheckedChanged(object sender, EventArgs e)
        {
            if(radioIncentFiscalSim.Checked == true)
            {
                txtCabIncentivo.Enabled = true;
            }
                
        }

        private void comboCabPagmentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCabPagmentos.SelectedIndex == 2 || comboCabPagmentos.SelectedIndex == 3)
            {
                txtCabFinanciamento.Enabled = true;
                txtCabInstFinanceira.Enabled = true;
            }
            else
            {
                txtCabFinanciamento.Text = "";
                txtCabInstFinanceira.Text = "";
                txtCabFinanciamento.Enabled = false;
                txtCabInstFinanceira.Enabled = false;
            }
        }


        private void btnCabGravaCabecalho_Click(object sender, EventArgs e)
        {
            string msgErro = "";
            if(comboCabTipo.SelectedIndex == 0)
            {
                msgErro += "Tipo de negócio em branco\n"; 
            }
            if(comboCabFinalidade.SelectedIndex == 0)
            {
                msgErro += "Finalidade não informada\n";
            }
            if (string.IsNullOrEmpty(txtVlrEstimadoEscopo.Text))
            {
                msgErro += "Valor Estimado Escopo não informado\n";
            }
            if(comboCabPadraoSolucao.SelectedIndex == 0)
            {
                msgErro += "Campo Padrão Solução não informado\n";
            }
            if(comboCabFrete.SelectedIndex == 0)
            {
                msgErro += "Frete não informado\n";
            }
            if(combocabFaturamento.SelectedIndex == 0)
            {
                msgErro += "Tipo de Faturamento não informado\n";
            }
            if(comboVendaP.SelectedIndex == 0)
            {
                msgErro += "Tipo de venda não informado\n";
            }
            if(comboCabPagmentos.SelectedIndex == 0)
            {
                msgErro += "Forma de pagamento não informada\n";
            }
            if((radioIncentFiscalSim.Checked) && (string.IsNullOrEmpty(txtCabIncentivo.Text)))
            {
                msgErro += "Campo Incentivo Fiscal não informado\n";
            }
            if( (comboCabIndicNegocio.SelectedIndex != 0) && (string.IsNullOrEmpty(txtCabComissaoIndic.Text)) )
            {
                msgErro += "Indicador de comissão não informado\n";
            }
            if (!string.IsNullOrEmpty(msgErro))
            {
                MessageBox.Show(msgErro, "Campos obrigatórios em branco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    //Seta as variáveis do insert
                    setValores();
                    CadSolicitacao cSolicitacao = new CadSolicitacao();
                    cSolicitacao.setSolicitacao("I", this.numero_solic.ToString(), this.NumRevisaoSolic , this.status_solic, this.txtCabecalhoCodCliente.Text, this.cod_obra, this.observacao,
                    this.nome_projeto, this.cod_tecnico, CodPessoaContatoTecnico, this.cod_comercial, CodPessoaContatoComercial, this.tipo_negocio,
                    this.finalidade, this.empreendimento, this.idioma, this.outro_idioma, this.valor, this.dt_obra, this.dt_proposta, this.concorrentes, this.resp_padrao_solucao,
                    this.frete, this.faturamento, this.vendaPara, this.contICMS, this.incentFiscal, this.desc_incentivo, this.formaPagamento, this.financiamento, this.instFinanceira,
                    this.indic_empr_codigo, this.indic_dpes_codigo, this.indicComissao, this.margemDesconto, this.moeda, this.cod_representante, this.empr_representante);

                    //Busca o número da solicitação cadastrada
                    this.numero_solic = Convert.ToInt32(cSolicitacao.getNumeroSolicitacao()) - 1;
                    MessageBox.Show("Número Solicitação: " + this.numero_solic);
                    //Ativa a Aba das condições de pagamento
                    tbCabecalho.Controls.Add(tabCabecalhoCondPgto);
                    MessageBox.Show("Cabeçalho gravado com sucesso!", "Cadastro de Solicitação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Traz os dados da solicitação gravada para os campos da tela
                    caregaCampos(this.empr_representante, this.numero_solic.ToString(), this.NumRevisaoSolic);

                    //Desabilita o botão Gravar e habilita o Alterar
                    btnCabGravaCabecalho.Enabled = false;
                    btnSalvaAlteracao.Visible = true;
                    btnSalvaAlteracao.Enabled = true;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
        }
        

        /// <summary>
        /// Carrega os valores dos campos para as variáveis que são usadas no SELECT.
        /// </summary>
        private void setValores()
        {
            //Pega os campos do formulário e grava nas variáveis
            CadSolicitacao csolicitacao = new CadSolicitacao();
            if (!string.IsNullOrEmpty(txtNumSolicitacao.Text))
            {
                this.numero_solic = Convert.ToInt32(txtNumSolicitacao.Text);
            }
            else
            {
                this.numero_solic = Convert.ToInt32(csolicitacao.getNumeroSolicitacao());
            }
            this.status_solic = txtStatusSolic.Text;
            this.cod_cliente = txtCabecalhoCodCliente.Text;
            this.cod_obra = txtCabecalhoCodObra.Text;
            this.observacao = txtObraObs.Text;
            this.nome_projeto = txtObraProjeto.Text;
            this.cod_tecnico = txtCodTecnico.Text;
            this.cod_comercial = txtCodComercial.Text;
            this.tipo_negocio = comboCabTipo.SelectedValue.ToString();
            this.finalidade = comboCabFinalidade.SelectedIndex.ToString();
            if (comboCabEmpreend.SelectedIndex == 0) //Se não informou o empreendimento
            {
                this.empreendimento = null;
            }
            else
            {
                this.empreendimento = comboCabEmpreend.SelectedIndex.ToString();
            }
            this.idioma = Convert.ToString(comboCabIdioma.SelectedIndex + 1);
            this.outro_idioma = txtCabOutroIdioma.Text;
            this.dt_proposta = dtpkPrazoProposta.Value.Date.ToShortDateString();  //String.Format("{0:dd/MM/yyyy}", dtpkPrazoProposta.Text);
            this.valor = txtVlrEstimadoEscopo.Text.Replace(",", ".");
            this.dt_obra = dtpkCabDataObra.Value.Date.ToShortDateString(); //String.Format("{0:dd/MM/yyyy}", dtpkCabDataObra.Text);
            this.concorrentes = txtCabConcorrentes.Text;
            this.resp_padrao_solucao = comboCabPadraoSolucao.SelectedIndex.ToString();
            this.frete = comboCabFrete.SelectedIndex.ToString();
            this.faturamento = combocabFaturamento.SelectedIndex.ToString();
            this.vendaPara = comboVendaP.SelectedIndex.ToString();
            if (radioContICMSSim.Checked)
            {
                this.contICMS = "S";
            }
            else
            {
                this.contICMS = "N";
            }
            if (radioIncentFiscalSim.Checked)
            {
                this.incentFiscal = "S";
            }
            else
            {
                this.incentFiscal = "N";
            }
            this.desc_incentivo = txtCabIncentivo.Text;
            this.formaPagamento = comboCabPagmentos.SelectedIndex.ToString();
            this.financiamento = txtCabFinanciamento.Text;
            this.instFinanceira = txtCabInstFinanceira.Text;
            this.indic_dpes_codigo = comboCabIndicNegocio.SelectedValue.ToString();
            this.indic_empr_codigo = empr_representante;
            if (string.IsNullOrEmpty(txtCabComissaoIndic.Text))
            {
                this.indicComissao = "0";
            }
            else
            {
                this.indicComissao = txtCabComissaoIndic.Text;
            }
            if (string.IsNullOrEmpty(txtCabDesconto.Text))
            {
                this.margemDesconto = "0";
            }
            else
            {
                this.margemDesconto = txtCabDesconto.Text;
            }
            this.moeda = Convert.ToString(comboCabMoeda.SelectedIndex + 1);
        }


        /// <summary>
        /// Busca os dados da solicitaçao no banco e carrega nos campos da tela
        /// </summary>
        /// <param name="codEmpr">Empresa do representante</param>
        /// <param name="numSolic">N° da solicitação</param>
        /// <param name="numRev">N° da revisão</param>
        private void caregaCampos(string codEmpr, string numSolic, string numRev)
        {
            try
            {
                inicializaCombos();
                CadSolicitacao cSolicitacao = new CadSolicitacao();
                //Inicializa Combo Indicadores do Negócio - Aba 2
                DataTable dt1 = new DataTable();
                dt1 = cSolicitacao.getIndicNegocios(codEmpr);
                //Adiciona o "Selecione" antes de preencher o combo com os dados do banco
                DataRow dr2 = dt1.NewRow();
                dr2["DPES_CODIGO"] = 0;
                dr2["COD_RAZAO_SOCIAL"] = "SELECIONE...";
                dt1.Rows.InsertAt(dr2, 0);
                comboCabIndicNegocio.DataSource = dt1;
                comboCabIndicNegocio.ValueMember = "DPES_CODIGO";
                comboCabIndicNegocio.DisplayMember = "COD_RAZAO_SOCIAL";
                DataTable dt = cSolicitacao.listaCabecalhoSolic(codEmpr.ToString(), numSolic.ToString(), numRev.ToString(), null);
                if (dt.Rows.Count > 0)
                {
                    txtNumSolicitacao.Text = dt.Rows[0]["NUMERO"].ToString();
                    txtStatusSolic.Text = dt.Rows[0]["STATUS"].ToString();
                    txtCabecalhoCodCliente.Text = dt.Rows[0]["DPES_CODIGO_CLI"].ToString();
                    //Busca os dados do Código do Cliente
                    if (!string.IsNullOrEmpty(txtCabecalhoCodCliente.Text))
                    {
                        DataSet ds = new DataSet();
                        DataTable da = new DataTable();
                        da = cSolicitacao.getCliente(txtCabecalhoCodCliente.Text, "cod");
                        if (da.Rows.Count > 0)
                        {
                            txtCabecalhoCli.Text = "Cód: " + da.Rows[0]["COD_CLIENTE"].ToString() + " | " + da.Rows[0]["RAZAO_SOCIAL"].ToString() + " | " + da.Rows[0]["CIDADE"].ToString() + "-" + da.Rows[0]["SIGLA_UF"].ToString();
                            txtCabecalhoCNPJCPF.Text = da.Rows[0]["CGC_CPF"].ToString();
                            txtCabecalhoInscEst.Text = da.Rows[0]["INSCRICAO_ESTADUAL"].ToString();
                            cod_cliente = da.Rows[0]["COD_CLIENTE"].ToString();
                            txtCabecalhoCodCliente.Text = da.Rows[0]["COD_CLIENTE"].ToString();
                            empr_representante = da.Rows[0]["EMPR_CODIGO_REPRES"].ToString();
                            cod_representante = da.Rows[0]["COD_REPRESENTANTE"].ToString();
                            btnCabecalhoBuscaObra.Enabled = true;
                            txtCabecalhoCodObra.Enabled = true;
                            txtCodTecnico.Enabled = true;
                            btnBuscaTecnico.Enabled = true;
                            txtCodComercial.Enabled = true;
                            btnBuscaComercial.Enabled = true;
                        }
                    }
                    txtCabecalhoCodObra.Text = dt.Rows[0]["DPES_CODIGO_OBRA"].ToString();
                    //Busca dados da Obra
                    if (!string.IsNullOrEmpty(txtCabecalhoCodObra.Text))
                    {
                        DataSet ds1 = new DataSet();
                        DataTable da1 = new DataTable();
                        da1 = cSolicitacao.getObra(txtCabecalhoCodObra.Text, "cod");
                        if (da1.Rows.Count > 0)
                        {
                            txtCabecalhoObra.Text = da1.Rows[0]["COD_CLIENTE"].ToString() + " | " + da1.Rows[0]["RAZAO_SOCIAL"].ToString() + " | " + da1.Rows[0]["CIDADE"].ToString() + "-" + da1.Rows[0]["SIGLA_UF"].ToString();
                            txtObraCPFCNPJ.Text = da1.Rows[0]["CGC_CPF"].ToString();
                            txtObraIE.Text = da1.Rows[0]["INSCRICAO_ESTADUAL"].ToString();
                        }
                    }
                    txtObraObs.Text = dt.Rows[0]["OBSERVACOES"].ToString();
                    txtObraProjeto.Text = dt.Rows[0]["NOME_PROJETO"].ToString();
                    txtCodTecnico.Text = dt.Rows[0]["COD_CONT_TEC_CLI"].ToString();
                    //Busca os dados Contato Técnico
                    if (!string.IsNullOrEmpty(txtCodTecnico.Text))
                    {
                        DataSet ds = new DataSet();
                        DataTable da = new DataTable();
                        da = cSolicitacao.getContato(txtCodTecnico.Text, this.empr_representante, txtCabecalhoCodCliente.Text, "N"); //N = Busca pelo nome do cliente 
                        if (da.Rows.Count > 0)
                        {
                            txtContatoTecnico.Text = "Cód: " + da.Rows[0]["CODIGO"].ToString() + " | " + da.Rows[0]["NOME"].ToString();
                            txtFoneTecnico.Text = da.Rows[0]["FONE"].ToString();
                            txtCelularTecnico.Text = da.Rows[0]["CELULAR"].ToString();
                            txtEmailTecnico.Text = da.Rows[0]["EMAIL"].ToString();
                            CodContatoTecnico = da.Rows[0]["CODIGO"].ToString();
                            CodPessoaContatoTecnico = da.Rows[0]["DPES_CODIGO"].ToString();
                        }
                    }
                    txtCodComercial.Text = dt.Rows[0]["COD_CONT_COM_CLI"].ToString();
                    //Busca dados Contato Comercial
                    if (!string.IsNullOrEmpty(txtCodComercial.Text))
                    {
                        DataSet ds = new DataSet();
                        DataTable da = new DataTable();
                        da = cSolicitacao.getContato(txtCodComercial.Text, this.empr_representante, txtCabecalhoCodCliente.Text, "N"); //N = Busca pelo nome do cliente 
                        if (da.Rows.Count > 0)
                        {
                            txtContatoComercial.Text = "Cód: " + da.Rows[0]["CODIGO"].ToString() + " | " + da.Rows[0]["NOME"].ToString();
                            txtFoneComercial.Text = da.Rows[0]["FONE"].ToString();
                            txtCelularComercial.Text = da.Rows[0]["CELULAR"].ToString();
                            txtEmailComercial.Text = da.Rows[0]["EMAIL"].ToString();
                            CodContatoComercial = da.Rows[0]["CODIGO"].ToString();
                            CodPessoaContatoComercial = da.Rows[0]["DPES_CODIGO"].ToString();
                        }
                    }
                    comboCabTipo.SelectedValue = Convert.ToInt32(dt.Rows[0]["NEGOCIO_ASSOCIADO"].ToString());
                    comboCabTipo.Text = dt.Rows[0]["DESCRICAO"].ToString();
                    comboCabEmpreend.SelectedValue = Convert.ToInt32(dt.Rows[0]["TIPO_EMPREENDIMENTO"].ToString());
                    comboCabFinalidade.SelectedValue = Convert.ToInt32(dt.Rows[0]["FINALIDADE_PROPOSTA"].ToString());
                    comboCabIdioma.SelectedValue = Convert.ToInt32(dt.Rows[0]["IDIOMA_PROPOSTA"].ToString());
                    if (dt.Rows[0]["IDIOMA_PROPOSTA"].ToString() == "4")
                    {
                        txtCabOutroIdioma.Enabled = true;
                        txtCabOutroIdioma.Text = dt.Rows[0]["OUTRO_IDIOMA"].ToString();
                    }
                    else
                    {
                        txtCabOutroIdioma.Enabled = false;
                    }
                    dtpkPrazoProposta.Value = Convert.ToDateTime(dt.Rows[0]["DT_PROPOSTA"].ToString());

                    txtVlrEstimadoEscopo.Text = dt.Rows[0]["VALOR_ESTIMADO"].ToString();

                    dtpkCabDataObra.Value = Convert.ToDateTime(dt.Rows[0]["DT_ENTREGA_OBRA"].ToString());

                    txtCabConcorrentes.Text = dt.Rows[0]["DESCRICAO_CONCORRENTES"].ToString();

                    comboCabPadraoSolucao.SelectedValue = Convert.ToInt32(dt.Rows[0]["RESP_PADRAO_VENDOR_LIST"].ToString());

                    comboCabFrete.SelectedValue = Convert.ToInt32(dt.Rows[0]["TIPO_FRETE"].ToString());

                    combocabFaturamento.SelectedValue = Convert.ToInt32(dt.Rows[0]["INDIC_FATURAMENTO"].ToString());

                    comboVendaP.SelectedValue = Convert.ToInt32(dt.Rows[0]["DESTINO_MATERIAL"].ToString());

                    if (dt.Rows[0]["CLIENTE_CONTRIB_ICMS"].ToString() == "S")
                    {
                        radioContICMSNao.Checked = false;
                        radioContICMSSim.Checked = true;
                    }
                    else
                    {
                        radioContICMSSim.Checked = false;
                        radioContICMSNao.Checked = true;
                    }
                    
                    if (dt.Rows[0]["CLIENTE_INCENTIVO_FISCAL"].ToString() == "S")
                    {
                        radioIncentFiscalNao.Checked = false;
                        radioIncentFiscalSim.Checked = true;
                        txtCabIncentivo.Text = dt.Rows[0]["DESC_INCENTIVO_FISC"].ToString();
                    }
                    else
                    {
                        radioIncentFiscalSim.Checked = false;
                        radioIncentFiscalNao.Checked = true;
                    }
                    comboCabPagmentos.SelectedValue = Convert.ToInt32(dt.Rows[0]["FORMA_PAGAMENTO"].ToString());
                    
                    if (dt.Rows[0]["FORMA_PAGAMENTO"].ToString() == "2" || dt.Rows[0]["FORMA_PAGAMENTO"].ToString() == "3")
                    {
                        txtCabFinanciamento.Enabled = true;
                        txtCabFinanciamento.Text = dt.Rows[0]["DESC_FINANCIAMENTO"].ToString();
                        txtCabInstFinanceira.Enabled = true;
                        txtCabInstFinanceira.Text = dt.Rows[0]["INSTITUICAO_FINANCEIRA"].ToString();
                    }
                    else
                    {
                        txtCabFinanciamento.Enabled = false;
                        txtCabFinanciamento.Text = "";
                        txtCabInstFinanceira.Enabled = false;
                        txtCabInstFinanceira.Text = "";
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["INDIC_DPES_CODIGO"].ToString()))
                    {
                        //Busca o Indicador da Solicitação atual, se estiver cadastrado
                        DataTable dtIndicador = cSolicitacao.getIndicadorNegocioSolic(numSolic, numRev, codEmpr);
                        if(dtIndicador.Rows.Count > 0)
                        {
                            comboCabIndicNegocio.SelectedValue = Convert.ToInt32(dtIndicador.Rows[0]["INDIC_DPES_CODIGO"].ToString());
                            comboCabIndicNegocio.Text = dtIndicador.Rows[0]["DESC_INDIC_NEGOCIO"].ToString();
                            txtCabComissaoIndic.Enabled = true;
                            txtCabComissaoIndic.Text = dt.Rows[0]["INDIC_PERC_COMISSAO"].ToString();
                        }
                    }
                    else
                    {
                        comboCabIndicNegocio.SelectedValue = 0;
                        txtCabComissaoIndic.Text = "";
                        txtCabComissaoIndic.Enabled = false;
                    }
                    txtCabDesconto.Text = dt.Rows[0]["MARGEM_DESCONTO"].ToString();
                    comboCabMoeda.SelectedValue = Convert.ToInt32(dt.Rows[0]["MOEDA_PROPOSTA"].ToString());
                }
                else
                {
                    MessageBox.Show("Não foi possível buscar os dados da solicitação informada.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Retorna o percentual das condições de pagamento atualizadas
        /// </summary>
        /// <param name="numero_solic"></param>
        /// <param name="num_revisao"></param>
        /// <returns></returns>
        private string getPercentualPagto(string numero_solic, string num_revisao)
        {
            try
            {
                CadSolicitacao csolicitacao = new CadSolicitacao();
                int percentCond = csolicitacao.getTotalPercentualCondPagto(numero_solic, num_revisao);
                return Convert.ToString(percentCond);
            }
            catch (Exception exc)
            {
                return "Erro: "+ exc.ToString();
            }
        }


        private void tbCabecalho_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (tbCabecalho.SelectedIndex == 1)
                {
                    string msgErro = "";
                    if (string.IsNullOrEmpty(txtCabecalhoCodCliente.Text))
                    {
                        msgErro += "Cliente não informado\n";
                    }
                    if (string.IsNullOrEmpty(txtCabecalhoObra.Text))
                    {
                        msgErro += "Campo Obra não informado\n";
                    }
                    if (!string.IsNullOrEmpty(msgErro))
                    {
                        MessageBox.Show(msgErro, "Campos obrigatórios em branco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbCabecalho.SelectedIndex = 0;
                    }
                }
                else if(tbCabecalho.SelectedIndex == 2)
                {
                    //Se não tiver nenhum registro, desabilita os botões
                    if(txtCondPgtoTotal.Text == "0" || string.IsNullOrEmpty(txtCondPgtoTotal.Text))
                    {
                        btnCondPgtoAtualizar.Visible = false;
                        btnCondPgtoExcluir.Visible = false;
                    }
                    else
                    {
                        btnCondPgtoAtualizar.Visible = true;
                        btnCondPgtoExcluir.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Carrega os tipos de empreendimentos no combobox.
        /// </summary>
        /// <param name="acao">Ação a ser realizada "novo" - Novo Registro, só carrega os dados no combo</param>
        private void atualizaGridTipoEmp(string acao)
        {
            try
            {
                CadSolicitacao csolicitacao = new CadSolicitacao();
                DataTable dt = new DataTable();
                dt = csolicitacao.getTipoNegocio();
                if (acao == "novo")
                {
                    DataRow dr = dt.NewRow();
                    dr["CODIGO"] = 0;
                    dr["DESCRICAO"] = "SELECIONE...";
                    dt.Rows.InsertAt(dr, 0);
                    comboCabTipo.DataSource = dt;
                    comboCabTipo.ValueMember = "CODIGO";
                    comboCabTipo.DisplayMember = "DESCRICAO";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Método que busca as condiçoes de pagamento de uma solicitação
        /// </summary>
        /// <param name="p_empr_cod">Empresa</param>
        /// <param name="p_num_solic">N° Solicitação</param>
        private void atualizaGridCondPag(string p_num_solic, string p_num_revisao, string p_empr_cod = null)
        {
            try
            {
                CadSolicitacao csolicitacao = new CadSolicitacao();
                DataTable dt1 = new DataTable();
                dgvCabCondicoesPgto.DataSource = csolicitacao.getCondPagamentoSolic(p_num_solic, p_num_revisao, p_empr_cod);
                //Verifica se atingiu 100%, se sim, desabilita o botão GRAVAR
                txtCondPgtoTotal.Text = getPercentualPagto(p_num_solic, p_num_revisao);
                if (txtCondPgtoTotal.Text == "100")
                {
                    btnGravaCondPgto.Enabled = false;
                }
                else
                {
                    btnGravaCondPgto.Enabled = true;
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private void txtCabComissaoIndic_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Habilita somente números e a tecla BackSpace
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) 
            {
                e.Handled = true;
            }
        }


        private void txtCabDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

      
        private void comboCabIndicNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboCabIndicNegocio.SelectedIndex != 0)
            {
                txtCabComissaoIndic.Enabled = true;
            }
            else
            {
                txtCabComissaoIndic.Enabled = false;
                txtCabComissaoIndic.Text = "";
            }
        }


        private void btnGravaCondPgto_Click(object sender, EventArgs e)
        {
            if(comboDescCondPgto.SelectedIndex == 0 || string.IsNullOrEmpty(txtCondPgtoPercentual.Text))
            {
                MessageBox.Show("Por favor, informe corretamente os dados para prosseguir.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CadSolicitacao csolicitacao = new CadSolicitacao();
                //Validação se o percentual cadastrado não ultrapassa os 100%
                int PercentAtual = csolicitacao.getTotalPercentualCondPagto(this.numero_solic.ToString(), this.NumRevisaoSolic); //Pega o total já cadastrado
                if(PercentAtual + Convert.ToInt32(txtCondPgtoPercentual.Text) > 100)
                {
                    MessageBox.Show("O valor informado ultrapassa os 100% do percentual total. Verifique o valor informado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCondPgtoPercentual.Text = "";
                    txtCondPgtoPercentual.Focus();
                }
                else
                {
                    this.SeqSolicitacao = csolicitacao.getSequenciaSolic(this.numero_solic.ToString());
                    csolicitacao.setPagamentosSolic(this.numero_solic.ToString(), this.NumRevisaoSolic, this.SeqSolicitacao, comboDescCondPgto.SelectedValue.ToString(), txtCondPgtoPercentual.Text);
                    MessageBox.Show("Condição de pagamento adicionada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizaGridCondPag(this.numero_solic.ToString(), this.NumRevisaoSolic, this.empr_representante);
                    txtCondPgtoPercentual.Text = "";
                    //Atualiza txt com o pecentual
                    txtCondPgtoTotal.Text = getPercentualPagto(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if (txtCondPgtoTotal.Text == "0" || string.IsNullOrEmpty(txtCondPgtoTotal.Text)) //Habilita/Desabilita botões Atualizar e Excluir
                    {
                        btnCondPgtoAtualizar.Visible = false;
                        btnCondPgtoExcluir.Visible = false;
                    }
                    else
                    {
                        btnCondPgtoAtualizar.Visible = true;
                        btnCondPgtoExcluir.Visible = true;
                    }
                }                
            }
        }


        private void btnCondPgtoAtualizar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirma alteração do registro selecionado?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if(dgvCabCondicoesPgto.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow r in dgvCabCondicoesPgto.SelectedRows)
                    {
                        CadSolicitacao csolicitacao = new CadSolicitacao();
                        int PercentTotal = csolicitacao.getTotalPercentualCondPagto(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        int PercentAtual = csolicitacao.getValorCondPgto(this.numero_solic.ToString(), this.NumRevisaoSolic, dgvCabCondicoesPgto["sequencia", r.Index].Value.ToString());
                        //Subtrai o PercentAtual do PercentTotal para realizar o update
                        PercentTotal = PercentTotal - PercentAtual;
                        if ( ((PercentTotal + Convert.ToInt32(dgvCabCondicoesPgto["perc_corresp", r.Index].Value.ToString())) > 100))
                        {
                            MessageBox.Show("O valor informado ultrapassa os 100% do percentual total. Verifique o valor informado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            csolicitacao.atualizaCondPagamento(dgvCabCondicoesPgto["perc_corresp", r.Index].Value.ToString(), this.numero_solic.ToString(), this.NumRevisaoSolic, dgvCabCondicoesPgto["sequencia", r.Index].Value.ToString());
                            atualizaGridCondPag(this.numero_solic.ToString(), this.NumRevisaoSolic, this.empr_representante);
                            //Atualiza txt com o pecentual
                            txtCondPgtoTotal.Text = getPercentualPagto(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            MessageBox.Show("Registro atualizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }



        private void dgvCabCondicoesPgto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCabCondicoesPgto.Columns[e.ColumnIndex].Name.Equals("percent_corresp"))
            {
                if (string.IsNullOrEmpty(dgvCabCondicoesPgto["percent_corresp", e.RowIndex].Value.ToString() ))
                {
                    MessageBox.Show("Por favor, informe o percentual correspondente ao método de pagamento.");
                    btnCondPgtoAtualizar.Enabled = false;
                }
                else
                {
                    btnCondPgtoAtualizar.Enabled = true;
                }
            }
        }


        private void btnCondPgtoExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente apagar o registro selecionado?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dgvCabCondicoesPgto.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow r in dgvCabCondicoesPgto.SelectedRows)
                    {
                        CadSolicitacao csolicitacao = new CadSolicitacao();
                        int retorno = csolicitacao.deletaCondPagto(this.numero_solic.ToString(), this.NumRevisaoSolic, dgvCabCondicoesPgto["sequencia", r.Index].Value.ToString());
                        if(retorno != 0)
                        {
                            atualizaGridCondPag(this.numero_solic.ToString(), NumRevisaoSolic.ToString(),this.empr_representante.ToString());
                            txtCondPgtoTotal.Text = getPercentualPagto(this.numero_solic.ToString(), NumRevisaoSolic); //Atualiza txt com o pecent
                            int PercentTotal = csolicitacao.getTotalPercentualCondPagto(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            atualizaGridCondPag(this.numero_solic.ToString(), this.NumRevisaoSolic, this.empr_representante);
                            //Atualiza txt com o pecentual
                            txtCondPgtoTotal.Text = getPercentualPagto(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (txtCondPgtoTotal.Text == "0" || string.IsNullOrEmpty(txtCondPgtoTotal.Text)) //Habilita/Desabilita botões Atualizar e Excluir
                            {
                                btnCondPgtoAtualizar.Visible = false;
                                btnCondPgtoExcluir.Visible = false;
                            }
                            else
                            {
                                btnCondPgtoAtualizar.Visible = true;
                                btnCondPgtoExcluir.Visible = true;
                            }
                            MessageBox.Show("Registro apagado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("O registro não pode ser apagado. Por favor, verifique os dados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                     
                    }
                }
            }
        }


        /// <summary>
        /// Classe usada para atribuir valores nos combos
        /// </summary>
        public class Combo
        {
            public int id { get; set; }
            public string valor { get; set; }

            public Combo(int id, string valor)
            {
                this.id = id;
                this.valor = valor;
            }
        }


        /// <summary>
        /// Inicializa os combobox do cabeçalho no primeiro carregamento da tela
        /// </summary>
        private void inicializaCombos()
        {
            CadSolicitacao csolicitacao = new CadSolicitacao();
            //Combo Tipo Negócios - Aba 2
            DataTable dt = new DataTable();
            dt = csolicitacao.getTipoNegocio();
            DataRow dr1 = dt.NewRow();
            dr1["CODIGO"] = 0;
            dr1["DESCRICAO"] = "SELECIONE...";
            dt.Rows.InsertAt(dr1, 0);
            comboCabTipo.DataSource = dt;
            comboCabTipo.ValueMember = "CODIGO";
            comboCabTipo.DisplayMember = "DESCRICAO";

            //Combo Finalidade
            List<Combo> comboFinalidade = new List<Combo>();
            comboFinalidade.Add(new Combo(0, "SELECIONE..."));
            comboFinalidade.Add(new Combo(1, "ESTIMATIVA"));
            comboFinalidade.Add(new Combo(2, "BANCO"));
            comboFinalidade.Add(new Combo(3, "PREVISÃO VERBA"));
            comboFinalidade.Add(new Combo(4, "NEGOCIAÇÃO"));
            comboCabFinalidade.DataSource = comboFinalidade;
            comboCabFinalidade.ValueMember = "id";
            comboCabFinalidade.DisplayMember = "valor";
            comboCabFinalidade.SelectedValue = 0;

            //Combo Empreendimento
            List<Combo> comboEmpreendimento = new List<Combo>();
            comboEmpreendimento.Add(new Combo(0, "SELECIONE..."));
            comboEmpreendimento.Add(new Combo(1, "OBRA NOVA"));
            comboEmpreendimento.Add(new Combo(2, "REFORMA"));
            comboEmpreendimento.Add(new Combo(3, "AMPLIAÇÃO DE FORNECIMENTO FOCKINK"));
            comboEmpreendimento.Add(new Combo(4, "AMPLIAÇÃO DE FORNECIMENTO TERCEIROS"));
            comboCabEmpreend.DataSource = comboEmpreendimento;
            comboCabEmpreend.ValueMember = "id";
            comboCabEmpreend.DisplayMember = "valor";
            comboCabEmpreend.SelectedValue = 0;

            //Combo Idioma
            List<Combo> comboIdioma = new List<Combo>();
            comboIdioma.Add(new Combo(1, "PORTUGUÊS"));
            comboIdioma.Add(new Combo(2, "ESPANHOL"));
            comboIdioma.Add(new Combo(3, "INGLÊS"));
            comboIdioma.Add(new Combo(4, "OUTRO"));
            comboCabIdioma.DataSource = comboIdioma;
            comboCabIdioma.ValueMember = "id";
            comboCabIdioma.DisplayMember = "valor";
            comboCabIdioma.SelectedValue = 1;

            //Combo Padrão Solução
            List<Combo> comboPadSolucao = new List<Combo>();
            comboPadSolucao.Add(new Combo(0, "SELECIONE..."));
            comboPadSolucao.Add(new Combo(1, "FOCKINK"));
            comboPadSolucao.Add(new Combo(2, "CLIENTE"));
            comboPadSolucao.Add(new Combo(3, "MISTO"));
            comboPadSolucao.Add(new Combo(4, "EDITAL/MEMORIAL"));
            comboCabPadraoSolucao.DataSource = comboPadSolucao;
            comboCabPadraoSolucao.ValueMember = "id";
            comboCabPadraoSolucao.DisplayMember = "valor";
            comboCabPadraoSolucao.SelectedValue = 0;

            //Combo Frete
            List<Combo> comboFrete = new List<Combo>();
            comboFrete.Add(new Combo(0, "SELECIONE..."));
            comboFrete.Add(new Combo(1, "CIF"));
            comboFrete.Add(new Combo(2, "FOB"));
            comboFrete.Add(new Combo(3, "EXPORTAÇÃO"));
            comboCabFrete.DataSource = comboFrete;
            comboCabFrete.ValueMember = "id";
            comboCabFrete.DisplayMember = "valor";
            comboCabFrete.SelectedValue = 0;

            //Combo Faturamento
            List<Combo> comboFat = new List<Combo>();
            comboFat.Add(new Combo(0, "SELECIONE..."));
            comboFat.Add(new Combo(1, "CLIENTE"));
            comboFat.Add(new Combo(2, "OBRA"));
            combocabFaturamento.DataSource = comboFat;
            combocabFaturamento.ValueMember = "id";
            combocabFaturamento.DisplayMember = "valor";
            combocabFaturamento.SelectedValue = 0;
            
            //Combo Venda Para
            List<Combo> comboVendaPara = new List<Combo>();
            comboVendaPara.Add(new Combo(0, "SELECIONE..."));
            comboVendaPara.Add(new Combo(1, "USO/CONSUMO"));
            comboVendaPara.Add(new Combo(2, "ATIVO IMOBILIZADO"));
            comboVendaPara.Add(new Combo(3, "INDUSTRIALIZAÇÃO"));
            comboVendaPara.Add(new Combo(4, "REVENDA"));
            comboVendaP.DataSource = comboVendaPara;
            comboVendaP.ValueMember = "id";
            comboVendaP.DisplayMember = "valor";
            comboVendaP.SelectedValue = 0;

            //Combo Forma Pagamento
            List<Combo> comboFormaPag = new List<Combo>();
            comboFormaPag.Add(new Combo(0, "SELECIONE..."));
            comboFormaPag.Add(new Combo(1, "RECURSOS PRÓPRIOS"));
            comboFormaPag.Add(new Combo(2, "FINANCIAMENTO"));
            comboFormaPag.Add(new Combo(3, "RECURSOS PRÓPRIOS/FINANCIAMENTOS"));
            comboFormaPag.Add(new Combo(4, "CARTA FIANÇA"));
            comboFormaPag.Add(new Combo(5, "SEGURO GARANTIA"));
            comboFormaPag.Add(new Combo(6, "CARTA PERFORMANCE"));
            comboCabPagmentos.DataSource = comboFormaPag;
            comboCabPagmentos.ValueMember = "id";
            comboCabPagmentos.DisplayMember = "valor";
            comboCabPagmentos.SelectedValue = 0;

            //Combo Moeda
            List<Combo> comboMoeda = new List<Combo>();
            comboMoeda.Add(new Combo(1, "REAIS"));
            comboMoeda.Add(new Combo(2, "DÓLAR"));
            comboMoeda.Add(new Combo(3, "EURO"));
            comboCabMoeda.DataSource = comboMoeda;
            comboCabMoeda.ValueMember = "id";
            comboCabMoeda.DisplayMember = "valor";
            comboCabMoeda.SelectedValue = 1;

            //Popula o combo dos eventos de pagamentos - Aba 3
            DataTable dt2 = new DataTable();
            dt2 = csolicitacao.getEventoPagamento();
            DataRow dr3 = dt2.NewRow();
            dr3["CODIGO"] = 0;
            dr3["DESCRICAO"] = "SELECIONE...";
            dt2.Rows.InsertAt(dr3, 0);
            comboDescCondPgto.DataSource = dt2;
            comboDescCondPgto.ValueMember = "CODIGO";
            comboDescCondPgto.DisplayMember = "DESCRICAO";
        }


        private void btnSalvaAlteracao_Click(object sender, EventArgs e)
        {
            string msgErro = "";
            if (comboCabTipo.SelectedIndex == 0)
            {
                msgErro += "Tipo de negócio em branco\n";
            }
            if (comboCabFinalidade.SelectedIndex == 0)
            {
                msgErro += "Finalidade não informada\n";
            }
            if (string.IsNullOrEmpty(txtVlrEstimadoEscopo.Text))
            {
                msgErro += "Valor Estimado Escopo não informado\n";
            }
            if (comboCabPadraoSolucao.SelectedIndex == 0)
            {
                msgErro += "Campo Padrão Solução não informado\n";
            }
            if (comboCabFrete.SelectedIndex == 0)
            {
                msgErro += "Frete não informado\n";
            }
            if (combocabFaturamento.SelectedIndex == 0)
            {
                msgErro += "Tipo de Faturamento não informado\n";
            }
            if (comboVendaP.SelectedIndex == 0)
            {
                msgErro += "Tipo de venda não informado\n";
            }
            if (comboCabPagmentos.SelectedIndex == 0)
            {
                msgErro += "Forma de pagamento não informada\n";
            }
            if ((radioIncentFiscalSim.Checked) && (string.IsNullOrEmpty(txtCabIncentivo.Text)))
            {
                msgErro += "Campo Incentivo Fiscal não informado\n";
            }
            if ((comboCabIndicNegocio.SelectedIndex != 0) && (string.IsNullOrEmpty(txtCabComissaoIndic.Text)))
            {
                msgErro += "Indicador de comissão não informado\n";
            }
            if (!string.IsNullOrEmpty(msgErro))
            {
                MessageBox.Show(msgErro, "Campos obrigatórios em branco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Seta as variáveis do insert
                setValores();
                CadSolicitacao cSolicitacao = new CadSolicitacao();
                cSolicitacao.setSolicitacao("U", this.numero_solic.ToString(), "1", status_solic, this.txtCabecalhoCodCliente.Text, this.cod_obra, this.observacao,
                this.nome_projeto, this.cod_tecnico, CodPessoaContatoTecnico, this.cod_comercial, CodPessoaContatoComercial, this.tipo_negocio,
                this.finalidade, this.empreendimento, this.idioma, this.outro_idioma, this.valor, this.dt_obra, this.dt_proposta, this.concorrentes, this.resp_padrao_solucao,
                this.frete, this.faturamento, this.vendaPara, this.contICMS, this.incentFiscal, this.desc_incentivo, this.formaPagamento, this.financiamento, this.instFinanceira,
                this.indic_empr_codigo, this.indic_dpes_codigo, this.indicComissao, this.margemDesconto, this.moeda, this.cod_representante, this.empr_representante);

                MessageBox.Show("Alterações realizadas com sucesso!", "Cadastro de Solicitação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Traz os dados da solicitação gravada para os campos da tela
                caregaCampos(empr_representante, numero_solic.ToString(), "1");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SOEFC.Escopo Teste = new Escopo();
        }

        private void btnEsc19Salvar_Click(object sender, EventArgs e)
        {
            if ( (!checkAbFecValas.Checked) && (!checkBasePoste.Checked) && (!checkCasaBombas.Checked) && (!checkCaixaInspecao.Checked) && (!checkBaseSubestacao.Checked) && (!checkOutro.Checked))
            {
                MessageBox.Show("Por favor, selecione pelo menos 1 escopo.", "Definição do escopo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (checkOutro.Checked && string.IsNullOrEmpty(txtEsc19Necessidade.Text))
                {
                    MessageBox.Show("Por favor, informe o outro escopo.", "Definição do escopo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string AbFecValas;
                    string CaixaInspecao;
                    string BasePostes;
                    string BaseSubestacao;
                    string CasaBombas;
                    string OutroEscopo;
                    

                    if (checkAbFecValas.Checked)
                    {
                        AbFecValas = "S";
                    }
                    else
                    {
                        AbFecValas = "N";
                    }
                    if (checkCaixaInspecao.Checked)
                    {
                        CaixaInspecao = "S";
                    }
                    else
                    {
                        CaixaInspecao = "N";
                    }
                    if (checkBasePoste.Checked)
                    {
                        BasePostes = "S";
                    }
                    else
                    {
                        BasePostes = "N";
                    }
                    if (checkBaseSubestacao.Checked)
                    {
                        BaseSubestacao = "S";
                    }
                    else
                    {
                        BaseSubestacao = "N";
                    }
                    if (checkCasaBombas.Checked)
                    {
                        CasaBombas = "S";
                    }
                    else
                    {
                        CasaBombas = "N";
                    }
                    if (checkOutro.Checked)
                    {
                        OutroEscopo = "S";
                    }
                    else
                    {
                        OutroEscopo = "N";
                    }

                    SOEF_CLASS.Escopo_19 Escopo19 = new SOEF_CLASS.Escopo_19(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    MessageBox.Show("Necessidade: " + txtEsc19Necessidade.Text);
                    MessageBox.Show("Observação: " + txtEsc19Observacoes.Text);
                    Escopo19.gravaEscopo19(AbFecValas, CaixaInspecao, BasePostes, BaseSubestacao, CasaBombas, OutroEscopo, txtEsc19Necessidade.Text, txtEsc19Observacoes.Text);


                }
            }
        }

        private void check6Esc19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOutro.Checked)
            {
                lblNecessidade.Visible = true;
                txtEsc19Necessidade.Visible = true;
            }
            else
            {
                lblNecessidade.Visible = false;
                txtEsc19Necessidade.Visible = false;
            }
        }
    }
}
