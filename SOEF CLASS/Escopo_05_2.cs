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
                query += "   [TIPO_PINTURA_INVOLUCRO], ";
                query += "   [DESC_OUTRA_TENSAO_PRIM], ";
                query += "   [DESC_OUTRA_TENSAO_SECUN]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   " + pTensaoPrim + ", ";
                query += "   " + pTensaoSec + ", ";
                query += "   '" + pIndPotenciaInfDef + "', ";
                query += "   '" + pIndListaCargas + "', ";
                query += "   '" + pIndInvolucro + "', ";
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
                query += "   '" + pDescOutraTensaoPri + "', ";
                query += "   '" + pDescOutraTensaoSec + "') ";
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



    }
}
