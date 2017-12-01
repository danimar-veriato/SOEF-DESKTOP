using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace ORCAMENTOS_FOCKINK
{
    public class CadSolicitacao
    {
        private string numero_solic { get; set; }
        private string status_solic { get; set; }
        private string cliente { get; set; }
        private string obra { get; set; }
        private string observacao { get; set; }
        private string projeto { get; set; }
        private string cod_tecnico { get; set; }
        private string dpes_cod_tecnico { get; set; }
        private string cod_comercial { get; set; }
        private string dpes_cod_comercial { get; set; }
        private string tipo_negocio { get; set; }
        private string finalidade { get; set; }
        private string empreendimento { get; set; }
        private string idioma { get; set; }
        private string outro_idioma { get; set; }
        private string prazo_proposta { get; set; }
        private string valor { get; set; }
        private string dt_proposta { get; set; }
        private string dt_entrega_obra { get; set; }
        private string concorrentes { get; set; }
        private string resp_padrao_solucao { get; set; }
        private string frete { get; set; }
        private string faturamento { get; set; }
        private string destino_material { get; set; }
        private string contICMS { get; set; }
        private string incentFiscal { get; set; }
        private string desc_incentivo { get; set; }
        private string formaPagamento { get; set; }
        private string financiamento { get; set; }
        private string instFinanceira { get; set; }
        private string indic_empr_codigo { get; set; }
        private string indic_dpes_codigo { get; set; }
        private string comissaoIndicador { get; set; }
        private string desconto { get; set; }
        private string moeda { get; set; }
        private string cod_repres { get; set; }
        private string empr_repres { get; set; }
        private string aliq_imposto { get; set; }
        private string taxa_flat { get; set; }
        private string maoObraCli { get; set; }
        private string tipoMaoObraCli { get; set; }
        private string ind_exportacao { get; set; }
        private string ind_resp_zelo_material { get; set; }
        private string ind_eng_residente { get; set; }
        private string ind_tec_seguranca { get; set; }
        private string ind_seg_resp_civil { get; set; }
        private string ind_plataforma { get; set; }
        private string ind_databook { get; set; }
        private string ind_treinamentos { get; set; }
        private string ind_canteiro_obras { get; set; }
        private string ind_outra_necessidade { get; set; }
        private string desc_outra_necessidade { get; set; }

        //Campos DOM_SOLIC_ORC_COND_PGTO
        private string revisaoSolic { get; set; }
        private string seqSolic { get; set; }
        private string codEventoPgto { get; set; }
        private string percCorrespondente { get; set; }


        /// <summary>
        /// Busca a última sequência de pagamento de uma solicitação
        /// </summary>
        /// <returns></returns>
        public string getSequenciaSolic(string p_NumSolic)
        {
            ManipulaBD mBD = new ManipulaBD();
            try
            {
                string sequencia = mBD.selectSOF("SELECT MAX(SEQUENCIA)+1 FROM [DOM_SOLIC_ORC_COND_PGTO] WHERE NUMERO_SOLICITACAO = " + p_NumSolic);
                if (string.IsNullOrEmpty(sequencia))
                {
                    sequencia = "1";
                }
                return sequencia;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }
        

        /// <summary>
        /// Busca o próximo número de solicitação
        /// </summary>
        /// <returns></returns>
        public string getNumeroSolicitacao()
        {
            ManipulaBD mBD = new ManipulaBD();
            try
            {
                string numero = mBD.selectSOF("SELECT MAX(NUMERO)+1 FROM [DOM_SOLIC_ORCAMENTO]");
                if (string.IsNullOrEmpty(numero))
                {
                    numero = "1";
                }
                return numero;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Busca os dados do cliente
        /// </summary>
        /// <param name="p_codigo">Código do cliente</param>
        /// <param name="p_act">C - Código | lista - Razão Social/CPF/CNPJ</param>
        /// <returns></returns>
        public DataTable getCliente(string p_codigo, string p_act)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
                        
            string sql = "";
            try
            {
                if (p_act == "lista") 
                {
                    sql = "SELECT [COD_CLIENTE], [COD_REPRESENTANTE], [EMPR_CODIGO_REPRES], [RAZAO_SOCIAL], [CGC_CPF], [INSCRICAO_ESTADUAL], [CIDADE] + '-' + [SIGLA_UF] AS CIDADE ";
                    sql += "FROM [DOM_CLIENTE] ";
                    sql += "WHERE COD_CLIENTE LIKE '%" + p_codigo + "%' ";
                    sql += "OR RAZAO_SOCIAL LIKE '%" + p_codigo + "%' ";
                    sql += "OR CGC_CPF LIKE '%" + p_codigo + "%' ";
                }
                else
                {
                    sql = "SELECT [COD_CLIENTE], [COD_REPRESENTANTE], [EMPR_CODIGO_REPRES], [RAZAO_SOCIAL], [CGC_CPF], [INSCRICAO_ESTADUAL], [CIDADE], [SIGLA_UF] ";
                    sql += "FROM [DOM_CLIENTE] ";
                    sql += "WHERE COD_CLIENTE = '" + p_codigo + "' ";
                }

                return mBD.selectListaSOF(sql, "DOM_CLIENTE");                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Busca os dados dos contatos da solicitação
        /// </summary>
        /// <param name="p_busca">Termo a ser buscado</param>
        /// <param name="p_dpes_codigo">Código de pessoa do representante</param>
        /// <param name="p_act"> Consulta vai retornar uma lista ou só o codigo</param>
        /// <returns></returns>
        public DataTable getContato(string p_busca, string p_empr_representante, string p_dpes_codigo, string p_act)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();

            string sql = "";
            try
            {
                if (p_act == "lista")
                {
                    sql = "SELECT * FROM ";
                    sql += "  ( SELECT  [CODIGO], [DPES_CODIGO], [NOME], [DDD] + [TELEFONE] as FONE, ";
                    sql += "  [CELULAR_DDD] + [CELULAR] CELULAR, [EMAIL] ";
                    sql += "FROM [DOM_CONTATO] ";
                    sql += "WHERE [DPES_CODIGO] IN('" + p_dpes_codigo + "') ";
                    sql += "AND [EMPR_CODIGO] = '" + p_empr_representante + "' ";
                    sql += "AND [ATIVO] = 'S' ";
                    sql += "AND [NOME] IS NOT NULL) ";
                    sql += "CONTATO";
                    sql += " WHERE [NOME] LIKE '%" + p_busca + "%' ";

                    sql += " OR [CODIGO] LIKE '%" + p_busca + "%' ";      
                }
                else
                {
                    sql = "SELECT [CODIGO] ";
                    sql += " ,[DPES_CODIGO] ";
                    sql += " ,[NOME] ";
                    sql += " ,[DDD] + [TELEFONE] as FONE ";
                    sql += " ,[CELULAR_DDD] + [CELULAR] CELULAR ";
                    sql += " ,[EMAIL] ";
                    sql += " ,[ATIVO] ";
                    sql += "FROM [DOM_CONTATO] ";
                    sql += "WHERE [CODIGO] = '" + p_busca + "' ";
                    sql += "AND [EMPR_CODIGO] = '" + p_empr_representante + "' ";
                    sql += "AND [DPES_CODIGO] = '" + p_dpes_codigo + "' ";
                    sql += "AND [ATIVO] = 'S' ";
                }
                return mBD.selectListaSOF(sql, "DOM_CONTATO");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Busca os dados do cliente onde a obra vai ser executada
        /// </summary>
        /// <param name="p_codigo"></param>
        /// <param name="p_act"></param>
        /// <returns></returns>
        public DataTable getObra(string p_codigo, string p_act) //ACT (C - Código | lista - Razão Social/CNPJ)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();

            string sql = "";
            try
            {
                if (p_act == "lista")
                {
                    sql = "SELECT [COD_CLIENTE], [RAZAO_SOCIAL], [CGC_CPF], [INSCRICAO_ESTADUAL], [CIDADE] + '-' + [SIGLA_UF] AS CIDADE ";
                    sql += "FROM [DOM_CLIENTE] ";
                    sql += "WHERE COD_CLIENTE LIKE '%" + p_codigo + "%' OR RAZAO_SOCIAL LIKE '%" + p_codigo + "%' OR CGC_CPF LIKE '%" + p_codigo + "%' ";
                }
                else
                {
                    sql = "SELECT [COD_CLIENTE], [RAZAO_SOCIAL], [CGC_CPF], [INSCRICAO_ESTADUAL], [CIDADE], [SIGLA_UF] ";
                    sql += "FROM [DOM_CLIENTE] ";
                    sql += "WHERE COD_CLIENTE = '" + p_codigo + "' ";
                }

                return mBD.selectListaSOF(sql, "DOM_CLIENTE");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }

        
        /// <summary>
        /// Busca a lista dos Tipos de Negócio para preencher o ComboBox do cabeçalho
        /// </summary>
        /// <returns></returns>
        public DataTable getTipoNegocio()
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            try
            {
                string sql = "";
                sql += "SELECT [CODIGO], [DESCRICAO] FROM DOM_TIPO_NEGOCIO";
                return mBD.selectListaSOF(sql, "DOM_CLIENTE");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Busca lista de Eventos de Pagamentos
        /// </summary>
        /// <returns></returns>
        public DataTable getEventoPagamento()
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            try
            {
                string sql = "";
                sql += "SELECT [CODIGO], [DESCRICAO] FROM DOM_EVENTO_PAGAMENTO";
                return mBD.selectListaSOF(sql, "DOM_EVENTO_PAGAMENTO");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }

        
        /// <summary>
        /// Busca os registros da tabela DOM_INDICADOR_NEGOCIO que é utilizado no cadastro do cabeçalho da solicitação
        /// </summary>
        /// <param name="p_empr_logada"></param>
        /// <returns></returns>
        public DataTable getIndicNegocios(string p_empr_logada)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            try
            {
                string sql = "";
                sql += "SELECT [DPES_CODIGO], [COD_RAZAO_SOCIAL] FROM DOM_INDICADOR_NEGOCIO WHERE [EMPR_CODIGO] = '" + p_empr_logada + "'";
                return mBD.selectListaSOF(sql, "DOM_INDICADOR_NEGOCIO");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Busca as formas de pagamento da tabela DOMOBR_REF_CODES
        /// </summary>
        /// <returns></returns>
        public DataTable getFormaPagamento(string pVlr)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            try
            {
                string sql = "";
                sql += "SELECT [VALOR], [DESCRICAO] FROM DOMOBR_REF_CODES";
                if (!string.IsNullOrEmpty(pVlr))
                {
                    sql += " WHERE [VALOR] = '" + pVlr + "'";
                }
                return mBD.selectListaSOF(sql, "DOMOBR_REF_CODES");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Realiza a gravação/alteração do registro de uma solicitação
        /// </summary>
        /// /// <param name="p_act">I - Insert U - Update</param>
        /// <param name="p_num_solic"></param>
        /// <param name="p_status_solic"></param>
        /// <param name="p_cliente"></param>
        /// <param name="p_obra"></param>
        /// <param name="p_observacao"></param>
        /// <param name="p_projeto"></param>
        /// <param name="p_cod_tecnico"></param>
        /// <param name="p_cod_comercial"></param>
        /// <param name="tipo_negocio"></param>
        /// <param name="p_finalidade"></param>
        /// <param name="p_empreendimento"></param>
        /// <param name="p_idioma"></param>
        /// <param name="p_outro_idioma"></param>
        /// <param name="p_prazo_proposta"></param>
        /// <param name="p_valor"></param>
        /// <param name="p_dt_obra"></param>
        /// <param name="p_concorrentes"></param>
        /// <param name="p_padrao_solucao"></param>
        /// <param name="p_frete"></param>
        /// <param name="p_faturamento"></param>
        /// <param name="p_venda_para"></param>
        /// <param name="p_contICMS"></param>
        /// <param name="p_incentFiscal"></param>
        /// <param name="p_incentivo"></param>
        /// <param name="p_forma_pagamento"></param>
        /// <param name="p_financiamento"></param>
        /// <param name="p_instFinanceira"></param>
        /// <param name="p_indic_negocio"></param>
        /// <param name="p_comissao_indicador"></param>
        /// <param name="p_desconto"></param>
        /// <param name="p_moeda"></param>
        public void setSolicitacao(string p_act, string p_num_solic, string p_revisao, string p_status_solic, string p_cliente, string p_obra, string p_observacao,
        string p_projeto, string p_cod_tecnico, string p_dpes_cod_tecnico, string p_cod_comercial, string p_dpes_cod_comercial, string p_tipo_negocio,
        string p_finalidade, string p_empreendimento, string p_idioma, string p_outro_idioma, string p_valor, string p_dt_entrega_obra,
        string p_dt_proposta, string p_concorrentes, string p_resp_padrao_solucao, string p_frete, string p_faturamento, string p_destino_material, string p_contICMS,
        string p_incentFiscal, string p_desc_incentivo, string p_forma_pagamento, string p_financiamento, string p_instFinanceira, string p_indic_empr_codigo, 
        string p_indic_dpes_codigo, string p_indic_comissao, string p_desconto, string p_moeda, string p_cod_repres, string p_empr_repres, string pAliqImposto, string pTaxaFlat,
        string p_maoObraCli, string p_tipoMaoObraCli, string p_indExportacao, string p_indRespZelo, string p_indEngResidente, string p_TecSeguranca, string p_SegRespCivil, 
        string p_Plataforma, string p_Databook, string p_indTreinamentos, string p_CanteiroObras, string p_OutraNecessidade, string p_DescOutraNecessidade)
        {
            //Atualizando o valor nos atributos da classe
            this.numero_solic = p_num_solic;
            this.status_solic = p_status_solic;
            this.cliente = p_cliente;
            this.obra = p_obra;
            this.observacao = p_observacao;
            this.projeto = p_projeto;
            this.cod_tecnico = p_cod_tecnico;
            this.dpes_cod_tecnico = p_dpes_cod_tecnico;
            this.cod_comercial = p_cod_comercial;
            this.dpes_cod_comercial = p_dpes_cod_comercial;
            this.tipo_negocio = p_tipo_negocio;
            this.finalidade = p_finalidade;
            this.empreendimento = p_empreendimento;
            this.idioma = p_idioma;
            this.outro_idioma = p_outro_idioma;
            this.valor = p_valor;
            this.dt_entrega_obra = p_dt_entrega_obra;
            this.dt_proposta = p_dt_proposta;
            this.concorrentes = p_concorrentes;
            this.resp_padrao_solucao = p_resp_padrao_solucao;
            this.frete = p_frete;
            this.faturamento = p_faturamento;
            this.destino_material = p_destino_material;
            this.contICMS = p_contICMS;
            this.incentFiscal = p_incentFiscal;
            this.desc_incentivo = p_desc_incentivo;
            this.formaPagamento = p_forma_pagamento;
            this.financiamento = p_financiamento;
            this.instFinanceira = p_instFinanceira;
            this.indic_empr_codigo = p_indic_empr_codigo;
            this.indic_dpes_codigo = p_indic_dpes_codigo;
            this.comissaoIndicador = p_indic_comissao;
            this.desconto = p_desconto;
            this.empr_repres = p_empr_repres;
            this.cod_repres = p_cod_repres;
            this.aliq_imposto = pAliqImposto;
            this.taxa_flat = taxa_flat;
            this.maoObraCli = maoObraCli;
            this.tipoMaoObraCli = tipoMaoObraCli;
            this.ind_exportacao = ind_exportacao;
            this.ind_resp_zelo_material = ind_resp_zelo_material;
            this.ind_eng_residente = ind_eng_residente;
            this.ind_tec_seguranca = ind_tec_seguranca;
            this.ind_seg_resp_civil = ind_seg_resp_civil;
            this.ind_plataforma = ind_plataforma;
            this.ind_databook = ind_databook;
            this.ind_treinamentos = ind_treinamentos;
            this.ind_canteiro_obras = ind_canteiro_obras;
            this.ind_outra_necessidade = ind_outra_necessidade;
            this.desc_outra_necessidade = desc_outra_necessidade;

            int retorno;

            //Instancia a classe de conexão com o banco
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            try
            {
                string sql = "";
                if (p_act == "I") //Insert
                {
                    sql += "INSERT INTO [DOM_SOLIC_ORCAMENTO] ";
                    sql += "([NUMERO] ";
                    sql += ",[REVISAO] ";
                    sql += ",[STATUS] ";
                    sql += ",[OBSERVACOES] ";
                    sql += ",[NOME_PROJETO] ";
                    sql += ",[DPES_CODIGO_CLI] ";
                    sql += ",[DPES_CODIGO_OBRA] ";
                    sql += ",[COD_CONT_TEC_CLI] ";
                    sql += ",[DPES_CONT_TEC_CLI] ";
                    sql += ",[COD_CONT_COM_CLI] ";
                    sql += ",[DPES_COD_CONT_COM_CLI] ";
                    sql += ",[NEGOCIO_ASSOCIADO] ";
                    sql += ",[FINALIDADE_PROPOSTA] ";
                    sql += ",[TIPO_EMPREENDIMENTO] ";
                    sql += ",[IDIOMA_PROPOSTA] ";
                    sql += ",[OUTRO_IDIOMA] ";
                    sql += ",[DT_ENTREGA_OBRA] ";
                    sql += ",[VALOR_ESTIMADO] ";
                    sql += ",[DESCRICAO_CONCORRENTES] ";
                    sql += ",[RESP_PADRAO_VENDOR_LIST] ";
                    sql += ",[TIPO_FRETE] ";
                    sql += ",[INDIC_FATURAMENTO] ";
                    sql += ",[DESTINO_MATERIAL] ";
                    sql += ",[CLIENTE_CONTRIB_ICMS] ";
                    sql += ",[CLIENTE_INCENTIVO_FISCAL] ";
                    sql += ",[DESC_INCENTIVO_FISC] ";
                    sql += ",[FORMA_PAGAMENTO] ";
                    sql += ",[DESC_FINANCIAMENTO] ";
                    sql += ",[INSTITUICAO_FINANCEIRA] ";
                    sql += ",[INDIC_EMPR_CODIGO] ";
                    sql += ",[INDIC_DPES_CODIGO] ";
                    sql += ",[INDIC_PERC_COMISSAO] ";
                    sql += ",[MARGEM_DESCONTO] ";
                    sql += ",[MOEDA_PROPOSTA] ";
                    sql += ",[DT_PROPOSTA] ";
                    sql += ",[REPRES_EMPR_CODIGO] ";
                    sql += ",[REPRES_DPES_CODIGO] ";
                    sql += ",[INFORMAR_ALIQ_IMPOSTO] ";
                    sql += ",[CONSIDERAR_TAXA_FLAT] ";

                    sql += ",[MAO_OBRA_CLIENTE] ";
                    sql += ",[TIPO_MAO_OBRA] ";
                    sql += ",[IND_EXPORTACAO] ";
                    sql += ",[IND_RESP_ZELO_MATERIAL] ";
                    sql += ",[IND_ENG_RESIDENTE] ";
                    sql += ",[IND_TEC_SEGURANCA] ";
                    sql += ",[IND_SEG_RESP_CIVIL] ";
                    sql += ",[IND_PLATAFORMA] ";
                    sql += ",[IND_DATABOOK] ";
                    sql += ",[IND_TREINAMENTOS] ";
                    sql += ",[IND_CANTEIRO_OBRAS] ";
                    sql += ",[IND_OUTRA_NECESSIDADE] ";
                    sql += ",[DESC_OUTRA_NECESSIDADE]) ";
                    sql += "VALUES ";
                    sql += "(" + p_num_solic + ", ";
                    sql += "'" + p_revisao + "', ";
                    sql += "'" + p_status_solic + "', ";
                    sql += "'" + p_observacao + "', ";
                    sql += "'" + p_projeto + "', ";
                    sql += "'" + p_cliente + "', ";
                    sql += "" + p_obra + ", ";
                    sql += "'" + p_cod_tecnico + "', ";
                    if (string.IsNullOrEmpty(p_dpes_cod_tecnico)) //Se informou contato técnico
                    {
                        sql += " NULL, ";
                    }
                    else
                    {
                        sql += "'" + p_dpes_cod_tecnico + "', ";
                    }
                    sql += "'" + p_cod_comercial + "', ";
                    if (string.IsNullOrEmpty(p_dpes_cod_comercial)) //Se informou contato comercial
                    {
                        sql += " NULL, ";
                    }
                    else
                    {
                        sql += "'" + p_dpes_cod_comercial + "', ";
                    }
                    sql += "" + p_tipo_negocio + ", ";
                    sql += "" + p_finalidade + ", ";
                    sql += "" + p_empreendimento + ", ";
                    sql += "" + p_idioma + ", ";
                    sql += "'" + p_outro_idioma + "', ";
                    sql += "@p_data1, "; //DT_ENTREGA_OBRA
                    if (string.IsNullOrEmpty(p_valor))
                    {
                        sql += " NULL, ";
                    }
                    else
                    {
                        sql += " "+ p_valor + ", ";
                    }
                    sql += "'" + p_concorrentes + "', ";
                    sql += "" + p_resp_padrao_solucao + ", ";
                    sql += "" + p_frete + ", ";
                    sql += "" + p_faturamento + ", ";
                    sql += "" + p_destino_material + ", ";
                    sql += "'" + p_contICMS + "', ";
                    sql += "'" + p_incentFiscal + "', ";
                    sql += "'" + p_desc_incentivo + "', ";
                    sql += "'" + p_forma_pagamento + "', ";
                    sql += "'" + p_financiamento + "', ";
                    sql += "'" + p_instFinanceira + "', ";
                    sql += "'" + p_indic_empr_codigo + "', ";
                    sql += "" + p_indic_dpes_codigo + ", ";
                    sql += "" + p_indic_comissao + ", ";
                    sql += "" + p_desconto + ", ";
                    sql += "" + p_moeda + ", ";
                    sql += "@p_data2, "; //DT_PROPOSTA
                    sql += "" + p_empr_repres + ", ";
                    sql += "" + p_cod_repres + ", ";
                    sql += "'" + pAliqImposto + "', ";
                    sql += "'" + pTaxaFlat + "', ";

                    sql += "'" + p_maoObraCli + "', ";
                    sql += "'" + p_tipoMaoObraCli + "', ";
                    sql += "'" + p_indExportacao + "', ";
                    sql += "'" + p_indRespZelo + "', ";
                    sql += "'" + p_indEngResidente + "', ";
                    sql += "'" + p_TecSeguranca + "', ";
                    sql += "'" + p_SegRespCivil + "', ";
                    sql += "'" + p_Plataforma + "', ";
                    sql += "'" + p_Databook + "', ";
                    sql += "'" + p_indTreinamentos + "', ";
                    sql += "'" + p_CanteiroObras + "', ";
                    sql += "'" + p_OutraNecessidade + "', ";
                    if (string.IsNullOrEmpty(p_DescOutraNecessidade))
                    {
                        sql += " NULL) ";
                    }
                    else
                    {
                        sql += "'" + p_DescOutraNecessidade + "') ";
                    }
                    
                }
                else //U - Update
                {
                    sql += "UPDATE [DOM_SOLIC_ORCAMENTO] ";
                    sql += "    SET [STATUS] = '" + p_status_solic + "', ";
                    sql += "    [OBSERVACOES] = '" + p_observacao + "', ";
                    sql += "    [NOME_PROJETO] = '" + p_projeto + "', ";
                    sql += "    [DPES_CODIGO_CLI] = '" + p_cliente + "', ";
                    sql += "    [DPES_CODIGO_OBRA] = '" + p_obra + "',";
                    sql += "    [COD_CONT_TEC_CLI] = '" + p_cod_tecnico + "', ";
                    if (string.IsNullOrEmpty(p_dpes_cod_tecnico))
                    {
                        sql += "    [DPES_CONT_TEC_CLI] = NULL, ";
                    }
                    else
                    {
                        sql += "    [DPES_CONT_TEC_CLI] = " + p_dpes_cod_tecnico + ", ";
                    }
                    sql += "    [COD_CONT_COM_CLI] = '" + p_cod_comercial + "', ";
                    if (string.IsNullOrEmpty(p_dpes_cod_comercial))
                    {
                        sql += "    [DPES_COD_CONT_COM_CLI] = NULL, ";
                    }
                    else
                    {
                        sql += "    [DPES_COD_CONT_COM_CLI] = " + p_dpes_cod_comercial + ", ";
                    }                    
                    sql += "    [NEGOCIO_ASSOCIADO] = " + p_tipo_negocio + ", ";
                    sql += "    [FINALIDADE_PROPOSTA] = " + p_finalidade + ", ";
                    sql += "    [TIPO_EMPREENDIMENTO] = " + p_empreendimento + ", ";
                    sql += "    [IDIOMA_PROPOSTA] = " + p_idioma + ", ";
                    sql += "    [OUTRO_IDIOMA] = '" + p_outro_idioma + "', ";
                    sql += "    [DT_ENTREGA_OBRA] = @p_data1, ";
                    if (string.IsNullOrEmpty(p_valor))
                    {
                        sql += "    [VALOR_ESTIMADO] = NULL, ";
                    }
                    else
                    {
                        sql += "    [VALOR_ESTIMADO] = " + p_valor + ", ";
                    }                    
                    sql += "    [DESCRICAO_CONCORRENTES] = '" + p_concorrentes + "',";
                    sql += "    [RESP_PADRAO_VENDOR_LIST] = " + p_resp_padrao_solucao + ", ";
                    sql += "    [TIPO_FRETE] = " + p_frete + ", ";
                    sql += "    [INDIC_FATURAMENTO] = " + p_faturamento + ", ";
                    sql += "    [DESTINO_MATERIAL] = " + p_destino_material + ", ";
                    sql += "    [CLIENTE_CONTRIB_ICMS] = '" + p_contICMS + "', ";
                    sql += "    [CLIENTE_INCENTIVO_FISCAL] = '" + p_incentFiscal + "', ";
                    sql += "    [DESC_INCENTIVO_FISC] = '" + p_desc_incentivo + "', ";
                    sql += "    [FORMA_PAGAMENTO] = '" + p_forma_pagamento + "', ";
                    sql += "    [DESC_FINANCIAMENTO] = '" + p_financiamento + "', ";
                    sql += "    [INSTITUICAO_FINANCEIRA] = '" + p_instFinanceira + "', ";
                    sql += "    [INFORMAR_ALIQ_IMPOSTO] = '" + pAliqImposto + "', ";
                    sql += "    [CONSIDERAR_TAXA_FLAT] = '" + pTaxaFlat + "', ";
                    sql += "    [INDIC_EMPR_CODIGO] = '" + p_indic_empr_codigo + "', ";
                    sql += "    [INDIC_DPES_CODIGO] = " + p_indic_dpes_codigo + ", ";
                    sql += "    [INDIC_PERC_COMISSAO] = " + p_indic_comissao + ", ";
                    sql += "    [MARGEM_DESCONTO] = " + p_desconto + ", ";
                    sql += "    [MOEDA_PROPOSTA] = " + p_moeda + ", ";
                    sql += "    [DT_PROPOSTA] = @p_data2, ";

                    sql += "    [MAO_OBRA_CLIENTE] = '" + p_maoObraCli + "', ";
                    sql += "    [TIPO_MAO_OBRA] = " + p_tipoMaoObraCli + ", ";
                    sql += "    [IND_EXPORTACAO] = '" + p_indExportacao + "', ";
                    sql += "    [IND_RESP_ZELO_MATERIAL] = '" + p_indRespZelo + "', ";
                    sql += "    [IND_ENG_RESIDENTE] = '" + p_indEngResidente + "', ";
                    sql += "    [IND_TEC_SEGURANCA] = '" + p_TecSeguranca + "', ";
                    sql += "    [IND_SEG_RESP_CIVIL] = '" + p_SegRespCivil + "', ";
                    sql += "    [IND_PLATAFORMA] = '" + p_Plataforma + "', ";
                    sql += "    [IND_DATABOOK] = '" + p_Databook + "', ";
                    sql += "    [IND_TREINAMENTOS] = '" + p_indTreinamentos + "', ";
                    sql += "    [IND_CANTEIRO_OBRAS] = '" + p_CanteiroObras + "', ";
                    sql += "    [IND_OUTRA_NECESSIDADE] = '" + p_OutraNecessidade + "', ";
                    if (string.IsNullOrEmpty(p_DescOutraNecessidade))
                    {
                        sql += "    [DESC_OUTRA_NECESSIDADE] = NULL ";
                    }
                    else
                    {
                        sql += "    [DESC_OUTRA_NECESSIDADE] = '" + p_DescOutraNecessidade + "' ";
                    }                    

                    sql += " WHERE[NUMERO] = " + p_num_solic + " ";
                    sql += "AND[REPRES_EMPR_CODIGO] = " + p_empr_repres + " ";
                    sql += "AND[REPRES_DPES_CODIGO] = " + p_cod_repres + " ";
                    sql += "AND[REVISAO] = '" + p_revisao + "'";                    
                }          
                retorno = mBD.insertSOF(sql, p_dt_entrega_obra, p_dt_proposta);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Grava as condições de pagamento da solicitação
        /// </summary>
        /// <param name="p_NumSolic">Número da solicitação</param>
        /// <param name="p_RevSolic">Número da revisão da solicitação</param>
        /// <param name="p_SeqSolic">Sequência da condição de pagamento</param>
        /// <param name="p_CodEvento">Código do Evento de Pagamento</param>
        /// <param name="p_Percentual">Percentual correspondente</param>
        public void setPagamentosSolic(string p_NumSolic, string p_RevSolic, string p_SeqSolic, string p_CodEvento, string p_Percentual)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            try
            {
                string sql = "INSERT INTO [DOM_SOLIC_ORC_COND_PGTO] ";
                sql += "([NUMERO_SOLICITACAO], ";
                sql += "[REVISAO_SOLICITACAO], ";
                sql += "[SEQUENCIA], ";
                sql += "[COD_EVENTO_PAGTO], ";
                sql += "[PERC_CORRESPONDENTE]) ";
                sql += "VALUES ";
                sql += "(" + p_NumSolic + ", ";
                sql += "'" + p_RevSolic + "', ";
                sql += "" + p_SeqSolic + ", ";
                sql += "" + p_CodEvento + ", ";
                sql += "" + p_Percentual + ")";
                mBD.insertSOF(sql);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }

        
        /// <summary>
        /// Método que busca o Indicador de Negócio de uma solicitação
        /// </summary>
        /// <param name="p_num_solic"></param>
        /// <param name="p_rev_solic"></param>
        /// <param name="p_repres_empr_cod"></param>
        /// <returns></returns>
        public DataTable getIndicadorNegocioSolic(string p_num_solic, string p_rev_solic, string p_repres_empr_cod)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            try
            {
                string sql = "SELECT DSO.[INDIC_DPES_CODIGO], ";
                sql += " DIN.[RAZAO_SOCIAL] AS DESC_INDIC_NEGOCIO ";
                sql += " FROM [DOM_SOLIC_ORCAMENTO] DSO ";
                sql += " INNER JOIN [DOM_INDICADOR_NEGOCIO] DIN ON DSO.[INDIC_DPES_CODIGO] = DIN.[DPES_CODIGO] ";
                sql += " AND DSO.[REPRES_EMPR_CODIGO] = DIN.[EMPR_CODIGO] ";
                sql += " WHERE DSO.[REPRES_EMPR_CODIGO] = " + p_repres_empr_cod;
                sql += " AND DSO.[NUMERO] = " + p_num_solic;
                sql += " AND DSO.[REVISAO] = '" + p_rev_solic +"'";
                return mBD.selectListaSOF(sql, "DOM_SOLIC_ORCAMENTO");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Busca a lista de Condições de Pagamento de uma Solicitação
        /// </summary>
        /// <param name="p_num_solic">Número da solicitação</param>
        /// <param name="p_empr_cod">Código da empresa da solicitação/representante</param>
        /// <returns></returns>
        public DataTable getCondPagamentoSolic(string p_num_solic, string p_rev_solic, string p_empr_cod)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            try
            {
                string sql = "SELECT DCOND.SEQUENCIA, ";
                sql += " DEPGTO.CODIGO EVENTO, ";
                sql += " DEPGTO.DESCRICAO, ";
                sql += " DCOND.PERC_CORRESPONDENTE ";
                sql += "FROM DOM_SOLIC_ORC_COND_PGTO DCOND ";
                sql += " INNER JOIN DOM_EVENTO_PAGAMENTO DEPGTO ";
                sql += " ON DCOND.COD_EVENTO_PAGTO = DEPGTO.CODIGO ";
                sql += "WHERE DCOND.NUMERO_SOLICITACAO = " + p_num_solic;
                sql += "AND DCOND.REVISAO_SOLICITACAO = '" + p_rev_solic + "'";
                sql += "ORDER BY DCOND.SEQUENCIA ";
                return mBD.selectListaSOF(sql, "DOM_SOLIC_ORC_COND_PGTO");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Busca o percentual total das condições de pagamento já registradas
        /// </summary>
        /// <param name="p_num_solic">N° da solicitação</param>
        /// <param name="p_num_rev">N° da revisão</param>
        /// <returns></returns>
        public int getTotalPercentualCondPagto(string p_num_solic, string p_num_rev)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            try
            {
                string sql = "SELECT SUM([PERC_CORRESPONDENTE]) TOTAL ";
                sql += " FROM [DOM_SOLIC_ORC_COND_PGTO] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + p_num_solic;
                sql += " AND [REVISAO_SOLICITACAO] = '" + p_num_rev + "'";
                string total = mBD.selectSOF(sql);
                if (string.IsNullOrEmpty(total))
                {
                    return 0; //Retorno está em 0%
                }
                else
                    return Convert.ToInt32(total);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Retorna o percentual atual da condição de pagamento (Usado antes do update)
        /// </summary>
        /// <param name="p_num_solic"></param>
        /// <param name="p_num_rev"></param>
        /// <param name="p_sequencia"></param>
        public int getValorCondPgto(string p_num_solic, string p_revisao, string p_sequencia)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            int retorno;
            try
            {
                string sql = "SELECT [PERC_CORRESPONDENTE] ";
                sql += " FROM [DOM_SOLIC_ORC_COND_PGTO] ";
                sql += "WHERE [NUMERO_SOLICITACAO] = " + p_num_solic;
                sql += " AND [REVISAO_SOLICITACAO] = '" + p_revisao + "'";
                sql += " AND [SEQUENCIA] = " + p_sequencia;
                retorno = Convert.ToInt32(mBD.selectSOF(sql));
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }
        

        /// <summary>
        /// Edita o valor de uma condição de pagamento da solicitação de orçamento
        /// </summary>
        /// <param name="p_percent_corresp">Percentual de pagamento</param>
        /// <param name="p_num_solic">N° da solicitação</param>
        /// <param name="p_revisao">N° da revisão (geralmente 0)</param>
        /// <param name="p_sequencia">Sequência da condição de pagamento</param>
        public void atualizaCondPagamento(string p_percent_corresp, string p_num_solic, string p_revisao, string p_sequencia)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            int retorno;
            try
            {
                string sql = "UPDATE DOM_SOLIC_ORC_COND_PGTO ";
                sql += "SET [PERC_CORRESPONDENTE] = " + p_percent_corresp + " ";
                sql += "WHERE [NUMERO_SOLICITACAO] = " + p_num_solic;
                sql += "AND [REVISAO_SOLICITACAO] = '" + p_revisao + "'";
                sql += "AND [SEQUENCIA] = " + p_sequencia;
                retorno = mBD.insertSOF(sql);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Deleta registro de condição de pagamento
        /// </summary>
        /// <param name="p_num_solic">N° solicitação</param>
        /// <param name="p_num_rev_solic">N° revisão</param>
        /// <param name="p_seq">N° sequência</param>
        /// <returns></returns>
        public int deletaCondPagto(string p_num_solic, string p_num_rev_solic, string p_sequencia)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            int retorno;
            try
            {
                string sql = "DELETE FROM [DOM_SOLIC_ORC_COND_PGTO] ";
                sql += "WHERE [NUMERO_SOLICITACAO] = " + p_num_solic;
                sql += " AND [REVISAO_SOLICITACAO] = '" + p_num_rev_solic +"'";
                sql += " AND [SEQUENCIA] = " + p_sequencia;
                retorno = mBD.deleteSOF(sql);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Seleciona os dados da solicitação
        /// </summary>
        /// <param name="p_empr_cod"></param>
        /// <param name="p_num_solic"></param>
        /// <param name="p_rev_solic"></param>
        /// <returns></returns>
        public DataTable listaCabecalhoSolic(string p_empr_cod, string p_num_solic, string p_rev_solic, string p_FiltroBusca)
        {
            ManipulaBD mBD = new ManipulaBD();
            mBD.openConnection();
            string sql = "";
            try
            {
                if (!string.IsNullOrEmpty(p_FiltroBusca)) 
                {
                    sql += "SELECT DSO.[NUMERO], ";
                    sql += "DSO.[REVISAO], ";
                    sql += "DSO.[STATUS], ";
                    sql += "DC.RAZAO_SOCIAL + ' - ' + DSO.[DPES_CODIGO_CLI] AS CLIENTE, ";
                    sql += "DSO.[NEGOCIO_ASSOCIADO], ";
                    sql += "DSO.REPRES_EMPR_CODIGO AS EMPRESA, ";
                    sql += "DSO.[VALOR_ESTIMADO] ";
                    sql += "FROM [DOM_SOLIC_ORCAMENTO] DSO ";
                    //sql += "INNER JOIN [DOM_TIPO_NEGOCIO] DTN ON DTN.[CODIGO] = DSO.[NEGOCIO_ASSOCIADO] ";
                   // sql += "INNER JOIN [DOM_INDICADOR_NEGOCIO] DIN ON DSO.[INDIC_DPES_CODIGO] = DIN.[DPES_CODIGO] ";
                   // sql += "AND DSO.[REPRES_EMPR_CODIGO] = DIN.[EMPR_CODIGO] ";
                    sql += "INNER JOIN DOM_CLIENTE DC ON DC.COD_CLIENTE = DSO.[DPES_CODIGO_CLI] ";

                    if(p_FiltroBusca == "P") //Pendente
                    {
                        sql += " WHERE DSO.[STATUS] = 'P' ";
                    }
                    else if(p_FiltroBusca == "E") //Enviadas
                    {
                        sql += " WHERE DSO.[STATUS] = 'E' ";
                    }
                    sql += "ORDER BY DSO.[NUMERO]";
                }
                else
                {
                    sql += "SELECT DSO.[NUMERO] ";
                    sql += ",DSO.[REVISAO] ";
                    sql += ",DSO.[STATUS] ";
                    sql += ",DSO.[OBSERVACOES] ";
                    sql += ",DSO.[NOME_PROJETO] ";
                    sql += ",DSO.[DPES_CODIGO_CLI] ";
                    sql += ",DSO.[DPES_CODIGO_OBRA] ";
                    sql += ",DSO.[COD_CONT_TEC_CLI] ";
                    sql += ",DSO.[DPES_CONT_TEC_CLI] ";
                    sql += ",DSO.[COD_CONT_COM_CLI] ";
                    sql += ",DSO.[DPES_COD_CONT_COM_CLI] ";
                    sql += ",DSO.[NEGOCIO_ASSOCIADO] ";
                    sql += ",DTN.DESCRICAO ";
                    sql += ",DSO.[FINALIDADE_PROPOSTA] ";
                    sql += ",DSO.[TIPO_EMPREENDIMENTO] ";
                    sql += ",DSO.[IDIOMA_PROPOSTA] ";
                    sql += ",DSO.[OUTRO_IDIOMA] ";
                    sql += ",DSO.[DT_ENTREGA_OBRA] ";
                    sql += ",DSO.[VALOR_ESTIMADO] ";
                    sql += ",DSO.[DESCRICAO_CONCORRENTES] ";
                    sql += ",DSO.[RESP_PADRAO_VENDOR_LIST] ";
                    sql += ",DSO.[TIPO_FRETE] ";
                    sql += ",DSO.[INDIC_FATURAMENTO] ";
                    sql += ",DSO.[DESTINO_MATERIAL] ";
                    sql += ",DSO.[CLIENTE_CONTRIB_ICMS] ";
                    sql += ",DSO.[CLIENTE_INCENTIVO_FISCAL] ";
                    sql += ",DSO.[DESC_INCENTIVO_FISC] ";
                    sql += ",DSO.[FORMA_PAGAMENTO] ";
                    sql += ",DRC.[DESCRICAO] AS DESC_FORMA_PAG ";
                    sql += ",DSO.[DESC_FINANCIAMENTO] ";
                    sql += ",DSO.[INSTITUICAO_FINANCEIRA] ";
                    sql += ",DSO.[INDIC_EMPR_CODIGO] ";
                    sql += ",DSO.[INDIC_DPES_CODIGO] ";
               //     sql += ",DIN.[RAZAO_SOCIAL] AS DESC_INDIC_NEGOCIO ";
                    sql += ",DSO.[INDIC_PERC_COMISSAO] ";
                    sql += ",DSO.[MARGEM_DESCONTO] ";
                    sql += ",DSO.[MOEDA_PROPOSTA] ";
                    sql += ",DSO.[DT_PROPOSTA] ";
                    sql += ",DSO.[REPRES_EMPR_CODIGO] ";
                    sql += ",DSO.[REPRES_DPES_CODIGO] ";
                    sql += ",DSO.[INFORMAR_ALIQ_IMPOSTO] ";
                    sql += ",DSO.[CONSIDERAR_TAXA_FLAT] ";
                    sql += ",DSO.[MAO_OBRA_CLIENTE] ";
                    sql += ",DSO.[TIPO_MAO_OBRA] ";
                    sql += ",DSO.[IND_EXPORTACAO] ";
                    sql += ",DSO.[IND_RESP_ZELO_MATERIAL] ";
                    sql += ",DSO.[IND_ENG_RESIDENTE] ";
                    sql += ",DSO.[IND_TEC_SEGURANCA] ";
                    sql += ",DSO.[IND_SEG_RESP_CIVIL] ";
                    sql += ",DSO.[IND_PLATAFORMA] ";
                    sql += ",DSO.[IND_DATABOOK] ";
                    sql += ",DSO.[IND_TREINAMENTOS] ";
                    sql += ",DSO.[IND_CANTEIRO_OBRAS] ";
                    sql += ",DSO.[IND_OUTRA_NECESSIDADE] ";
                    sql += ",DSO.[DESC_OUTRA_NECESSIDADE] ";
                    sql += " FROM [DOM_SOLIC_ORCAMENTO] DSO ";
                    sql += " INNER JOIN [DOM_TIPO_NEGOCIO] DTN ON DTN.[CODIGO] = DSO.[NEGOCIO_ASSOCIADO] ";
                    //sql += " INNER JOIN [DOM_INDICADOR_NEGOCIO] DIN ON DSO.[INDIC_DPES_CODIGO] = DIN.[DPES_CODIGO] AND DSO.[REPRES_EMPR_CODIGO] = DIN.[EMPR_CODIGO] ";
                    sql += "INNER JOIN [DOMOBR_REF_CODES] DRC ON DRC.[VALOR] = DSO.[FORMA_PAGAMENTO] ";
                    sql += " WHERE [REPRES_EMPR_CODIGO] = " + p_empr_cod;
                    sql += " AND [NUMERO] = " + p_num_solic;
                    sql += " AND [REVISAO] = '" + p_rev_solic + "'";
                }
                return mBD.selectListaSOF(sql, "DOM_SOLIC_ORCAMENTO");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mBD.closeConnection();
            }
        }


    }
}
