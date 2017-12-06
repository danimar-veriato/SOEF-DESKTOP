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
                if (string.IsNullOrEmpty(pComprimento))
                {
                    pComprimento = "NULL";
                }
                if (string.IsNullOrEmpty(pLargura))
                {
                    pLargura = "NULL";
                }
                if (string.IsNullOrEmpty(pAltura))
                {
                    pAltura = "NULL";
                }

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
        }


        //Métodos Escopo 10_3

        /// <summary>
        /// Grava dados Escopo 10_3
        /// </summary>
        /// <param name="pTensaoTrifasica"></param>
        /// <param name="pFrequencia"></param>
        /// <param name="pDescOutraFrequencia"></param>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPreenchido"></param>
        /// <returns></returns>
        public int gravaEscopo_10_3(string pTensaoTrifasica, string pFrequencia, string pDescOutraFrequencia, string pDadosAmbientais, string pObs, string pIndPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
              
                int retorno;
                string query = "";

                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_10_3] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [TENSAO_TRIFASICA], ";
                query += "   [FREQUENCIA], ";
                query += "   [DESC_OUTRA_FREQUENCIA], ";
                query += "   [DADOS_AMBIENTAIS], ";                
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   " + pTensaoTrifasica + ", ";
                query += "   " + pFrequencia + ", ";
                query += "   '" + pDescOutraFrequencia + "', ";
                query += "   '" + pDadosAmbientais + "', ";
                query += "   '" + pObs + "', ";
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
        /// Atualiza as informações Escopo 10_3
        /// </summary>
        /// <param name="pTensaoTrifasica"></param>
        /// <param name="pFrequencia"></param>
        /// <param name="pDescOutraFrequencia"></param>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPreenchido"></param>
        /// <returns></returns>
        public int updateEscopo_10_3(string pTensaoTrifasica, string pFrequencia, string pDescOutraFrequencia, string pDadosAmbientais, string pObs, string pIndPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_10_3] ";
                query += "   SET [DADOS_AMBIENTAIS] = '" + pDadosAmbientais + "',  ";
                query += "       [TENSAO_TRIFASICA] = " + pTensaoTrifasica + ", ";
                query += "       [FREQUENCIA] = " + pFrequencia + ", ";
                query += "       [DESC_OUTRA_FREQUENCIA] = '" + pDescOutraFrequencia + "', ";
                query += "       [OBSERVACOES] = '" + pObs + "', ";
                query += "       [IND_PREENCHIDO] = '" + pIndPreenchido + "' ";
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
        /// Busca os dados do Escopo 10_3
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
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_10_3] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_10_3");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Apaga os registros do Escopo 10_3
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_10_3(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_10_3] ";
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
