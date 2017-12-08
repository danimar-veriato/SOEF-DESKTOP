using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    class Escopo_10_4 : Escopo
    {
        /// <summary>
        /// Construtor do Escopo 10_4
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_10_4(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }

        //Métodos do Escopo 10_4

        /// <summary>
        /// Grava os dados do Escopo 10_4
        /// </summary>
        /// <param name="pMaterialTampa"></param>
        /// <param name="pQuantidade"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int gravaEscopo_10_4(string pMaterialTampa, string pQuantidade, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {

                int retorno;
                string query = "";

                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_10_4] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [MATERIAL_TAMPA], ";
                query += "   [QUANTIDADE], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   " + pMaterialTampa + ", ";
                query += "   " + pQuantidade + ", ";
                query += "   '" + pObs + "', ";
                query += "   '" + pIndPre + "') ";
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
        /// Atualiza os dados do Escopo 10_4
        /// </summary>
        /// <param name="pMaterialTampa"></param>
        /// <param name="pQuantidade"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int updateEscopo_10_3(string pMaterialTampa, string pQuantidade, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_10_4] ";
                query += "   SET [MATERIAL_TAMPA] = '" + pMaterialTampa + "',  ";
                query += "       [QUANTIDADE] = " + pQuantidade + ", ";
                query += "       [OBSERVACOES] = '" + pObs + "', ";
                query += "       [IND_PREENCHIDO] = '" + pIndPre + "' ";
                query += "  WHERE [NUMERO_SOLICITACAO] = " + Numero + " AND  [REVISAO_SOLICITACAO] = '" + Revisao + "'";
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
        /// Busca os dados do Escopo 10_4
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_10_3()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_10_4] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_10_4");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta os dados do Escopo 10_4
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_10_4(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_10_4] ";
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


        //Métodos DOM_SOLIC_ORC_TAMPA_ESCOPO

        /// <summary>
        /// Grava informações Tampa Escopo 10_4
        /// </summary>
        /// <param name="pEscopo"></param>
        /// <param name="pSequencia"></param>
        /// <param name="pQuantidade"></param>
        /// <param name="pTipoTampa"></param>
        /// <param name="pComprimento"></param>
        /// <param name="pLargura"></param>
        /// <returns></returns>
        public int gravaTampaEscopo10_4(string pEscopo, string pSequencia, string pQuantidade, string pTipoTampa, string pComprimento, string pLargura)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {

                int retorno;
                string query = "";

                query += " INSERT INTO [DOM_SOLIC_ORC_TAMPA_ESCOPO] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [ESCOPO], ";
                query += "   [SEQUENCIA], ";
                query += "   [QUANTIDADE], ";
                query += "   [TIPO_TAMPA], ";
                query += "   [COMPRIMENTO], ";
                query += "   [LARGURA]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + pEscopo + "', ";
                query += "   " + pSequencia + ", ";
                query += "   " + pQuantidade + ", ";
                query += "   '" + pTipoTampa + "', ";
                query += "   " + pComprimento + ", ";
                query += "   " + pLargura + ") ";
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
        /// Atualiza dados da tabela Tampa Escopo
        /// </summary>
        /// <param name="pEscopo"></param>
        /// <param name="pSequencia"></param>
        /// <param name="pQuantidade"></param>
        /// <param name="pTipoTampa"></param>
        /// <param name="pComprimento"></param>
        /// <param name="pLargura"></param>
        /// <returns></returns>
        public int updateTampaEscopo10_4(string pEscopo, string pSequencia, string pQuantidade, string pTipoTampa, string pComprimento, string pLargura)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_TAMPA_ESCOPO] ";
                query += "   SET [QUANTIDADE] = " + pQuantidade + ",  ";
                query += "       [TIPO_TAMPA] = '" + pTipoTampa + "', ";
                query += "       [COMPRIMENTO] = " + pComprimento + ", ";
                query += "       [LARGURA] = " + pLargura + " ";
                query += "  WHERE [NUMERO_SOLICITACAO] = " + Numero + " AND  [REVISAO_SOLICITACAO] = '" + Revisao + "'";
                query += " AND  [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                query += " AND  [ESCOPO] = '" + pEscopo + "' ";
                query += " AND  [SEQUENCIA] = " + pSequencia + " ";
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
        /// Busca os dados da Tampa Escopo
        /// </summary>
        /// <returns></returns>
        public DataTable getTampaEscopo(string pEscopo, string pSequencia)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_TAMPA_ESCOPO] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                sql += " AND [ESCOPO] = '" + pEscopo + "' ";
                sql += " AND [SEQUENCIA] = " + pSequencia + " ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_TAMPA_ESCOPO");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Apaga o registro da Tampa Escopo
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <param name="pEscopo"></param>
        /// <param name="pSequencia"></param>
        /// <returns></returns>
        public int deleteTampaEscopo(string pNumero, string pRevisao, string pEscopo, string pSequencia)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_TAMPA_ESCOPO] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + pNumero + " ";
                query += " AND [REVISAO_SOLICITACAO] = '" + pRevisao + "' ";
                query += " AND [ESCOPO] = '" + pEscopo + "' ";
                query += " AND [SEQUENCIA] = " + pSequencia + " ";
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
