using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_17: Escopo
    {
        /// <summary>
        /// Construtor Escopo 17
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_17(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }


        //Métodos CRUD Escopo 17

        /// <summary>
        /// Grava os dados do Escopo 17
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int gravaEscopo_17(string pFinalidadeProj, string pDescOutraFinalidade, string pProjetoImplantacao, string pDescLayoutObra, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_17] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [IND_FINALIDADE_PROJETO], ";
                query += "   [DESC_OUTRA_FINALIDADE], ";
                query += "   [IND_PROJETO_IMPLANTACAO], ";
                query += "   [DESC_LAYOUT_OBRA], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + pFinalidadeProj + "', ";
                query += "   '" + pDescOutraFinalidade + "', ";
                query += "   '" + pProjetoImplantacao + "', ";
                query += "   '" + pDescLayoutObra + "', ";
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
        /// Atualiza os dados do Escopo 05_3
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int updateEscopo_17(string pFinalidadeProj, string pDescOutraFinalidade, string pProjetoImplantacao, string pDescLayoutObra, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_17] ";
                query += "   SET [IND_FINALIDADE_PROJETO] = '" + pFinalidadeProj + "', ";
                query += "       [DESC_OUTRA_FINALIDADE] = '" + pDescOutraFinalidade + "', ";
                query += "       [IND_PROJETO_IMPLANTACAO] = '" + pProjetoImplantacao + "', ";
                query += "       [DESC_LAYOUT_OBRA] = '" + pDescLayoutObra + "', ";
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
        /// Busca os dados do Escopo 17
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_17()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_17] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_17");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Apaga os dados do Escopo 17
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_17(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_17] ";
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
