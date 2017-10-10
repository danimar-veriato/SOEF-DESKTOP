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
        public int gravaEscopo_Valor_Comum_E01(string dadosAmbientais, string frequenciaHz, string outraFrequencia, string tipoPintura, string tipoInstalacao)
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
                query += "    [IND_INSTAL_ABRIG_TEMPO]) ";
                query += " VALUES ";
                query += " (" + Numero + ", ";
                query += " '" + Revisao + "', ";
                query += " '" + dadosAmbientais + "', ";
                query += " '" + frequenciaHz + "', ";
                query += " '" + outraFrequencia + "', ";
                query += " '" + tipoPintura + "', ";
                query += " '" + tipoInstalacao + "') ";
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
        public int atualizaEscopo_Valor_Comum_E01(string dadosAmbientais, string frequenciaHz, string outraFrequencia, string tipoPintura, string tipoInstalacao)
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
                query += "     [IND_INSTAL_ABRIG_TEMPO] = '" + tipoInstalacao + "' ";
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
                query += "     [IND_INSTAL_ABRIG_TEMPO] = NULL ";
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
                query += " SELECT [DADOS_AMBIENTAIS], [FREQUENCIA_HZ], [OUTRA_FREQUENCIA], [TIPO_PINTURA], [IND_INSTAL_ABRIG_TEMPO] ";
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
                query += " SELECT [TENSAO_TRIFASICA], [FREQUENCIA_HZ], [OUTRA_FREQUENCIA], [DADOS_AMBIENTAIS], [NORMATIVA_MAPA], [TIPO_PRODUTO], [OUTRO_PRODUTO] ";
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
                query += " SET [TENSAO_TRIFASICA_BT] = '" + dadosAmbientais + "', ";
                query += "     [FREQUENCIA_HZ] = " + frequenciaHz + ", ";
                query += "     [OUTRA_FREQUENCIA] = '" + outraFrequencia + "', ";
                query += "     [DADOS_AMBIENTAIS] = '" + dadosAmbientais + "', ";
                query += "     [NORMATIVA_MAPA] = '" + normativaMapa + "', ";
                query += "     [TIPO_PRODUTO] = '" + tipoProduto + "', ";
                query += "     [OUTRO_PRODUTO] = '" + outroProduto + "' ";
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
                query += " SET [TENSAO_TRIFASICA] = NULL ";
                query += "     [FREQUENCIA_HZ] = NULL, ";
                query += "     [OUTRA_FREQUENCIA] = NULL, ";
                query += "     [DADOS_AMBIENTAIS] = NULL, ";
                query += "     [NORMATIVA_MAPA] = NULL ";
                query += "     [TIPO_PRODUTO] = NULL ";
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




    }
}
