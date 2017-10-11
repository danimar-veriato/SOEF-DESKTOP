using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
   public class Escopo_10_1: Escopo
   {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_10_1(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }

        //Métodos do CRUD do Escopo 10_1     

        /// <summary>
        /// Insere o registro do Escopo 10_1 no banco
        /// </summary>
        /// <param name="pTensaoTrifasica"></param>
        /// <param name="pFrequencia"></param>
        /// <param name="pOutraFrequencia"></param>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pNormativa"></param>
        /// <param name="pTipoProduto"></param>
        /// <param name="pDescOutroProduto"></param>
        /// <param name="pUmidade"></param>
        /// <param name="pTipoAeracao"></param>
        /// <param name="pTipoInstalacao"></param>
        /// <param name="pMatTampaCanaleta"></param>
        /// <param name="pTipoTampaCanaleta"></param>
        /// <param name="pMaterialCasaMata"></param>
        /// <param name="pObs"></param>
        /// <param name="indPreenchido"></param>
        /// <returns></returns>
        public int gravaEscopo_10_1(string pTensaoTrifasica, string pFrequencia, string pOutraFrequencia, string pDadosAmbientais, string pNormativa, string pTipoProduto, string pDescOutroProduto, string pUmidade, string pTipoAeracao, string pTipoInstalacao, string pMatTampaCanaleta, string pTipoTampaCanaleta, string pMaterialCasaMata, string pObs, string indPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_10_1] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [TENSAO_TRIFASICA], ";
                query += "   [FREQUENCIA], ";
                query += "   [DESC_OUTRA_FREQUENCIA], ";
                query += "   [DADOS_AMBIENTAIS], ";
                query += "   [IND_NORMATIVA_MAPA], ";
                query += "   [TIPO_PRODUTO], ";
                query += "   [DESC_OUTRO_PRODUTO], ";
                query += "   [UMIDADE_PRODUTO], ";
                query += "   [TIPO_AERACAO], ";
                query += "   [TIPO_INSTALACAO], ";
                query += "   [MATERIAL_TAMPA_CANALETA], ";
                query += "   [TIPO_TAMPA_CANALETA], ";
                query += "   [MATERIAL_CASA_MATA], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   " + pTensaoTrifasica + ", ";
                query += "   " + pFrequencia + ", ";
                query += "   '" + pOutraFrequencia + "', ";
                query += "   '" + pDadosAmbientais + "', ";
                query += "   '" + pNormativa + "', ";
                query += "   '" + pTipoProduto + "', ";
                query += "   '" + pDescOutroProduto + "', ";
                query += "   " + pUmidade + ", ";
                query += "   '" + pTipoAeracao + "', ";
                query += "   '" + pTipoInstalacao + "', ";
                query += "   '" + pMatTampaCanaleta + "', ";
                query += "   '" + pTipoTampaCanaleta + "', ";
                query += "   '" + pMaterialCasaMata + "', ";
                query += "   '" + pObs + "', ";
                query += "   '" + indPreenchido + "') ";
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
        /// Atualiza os dados do Escopo 10_1
        /// </summary>
        /// <param name="pTensaoTrifasica"></param>
        /// <param name="pFrequencia"></param>
        /// <param name="pOutraFrequencia"></param>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pNormativa"></param>
        /// <param name="pTipoProduto"></param>
        /// <param name="pDescOutroProduto"></param>
        /// <param name="pUmidade"></param>
        /// <param name="pTipoAeracao"></param>
        /// <param name="pTipoInstalacao"></param>
        /// <param name="pMatTampaCanaleta"></param>
        /// <param name="pTipoTampaCanaleta"></param>
        /// <param name="pMaterialCasaMata"></param>
        /// <param name="pObs"></param>
        /// <param name="indPreenchido"></param>
        /// <returns></returns>
        public int updateEscopo_10_1(string pTensaoTrifasica, string pFrequencia, string pOutraFrequencia, string pDadosAmbientais, string pNormativa, string pTipoProduto, string pDescOutroProduto, string pUmidade, string pTipoAeracao, string pTipoInstalacao, string pMatTampaCanaleta, string pTipoTampaCanaleta, string pMaterialCasaMata, string pObs, string indPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_10_1] ";
                query += "   SET [TENSAO_TRIFASICA] = " + pTensaoTrifasica + ",  ";
                query += "       [FREQUENCIA] = " + pFrequencia + ", ";
                query += "       [DESC_OUTRA_FREQUENCIA] = '" + pOutraFrequencia + "', ";
                query += "       [DADOS_AMBIENTAIS] = '" + pDadosAmbientais + "', ";
                query += "       [IND_NORMATIVA_MAPA] = '" + pNormativa + "', ";
                query += "       [TIPO_PRODUTO] = '" + pTipoProduto + "', ";
                query += "       [DESC_OUTRO_PRODUTO] = '" + pDescOutroProduto + "', ";
                query += "       [UMIDADE_PRODUTO] = " + pUmidade + ", ";
                query += "       [TIPO_AERACAO] = '" + pTipoAeracao + "', ";
                query += "       [TIPO_INSTALACAO] = '" + pTipoInstalacao + "', ";
                query += "       [MATERIAL_TAMPA_CANALETA] = '" + pMatTampaCanaleta + "',  ";
                query += "       [TIPO_TAMPA_CANALETA] = '" + pTipoTampaCanaleta + "', ";
                query += "       [MATERIAL_CASA_MATA] = '" + pMaterialCasaMata + "', ";
                query += "       [OBSERVACOES] = '" + pObs + "', ";
                query += "       [IND_PREENCHIDO] = '" + indPreenchido + "' ";
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
        /// Busca os dados do Escopo 10_1
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_10_1()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_10_1] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_10_1");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta o Escopo 10_1
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_10_1(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_10_1] ";
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
