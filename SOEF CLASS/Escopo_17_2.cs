using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_17_2:Escopo
    {
        /// <summary>
        /// Construtor Escopo 17_2
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_17_2(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }


        //Métodos CRUD Escopo 17_2

        /// <summary>
        /// Grava os dados do Escopo 17_2
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int gravaEscopo_17_2(string pMediaTensao, string pAprovConcessionaria, string pCaboGeral, string pInstalForca, string pInstalComando, string pIluminacaoInt, string pIluminacaoExt, string pAterramento, string pCFTV, string pTelefonia, string pRedeDados, string pRedeEstabilizada, string pMemorialDescritivo, string pListaMateriais, string pIndOutro, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_17_2] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [IND_INSTAL_MEDIA_TENSAO], ";
                query += "   [IND_APROV_CONCESSIONARIA], ";
                query += "   [IND_CABO_GERAL], ";
                query += "   [IND_INSTAL_FORCA], ";
                query += "   [IND_INSTAL_COMANDO], ";
                query += "   [IND_INSTAL_ILUMINACAO_INT], ";
                query += "   [IND_INSTAL_ILUMINACAO_EXT], ";
                query += "   [IND_INSTAL_ATERRAMENTO], ";
                query += "   [IND_INSTAL_CFTV], ";
                query += "   [IND_INSTAL_TELEFONIA], ";
                query += "   [IND_INSTAL_REDE_DADOS], ";
                query += "   [IND_INSTAL_REDE_ESTABILIZADA], ";
                query += "   [IND_MEMORIAL_DESCRITIVO], ";
                query += "   [IND_LISTA_MATERIAIS], ";
                query += "   [IND_OUTRO], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + pMediaTensao + "', ";
                query += "   '" + pAprovConcessionaria + "', ";
                query += "   '" + pCaboGeral + "', ";
                query += "   '" + pInstalForca + "', ";
                query += "   '" + pInstalComando + "', ";
                query += "   '" + pIluminacaoInt + "', ";
                query += "   '" + pIluminacaoExt + "', ";
                query += "   '" + pAterramento + "', ";
                query += "   '" + pCFTV + "', ";
                query += "   '" + pTelefonia + "', ";
                query += "   '" + pRedeDados + "', ";
                query += "   '" + pRedeEstabilizada + "', ";
                query += "   '" + pMemorialDescritivo + "', ";
                query += "   '" + pListaMateriais + "', ";
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
        /// Atualiza os dados do Escopo 17_2
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int updateEscopo_17_2(string pMediaTensao, string pAprovConcessionaria, string pCaboGeral, string pInstalForca, string pInstalComando, string pIluminacaoInt, string pIluminacaoExt, string pAterramento, string pCFTV, string pTelefonia, string pRedeDados, string pRedeEstabilizada, string pMemorialDescritivo, string pListaMateriais, string pIndOutro, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_17_2] ";
                query += "   SET [IND_INSTAL_MEDIA_TENSAO] = '" + pMediaTensao + "', ";
                query += "       [IND_APROV_CONCESSIONARIA] = '" + pAprovConcessionaria + "', ";
                query += "       [IND_CABO_GERAL] = '" + pCaboGeral + "', ";
                query += "       [IND_INSTAL_FORCA] = '" + pInstalForca + "', ";
                query += "       [IND_INSTAL_COMANDO] = '" + pInstalComando + "', ";
                query += "       [IND_INSTAL_ILUMINACAO_INT] = '" + pIluminacaoInt + "', ";
                query += "       [IND_INSTAL_ILUMINACAO_EXT] = '" + pIluminacaoExt + "', ";
                query += "       [IND_INSTAL_ATERRAMENTO] = '" + pAterramento + "', ";
                query += "       [IND_INSTAL_CFTV] = '" + pCFTV + "', ";
                query += "       [IND_INSTAL_TELEFONIA] = '" + pTelefonia + "', ";
                query += "       [IND_INSTAL_REDE_DADOS] = '" + pRedeDados + "', ";
                query += "       [IND_INSTAL_REDE_ESTABILIZADA] = '" + pRedeEstabilizada + "', ";
                query += "       [IND_MEMORIAL_DESCRITIVO] = '" + pMemorialDescritivo + "', ";
                query += "       [IND_LISTA_MATERIAIS] = '" + pListaMateriais + "', ";
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
        /// Busca os dados do Escopo 17_2
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_17_2()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = " SELECT E17_2.[NUMERO_SOLICITACAO], ";
                sql += " E17_2.[REVISAO_SOLICITACAO], ";
                sql += " E17_2.[IND_INSTAL_MEDIA_TENSAO], ";
                sql += " E17_2.[IND_APROV_CONCESSIONARIA], ";
                sql += " E17_2.[IND_CABO_GERAL], ";
                sql += " E17_2.[IND_INSTAL_FORCA], ";
                sql += " E17_2.[IND_INSTAL_COMANDO], ";
                sql += " E17_2.[IND_INSTAL_ILUMINACAO_INT], ";
                sql += " E17_2.[IND_INSTAL_ILUMINACAO_EXT], ";
                sql += " E17_2.[IND_INSTAL_ATERRAMENTO], ";
                sql += " E17_2.[IND_INSTAL_CFTV], ";
                sql += " E17_2.[IND_INSTAL_TELEFONIA], ";
                sql += " E17_2.[IND_INSTAL_REDE_DADOS], ";
                sql += " E17_2.[IND_INSTAL_REDE_ESTABILIZADA], ";
                sql += " DSOVC.[IND_MEMORIAL_DESCRITIVO], ";
                sql += " DSOVC.[IND_LISTA_MATERIAIS], ";
                sql += " E17_2.[IND_OUTRO], ";
                sql += " E17_2.[OBSERVACOES] ";
                sql += " FROM [DOM_SOLIC_ORC_ESCOPO_17_2] as E17_2 ";
                sql += " INNER JOIN DOM_SOLIC_ORC_VALOR_COMUM as DSOVC ";
                sql += " ON DSOVC.[IND_LISTA_MATERIAIS] = E17_2.[IND_LISTA_MATERIAIS] ";
                sql += " AND DSOVC.[IND_MEMORIAL_DESCRITIVO] = E17_2.[IND_MEMORIAL_DESCRITIVO] ";
                sql += " WHERE E17_2.[NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND E17_2.[REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_17_2");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Apaga os dados do Escopo 17_2
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_17_2(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_17_2] ";
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
