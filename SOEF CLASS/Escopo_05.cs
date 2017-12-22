using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_05 : Escopo
    {
        /// <summary>
        /// Construtor Escopo 05
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_05(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }

        //Métodos CRUD Escopo 05

        /// <summary>
        /// Grava os dados do Escopo 05
        /// </summary>
        /// <param name="pFrequencia"></param>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int gravaEscopo_05(string pFrequencia, string pDadosAmbientais, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_05] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [FREQUENCIA_TRANSF], ";
                query += "   [DADOS_AMBIENTAIS], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   " + pFrequencia + ", ";
                query += "   '" + pDadosAmbientais + "', ";
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
        /// Atualiza dos dados do Escopo 05
        /// </summary>
        /// <param name="pFrequencia"></param>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int updateEscopo_05(string pFrequencia, string pDadosAmbientais, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_05] ";
                query += "   SET [FREQUENCIA_TRANSF] = " + pFrequencia + ", ";
                query += "       [DADOS_AMBIENTAIS] = '" + pDadosAmbientais + "', ";
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
        /// Busca os dados do Escopo 05
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_05()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_05] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_05");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deleta o registro do Escopo 05
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_05(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_05] ";
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
