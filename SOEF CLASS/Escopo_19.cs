using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOEFC;
using System.Data;

namespace SOEF_CLASS
{
    public class Escopo_19 : Escopo
    {
        /// <summary>
        /// Construtor da classe Escopo 19
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_19(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }

        //Atributos Escopo 19
        private string IndAberturaFechamentoValas { get; set; }
        private string IndCaixaInspecao { get; set; }
        private string IndBasePostes { get; set; }
        private string IndBaseSubestacao { get; set; }
        private string IndCasaBombas { get; set; }
        private string IndOutroEscopo { get; set; }
        private string DescricaOutroEscopo { get; set; }


        //Métodos Escopo 19
        /// <summary>
        /// Método que faz a gravação do escopo 19: Fornecimento de Civil. 
        /// </summary>
        /// <param name="indAberturaFechamentoValas">Indica o fornecimento de abertura e fechamento de valas</param>
        /// <param name="indCaixaInspecao">Indica o fornecimento de caixa de inspeção</param>
        /// <param name="indBasePostes">Indica o fornecimento de base de postes e/ou suportes</param>
        /// <param name="indBaseSubestacao">Indica o fornecimento de base para subestação blindada</param>
        /// <param name="indCasaBombas">Indica o fornecimento de cada de bombas (PPCI)</param>
        /// <param name="indOutroEscopo">Indica o fornecimento de outro escopo</param>
        /// <param name="descricaOutroEscopo">Descriçao do outro escopo</param>
        /// <param name="observacao">Observação sobre o escopo</param>
        public int gravaEscopo19(string indAberturaFechamentoValas, string indCaixaInspecao, string indBasePostes, string indBaseSubestacao, string indCasaBombas, string indOutroEscopo, string descOutroEscopo, string observacao, string indPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_19] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [IND_ABERTURA_FEC_VALAS], ";
                query += "   [IND_CAIXA_INSPECAO], ";
                query += "   [IND_BASE_POSTES], ";
                query += "   [IND_BASE_SUBESTACAO], ";
                query += "   [IND_CASA_BOMBAS], ";
                query += "   [IND_OUTRO_ESCOPO], ";
                query += "   [DESC_OUTRO_ESCOPO], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + indAberturaFechamentoValas + "', ";
                query += "   '" + indCaixaInspecao + "', ";
                query += "   '" + indBasePostes + "', ";
                query += "   '" + indBaseSubestacao + "', ";
                query += "   '" + indCasaBombas + "', ";
                query += "   '" + indOutroEscopo + "', ";
                query += "   '" + descOutroEscopo + "', ";
                query += "   '" + observacao + "', ";
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
        /// Busca os dados do Escopo 19, caso esteja cadastrado
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public DataTable getEscopo(string pNumSolic, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM DOM_SOLIC_ORC_ESCOPO_19 WHERE NUMERO_SOLICITACAO = "+ pNumSolic + " AND REVISAO_SOLICITACAO = '" + pRevisao + "'";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_19");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Método que atualiza informações do Escopo 19
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int updateEscopo(string pNumSolic, string pRevisao, string pindAberturaFechamentoValas, string pindCaixaInspecao, string pindBasePostes, string pindBaseSubestacao, string pindCasaBombas, string pindOutroEscopo, string pdescOutroEscopo, string pobservacao)
        {
            SqlCE sqlce = new SqlCE();
            try
            {
                DataTable dtVerificacao;
                int retorno = 0;
                string sql;
                //Verifica se existe registro para essa solicitação
                dtVerificacao = this.getEscopo(pNumSolic, pRevisao);
                if(dtVerificacao.Rows.Count > 0)
                {
                    sqlce.openConnection();
                    //DataTable dt = new DataTable();
                    sql = "UPDATE [DOM_SOLIC_ORC_ESCOPO_19] ";
                    sql += "  SET [IND_ABERTURA_FEC_VALAS] = '" + pindAberturaFechamentoValas + "' ";
                    sql += "   ,[IND_CAIXA_INSPECAO] = '" + pindCaixaInspecao + "'";
                    sql += "   ,[IND_BASE_POSTES] = '" + pindBasePostes + "'";
                    sql += "   ,[IND_BASE_SUBESTACAO] = '" + pindBaseSubestacao + "'";
                    sql += "   ,[IND_CASA_BOMBAS] = '" + pindCasaBombas + "'";
                    sql += "   ,[IND_OUTRO_ESCOPO] = '" + pindOutroEscopo + "'";
                    sql += "   ,[DESC_OUTRO_ESCOPO] = '" + pdescOutroEscopo + "'";
                    sql += "   ,[OBSERVACOES] = '" + pobservacao + "' ";
                    sql += "WHERE [NUMERO_SOLICITACAO] = " + pNumSolic + " AND [REVISAO_SOLICITACAO] = '" + pRevisao + "'";
                    retorno = sqlce.insertSOF(sql);
                }
                else 
                {
                    retorno = this.gravaEscopo19(pindAberturaFechamentoValas, pindCaixaInspecao, pindBasePostes, pindBaseSubestacao, pindCasaBombas, pindOutroEscopo, pdescOutroEscopo, pobservacao, "S");
                }
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
        /// Método que apaga o Escopo 19 da solicitação
        /// </summary>
        /// <param name="pNumSolic">N° Solicitação</param>
        /// <param name="pRevisao">N° Revisão</param>
        /// <returns></returns>
        public int deleteEscopo19(string pNumSolic, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string sql;
                sql = "DELETE FROM [DOM_SOLIC_ORC_ESCOPO_19] ";
                sql += " WHERE NUMERO_SOLICITACAO = " + pNumSolic;
                sql += " AND REVISAO_SOLICITACAO = '" + pRevisao + "'";
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
