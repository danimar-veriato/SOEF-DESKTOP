using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_10_3: Escopo
    {
        /// <summary>
        /// Construtor do Escopo 10_3
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_10_3(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }


        //Métodos cadastro Renovadores de Ar

        /// <summary>
        /// Grava o registro na tabela DOM_SOLIC_ORC_RENOVADOR_AR
        /// </summary>
        /// <param name="pSeq"></param>
        /// <param name="pLocal"></param>
        /// <param name="pTag"></param>
        /// <param name="pIndRenovadorProjeto"></param>
        /// <param name="pComprimento"></param>
        /// <param name="pLargura"></param>
        /// <param name="pAltura"></param>
        /// <returns></returns>
        public int gravaRenovadoresAr(string pSeq, string pLocal, string pTag, string pIndRenovadorProjeto, string pComprimento, string pLargura, string pAltura)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_RENOVADOR_AR] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [SEQUENCIA], ";
                query += "   [LOCAL], ";
                query += "   [TAG], ";
                query += "   [IND_RENOVADOR_PROJETO], ";
                query += "   [COMPRIMENTO], ";
                query += "   [LARGURA], ";
                query += "   [ALTURA]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   " + pSeq + ", ";
                query += "   '" + pLocal + "', ";
                query += "   '" + pTag + "', ";
                query += "   '" + pIndRenovadorProjeto + "', ";
                query += "   " + pComprimento + ", ";
                query += "   " + pLargura + ", ";
                query += "   " + pAltura + ") ";
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
        /// Método que busca a última sequência cadastrada Renovadores de Ar
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int getSequencia(string pNumSolic, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            string retorno;
            try
            {
                string sql;
                sql = " SELECT MAX([SEQUENCIA]) ";
                sql += " FROM [DOM_SOLIC_ORC_RENOVADOR_AR] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + pNumSolic;
                sql += " AND [REVISAO_SOLICITACAO] = '" + pRevisao + "'";
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
        /// Deleta um ou todos os registros da tabela de Renovadores de Ar
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <param name="pSequencia"></param>
        /// <returns></returns>
        public int deleteRenovadoresAr(string pNumSolic, string pRevisao, string pSequencia)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = " DELETE FROM [DOM_SOLIC_ORC_RENOVADOR_AR] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + pNumSolic;
                sql += " AND [REVISAO_SOLICITACAO] = '" + pRevisao + "'";
                //Se não informou a sequência (apaga todos os registros daquela solicitação)
                if (!string.IsNullOrEmpty(pSequencia))
                {
                    sql += " AND [SEQUENCIA] = " + pSequencia;
                }
                return sqlce.deleteSOF(sql);
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
        /// Busca os Registros da Tabela de Renovadores de Ar
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public DataTable getRenovadoresAr(string pNumSolic, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT [NUMERO_SOLICITACAO], ";
                sql += " [REVISAO_SOLICITACAO], ";
                sql += " [SEQUENCIA] SEQ, ";
                sql += " [LOCAL], ";
                sql += " [TAG], ";
                sql += " [IND_RENOVADOR_PROJETO], ";
                sql += " [COMPRIMENTO], ";
                sql += " [LARGURA], ";
                sql += " [ALTURA] ";
                sql += " FROM [DOM_SOLIC_ORC_RENOVADOR_AR]";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + pNumSolic + " AND [REVISAO_SOLICITACAO] = '" + pRevisao + "'";
                sql += " ORDER BY [SEQUENCIA] ";

                return sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_RENOVADOR_AR");
            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    sqlce.closeConnection();
            //}
        }

        
        //Métodos Escopo 10_3


    }
}
