using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_20 : Escopo
    {
        /// <summary>
        /// Construtor da Classe inicializa com o Número e Revisão da Solicitação
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="numRevisao"></param>
        public Escopo_20(string numSolicitacao, string numRevisao)
        {
            Numero = numSolicitacao;
            Revisao = numRevisao;
        }

        //Atributos Escopo 20
        private string sequencia { get; set; }
        private string titulo_escopo { get; set; }
        private string descricao_escopo { get; set; }
        private string ind_preenchido { get; set; }


        /// <summary>
        /// Método de inserção Escopo 20
        /// </summary>
        /// <param name="pSequencia">Sequência Registro Escopo</param>
        /// <param name="pTituloEscopo">Título do Escopo</param>
        /// <param name="pDescEscopo">Descrição do Escopo</param>
        /// <param name="pIndPreenchido">Indica se está preenchido ou não</param>
        /// <returns></returns>
        public int gravaEscopo20(string pSequencia, string pTituloEscopo, string pDescEscopo, string pIndPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO[DOM_SOLIC_ORC_ESCOPO_20] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [SEQUENCIA], ";
                query += "   [TITULO_ESCOPO], ";
                query += "   [DESCRICAO_ESCOPO], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   " + pSequencia + ", ";
                query += "   '" + pTituloEscopo + "', ";
                query += "   '" + pDescEscopo + "', ";
                query += "   '" + pIndPreenchido + "') ";
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
        /// Método que busca a última sequência cadastrada
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
                sql += " FROM [DOM_SOLIC_ORC_ESCOPO_20] ";
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
        
        public int getCabecalhoP(string pNumSolic, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            string retorno;
            try
            {
                string sql;
                sql = " SELECT MAX([SEQUENCIA]) ";
                sql += " FROM [DOM_SOLIC_ORC_ESCOPO_20] ";
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
        /// Busca os Registros do Escopo 20
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public DataTable getEscopo20(string pNumSolic, string pRevisao)
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
                sql += " [TITULO_ESCOPO], ";
                sql += " [DESCRICAO_ESCOPO], ";
                sql += " [IND_PREENCHIDO] ";
                sql += " FROM [DOM_SOLIC_ORC_ESCOPO_20]";
                sql += " WHERE NUMERO_SOLICITACAO = " + pNumSolic + " AND REVISAO_SOLICITACAO = '" + pRevisao + "'";
                sql += " ORDER BY [SEQUENCIA] ";

                return sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_20");
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

        /// <summary>
        /// Método que apaga um registro do Escopo 20
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <param name="pSequencia"></param>
        /// <returns></returns>
        public int deleteEscopo20(string pNumSolic, string pRevisao, string pSequencia)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_20] ";
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


    }
}
