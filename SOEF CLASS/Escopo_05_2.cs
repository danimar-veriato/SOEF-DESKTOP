using SOEFC;
using System;
using System.Collections.Generic;
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
                    query += "   '" + pTipoPintura + "', ";
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



    }
}
