using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_Valor_Comum: Escopo
    {
        /// <summary>
        /// Construtor da Classe Escopo_Valor_Comum
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_Valor_Comum(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }

        //Métodos CRUD


        //CRUD Table Valor Comum
        /// <summary>
        /// Busca os dados do Valor Comum
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComum(string numSolicitacao, string revSolicitacao)
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT * FROM ";
                query += " DOM_SOLIC_ORC_VALOR_COMUM ";
                query += " WHERE NUMERO_SOLICITACAO = " + Numero;
                query += " AND REVISAO_SOLICITACAO = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que apaga o registro da tabela DOM_SOLIC_ORC_VALOR_COMUM
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopoValorComum(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + pNumero + " ";
                query += " AND [REVISAO_SOLICITACAO] = '" + pRevisao + "' ";
                retorno = sqlce.deleteSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        

        //CRUD ESCOPO 01

        /// <summary>
        /// Grava dados na Tabela Valor Comum
        /// </summary>
        /// <param name="dadosAmbientais"></param>
        /// <param name="frequenciaHz"></param>
        /// <param name="outraFrequencia"></param>
        /// <param name="tipoPintura"></param>
        /// <param name="tipoInstalacao"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E01(string dadosAmbientais, string frequenciaHz, string outraFrequencia, string tipoPintura, string tipoInstalacao, string tensaoDistribuicao, string outraTensaoD)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [DADOS_AMBIENTAIS], ";
                query += "    [FREQUENCIA_HZ], ";
                query += "    [OUTRA_FREQUENCIA], ";
                query += "    [TIPO_PINTURA], ";
                query += "    [IND_INSTAL_ABRIG_TEMPO], ";
                query += "    [TENSAO_DISTRIBUICAO], ";
                query += "    [OUTRA_TENSAO_DISTRIB]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + dadosAmbientais + "', ";
                query += " '" + frequenciaHz + "', ";
                query += " '" + outraFrequencia + "', ";
                query += " '" + tipoPintura + "', ";
                query += " '" + tipoInstalacao + "', ";
                query += " " + tensaoDistribuicao + ", ";
                query += " '" + outraTensaoD + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Atualiza os valores da tabela Escopo Valor Comum
        /// </summary>
        /// <param name="dadosAmbientais"></param>
        /// <param name="frequenciaHz"></param>
        /// <param name="outraFrequencia"></param>
        /// <param name="tipoPintura"></param>
        /// <param name="tipoInstalacao"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E01(string dadosAmbientais, string frequenciaHz, string outraFrequencia, string tipoPintura, string tipoInstalacao, string tensaoDistribuicao, string outraTensaoD)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [DADOS_AMBIENTAIS] = '" + dadosAmbientais + "', ";
                query += "     [FREQUENCIA_HZ] = '" + frequenciaHz + "', ";
                query += "     [OUTRA_FREQUENCIA] = '" + outraFrequencia + "', ";
                query += "     [TIPO_PINTURA] = '" + tipoPintura + "', ";
                query += "     [IND_INSTAL_ABRIG_TEMPO] = '" + tipoInstalacao + "', ";
                query += "     [TENSAO_DISTRIBUICAO] = " + tensaoDistribuicao + ", ";
                query += "     [OUTRA_TENSAO_DISTRIB] = '" + outraTensaoD + "' ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Define como NULL os campos dos valores comuns referentes ao Escopo 01
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E01()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [DADOS_AMBIENTAIS] = NULL, ";
                query += "     [FREQUENCIA_HZ] = NULL, ";
                query += "     [OUTRA_FREQUENCIA] = NULL, ";
                query += "     [TIPO_PINTURA] = NULL, ";
                query += "     [IND_INSTAL_ABRIG_TEMPO] = NULL, ";
                query += "     [TENSAO_DISTRIBUICAO] = NULL, ";
                query += "     [OUTRA_TENSAO_DISTRIB] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Busca os campos da DOM_SOLIC_ORC_VALOR_COMUM utilizados no ESCOPO 01
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE01(string numSolicitacao, string revSolicitacao)
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [DADOS_AMBIENTAIS], [FREQUENCIA_HZ], [OUTRA_FREQUENCIA], [TIPO_PINTURA], [IND_INSTAL_ABRIG_TEMPO], [TENSAO_DISTRIBUICAO], [OUTRA_TENSAO_DISTRIB] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        //CRUD ESCOPO 05

        /// <summary>
        /// Grava os campos do Escopo 05 na tabela VALOR_COMUM
        /// </summary>
        /// <param name="dadosAmbientais"></param>
        /// <param name="frequenciaHz"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E05(string dadosAmbientais, string frequenciaHz)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [DADOS_AMBIENTAIS], ";
                query += "    [FREQUENCIA_HZ]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + dadosAmbientais + "', ";
                query += " '" + frequenciaHz + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Atualiza os campos do Escopo 05 na tabela VALOR_COMUM
        /// </summary>
        /// <param name="dadosAmbientais"></param>
        /// <param name="frequenciaHz"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E05(string dadosAmbientais, string frequenciaHz)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [DADOS_AMBIENTAIS] = '" + dadosAmbientais + "', ";
                query += "     [FREQUENCIA_HZ] = '" + frequenciaHz + "' ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Apaga (SETA COMO NULL) os campos do Escopo 05
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E05()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [DADOS_AMBIENTAIS] = NULL, ";
                query += "     [FREQUENCIA_HZ] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca os campos utilizados pelo Escopo 05 na VALOR_COMUM
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE05(string numSolicitacao, string revSolicitacao)
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [DADOS_AMBIENTAIS], [FREQUENCIA_HZ] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //CRUD ESCOPO 05_1

        /// <summary>
        /// Grava o registro do Escopo 05_1
        /// </summary>
        /// <param name="pTipoPintura"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E05_1(string pTipoPintura)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [TIPO_PINTURA]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + pTipoPintura + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Atualiza o registro do Escopo 05_1 na tabela de valores comuns
        /// </summary>
        /// <param name="pTipoPintura"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E05_1(string pTipoPintura)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                if (string.IsNullOrEmpty(pTipoPintura))
                {
                    query += " SET [TIPO_PINTURA] = NULL ";
                }
                else
                {
                    query += " SET [TIPO_PINTURA] = '" + pTipoPintura + "' ";
                }
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Apaga (SETA COMO NULL) os campos do Escopo 05_1
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E05_1()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [TIPO_PINTURA] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca os campos utilizados pelo Escopo 05_1 na VALOR_COMUM
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE05_1()
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [TIPO_PINTURA] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //CRUD ESCOPO 5_2

        /// <summary>
        /// Grava Escopo 05_2
        /// </summary>
        /// <param name="pTipoPintura"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E05_2(string pTipoPintura)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [TIPO_PINTURA]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + pTipoPintura + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Atualiza o registro do Escopo 05_2 na tabela de valores comuns
        /// </summary>
        /// <param name="pTipoPintura"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E05_2(string pTipoPintura)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                if (string.IsNullOrEmpty(pTipoPintura))
                {
                    query += " SET [TIPO_PINTURA] = NULL ";
                }
                else
                {
                    query += " SET [TIPO_PINTURA] = '" + pTipoPintura + "' ";
                }
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Apaga (SETA COMO NULL) os campos do Escopo 05_2
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E05_2()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [TIPO_PINTURA] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca os campos utilizados pelo Escopo 05_2 na VALOR_COMUM
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE05_2()
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [TIPO_PINTURA] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        


        //CRUD ESCOPO 10_1
        /// <summary>
        /// Grava os valores comuns do Escopo 10_1
        /// </summary>
        /// <param name="tensaoTrifasica"></param>
        /// <param name="frequenciaHz"></param>
        /// <param name="outraFrequencia"></param>
        /// <param name="dadosAmbientais"></param>
        /// <param name="normativaMapa"></param>
        /// <param name="tipoProduto"></param>
        /// <param name="outroProduto"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E10_1(string tensaoTrifasica, string frequenciaHz, string outraFrequencia, string dadosAmbientais, string normativaMapa, string tipoProduto, string outroProduto)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [TENSAO_TRIFASICA_BT], ";
                query += "    [FREQUENCIA_HZ], ";
                query += "    [OUTRA_FREQUENCIA], ";
                query += "    [DADOS_AMBIENTAIS], ";
                query += "    [NORMATIVA_MAPA], ";
                query += "    [TIPO_PRODUTO], ";
                query += "    [OUTRO_PRODUTO]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + tensaoTrifasica + "', ";
                query += " '" + frequenciaHz + "', ";
                query += " '" + outraFrequencia + "', ";
                query += " '" + dadosAmbientais + "', ";
                query += " '" + normativaMapa + "', ";
                query += " '" + tipoProduto + "', ";
                query += " '" + outroProduto + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Busca os campos comuns utilizados no ESCOPO 10_1
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE10_1(string numSolicitacao, string revSolicitacao)
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [TENSAO_TRIFASICA_BT], ";
                query += " [FREQUENCIA_HZ], ";
                query += " [OUTRA_FREQUENCIA], ";
                query += " [DADOS_AMBIENTAIS], ";
                query += " [NORMATIVA_MAPA], ";
                query += " [TIPO_PRODUTO], ";
                query += " [OUTRO_PRODUTO] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Atualiza os campos do Escopo 10_1
        /// </summary>
        /// <param name="tensaoTrifasica"></param>
        /// <param name="frequenciaHz"></param>
        /// <param name="outraFrequencia"></param>
        /// <param name="dadosAmbientais"></param>
        /// <param name="normativaMapa"></param>
        /// <param name="tipoProduto"></param>
        /// <param name="outroProduto"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E10_1(string tensaoTrifasica, string frequenciaHz, string outraFrequencia, string dadosAmbientais, string normativaMapa, string tipoProduto, string outroProduto)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [TENSAO_TRIFASICA_BT] = '" + tensaoTrifasica + "', ";
                query += "     [FREQUENCIA_HZ] = " + frequenciaHz + ", ";
                query += "     [OUTRA_FREQUENCIA] = '" + outraFrequencia + "', ";
                query += "     [DADOS_AMBIENTAIS] = '" + dadosAmbientais + "', ";
                query += "     [NORMATIVA_MAPA] = '" + normativaMapa + "', ";
                query += "     [TIPO_PRODUTO] = '" + tipoProduto + "', ";
                query += "     [OUTRO_PRODUTO] = '" + outroProduto + "' ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query, null, null);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Deleta (deixa nulo) os campos do Escopo 10_1
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E10_1()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [TENSAO_TRIFASICA_BT] = NULL, ";
                query += "     [FREQUENCIA_HZ] = NULL, ";
                query += "     [OUTRA_FREQUENCIA] = NULL, ";
                query += "     [DADOS_AMBIENTAIS] = NULL, ";
                query += "     [NORMATIVA_MAPA] = NULL, ";
                query += "     [TIPO_PRODUTO] = NULL, ";
                query += "     [OUTRO_PRODUTO] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        

        //CRUD Escopo 10_2

        /// <summary>
        /// Grava valores comuns Escopo 10_2
        /// </summary>
        /// <param name="dadosAmbientais"></param>
        /// <param name="tipoProduto"></param>
        /// <param name="outroProduto"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E10_2(string dadosAmbientais, string tipoProduto, string outroProduto)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [DADOS_AMBIENTAIS], ";
                query += "    [TIPO_PRODUTO], ";
                query += "    [OUTRO_PRODUTO]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + dadosAmbientais + "', ";
                query += " '" + tipoProduto + "', ";
                query += " '" + outroProduto + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca os campos comuns utilizados no ESCOPO 10_2
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE10_2(string numSolicitacao, string revSolicitacao)
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [DADOS_AMBIENTAIS], [TIPO_PRODUTO], [OUTRO_PRODUTO] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Atualiza os campos do Escopo 10_2
        /// </summary>
        /// <param name="dadosAmbientais"></param>
        /// <param name="tipoProduto"></param>
        /// <param name="outroProduto"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E10_2(string dadosAmbientais, string tipoProduto, string outroProduto)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [DADOS_AMBIENTAIS] = '" + dadosAmbientais + "', ";
                query += "     [TIPO_PRODUTO] = '" + tipoProduto + "', ";
                query += "     [OUTRO_PRODUTO] = '" + outroProduto + "' ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query, null, null);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Deleta (deixa nulo) os campos do Escopo 10_2
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E10_2()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [DADOS_AMBIENTAIS] = NULL, ";
                query += "     [TIPO_PRODUTO] = NULL, ";
                query += "     [OUTRO_PRODUTO] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }


        //CRUD Escopo 10_3

        /// <summary>
        /// Grava valores comuns Escopo 10_3
        /// </summary>
        /// <param name="dadosAmbientais"></param>
        /// <param name="tensaoTrif"></param>
        /// <param name="frequencia"></param>
        /// <param name="outraFreq"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E10_3(string dadosAmbientais, string tensaoTrif, string frequencia, string outraFreq)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [DADOS_AMBIENTAIS], ";
                query += "    [TENSAO_TRIFASICA_BT], ";
                query += "    [FREQUENCIA_HZ], ";
                query += "    [OUTRA_FREQUENCIA]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + dadosAmbientais + "', ";
                query += " " + tensaoTrif + ", ";
                query += " " + frequencia + ", ";
                query += " '" + outraFreq + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca valores comuns Escopo 10_3
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE10_3(string numSolicitacao, string revSolicitacao)
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [DADOS_AMBIENTAIS], ";
                query += " [TENSAO_TRIFASICA_BT], ";
                query += " [FREQUENCIA_HZ], ";
                query += " [OUTRA_FREQUENCIA] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Atualiza campos valores comuns Escopo 10_3
        /// </summary>
        /// <param name="dadosAmbientais"></param>
        /// <param name="tensaoTrif"></param>
        /// <param name="frequencia"></param>
        /// <param name="outraFreq"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E10_3(string dadosAmbientais, string tensaoTrif, string frequencia, string outraFreq)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [DADOS_AMBIENTAIS] = '" + dadosAmbientais + "', ";
                query += "     [TENSAO_TRIFASICA_BT] = '" + tensaoTrif + "', ";
                query += "     [FREQUENCIA_HZ] = '" + frequencia + "', ";
                query += "     [OUTRA_FREQUENCIA] = '" + outraFreq + "' ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query, null, null);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Deleta (deixa nulo) os campos comuns Escopo 10_3
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E10_3()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [DADOS_AMBIENTAIS] = NULL, ";
                query += "     [TENSAO_TRIFASICA_BT] = NULL, ";
                query += "     [FREQUENCIA_HZ] = NULL, ";
                query += "     [OUTRA_FREQUENCIA] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        //CRUD Escopo 17_1

        /// <summary>
        /// Grava valores do Escopo 17_1
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E17_1(string pMemorialDescritivo)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [IND_MEMORIAL_DESCRITIVO]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + pMemorialDescritivo + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Atualiza o registro do Escopo 17_1 na tabela de valores comuns
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E17_1(string pMemorialDescritivo)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                if (string.IsNullOrEmpty(pMemorialDescritivo))
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL ";
                }
                else
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = '" + pMemorialDescritivo + "' ";
                }
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Apaga (SETA COMO NULL) os campos do Escopo 17_1
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E17_1()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca os campos utilizados pelo Escopo 17_1 na VALOR_COMUM
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE17_1()
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [IND_MEMORIAL_DESCRITIVO] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        //CRUD Escopo 17_2

        /// <summary>
        /// Grava valores do Escopo 17_2
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E17_2(string pMemorialDescritivo, string pListaMateriais)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [IND_MEMORIAL_DESCRITIVO], ";
                query += "    [IND_LISTA_MATERIAIS]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + pMemorialDescritivo + "', ";
                query += " '" + pListaMateriais + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Atualiza o registro do Escopo 17_2 na tabela de valores comuns
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E17_2(string pMemorialDescritivo, string pListaMateriais)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                if (string.IsNullOrEmpty(pMemorialDescritivo))
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL, ";
                }
                else
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = '" + pMemorialDescritivo + "', ";
                }
                if (string.IsNullOrEmpty(pListaMateriais))
                {
                    query += " SET [IND_LISTA_MATERIAIS] = NULL, ";
                }
                else
                {
                    query += " SET [IND_LISTA_MATERIAIS] = '" + pListaMateriais + "', ";
                }
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Apaga (SETA COMO NULL) os campos do Escopo 17_2
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E17_2()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL, ";
                query += "     [IND_LISTA_MATERIAIS] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca os campos utilizados pelo Escopo 17_1 na VALOR_COMUM
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE17_2()
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [IND_MEMORIAL_DESCRITIVO], [IND_LISTA_MATERIAIS] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //CRUD Escopo 17_3

        /// <summary>
        /// Grava valores do Escopo 17_3
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E17_3(string pMemorialDescritivo, string pListaMateriais)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [IND_MEMORIAL_DESCRITIVO], ";
                query += "    [IND_LISTA_MATERIAIS]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + pMemorialDescritivo + "', ";
                query += " '" + pListaMateriais + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Atualiza o registro do Escopo 17_3 na tabela de valores comuns
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E17_3(string pMemorialDescritivo, string pListaMateriais)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                if (string.IsNullOrEmpty(pMemorialDescritivo))
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL, ";
                }
                else
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = '" + pMemorialDescritivo + "', ";
                }
                if (string.IsNullOrEmpty(pListaMateriais))
                {
                    query += " [IND_LISTA_MATERIAIS] = NULL ";
                }
                else
                {
                    query += " [IND_LISTA_MATERIAIS] = '" + pListaMateriais + "' ";
                }
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }
        
        /// <summary>
        /// Apaga (SETA COMO NULL) os campos do Escopo 17_3
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E17_3()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL, ";
                query += "     [IND_LISTA_MATERIAIS] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca os campos utilizados pelo Escopo 17_3 na VALOR_COMUM
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE17_3()
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [IND_MEMORIAL_DESCRITIVO], [IND_LISTA_MATERIAIS] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //CRUD Escopo 17_4

        /// <summary>
        /// Grava valores do Escopo 17_4
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E17_4(string pMemorialDescritivo)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [IND_MEMORIAL_DESCRITIVO]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + pMemorialDescritivo + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Atualiza o registro do Escopo 17_4 na tabela de valores comuns
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E17_4(string pMemorialDescritivo)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                if (string.IsNullOrEmpty(pMemorialDescritivo))
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL ";
                }
                else
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = '" + pMemorialDescritivo + "' ";
                }
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Apaga (SETA COMO NULL) os campos do Escopo 17_4
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E17_4()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca os campos utilizados pelo Escopo 17_4 na VALOR_COMUM
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE17_4()
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [IND_MEMORIAL_DESCRITIVO] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //CRUD Escopo 17_5

        /// <summary>
        /// Grava valores do Escopo 17_5
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int gravaEscopo_Valor_Comum_E17_5(string pMemorialDescritivo)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += "    ([NUMERO_SOLICITACAO], ";
                query += "    [REVISAO_SOLICITACAO], ";
                query += "    [IND_MEMORIAL_DESCRITIVO]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + pMemorialDescritivo + "') ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Atualiza o registro do Escopo 17_5 na tabela de valores comuns
        /// </summary>
        /// <param name="pMemorialDescritivo"></param>
        /// <returns></returns>
        public int atualizaEscopo_Valor_Comum_E17_5(string pMemorialDescritivo)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                if (string.IsNullOrEmpty(pMemorialDescritivo))
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL ";
                }
                else
                {
                    query += " SET [IND_MEMORIAL_DESCRITIVO] = '" + pMemorialDescritivo + "' ";
                }
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Apaga (SETA COMO NULL) os campos do Escopo 17_5
        /// </summary>
        /// <returns></returns>
        public int deleteEscopo_Valor_Comum_E17_5()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno = 0;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " SET [IND_MEMORIAL_DESCRITIVO] = NULL ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + "";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                retorno = sqlce.insertSOF(query);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlce.closeConnection();
            }
        }

        /// <summary>
        /// Busca os campos utilizados pelo Escopo 17_5 na VALOR_COMUM
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        /// <returns></returns>
        public DataTable buscaEscopoValorComumE17_5()
        {
            DataTable dt = new DataTable();
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [IND_MEMORIAL_DESCRITIVO] ";
                query += " FROM [DOM_SOLIC_ORC_VALOR_COMUM] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero;
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(query, "DOM_SOLIC_ORC_VALOR_COMUM");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
