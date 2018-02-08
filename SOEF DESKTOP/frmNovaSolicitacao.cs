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
        public string informarAliqImposto;
        public string considerarTaxaFlat;

        public string maoObraCli;
        public string tipoMaoObra;
        public string indExportacao;
        public string indRespZeloMaterial;
        public string indEngResidente;
        public string indTecSeguranca;
        public string indSegRespCivil;
        public string indPlataforma;
        public string indDatabook;
        public string indTreinamentos;
        public string indCanteiroObras;
        public string indOutraNecessidade;
        public string descOutraNecessidade;

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
                //Seta a Revisão p/ Novo Registro como R0C0 por default
                this.NumRevisaoSolic = "R0C0";
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
            tabNovaSolicitacao.Controls.Remove(tabEscopo20);
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
            if (comboCabPagmentos.SelectedValue.ToString()  == "F" || comboCabPagmentos.SelectedValue.ToString() == "P")
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
            if(!radioCabeAliqImpostoS.Checked && !radioCabeAliqImpostoN.Checked)
            {
                msgErro += "Marque uma opção no campo Informar Aliq. Imposto\n";
            }
            if(!radioCabeConsiderarFlatS.Checked && !radioCabeConsiderarFlatN.Checked)
            {
                msgErro += "Marque uma opção no campo Considerar Taxa Flat\n";
            }

            if( (comboCabIndicNegocio.SelectedIndex != 0) && (string.IsNullOrEmpty(txtCabComissaoIndic.Text)) )
            {
                msgErro += "Indicador de comissão não informado\n";
            }
            if(!radioCabMaoObraCliS.Checked && !radioCabMaoObraCliN.Checked)
            {
                msgErro += "Informe o campo Mão de Obra Cliente\n";
            }
            if(!radioCabExportS.Checked && !radioCabExportN.Checked)
            {
                msgErro += "Informe o campo Exportação\n";
            }
            if(comboCabZelo.SelectedIndex == 0)
            {
                msgErro += "Informe o campo O Zelo de Materiais Deve Ser\n";
            }
            if (checkCabOutro.Checked)
            {
                if (string.IsNullOrEmpty(txtCabDescNecessidade.Text))
                {
                    msgErro += "Informe o campo Descrição da Necessidade\n";
                }
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
                    this.indic_empr_codigo, this.indic_dpes_codigo, this.indicComissao, this.margemDesconto, this.moeda, this.cod_representante, this.empr_representante, this.informarAliqImposto, 
                    this.considerarTaxaFlat, this.maoObraCli, this.tipoMaoObra, this.indExportacao, this.indRespZeloMaterial, this.indEngResidente, this.indTecSeguranca, this.indSegRespCivil, 
                    this.indPlataforma, this.indDatabook, this.indTreinamentos, this.indCanteiroObras, this.indOutraNecessidade, this.descOutraNecessidade); 
                    //Busca o número da solicitação cadastrada
                    this.numero_solic = Convert.ToInt32(cSolicitacao.getNumeroSolicitacao()) - 1;
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
            this.formaPagamento = comboCabPagmentos.SelectedValue.ToString();
            this.financiamento = txtCabFinanciamento.Text;
            this.instFinanceira = txtCabInstFinanceira.Text;

            //Aliq. Imposto
            if (radioCabeAliqImpostoS.Checked)
            {
                this.informarAliqImposto = "S";
            }
            else
            {
                this.informarAliqImposto = "N";
            }
            //Taxa Flat
            if (radioCabeConsiderarFlatS.Checked)
            {
                this.considerarTaxaFlat = "S";
            }
            else
            {
                this.considerarTaxaFlat = "N";
            }
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
            //Mão de Obra Cliente
            if (radioCabMaoObraCliS.Checked)
            {
                this.maoObraCli = "S";
            }
            else
            {
                this.maoObraCli = "N";
            }

            //Tipo Mão de Obra
            this.tipoMaoObra = comboCabTipoMaoObra.SelectedIndex.ToString();
            //Exportação
            if (radioCabExportS.Checked)
            {
                this.indExportacao = "S";
            }
            else
            {
                this.indExportacao = "N";
            }
            //Zelo
            this.indRespZeloMaterial = comboCabZelo.SelectedValue.ToString();
            //Checkboxes
            if (checkCabEngResidente.Checked)
            {
                this.indEngResidente = "S";
            }
            else
            {
                this.indEngResidente = "N";
            }
            if (checkCabTecSeg.Checked)
            {
                this.indTecSeguranca = "S";
            }
            else
            {
                this.indTecSeguranca = "N";
            }
            if (checkCabTecSeg.Checked)
            {
                this.indTecSeguranca = "S";
            }
            else
            {
                this.indTecSeguranca = "N";
            }
            if (checkCabSeguro.Checked)
            {
                this.indSegRespCivil = "S";
            }
            else
            {
                this.indSegRespCivil = "N";
            }
            if (checkCabPlataforma.Checked)
            {
                this.indPlataforma = "S";
            }
            else
            {
                this.indPlataforma = "N";
            }
            if (checkCabDatabook.Checked)
            {
                this.indDatabook = "S";
            }
            else
            {
                this.indDatabook = "N";
            }
            if (checkCabTreinamentos.Checked)
            {
                this.indTreinamentos = "S";
            }
            else
            {
                this.indTreinamentos = "N";
            }
            if (checkCabCanteiroObras.Checked)
            {
                this.indCanteiroObras = "S";
            }
            else
            {
                this.indCanteiroObras = "N";
            }
            if (checkCabOutro.Checked)
            {
                this.indOutraNecessidade = "S";
                this.descOutraNecessidade = txtCabDescNecessidade.Text;
            }
            else
            {
                this.indOutraNecessidade = "N";
                this.descOutraNecessidade = null;
            }


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
                    comboCabPagmentos.SelectedValue = dt.Rows[0]["FORMA_PAGAMENTO"].ToString();
                    comboCabPagmentos.Text = dt.Rows[0]["DESC_FORMA_PAG"].ToString();
                    
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
                    //Aliq. Imposto
                    if(dt.Rows[0]["INFORMAR_ALIQ_IMPOSTO"].ToString() == "S")
                    {
                        radioCabeAliqImpostoS.Checked = true;
                    }
                    else
                    {
                        radioCabeAliqImpostoN.Checked = true;
                    }
                    //Taxa Flat
                    if(dt.Rows[0]["CONSIDERAR_TAXA_FLAT"].ToString() == "S")
                    {
                        radioCabeConsiderarFlatS.Checked = true;
                    }
                    else
                    {
                        radioCabeConsiderarFlatN.Checked = true;
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

                    //Mão Obra Cliente
                    if(dt.Rows[0]["MAO_OBRA_CLIENTE"].ToString() == "S")
                    {
                        radioCabeAliqImpostoS.Checked = true;
                    }
                    else
                    {
                        radioCabeAliqImpostoN.Checked = true;
                    }
                    //Tipo Mão de Obra
                    comboCabTipoMaoObra.SelectedIndex = Convert.ToInt32(dt.Rows[0]["TIPO_MAO_OBRA"].ToString());
                    if(dt.Rows[0]["IND_EXPORTACAO"].ToString() == "S")
                    {
                        radioCabExportS.Checked = true;
                    }
                    else
                    {
                        radioCabExportN.Checked = false;
                    }
                    //Zelo Material
                    if(dt.Rows[0]["IND_RESP_ZELO_MATERIAL"].ToString() == "CL")
                    {
                        comboCabZelo.SelectedIndex = 1;
                    }
                    else if (dt.Rows[0]["IND_RESP_ZELO_MATERIAL"].ToString() == "FN")
                    {
                        comboCabZelo.SelectedIndex = 2;
                    }
                    else if (dt.Rows[0]["IND_RESP_ZELO_MATERIAL"].ToString() == "FA")
                    {
                        comboCabZelo.SelectedIndex = 3;
                    }
                    else if (dt.Rows[0]["IND_RESP_ZELO_MATERIAL"].ToString() == "NA")
                    {
                        comboCabZelo.SelectedIndex = 4;
                    }
                    //Checkboxes a considerar no escopo
                    if (dt.Rows[0]["IND_ENG_RESIDENTE"].ToString() == "S")
                    {
                        checkCabEngResidente.Checked = true;
                    }
                    else
                    {
                        checkCabEngResidente.Checked = false;
                    }
                    if (dt.Rows[0]["IND_TEC_SEGURANCA"].ToString() == "S")
                    {
                        checkCabTecSeg.Checked = true;
                    }
                    else
                    {
                        checkCabTecSeg.Checked = false;
                    }
                    if (dt.Rows[0]["IND_SEG_RESP_CIVIL"].ToString() == "S")
                    {
                        checkCabSeguro.Checked = true;
                    }
                    else
                    {
                        checkCabSeguro.Checked = false;
                    }
                    if (dt.Rows[0]["IND_PLATAFORMA"].ToString() == "S")
                    {
                        checkCabPlataforma.Checked = true;
                    }
                    else
                    {
                        checkCabPlataforma.Checked = false;
                    }
                    if (dt.Rows[0]["IND_DATABOOK"].ToString() == "S")
                    {
                        checkCabDatabook.Checked = true;
                    }
                    else
                    {
                        checkCabDatabook.Checked = false;
                    }
                    if (dt.Rows[0]["IND_TREINAMENTOS"].ToString() == "S")
                    {
                        checkCabTreinamentos.Checked = true;
                    }
                    else
                    {
                        checkCabTreinamentos.Checked = false;
                    }
                    if (dt.Rows[0]["IND_CANTEIRO_OBRAS"].ToString() == "S")
                    {
                        checkCabCanteiroObras.Checked = true;
                    }
                    else
                    {
                        checkCabCanteiroObras.Checked = false;
                    }
                    if (dt.Rows[0]["IND_OUTRA_NECESSIDADE"].ToString() == "S")
                    {
                        checkCabOutro.Checked = true;
                        label145.Visible = true;
                        txtCabDescNecessidade.Visible = true;
                        txtCabDescNecessidade.Text = dt.Rows[0]["DESC_OUTRA_NECESSIDADE"].ToString();
                    }
                    else
                    {
                        checkCabOutro.Checked = false;
                        label145.Visible = false;
                        txtCabDescNecessidade.Text = "";
                        txtCabDescNecessidade.Visible = false;
                    }
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

            //Combo Tipo de Mão de Obra
            List<Combo> TipoMaoObra = new List<Combo>();
            TipoMaoObra.Add(new Combo(0, "SELECIONE..."));
            TipoMaoObra.Add(new Combo(1, "C / HOSPEDAGEM - C / ALIMENTAÇÃO"));
            TipoMaoObra.Add(new Combo(2, "C / HOSPEDAGEM - S / ALIMENTAÇÃO"));
            TipoMaoObra.Add(new Combo(3, "S / HOSPEDAGEM - C / ALIMENTAÇÃO"));
            TipoMaoObra.Add(new Combo(3, "C / HOSPEDAGEM - S / ALIMENTAÇÃO"));
            comboCabTipoMaoObra.DataSource = TipoMaoObra;
            comboCabTipoMaoObra.ValueMember = "id";
            comboCabTipoMaoObra.DisplayMember = "valor";
            comboCabTipoMaoObra.SelectedValue = 0;

            //Combo O Zelo de Materiais deve ser
            List<Combo> ZeloMateriais = new List<Combo>();
            ZeloMateriais.Add(new Combo(0, "SELECIONE..."));           
            ZeloMateriais.Add(new Combo(1, "CLIENTE"));
            ZeloMateriais.Add(new Combo(2, "FOCKINK - NÃO ARMADA"));
            ZeloMateriais.Add(new Combo(3, "FOCKINK - ARMADA"));
            ZeloMateriais.Add(new Combo(3, "NÃO SE APLICA"));
            comboCabZelo.DataSource = ZeloMateriais;
            comboCabZelo.ValueMember = "id";
            comboCabZelo.DisplayMember = "valor";
            comboCabZelo.SelectedValue = 0;

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
            DataTable dt1 = csolicitacao.getFormaPagamento(null);
            DataRow dr2 = dt1.NewRow();
            dr2["VALOR"] = 0;
            dr2["DESCRICAO"] = "SELECIONE...";
            dt1.Rows.InsertAt(dr2, 0);
            comboCabPagmentos.DataSource = dt1;
            comboCabPagmentos.ValueMember = "VALOR";
            comboCabPagmentos.DisplayMember = "DESCRICAO";
            
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
                cSolicitacao.setSolicitacao("U", this.numero_solic.ToString(), this.NumRevisaoSolic, status_solic, this.txtCabecalhoCodCliente.Text, this.cod_obra, this.observacao,
                this.nome_projeto, this.cod_tecnico, CodPessoaContatoTecnico, this.cod_comercial, CodPessoaContatoComercial, this.tipo_negocio,
                this.finalidade, this.empreendimento, this.idioma, this.outro_idioma, this.valor, this.dt_obra, this.dt_proposta, this.concorrentes, this.resp_padrao_solucao,
                this.frete, this.faturamento, this.vendaPara, this.contICMS, this.incentFiscal, this.desc_incentivo, this.formaPagamento, this.financiamento, this.instFinanceira,
                this.indic_empr_codigo, this.indic_dpes_codigo, this.indicComissao, this.margemDesconto, this.moeda, this.cod_representante, this.empr_representante, this.informarAliqImposto, 
                this.considerarTaxaFlat, this.maoObraCli, this.tipoMaoObra, this.indExportacao, this.indRespZeloMaterial, this.indEngResidente, this.indTecSeguranca, this.indSegRespCivil, 
                this.indPlataforma, this.indDatabook, this.indTreinamentos, this.indCanteiroObras, this.indOutraNecessidade, this.descOutraNecessidade);

                MessageBox.Show("Alterações realizadas com sucesso!", "Cadastro de Solicitação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Traz os dados da solicitação gravada para os campos da tela
                caregaCampos(empr_representante, numero_solic.ToString(), this.NumRevisaoSolic);
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
                    int vlrRetorno;
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
                    //Verifica se é registro novo ou alteração
                    if (AcaoTela == "N")
                    {
                        vlrRetorno = Escopo19.gravaEscopo19(AbFecValas, CaixaInspecao, BasePostes, BaseSubestacao, CasaBombas, OutroEscopo, txtEsc19Necessidade.Text, txtEsc19Observacoes.Text, "S");
                        if(vlrRetorno > 0)
                        {
                            MessageBox.Show("Escopo registrado com sucesso!");
                            listaEscopo19(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            btnEsc19Excluir.Visible = true;
                            checkEscopo19.Checked = true;
                            checkEscopo19.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro ao definir este escopo.");
                        }
                    }
                    else
                    {
                        vlrRetorno = Escopo19.updateEscopo(this.numero_solic.ToString(), this.NumRevisaoSolic, AbFecValas, CaixaInspecao, BasePostes, BaseSubestacao, CasaBombas, OutroEscopo, txtEsc19Necessidade.Text, txtEsc19Observacoes.Text);
                        if (vlrRetorno > 0)
                        {
                            MessageBox.Show("Escopo gravado/atualizado com sucesso!");
                            checkEscopo19.Checked = true;
                            checkEscopo19.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro na atualização deste escopo.");
                        }
                    }
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

        /// <summary>
        /// Lista os dados do Escopo 10_3
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo10_3(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_10_3 Escopo10_3 = new SOEF_CLASS.Escopo_10_3(pNumSolic, pNumRev);
                DataTable dt = Escopo10_3.getEscopo_10_3();
                if(dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        combo10_3Tensao.SelectedIndex = Convert.ToInt32(dr["TENSAO_TRIFASICA"].ToString());
                        combo10_3Freq.SelectedIndex = Convert.ToInt32(dr["FREQUENCIA"].ToString());
                        if(combo10_3Freq.SelectedIndex == 3)
                        {
                            txt10_3OutraFreq.Enabled = true;
                            txt10_3OutraFreq.Text = dr["DESC_OUTRA_FREQUENCIA"].ToString();
                        }
                        else
                        {
                            txt10_3OutraFreq.Enabled = false;
                            txt10_3OutraFreq.Text = "";
                        }
                        txt10_3Obs.Text = dr["OBSERVACOES"].ToString();

                        if(dr["DADOS_AMBIENTAIS"].ToString() == "U")
                        {
                            combo10_3DadosAmbientais.SelectedIndex = 1;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "M")
                        {
                            combo10_3DadosAmbientais.SelectedIndex = 2;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                        {
                            combo10_3DadosAmbientais.SelectedIndex = 3;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                        {
                            combo10_3DadosAmbientais.SelectedIndex = 4;
                        }
                        btn10_3Excluir.Visible = true;
                    }
                }
                else
                {
                    combo10_3Tensao.SelectedIndex = 0;
                    combo10_3DadosAmbientais.SelectedIndex = 0;
                    combo10_3Freq.SelectedIndex = 0;
                    txt10_3OutraFreq.Text = "";
                    txt10_3OutraFreq.Enabled = false;
                    combo10_3Local.SelectedIndex = 0;
                    txt10_3Obs.Text = "";
                    btn10_3Excluir.Visible = false;
                }

                
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista os dados do Escopo 10_4
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo10_4(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_10_4 Escopo10_4 = new SOEF_CLASS.Escopo_10_4(pNumSolic, pNumRev);
                DataTable dt = Escopo10_4.getEscopo_10_4();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if(dr["MATERIAL_TAMPA"].ToString() == "P")
                        {
                            combo10_4MatTampa.SelectedIndex = 1;
                        }
                        else
                        {
                            combo10_4MatTampa.SelectedIndex = 2;
                        }
                        
                        if(combo10_4MatTampa.SelectedIndex == 1)
                        {
                            txt10_4QtdTampa.Enabled = true;
                            txt10_4QtdTampa.Text = dr["QUANTIDADE"].ToString();
                            //Desabilita campos da segunda opção
                            txt10_4Qtd.Text = "";
                            txt10_4Qtd.Enabled = false;
                            txt10_4Comprimento.Text = "";
                            txt10_4Comprimento.Enabled = false;
                            txt10_4Largura.Text = "";
                            txt10_4Largura.Enabled = false;
                            combo10_4TipoTampa.SelectedIndex = 0;
                            combo10_4TipoTampa.Enabled = false;
                            btn10_4GravaTampa.Enabled = false;
                            dgv10_4Tampa.DataSource = null;
                            dgv10_4Tampa.Enabled = false;
                        }
                        else if (combo10_4MatTampa.SelectedIndex == 2)
                        {
                            txt10_4Qtd.Enabled = true;
                            txt10_4Qtd.Text = "";
                            txt10_4Comprimento.Enabled = true;
                            txt10_4Comprimento.Text = "";
                            txt10_4Largura.Enabled = true;
                            txt10_4Largura.Text = "";
                            combo10_4TipoTampa.Enabled = true;
                            combo10_4TipoTampa.SelectedIndex = 0;
                            dgv10_4Tampa.Enabled = true;
                            //Popula o Data Grid com os dados da Tampa Escopo
                            dgv10_4Tampa.DataSource = Escopo10_4.getTampaEscopo("10_4", null);
                            btn10_4GravaTampa.Enabled = true;
                            //Desabilita campos 1° opcao
                            txt10_4QtdTampa.Text = "";
                            txt10_4QtdTampa.Enabled = false;
                        }
                        txt10_4Obs.Text = dr["OBSERVACOES"].ToString();
                        btn10_4Excluir.Visible = true;
                    }
                }
                else
                {
                    txt10_4Qtd.Text = "";
                    txt10_4Qtd.Enabled = false;
                    txt10_4Comprimento.Text = "";
                    txt10_4Comprimento.Enabled = false;
                    txt10_4Largura.Text = "";
                    txt10_4Largura.Enabled = false;
                    combo10_4TipoTampa.SelectedIndex = 0;
                    combo10_4TipoTampa.Enabled = false;
                    btn10_4GravaTampa.Enabled = false;
                    combo10_4MatTampa.SelectedIndex = 0;
                    dgv10_4Tampa.DataSource = null;
                    dgv10_4Tampa.Enabled = false;
                    txt10_4Obs.Text = "";
                    btn10_3Excluir.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista os dados do Escopo 05
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo05(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_05 Escopo05 = new SOEF_CLASS.Escopo_05(pNumSolic, pNumRev);
                DataTable dt = Escopo05.getEscopo_05();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        combo05Freq.SelectedIndex = Convert.ToInt32(dr["FREQUENCIA_TRANSF"].ToString());
                        if (dr["DADOS_AMBIENTAIS"].ToString() == "U")
                        {
                            combo05DadosAmbientais.SelectedIndex = 1;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "M")
                        {
                            combo05DadosAmbientais.SelectedIndex = 2;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                        {
                            combo05DadosAmbientais.SelectedIndex = 3;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                        {
                            combo05DadosAmbientais.SelectedIndex = 4;
                        }
                        txt05Obs.Text = dr["OBSERVACOES"].ToString();
                    }
                    btnE10_1Excluir.Visible = true;
                }
                else
                {
                    //Reseta os campos da tela
                    combo05DadosAmbientais.SelectedIndex = 0;
                    combo05Freq.SelectedIndex = 0;                    
                    txt05Obs.Text = "";
                    btn05Excluir.Visible = false;
                    tabNovaSolicitacao.SelectedTab.Name = "tabEscopo5"; //Conferir se o nome está correto
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista os dados do Escopo 05_1
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo05_1(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_05_1 Escopo05_1 = new SOEF_CLASS.Escopo_05_1(pNumSolic, pNumRev);
                DataTable dt = Escopo05_1.getEscopo_05_1();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if(dr["IND_POTENCIA_INFORM_DEF"].ToString() == "I")
                        {
                            radio5_1PotInf.Checked = true;
                        }
                        else
                        {
                            radio5_1PotFD.Checked = true;
                            if(dr["IND_LISTA_CARGAS"].ToString() == "S")
                            {
                                radio5_1ListaCargaS.Checked = true;
                            }
                            else
                            {
                                radio5_1ListaCargaN.Checked = true;
                            }
                        }
                        combo5_1TensaoPrimaria.SelectedIndex = Convert.ToInt32(dr["TENSAO_PRIMARIA"].ToString());
                        if (combo5_1TensaoPrimaria.SelectedIndex == 4)
                        {
                            txt5_1DescTensaoPrim.Enabled = true;
                            txt5_1DescTensaoPrim.Text = dr["DESC_OUTRA_TENSAO_PRIM"].ToString();
                        }
                        else
                        {
                            txt5_1DescTensaoPrim.Text = "";
                            txt5_1DescTensaoPrim.Enabled = false;
                        }
                        combo5_1TensaoSec.SelectedIndex = Convert.ToInt32(dr["TENSAO_SECUNDARIA"].ToString());
                        if (combo5_1TensaoSec.SelectedIndex == 4)
                        {
                            txt5_1DescTenSec.Enabled = true;
                            txt5_1DescTenSec.Text = dr["DESC_OUTRA_TENSAO_SECUN"].ToString();
                        }
                        else
                        {
                            txt5_1DescTenSec.Text = "";
                            txt5_1DescTenSec.Enabled = false;
                        }
                        if (dr["IND_INVOLUCRO_PROTEC"].ToString() == "S")
                        {
                            radio5_1InProtecaoS.Checked = true;
                            combo5_1Pintura.Enabled = true;   
                            if (dr["TIPO_PINTURA_INVOLUCRO"].ToString() == "R")
                            {
                                combo5_1Pintura.SelectedIndex = 1;
                            }
                            else if (dr["TIPO_PINTURA_INVOLUCRO"].ToString() == "M")
                            {
                                combo5_1Pintura.SelectedIndex = 2;
                            }
                            else if (dr["TIPO_PINTURA_INVOLUCRO"].ToString() == "E")
                            {
                                combo5_1Pintura.SelectedIndex = 3;
                            }
                        }
                        else
                        {
                            combo5_1Pintura.SelectedIndex = 0;
                            combo5_1Pintura.Enabled = false;
                            radio5_1InProtecaoN.Checked = true;
                        }
                        txt5_1Obs.Text = dr["OBSERVACOES"].ToString();
                    }
                    btn05_1Excluir.Visible = true;
                }
                else
                {
                    //Reseta os campos da tela
                    radio5_1PotInf.Checked = true;
                    combo5_1TensaoPrimaria.SelectedIndex = 0;
                    combo5_1TensaoSec.SelectedIndex = 0;
                    combo5_1Pintura.SelectedIndex = 0;
                    txt5_1Obs.Text = "";
                    btn05_1Excluir.Visible = false;
                    tabNovaSolicitacao.SelectedTab.Name = "tabEscopo5"; //Conferir se o nome está correto
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lista os dados do Escopo 05_2
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo05_2(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_05_2 Escopo05_2 = new SOEF_CLASS.Escopo_05_2(pNumSolic, pNumRev);
                DataTable dt = Escopo05_2.getEscopo_05_2();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["IND_POTENCIA_INFORM_DEF"].ToString() == "I")
                        {
                            radio5_2PotInf.Checked = true;
                        }
                        else
                        {
                            radio5_2PotDef.Checked = true;
                            if (dr["IND_LISTA_CARGAS"].ToString() == "S")
                            {
                                radio5_2ListaCargasS.Checked = true;
                            }
                            else
                            {
                                radio5_2ListaCargasN.Checked = true;
                            }
                        }
                        //Tensão Primária
                        combo5_2TensaoPrim.SelectedIndex = Convert.ToInt32(dr["TENSAO_PRIMARIA"].ToString());
                        if (combo5_2TensaoPrim.SelectedIndex == 7)
                        {
                            txt5_2DescOutraTensaoPrim.Enabled = true;
                            txt5_2DescOutraTensaoPrim.Text = dr["DESC_OUTRA_TENSAO_PRIM"].ToString();
                        }
                        else
                        {
                            txt5_2DescOutraTensaoPrim.Text = "";
                            txt5_2DescOutraTensaoPrim.Enabled = false;
                        }
                        //Tensão Secundária
                        combo5_2TensaoSec.SelectedIndex = Convert.ToInt32(dr["TENSAO_SECUNDARIA"].ToString());
                        if (combo5_2TensaoSec.SelectedIndex == 7)
                        {
                            txt5_2DescOutraTensaoSec.Enabled = true;
                            txt5_2DescOutraTensaoSec.Text = dr["DESC_OUTRA_TENSAO_SECUN"].ToString();
                        }
                        else
                        {
                            txt5_2DescOutraTensaoSec.Text = "";
                            txt5_2DescOutraTensaoSec.Enabled = false;
                        }
                        //Meio Isolante
                        combo5_2MeioIsol.SelectedIndex = Convert.ToInt32(dr["MEIO_ISOLANTE"].ToString());
                        if(combo5_2MeioIsol.SelectedIndex == 1)
                        {
                            //Exige Buchas MT e BT
                            if (string.IsNullOrEmpty(dr["BUCHAS_MT"].ToString()))
                            {
                                combo5_2BuchaMT.SelectedIndex = 0;
                            }
                            else
                            {
                                combo5_2BuchaMT.SelectedIndex = Convert.ToInt32(dr["BUCHAS_MT"].ToString());
                            }
                            //MessageBox.Show("Bucha MT: "+combo5_2BuchaMT.SelectedIndex.ToString());
                            if (combo5_2BuchaMT.SelectedIndex == 4)
                            {
                                txt5_2DescOutraBuchaMT.Enabled = true;
                                txt5_2DescOutraBuchaMT.Text = dr["DESC_OUTRA_BUCHA_MT"].ToString();
                            }
                            else
                            {
                                txt5_2DescOutraBuchaMT.Text = "";
                                txt5_2DescOutraBuchaMT.Enabled = false;
                            }
                            if (string.IsNullOrEmpty(dr["BUCHAS_BT"].ToString()))
                            {
                                combo5_2BuchaBT.SelectedIndex = 0;
                            }
                            else
                            {
                                combo5_2BuchaBT.SelectedIndex = Convert.ToInt32(dr["BUCHAS_BT"].ToString());
                            }
                            MessageBox.Show("Bucha BT: " + combo5_2BuchaBT.SelectedIndex.ToString());
                            if (combo5_2BuchaBT.SelectedIndex == 5)
                            {
                                txt5_2DescOutraBuchaBT.Enabled = true;
                                txt5_2DescOutraBuchaBT.Text = dr["DESC_OUTRA_BUCHA_BT"].ToString();
                            }
                            else
                            {
                                txt5_2DescOutraBuchaBT.Text = "";
                                txt5_2DescOutraBuchaBT.Enabled = false;
                            }
                        }
                        else if (combo5_2MeioIsol.SelectedIndex == 3)
                        {
                            //Exige Pintura Meio Isolante
                            label172.Visible = true;
                            combo5_2Pintura.Visible = true;
                            if (dr["TIPO_PINTURA_MEIO_ISOLANTE"].ToString() == "R")
                            {
                                combo5_2Pintura.SelectedIndex = 1;
                            }
                            else if (dr["TIPO_PINTURA_MEIO_ISOLANTE"].ToString() == "M")
                            {
                                combo5_2Pintura.SelectedIndex = 2;
                            }
                            else if (dr["TIPO_PINTURA_MEIO_ISOLANTE"].ToString() == "E")
                            {
                                combo5_2Pintura.SelectedIndex = 3;
                            }
                        }
                        else if(combo5_2MeioIsol.SelectedIndex == 4)
                        {
                            //Exige Descrição outro meio Isolante
                            txt5_2DescOutroMeio.Enabled = true;
                            txt5_2DescOutroMeio.Text = dr["DESC_OUTRO_MEIO_ISOLANTE"].ToString();
                        }
                        txt5_2Obs.Text = dr["OBSERVACOES"].ToString();
                    }
                    btn5_2Excluir.Visible = true;
                }
                else
                {
                    //Reseta os campos da tela
                    txt5_2Obs.Text = "";
                    radio5_2PotInf.Checked = true;
                    combo5_2TensaoPrim.SelectedIndex = 0;
                    combo5_2TensaoSec.SelectedIndex = 0;
                    combo5_2MeioIsol.SelectedIndex = 0;
                    combo5_2Pintura.SelectedIndex = 0;
                    combo5_2BuchaMT.SelectedIndex = 0;
                    combo5_2BuchaBT.SelectedIndex = 0;
                    txt5_2DescOutraBuchaMT.Text = "";
                    txt5_2DescOutraBuchaMT.Visible = true;
                    txt5_2DescOutraBuchaBT.Text = "";
                    txt5_2DescOutraBuchaBT.Visible = true;
                    combo5_2Potencia.SelectedIndex = 0;
                    btn5_2Excluir.Visible = false;
                    tabNovaSolicitacao.SelectedTab.Name = "tabEscopo5_2"; //Conferir se o nome está correto
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Lista os dados do Escopo 20
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo20(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_20 Escopo20 = new SOEF_CLASS.Escopo_20(pNumSolic, pNumRev);
                dgvListaEsc20.DataSource = Escopo20.getEscopo20(pNumSolic, pNumRev);  
                if(dgvListaEsc20.Rows.Count > 0)
                {
                    btnEsc20Excluir.Visible = true;                    
                }
                else
                {
                    btnEsc20Excluir.Visible = false;                   
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista dados na tela Escopo 10_1
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo10_1(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_10_1 Escopo10_1 = new SOEF_CLASS.Escopo_10_1(pNumSolic, pNumRev);
                DataTable dt = Escopo10_1.getEscopo_10_1();
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        comboE10_1TensaoTri.SelectedIndex = Convert.ToInt32(dr["TENSAO_TRIFASICA"].ToString());
                        comboE10_1Freq.SelectedIndex = Convert.ToInt32(dr["FREQUENCIA"].ToString());
                        if (dr["FREQUENCIA"].ToString() == "3")
                        {
                            txtE10_1OutraFreq.Text = dr["DESC_OUTRA_FREQUENCIA"].ToString();
                        }
                        if(dr["DADOS_AMBIENTAIS"].ToString() == "U")
                        {
                            comboE10_1DadosAmbientais.SelectedIndex = 1;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "M")
                        {
                            comboE10_1DadosAmbientais.SelectedIndex = 2;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                        {
                            comboE10_1DadosAmbientais.SelectedIndex = 3;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                        {
                            comboE10_1DadosAmbientais.SelectedIndex = 4;
                        }

                        if(dr["IND_NORMATIVA_MAPA"].ToString() == "S")
                        {
                            radioE10_1NormativaS.Checked = true;
                            radioE10_1NormativaN.Checked = false;
                        }
                        else
                        {
                            radioE10_1NormativaS.Checked = false;
                            radioE10_1NormativaN.Checked = true;
                        }
                        if (dr["TIPO_PRODUTO"].ToString() == "S")
                        {
                            comboE10_1TipoProd.SelectedIndex = 1;
                        }
                        else if (dr["TIPO_PRODUTO"].ToString() == "M")
                        {
                            comboE10_1TipoProd.SelectedIndex = 2;
                        }
                        else if (dr["TIPO_PRODUTO"].ToString() == "T")
                        {
                            comboE10_1TipoProd.SelectedIndex = 3;
                        }
                        else if (dr["TIPO_PRODUTO"].ToString() == "A")
                        {
                            comboE10_1TipoProd.SelectedIndex = 4;
                        }
                        else if (dr["TIPO_PRODUTO"].ToString() == "O")
                        {
                            comboE10_1TipoProd.SelectedIndex = 5;
                            txtE10_1OutroProd.Enabled = true;
                            txtE10_1OutroProd.Text = dr["DESC_OUTRO_PRODUTO"].ToString();
                        }
                        if (dr["UMIDADE_PRODUTO"].ToString() == "14")
                        {
                            comboE10_1Umidade.SelectedIndex = 1;
                        }
                        else if (dr["UMIDADE_PRODUTO"].ToString() == "16")
                        {
                            comboE10_1Umidade.SelectedIndex = 2;
                        }
                        else if (dr["UMIDADE_PRODUTO"].ToString() == "18")
                        {
                            comboE10_1Umidade.SelectedIndex = 3;
                        }
                        if (dr["TIPO_AERACAO"].ToString() == "L")
                        {
                            comboE10_1TipoAeracao.SelectedIndex = 1;
                        }
                        else
                        {
                            comboE10_1TipoAeracao.SelectedIndex = 1;
                        }
                        if (dr["TIPO_INSTALACAO"].ToString() == "P")
                        {
                            comboE10_1TipoInstalacao.SelectedIndex = 1;
                        }
                        else
                        {
                            comboE10_1TipoInstalacao.SelectedIndex = 2;
                            if(dr["MATERIAL_TAMPA_CANALETA"].ToString() == "P")
                            {
                                comboE10_1MatTampa.SelectedIndex = 1;
                            }
                            else
                            {
                                comboE10_1MatTampa.SelectedIndex = 2;
                                if(dr["TIPO_TAMPA_CANALETA"].ToString() == "P")
                                {
                                    comboE10_1TipoTampa.SelectedIndex = 1;
                                }
                                else
                                {
                                    comboE10_1TipoTampa.SelectedIndex = 2;
                                }
                            }                            
                        }
                        if (dr["MATERIAL_CASA_MATA"].ToString() == "C")
                        {
                            comboE10_1MatCasaMata.SelectedIndex = 1;
                        }
                        else if (dr["MATERIAL_CASA_MATA"].ToString() == "M")
                        {
                            comboE10_1MatCasaMata.SelectedIndex = 2;
                        }
                        else if (dr["MATERIAL_CASA_MATA"].ToString() == "N")
                        {
                            comboE10_1MatCasaMata.SelectedIndex = 3;
                        }
                        txtE10_1Obs.Text = dr["OBSERVACOES"].ToString();                        
                    }
                    btnE10_1Excluir.Visible = true;
                }
                else
                {
                    //Reseta os campos da tela
                    comboE10_1TensaoTri.SelectedIndex = 0;
                    comboE10_1Freq.SelectedIndex = 0;
                    txtE10_1OutraFreq.Text = "";
                    comboE10_1DadosAmbientais.SelectedIndex = 0;
                    radioE10_1NormativaS.Checked = false;
                    radioE10_1NormativaN.Checked = false;
                    comboE10_1TipoProd.SelectedIndex = 0;
                    txtE10_1OutroProd.Text = "";
                    comboE10_1Umidade.SelectedIndex = 0;
                    comboE10_1TipoAeracao.SelectedIndex = 0;
                    comboE10_1TipoInstalacao.SelectedIndex = 0;
                    comboE10_1MatTampa.SelectedIndex = 0;
                    comboE10_1TipoTampa.SelectedIndex = 0;
                    comboE10_1MatCasaMata.SelectedIndex = 0;
                    txtE10_1Obs.Text = "";
                    btnE10_1Excluir.Visible = false;
                    tabNovaSolicitacao.SelectedTab.Name = "tabEscopo10_1";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Lista os dados na tela Escopo 10_2
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo10_2(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_10_2 Escopo10_2 = new SOEF_CLASS.Escopo_10_2(pNumSolic, pNumRev);
                DataTable dt = Escopo10_2.getEscopo_10_2();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if(dr["DADOS_AMBIENTAIS"].ToString() == "U")
                        {
                            combo10_2DadosAmbientais.SelectedIndex = 1;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "M")
                        {
                            combo10_2DadosAmbientais.SelectedIndex = 2;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                        {
                            combo10_2DadosAmbientais.SelectedIndex = 3;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                        {
                            combo10_2DadosAmbientais.SelectedIndex = 4;
                        }

                        //Produto
                        if(dr["TIPO_PRODUTO"].ToString() == "S")
                        {
                            combo10_2Produto.SelectedIndex = 1;
                        }
                        else if (dr["TIPO_PRODUTO"].ToString() == "M")
                        {
                            combo10_2Produto.SelectedIndex = 2;
                        }
                        else if (dr["TIPO_PRODUTO"].ToString() == "T")
                        {
                            combo10_2Produto.SelectedIndex = 3;
                        }
                        else if (dr["TIPO_PRODUTO"].ToString() == "A")
                        {
                            combo10_2Produto.SelectedIndex = 4;
                        }
                        else if (dr["TIPO_PRODUTO"].ToString() == "O")
                        {
                            combo10_2Produto.SelectedIndex = 5;
                            txt10_2OutroProd.Enabled = true;
                            txt10_2OutroProd.Text = dr["DESC_OUTRO_PRODUTO"].ToString();
                        }
                        else
                        {
                            txt10_2OutroProd.Text = "";
                            txt10_2OutroProd.Enabled = false;
                        }

                        //Local Instalação - SILO
                        if(dr["IND_INSTAL_SILO"].ToString() == "S")
                        {
                            check10_2Silos.Checked = true;
                            //Habilita o box do Silo
                            gBox10_2Silo.Visible = true;
                            if (dr["CAPACIDADE_SILO"].ToString() == "60")
                            {
                                combo10_2CapacidadeSilo.SelectedIndex = 1;
                                label109.Visible = true;
                                radioPenduloCentralS.Visible = true;
                                radioPenduloCentralN.Visible = true;
                                if (dr["IND_SUPORTE_PENDULO"].ToString() == "S")
                                {
                                    radioPenduloCentralS.Checked = true;
                                }
                                else
                                {
                                    radioPenduloCentralN.Checked = true;
                                }
                            }
                            else if (dr["CAPACIDADE_SILO"].ToString() == "120")
                            {
                                combo10_2CapacidadeSilo.SelectedIndex = 2;
                                label109.Visible = true;
                                radioPenduloCentralS.Visible = true;
                                radioPenduloCentralN.Visible = true;
                                if (dr["IND_SUPORTE_PENDULO"].ToString() == "S")
                                {
                                    radioPenduloCentralS.Checked = true;
                                }
                                else
                                {
                                    radioPenduloCentralN.Checked = true;
                                }
                            }
                            else if (dr["CAPACIDADE_SILO"].ToString() == "270")
                            {
                                combo10_2CapacidadeSilo.SelectedIndex = 3;
                                label109.Visible = true;
                                radioPenduloCentralS.Visible = true;
                                radioPenduloCentralN.Visible = true;
                                if (dr["IND_SUPORTE_PENDULO"].ToString() == "S")
                                {
                                    radioPenduloCentralS.Checked = true;
                                }
                                else
                                {
                                    radioPenduloCentralN.Checked = true;
                                }
                            }
                            else if (dr["CAPACIDADE_SILO"].ToString() == "320")
                            {
                                combo10_2CapacidadeSilo.SelectedIndex = 4;
                                label109.Visible = true;
                                radioPenduloCentralS.Visible = true;
                                radioPenduloCentralN.Visible = true;
                                if (dr["IND_SUPORTE_PENDULO"].ToString() == "S")
                                {
                                    radioPenduloCentralS.Checked = true;
                                }
                                else
                                {
                                    radioPenduloCentralN.Checked = true;
                                }
                            }
                            else if (dr["CAPACIDADE_SILO"].ToString() == "500")
                            {
                                combo10_2CapacidadeSilo.SelectedIndex = 5;
                                msgPenduloCentral.Visible = true;
                                label109.Visible = false;
                                radioPenduloCentralS.Visible = false;
                                radioPenduloCentralN.Visible = false;
                            }
                            else if (dr["CAPACIDADE_SILO"].ToString() == "999")
                            {
                                combo10_2CapacidadeSilo.SelectedIndex = 6;
                                label109.Visible = true;
                                radioPenduloCentralS.Visible = true;
                                radioPenduloCentralN.Visible = true;
                                label117.Visible = true;
                                text10_2CaractisticaEspalhadorS.Visible = true;
                                text10_2CaractisticaEspalhadorS.Text = dr["CARACT_ESPALHADOR_ESP_SIL"].ToString();
                            }
                            else
                            {
                                text10_2CaractisticaEspalhadorS.Text = "";
                                text10_2CaractisticaEspalhadorS.Visible = false;
                            }
                        }
                        else
                        {
                            check10_2Armazem.Checked = false;
                            //Habilita o box do Armazém
                            //gBox10_2Armazem.Visible = false;
                        }

                        //Armazém
                        if(dr["IND_INSTAL_ARMAZEM"].ToString() == "S")
                        {
                            check10_2Armazem.Checked = true;
                            gBox10_2Armazem.Visible = true;
                            label120.Visible = true;
                            combo10_2CapacidadeArmazem.Visible = true;
                            label119.Visible = true;
                            combo10_2Transportadores.Visible = true;
                            if (dr["CAPACIDADE_ARMAZEM"].ToString() == "60")
                            {
                                combo10_2CapacidadeArmazem.SelectedIndex = 1;
                            }
                            else if (dr["CAPACIDADE_ARMAZEM"].ToString() == "120")
                            {
                                combo10_2CapacidadeArmazem.SelectedIndex = 2;
                            }
                            else if (dr["CAPACIDADE_ARMAZEM"].ToString() == "270")
                            {
                                combo10_2CapacidadeArmazem.SelectedIndex = 3;
                            }
                            else if (dr["CAPACIDADE_ARMAZEM"].ToString() == "320")
                            {
                                combo10_2CapacidadeArmazem.SelectedIndex = 4;
                            }
                            else if (dr["CAPACIDADE_ARMAZEM"].ToString() == "500")
                            {
                                combo10_2CapacidadeArmazem.SelectedIndex = 5;
                            }
                            else if (dr["CAPACIDADE_ARMAZEM"].ToString() == "999")
                            {
                                combo10_2CapacidadeArmazem.SelectedIndex = 6;
                                label110.Visible = true;
                                text10_2CaractisticaEspalhadorA.Visible = true;
                                text10_2CaractisticaEspalhadorA.Text = dr["CARACT_ESPALHADOR_ESP_ARM"].ToString();
                            }
                            else
                            {
                                text10_2CaractisticaEspalhadorA.Text = "";
                                text10_2CaractisticaEspalhadorA.Visible = false;
                            }
                        }
                        else
                        {
                            //gBox10_2Armazem.Visible = false;
                            check10_2Armazem.Checked = false;
                        }
                        if(dr["QTDE_TRANSPORTADOR"].ToString() == "1")
                        {
                            combo10_2Transportadores.SelectedIndex = 1;
                        }
                        else if (dr["QTDE_TRANSPORTADOR"].ToString() == "2")
                        {
                            combo10_2Transportadores.SelectedIndex = 2;
                        }
                        else if (dr["QTDE_TRANSPORTADOR"].ToString() == "3")
                        {
                            combo10_2Transportadores.SelectedIndex = 3;
                        }

                        txt10_2Obs.Text = dr["OBSERVACOES"].ToString();
                    }
                    btn10_2Excluir.Visible = true;
                }
                else
                {
                    //Reseta campos da tela
                    combo10_2DadosAmbientais.SelectedIndex = 0;
                    combo10_2Produto.SelectedIndex = 0;
                    txt10_2OutroProd.Text = "";
                    txt10_2OutroProd.Enabled = false;
                    check10_2Silos.Checked = false;
                    check10_2Armazem.Checked = false;
                    combo10_2CapacidadeSilo.SelectedIndex = 0;
                    msgPenduloCentral.Visible = false;
                    radioPenduloCentralS.Checked = false;
                    radioPenduloCentralN.Checked = false;
                    text10_2CaractisticaEspalhadorS.Text = "";
                    text10_2CaractisticaEspalhadorA.Text = "";
                    combo10_2Transportadores.SelectedIndex = 0;
                    combo10_2CapacidadeArmazem.SelectedIndex = 0;
                    txt10_2Obs.Text = "";
                    btn10_2Excluir.Visible = false;
                    tabNovaSolicitacao.SelectedTab.Name = "tabEscopo10_2";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista dados na tela Escopo 01
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo01(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_01 Escopo01 = new SOEF_CLASS.Escopo_01(pNumSolic, pNumRev);
                DataTable dt = Escopo01.getEscopo_01();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        combo01Tensao.SelectedIndex = Convert.ToInt32(dr["TENSAO_MEDIA"].ToString());
                        if(combo01Tensao.SelectedIndex == 4)
                        {
                            txt01OutraTensao.Enabled = true;
                            txt01OutraTensao.Text = dr["DESC_OUTRA_TENSAO"].ToString();
                        }
                        else
                        {
                            txt01OutraTensao.Enabled = false;
                            txt01OutraTensao.Text = "";
                        }
                        if (dr["IND_TIPO_INSTALACAO"].ToString() == "A")
                        {
                            combo01Instalacao.SelectedIndex = 1;
                        }
                        else if (dr["IND_TIPO_INSTALACAO"].ToString() == "T")
                        {
                            combo01Instalacao.SelectedIndex = 2;
                        }
                        else if (dr["IND_TIPO_INSTALACAO"].ToString() == "M")
                        {
                            combo01Instalacao.SelectedIndex = 3;
                        }
                        if (dr["IND_ENSAIO"].ToString() == "A")
                        {
                            combo01EnsaioPainel.SelectedIndex = 1;
                        }
                        else if (dr["IND_ENSAIO"].ToString() == "C")
                        {
                            combo01EnsaioPainel.SelectedIndex = 2;
                        }
                        else if (dr["IND_ENSAIO"].ToString() == "T")
                        {
                            combo01EnsaioPainel.SelectedIndex = 3;
                        }
                        else if (dr["IND_ENSAIO"].ToString() == "O")
                        {
                            combo01EnsaioPainel.SelectedIndex = 4;
                            txt01OutroEnsaio.Enabled = true;
                            txt01OutroEnsaio.Text = dr["DESC_OUTRO_ENSAIO"].ToString();
                        }

                        if (dr["TIPO_PINTURA"].ToString() == "R")
                        {
                            combo01Pintura.SelectedIndex = 1;
                        }
                        else if (dr["TIPO_PINTURA"].ToString() == "M")
                        {
                            combo01Pintura.SelectedIndex = 2;
                        }
                        else if (dr["TIPO_PINTURA"].ToString() == "E")
                        {
                            combo01Pintura.SelectedIndex = 3;
                        }

                        if (!string.IsNullOrEmpty(dr["OBSERVACOES"].ToString()))
                        {
                            txt01Obs.Text = dr["OBSERVACOES"].ToString();
                        }
                        else
                        {
                            txt01Obs.Text = "";
                        }

                        combo01Frequencia.SelectedIndex = Convert.ToInt32(dr["FREQUENCIA"].ToString());
                        if (dr["FREQUENCIA"].ToString() == "3")
                        {
                            txt01OutraFrequencia.Enabled = true;
                            txt01OutraFrequencia.Text = dr["DESC_OUTRA_FREQUENCIA"].ToString();
                        }

                        if (dr["DADOS_AMBIENTAIS"].ToString() == "U")
                        {
                            combo01DadosAmbientais.SelectedIndex = 1;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "M")
                        {
                            combo01DadosAmbientais.SelectedIndex = 2;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                        {
                            combo01DadosAmbientais.SelectedIndex = 3;
                        }
                        else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                        {
                            combo01DadosAmbientais.SelectedIndex = 4;
                        }

                        if (dr["IND_DIAGRAMA_UNIFILAR"].ToString() == "S")
                        {
                            rbtn01Sim.Checked = true;
                        }
                        else
                        {
                            rbtn01Nao.Checked = true;
                            txt01Descricao.Enabled = true;
                            txt01Descricao.Text = dr["DESCRICAO_SOLUCAO"].ToString();
                        }                        
                    }
                    btn01Excluir.Visible = true;
                }
                else
                {
                    //Limpa os campos
                    combo01Tensao.SelectedIndex = 0;
                    txt01OutraTensao.Text = "";
                    txt01OutraTensao.Enabled = false;
                    combo01Instalacao.SelectedIndex = 0;
                    combo01EnsaioPainel.SelectedIndex = 0;
                    combo01Pintura.SelectedIndex = 0;
                    txt01Obs.Text = "";
                    combo01Frequencia.SelectedIndex = 0;
                    txt01OutraFrequencia.Text = "";
                    txt01OutraFrequencia.Enabled = false;
                    combo01DadosAmbientais.SelectedIndex = 0;
                    rbtn01Nao.Checked = false;
                    rbtn01Sim.Checked = false;
                    txt01Descricao.Text = "";
                    txt01OutroEnsaio.Enabled = false;
                    txt01OutroEnsaio.Text = "";
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lista o Escopo 18_2
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo18_2(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_18_2 Escopo18_2 = new SOEF_CLASS.Escopo_18_2(pNumSolic, pNumRev);
                DataTable dt = Escopo18_2.getEscopo18_2();
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        if(dr["IND_TECNICO_OBRAS"].ToString() == "S")
                        {
                            check18_2TecObras.Checked = true;
                        }
                        else
                        {
                            check18_2TecObras.Checked = false;
                        }
                        if (dr["IND_ALMOXARIFE"].ToString() == "S")
                        {
                            check18_2Almoxarife.Checked = true;
                        }
                        else
                        {
                            check18_2Almoxarife.Checked = false;
                        }
                        if (dr["IND_MONTADOR"].ToString() == "S")
                        {
                            check18_2Montador.Checked = true;
                        }
                        else
                        {
                            check18_2Montador.Checked = false;
                        }
                        if (dr["IND_SOLDADOR"].ToString() == "S")
                        {
                            check18_2Soldador.Checked = true;
                        }
                        else
                        {
                            check18_2Soldador.Checked = false;
                        }
                        if (dr["IND_OUTRO_PROFISSIONAL"].ToString() == "S")
                        {
                            check18_2Outro.Checked = true;
                            label81.Visible = true;
                            txt18_2DescProfissional.Visible = true;
                        }
                        else
                        {
                            check18_2Soldador.Checked = false;
                            label81.Visible = false;
                            txt18_2DescProfissional.Text = "";
                            txt18_2DescProfissional.Visible = false;
                        }
                        if (dr["IND_PLATAFORMA_ELEVATORIA"].ToString() == "S")
                        {
                            check18_2PlataformaElevatoria.Checked = true;
                        }
                        else
                        {
                            check18_2PlataformaElevatoria.Checked = false;
                        }
                        if (dr["IND_MUNCK"].ToString() == "S")
                        {
                            check18_2Munck.Checked = true;
                        }
                        else
                        {
                            check18_2Munck.Checked = false;
                        }
                        if (dr["IND_FERRAMENTAL"].ToString() == "S")
                        {
                            check18_2Ferramental.Checked = true;
                        }
                        else
                        {
                            check18_2Ferramental.Checked = false;
                        }
                        txt18_2Obs.Text = dr["OBSERVACOES"].ToString();
                    }
                    btn18_2Excluir.Visible = true;
                    //Marca o CheckBox 18.2 se existir registro
                    check18_2MaoObraDireta.Checked = true;
                    check18_2MaoObraDireta.Enabled = false;                    
                }
                else
                {
                    //Limpa os campos da  tela
                    check18_2TecObras.Checked = false;
                    check18_2Almoxarife.Checked = false;
                    check18_2Montador.Checked = false;
                    check18_2AuxiliarMontador.Checked = false;
                    check18_2Soldador.Checked = false;
                    check18_2Outro.Checked = false;
                    txt18_2DescProfissional.Text = "";
                    label81.Visible = false;
                    txt18_2DescProfissional.Visible = false;
                    check18_2PlataformaElevatoria.Checked = false;
                    check18_2Munck.Checked = false;
                    check18_2Ferramental.Checked = false;
                    txt18_2Obs.Text = "";
                    btn18_2Excluir.Visible = false;
                    //Marca o Checkbox 18.1 se não existir registro cadastrado
                    check18_2MaoObraDireta.Checked = false;
                    check18_2MaoObraDireta.Enabled = true;
                    p18_2.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        /// <summary>
        /// Lista o Escopo 18_1
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo18_1(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_18_1 Escopo18_1 = new SOEF_CLASS.Escopo_18_1(pNumSolic, pNumRev);
                DataTable dt = Escopo18_1.getEscopo18_1();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["IND_ENGENHEIRO_RESIDENTE"].ToString() == "S")
                        {
                            check18_1EngResidente.Checked = true;
                        }
                        else
                        {
                            check18_1EngResidente.Checked = false;
                        }

                        if(dr["IND_ADMINISTRATIVO"].ToString() == "S")
                        {
                            check18_1Administrativo.Checked = true;
                        }
                        else
                        {
                            check18_1Administrativo.Checked = false;
                        }

                        if (dr["IND_TECNICO_SEGURANCA"].ToString() == "S")
                        {
                            check18_1TecSeguranca.Checked = true;
                        }
                        else
                        {
                            check18_1TecSeguranca.Checked = false;
                        }

                        if(dr["IND_PLANEJADOR"].ToString() == "S")
                        {
                            check18_1Planejador.Checked = true;
                        }
                        else
                        {
                            check18_1Planejador.Checked = false;
                        }

                        if (dr["IND_OUTRO_PROFISSIONAL"].ToString() == "S")
                        {
                            check18_1Outro.Checked = true;
                            label76.Visible = true;
                            txt18_1DescProfissional.Visible = true;
                            txt18_1DescProfissional.Text = dr["DESC_OUTRO_PROFISSIONAL"].ToString();
                        }
                        else
                        {
                            check18_1Outro.Checked = false;
                            label76.Visible = false;
                            txt18_1DescProfissional.Visible = false;
                            txt18_1DescProfissional.Text = "";
                        }
                        if (dr["IND_ENCARREGADO"].ToString() == "S")
                        {
                            check18_1Encarregado.Checked = true;
                        }
                        else
                        {
                            check18_1Encarregado.Checked = false;
                        }

                        txt18_1Obs.Text = dr["OBSERVACOES"].ToString();
                    }
                    btn18_1Excluir.Visible = true;

                    //Marca o Checkbox 18.1 se existir registro cadastrado
                    check18_1MaoObraIndireta.Checked = true;
                    check18_1MaoObraIndireta.Enabled = false;
                }
                else
                {
                    //Limpa os campos da tela
                    check18_1EngResidente.Checked = false;
                    check18_1Administrativo.Checked = false;
                    check18_1TecSeguranca.Checked = false;
                    check18_1Planejador.Checked = false;
                    check18_1Outro.Checked = false;
                    txt18_1DescProfissional.Text = "";
                    label76.Visible = false;
                    txt18_1DescProfissional.Visible = false;
                    txt18_1Obs.Text = "";
                    check18_1Encarregado.Checked = false;
                    btn18_1Excluir.Visible = false;
                    //Marca o Checkbox 18.1 se não existir registro cadastrado
                    check18_1MaoObraIndireta.Checked = false;
                    check18_1MaoObraIndireta.Enabled = true;
                    p18_1.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        /// <summary>
        /// Lista o Escopo 18
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pNumRev"></param>
        protected void listaEscopo18(string pNumSolic, string pNumRev)
        {
            try
            {
                SOEF_CLASS.Escopo_18 Escopo18 = new SOEF_CLASS.Escopo_18(pNumSolic, pNumRev);
                DataTable dt = Escopo18.getEscopo18();
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        if(dr["IND_HORA_EXTRA"].ToString() == "S")
                        {
                            rbtn18HrasExtrasSim.Checked = true;
                        }
                        else if (dr["IND_HORA_EXTRA"].ToString() == "N")
                        {
                            rbtn18HrasExtrasNao.Checked = true;
                        }
                        if(dr["IND_MATERIAL_CONSUMO"].ToString() == "S")
                        {
                            rbtn18MatConsumoSim.Checked = true;
                        }
                        else if(dr["IND_MATERIAL_CONSUMO"].ToString() == "N")
                        {
                            rbtn18MatConsumoNao.Checked = true;
                        }
                        if (dr["IND_TRANSLADO_OBRA"].ToString() == "S")
                        {
                            rbtn18ConsidTransladoSim.Checked = true;
                        }
                        else if (dr["IND_TRANSLADO_OBRA"].ToString() == "N")
                        {
                            rbtn18ConsidTransladoNao.Checked = true;
                        }
                        if (dr["IND_FORNEC_ALIMENTACAO"].ToString() == "F")
                        {
                            rbtn18AlimentacaoFockink.Checked = true;
                        }
                        else if(dr["IND_FORNEC_ALIMENTACAO"].ToString() == "C")
                        {
                            rbtn18AlimentacaoCli.Checked = true;
                        }
                        if (dr["IND_FORNEC_ESTADIA"].ToString() == "F")
                        {
                            rbtn18EstadiaFockink.Checked = true;

                        }
                        else if (dr["IND_FORNEC_ESTADIA"].ToString() == "C")
                        {
                            rbtn18EstadiaCli.Checked = true; 
                        }
                        txt18DescServicos.Text = dr["DESCRICAO_SERVICO"].ToString();
                    }
                    btn18Excluir.Visible = true;
                }
                else
                {
                    //Limpa os campos da tela
                    rbtn18HrasExtrasSim.Checked = false;
                    rbtn18HrasExtrasNao.Checked = false;
                    rbtn18MatConsumoSim.Checked = false;
                    rbtn18MatConsumoNao.Checked = false;
                    rbtn18ConsidTransladoSim.Checked = false;
                    rbtn18ConsidTransladoNao.Checked = false;
                    rbtn18AlimentacaoFockink.Checked = false;
                    rbtn18AlimentacaoCli.Checked = false;
                    rbtn18EstadiaCli.Checked = false;
                    rbtn18EstadiaFockink.Checked = false;
                    txt18DescServicos.Text = "";
                    btn18Excluir.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Função que verifica os escopos que já estão preenchidos
        /// </summary>
        /// <param name="numSolic">N° da solicitação</param>
        /// <param name="numRev">N° da revisão</param>
        /// <param name="tabelaEscopo">Nome da tabela do BD referente ao escopo</param>
        public void verificaEscopos(string numSolic, string numRev)
       {
            try
            {
                DataTable dtVerifica01 = new DataTable();
                //Escopo 01
                SOEF_CLASS.Escopo_01 Escopo01 = new SOEF_CLASS.Escopo_01(numSolic, numRev);
                dtVerifica01 = Escopo01.getEscopo_01();
                if(dtVerifica01.Rows.Count > 0)
                {
                    if(dtVerifica01.Rows[0]["IND_PREENCHIDO"].ToString() == "S")
                    {
                        //Marca o Escopo_01 como preenchido na tela de escopos
                        checkEscopo1.Checked = true;
                        checkEscopo1.Enabled = false;
                    }
                    else
                    {
                        checkEscopo1.Checked = false;
                        checkEscopo1.Enabled = true;
                    }
                }

                //Escopos 10
                bool E10_1 = false;
                bool E10_2 = false;
                bool E10_3 = false;
                bool E10_4 = false;
                //Escopo 10_1
                DataTable dtVerifica10_1 = new DataTable();
                SOEF_CLASS.Escopo_10_1 Escopo_10_1 = new SOEF_CLASS.Escopo_10_1(numSolic, numRev);
                dtVerifica10_1 = Escopo_10_1.getEscopo_10_1();
                if(dtVerifica10_1.Rows.Count > 0)
                {
                    if (dtVerifica10_1.Rows[0]["IND_PREENCHIDO"].ToString() == "S")
                    {
                        E10_1 = true;
                    }
                    else
                    {
                        E10_1 = false;
                    }
                }
                //Escopo 10_2
                DataTable dtVerifica10_2 = new DataTable();
                SOEF_CLASS.Escopo_10_2 Escopo_10_2 = new SOEF_CLASS.Escopo_10_2(numSolic, numRev);
                dtVerifica10_2 = Escopo_10_2.getEscopo_10_2();
                if (dtVerifica10_2.Rows.Count > 0)
                {
                    if (dtVerifica10_2.Rows[0]["IND_PREENCHIDO"].ToString() == "S")
                    {
                        E10_2 = true;                      
                    }
                    else
                    {
                        E10_2 = false;
                    }
                }
                //Escopo 10_3
                DataTable dtVerifica10_3 = new DataTable();
                SOEF_CLASS.Escopo_10_3 Escopo_10_3 = new SOEF_CLASS.Escopo_10_3(numSolic, numRev);
                dtVerifica10_3 = Escopo_10_3.getEscopo_10_3();
                if (dtVerifica10_3.Rows.Count > 0)
                {
                    if (dtVerifica10_3.Rows[0]["IND_PREENCHIDO"].ToString() == "S")
                    {
                        E10_3 = true;
                    }
                    else
                    {
                        E10_3 = false;
                    }
                }
                //Escopo 10_4
                DataTable dtVerifica10_4 = new DataTable();
                SOEF_CLASS.Escopo_10_4 Escopo_10_4 = new SOEF_CLASS.Escopo_10_4(numSolic, numRev);
                dtVerifica10_4 = Escopo_10_4.getEscopo_10_4();
                if (dtVerifica10_4.Rows.Count > 0)
                {
                    if (dtVerifica10_4.Rows[0]["IND_PREENCHIDO"].ToString() == "S")
                    {
                        E10_4 = true;
                    }
                    else
                    {
                        E10_4 = false;
                    }
                }
                if(E10_1 || E10_2 || E10_3 || E10_4)
                {
                    checkEscopo10.Checked = true;
                    checkEscopo10.Enabled = false;
                }
                else
                {
                    checkEscopo10.Checked = false;
                    checkEscopo10.Enabled = true;
                }


                //Escopo 18
                SOEF_CLASS.Escopo_18 Escopo18 = new SOEF_CLASS.Escopo_18(numSolic, numRev);
                DataTable dtVerifica18 = new DataTable();
                dtVerifica18 = Escopo18.getEscopo18();
                if (dtVerifica18.Rows.Count > 0)
                {
                    if (dtVerifica18.Rows[0]["IND_PREENCHIDO"].ToString() == "S")
                    {
                        //Marca o Escopo_18 como preenchido na tela de escopos
                        checkEscopo18.Checked = true;
                        checkEscopo18.Enabled = false;
                    }
                    else
                    {
                        checkEscopo18.Checked = false;
                        checkEscopo18.Enabled = true;
                    }
                }

                //Escopo 19
                SOEF_CLASS.Escopo_19 Escopo19 = new SOEF_CLASS.Escopo_19(numSolic, numRev);
                DataTable dtVerifica19 = new DataTable();
                dtVerifica19 = Escopo19.getEscopo(numSolic, numRev);
                if(dtVerifica19.Rows.Count > 0)
                {
                    if(dtVerifica19.Rows[0]["IND_PREENCHIDO"].ToString() == "S")
                    {
                        checkEscopo19.Checked = true;
                        checkEscopo19.Enabled = false;
                    }
                    else
                    {
                        checkEscopo19.Checked = false;
                        checkEscopo19.Enabled = true;
                    }
                }

                //Escopo 20
                SOEF_CLASS.Escopo_20 Escopo20 = new SOEF_CLASS.Escopo_20(numSolic, numRev);
                DataTable dtVerifica20 = new DataTable();
                dtVerifica20 = Escopo20.getEscopo20(numSolic, numRev);
                if (dtVerifica20.Rows.Count > 0)
                {
                    if (dtVerifica20.Rows[0]["IND_PREENCHIDO"].ToString() == "S")
                    {
                        checkEscopo20.Checked = true;
                        checkEscopo20.Enabled = false;
                    }
                    else
                    {
                        checkEscopo20.Checked = false;
                        checkEscopo20.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

       }


        /// <summary>
        /// Função que lista os dados do Escopo 19 na tela
        /// </summary>
        /// <param name="numSolic"></param>
        /// <param name="numRevi"></param>
        protected void listaEscopo19(string numSolic, string numRevi)
        {
            try
            {
                SOEF_CLASS.Escopo_19 Escopo19 = new SOEF_CLASS.Escopo_19(numSolic, numRevi);
                DataTable dt = Escopo19.getEscopo(numSolic, numRevi);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["IND_ABERTURA_FEC_VALAS"].ToString() == "S")
                        {
                            checkAbFecValas.Checked = true;
                        }
                        else
                        {
                            checkAbFecValas.Checked = false;
                        }
                        if (dr["IND_CAIXA_INSPECAO"].ToString() == "S")
                        {
                            checkCaixaInspecao.Checked = true;
                        }
                        else
                        {
                            checkCaixaInspecao.Checked = false;
                        }
                        if (dr["IND_BASE_POSTES"].ToString() == "S")
                        {
                            checkBasePoste.Checked = true;
                        }
                        else
                        {
                            checkBasePoste.Checked = false;
                        }
                        if (dr["IND_BASE_SUBESTACAO"].ToString() == "S")
                        {
                            checkBaseSubestacao.Checked = true;
                        }
                        else
                        {
                            checkBaseSubestacao.Checked = false;
                        }
                        if (dr["IND_CASA_BOMBAS"].ToString() == "S")
                        {
                            checkCasaBombas.Checked = true;
                        }
                        else
                        {
                            checkCasaBombas.Checked = false;
                        }
                        if (dr["IND_OUTRO_ESCOPO"].ToString() == "S")
                        {
                            checkOutro.Checked = true;
                            txtEsc19Necessidade.Text = dr["DESC_OUTRO_ESCOPO"].ToString();
                        }
                        else
                        {
                            checkOutro.Checked = false;
                            txtEsc19Necessidade.Text = "";
                        }
                        if (!string.IsNullOrEmpty(dr["OBSERVACOES"].ToString()))
                        {
                            txtEsc19Observacoes.Text = dr["OBSERVACOES"].ToString();
                        }
                        else
                        {
                            txtEsc19Observacoes.Text = "";
                        }
                    }
                }
                else
                {
                    //Limpa os campos da tela
                    checkAbFecValas.Checked = false;
                    checkBasePoste.Checked = false;
                    checkCasaBombas.Checked = false;
                    checkCaixaInspecao.Checked = false;
                    checkBaseSubestacao.Checked = false;
                    checkOutro.Checked = false;
                    txtEsc19Observacoes.Text = "";
                    txtEsc19Necessidade.Text = "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
               


        private void tabNovaSolicitacao_Selected(object sender, TabControlEventArgs e)
        {
            //Instancia a classe do Escopo Valor Comum
            SOEF_CLASS.Escopo_Valor_Comum EscopoValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);

            //Lista de Escopos Preenchidos
            if (tabNovaSolicitacao.SelectedTab.Name == "tabDefEscopo")
            {
                ////Função que verifica os escopos existentes e ativa eles
                verificaEscopos(this.numero_solic.ToString(), this.NumRevisaoSolic);
            }

            //Escopo 01
            if(tabNovaSolicitacao.SelectedTab.Name == "tabEscopo1")
            {
                if(AcaoTela == "N")
                {
                    combo01Tensao.SelectedIndex = 0;
                    combo01EnsaioPainel.SelectedIndex = 0;
                    rbtn01Sim.Checked = true;
                    btn01Excluir.Visible = false;

                    //Verifica se existe registro na tabela Valor Comum
                    DataTable dt = EscopoValorComum.buscaEscopoValorComumE01(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if (dt.Rows.Count > 0)
                    {
                        foreach(DataRow dr in dt.Rows)
                        {
                            //Dados Ambientais
                            if(dr["DADOS_AMBIENTAIS"].ToString() == "U")
                            {
                                combo01DadosAmbientais.SelectedIndex = 1;
                            }
                            else if(dr["DADOS_AMBIENTAIS"].ToString() == "M")
                            {
                                combo01DadosAmbientais.SelectedIndex = 2;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                            {
                                combo01DadosAmbientais.SelectedIndex = 3;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                            {
                                combo01DadosAmbientais.SelectedIndex = 4;
                            }
                            //Frequência
                            if (dr["FREQUENCIA_HZ"].ToString() == "1")
                            {
                                combo01DadosAmbientais.SelectedIndex = 1;
                            }
                            else if (dr["FREQUENCIA_HZ"].ToString() == "2")
                            {
                                combo01DadosAmbientais.SelectedIndex = 2;
                            }
                            else if (dr["FREQUENCIA_HZ"].ToString() == "3")
                            {
                                combo01DadosAmbientais.SelectedIndex = 3;
                                txt01OutraFrequencia.Enabled = true;
                                txt01OutraFrequencia.Text = dr["OUTRA_FREQUENCIA"].ToString();
                            }
                            //Tipo Pintura
                            if (dr["TIPO_PINTURA"].ToString() == "R")
                            {
                                combo01Pintura.SelectedIndex = 1;
                            }
                            else if (dr["TIPO_PINTURA"].ToString() == "M")
                            {
                                combo01Pintura.SelectedIndex = 2;
                            }
                            else if (dr["TIPO_PINTURA"].ToString() == "E")
                            {
                                combo01Pintura.SelectedIndex = 3;
                            }
                            //Tipo Instalação
                            if (dr["IND_INSTAL_ABRIG_TEMPO"].ToString() == "A")
                            {
                                combo01DadosAmbientais.SelectedIndex = 1;
                            }
                            else if (dr["IND_INSTAL_ABRIG_TEMPO"].ToString() == "T")
                            {
                                combo01DadosAmbientais.SelectedIndex = 2;
                            }
                            else if (dr["IND_INSTAL_ABRIG_TEMPO"].ToString() == "M")
                            {
                                combo01DadosAmbientais.SelectedIndex = 3;
                            }
                            //Tensao Distribuição
                            combo01Tensao.SelectedIndex = Convert.ToInt32(dr["TENSAO_DISTRIBUICAO"].ToString());
                            if(combo01Tensao.SelectedIndex == 4)
                            {
                                txt01OutraTensao.Enabled = true;
                                txt01OutraTensao.Text = dr["OUTRA_TENSAO_DISTRIB"].ToString();
                            }
                            else
                            {
                                txt01OutraTensao.Text = "";
                                txt01OutraTensao.Enabled = false;                           
                            }
                        }
                    }
                    else
                    {
                        //Se os valores comuns estão vazios, não sugere nada
                        combo01DadosAmbientais.SelectedIndex = 0;
                        combo01Frequencia.SelectedIndex = 0;
                        combo01Instalacao.SelectedIndex = 0;
                        combo01Pintura.SelectedIndex = 0;
                        combo01Tensao.SelectedIndex = 0;
                        txt01OutraTensao.Enabled = false;
                    }
                }
                else
                {
                    listaEscopo01(this.numero_solic.ToString(), this.NumRevisaoSolic);

                }           
            } //Fim Escopo 01

            //Escopo 05
            if(tabNovaSolicitacao.SelectedTab.Name == "tabEscopo5")
            {
                inicializaCamposE05();
                if(AcaoTela == "N")
                {
                    //Verifica e sugere os campos comuns caso existir registro VALOR_COMUM
                    DataTable dtEscopo05 = EscopoValorComum.buscaEscopoValorComumE05(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if (dtEscopo05.Rows.Count > 0)
                    {
                        foreach(DataRow dr in dtEscopo05.Rows)
                        {
                            //Frequencia
                            combo05Freq.SelectedIndex = Convert.ToInt32(dr["FREQUENCIA_HZ"].ToString());
                            //Dados Ambientais
                            if (dr["DADOS_AMBIENTAIS"].ToString() == "U")
                            {
                                combo05DadosAmbientais.SelectedIndex = 1;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "M")
                            {
                                combo05DadosAmbientais.SelectedIndex = 2;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                            {
                                combo05DadosAmbientais.SelectedIndex = 3;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                            {
                                combo05DadosAmbientais.SelectedIndex = 4;
                            }
                            //Observacoes
                            txt05Obs.Text = dr["OBSERVACOES"].ToString();
                        }
                    }
                }
                else
                {
                    //Se a AcaoTela for Atualizar, preenche os campos da tela com os dados
                    listaEscopo05(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
            }

            //Escopo 10
            if(tabNovaSolicitacao.SelectedTab.Name == "tabEscopo10")
            {
                inicializaCamposE10_1();
                if(AcaoTela == "N")
                {
                    //Verifica e sugere os campos comuns caso existir registro
                    DataTable dtEscopo10_1 = EscopoValorComum.buscaEscopoValorComumE10_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if(dtEscopo10_1.Rows.Count > 0)
                    {
                        foreach(DataRow dr in dtEscopo10_1.Rows)
                        {
                            //Tensao Trifásica
                            comboE10_1TensaoTri.SelectedIndex = Convert.ToInt32(dr["TENSAO_TRIFASICA"].ToString());

                            //Frequência
                            comboE10_1Freq.SelectedIndex = Convert.ToInt32(dr["FREQUENCIA_HZ"].ToString());
                            if(dr["FREQUENCIA_HZ"].ToString() == "3")
                            {
                                txtE10_1OutraFreq.Enabled = true;
                                txtE10_1OutraFreq.Text = dr["OUTRA_FREQUENCIA"].ToString();
                            }

                            //Dados Ambientais
                            if (dr["DADOS_AMBIENTAIS"].ToString() == "U")
                            {
                                comboE10_1DadosAmbientais.SelectedIndex = 1;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "M")
                            {
                                comboE10_1DadosAmbientais.SelectedIndex = 2;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                            {
                                comboE10_1DadosAmbientais.SelectedIndex = 3;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                            {
                                comboE10_1DadosAmbientais.SelectedIndex = 4;
                            }

                            //Normativa Mapa
                            if(dr["NORMATIVA_MAPA"].ToString() == "S")
                            {
                                radioE10_1NormativaS.Checked = true;
                            }
                            else
                            {
                                radioE10_1NormativaN.Checked = true;
                            }

                            //Tipo Produto
                            if (dr["TIPO_PRODUTO"].ToString() == "S")
                            {
                                comboE10_1TipoProd.SelectedIndex = 1;
                            }
                            else if (dr["TIPO_PRODUTO"].ToString() == "M")
                            {
                                comboE10_1TipoProd.SelectedIndex = 2;
                            }
                            else if (dr["TIPO_PRODUTO"].ToString() == "T")
                            {
                                comboE10_1TipoProd.SelectedIndex = 3;
                            }
                            else if (dr["TIPO_PRODUTO"].ToString() == "A")
                            {
                                comboE10_1TipoProd.SelectedIndex = 4;
                            }
                            else if (dr["TIPO_PRODUTO"].ToString() == "O")
                            {
                                comboE10_1TipoProd.SelectedIndex = 5;
                                txtE10_1OutroProd.Enabled = true;
                                txtE10_1OutroProd.Text = dr["OUTRO_PRODUTO"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    //Se a AcaoTela for Atualizar, preenche os campos da tela com os dados
                    listaEscopo10_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
            }

            //Escopo 18
            if (tabNovaSolicitacao.SelectedTab.Name == "tabEscopo18")
            {
                //Novo Registro ou Consulta/Alteração
                if (AcaoTela == "N")
                {
                    btn18Excluir.Visible = false;
                }
                else
                {
                    //Buscar dados do escopo 18 da solicitação
                    listaEscopo18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    btn18Excluir.Visible = true;
                }
            } 

            //Escopo 19
            if (tabNovaSolicitacao.SelectedTab.Name == "tabEscopo19")
            {
                //Novo Registro ou Consulta/Alteração
                if (AcaoTela == "N")
                {
                    btnEsc19Excluir.Visible = false;
                }
                else
                {
                    //Buscar dados do escopo 19 da solicitação
                    listaEscopo19(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    btnEsc19Excluir.Visible = true;
                }
            }

            //Escopo 20
            else if(tabNovaSolicitacao.SelectedTab.Name == "tabEscopo20")
            {
                //    listaEscopo20(this.numero_solic.ToString(), this.NumRevisaoSolic);
                //Inicializa Campos
                combo10_3DadosAmbientais.SelectedIndex = 0;
                combo10_3Freq.SelectedIndex = 0;
                combo10_3Local.SelectedIndex = 0;
                combo10_3Tensao.SelectedIndex = 0;

                //Verificar Escopo 10_3 - Tabela Valores Comum

            }
        }


        private void btnEsc19Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 19 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SOEF_CLASS.Escopo_19 Escopo19 = new SOEF_CLASS.Escopo_19(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    int retorno = Escopo19.deleteEscopo19(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if(retorno > 0)
                    {
                        MessageBox.Show("Escopo excluído com sucesso!");
                        listaEscopo19(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        checkEscopo19.Checked = false;
                        checkEscopo19.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao excluir o escopo. Favor tente novamente.");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        private void checkEscopo20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscopo20.Checked)
            {
                tabNovaSolicitacao.Controls.Add(tabEscopo20);
            }
            else
            {
                tabNovaSolicitacao.Controls.Remove(tabEscopo20);
            }
        }


        private void btnEsc20Salvar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEsc20Titulo.Text) || string.IsNullOrEmpty(txtEsc20Desc.Text))
            {
                MessageBox.Show("Por favor, informe o título e a descrição do escopo.");
            }
            else
            {
                try
                {
                    string EscopoPre = "";
                    int vlrRetorno = 0;
                    int sequencia;
                    string EscopoPreenchido = "S";
                    SOEF_CLASS.Escopo_20 Escopo20 = new SOEF_CLASS.Escopo_20(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Busca a última sequência inserida
                    sequencia = Escopo20.getSequencia(this.numero_solic.ToString(), this.NumRevisaoSolic) + 1;
                    vlrRetorno = Escopo20.gravaEscopo20(sequencia.ToString(), txtEsc20Titulo.Text, txtEsc20Desc.Text, EscopoPreenchido);
                    if(vlrRetorno > 0)
                    {
                        listaEscopo20(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        MessageBox.Show("Escopo gravado com sucesso!");
                        txtEsc20Desc.Text = "";
                        txtEsc20Titulo.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro na gravação do escopo. Tente novamente.");
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        private void dgvListaEsc20_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int retorno;
                SOEF_CLASS.Escopo_20 Escopo20 = new SOEF_CLASS.Escopo_20(dgvListaEsc20.CurrentRow.Cells[1].Value.ToString(), dgvListaEsc20.CurrentRow.Cells[2].Value.ToString());
                retorno = Escopo20.deleteEscopo20(dgvListaEsc20.CurrentRow.Cells[1].Value.ToString(), dgvListaEsc20.CurrentRow.Cells[2].Value.ToString(), dgvListaEsc20.CurrentRow.Cells[3].Value.ToString());
                if(retorno > 0)
                {
                    MessageBox.Show("Registro apagado com sucesso!");
                    listaEscopo20(dgvListaEsc20.CurrentRow.Cells[1].Value.ToString(), dgvListaEsc20.CurrentRow.Cells[2].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro na exclusão do registro.");
                }
            }
        }

        private void btnEsc20Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 19 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SOEF_CLASS.Escopo_20 Escopo20 = new SOEF_CLASS.Escopo_20(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno;
                retorno = Escopo20.deleteEscopo20(this.numero_solic.ToString(), this.NumRevisaoSolic, null);
                if (retorno > 0)
                {
                    MessageBox.Show("Registro apagado com sucesso!");
                    checkEscopo20.Checked = false;
                    checkEscopo20.Enabled = true;
                    listaEscopo20(dgvListaEsc20.CurrentRow.Cells[1].Value.ToString(), dgvListaEsc20.CurrentRow.Cells[2].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro na exclusão do registro.");
                }
            }            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if( (rbtn18HrasExtrasNao.Checked == false && rbtn18HrasExtrasSim.Checked == false) || (rbtn18MatConsumoNao.Checked == false && rbtn18MatConsumoSim.Checked == false) || (rbtn18ConsidTransladoNao.Checked == false && rbtn18ConsidTransladoSim.Checked == false) || (rbtn18AlimentacaoCli.Checked == false && rbtn18AlimentacaoFockink.Checked == false) || (rbtn18EstadiaCli.Checked == false && rbtn18EstadiaFockink.Checked == false) || (string.IsNullOrEmpty(txt18DescServicos.Text)) )
            {
                MessageBox.Show("Por favor, informe todos os campos obrigatórios.");
            }
            else
            {
                string HraExtra;
                string MaterialConsumo;
                string TransladoObra;
                string FornecAlimentacao = "";
                string FornecEstadia = "";
                int retorno = 0;
                
                //Hora Extra
                if(rbtn18HrasExtrasSim.Checked == true)
                {
                    HraExtra = "S";
                }
                else
                {
                    HraExtra = "N";
                }
                //Material de Consumo
                if(rbtn18MatConsumoSim.Checked == true)
                {
                    MaterialConsumo = "S";
                }
                else
                {
                    MaterialConsumo = "N";
                }
                //Translado
                if(rbtn18ConsidTransladoSim.Checked == true)
                {
                    TransladoObra = "S";
                }
                else
                {
                    TransladoObra = "N";
                }
                //Fornecimento Alimentação
                if(rbtn18AlimentacaoCli.Checked == true)
                {
                    FornecAlimentacao = "C";
                }
                else if(rbtn18AlimentacaoFockink.Checked == true)
                {
                    FornecAlimentacao = "F";
                }
                //Fornecimento Estadia
                if(rbtn18EstadiaCli.Checked == true)
                {
                    FornecEstadia = "C";
                }
                else if(rbtn18EstadiaFockink.Checked == true)
                {
                    FornecEstadia = "F";
                }

                if(AcaoTela == "N")
                {
                    SOEF_CLASS.Escopo_18 Escopo18 = new SOEF_CLASS.Escopo_18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    retorno = Escopo18.gravaEscopo18(HraExtra, MaterialConsumo, TransladoObra, FornecAlimentacao, FornecEstadia, txt18DescServicos.Text, "S");
                    if (retorno > 0)
                    {
                        MessageBox.Show("Registro inserido com sucesso!");
                        btn18Excluir.Visible = true;
                        checkEscopo18.Checked = true;
                        checkEscopo18.Enabled = false;
                        listaEscopo18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao inserir o registro!");
                    }
                }
                else
                {
                    SOEF_CLASS.Escopo_18 Escopo18 = new SOEF_CLASS.Escopo_18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Verifica se existe Escopo 18 cadastrado
                    DataTable dt18 = Escopo18.getEscopo18();
                    if(dt18.Rows.Count > 0)
                    {
                        retorno = Escopo18.atualizaEscopo18(HraExtra, MaterialConsumo, TransladoObra, FornecAlimentacao, FornecEstadia, txt18DescServicos.Text, "S");
                    }
                    else
                    {
                        retorno = Escopo18.gravaEscopo18(HraExtra, MaterialConsumo, TransladoObra, FornecAlimentacao, FornecEstadia, txt18DescServicos.Text, "S");
                    }
                    
                    if (retorno > 0)
                    {
                        MessageBox.Show("Registro atualizado com sucesso!");
                        checkEscopo18.Checked = true;
                        checkEscopo18.Enabled = false;
                        btn18Excluir.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao inserir o registro!");
                    }
                }
            }
        }

        private void check18_1Outro_CheckedChanged(object sender, EventArgs e)
        {
            if (check18_1Outro.Checked == true)
            {
                label76.Visible = true;
                txt18_1DescProfissional.Visible = true;
            }
            else
            {
                label76.Visible = false;
                txt18_1DescProfissional.Visible = false;
            }
        }

        private void check18_1MaoObraIndireta_CheckedChanged(object sender, EventArgs e)
        {
            if(check18_1MaoObraIndireta.Checked == true)
            {
                p18_1.Visible = true;
            }
            else
            {
                p18_1.Visible = false;
            }
        }

        private void check18_2MaoObraDireta_CheckedChanged(object sender, EventArgs e)
        {
            if (check18_2MaoObraDireta.Checked == true)
            {
                p18_2.Visible = true;
            }
            else
            {
                p18_2.Visible = false;
            }
        }

        private void check18_2Outro_CheckedChanged(object sender, EventArgs e)
        {
            if(check18_2Outro.Checked == true)
            {
                label81.Visible = true;
                txt18_2DescProfissional.Visible = true;
            }
            else
            {
                label81.Visible = false;
                txt18_2DescProfissional.Visible = false;
            }
        }

        private void btn18_1Salvar_Click(object sender, EventArgs e)
        {
            string indEngResidente;
            string indAdministrativo;
            string indTecSeguranca;
            string indPlanejador;
            string indOutroProfissional = null;
            string descOutroProfissional = null;
            string indEncarregado = null;
            int vlrRetorno = 0;

            if(check18_1EngResidente.Checked == true)
            {
                indEngResidente = "S";
            }
            else
            {
                indEngResidente = "N";
            }
            if(check18_1Administrativo.Checked == true)
            {
                indAdministrativo = "S";
            }
            else
            {
                indAdministrativo = "N";
            }
            if(check18_1TecSeguranca.Checked == true)
            {
                indTecSeguranca = "S";
            }
            else
            {
                indTecSeguranca = "N";
            }
            if(check18_1Planejador.Checked == true)
            {
                indPlanejador = "S";
            }
            else
            {
                indPlanejador = "N";
            }
            if (check18_1Outro.Checked == true)
            {
                if (string.IsNullOrEmpty(txt18_1DescProfissional.Text))
                {
                    MessageBox.Show("Informe a descrição do profissional.");
                }
                else
                {
                    indOutroProfissional = "S";
                    descOutroProfissional = txt18_1DescProfissional.Text;
                }
            }
            else
            {
                indOutroProfissional = "N";
                descOutroProfissional = null;
            }


            if(check18_1Encarregado.Checked == true)
            {
                indEncarregado = "S";
            }
            else
            {
                indEncarregado = "N";
            }

            SOEF_CLASS.Escopo_18_1 Escopo18_1 = new SOEF_CLASS.Escopo_18_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
            //Verifica se é registro novo ou alteração
            if(AcaoTela == "N")
            {
                vlrRetorno = Escopo18_1.gravaEscopo18_1(indEngResidente, indAdministrativo, indTecSeguranca, indPlanejador, indOutroProfissional, descOutroProfissional, txt18_1Obs.Text, "S", indEncarregado);
                if(vlrRetorno > 0)
                {
                    MessageBox.Show("Registro realizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro no cadastro do registro.");
                }
                btn18_1Excluir.Visible = true;
                listaEscopo18_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
            }
            else
            {
                //Verifica se existe registro cadastrado
                DataTable dt = Escopo18_1.getEscopo18_1();
                if (dt.Rows.Count > 0)
                {

                    vlrRetorno = Escopo18_1.atualizaEscopo18_1(indEngResidente, indAdministrativo, indTecSeguranca, indPlanejador, indOutroProfissional, descOutroProfissional, txt18_1Obs.Text, "S", indEncarregado);
                    if (vlrRetorno > 0)
                    {
                        MessageBox.Show("Registro atualizado com sucesso!");
                        listaEscopo18_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro na atualização do registro.");
                    }
                }
                else 
                {
                    //Se não tem nenhum registro cadastrado
                    vlrRetorno = Escopo18_1.gravaEscopo18_1(indEngResidente, indAdministrativo, indTecSeguranca, indPlanejador, indOutroProfissional, descOutroProfissional, txt18_1Obs.Text, "S", indEncarregado);
                    if (vlrRetorno > 0)
                    {
                        MessageBox.Show("Registro realizado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro no cadastro do registro.");
                    }
                    btn18_1Excluir.Visible = true;
                    listaEscopo18_1(this.numero_solic.ToString(), this.NumRevisaoSolic);

                }
            }


        }

        private void btn18_2Salvar_Click(object sender, EventArgs e)
        {
            string indTecnicoObras;
            string indAlmoxarife;
            string indMontador;
            string indAuxMontador;
            string indSoldador;
            string indOutroProfissional;
            string descOutroProfissional = "";
            string indPlataformaElevatoria;
            string indMunck;
            string indFerramental;
            
            if(check18_2TecObras.Checked == true)
            {
                indTecnicoObras = "S";
            }
            else
            {
                indTecnicoObras = "N";
            }
            if(check18_2Almoxarife.Checked == true)
            {
                indAlmoxarife = "S";
            }
            else
            {
                indAlmoxarife = "N";
            }
            if(check18_2Montador.Checked == true)
            {
                indMontador = "S";
            }
            else
            {
                indMontador = "N";
            }
            if(check18_2AuxiliarMontador.Checked == true)
            {
                indAuxMontador = "S";
            }
            else
            {
                indAuxMontador = "N";
            }
            if(check18_2Soldador.Checked == true)
            {
                indSoldador = "S";
            }
            else
            {
                indSoldador = "N";
            }
            if(check18_2Outro.Checked == true)
            {
                indOutroProfissional = "S";
                if (string.IsNullOrEmpty(txt18_2DescProfissional.Text))
                {
                    MessageBox.Show("Informe a descrição do profissional.");
                }
                else
                {
                    descOutroProfissional = txt18_2DescProfissional.Text;
                }
            }
            else
            {
                indOutroProfissional = "N";
                //Limpa a Descrição Outro Profissional
                txt18_2DescProfissional.Text = "";
                descOutroProfissional = "";
            }           

            if (check18_2PlataformaElevatoria.Checked == true)
            {
                indPlataformaElevatoria = "S";
            }
            else
            {
                indPlataformaElevatoria = "N";
            }

             if(check18_2Munck.Checked == true)
            {
                indMunck = "S";
            }
            else
            {
                indMunck = "N";
            }
            if(check18_2Ferramental.Checked == true)
            {
                indFerramental = "S";
            }
            else
            {
                indFerramental = "N";
            }

            if(AcaoTela == "N")
            {
                SOEF_CLASS.Escopo_18_2 Escopo_18_2 = new SOEF_CLASS.Escopo_18_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno = Escopo_18_2.gravaEscopo18_2(indTecnicoObras, indAlmoxarife, indMontador, indAuxMontador, indSoldador, indOutroProfissional, descOutroProfissional, indPlataformaElevatoria, indMunck, indFerramental, txt18_2Obs.Text, "S");
                if(retorno > 0)
                {
                    MessageBox.Show("Registro inserido com sucesso!");
                    listaEscopo18_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao inserir o registro.");
                }
            }
            else
            {
                SOEF_CLASS.Escopo_18_2 Escopo_18_2 = new SOEF_CLASS.Escopo_18_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                DataTable dtBusca = Escopo_18_2.getEscopo18_2();
                //Testa se já existe registro
                if (dtBusca.Rows.Count > 0)
                {
                    int retorno = Escopo_18_2.atualizaEscopo18_2(indTecnicoObras, indAlmoxarife, indMontador, indAuxMontador, indSoldador, indOutroProfissional, descOutroProfissional, indPlataformaElevatoria, indMunck, indFerramental, txt18_2Obs.Text, "S");
                    if (retorno > 0)
                    {
                        MessageBox.Show("Registro atualizado com sucesso!");
                        listaEscopo18_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao atualizar o registro.");
                    }
                }
                else
                {   //Se não existe registro ainda, insere um novo
                    int retorno = Escopo_18_2.gravaEscopo18_2(indTecnicoObras, indAlmoxarife, indMontador, indAuxMontador, indSoldador, indOutroProfissional, descOutroProfissional, indPlataformaElevatoria, indMunck, indFerramental, txt18_2Obs.Text, "S");
                    if (retorno > 0)
                    {
                        MessageBox.Show("Registro inserido com sucesso!");
                        listaEscopo18_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao inserir o registro.");
                    }
                }


                


            }
        }

        private void btn18Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 18 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SOEF_CLASS.Escopo_18 Escopo18 = new SOEF_CLASS.Escopo_18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno;
                retorno = Escopo18.deleteEscopo18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if(retorno > 0)
                {
                    MessageBox.Show("Escopo excluido com sucesso!");
                    listaEscopo18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    btn18Excluir.Visible = false;
                    listaEscopo18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o escopo selecionado.");
                }
            }
        }

        private void tabEscopo18_1_2_Selected(object sender, TabControlEventArgs e)
        {
            if (AcaoTela == "N")
            {
                if(tabEscopo18_1_2.SelectedTab.Name == "tbpage18InfoG")
                {
                    listaEscopo18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }

                if (tabEscopo18_1_2.SelectedTab.Name == "tbpage18DefMaoObra")
                {
                    listaEscopo18_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
            }
            else
            {
                if (tabEscopo18_1_2.SelectedTab.Name == "tbpage18InfoG")
                {
                    listaEscopo18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    
                }

                if (tabEscopo18_1_2.SelectedTab.Name == "tbpage18DefMaoObra")
                {
                    listaEscopo18_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    listaEscopo18_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }

            }


            
        }

        private void btn18_1Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir este registro?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SOEF_CLASS.Escopo_18_1 Escopo_18_1 = new SOEF_CLASS.Escopo_18_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    int retorno = Escopo_18_1.deleteEscopo18(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if (retorno > 0)
                    {
                        MessageBox.Show("Registro excluído com sucesso!");
                        listaEscopo18_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao excluir o registro. Favor tente novamente.");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btn18_2Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir este registro?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SOEF_CLASS.Escopo_18_2 Escopo_18_2 = new SOEF_CLASS.Escopo_18_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno = Escopo_18_2.deleteEscopo18_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (retorno > 0)
                {
                    MessageBox.Show("Registro excluído com sucesso!");
                    listaEscopo18_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o registro. Favor tente novamente.");
                }

            }
        }

        private void combo01Frequencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo01Frequencia.SelectedIndex == 3)
            {
                txt01OutraFrequencia.Enabled = true;
            }
            else
            {
                txt01OutraFrequencia.Text = "";
                txt01OutraFrequencia.Enabled = false;
            }
        }


        /// <summary>
        /// Retorna TRUE quando todos campos da tabela DOM_SOLIC_ORC_VALOR_COMUM estão nulos
        /// </summary>
        /// <param name="pNumSolic">Número da Solicitação</param>
        /// <param name="pNumRevSolic">Número da Revisão</param>
        /// <returns></returns>
        private Boolean verificaRegistroValorComum(string pNumSolic, string pNumRevSolic)
        {
            try
            {
                int NaoNulo = 0;
                SOEF_CLASS.Escopo_Valor_Comum EscopoValorComum = new SOEF_CLASS.Escopo_Valor_Comum(pNumSolic, pNumRevSolic);
                DataTable dtEscopoNull = EscopoValorComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (dtEscopoNull.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_INSTAL_ABRIG_TEMPO"].ToString()))
                    {
                        NaoNulo =+ 1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["DADOS_AMBIENTAIS"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TENSAO_TRIFASICA_BT"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TENSAO_MONOFASICA_BT"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["FREQUENCIA_HZ"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TIPO_PINTURA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["NORMATIVA_MAPA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TIPO_PRODUTO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["OUTRO_PRODUTO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_PAINEL_ELETRICO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_INSTAL_ELETRICA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TIPO_INSTAL_MECANICA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_AREA_CLASSIFICADA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_SALA_PAINEL_CLIMATIZADA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["OUTRA_FREQUENCIA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TENSAO_INTERNA_CONTROLE"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TIPO_REDE_COMUNICACAO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TENSAO_ILUMINACAO_TRIF"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["OUTRA_TENSAO_ILUM_TRIF"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["SELECAO_MECAN_FLUXO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["OUTRA_SELEC_MECANICA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["POTENCIA_GERADOR"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["FABRICANTE_GERADOR"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["MODELO_CONTROLADOR"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["FABRICANTE_CONTROLADOR"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["ACIONAMENTO_SISTEMA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TIPO_TRANSFER_ACION_AUT"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_TRANSFER_ACION_MAN"].ToString()))
                    {
                        NaoNulo = +1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_MEMORIAL_DESCRITIVO"].ToString()))
                    {
                        NaoNulo = +1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_LISTA_MATERIAIS"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TENSAO_DISTRIBUICAO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["OUTRA_TENSAO_DISTRIB"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_PLANTA_BAIXA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_PADRAO_ELETRODUTO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_PADR_PROTEC_MECANICA"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_CORTE_MEC_CIVIL"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["TENSAO_ILUMINACAO_MONO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_LISTA_COMANDO_EQUIP"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["IND_FLUXOGRAMA_PONTO_COMANDO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                    if (!string.IsNullOrEmpty(dtEscopoNull.Rows[0]["DESC_PONTOS_EQUIPAMENTO"].ToString()))
                    {
                        NaoNulo =+1;
                    }
                }
                //Se todos os campos estão nulo (NaoNulo = 0), retorna TRUE, senão, retorna FALSE
                if (NaoNulo == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btn01Salvar_Click(object sender, EventArgs e)
        {
            string erro = "";
            

            string tensaoMedia;
            string indTipoInstalacao = "";
            string indEnsaio = "";
            string tipoPintura = "";
            string obs = "";
            string indPreenchido = "";
            string frequencia = "";
            string descOutraFrequencia = "";
            string descOutroEnsaio = "";
            string dadosAmbientais = "";
            string indDiagramaUnifilar = "";
            string descSolucao = "";
            string outraTensaoD = "";

            //Tensão Distribuição
            if (combo01Tensao.SelectedIndex == 0)
            {
                erro += "Informe a Tensão de Distribuição.\n";
            }
            else if (combo01Tensao.SelectedIndex == 4)
            {
                if (string.IsNullOrEmpty(txt01Obs.Text))
                {
                    erro += "Por favor, informe a descrição da Taxa de Distribuição no campo Observação.\n";
                }
                if (string.IsNullOrEmpty(txt01OutraTensao.Text))
                {
                    erro += "Informe o campo Outra Tensão\n";
                }
                else
                {
                    outraTensaoD = txt01OutraTensao.Text;
                }

            }
            tensaoMedia = combo01Tensao.SelectedIndex.ToString();

            //Frequência
            if(combo01Frequencia.SelectedIndex == 0)
            {
                erro += "Informe a Frequência.\n";
            }
            else if(combo01Frequencia.SelectedIndex == 3)
            {
                if (string.IsNullOrEmpty(txt01OutraFrequencia.Text))
                {
                    erro += "Por favor, informe o valor da Frequência.\n";
                }
                else
                {
                    descOutraFrequencia = txt01OutraFrequencia.Text;
                }
            }
            frequencia = combo01Frequencia.SelectedIndex.ToString();
            
            //Instalação
            if(combo01Instalacao.SelectedIndex == 0)
            {
                erro += "Informe o Tipo de Instalação\n";
            }
            else if(combo01Instalacao.SelectedIndex == 1)
            {
                indTipoInstalacao = "A";
            }
            else if(combo01Instalacao.SelectedIndex == 2)
            {
                indTipoInstalacao = "T";
            }
            else if(combo01Instalacao.SelectedIndex == 3)
            {
                indTipoInstalacao = "M";
            }

            //Dados Ambientais
            if(combo01DadosAmbientais.SelectedIndex == 0)
            {
                erro += "Informe o campo Dados Ambientais.\n";
            }
            else if(combo01DadosAmbientais.SelectedIndex == 1)
            {
                dadosAmbientais = "U";
            }
            else if (combo01DadosAmbientais.SelectedIndex == 2)
            {
                dadosAmbientais = "M";
            }
            else if (combo01DadosAmbientais.SelectedIndex == 3)
            {
                dadosAmbientais = "C";
            }
            else if (combo01DadosAmbientais.SelectedIndex == 4)
            {
                dadosAmbientais = "N";
            }

            //Pintura
            if (combo01Pintura.SelectedIndex == 0)
            {
                erro += "Informe o Tipo de Pintura.\n";
            }
            else if(combo01Pintura.SelectedIndex == 1)
            {
                tipoPintura = "R";
            }
            else if (combo01Pintura.SelectedIndex == 2)
            {
                tipoPintura = "M";
            }
            else if (combo01Pintura.SelectedIndex == 3)
            {
                tipoPintura = "E";
            }
            
            //Ensaio Painel
            if (combo01EnsaioPainel.SelectedIndex == 0)
            {
                erro += "Informe o Ensaio Painel.\n";
            }
            else if(combo01EnsaioPainel.SelectedIndex == 1)
            {
                indEnsaio = "A";
            }
            else if (combo01EnsaioPainel.SelectedIndex == 2)
            {
                indEnsaio = "C";
            }
            else if (combo01EnsaioPainel.SelectedIndex == 3)
            {
                indEnsaio = "T";
            }
            else if(combo01EnsaioPainel.SelectedIndex == 4)
            {
                if (string.IsNullOrEmpty(txt01OutroEnsaio.Text))
                {
                    erro += "Informe a descrição do Outro Ensaio.\n";
                }
                else
                {
                    indEnsaio = "O";
                    descOutroEnsaio = txt01OutroEnsaio.Text;
                }
            }

            //Tem Diagrama Unifilar
            if(rbtn01Nao.Checked == false && rbtn01Sim.Checked == false)
            {
                erro += "Informe o campo Tem Diagrama Unifilar.\n";
            }
            else if (rbtn01Sim.Checked == true)
            {
                indDiagramaUnifilar = "S";
                descSolucao = null;
            }
            else
            {
                indDiagramaUnifilar = "N";
                descSolucao = txt01Descricao.Text;
            }
            //Se tem erros de validação de campo
            if (!string.IsNullOrEmpty(erro))
            {
                MessageBox.Show(erro);
            }
            else
            {
                int retornoAtualizaVlrComum = 0;
                int retornoGravaVlrComum = 0;
                bool sucesso = true;
                int retornoInsertEscopo01 = 0;
                //Insere os dados

                try
                {
                    if (AcaoTela == "N")
                    {
                        SOEF_CLASS.Escopo_01 Escopo01 = new SOEF_CLASS.Escopo_01(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        retornoInsertEscopo01 = Escopo01.gravaEscopo_01(tensaoMedia, indTipoInstalacao, indEnsaio, tipoPintura, txt01Obs.Text, "S", frequencia, descOutraFrequencia, dadosAmbientais, indDiagramaUnifilar, descSolucao, descOutroEnsaio, outraTensaoD);
                        if (retornoInsertEscopo01 > 0)
                        {
                            SOEF_CLASS.Escopo_Valor_Comum EscopoValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            //Verifica se existe registro na tabela Valor Comum
                            DataTable dt = EscopoValorComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (dt.Rows.Count == 0)
                            {
                                //Se não encontra registro para o registro, grava pela primeira vez
                                retornoGravaVlrComum = EscopoValorComum.gravaEscopo_Valor_Comum_E01(dadosAmbientais, frequencia, descOutraFrequencia, tipoPintura, indTipoInstalacao, tensaoMedia, outraTensaoD);
                                if (retornoGravaVlrComum <= 0)
                                {
                                    sucesso = false;
                                    MessageBox.Show("Houve um problema na inserção dos Valores Comum. Por favor, tente novamente.");
                                }
                            }
                            else
                            {
                                //Atualiza os campos existentes no escopo 1
                                retornoAtualizaVlrComum = EscopoValorComum.atualizaEscopo_Valor_Comum_E01(dadosAmbientais, frequencia, descOutraFrequencia, tipoPintura, indTipoInstalacao, tensaoMedia, outraTensaoD);
                                if (retornoAtualizaVlrComum > 0)
                                {
                                    //Verifica se os campos da tabela estão nullos
                                    bool DeletaRegistro = verificaRegistroValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                    if (DeletaRegistro)//True - Deleta o registro
                                    {
                                        int retornoDelete = EscopoValorComum.deleteEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                        if (retornoDelete <= 0)
                                        {
                                            sucesso = false;
                                            MessageBox.Show("Não foi possível realizar a operação completa. Por favor, verifique os dados informados e tente novamente.");
                                        }
                                    }
                                }
                                else
                                {
                                    sucesso = false;
                                    MessageBox.Show("Houve um problema na inserção do registro de Valores Comuns. Por favor, tente novamente.");
                                }
                            }
                        }
                        else
                        {
                            sucesso = false;
                            MessageBox.Show("Ocorreu um erro ao inserir o registro!");
                        }
                    }
                    //FimAçãoTela
                    else
                    {
                        //Se a Ação Tela for ATUALIZAÇÃO
                        SOEF_CLASS.Escopo_01 Escopo01 = new SOEF_CLASS.Escopo_01(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        //Verifica se o Escopo já foi preenchido ou não
                        DataTable dtEscopo01 = Escopo01.getEscopo_01();
                        if(dtEscopo01.Rows.Count > 0)
                        {
                            retornoInsertEscopo01 = Escopo01.updateEscopo_01(tensaoMedia, indTipoInstalacao, indEnsaio, tipoPintura, txt01Obs.Text, "S", frequencia, descOutraFrequencia, dadosAmbientais, indDiagramaUnifilar, descSolucao, descOutroEnsaio, outraTensaoD);
                        }
                        else
                        {
                            retornoInsertEscopo01 = Escopo01.gravaEscopo_01(tensaoMedia, indTipoInstalacao, indEnsaio, tipoPintura, txt01Obs.Text, "S", frequencia, descOutraFrequencia, dadosAmbientais, indDiagramaUnifilar, descSolucao, descOutroEnsaio, outraTensaoD);
                        }
                        
                        if (retornoInsertEscopo01 > 0)
                        {
                            SOEF_CLASS.Escopo_Valor_Comum EscopoValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            //Verifica se existe registro na tabela Valor Comum
                            DataTable dt = EscopoValorComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (dt.Rows.Count == 0)
                            {
                                //Se não encontra registro para o registro, grava pela primeira vez
                                retornoGravaVlrComum = EscopoValorComum.gravaEscopo_Valor_Comum_E01(dadosAmbientais, frequencia, descOutraFrequencia, tipoPintura, indTipoInstalacao, tensaoMedia, outraTensaoD);
                                if (retornoGravaVlrComum <= 0)
                                {
                                    MessageBox.Show("Houve um problema na inserção dos Valores Comum. Por favor, tente novamente.");
                                }
                            }
                            else
                            {
                                //Atualiza os campos existentes no escopo 1
                                retornoAtualizaVlrComum = EscopoValorComum.atualizaEscopo_Valor_Comum_E01(dadosAmbientais, frequencia, descOutraFrequencia, tipoPintura, indTipoInstalacao, tensaoMedia, outraTensaoD);
                                if (retornoAtualizaVlrComum > 0)
                                {
                                    //Verifica se os campos da tabela estão nullos
                                    bool DeletaRegistro = verificaRegistroValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                    if (DeletaRegistro)//True - Deleta o registro
                                    {
                                        int retornoDelete = EscopoValorComum.deleteEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                        if (retornoDelete <= 0)
                                        {
                                            sucesso = false;
                                            MessageBox.Show("Não foi possível realizar a operação completa. Por favor, verifique os dados informados e tente novamente.");
                                        }
                                    }
                                }
                                else
                                {
                                    sucesso = false;
                                    MessageBox.Show("Houve um problema na inserção do registro de Valores Comuns. Por favor, tente novamente.");
                                }
                            }
                        }
                        else
                        {
                            sucesso = false;
                            MessageBox.Show("Ocorreu um erro ao inserir o registro!");
                        }
                    }
                    //Verifica se ocorreu erro durante o processo de inserção no ESCOPO 01 e VALOR COMUM
                    if (sucesso)
                    {
                        MessageBox.Show("Registro inserido/alterado com sucesso!");
                        btn01Excluir.Visible = true;
                        listaEscopo01(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        //Muda o STATUS da AçãoTela p/ EDIÇÂO
                        AcaoTela = "C";
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao ao inserir/alterar o registro. Por favor tente novamente ou contate o administrador do sistema.");
                    }
                }
                catch (Exception)
                {
                    throw;
                }


                


            }
        }

        private void combo01EnsaioPainel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo01EnsaioPainel.SelectedIndex == 4)
            {
                txt01OutroEnsaio.Enabled = true;
            }
            else
            {
                txt01OutroEnsaio.Text = "";
                txt01OutroEnsaio.Enabled = false;
            }
        }

        private void combo01Tensao_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Selecionado: " + combo01Tensao.SelectedIndex.ToString());
            if(combo01Tensao.SelectedIndex == 4)
            {
                txt01Obs.Text = "";
                txt01OutraTensao.Enabled = true;
            }
            else
            {
                txt01OutraTensao.Text = "";
                txt01OutraTensao.Enabled = false;
            }
        }

        private void rbtn01Sim_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn01Sim.Checked == true)
            {
                txt01Descricao.Text = "";
                txt01Descricao.Enabled = false;
            }
            else
            {
                txt01Descricao.Enabled = true;
            }
        }


        private void btn01Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 01 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool sucesso = true;
                //Apaga os dados do Escopo 01
                SOEF_CLASS.Escopo_01 Escopo01 = new SOEF_CLASS.Escopo_01(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno = Escopo01.deleteEscopo_01(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (retorno > 0)
                {
                    //Apaga (define como NULL) os campos comuns da tabela VALOR_COMUM
                    SOEF_CLASS.Escopo_Valor_Comum EValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    int retornoUpdate = 0;
                    retornoUpdate = EValorComum.deleteEscopo_Valor_Comum_E01 ();
                    if(retornoUpdate > 0)
                    {
                        //Verifica se todos os campos do registro são nulos, se sim, apaga o registro em definitivo
                        bool DeletaRegistro = verificaRegistroValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if (DeletaRegistro)//True - Deleta o registro
                        {
                            int retornoDelete = EValorComum.deleteEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (retornoDelete <= 0)
                            {
                                sucesso = false;
                                //MessageBox.Show("Não foi possível realizar a operação completa. Por favor, verifique os dados informados e tente novamente.");
                            }
                        }
                    }
                    else
                    {
                        sucesso = false;
                    }
                }
                else
                {
                    sucesso = false;
                }
                if (sucesso)
                {
                    MessageBox.Show("Registro excluído com sucesso!");
                    btn01Excluir.Visible = false;
                    checkEscopo1.Checked = false;
                    checkEscopo1.Enabled = true;
                    listaEscopo01(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o registro. Por favor, contate o suporte do sistema e tente novamente.");
                }
            }
        }

        private void comboE10_1Freq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboE10_1Freq.SelectedIndex == 3)
            {
                txtE10_1OutraFreq.Enabled = true;
            }
            else
            {
                txtE10_1OutraFreq.Text = "";
                txtE10_1OutraFreq.Enabled = false;
            }
        }

        private void comboE10_1TipoProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboE10_1TipoProd.SelectedIndex == 5)
            {
                txtE10_1OutroProd.Enabled = true;
            }
            else
            {
                txtE10_1OutroProd.Text = "";
                txtE10_1OutroProd.Enabled = false;
            }

        }

        private void comboE10_1TipoInstalacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboE10_1TipoInstalacao.SelectedIndex == 2)
            {
                comboE10_1MatTampa.Enabled = true;
            }
            else
            {
                comboE10_1MatTampa.SelectedIndex = 0;
                comboE10_1MatTampa.Enabled = false;
            }
        }

        private void comboE10_1MatTampa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboE10_1MatTampa.SelectedIndex == 2)
            {
                comboE10_1TipoTampa.Enabled = true;
            }
            else
            {
                comboE10_1TipoTampa.SelectedIndex = 0;
                comboE10_1TipoTampa.Enabled = false;
            }
        }
        
        /// <summary>
        /// Inicializa campos Escopo 05
        /// </summary>
        private void inicializaCamposE05()
        {
            combo05DadosAmbientais.SelectedIndex = 0;
            combo05Freq.SelectedIndex = 0;
            txt05Obs.Text = "";
            btn05Excluir.Visible = false;
        }

        /// <summary>
        /// Inicializa campos Escopo 05_1
        /// </summary>
        private void inicializaCamposE05_1()
        {
            radio5_1PotInf.Checked = true;
            combo5_1TensaoPrimaria.SelectedIndex = 0;
            combo5_1TensaoSec.SelectedIndex = 0;
            combo5_1Pintura.SelectedIndex = 0;            
        }

        /// <summary>
        /// Inicializa campos Escopo 05_2
        /// </summary>
        private void inicializaCamposE05_2()
        {
            radio5_2PotInf.Checked = true;
            combo5_2TensaoPrim.SelectedIndex = 0;
            combo5_2TensaoSec.SelectedIndex = 0;
            combo5_2MeioIsol.SelectedIndex = 0;
            combo5_2Pintura.SelectedIndex = 0;
            combo5_2BuchaMT.SelectedIndex = 0;
            combo5_2BuchaBT.SelectedIndex = 0;
            txt5_2DescOutraBuchaMT.Text = "";
            txt5_2DescOutraBuchaMT.Visible = true;
            txt5_2DescOutraBuchaBT.Text = "";
            txt5_2DescOutraBuchaBT.Visible = true;
            combo5_2Potencia.SelectedIndex = 0;
        }

        /// <summary>
        /// Inicializa os campos do Escopo 10_1
        /// </summary>
        private void inicializaCamposE10_1()
        {
            comboE10_1TensaoTri.SelectedIndex = 0;
            comboE10_1Freq.SelectedIndex = 0;
            comboE10_1DadosAmbientais.SelectedIndex = 0;
            radioE10_1NormativaS.Checked = false;
            radioE10_1NormativaN.Checked = false;
            comboE10_1TipoProd.SelectedIndex = 0;
            comboE10_1Umidade.SelectedIndex = 0;
            comboE10_1TipoAeracao.SelectedIndex = 0;
            comboE10_1TipoInstalacao.SelectedIndex = 0;
            comboE10_1MatTampa.SelectedIndex = 0;
            comboE10_1TipoTampa.SelectedIndex = 0;
            comboE10_1MatCasaMata.SelectedIndex = 0;            
        }
        
        /// <summary>
        /// Inicializa os campos do Escopo 10_2
        /// </summary>
        private void inicializaCamposE10_2()
        {
            combo10_2CapacidadeArmazem.SelectedIndex = 0;
            combo10_2CapacidadeSilo.SelectedIndex = 0;
            combo10_2DadosAmbientais.SelectedIndex = 0;
            combo10_2Produto.SelectedIndex = 0;
            combo10_2Transportadores.SelectedIndex = 0;

        }

        /// <summary>
        /// Inicializa campos Escopo 10_3
        /// </summary>
        private void inicializaCamposE10_3()
        {
            combo10_3Tensao.SelectedIndex = 0;
            combo10_3Freq.SelectedIndex = 0;
            combo10_3DadosAmbientais.SelectedIndex = 0;
            combo10_3Local.SelectedIndex = 0;

        }

        /// <summary>
        /// Inicializa campos Escopo 10_4
        /// </summary>
        private void inicializaCamposE10_4()
        {
            combo10_4MatTampa.SelectedIndex = 0;
            combo10_4TipoTampa.SelectedIndex = 0;
        }


        private void tabsEscopo10_Selected(object sender, TabControlEventArgs e)
        {
            if (tabsEscopo10.SelectedTab.Name == "tabEscopo10_1")
            {
                //MessageBox.Show("show");
            } //Fim Escopo 10_1
            else if(tabsEscopo10.SelectedTab.Name == "tabEscopo10_2")
            {
                if (AcaoTela == "N")
                {
                    SOEF_CLASS.Escopo_Valor_Comum EscopoValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Verifica e sugere os campos comuns caso existir registro
                    DataTable dtEscopo10_2 = EscopoValorComum.buscaEscopoValorComumE10_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if (dtEscopo10_2.Rows.Count > 0)
                    {
                        foreach(DataRow dr in dtEscopo10_2.Rows)
                        {
                            //Dados Ambientais
                            if (dr["DADOS_AMBIENTAIS"].ToString() == "U")
                            {
                                combo10_2DadosAmbientais.SelectedIndex = 1;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "M")
                            {
                                combo10_2DadosAmbientais.SelectedIndex = 2;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                            {
                                combo10_2DadosAmbientais.SelectedIndex = 3;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                            {
                                combo10_2DadosAmbientais.SelectedIndex = 4;
                            }

                            //Tipo Produto
                            if (dr["TIPO_PRODUTO"].ToString() == "S")
                            {
                                combo10_2Produto.SelectedIndex = 1;
                            }
                            else if (dr["TIPO_PRODUTO"].ToString() == "M")
                            {
                                combo10_2Produto.SelectedIndex = 2;
                            }
                            else if (dr["TIPO_PRODUTO"].ToString() == "T")
                            {
                                combo10_2Produto.SelectedIndex = 3;
                            }
                            else if (dr["TIPO_PRODUTO"].ToString() == "A")
                            {
                                combo10_2Produto.SelectedIndex = 4;
                            }
                            else if (dr["TIPO_PRODUTO"].ToString() == "O")
                            {
                                combo10_2Produto.SelectedIndex = 5;
                                txt10_2OutroProd.Enabled = true;
                                txt10_2OutroProd.Text = dr["OUTRO_PRODUTO"].ToString();
                            }
                        }
                    }
                    else
                    {
                        inicializaCamposE10_2();
                    }
                }
                else
                {
                    listaEscopo10_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
            }//Fim Escopo 10_2
            else if (tabsEscopo10.SelectedTab.Name == "tabEscopo10_3")
            {
                inicializaCamposE10_3();
                SOEF_CLASS.Escopo_10_3 Escopo10_3 = new SOEF_CLASS.Escopo_10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                dgv10_3.DataSource = Escopo10_3.getRenovadoresAr(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (AcaoTela == "N")
                {
                    SOEF_CLASS.Escopo_Valor_Comum EscopoValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Verifica e sugere os campos comuns caso existir registro
                    DataTable dtEscopo10_3 = EscopoValorComum.buscaEscopoValorComumE10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if (dtEscopo10_3.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtEscopo10_3.Rows)
                        {
                            //Dados Ambientais
                            if (dr["DADOS_AMBIENTAIS"].ToString() == "U")
                            {
                                combo10_2DadosAmbientais.SelectedIndex = 1;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "M")
                            {
                                combo10_2DadosAmbientais.SelectedIndex = 2;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "C")
                            {
                                combo10_2DadosAmbientais.SelectedIndex = 3;
                            }
                            else if (dr["DADOS_AMBIENTAIS"].ToString() == "N")
                            {
                                combo10_2DadosAmbientais.SelectedIndex = 4;
                            }

                            //Frequência
                            combo10_3Freq.SelectedIndex = Convert.ToInt32(dr["FREQUENCIA_HZ"].ToString());
                            if(combo10_3Freq.SelectedIndex == 3)
                            {
                                txt10_3OutraFreq.Enabled = true;
                                txt10_3OutraFreq.Text = dr["OUTRA_FREQUENCIA"].ToString();
                            }
                            else
                            {
                                txt10_3OutraFreq.Enabled = false;
                                txt10_3OutraFreq.Text = "";
                            }

                            //Tensao Trifásica
                            combo10_3Tensao.SelectedIndex = Convert.ToInt32(dr["TENSAO_TRIFASICA_BT"].ToString());
                        }
                    }
                    else
                    {
                        inicializaCamposE10_3();
                    }
                }
                else
                {
                    listaEscopo10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
            }//Fim Escopo 10_3
            else if (tabsEscopo10.SelectedTab.Name == "tabEscopo10_4") //Fim Escopo 10_4
            {            
                if (AcaoTela == "N")
                {
                    inicializaCamposE10_4();
                }
                else
                {
                    listaEscopo10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
            }//Fim Escopo 10_4
        }

        private void btnE10_1Salvar_Click(object sender, EventArgs e)
        {
            string erro = "";
            if(comboE10_1TensaoTri.SelectedIndex == 0)
            {
                erro += "O campo Tensão Trifásica deve ser preenchido.\n";
            }
            if(comboE10_1Freq.SelectedIndex == 0)
            {
                erro += "O campo Tensão Trifásica deve ser preenchido.\n";
            }
            else if(comboE10_1Freq.SelectedIndex == 3)
            {
                if (string.IsNullOrEmpty(txtE10_1OutraFreq.Text))
                {
                    erro += "O campo Outra Frequência deve ser preenchido.\n";
                }
            }
            if(comboE10_1DadosAmbientais.SelectedIndex == 0)
            {
                erro += "O campo Dados Ambientais deve ser preenchido.\n";
            }
            if(radioE10_1NormativaS.Checked == false && radioE10_1NormativaN.Checked == false)
            {
                erro += "O campo Normativa do MAPA deve ser preenchido.\n";
            }
            if(comboE10_1TipoProd.SelectedIndex == 0)
            {
                erro += "O campo Tipo de Produto deve ser preenchido.\n";
            }
            else if(comboE10_1TipoProd.SelectedIndex == 5)
            {
                if (string.IsNullOrEmpty(txtE10_1OutroProd.Text))
                {
                    erro += "O campo Outro Produto deve ser preenchido.\n";
                }
            }
            if(comboE10_1Umidade.SelectedIndex == 0)
            {
                erro += "O campo Umidade do Produto deve ser preenchido.\n";
            }
            if(comboE10_1TipoAeracao.SelectedIndex == 0)
            {
                erro += "O campo Tipo Aeração deve ser preenchido.\n";
            }
            if(comboE10_1TipoInstalacao.SelectedIndex == 0)
            {
                erro += "O campo Tipo Instalação deve ser preenchido.\n";
            }
            else if(comboE10_1TipoInstalacao.SelectedIndex == 2)
            {
                if(comboE10_1MatTampa.SelectedIndex == 0)
                {
                    erro += "O campo Material da Tampa deve ser preenchido.\n";
                }
                else if(comboE10_1MatTampa.SelectedIndex == 2)
                {
                    if(comboE10_1TipoTampa.SelectedIndex == 0)
                    {
                        erro += "O campo Tipo da Tampa deve ser preenchido.\n";
                    }
                }
            }
            if(comboE10_1MatCasaMata.SelectedIndex == 0)
            {
                erro += "O campo Material da Casa Mata deve ser preenchido.\n";
            }

            //Verifica se todos os campos foram inseridos corretamente
            if (!string.IsNullOrEmpty(erro))
            {
                MessageBox.Show("Painel de erros:\n" + erro);
            }
            else
            {
                string tensaoTrifasica = comboE10_1TensaoTri.SelectedIndex.ToString();
                string frequenciaHz = comboE10_1Freq.SelectedIndex.ToString();
                
                string outraFrequencia = txtE10_1OutraFreq.Text;
                string dadosAmbientais = "";
                if(comboE10_1DadosAmbientais.SelectedIndex == 1)
                {
                    dadosAmbientais = "U";
                }
                else if (comboE10_1DadosAmbientais.SelectedIndex == 2)
                {
                    dadosAmbientais = "M";
                }
                else if (comboE10_1DadosAmbientais.SelectedIndex == 3)
                {
                    dadosAmbientais = "C";
                }
                else
                {
                    dadosAmbientais = "N";
                }
                //Normativa Mapa
                string normativaMapa = "";
                if (radioE10_1NormativaS.Checked)
                {
                    normativaMapa = "S";
                }
                else
                {
                    normativaMapa = "N";
                }
                //Tipo Produto
                string tipoProduto = "";
                //Outro Produto
                string outroProduto = "";
                if(comboE10_1TipoProd.SelectedIndex == 1)
                {
                    tipoProduto = "S";
                }
                else if (comboE10_1TipoProd.SelectedIndex == 2)
                {
                    tipoProduto = "M";
                }
                else if (comboE10_1TipoProd.SelectedIndex == 3)
                {
                    tipoProduto = "T";
                }
                else if (comboE10_1TipoProd.SelectedIndex == 4)
                {
                    tipoProduto = "A";
                }
                else
                {
                    tipoProduto = "O";
                    outroProduto = txtE10_1OutroProd.Text;
                }
                //Umidade
                string umidade;
                if(comboE10_1Umidade.SelectedIndex == 1)
                {
                    umidade = "14";
                }
                else if (comboE10_1Umidade.SelectedIndex == 2)
                {
                    umidade = "16";
                }
                else
                {
                    umidade = "18";
                }

                //Tipo Aeração
                string tipoAeracao = "";
                if(comboE10_1TipoAeracao.SelectedIndex == 1)
                {
                    tipoAeracao = "L";
                }
                else
                {
                    tipoAeracao = "T";
                }

                //Tipo Instalação
                string tipoInstalacao = "";
                if(comboE10_1TipoInstalacao.SelectedIndex == 1)
                {
                    tipoInstalacao = "P";
                }
                else
                {
                    tipoInstalacao = "C";
                }

                //Material Tampa Canaleta
                string matTampaCanaleta = "";
                if(comboE10_1MatTampa.SelectedIndex == 1)
                {
                    matTampaCanaleta = "P";
                }
                else
                {
                    matTampaCanaleta = "M";
                }

                //Tipo Tampa Canaleta
                string tipoTampaCanaleta = "";
                if(comboE10_1TipoTampa.SelectedIndex == 1)
                {
                    tipoTampaCanaleta = "P";
                }
                else
                {
                    tipoTampaCanaleta = "O";
                }
                //Material Casa Mata
                string matCasaMata = "";
                if(comboE10_1MatCasaMata.SelectedIndex == 1)
                {
                    matCasaMata = "C";
                }
                else if (comboE10_1MatCasaMata.SelectedIndex == 2)
                {
                    matCasaMata = "M";
                }
                else if (comboE10_1MatCasaMata.SelectedIndex == 3)
                {
                    matCasaMata = "N";
                }
                //Observacoes
                string obs = txtE10_1Obs.Text;
                string indPreenchido = "S";
                bool sucesso = true;

                SOEF_CLASS.Escopo_10_1 Escopo10_1 = new SOEF_CLASS.Escopo_10_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                SOEF_CLASS.Escopo_Valor_Comum EscopoVlrComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                //Verifica se está cadastrando ou alterando o registro
                if (AcaoTela == "N")
                {
                    int retornoInsert = Escopo10_1.gravaEscopo_10_1(tensaoTrifasica, frequenciaHz, outraFrequencia, dadosAmbientais, normativaMapa, tipoProduto, outroProduto, umidade, tipoAeracao, tipoInstalacao, matTampaCanaleta, tipoTampaCanaleta, matCasaMata, obs, indPreenchido);
                    if(retornoInsert > 0)
                    {
                        //Verifica se já existe registro para essa solicitação. Se sim, atualiza com os valores deste escopo, se não, insere um novo registro
                        DataTable dtBuscaEscopo10_1 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if (dtBuscaEscopo10_1.Rows.Count > 0)
                        {
                            //Faz o update e grava os dados usados no Escopo 10_1
                            int retornoInsert10_1 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E10_1(tensaoTrifasica, frequenciaHz, outraFrequencia, dadosAmbientais, normativaMapa, tipoProduto, outroProduto);
                            if(retornoInsert10_1 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                        else
                        {
                            //Insere um novo registro na tabela Valor Comum
                            int retornoInsert10_1 = EscopoVlrComum.gravaEscopo_Valor_Comum_E10_1(tensaoTrifasica, frequenciaHz, outraFrequencia, dadosAmbientais, normativaMapa, tipoProduto, outroProduto);
                            if (retornoInsert10_1 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                        AcaoTela = "C";
                        btnE10_1Excluir.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro na inserção do registro. Tente novamente mais tarde.");
                    }
                }
                else
                {
                    //AcaoTela - ATUALIZAR
                    DataTable dtBuscaEscopo10_1 = Escopo10_1.getEscopo_10_1();
                    int retornoUpdate = 0;
                    if (dtBuscaEscopo10_1.Rows.Count > 0)
                    {
                        //Atualiza o Escopo 10_1 se já estiver cadastrado
                        retornoUpdate = Escopo10_1.updateEscopo_10_1(tensaoTrifasica, frequenciaHz, outraFrequencia, dadosAmbientais, normativaMapa, tipoProduto, outroProduto, umidade, tipoAeracao, tipoInstalacao, matTampaCanaleta, tipoTampaCanaleta, matCasaMata, obs, indPreenchido);
                    }
                    else
                    {
                        //Cadastra o Escopo 10_1 se ainda não existir
                        retornoUpdate = Escopo10_1.gravaEscopo_10_1(tensaoTrifasica, frequenciaHz, outraFrequencia, dadosAmbientais, normativaMapa, tipoProduto, outroProduto, umidade, tipoAeracao, tipoInstalacao, matTampaCanaleta, tipoTampaCanaleta, matCasaMata, obs, indPreenchido);
                    }                    
                    if(retornoUpdate > 0)
                    {
                        DataTable dtBuscaVCEscopo10_1 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if (dtBuscaVCEscopo10_1.Rows.Count > 0)
                        {
                            //Faz o update e grava os dados usados no Escopo 10_1
                            int retornoInsert10_1 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E10_1(tensaoTrifasica, frequenciaHz, outraFrequencia, dadosAmbientais, normativaMapa, tipoProduto, outroProduto);
                            if (retornoInsert10_1 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                        else
                        {
                            //Insere um novo registro na tabela Valor Comum
                            int retornoInsert10_1 = EscopoVlrComum.gravaEscopo_Valor_Comum_E10_1(tensaoTrifasica, frequenciaHz, outraFrequencia, dadosAmbientais, normativaMapa, tipoProduto, outroProduto);
                            if (retornoInsert10_1 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro na atualização do registro. Tente novamente mais tarde.");
                    }
                }
                //Verifica se ocorreu erro durante o processo de inserção no ESCOPO 10_1 e VALOR COMUM
                if (sucesso)
                {
                    MessageBox.Show("Registro inserido/alterado com sucesso!");
                    btnE10_1Excluir.Visible = true;
                    listaEscopo10_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Muda o STATUS da AçãoTela p/ EDIÇÂO
                    AcaoTela = "C";
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao ao inserir/alterar o registro. Por favor tente novamente ou contate o administrador do sistema.");
                }
            }

        }

        private void btnE10_1Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 10_1 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool sucesso = true;
                //Apaga os dados do Escopo 10_1
                SOEF_CLASS.Escopo_10_1 Escopo10_1 = new SOEF_CLASS.Escopo_10_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno = Escopo10_1.deleteEscopo_10_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (retorno > 0)
                {
                    //Apaga (define como NULL) os campos comuns da tabela VALOR_COMUM
                    SOEF_CLASS.Escopo_Valor_Comum EValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    int retornoUpdate = 0;
                    retornoUpdate = EValorComum.deleteEscopo_Valor_Comum_E10_1();
                    if (retornoUpdate > 0)
                    {
                        //Verifica se todos os campos do registro são nulos, se sim, apaga o registro em definitivo
                        bool DeletaRegistro = verificaRegistroValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if (DeletaRegistro)//True - Deleta o registro
                        {
                            int retornoDelete = EValorComum.deleteEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (retornoDelete <= 0)
                            {
                                sucesso = false;
                                //MessageBox.Show("Não foi possível realizar a operação completa. Por favor, verifique os dados informados e tente novamente.");
                            }
                        }
                    }
                    else
                    {
                        sucesso = false;
                    }
                }
                else
                {
                    sucesso = false;
                }
                if (sucesso)
                {
                    MessageBox.Show("Registro excluído com sucesso!");
                    btnE10_1Excluir.Visible = false;
                    //checkEscopo10.Checked = false;
                    //checkEscopo10.Enabled = true;
                    listaEscopo10_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o registro. Por favor, contate o suporte do sistema e tente novamente.");
                }
            }
        }

        private void btn10_2Salvar_Click(object sender, EventArgs e)
        {
            string erros = "";
            if(combo10_2DadosAmbientais.SelectedIndex == 0)
            {
                erros += "O campo Dados Ambientais deve ser preenchido.\n";
            }
            if(combo10_2Produto.SelectedIndex == 0)
            {
                erros += "O campo Tipo de Produto deve ser preenchido.\n";
            }
            else if(combo10_2Produto.SelectedIndex == 5)
            {
                if (string.IsNullOrEmpty(txt10_2OutroProd.Text))
                {
                    erros += "O campo Outro Produto deve ser preenchido.\n";
                }
            }
            if(!check10_2Silos.Checked && !check10_2Armazem.Checked)
            {
                erros += "É obrigatório definir um local de instalação como Silo ou Armazém.\n";
            }
            //Validação campos SILOS
            if (check10_2Silos.Checked)
            {
                if(combo10_2CapacidadeSilo.SelectedIndex == 0)
                {
                    erros += "O campo Capacidade Silo deve ser preenchido.\n";
                }
                else if(combo10_2CapacidadeSilo.SelectedIndex == 1 || combo10_2CapacidadeSilo.SelectedIndex == 2 || combo10_2CapacidadeSilo.SelectedIndex == 3 || combo10_2CapacidadeSilo.SelectedIndex == 4)
                {
                    if(!radioPenduloCentralS.Checked && !radioPenduloCentralN.Checked)
                    {
                        erros += "O campo Considerar Suporte Pêndulo Central deve ser preenchido.\n";
                    }
                }
                else if(combo10_2CapacidadeSilo.SelectedIndex == 6)
                {
                    if (string.IsNullOrEmpty(text10_2CaractisticaEspalhadorS.Text))
                    {
                        erros += "O campo Características Espalhador do silo deve ser preenchido.\n";
                    }
                }
            }
            //Validação campos ARMAZÉM
            if (check10_2Armazem.Checked)
            {
                if(combo10_2Transportadores.SelectedIndex == 0)
                {
                    erros += "O campo Quantos Transportador(es) Tem deve ser preenchido.\n";
                }
                if (combo10_2CapacidadeArmazem.SelectedIndex == 0)
                {
                    erros += "O campo Capacidade do Armazém deve ser preenchido.\n";
                }
                else if (combo10_2CapacidadeArmazem.SelectedIndex == 6)
                {
                    if (string.IsNullOrEmpty(text10_2CaractisticaEspalhadorA.Text))
                    {
                        erros += "O campo Características Espalhador do armazém deve ser preenchido.\n";
                    }
                }
            }
            //Verifica se há erros de validação
            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Painel de erros:\n" + erros);
            }
            else
            {
                //Variáveis da tabela
                string DadosAmbientais = "";
                string TipoProduto = "";
                string DescOutroProduto = "";
                string InstalArmazem = "";
                string InstalSilo = "";
                string CapacidadeSilo = "";
                string SuportePendulo = "";
                string CapacidadeArmazem = "";
                string QtdTransportador = "";
                string Obs = "";
                string IndPreenchido = "S";
                string CaracEspalhadorSil = "";
                string CaracEspalhadorArm = "";
                bool sucesso = true;

                //Dados Ambientais
                if (combo10_2DadosAmbientais.SelectedIndex == 1)
                {
                    DadosAmbientais = "U";
                }
                else if (combo10_2DadosAmbientais.SelectedIndex == 2)
                {
                    DadosAmbientais = "M";
                }
                else if (combo10_2DadosAmbientais.SelectedIndex == 3)
                {
                    DadosAmbientais = "C";
                }
                else if (combo10_2DadosAmbientais.SelectedIndex == 4)
                {
                    DadosAmbientais = "N";
                }

                //Tipo Produto
                if(combo10_2Produto.SelectedIndex == 1)
                {
                    TipoProduto = "S";
                }
                else if (combo10_2Produto.SelectedIndex == 2)
                {
                    TipoProduto = "M";
                }
                else if (combo10_2Produto.SelectedIndex == 3)
                {
                    TipoProduto = "T";
                }
                else if (combo10_2Produto.SelectedIndex == 4)
                {
                    TipoProduto = "A";
                }
                else
                {
                    TipoProduto = "O";
                    DescOutroProduto = txt10_2OutroProd.Text;
                }
                //Local de Instalação
                if (check10_2Silos.Checked)
                {
                    InstalSilo = "S";
                    //Capacidade Silo
                    if(combo10_2CapacidadeSilo.SelectedIndex == 1)
                    {
                        CapacidadeSilo = "60";
                    }
                    else if (combo10_2CapacidadeSilo.SelectedIndex == 2)
                    {
                        CapacidadeSilo = "120";
                    }
                    else if (combo10_2CapacidadeSilo.SelectedIndex == 3)
                    {
                        CapacidadeSilo = "270";
                    }
                    else if (combo10_2CapacidadeSilo.SelectedIndex == 4)
                    {
                        CapacidadeSilo = "320";
                    }
                    else if (combo10_2CapacidadeSilo.SelectedIndex == 5)
                    {
                        CapacidadeSilo = "500";
                    }
                    else if (combo10_2CapacidadeSilo.SelectedIndex == 6)
                    {
                        CapacidadeSilo = "999";
                    }
                    //Pendulo Central
                    if (radioPenduloCentralS.Checked)
                    {
                        SuportePendulo = "S";
                    }
                    else if (radioPenduloCentralN.Checked)
                    {
                        SuportePendulo = "N";
                    }
                }
                else
                {
                    InstalSilo = "N";
                    //CapacidadeSilo = null;

                }


                if (check10_2Armazem.Checked)
                {
                    InstalArmazem = "S";
                    //Capacidade Armazém
                   if(combo10_2CapacidadeArmazem.SelectedIndex == 1)
                    {
                        CapacidadeArmazem = "60";
                    }
                    else if (combo10_2CapacidadeArmazem.SelectedIndex == 2)
                    {
                        CapacidadeArmazem = "120";
                    }
                    else if (combo10_2CapacidadeArmazem.SelectedIndex == 3)
                    {
                        CapacidadeArmazem = "270";
                    }
                    else if (combo10_2CapacidadeArmazem.SelectedIndex == 4)
                    {
                        CapacidadeArmazem = "320";
                    }
                    else if (combo10_2CapacidadeArmazem.SelectedIndex == 5)
                    {
                        CapacidadeArmazem = "500";
                    }
                    else if (combo10_2CapacidadeArmazem.SelectedIndex == 6)
                    {
                        CapacidadeArmazem = "999";
                    }
                    //Qtd Transportador
                    QtdTransportador = Convert.ToString(combo10_2Transportadores.SelectedIndex);
                }
                else
                {
                    InstalArmazem = "N";
                    //QtdTransportador = null;
                    //CapacidadeArmazem = null;
                }
                //Espalhador Silo
                CaracEspalhadorSil = text10_2CaractisticaEspalhadorS.Text;
                //Espalhador Armazém
                CaracEspalhadorArm = text10_2CaractisticaEspalhadorA.Text;
                //Obs
                Obs = txt10_2Obs.Text;

                SOEF_CLASS.Escopo_10_2 Escopo10_2 = new SOEF_CLASS.Escopo_10_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                SOEF_CLASS.Escopo_Valor_Comum EscopoVlrComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                //Verifica se está cadastrando ou alterando o registro
                if(AcaoTela == "N")
                {
                    int retornoInsert = Escopo10_2.gravaEscopo_10_2(DadosAmbientais, TipoProduto, DescOutroProduto, InstalSilo, InstalArmazem, CapacidadeSilo, SuportePendulo, CapacidadeArmazem, QtdTransportador, Obs, IndPreenchido, CaracEspalhadorSil, CaracEspalhadorArm);
                    if(retornoInsert > 0)
                    {
                        //Verifica valores comuns desta solicitação
                        DataTable dtVlrComum10_2 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if(dtVlrComum10_2.Rows.Count > 0)
                        {
                            //Se existe, faz o update dos Valores Comuns do Escopo 10_2
                            int retornoInsertVC10_2 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E10_2(DadosAmbientais, TipoProduto, DescOutroProduto);
                            if(retornoInsertVC10_2 <= 0)
                            {
                                sucesso = false;
                            }                            
                        }
                        else
                        {
                            //Insere um novo registro na tabela Valores Comuns
                            int retornoInsertVC10_2 = EscopoVlrComum.gravaEscopo_Valor_Comum_E10_2(DadosAmbientais, TipoProduto, DescOutroProduto);
                            if(retornoInsertVC10_2 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                        AcaoTela = "C";
                        btn10_2Excluir.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro na inserção do registro. Tente novamente mais tarde.");
                    }
                }
                else
                {
                    //AcaoTela - ATUALIZAR
                    DataTable dtBuscaEscopo10_2 = Escopo10_2.getEscopo_10_2();
                    int retornoUpdate;
                    if (dtBuscaEscopo10_2.Rows.Count > 0)
                    {
                        //Atualiza o Escopo 10_1 se já estiver cadastrado
                        retornoUpdate = Escopo10_2.updateEscopo_10_2(DadosAmbientais, TipoProduto, DescOutroProduto, InstalSilo, InstalArmazem, CapacidadeSilo, SuportePendulo, CapacidadeArmazem, QtdTransportador, Obs, IndPreenchido, CaracEspalhadorSil, CaracEspalhadorArm);
                    }
                    else
                    {
                        //Cadastra o Escopo 10_1 se ainda não existir
                        retornoUpdate = Escopo10_2.gravaEscopo_10_2(DadosAmbientais, TipoProduto, DescOutroProduto, InstalSilo, InstalArmazem, CapacidadeSilo, SuportePendulo, CapacidadeArmazem, QtdTransportador, Obs, IndPreenchido, CaracEspalhadorSil, CaracEspalhadorArm);
                    }
                    if(retornoUpdate > 0)
                    {
                        //Verifica se existe registro Valor Comum
                        DataTable dtBuscaVCEscopo10_2 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if(dtBuscaVCEscopo10_2.Rows.Count > 0)
                        {
                            //Faz o update e grava os dados usados no Escopo 10_2
                            int retornoInsert10_2 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E10_2(DadosAmbientais, TipoProduto, DescOutroProduto);
                            if (retornoInsert10_2 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                        else
                        {
                            //Insere um novo registro na tabela Valor Comum
                            int retornoInsert10_2 = EscopoVlrComum.gravaEscopo_Valor_Comum_E10_2(DadosAmbientais, TipoProduto, DescOutroProduto);
                            if (retornoInsert10_2 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro na atualização do registro. Tente novamente mais tarde.");
                    }
                }
                //Verifica se ocorreu erro durante o processo de inserção no ESCOPO 10_2 e VALOR COMUM
                if (sucesso)
                {
                    MessageBox.Show("Registro inserido/alterado com sucesso!");
                    btn10_2Excluir.Visible = true;                   
                    listaEscopo10_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Muda o STATUS da AçãoTela p/ EDIÇÂO
                    AcaoTela = "C";
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao ao inserir/alterar o registro. Por favor tente novamente ou contate o administrador do sistema.");
                }
            }

        }

        private void combo10_2Produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo10_2Produto.SelectedIndex == 5)
            {
                txt10_2OutroProd.Enabled = true;
            }
            else
            {
                txt10_2OutroProd.Enabled = false;
            }
        }

        private void check10_2Silos_CheckedChanged(object sender, EventArgs e)
        {
            if (check10_2Silos.Checked)
            {
                gBox10_2Silo.Enabled = true;
            }
            else
            {
                combo10_2CapacidadeSilo.SelectedIndex = 0;
                msgPenduloCentral.Visible = false;
                radioPenduloCentralN.Checked = false;
                radioPenduloCentralS.Checked = false;
                text10_2CaractisticaEspalhadorS.Text = "";
                gBox10_2Silo.Enabled = false; ;
            }
        }

        private void check10_2Armazem_CheckedChanged(object sender, EventArgs e)
        {
            if (check10_2Armazem.Checked)
            {
                gBox10_2Armazem.Enabled = true;
            }
            else
            {
                combo10_2CapacidadeArmazem.SelectedIndex = 0;
                combo10_2Transportadores.SelectedIndex = 0;
                radioPenduloCentralN.Checked = false;
                radioPenduloCentralS.Checked = false;
                text10_2CaractisticaEspalhadorA.Text = "";
                gBox10_2Armazem.Enabled = false; ;
            }
        }

        private void combo10_2CapacidadeSilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo10_2CapacidadeSilo.SelectedIndex == 6)
            {
                label117.Visible = true;
                text10_2CaractisticaEspalhadorS.Visible = true;
            }
            else
            {
                label117.Visible = false;
                text10_2CaractisticaEspalhadorS.Text = "";
                text10_2CaractisticaEspalhadorS.Visible = false;
            }
            
            if(combo10_2CapacidadeSilo.SelectedIndex == 1 || combo10_2CapacidadeSilo.SelectedIndex == 2 || combo10_2CapacidadeSilo.SelectedIndex == 3 || combo10_2CapacidadeSilo.SelectedIndex == 4)
            {
                label109.Visible = true;
                radioPenduloCentralS.Checked = false;
                radioPenduloCentralN.Checked = false;
                radioPenduloCentralS.Visible = true;
                radioPenduloCentralN.Visible = true;                
            }
            else
            {
                label109.Visible = false;
                radioPenduloCentralS.Checked = false;
                radioPenduloCentralN.Checked = false;
                radioPenduloCentralS.Visible = false;
                radioPenduloCentralN.Visible = false;
            }
            if(combo10_2CapacidadeSilo.SelectedIndex == 5)
            {
                msgPenduloCentral.Visible = true;
            }
            else
            {
                msgPenduloCentral.Visible = false;
            }
        }

        private void combo10_2CapacidadeArmazem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo10_2CapacidadeArmazem.SelectedIndex == 6)
            {
                label110.Visible = true;
                text10_2CaractisticaEspalhadorA.Visible = true;
            }
            else
            {
                label110.Visible = false;
                text10_2CaractisticaEspalhadorA.Text = "";
                text10_2CaractisticaEspalhadorA.Visible = false;
            }
        }

        private void btn10_2Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 10_2 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool sucesso = true;
                //Apaga os dados do Escopo 10_2
                SOEF_CLASS.Escopo_10_2 Escopo10_2 = new SOEF_CLASS.Escopo_10_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno = Escopo10_2.deleteEscopo_10_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (retorno > 0)
                {
                    //Apaga (define como NULL) os campos comuns da tabela VALOR_COMUM
                    SOEF_CLASS.Escopo_Valor_Comum EValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    int retornoUpdate = 0;
                    retornoUpdate = EValorComum.deleteEscopo_Valor_Comum_E10_2();
                    if (retornoUpdate > 0)
                    {
                        //Verifica se todos os campos do registro são nulos, se sim, apaga o registro em definitivo
                        bool DeletaRegistro = verificaRegistroValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if (DeletaRegistro)//True - Deleta o registro
                        {
                            int retornoDelete = EValorComum.deleteEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (retornoDelete <= 0)
                            {
                                sucesso = false;
                                //MessageBox.Show("Não foi possível realizar a operação completa. Por favor, verifique os dados informados e tente novamente.");
                            }
                        }
                    }
                    else
                    {
                        sucesso = false;
                    }
                }
                else
                {
                    sucesso = false;
                }
                if (sucesso)
                {
                    MessageBox.Show("Registro excluído com sucesso!");
                    btn10_2Excluir.Visible = false;
                    listaEscopo10_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //checkEscopo10.Checked = false;
                    //checkEscopo10.Enabled = true;
                    // Fazer uma função que verifica se algum dos escopos 10_1, 2, 3 ou 4 estão preenchidos, habilita o check na tela dos escopos
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o registro. Por favor, contate o suporte do sistema e tente novamente.");
                }
            }
        }

        private void combo10_3Freq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo10_3Freq.SelectedIndex == 3)
            {
                txt10_3OutraFreq.Enabled = true;
            }
            else
            {
                txt10_3OutraFreq.Text = "";
                txt10_3OutraFreq.Enabled = false;
            }
        }

        private void combo10_3Local_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (combo10_3Local.SelectedIndex == 1 || combo10_3Local.SelectedIndex == 2 || combo10_3Local.SelectedIndex == 3)
            {
                txt10_3Tag.Enabled = true;
                radio10_3ProjetoN.Enabled = true;
                radio10_3ProjetoS.Enabled = true;
                txt10_3Local.Text = "";
                txt10_3Local.Enabled = false;
            }
            else if(combo10_3Local.SelectedIndex == 4)
            {
                txt10_3Local.Enabled = true;
                txt10_3Tag.Enabled = true;
                radio10_3ProjetoN.Enabled = true;
                radio10_3ProjetoS.Enabled = true;
            }
            else
            {
                txt10_3Local.Text = "";
                txt10_3Local.Enabled = false;
                txt10_3Tag.Text = "";
                txt10_3Tag.Enabled = false;
                radio10_3ProjetoN.Checked = false;
                radio10_3ProjetoN.Enabled = false;
                radio10_3ProjetoS.Checked = false;
                radio10_3ProjetoS.Enabled = false;
            }
        }

        private void btn10_3Salvar_Click(object sender, EventArgs e)
        {
            string erros = "";

            //Verificar se já foi cadatrado a tabela de Renovadores de Ar

            if (combo10_3Tensao.SelectedIndex == 0)
            {
                erros += "Informe a Tensão Trifásica\n";
            }
            if (combo10_3Freq.SelectedIndex == 0)
            {
                erros += "Informe a Frequência\n";
            }
            else if (combo10_3Freq.SelectedIndex == 3)
            {
                if (string.IsNullOrEmpty(txt10_3OutraFreq.Text))
                {
                    erros += "Informe o campo Outra Frequência\n";
                }
            }
            if (combo10_3DadosAmbientais.SelectedIndex == 0)
            {
                erros += "Informe o campo Dados Ambientais";
            }

            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Painel de erros:\n" + erros);
            }
            else
            {
                string TensaoTrifasica = "";
                string Frequencia = "";
                string OutraFrequencia = "";
                string DadosAmbientais = "";
                string Obs;
                bool sucesso = true;

                //Validação campos
                TensaoTrifasica = combo10_3Tensao.SelectedIndex.ToString();
                Frequencia = combo10_3Freq.SelectedIndex.ToString();
                OutraFrequencia = txt10_3OutraFreq.Text;
                //Dados Ambientais
                if (combo10_3DadosAmbientais.SelectedIndex == 1)
                {
                    DadosAmbientais = "U";
                }
                else if (combo10_3DadosAmbientais.SelectedIndex == 2)
                {
                    DadosAmbientais = "M";
                }
                else if (combo10_3DadosAmbientais.SelectedIndex == 3)
                {
                    DadosAmbientais = "C";
                }
                else if (combo10_3DadosAmbientais.SelectedIndex == 4)
                {
                    DadosAmbientais = "N";
                }
                Obs = txt10_3Obs.Text;

                //Verificar se a tabela Renovadores Ar está preenchida
                SOEF_CLASS.Escopo_10_3 Escopo10_3 = new SOEF_CLASS.Escopo_10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                DataTable dtRetorno = Escopo10_3.getRenovadoresAr(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if(dtRetorno.Rows.Count > 0)
                {
                    //Prossegue com a inserção dos dados
                    SOEF_CLASS.Escopo_Valor_Comum EscopoVlrComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Verifica se está cadastrando ou alterando o registro

                    if (AcaoTela == "N")
                    {
                        int retornoInsert = Escopo10_3.gravaEscopo_10_3(TensaoTrifasica, Frequencia, OutraFrequencia, DadosAmbientais, Obs, "S");
                        if (retornoInsert > 0)
                        {
                            //Verifica valores comuns desta solicitação
                            DataTable dtVlrComum10_3 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (dtVlrComum10_3.Rows.Count > 0)
                            {
                                //Se existe, faz o update dos Valores Comuns do Escopo 10_2
                                int retornoInsertVC10_3 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E10_3(DadosAmbientais, TensaoTrifasica, Frequencia, OutraFrequencia);
                                if (retornoInsertVC10_3 <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                            else
                            {
                                //Insere um novo registro na tabela Valores Comuns
                                int retornoInsertVC10_3 = EscopoVlrComum.gravaEscopo_Valor_Comum_E10_3(DadosAmbientais, TensaoTrifasica, Frequencia, OutraFrequencia);
                                if (retornoInsertVC10_3 <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                            AcaoTela = "C";
                            btn10_3Excluir.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro na inserção do registro. Tente novamente mais tarde.");
                        }
                    }
                    else
                    {
                        //AcaoTela - ATUALIZAR
                        DataTable dtBuscaEscopo10_3 = Escopo10_3.getEscopo_10_3();
                        int retornoUpdate;
                        if (dtBuscaEscopo10_3.Rows.Count > 0)
                        {
                            //Atualiza o Escopo 10_3 se já estiver cadastrado
                            retornoUpdate = Escopo10_3.updateEscopo_10_3(TensaoTrifasica, Frequencia, OutraFrequencia, DadosAmbientais, Obs, "S");
                        }
                        else
                        {
                            //Cadastra o Escopo 10_3 se ainda não existir
                            retornoUpdate = Escopo10_3.gravaEscopo_10_3(TensaoTrifasica, Frequencia, OutraFrequencia, DadosAmbientais, Obs, "S");
                        }
                        if (retornoUpdate > 0)
                        {
                            //Verifica se existe registro Valor Comum
                            DataTable dtBuscaVCEscopo10_3 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (dtBuscaVCEscopo10_3.Rows.Count > 0)
                            {
                                //Faz o update e grava os dados usados no Escopo 10_3
                                int retornoInsert10_3 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E10_3(DadosAmbientais, TensaoTrifasica, Frequencia, OutraFrequencia);
                                if (retornoInsert10_3 <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                            else
                            {
                                //Insere um novo registro na tabela Valor Comum
                                int retornoInsert10_3 = EscopoVlrComum.gravaEscopo_Valor_Comum_E10_3(DadosAmbientais, TensaoTrifasica, Frequencia, OutraFrequencia);
                                if (retornoInsert10_3 <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro na atualização do registro. Tente novamente mais tarde.");
                        }
                    }

                    if (sucesso)
                    {
                        MessageBox.Show("Registro inserido/alterado com sucesso!");
                        btn10_3Excluir.Visible = true;
                        listaEscopo10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        //Muda o STATUS da AçãoTela p/ EDIÇÂO
                        AcaoTela = "C";
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao ao inserir/alterar o registro. Por favor tente novamente ou contate o administrador do sistema.");
                    }
                }
                else
                {
                    MessageBox.Show("A tabela de renovadores de Ar não foi preenchida. Preencha a tabela de renovadores para poder gravar o escopo.");
                }

            }

        }

        private void btn10_3Renovadores_Click(object sender, EventArgs e)
        {
            string erros = "";

            
            if (combo10_3Local.SelectedIndex == 0)
            {
                erros += "Selecione um local nas opções disponíveis ou descreva um local no campo disponível para este fim caso seja um local diferente dos disponíveis.";
            }
            else
            {
                if (radio10_3ProjetoS.Checked == false && radio10_3ProjetoN.Checked == false)
                {
                    erros += "O campo Tem no Projeto, da montagem da relação de Renovadores deve ser informado.";
                }
            }
            if(!radio10_3ProjetoS.Checked && !radio10_3ProjetoN.Checked)
            {
                erros += "Informe o campo Tem no Projeto\n";
            }

            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Painel de erros:\n" + erros);
            }
            else
            {
                //Validando dados
                string Local = ""; //T, S, P, D
                string Tag = "";
                string RenovadorProjeto = "";
                string Comprimento = "";
                string Largura = "";
                string Altura = "";
                int sequencia = 0;

                //Local
                if (combo10_3Local.SelectedIndex == 1)
                {
                    Local = "T";
                }
                else if (combo10_3Local.SelectedIndex == 2)
                {
                    Local = "S";
                }
                else if (combo10_3Local.SelectedIndex == 3)
                {
                    Local = "P";
                }
                else if (combo10_3Local.SelectedIndex == 4)
                {
                    Local = txt10_3Local.Text;
                }                
                //TAG
                Tag = txt10_3Tag.Text;
                //Tem Projeto
                if (radio10_3ProjetoS.Checked)
                {
                    RenovadorProjeto = "S";
                }
                else if (radio10_3ProjetoN.Checked)
                {
                    RenovadorProjeto = "N";
                }
                //Comprimento
                Comprimento = txt10_3Compr.Text;
                //Largura
                Largura = txt10_3Largura.Text;
                //Altura 
                Altura = txt10_3Altura.Text;


                SOEF_CLASS.Escopo_10_3 Escopo10_3 = new SOEF_CLASS.Escopo_10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                sequencia = Escopo10_3.getSequencia(this.numero_solic.ToString(), this.NumRevisaoSolic) + 1; //Última sequência inserida na tabela
                int retorno = Escopo10_3.gravaRenovadoresAr(sequencia.ToString(), Local, Tag, RenovadorProjeto, Comprimento, Largura, Altura);
                if(retorno > 0)
                {
                    //listaEscopo10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    dgv10_3.DataSource = Escopo10_3.getRenovadoresAr(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    MessageBox.Show("Registro inserido com sucesso!");
                }
            }
        }

        private void checkCabOutro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCabOutro.Checked)
            {
                label145.Visible = true;
                txtCabDescNecessidade.Visible = true;
            }
            else
            {
                txtCabDescNecessidade.Text = "";
                label145.Visible = false;
                txtCabDescNecessidade.Visible = false;
            }
        }

        private void radio10_3ProjetoN_CheckedChanged(object sender, EventArgs e)
        {
            if (radio10_3ProjetoN.Checked)
            {
                txt10_3Altura.Enabled = true;
                txt10_3Compr.Enabled = true;
                txt10_3Largura.Enabled = true;
            }
            else
            {
                txt10_3Altura.Enabled = false;
                txt10_3Compr.Enabled = false;
                txt10_3Largura.Enabled = false;
            }
        }

        private void dgv10_3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                SOEF_CLASS.Escopo_10_3 Escopo10_3 = new SOEF_CLASS.Escopo_10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno = Escopo10_3.deleteRenovadoresAr(dgv10_3.CurrentRow.Cells[1].Value.ToString(), dgv10_3.CurrentRow.Cells[2].Value.ToString(), dgv10_3.CurrentRow.Cells[3].Value.ToString());
                if(retorno > 0)
                {
                    dgv10_3.DataSource = Escopo10_3.getRenovadoresAr(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    MessageBox.Show("Registro apagado com sucesso!");
                }
            }

        }

        private void btn10_3Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 10_3 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool sucesso = true;
                //Apaga os dados do Escopo 10_3
                SOEF_CLASS.Escopo_10_3 Escopo10_3 = new SOEF_CLASS.Escopo_10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno01 = Escopo10_3.deleteRenovadoresAr(this.numero_solic.ToString(), this.NumRevisaoSolic, null);
                if(retorno01 > 0)
                {
                    int retorno = Escopo10_3.deleteEscopo_10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if (retorno > 0)
                    {
                        //Apaga (define como NULL) os campos comuns da tabela VALOR_COMUM
                        SOEF_CLASS.Escopo_Valor_Comum EValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        int retornoUpdate = 0;
                        retornoUpdate = EValorComum.deleteEscopo_Valor_Comum_E10_3();
                        if (retornoUpdate > 0)
                        {
                            //Verifica se todos os campos do registro são nulos, se sim, apaga o registro em definitivo
                            bool DeletaRegistro = verificaRegistroValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (DeletaRegistro)//True - Deleta o registro
                            {
                                int retornoDelete = EValorComum.deleteEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                if (retornoDelete <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                        }
                        else
                        {
                            sucesso = false;
                        }
                    }
                    else
                    {
                        sucesso = false;
                    }
                    if (sucesso)
                    {
                        MessageBox.Show("Registro excluído com sucesso!");
                        btn10_3Excluir.Visible = false;
                        listaEscopo10_3(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        dgv10_3.DataSource = Escopo10_3.getRenovadoresAr(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        //checkEscopo10.Checked = false;
                        //checkEscopo10.Enabled = true;
                        // Fazer uma função que verifica se algum dos escopos 10_1, 2, 3 ou 4 estão preenchidos, habilita o check na tela dos escopos
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao excluir o registro. Por favor, contate o suporte do sistema e tente novamente.");
                    }
                }
                else
                {
                    sucesso = false;
                }
                
            }
        }

        private void combo10_4MatTampa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo10_4MatTampa.SelectedIndex == 0)
            {
                txt10_4QtdTampa.Enabled = false;
                txt10_4Qtd.Text = "";
                txt10_4Qtd.Enabled = false;
                combo10_4TipoTampa.SelectedIndex = 0;
                combo10_4TipoTampa.Enabled = false;
                txt10_4Comprimento.Text = "";
                txt10_4Comprimento.Enabled = false;
                txt10_4Largura.Text = "";
                txt10_4Largura.Enabled = false;
                btn10_4GravaTampa.Enabled = false;
            }
            if(combo10_4MatTampa.SelectedIndex == 1)
            {
                //Mostra opções 1
                txt10_4QtdTampa.Enabled = true;
                txt10_4Qtd.Text = "";
                txt10_4Qtd.Enabled = false;
                txt10_4Comprimento.Text = "";
                txt10_4Comprimento.Enabled = false;
                combo10_4TipoTampa.SelectedIndex = 0;
                combo10_4TipoTampa.Enabled = false;
                txt10_4Largura.Text = "";
                txt10_4Largura.Enabled = false;
                btn10_4GravaTampa.Enabled = false;
            }

            if(combo10_4MatTampa.SelectedIndex == 2)
            {
                txt10_4QtdTampa.Text = "";
                txt10_4QtdTampa.Enabled = false;
                txt10_4Qtd.Enabled = true;
                txt10_4Comprimento.Enabled = true;
                combo10_4TipoTampa.SelectedIndex = 0;
                combo10_4TipoTampa.Enabled = true;
                txt10_4Largura.Enabled = true;
                btn10_4GravaTampa.Enabled = true;
            }
        }

        private void btn10_4Salvar_Click(object sender, EventArgs e)
        {
            string erros = "";
            if(combo10_4MatTampa.SelectedIndex == 0)
            {
                erros += "O campo Qual Material da Tampa deve ser preenchido.\n";
            }
            else
            {
                SOEF_CLASS.Escopo_10_4 Escopo10_4 = new SOEF_CLASS.Escopo_10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                string matTampa = "";
                string qtdTampas;
                string obs;
                string indPre = "S";

                if (combo10_4MatTampa.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(txt10_4QtdTampa.Text))
                    {
                        erros += "O campo Quantidade Tampas deve ser preenchido.\n";
                    }
                    else
                    {
                        matTampa = "P";
                        qtdTampas = txt10_4QtdTampa.Text;
                        obs = txt10_4Obs.Text;
                        if(AcaoTela == "N")
                        {
                            int RIEscopo = Escopo10_4.gravaEscopo_10_4(matTampa, qtdTampas, obs, indPre);
                            if(RIEscopo > 0)
                            {
                                MessageBox.Show("Escopo 10_4 inserido com sucesso!");
                                listaEscopo10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                AcaoTela = "C";
                                btn10_4Excluir.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Ocorreu um erro na inserção do registro!");
                            }
                        }
                        else
                        {
                            //Verifica se não tem registro na tabela
                            int RIEscopo = 0;
                            DataTable dt1 = Escopo10_4.getEscopo_10_4();
                            if(dt1.Rows.Count > 0)
                            {
                                //Verificar se tem registro na ORC_TAMPA_ESCOPO, se tiver, apagar o registro antes de fazer o update
                                DataTable dtRetorno = Escopo10_4.getTampaEscopo("10_4", null);
                                if(dtRetorno.Rows.Count > 0)
                                {
                                    //Apaga o registro da tabela DOM_SOLIC_ORC_TAMPA_ESCOPO antes de atualizar o ESCOPO 10_4
                                    int rDelete = Escopo10_4.deleteTampaEscopo(this.numero_solic.ToString(), this.NumRevisaoSolic, "10_4", null);
                                    if(rDelete < 0)
                                    {
                                        MessageBox.Show("Não foi possível apagar o registro da DOM_SOLIC_ORC_TAMPA_ESCOPO. Tente novamente.");
                                    }
                                    else
                                    {
                                        //Faz a atualização do ESCOPO 10_4
                                        RIEscopo = Escopo10_4.updateEscopo_10_4(matTampa, qtdTampas, obs, indPre);
                                    }
                                }
                            }
                            else
                            {
                                RIEscopo = Escopo10_4.gravaEscopo_10_4(matTampa, qtdTampas, obs, indPre);
                            }                            
                            if(RIEscopo > 0)
                            {
                                MessageBox.Show("Escopo 10.4 atualizado com sucesso!");
                                listaEscopo10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            }
                            else
                            {
                                MessageBox.Show("Ocorreu um erro na atualização do escopo!");
                            }
                        }
                    }
                }
                else if (combo10_4MatTampa.SelectedIndex == 2)
                {
                    //Verifica se foi preenchido a tabela de tampas
                    DataTable dt = Escopo10_4.getTampaEscopo("10_4", null);
                    if (dt.Rows.Count <= 0)
                    {
                        MessageBox.Show("Para tampa metálica é obrigatório preencher a tabela de tampas. Preencha a tabela de tampas.");
                    }
                    else
                    {
                        matTampa = "M";
                        qtdTampas = txt10_4QtdTampa.Text;
                        obs = txt10_4Obs.Text;
                        if (AcaoTela == "N")
                        {
                            int RIEscopo = Escopo10_4.gravaEscopo_10_4(matTampa, qtdTampas, obs, indPre);
                            if (RIEscopo > 0)
                            {
                                MessageBox.Show("Registro inserido com sucesso!");
                                listaEscopo10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                AcaoTela = "C";
                                btn10_4Excluir.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Ocorreu um erro na inserção do registro!");
                            }
                        }
                        else
                        {
                            int RIEscopo = 0;
                            DataTable dt1 = Escopo10_4.getEscopo_10_4();
                            if (dt1.Rows.Count > 0)
                            {
                                RIEscopo = Escopo10_4.updateEscopo_10_4(matTampa, qtdTampas, obs, indPre);
                            }
                            else
                            {
                                RIEscopo = Escopo10_4.gravaEscopo_10_4(matTampa, qtdTampas, obs, indPre);
                            }
                            if (RIEscopo > 0)
                            {
                                MessageBox.Show("Escopo 10.4 gravado com sucesso!");
                                listaEscopo10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            }
                            else
                            {
                                MessageBox.Show("Ocorreu um erro na atualização do escopo!");
                            }
                        }
                    }
                }                
            }   

            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Painel de erros:\n" + erros);
            }
            else
            {
                //Continua com a validação dos dados e insere no banco
                //Variaveis Escopo 10_4
                string MatTampa = "";
                string Quantidade = "";
                string Observacoes = "";
                string IndPreenchido = "S";

                if (combo10_4MatTampa.SelectedIndex == 1)
                {
                    MatTampa = "P";
                }
                else if (combo10_4MatTampa.SelectedIndex == 2)
                {
                    MatTampa = "M";
                }
                Quantidade = txt10_4QtdTampa.Text;
                Observacoes = txt10_4Obs.Text;

            }
        }

        private void btn10_4GravaTampa_Click(object sender, EventArgs e)
        {
            string erros = "";
            if (string.IsNullOrEmpty(txt10_4Qtd.Text))
            {
                erros += "O campo Quantidade deve ser preenchido.\n";
            }
            if (string.IsNullOrEmpty(txt10_4Comprimento.Text))
            {
                erros += "O campo Comprimento (mm) deve ser preenchido.\n";
            }
            if (string.IsNullOrEmpty(txt10_4Largura.Text))
            {
                erros += "O campo Largura (mm) deve ser preenchido.\n";
            }
            if(combo10_4TipoTampa.SelectedIndex == 0)
            {
                erros += "O campo Tipo de Tampa deve ser preenchido.\n";
            }

            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Painel de erros:\n" + erros);
            }
            else
            {
                //Variáveis Tampa Escopo
                string Escopo = "";
                string Seq = "";
                string Qtd = "";
                string TipoTampa = "";
                string Comprimento = "";
                string Largura = "";
                int sequencia = 0;               
                Escopo = "10_4";
                Qtd = txt10_4Qtd.Text;
                if(combo10_4TipoTampa.SelectedIndex == 1)
                {
                    TipoTampa = "P";
                }
                else
                {
                    TipoTampa = "O";
                }
                Comprimento = txt10_4Comprimento.Text;
                Largura = txt10_4Largura.Text;

                try
                {
                    SOEF_CLASS.Escopo_10_4 Escopo10_4 = new SOEF_CLASS.Escopo_10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    sequencia = Escopo10_4.getSequencia(this.numero_solic.ToString(), this.NumRevisaoSolic) + 1; //Última sequência inserida na tabela
                    int retorno = Escopo10_4.gravaTampaEscopo10_4(Escopo, sequencia.ToString(), Qtd, TipoTampa, Comprimento, Largura);
                    if (retorno > 0)
                    {
                        dgv10_4Tampa.DataSource = Escopo10_4.getTampaEscopo("10_4", sequencia.ToString());
                        MessageBox.Show("Registro inserido com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível inserir registro Tampa Escopo");
                    }
                }
                catch (Exception)
                {
                    throw;
                }               
            }
        }

        private void dgv10_4Tampa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                SOEF_CLASS.Escopo_10_4 Escopo10_4 = new SOEF_CLASS.Escopo_10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);

                int retorno = Escopo10_4.deleteTampaEscopo(dgv10_4Tampa.CurrentRow.Cells[1].Value.ToString(), dgv10_4Tampa.CurrentRow.Cells[2].Value.ToString(), "10_4", dgv10_4Tampa.CurrentRow.Cells[3].Value.ToString());
                if (retorno > 0)
                {
                    dgv10_4Tampa.DataSource = Escopo10_4.getTampaEscopo("10_4", null);
                    MessageBox.Show("Registro apagado com sucesso!");
                }
            }
        }

        private void btn10_4Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 10_4 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SOEF_CLASS.Escopo_10_4 Escopo10_4 = new SOEF_CLASS.Escopo_10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                bool erros = false;
                //Verifica se existe registro na DOM_SOLIC_ORC_TAMPA_ESCOPO
                DataTable dtTampaEscopo = Escopo10_4.getTampaEscopo("10_4", null);
                if(dtTampaEscopo.Rows.Count > 0)
                {
                    //Deleta os registros da TAMPA_ESCOPO
                    int retTampaEscopo = Escopo10_4.deleteTampaEscopo(this.numero_solic.ToString(), this.NumRevisaoSolic, "10_4", null);
                    if(retTampaEscopo <= 0)
                    {
                        erros = true;
                    }
                }
                //Verifica se existe registro na DOM_ORC_ESCOPO_10_4
                DataTable dtEscopo10_4 = Escopo10_4.getEscopo_10_4();
                if(dtEscopo10_4.Rows.Count > 0)
                {
                    //Delete os registros do Escopo 10_4
                    int retEscopo10_4 = Escopo10_4.deleteEscopo_10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    if(retEscopo10_4 <= 0)
                    {
                        erros = true;
                    }
                }
                if (erros)
                {
                    MessageBox.Show("Não foi possível excluir os dados deste escopo. Favor tentar novamente.");
                }
                else
                {
                    MessageBox.Show("Registro do Escopo 10_4 apagado com sucesso!");
                    btn10_4Excluir.Visible = false;
                    listaEscopo10_4(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
            }

        }

        private void btn05Salvar_Click(object sender, EventArgs e)
        {
            if(combo05Freq.SelectedIndex == 0 || combo05DadosAmbientais.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, preencha os campos obrigatórios para continuar.");
            }
            else
            {
                string Frequencia = combo05Freq.SelectedIndex.ToString();
                string dadosAmbientais = "";
                if (comboE10_1DadosAmbientais.SelectedIndex == 1)
                {
                    dadosAmbientais = "U";
                }
                else if (comboE10_1DadosAmbientais.SelectedIndex == 2)
                {
                    dadosAmbientais = "M";
                }
                else if (comboE10_1DadosAmbientais.SelectedIndex == 3)
                {
                    dadosAmbientais = "C";
                }
                else
                {
                    dadosAmbientais = "N";
                }
                string Obs = txt05Obs.Text;
                string indPre = "S";

                bool sucesso = true;

                SOEF_CLASS.Escopo_05 Escopo_05 = new SOEF_CLASS.Escopo_05(this.numero_solic.ToString(), this.NumRevisaoSolic);
                SOEF_CLASS.Escopo_Valor_Comum EscopoVlrComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                //Verifica se está cadastrando ou alterando o registro
                if (AcaoTela == "N")
                {
                    int retornoInsert = Escopo_05.gravaEscopo_05(Frequencia, dadosAmbientais, Obs, indPre);
                    if (retornoInsert > 0)
                    {
                        //Verifica se já existe registro para essa solicitação. Se sim, atualiza com os valores deste escopo, se não, insere um novo registro
                        DataTable dtBuscaEscopo_05 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if (dtBuscaEscopo_05.Rows.Count > 0)
                        {
                            //Faz o update e grava os dados usados no Escopo 10_1
                            int retornoInsert05 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E05(dadosAmbientais, Frequencia);
                            if (retornoInsert05 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                        else
                        {
                            //Insere um novo registro na tabela Valor Comum
                            int retornoInsert05 = EscopoVlrComum.gravaEscopo_Valor_Comum_E05(dadosAmbientais, Frequencia);
                            if (retornoInsert05 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                        AcaoTela = "C";
                        btn05Excluir.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro na inserção do registro. Tente novamente mais tarde.");
                    }
                }
                else
                {
                    //AcaoTela - ATUALIZAR
                    DataTable dtBuscaEscopo05 = Escopo_05.getEscopo_05();
                    int retornoUpdate = 0;
                    if (dtBuscaEscopo05.Rows.Count > 0)
                    {
                        //Atualiza o Escopo 05 se já estiver cadastrado
                        retornoUpdate = Escopo_05.updateEscopo_05(Frequencia, dadosAmbientais, Obs, indPre);
                    }
                    else
                    {
                        //Cadastra o Escopo 05 se ainda não existir
                        retornoUpdate = Escopo_05.gravaEscopo_05(Frequencia, dadosAmbientais, Obs, indPre);
                    }
                    if (retornoUpdate > 0)
                    {
                        DataTable dtBuscaVCEscopo05 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if (dtBuscaVCEscopo05.Rows.Count > 0)
                        {
                            //Faz o update e grava os dados usados no Escopo 05
                            int retornoInsert05 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E05(dadosAmbientais, Frequencia);
                            if (retornoInsert05 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                        else
                        {
                            //Insere um novo registro na tabela Valor Comum
                            int retornoInsert05 = EscopoVlrComum.gravaEscopo_Valor_Comum_E05(dadosAmbientais, Frequencia);
                            if (retornoInsert05 <= 0)
                            {
                                sucesso = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro na atualização do registro. Tente novamente mais tarde.");
                    }
                }
                //Verifica se ocorreu erro durante o processo de inserção no ESCOPO 10_1 e VALOR COMUM
                if (sucesso)
                {
                    MessageBox.Show("Registro inserido/alterado com sucesso!");
                    btn05Excluir.Visible = true;
                    listaEscopo05(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Muda o STATUS da AçãoTela p/ EDIÇÂO
                    AcaoTela = "C";
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao ao inserir/alterar o registro. Por favor tente novamente ou contate o administrador do sistema.");
                }
            }
        }

        private void btn05Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 05 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool sucesso = true;
                //Apaga os dados do Escopo 10_1
                SOEF_CLASS.Escopo_05 Escopo05 = new SOEF_CLASS.Escopo_05(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno = Escopo05.deleteEscopo_05(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (retorno > 0)
                {
                    //Apaga (define como NULL) os campos comuns da tabela VALOR_COMUM
                    SOEF_CLASS.Escopo_Valor_Comum EValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    int retornoUpdate = 0;
                    retornoUpdate = EValorComum.deleteEscopo_Valor_Comum_E05();
                    if (retornoUpdate > 0)
                    {
                        //Verifica se todos os campos do registro são nulos, se sim, apaga o registro em definitivo
                        bool DeletaRegistro = verificaRegistroValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        if (DeletaRegistro)//True - Deleta o registro
                        {
                            int retornoDelete = EValorComum.deleteEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (retornoDelete <= 0)
                            {
                                sucesso = false;
                                //MessageBox.Show("Não foi possível realizar a operação completa. Por favor, verifique os dados informados e tente novamente.");
                            }
                        }
                    }
                    else
                    {
                        sucesso = false;
                    }
                }
                else
                {
                    sucesso = false;
                }
                if (sucesso)
                {
                    MessageBox.Show("Registro excluído com sucesso!");
                    btn05Excluir.Visible = false;
                    //checkEscopo10.Checked = false;
                    //checkEscopo10.Enabled = true;
                    listaEscopo05(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o registro. Por favor, contate o suporte do sistema e tente novamente.");
                }
            }
        }

        private void comboTensaoPrimaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo5_1TensaoPrimaria.SelectedIndex == 4)
            {
                txt5_1DescTensaoPrim.Enabled = true;
            }
            else
            {
                txt5_1DescTensaoPrim.Text = "";
                txt5_1DescTensaoPrim.Enabled = false;
            }
        }

        private void combo5_1TensaoSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo5_1TensaoSec.SelectedIndex == 4)
            {
                txt5_1DescTenSec.Enabled = true;
            }
            else
            {
                txt5_1DescTenSec.Text = "";
                txt5_1DescTenSec.Enabled = false;
            }
        }

        private void radio5_1InProtecaoS_CheckedChanged(object sender, EventArgs e)
        {
            if (radio5_1InProtecaoS.Checked)
            {
                combo5_1Pintura.Visible = true;
                combo5_1Pintura.Enabled = true;
                label162.Visible = true;
            }
            else
            {
                combo5_1Pintura.Visible = false;
                label162.Visible = false;
            }
        }

        private void radio5_1InProtecaoN_CheckedChanged(object sender, EventArgs e)
        {
            if (radio5_1InProtecaoN.Checked)
            {
                combo5_1Pintura.Visible = false;
                label162.Visible = false;
            }
            else
            {
                combo5_1Pintura.Visible = true;
                label162.Visible = true;
            }
        }

        private void btn05_1Salvar_Click(object sender, EventArgs e)
        {
            string erros = "";
            if(radio5_1PotFD.Checked)
            {
                if(!radio5_1ListaCargaS.Checked && !radio5_1ListaCargaN.Checked)
                {
                    erros += "O campo Tem Lista de Cargas, deve ser preenchido.\n";
                }
            }
            //Tensão Primária
            if(combo5_1TensaoPrimaria.SelectedIndex == 0)
            {
                erros += "O campo Tensão Primária, deve ser preenchido.\n";
            }
            else if(combo5_1TensaoPrimaria.SelectedIndex == 4)
            {
                if (string.IsNullOrEmpty(txt5_1DescTensaoPrim.Text))
                {
                    erros += "O campo Descrição da Outra Tensão Primária, deve ser preenchido.\n";
                }
            }
            //Tensão Secundária
            if(combo5_1TensaoSec.SelectedIndex == 0)
            {
                erros += "O campo Tensão Secundária, deve ser preenchido.\n";
            }
            else if (combo5_1TensaoSec.SelectedIndex == 4)
            {
                if (string.IsNullOrEmpty(txt5_1DescTenSec.Text))
                {
                    erros += "O campo Descrição da Outra Tensão Secundária, deve ser preenchido.\n";
                }
            }
            //Invólucro de Proteção
            if(!radio5_1InProtecaoS.Checked && !radio5_1InProtecaoN.Checked)
            {
                erros += "O campo Invólucro de Proteção, deve ser preenchido.\n";
            }
            else if (radio5_1InProtecaoS.Checked)
            {
                if(combo5_1Pintura.SelectedIndex == 0)
                {
                    erros += "O campo Pinturas, deve ser preenchido.\n";
                }
            }

            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Painel de erros:\n" + erros);
            }
            else
            {
                bool validaPotencia = true;
                SOEF_CLASS.Escopo_05_1 Escopo_05_1 = new SOEF_CLASS.Escopo_05_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                //Verifica se foi cadastrado a Potência caso seja obrigatória
                if (radio5_1PotInf.Checked)
                {
                    DataTable retPotencia = Escopo_05_1.getPotenciaEscopo("05_1", null);
                    if (retPotencia.Rows.Count <= 0)
                    {
                        validaPotencia = false;
                    }
                }
                if (!validaPotencia)
                {
                    MessageBox.Show("A Potência do transformador BT-BT foi definida como Informada, mas não foi associada nenhuma potência. Informe a lista de potências desejada.");
                }
                else
                {
                    string TensaoPrimaria;
                    string TensaoSecundaria;
                    string indPotenciaInformDef = null;
                    string indListaCargas;
                    string indInvolucroProtec;
                    string obs;
                    string indPre = "S";
                    string tipoPinturaInvolucro = null;
                    string descOutTensaoPrim = null;
                    string descOutTensaoSecun = null;
                    bool sucesso = true;


                    //Tensão Primária
                    TensaoPrimaria = combo5_1TensaoPrimaria.SelectedIndex.ToString();
                    if (combo5_1TensaoPrimaria.SelectedIndex == 4)
                    {
                        descOutTensaoPrim = txt5_1DescTensaoPrim.Text;
                    }
                    //Tensão Secundária
                    TensaoSecundaria = combo5_1TensaoSec.SelectedIndex.ToString();
                    if (combo5_1TensaoSec.SelectedIndex == 4)
                    {
                        descOutTensaoSecun = txt5_1DescTenSec.Text;
                    }

                    if (radio5_1PotInf.Checked)
                    {
                        indPotenciaInformDef = "I";
                    }
                    else if (radio5_1PotFD.Checked)
                    {
                        indPotenciaInformDef = "D";
                        if (radio5_1ListaCargaS.Checked)
                        {
                            indListaCargas = "S";
                        }
                        else
                        {
                            indListaCargas = "N";
                        }
                    }
                    if (radio5_1InProtecaoS.Checked)
                    {
                        indInvolucroProtec = "S";
                        //Pintura
                        if (combo5_1Pintura.SelectedIndex == 1)
                        {
                            tipoPinturaInvolucro = "R";
                        }
                        else if (combo5_1Pintura.SelectedIndex == 2)
                        {
                            tipoPinturaInvolucro = "M";
                        }
                        else if (combo5_1Pintura.SelectedIndex == 3)
                        {
                            tipoPinturaInvolucro = "E";
                        }
                    }
                    else
                    {
                        indInvolucroProtec = "N";
                    }
                    obs = txt5_1Obs.Text;

                    if (indPotenciaInformDef == "D")
                    {
                        if (radio5_1ListaCargaS.Checked)
                        {
                            indListaCargas = "S";
                        }
                        else
                        {
                            indListaCargas = "N";
                        }
                    }
                    else
                    {
                        indListaCargas = null;
                    }
                    SOEF_CLASS.Escopo_Valor_Comum EscopoVlrComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Verifica se está cadastrando ou alterando o registro
                    if (AcaoTela == "N")
                    {
                        int retornoInsert = Escopo_05_1.gravaEscopo_05_1(TensaoPrimaria, TensaoSecundaria, indPotenciaInformDef, indListaCargas, indInvolucroProtec, obs, indPre, tipoPinturaInvolucro, descOutTensaoPrim, descOutTensaoSecun);
                        if (retornoInsert > 0)
                        {
                            //Verifica se o campo pintura é requerido
                            if (indInvolucroProtec == "S")
                            {
                                //Verifica se já existe registro para essa solicitação. Se sim, atualiza com os valores deste escopo, se não, insere um novo registro
                                DataTable dtBuscaEscopo05_1 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                if (dtBuscaEscopo05_1.Rows.Count > 0)
                                {
                                    //Faz o update e grava os dados usados no Escopo 10_1
                                    int retornoInsert05_1 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E05_1(tipoPinturaInvolucro);
                                    if (retornoInsert05_1 <= 0)
                                    {
                                        sucesso = false;
                                    }
                                }
                                else
                                {
                                    //Insere um novo registro na tabela Valor Comum
                                    int retornoInsert05_1 = EscopoVlrComum.gravaEscopo_Valor_Comum_E05_1(tipoPinturaInvolucro);
                                    if (retornoInsert05_1 <= 0)
                                    {
                                        sucesso = false;
                                    }
                                }
                            }
                            AcaoTela = "C";
                            btn05_1Excluir.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro na inserção do registro. Tente novamente mais tarde.");
                        }
                    }
                    else
                    {
                        //AcaoTela - ATUALIZAR
                        DataTable dtBuscaEscopo05_1 = Escopo_05_1.getEscopo_05_1();
                        int retornoUpdate = 0;
                        if (dtBuscaEscopo05_1.Rows.Count > 0)
                        {
                            //Atualiza o Escopo 05_1 se já estiver cadastrado
                            retornoUpdate = Escopo_05_1.updateEscopo_05_1(TensaoPrimaria, TensaoSecundaria, indPotenciaInformDef, indListaCargas, indInvolucroProtec, obs, indPre, tipoPinturaInvolucro, descOutTensaoPrim, descOutTensaoSecun);
                        }
                        else
                        {
                            //Cadastra o Escopo 05_1 se ainda não existir
                            retornoUpdate = Escopo_05_1.gravaEscopo_05_1(TensaoPrimaria, TensaoSecundaria, indPotenciaInformDef, indListaCargas, indInvolucroProtec, obs, indPre, tipoPinturaInvolucro, descOutTensaoPrim, descOutTensaoSecun);
                        }
                        if (retornoUpdate > 0)
                        {
                            DataTable dtBuscaVCEscopo05_1 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (dtBuscaVCEscopo05_1.Rows.Count > 0)
                            {
                                //Faz o update e grava os dados usados no Escopo 05_1
                                int retornoInsert05_1 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E05_1(tipoPinturaInvolucro);
                                if (retornoInsert05_1 <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                            else
                            {
                                //Insere um novo registro na tabela Valor Comum
                                int retornoInsert05_1 = EscopoVlrComum.gravaEscopo_Valor_Comum_E05_1(tipoPinturaInvolucro);
                                if (retornoInsert05_1 <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro na atualização do registro. Tente novamente mais tarde.");
                        }
                    }
                    if (sucesso)
                    {
                        MessageBox.Show("Registro inserido/alterado com sucesso!");
                        btn05_1Excluir.Visible = true;
                        listaEscopo05_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        //Muda o STATUS da AçãoTela p/ EDIÇÂO
                        AcaoTela = "C";
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao ao inserir/alterar o registro. Por favor tente novamente ou contate o administrador do sistema.");
                    }
                }
                                  
            }  
        }

        private void btn5_1GravaPotencia_Click(object sender, EventArgs e)
        {
            string erros = "";
            if (string.IsNullOrEmpty(txt5_1Potencia.Text))
            {
                erros += "O campo Informe a Potência, deve ser preenchido.\n";
            }
            if (string.IsNullOrEmpty(txt5_1Qtd.Text))
            {
                erros += "O campo Quantidade, deve ser preenchido.\n";
            }

            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Painel de erros:\n" + erros);
            }
            else
            {
                string escopo = "05_1";
                string sequencia = "";
                string quantidade = "";
                string potKva = "";
                string fatorK = "";
                string modelo = "";
                int retorno;
                potKva = txt5_1Potencia.Text;
                quantidade = txt5_1Qtd.Text;

                SOEF_CLASS.Escopo_05_1 Escopo_05_1 = new SOEF_CLASS.Escopo_05_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                sequencia = Convert.ToString(Escopo_05_1.getSequencia(this.numero_solic.ToString(), this.NumRevisaoSolic, escopo) + 1);
                retorno = Escopo_05_1.gravaPotencEscopo(escopo, sequencia, quantidade, potKva, null, null);
                if(retorno > 0)
                {
                    dgv5_1Potencias.DataSource = Escopo_05_1.getPotenciaEscopo("05_1", null);
                    MessageBox.Show("Registro inserido com sucesso!");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro na inserção do registro.");
                }

            }


        }

        private void tabE5_Selected(object sender, TabControlEventArgs e)
        {
            if(tabE5.SelectedTab.Name == "tabPE5_1")
            {
                SOEF_CLASS.Escopo_05_1 Escopo_05_1 = new SOEF_CLASS.Escopo_05_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                dgv5_1Potencias.DataSource = Escopo_05_1.getPotenciaEscopo("05_1", null);
                if (AcaoTela == "N")
                {
                    SOEF_CLASS.Escopo_Valor_Comum EscopoValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Verifica e sugere os campos comuns caso existir registro
                    DataTable dtEscopo05_1 = EscopoValorComum.buscaEscopoValorComumE05_1();
                    if (dtEscopo05_1.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtEscopo05_1.Rows)
                        {
                            if (dr["TIPO_PINTURA"].ToString() == "R")
                            {
                                combo5_1Pintura.SelectedIndex = 1;
                            }
                            else if (dr["TIPO_PINTURA"].ToString() == "M")
                            {
                                combo5_1Pintura.SelectedIndex = 2;
                            }
                            else if (dr["TIPO_PINTURA"].ToString() == "E")
                            {
                                combo5_1Pintura.SelectedIndex = 3;
                            }
                        }
                    }
                    else
                    {
                        inicializaCamposE05_1();
                    }
                }
                else
                {
                    listaEscopo05_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }

            }
            else if (tabE5.SelectedTab.Name == "tabPE5_2")
            {
                inicializaCamposE05_2();
                SOEF_CLASS.Escopo_05_2 Escopo_05_2 = new SOEF_CLASS.Escopo_05_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                dgv5_2Potencias.DataSource = Escopo_05_2.getPotenciaEscopo("05_2", null);
                if (AcaoTela == "N")
                {
                    SOEF_CLASS.Escopo_Valor_Comum EscopoValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Verifica e sugere os campos comuns caso existir registro
                    DataTable dtEscopo05_2 = EscopoValorComum.buscaEscopoValorComumE05_2();
                    if (dtEscopo05_2.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtEscopo05_2.Rows)
                        {
                            if (dr["TIPO_PINTURA"].ToString() == "R")
                            {
                                combo5_1Pintura.SelectedIndex = 1;
                            }
                            else if (dr["TIPO_PINTURA"].ToString() == "M")
                            {
                                combo5_1Pintura.SelectedIndex = 2;
                            }
                            else if (dr["TIPO_PINTURA"].ToString() == "E")
                            {
                                combo5_1Pintura.SelectedIndex = 3;
                            }
                        }
                    }
                    else
                    {
                        inicializaCamposE05_2();
                    }
                }
                else
                {
                    listaEscopo05_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
            }
        }

        private void dgv5_1Potencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                SOEF_CLASS.Escopo_05_1 Escopo_05_1 = new SOEF_CLASS.Escopo_05_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno = Escopo_05_1.deletePotencEscopo(dgv5_1Potencias.CurrentRow.Cells[1].Value.ToString(), dgv5_1Potencias.CurrentRow.Cells[2].Value.ToString(), "05_1", dgv5_1Potencias.CurrentRow.Cells[3].Value.ToString());
                if (retorno > 0)
                {
                    dgv5_1Potencias.DataSource = Escopo_05_1.getPotenciaEscopo("05_1", null);
                    MessageBox.Show("Registro apagado com sucesso!");
                }
            }
        }

        private void radio5_1PotFD_CheckedChanged(object sender, EventArgs e)
        {
            if (radio5_1PotFD.Checked)
            {
                pListaCargas.Visible = true;

                //Oculta campos
                label155.Visible = false;
                txt5_1Potencia.Visible = false;
                label158.Visible = false;
                txt5_1Qtd.Visible = false;
                btn5_1GravaPotencia.Visible = false;
                label164.Visible = false;
                dgv5_1Potencias.Visible = false;
                label156.Visible = false;
            }
            else
            {
                pListaCargas.Visible = false;

                label155.Visible = true;
                txt5_1Potencia.Visible = true;
                label158.Visible = true;
                txt5_1Qtd.Visible = true;
                btn5_1GravaPotencia.Visible = true;
                label164.Visible = true;
                dgv5_1Potencias.Visible = true;
                label156.Visible = true;
            }
        }

        private void radio5_1PotInf_CheckedChanged(object sender, EventArgs e)
        {
            if (radio5_1PotInf.Checked)
            {
                label155.Visible = true;
                txt5_1Potencia.Visible = true;
                label158.Visible = true;
                txt5_1Qtd.Visible = true;
                btn5_1GravaPotencia.Visible = true;
                label164.Visible = true;
                dgv5_1Potencias.Visible = true;
                label156.Visible = true;

                pListaCargas.Visible = false;
            }
            else
            {
                label155.Visible = false;
                txt5_1Potencia.Visible = false;
                label158.Visible = false;
                txt5_1Qtd.Visible = false;
                btn5_1GravaPotencia.Visible = false;
                label164.Visible = false;
                dgv5_1Potencias.Visible = false;
                label156.Visible = false;

                pListaCargas.Visible = true;
            }
        }

        private void btn05_1Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 05_1 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool sucesso = true;
                SOEF_CLASS.Escopo_05_1 Escopo05_1 = new SOEF_CLASS.Escopo_05_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                //Apaga os dados da tabela POTENC_ESCOPO
                DataTable dtPotencia = Escopo05_1.getPotenciaEscopo("05_1", null);
                if(dtPotencia.Rows.Count > 0)
                {
                    int retornoPotencia = Escopo05_1.deletePotencEscopo(this.numero_solic.ToString(), this.NumRevisaoSolic, "05_1", null);
                    if(retornoPotencia <= 0)
                    {
                        sucesso = false;
                    }
                }
                //Apaga os dados do Escopo 5_1
                int retorno = Escopo05_1.deleteEscopo_05_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (retorno > 0)
                {
                    //Verifica se o campo da Tabela VALOR_COMUM é requerido
                    SOEF_CLASS.Escopo_Valor_Comum EValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    DataTable dtBusca = EValorComum.buscaEscopoValorComumE05_1();
                    if(dtBusca.Rows.Count > 0)
                    {
                        int retornoUpdate = 0;
                        retornoUpdate = EValorComum.deleteEscopo_Valor_Comum_E05_1();
                        if (retornoUpdate > 0)
                        {
                            //Verifica se todos os campos do registro são nulos, se sim, apaga o registro em definitivo
                            bool DeletaRegistro = verificaRegistroValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (DeletaRegistro)//True - Deleta o registro
                            {
                                int retornoDelete = EValorComum.deleteEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                if (retornoDelete <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                        }
                        else
                        {
                            sucesso = false;
                        }
                    }          
                }
                else
                {
                    sucesso = false;
                }
                if (sucesso)
                {
                    MessageBox.Show("Registro excluído com sucesso!");
                    btn05_1Excluir.Visible = false;
                    dgv5_1Potencias.DataSource = Escopo05_1.getPotenciaEscopo("05_1", null);
                    listaEscopo05_1(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o registro. Por favor, contate o suporte do sistema e tente novamente.");
                }
            }
        }

        private void btn5_2GravaPotencia_Click(object sender, EventArgs e)
        {
            string erros = "";
            if (combo5_2Potencia.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(txt5_2PotKva.Text))
                {
                    erros += "Selecione uma potência ou informe um valor para a Potência do transformador.\n";
                }
            }
            if (string.IsNullOrEmpty(txt5_2Qtd.Text))
            {
                erros += "O campo Quantidade, deve ser preenchido.\n";
            }
            
            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Painel de erros:\n" + erros);
            }
            else
            {
                string escopo = "05_2";
                string sequencia = "";
                string quantidade = "";
                string potKva = "";
                string fatorK = "";
                int retorno;

                potKva = txt5_2PotKva.Text;
                quantidade = txt5_2Qtd.Text;
                fatorK = txt5_2FatorK.Text;

                SOEF_CLASS.Escopo_05_2 Escopo_05_2 = new SOEF_CLASS.Escopo_05_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                sequencia = Convert.ToString(Escopo_05_2.getSequencia(this.numero_solic.ToString(), this.NumRevisaoSolic, escopo) + 1);
                retorno = Escopo_05_2.gravaPotencEscopo(escopo, sequencia, quantidade, potKva, fatorK);
                if (retorno > 0)
                {
                    dgv5_2Potencias.DataSource = Escopo_05_2.getPotenciaEscopo("05_2", null);
                    MessageBox.Show("Registro inserido com sucesso!");
                    //Limpa campos
                    combo5_2Potencia.SelectedIndex = 0;
                    txt5_2PotKva.Text = "";
                    txt5_2Qtd.Text = "";
                    txt5_2FatorK.Text = "";
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro na inserção do registro.");
                }

            }
        }

        private void combo5_2Potencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo5_2Potencia.SelectedIndex == 0)
            {
                txt5_2PotKva.Enabled = true;
            }
            else
            {
                txt5_2PotKva.Text = "";
                txt5_2PotKva.Enabled = false;
            }
        }

        private void radio5_2PotInf_CheckedChanged(object sender, EventArgs e)
        {
            if (radio5_2PotInf.Checked)
            {
                //Oculta campos
                label171.Visible = true;
                combo5_2Potencia.Visible = true;
                label169.Visible = true;
                txt5_2Qtd.Visible = true;
                label183.Visible = true;
                txt5_2PotKva.Visible = true;
                label184.Visible = true;
                txt5_2FatorK.Visible = true;
                label170.Visible = true;
                btn5_2GravaPotencia.Visible = true;
                label168.Visible = true;
                dgv5_2Potencias.Visible = true;

                //Oculta campo Lista Cargas
                panel25.Visible = false;
                radio5_2ListaCargasS.Checked = false;
                radio5_2ListaCargasN.Checked = false;
            }
            else
            {

            }
        }

        private void combo5_2TensaoPrim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo5_2TensaoPrim.SelectedIndex == 7)
            {
                txt5_2DescOutraTensaoPrim.Enabled = true;
            }
            else
            {
                txt5_2DescOutraTensaoPrim.Text = "";
                txt5_2DescOutraTensaoPrim.Enabled = false;
            }
        }

        private void combo5_2TensaoSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo5_2TensaoSec.SelectedIndex == 7)
            {
                txt5_2DescOutraTensaoSec.Enabled = true;
            }
            else
            {
                txt5_2DescOutraTensaoSec.Text = "";
                txt5_2DescOutraTensaoSec.Enabled = false;
            }
        }

        private void radio5_2PotDef_CheckedChanged(object sender, EventArgs e)
        {
            if (radio5_2PotDef.Checked)
            {
                //Mostra campos
                label171.Visible = false;
                combo5_2Potencia.Visible = false;
                label169.Visible = false;
                txt5_2Qtd.Visible = false;
                label183.Visible = false;
                txt5_2PotKva.Visible = false;
                label184.Visible = false;
                txt5_2FatorK.Visible = false;
                label170.Visible = false;
                btn5_2GravaPotencia.Visible = false;
                label168.Visible = false;
                dgv5_2Potencias.Visible = false;

                //Oculta campo Lista Cargas
                panel25.Visible = true;
                radio5_2ListaCargasS.Checked = false;
                radio5_2ListaCargasN.Checked = false;
            }
        }

        private void combo5_2MeioIsol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo5_2MeioIsol.SelectedIndex == 0)
            {
                combo5_2BuchaMT.Enabled = false;
                combo5_2BuchaBT.Enabled = false;
                txt5_2DescOutraBuchaMT.Enabled = false;
                txt5_2DescOutraBuchaBT.Enabled = false;
                combo5_2Pintura.Enabled = false;
                txt5_2DescOutroMeio.Text = "";
                txt5_2DescOutroMeio.Enabled = false;

            }
            else if (combo5_2MeioIsol.SelectedIndex == 1)
            {
                combo5_2BuchaMT.Enabled = true;
                combo5_2BuchaBT.Enabled = true;
                //txt5_2DescOutraBuchaMT.Enabled = true;
                //txt5_2DescOutraBuchaBT.Enabled = true;
                label172.Visible = false;
                combo5_2Pintura.Visible = false;
            }
            else if (combo5_2MeioIsol.SelectedIndex == 2)
            {
                combo5_2BuchaMT.Enabled = false;
                combo5_2BuchaBT.Enabled = false;
                txt5_2DescOutraBuchaMT.Enabled = false;
                txt5_2DescOutraBuchaBT.Enabled = false;
                label172.Visible = false;
                combo5_2Pintura.Visible = false;
              //  label185.Enabled = false;
                txt5_2DescOutroMeio.Text = "";
                txt5_2DescOutroMeio.Enabled = false;
            }
            else if (combo5_2MeioIsol.SelectedIndex == 3)
            {
                combo5_2BuchaMT.Enabled = false;
                combo5_2BuchaBT.Enabled = false;
                txt5_2DescOutraBuchaMT.Enabled = false;
                txt5_2DescOutraBuchaBT.Enabled = false;
                label172.Visible = true;
                combo5_2Pintura.Visible = true;
                combo5_2Pintura.Enabled = true;
                txt5_2DescOutroMeio.Text = "";
                txt5_2DescOutroMeio.Enabled = false;
            }
            else //if (combo5_2MeioIsol.SelectedIndex == 4)
            {
                combo5_2BuchaMT.Enabled = false;
                combo5_2BuchaBT.Enabled = false;
                txt5_2DescOutraBuchaMT.Enabled = false;
                txt5_2DescOutraBuchaBT.Enabled = false;
                label172.Visible = false;
                combo5_2Pintura.Visible = false;
                txt5_2DescOutroMeio.Enabled = true;

            }
        }

        private void btn5_2Salvar_Click(object sender, EventArgs e)
        {
            string erros = "";
            if (radio5_2PotInf.Checked)
            {
                //Verificar se foi informado o cadastro de Potencia..
            }
            else if (radio5_2PotDef.Checked)
            {
                if(!radio5_2ListaCargasS.Checked && !radio5_2ListaCargasN.Checked)
                {
                    erros += "O campo Tem Lista de Cargas, deve ser preenchido.\n";
                }
            }
            //Tensão Primária
            if(combo5_2TensaoPrim.SelectedIndex == 0)
            {
                erros += "O campo Tensão Primária, deve ser preenchido.\n";
            }
            else if(combo5_2TensaoPrim.SelectedIndex == 7)
            {
                if (string.IsNullOrEmpty(txt5_2DescOutraTensaoPrim.Text))
                {
                    erros += "O campo Descrição da Outra Tensão Primária, deve ser preenchido.\n";
                }
            }
            //Tensão Secundária
            if(combo5_2TensaoSec.SelectedIndex == 0)
            {
                erros += "O campo Tensão Secundária, deve ser preenchido.\n";
            }
            else  if(combo5_2TensaoSec.SelectedIndex == 7)
            {
                if (string.IsNullOrEmpty(txt5_2DescOutraTensaoSec.Text))
                {
                    erros += "O campo Descrição da Outra Tensão Secundária, deve ser preenchido.\n";
                }
            }
            //Meio Isolante
            if (combo5_2MeioIsol.SelectedIndex == 0)
            {
                erros += "O campo Meio Isolante, deve ser preenchido.\n";
            }
            else if (combo5_2MeioIsol.SelectedIndex == 1)
            {
                if(combo5_2BuchaMT.SelectedIndex == 0)
                {
                    erros += "O campo Buchas MT Devem Ser, deve ser preenchido.\n";
                }
                else if(combo5_2BuchaMT.SelectedIndex == 4)
                {
                    if (string.IsNullOrEmpty(txt5_2DescOutraBuchaMT.Text))
                    {
                        erros += "O campo Descrição da Outra Bucha MT, deve ser preenchido.\n";
                    }                    
                }
                if (combo5_2BuchaBT.SelectedIndex == 0)
                {
                    erros += "O campo Buchas BT Devem Ser, deve ser preenchido.\n";
                }
                else if (combo5_2BuchaBT.SelectedIndex == 5)
                {
                    if (string.IsNullOrEmpty(txt5_2DescOutraBuchaBT.Text))
                    {
                        erros += "O campo Descrição da Outra Bucha BT, deve ser preenchido.\n";
                    }
                }
            }
            else if (combo5_2MeioIsol.SelectedIndex == 3)
            {
                if(combo5_2Pintura.SelectedIndex == 0)
                {
                    erros += "O campo Pintura Meio Isolante, deve ser preenchido.\n";
                }
            }
            else if (combo5_2MeioIsol.SelectedIndex == 4)
            {
                if (string.IsNullOrEmpty(txt5_2DescOutraBuchaBT.Text))
                {
                    erros += "O campo Descrição do Outro Meio Isolante, deve ser preenchido.\n";
                }
            }

            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Painel de erros:\n" + erros);
            }
            else
            {
                bool validaPotencia = true;
                SOEF_CLASS.Escopo_05_2 Escopo_05_2 = new SOEF_CLASS.Escopo_05_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                //Verifica se foi cadastrado a Potência caso seja obrigatória
                if (radio5_1PotInf.Checked)
                {
                    DataTable retPotencia = Escopo_05_2.getPotenciaEscopo("05_2", null);
                    if (retPotencia.Rows.Count <= 0)
                    {
                        validaPotencia = false;
                    }
                }
                if (!validaPotencia)
                {
                    MessageBox.Show("A Potência do transformador BT-MT/MT-BT foi definida como Informada, mas não foi associada nenhuma potência. Informe a lista de potências desejada.");
                }
                else
                {
                    string TensaoPrimaria;
                    string TensaoSecundaria;
                    string indPotenciaInformDef = "";
                    string indListaCargas = "";
                    string MeioIsolante = "";
                    string BuchasMT = null;
                    string BuchasBT = null;
                    string Obs = "";
                    string indPre = "S";
                    string tipoPinturaMeioIsol = null;
                    string descOutraTensaoPrim = "";
                    string descOutraTensaoSec = "";
                    string descOutraBuchaMT = "";
                    string descOutraBuchaBT = "";
                    string descOutroMeioIsolante = "";
                    bool sucesso = true;

                    //Tensão Primária
                    TensaoPrimaria = combo5_2TensaoPrim.SelectedIndex.ToString();
                    if (combo5_2TensaoPrim.SelectedIndex == 7)
                    {
                        descOutraTensaoPrim = txt5_2DescOutraTensaoPrim .Text;
                    }
                    //Tensão Secundária
                    TensaoSecundaria = combo5_2TensaoSec.SelectedIndex.ToString();
                    if (combo5_2TensaoSec.SelectedIndex == 7)
                    {
                        descOutraTensaoSec = txt5_2DescOutraTensaoSec.Text;
                    }
                    //IND_POTENCIA_INFORM_DEF
                    if (radio5_2PotInf.Checked)
                    {
                        indPotenciaInformDef = "I";
                    }
                    else if (radio5_1PotFD.Checked)
                    {
                        indPotenciaInformDef = "D";
                        if (radio5_2ListaCargasS.Checked)
                        {
                            indListaCargas = "S";
                        }
                        else
                        {
                            indListaCargas = "N";
                        }
                    }
                    //Meio Isolante
                    MeioIsolante = combo5_2MeioIsol.SelectedIndex.ToString();
                    if(combo5_2MeioIsol.SelectedIndex == 1)
                    {
                        //Obriga Buchas MT e BT
                        BuchasMT = combo5_2BuchaMT.SelectedIndex.ToString();
                        if(combo5_2BuchaMT.SelectedIndex == 4)
                        {
                           // BuchasMT = combo5_2BuchaMT.SelectedIndex.ToString();
                            descOutraBuchaMT = txt5_2DescOutraBuchaMT.Text;
                        }
                        else
                        {
                            descOutraBuchaMT = "";
                        }
                        //Bucha BT
                        BuchasBT = combo5_2BuchaBT.SelectedIndex.ToString();
                        if (combo5_2BuchaBT.SelectedIndex == 5)
                        {
                            descOutraBuchaBT = txt5_2DescOutraBuchaBT.Text;
                        }
                        else
                        {
                            descOutraBuchaBT = "";
                        }
                        tipoPinturaMeioIsol = null;
                        descOutroMeioIsolante = null;
                    }
                    else if (combo5_2MeioIsol.SelectedIndex == 2)
                    {
                        BuchasMT = null;
                        BuchasBT = null;
                        descOutraBuchaMT = "";
                        descOutraBuchaBT = "";
                        tipoPinturaMeioIsol = null;
                        descOutroMeioIsolante = "";
                    }
                    else if(combo5_2MeioIsol.SelectedIndex == 3)
                    {
                        //Pintura
                        if (combo5_2Pintura.SelectedIndex == 1)
                        {
                            tipoPinturaMeioIsol = "R";
                        }
                        else if (combo5_2Pintura.SelectedIndex == 2)
                        {
                            tipoPinturaMeioIsol = "M";
                        }
                        else if (combo5_2Pintura.SelectedIndex == 3)
                        {
                            tipoPinturaMeioIsol = "E";
                        }
                        BuchasMT = null;
                        BuchasBT = null;
                        descOutraBuchaMT = "";
                        descOutraBuchaBT = "";
                        descOutroMeioIsolante = "";
                    }
                    else if(combo5_2MeioIsol.SelectedIndex == 4)
                    {
                        descOutroMeioIsolante = txt5_2DescOutroMeio.Text;
                        BuchasMT = null;
                        BuchasBT = null;
                        descOutraBuchaMT = "";
                        descOutraBuchaBT = "";
                        tipoPinturaMeioIsol = null;
                    }
                    //Obs
                    Obs = txt5_2Obs.Text;

                    SOEF_CLASS.Escopo_Valor_Comum EscopoVlrComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    //Verifica se está cadastrando ou alterando o registro
                    if (AcaoTela == "N")
                    {
                        int retornoInsert = Escopo_05_2.gravaEscopo_05_2(TensaoPrimaria, TensaoSecundaria, indPotenciaInformDef, indListaCargas, MeioIsolante, BuchasMT, BuchasBT, Obs, indPre, tipoPinturaMeioIsol, descOutraTensaoPrim, descOutraTensaoSec, descOutraBuchaMT, descOutraBuchaBT, descOutroMeioIsolante);
                        if (retornoInsert > 0)
                        {
                            //Verifica se o campo pintura é requerido
                            if (combo5_2MeioIsol.SelectedIndex == 3)
                            {
                                //Verifica se já existe registro para essa solicitação. Se sim, atualiza com os valores deste escopo, se não, insere um novo registro
                                DataTable dtBuscaEscopo05_2 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                if (dtBuscaEscopo05_2.Rows.Count > 0)
                                {
                                    //Faz o update e grava os dados usados no Escopo 10_2
                                    int retornoInsert05_2 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E05_2(tipoPinturaMeioIsol);
                                    if (retornoInsert05_2 <= 0)
                                    {
                                        sucesso = false;
                                    }
                                }
                                else
                                {
                                    //Insere um novo registro na tabela Valor Comum
                                    int retornoInsert05_2 = EscopoVlrComum.gravaEscopo_Valor_Comum_E05_2(tipoPinturaMeioIsol);
                                    if (retornoInsert05_2 <= 0)
                                    {
                                        sucesso = false;
                                    }
                                }
                            }
                            AcaoTela = "C";
                            btn5_2Excluir.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro na inserção do registro. Tente novamente mais tarde.");
                        }
                    }
                    else
                    {
                        //AcaoTela - ATUALIZAR
                        DataTable dtBuscaEscopo05_2 = Escopo_05_2.getEscopo_05_2();
                        int retornoUpdate = 0;
                        if (dtBuscaEscopo05_2.Rows.Count > 0)
                        {
                            //Atualiza o Escopo 05_1 se já estiver cadastrado
                            retornoUpdate = Escopo_05_2.updateEscopo_05_2(TensaoPrimaria, TensaoSecundaria, indPotenciaInformDef, indListaCargas, MeioIsolante, BuchasMT, BuchasBT, Obs, indPre, tipoPinturaMeioIsol, descOutraTensaoPrim, descOutraTensaoSec, descOutraBuchaMT, descOutraBuchaBT, descOutroMeioIsolante);
                        }
                        else
                        {
                            //Cadastra o Escopo 05_1 se ainda não existir
                            retornoUpdate = Escopo_05_2.gravaEscopo_05_2(TensaoPrimaria, TensaoSecundaria, indPotenciaInformDef, indListaCargas, MeioIsolante, BuchasMT, BuchasBT, Obs, indPre, tipoPinturaMeioIsol, descOutraTensaoPrim, descOutraTensaoSec, descOutraBuchaMT, descOutraBuchaBT, descOutroMeioIsolante);
                        }
                        if (retornoUpdate > 0)
                        {
                            DataTable dtBuscaVCEscopo05_2 = EscopoVlrComum.buscaEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (dtBuscaVCEscopo05_2.Rows.Count > 0)
                            {
                                //Faz o update e grava os dados usados no Escopo 05_2
                                int retornoInsert05_2 = EscopoVlrComum.atualizaEscopo_Valor_Comum_E05_2(tipoPinturaMeioIsol);
                                if (retornoInsert05_2 <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                            else
                            {
                                //Insere um novo registro na tabela Valor Comum
                                int retornoInsert05_2 = EscopoVlrComum.gravaEscopo_Valor_Comum_E05_2(tipoPinturaMeioIsol);
                                if (retornoInsert05_2 <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro na atualização do registro. Tente novamente mais tarde.");
                        }
                    }
                    if (sucesso)
                    {
                        MessageBox.Show("Registro inserido/alterado com sucesso!");
                        btn5_2Excluir.Visible = true;
                        listaEscopo05_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                        //Muda o STATUS da AçãoTela p/ EDIÇÂO
                        AcaoTela = "C";
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao ao inserir/alterar o registro. Por favor tente novamente ou contate o administrador do sistema.");
                    }
                }
            }
        }

        private void dgv5_2Potencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                SOEF_CLASS.Escopo_05_2 Escopo_05_2 = new SOEF_CLASS.Escopo_05_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                int retorno = Escopo_05_2.deletePotencEscopo(dgv5_2Potencias.CurrentRow.Cells[1].Value.ToString(), dgv5_2Potencias.CurrentRow.Cells[2].Value.ToString(), "05_2", dgv5_2Potencias.CurrentRow.Cells[3].Value.ToString());
                if (retorno > 0)
                {
                    dgv5_2Potencias.DataSource = Escopo_05_2.getPotenciaEscopo("05_2", null);
                    MessageBox.Show("Registro apagado com sucesso!");
                }
            }
        }

        private void btn5_2Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Escopo 05_2 desta solicitação?", "SOEF", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool sucesso = true;
                SOEF_CLASS.Escopo_05_2 Escopo05_2 = new SOEF_CLASS.Escopo_05_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                //Apaga os dados da tabela POTENC_ESCOPO
                DataTable dtPotencia = Escopo05_2.getPotenciaEscopo("05_2", null);
                if (dtPotencia.Rows.Count > 0)
                {
                    int retornoPotencia = Escopo05_2.deletePotencEscopo(this.numero_solic.ToString(), this.NumRevisaoSolic, "05_2", null);
                    if (retornoPotencia <= 0)
                    {
                        sucesso = false;
                    }
                }
                //Apaga os dados do Escopo 5_2
                int retorno = Escopo05_2.deleteEscopo_05_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                if (retorno > 0)
                {
                    //Verifica se o campo da Tabela VALOR_COMUM é requerido
                    SOEF_CLASS.Escopo_Valor_Comum EValorComum = new SOEF_CLASS.Escopo_Valor_Comum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                    DataTable dtBusca = EValorComum.buscaEscopoValorComumE05_2();
                    if (dtBusca.Rows.Count > 0)
                    {
                        int retornoUpdate = 0;
                        retornoUpdate = EValorComum.deleteEscopo_Valor_Comum_E05_2();
                        if (retornoUpdate > 0)
                        {
                            //Verifica se todos os campos do registro são nulos, se sim, apaga o registro em definitivo
                            bool DeletaRegistro = verificaRegistroValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                            if (DeletaRegistro)//True - Deleta o registro
                            {
                                int retornoDelete = EValorComum.deleteEscopoValorComum(this.numero_solic.ToString(), this.NumRevisaoSolic);
                                if (retornoDelete <= 0)
                                {
                                    sucesso = false;
                                }
                            }
                        }
                        else
                        {
                            sucesso = false;
                        }
                    }
                }
                else
                {
                    sucesso = false;
                }
                if (sucesso)
                {
                    MessageBox.Show("Registro excluído com sucesso!");
                    btn5_2Excluir.Visible = false;
                    dgv5_2Potencias.DataSource = Escopo05_2.getPotenciaEscopo("05_2", null);
                    listaEscopo05_2(this.numero_solic.ToString(), this.NumRevisaoSolic);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o registro. Por favor, contate o suporte do sistema e tente novamente.");
                }
            }
        }

        private void combo5_2Pintura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo5_2BuchaMT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo5_2BuchaMT.SelectedIndex == 4)
            {
                txt5_2DescOutraBuchaMT.Enabled = true;
            }
            else
            {
                txt5_2DescOutraBuchaMT.Text = "";
                txt5_2DescOutraBuchaMT.Enabled = false;
            }
        }

        private void combo5_2BuchaBT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo5_2BuchaBT.SelectedIndex == 5)
            {
                txt5_2DescOutraBuchaBT.Enabled = true;
            }
            else
            {
                txt5_2DescOutraBuchaBT.Text = "";
                txt5_2DescOutraBuchaBT.Enabled = false;
            }
        }
    }
}
