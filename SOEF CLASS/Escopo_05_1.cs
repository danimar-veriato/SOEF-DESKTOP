using SOEFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_05_1: Escopo
    {
        /// <summary>
        /// Construtor Escopo 05_1
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_05_1(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }


        //CRUD DOM_SOLIC_ORC_POTENC_ESCOPO

        /// <summary>
        /// Insere o registro na Potenc Escopo
        /// </summary>
        /// <param name="pEscopo"></param>
        /// <param name="pSequencia"></param>
        /// <param name="pQuantidade"></param>
        /// <param name="pPotKva"></param>
        /// <param name="pFatorK"></param>
        /// <param name="pModelo"></param>
        /// <returns></returns>
        public int gravaPotencEscopo(string pEscopo, string pSequencia, string pQuantidade, string pPotKva, string pFatorK, string pModelo)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_POTENC_ESCOPO] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [ESCOPO], ";
                query += "   [SEQUENCIA], ";
                query += "   [QUANTIDADE], ";
                query += "   [POTENCIA_KVA], ";
                query += "   [FATOR_K], ";
                query += "   [MODELO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + pEscopo + "', ";
                query += "   " + pSequencia + ", ";
                query += "   " + pQuantidade + ", ";
                query += "   '" + pPotKva + "', ";
                query += "   " + pFatorK + ", ";
                query += "   '" + pModelo + "') ";
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
        /// Busca a última sequência gravada
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <param name="pEscopo"></param>
        /// <returns></returns>
        public int getSequencia(string pNumSolic, string pRevisao, string pEscopo)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            string retorno;
            try
            {
                string sql;
                sql = " SELECT MAX([SEQUENCIA]) ";
                sql += " FROM [DOM_SOLIC_ORC_TAMPA_ESCOPO] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + pNumSolic;
                sql += " AND [REVISAO_SOLICITACAO] = '" + pRevisao + "'";
                sql += " AND [ESCOPO] = '" + pEscopo + "'";
                retorno = sqlce.selectSOF(sql);

                if (string.IsNullOrEmpty(retorno))
                {
                    retorno = "0";
                }

                return Convert.ToInt32(retorno);
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Método que remove um ou todos os registros da Potenc Escopo
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <param name="pEscopo"></param>
        /// <param name="pSequencia"></param>
        /// <returns></returns>
        public int deletePotencEscopo(string pNumero, string pRevisao, string pEscopo, string pSequencia)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_POTENC_ESCOPO] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + pNumero + " ";
                query += " AND [REVISAO_SOLICITACAO] = '" + pRevisao + "' ";
                query += " AND [ESCOPO] = '" + pEscopo + "' ";
                if (!string.IsNullOrEmpty(pSequencia))
                {
                    query += " AND [SEQUENCIA] = " + pSequencia + " ";
                }
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
