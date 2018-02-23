using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_17_5:Escopo
    {
        /// <summary>
        /// Construtor Escopo 17_5
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_17_5(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }

        //Métodos CRUD Escopo 17_5

        /// <summary>
        /// Grava os dados do Escopo 17_5
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int gravaEscopo_17_5(string pPainelCLP, string pPainelRemota, string pTopologiaRede, string pListaIO, string pMemorialDesc, string pOutro, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_17_5] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [IND_PAINEL_CLP], ";
                query += "   [IND_PAINEL_REMOTA], ";
                query += "   [IND_TOPOLOGIA_REDE], ";
                query += "   [IND_LISTA_IO], ";
                query += "   [IND_MEMORIAL_DESCRITIVO], ";
                query += "   [IND_OUTRO], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + pPainelCLP + "', ";
                query += "   '" + pPainelRemota + "', ";
                query += "   '" + pTopologiaRede + "', ";
                query += "   '" + pListaIO + "', ";
                query += "   '" + pMemorialDesc + "', ";
                query += "   '" + pOutro + "', ";
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
        /// Atualiza os dados do Escopo 17_5
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int updateEscopo_17_5(string pPainelCLP, string pPainelRemota, string pTopologiaRede, string pListaIO, string pMemorialDesc, string pOutro, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_17_5] ";
                query += "   SET [IND_PAINEL_CLP] = '" + pPainelCLP + "', ";
                query += "       [IND_PAINEL_REMOTA] = '" + pPainelRemota + "', ";
                query += "       [IND_TOPOLOGIA_REDE] = '" + pTopologiaRede + "', ";
                query += "       [IND_LISTA_IO] = '" + pListaIO + "', ";
                query += "       [IND_MEMORIAL_DESCRITIVO] = '" + pMemorialDesc + "', ";
                query += "       [IND_OUTRO] = '" + pOutro + "', ";
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
        /// Busca os dados do Escopo 17_5
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_17_5()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = " SELECT E17_5.[NUMERO_SOLICITACAO], ";
                sql += " E17_5.[REVISAO_SOLICITACAO], ";
                sql += " E17_5.[IND_PAINEL_CLP], ";
                sql += " E17_5.[IND_PAINEL_REMOTA], ";
                sql += " E17_5.[IND_TOPOLOGIA_REDE], ";
                sql += " E17_5.[IND_LISTA_IO], ";
                sql += " DSOVC.[IND_MEMORIAL_DESCRITIVO], ";
                sql += " E17_5.[IND_OUTRO], ";
                sql += " E17_5.[OBSERVACOES], ";
                sql += " E17_5.[IND_PREENCHIDO] ";
                sql += " FROM [DOM_SOLIC_ORC_ESCOPO_17_5] as E17_5 ";
                sql += " INNER JOIN DOM_SOLIC_ORC_VALOR_COMUM as DSOVC ";
                sql += " ON DSOVC.IND_MEMORIAL_DESCRITIVO = E17_5.IND_MEMORIAL_DESCRITIVO ";
                sql += " WHERE E17_5.[NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND E17_5.[REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_17_5");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Apaga os dados do Escopo 17_5
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_17_5(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_17_5] ";
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
