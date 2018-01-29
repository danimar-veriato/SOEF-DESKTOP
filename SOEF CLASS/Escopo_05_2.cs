using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_05_2: Escopo
    {
        /// <summary>
        /// Construtor Escopo 05_2
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_05_2(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }


        //CRUD Escopo 05_2

        public int gravaEscopo_05_2(string pTensaoPrim, string pTensaoSec, string pIndPotenciaInfDef, string pIndListaCargas, string pMeioIsolante, string pBuchaMT, string pBuchaBT, string pObs, string pIndPre, string pTipoPintura, string pDescOutraTensaoPri, string pDescOutraTensaoSec, string pDescOutraBuchaMT, string pDescOutraBuchaBT, string pDescMeioIsolante)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_05_2] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [TENSAO_PRIMARIA], ";
                query += "   [TENSAO_SECUNDARIA], ";
                query += "   [IND_POTENCIA_INFORM_DEF], ";
                query += "   [IND_LISTA_CARGAS], ";
                query += "   [MEIO_ISOLANTE], ";
                query += "   [BUCHAS_MT], ";
                query += "   [BUCHAS_BT], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO], ";
                query += "   [TIPO_PINTURA_MEIO_ISOLANTE], ";
                query += "   [DESC_OUTRA_TENSAO_PRIM], ";
                query += "   [DESC_OUTRA_TENSAO_SECUN], ";
                query += "   [DESC_OUTRA_BUCHA_MT], ";
                query += "   [DESC_OUTRA_BUCHA_BT], ";
                query += "   [DESC_OUTRO_MEIO_ISOLANTE]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   " + pTensaoPrim + ", ";
                query += "   " + pTensaoSec + ", ";
                query += "   '" + pIndPotenciaInfDef + "', ";
                query += "   '" + pIndListaCargas + "', ";
                query += "   " + pBuchaMT + ", ";
                query += "   " + pBuchaBT + ", ";
                query += "   '" + pObs + "', ";
                query += "   '" + pIndPre + "', ";
                if (string.IsNullOrEmpty(pTipoPintura))
                {
                   query += " NULL, ";
                }
                else
                {
                    query += " '" + pTipoPintura + "', ";
                }
                query += "   '" + pMeioIsolante + "', ";
                query += "   '" + pDescOutraTensaoPri + "', ";
                query += "   '" + pDescOutraTensaoSec + "', ";
                query += "   '" + pDescOutraBuchaMT + "', ";
                query += "   '" + pDescOutraBuchaMT + "', ";
                query += "   '" + pDescMeioIsolante + "') ";
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
        /// Atualiza as informações do Escopo 05_2
        /// </summary>
        /// <param name="pTensaoPrim"></param>
        /// <param name="pTensaoSec"></param>
        /// <param name="pIndPotenciaInfDef"></param>
        /// <param name="pIndListaCargas"></param>
        /// <param name="pMeioIsolante"></param>
        /// <param name="pBuchaMT"></param>
        /// <param name="pBuchaBT"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPre"></param>
        /// <param name="pTipoPintura"></param>
        /// <param name="pDescOutraTensaoPri"></param>
        /// <param name="pDescOutraTensaoSec"></param>
        /// <param name="pDescOutraBuchaMT"></param>
        /// <param name="pDescOutraBuchaBT"></param>
        /// <param name="pDescMeioIsolante"></param>
        /// <returns></returns>
        public int updateEscopo_05_2(string pTensaoPrim, string pTensaoSec, string pIndPotenciaInfDef, string pIndListaCargas, string pMeioIsolante, string pBuchaMT, string pBuchaBT, string pObs, string pIndPre, string pTipoPintura, string pDescOutraTensaoPri, string pDescOutraTensaoSec, string pDescOutraBuchaMT, string pDescOutraBuchaBT, string pDescMeioIsolante)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_05_2] ";
                query += "   SET [TENSAO_PRIMARIA] = " + pTensaoPrim + ", ";
                query += "       [TENSAO_SECUNDARIA] = " + pTensaoSec + ", ";
                query += "       [IND_POTENCIA_INFORM_DEF] = '" + pIndPotenciaInfDef + "', ";
                query += "       [IND_LISTA_CARGAS] = '" + pIndListaCargas + "', ";
                query += "       [MEIO_ISOLANTE] = " + pMeioIsolante + ", ";
                query += "       [BUCHAS_MT] = " + pBuchaMT + ", ";
                query += "       [BUCHAS_BT] = " + pBuchaBT + ", ";
                query += "       [OBSERVACOES] = '" + pObs + "', ";
                query += "       [IND_PREENCHIDO] = '" + pIndPre + "', ";
                if (string.IsNullOrEmpty(pTipoPintura))
                {
                    query += "       [TIPO_PINTURA_MEIO_ISOLANTE] = NULL, ";
                }
                else
                {
                    query += "       [TIPO_PINTURA_MEIO_ISOLANTE] = '" + pTipoPintura + "', ";
                }
                query += "       [DESC_OUTRA_TENSAO_PRIM] = " + pDescOutraTensaoPri + ", ";
                query += "       [DESC_OUTRA_TENSAO_SECUN] = " + pDescOutraTensaoSec + ", ";
                query += "       [DESC_OUTRA_BUCHA_MT] = '" + pDescOutraBuchaMT + "', ";
                query += "       [DESC_OUTRA_BUCHA_BT] = '" + pDescOutraBuchaBT + "' "; 
                query += "       [DESC_OUTRO_MEIO_ISOLANTE] = '" + pDescMeioIsolante + "' ";
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
        /// Busca os dados do Escopo 05_2
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_05_2()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_05_2] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_05_2");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int deleteEscopo_05_2(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_05_2] ";
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
        public int gravaPotencEscopo(string pEscopo, string pSequencia, string pQuantidade, string pPotKva, string pFatorK)
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
                query += "   [FATOR_K]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + pEscopo + "', ";
                query += "   " + pSequencia + ", ";
                query += "   " + pQuantidade + ", ";
                query += "   '" + pPotKva + "', ";
                if (string.IsNullOrEmpty(pFatorK))
                {
                    query += " NULL) ";
                }
                else
                {
                    query += "   " + pFatorK + ") ";
                }
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
        /// Busca os dados da tabela DOM_SOLIC_ORC_POTENC_ESCOPO
        /// </summary>
        /// <param name="pEscopo"></param>
        /// <param name="pSequencia"></param>
        /// <returns></returns>
        public DataTable getPotenciaEscopo(string pEscopo, string pSequencia)
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
                sql += " [QUANTIDADE], ";
                sql += " [POTENCIA_KVA], ";
                sql += " [FATOR_K] ";
                sql += " FROM [DOM_SOLIC_ORC_POTENC_ESCOPO] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                sql += " AND [ESCOPO] = '" + pEscopo + "' ";
                if (!string.IsNullOrEmpty(pSequencia))
                {
                    sql += " AND [SEQUENCIA] = " + pSequencia + " ";
                    sql += " ORDER BY [SEQ] ";
                }
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_TAMPA_ESCOPO");
                return dt;
            }
            catch (Exception)
            {
                throw;
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
                sql += " FROM [DOM_SOLIC_ORC_POTENC_ESCOPO] ";
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
