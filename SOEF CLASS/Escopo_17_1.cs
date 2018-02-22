using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_17_1:Escopo
    {
        /// <summary>
        /// Construtor Escopo 17_1
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_17_1(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }


        //Métodos CRUD Escopo 17_1

        /// <summary>
        /// Grava os dados do Escopo 17_1
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int gravaEscopo_17_1(string pSubstacaoBlidada, string pQuadroBaixaTensao, string pConjCorrecFP, string pPainelContMotores, string pQuadroDistribIluminacao, string pPainelSinotico, string pPainelComandoLocal, string pMemorialDesc, string pIndOutro, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_17_1] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [IND_SUBSTACAO_BLINDADA], ";
                query += "   [IND_QUADRO_GER_BAIXA_TENSAO], ";
                query += "   [IND_CONJ_CORREC_FATOR_POT], ";
                query += "   [IND_PAINEL_CONT_MOTORES], ";
                query += "   [IND_QUADRO_DISTRIB_ILUMINACAO], ";
                query += "   [IND_PAINEL_SINOTICO], ";
                query += "   [IND_PAINEL_COMANDO_LOCAL], ";
                query += "   [IND_MEMORIAL_DESCRITIVO], ";
                query += "   [IND_OUTRO], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + pSubstacaoBlidada + "', ";
                query += "   '" + pQuadroBaixaTensao + "', ";
                query += "   '" + pConjCorrecFP + "', ";
                query += "   '" + pPainelContMotores + "', ";
                query += "   '" + pQuadroDistribIluminacao + "', ";
                query += "   '" + pPainelSinotico + "', ";
                query += "   '" + pPainelComandoLocal + "', ";
                query += "   '" + pMemorialDesc + "', ";
                query += "   '" + pIndOutro + "', ";
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
        /// Atualiza os dados do Escopo 17_1
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int updateEscopo_17_1(string pSubstacaoBlidada, string pQuadroBaixaTensao, string pConjCorrecFP, string pPainelContMotores, string pQuadroDistribIluminacao, string pPainelSinotico, string pPainelComandoLocal, string pMemorialDesc, string pIndOutro, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_17_1] ";
                query += "   SET [IND_SUBSTACAO_BLINDADA] = '" + pSubstacaoBlidada + "', ";
                query += "       [IND_QUADRO_GER_BAIXA_TENSAO] = '" + pQuadroBaixaTensao + "', ";
                query += "       [IND_CONJ_CORREC_FATOR_POT] = '" + pConjCorrecFP + "', ";
                query += "       [IND_PAINEL_CONT_MOTORES] = '" + pPainelContMotores + "', ";
                query += "       [IND_QUADRO_DISTRIB_ILUMINACAO] = '" + pQuadroDistribIluminacao + "', ";
                query += "       [IND_PAINEL_SINOTICO] = '" + pPainelSinotico + "', ";
                query += "       [IND_PAINEL_COMANDO_LOCAL] = '" + pPainelComandoLocal + "', ";
                query += "       [IND_MEMORIAL_DESCRITIVO] = '" + pMemorialDesc + "', ";
                query += "       [IND_OUTRO] = '" + pIndOutro + "', ";
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
        /// Busca os dados do Escopo 17_1
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_17_1()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = " SELECT E17_1.[NUMERO_SOLICITACAO], ";
                sql += " E17_1.[REVISAO_SOLICITACAO], ";
                sql += " E17_1.[IND_SUBSTACAO_BLINDADA], ";
                sql += " E17_1.[IND_QUADRO_GER_BAIXA_TENSAO], ";
                sql += " E17_1.[IND_CONJ_CORREC_FATOR_POT], ";
                sql += " E17_1.[IND_PAINEL_CONT_MOTORES], ";
                sql += " E17_1.[IND_QUADRO_DISTRIB_ILUMINACAO], ";
                sql += " E17_1.[IND_PAINEL_SINOTICO], ";
                sql += " E17_1.[IND_PAINEL_COMANDO_LOCAL], ";
                sql += " DSOVC.[IND_MEMORIAL_DESCRITIVO], ";
                sql += " E17_1.[IND_OUTRO], ";
                sql += " E17_1.[OBSERVACOES] ";
                sql += " FROM [DOM_SOLIC_ORC_ESCOPO_17_1] as E17_1 ";
                sql += " INNER JOIN DOM_SOLIC_ORC_VALOR_COMUM as DSOVC ";
                sql += " ON DSOVC.IND_MEMORIAL_DESCRITIVO = E17_1.IND_MEMORIAL_DESCRITIVO ";
                sql += " WHERE E17_1.[NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND E17_1.[REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_17_1");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Apaga os dados do Escopo 17_1
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_17_1(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_17_1] ";
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
