using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_18_1 : Escopo
    {
        /// <summary>
        /// Construtor do Escopo 18_1
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_18_1(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }

        //Atributos
        private string IndEngenheiroResidente { get; set; }
        private string IndAdministrativo { get; set; }
        private string IndTecnicoSeguranca { get; set; }
        private string IndPlanejador { get; set; }
        private string IndOutroProfissional { get; set; }
        public string DescOutroProfissional { get; set; }
        private string Obs { get; set; }
        private string IndPreenchido { get; set; }


        /// <summary>
        /// Grava Escopo 18_1
        /// </summary>
        /// <param name="IndEngenheiroResidente"></param>
        /// <param name="IndAdministrativo"></param>
        /// <param name="IndTecnicoSeguranca"></param>
        /// <param name="IndPlanejador"></param>
        /// <param name="IndOutroProfissional"></param>
        /// <param name="DescOutroProfissional"></param>
        /// <param name="IndObservacoes"></param>
        /// <param name="IndPreenchido"></param>
        /// <returns></returns>
        public int gravaEscopo18_1(string IndEngenheiroResidente, string IndAdministrativo, string IndTecnicoSeguranca, string IndPlanejador, string IndOutroProfissional, string DescOutroProfissional, string IndObservacoes, string IndPreenchido, string IndEncarregado)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_18_1] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [IND_ENGENHEIRO_RESIDENTE], ";
                query += "   [IND_ADMINISTRATIVO], ";
                query += "   [IND_TECNICO_SEGURANCA], ";
                query += "   [IND_PLANEJADOR], ";
                query += "   [IND_OUTRO_PROFISSIONAL], ";
                query += "   [DESC_OUTRO_PROFISSIONAL], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO], ";
                query += "   [IND_ENCARREGADO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + IndEngenheiroResidente + "', ";
                query += "   '" + IndAdministrativo + "', ";
                query += "   '" + IndTecnicoSeguranca + "', ";
                query += "   '" + IndPlanejador + "', ";
                query += "   '" + IndOutroProfissional + "', ";
                query += "   '" + DescOutroProfissional + "', ";
                query += "   '" + IndObservacoes + "', ";
                query += "   '" + IndPreenchido + "', ";
                query += "   '" + IndEncarregado + "') ";
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
        /// Busca dados Escopo 18_1
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public DataTable getEscopo18_1()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_18_1] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_18_1");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Atualiza o Escopo 18_1
        /// </summary>
        /// <param name="IndEngenheiroResidente"></param>
        /// <param name="IndAdministrativo"></param>
        /// <param name="IndTecnicoSeguranca"></param>
        /// <param name="IndPlanejador"></param>
        /// <param name="IndOutroProfissional"></param>
        /// <param name="DescOutroProfissional"></param>
        /// <param name="IndObservacoes"></param>
        /// <param name="IndPreenchido"></param>
        /// <returns></returns>
        public int atualizaEscopo18_1(string IndEngenheiroResidente, string IndAdministrativo, string IndTecnicoSeguranca, string IndPlanejador, string IndOutroProfissional, string DescOutroProfissional, string IndObservacoes, string IndPreenchido, string IndEncarregado)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_18_1] ";
                query += "   SET [IND_ENGENHEIRO_RESIDENTE] = '" + IndEngenheiroResidente + "', ";
                query += "   [IND_ADMINISTRATIVO] = '" + IndAdministrativo + "', ";
                query += "   [IND_TECNICO_SEGURANCA] = '" + IndTecnicoSeguranca + "', ";
                query += "   [IND_PLANEJADOR] = '" + IndPlanejador + "', ";
                query += "   [IND_OUTRO_PROFISSIONAL] = '" + IndOutroProfissional + "', ";
                query += "   [DESC_OUTRO_PROFISSIONAL] = '" + DescOutroProfissional + "', ";
                query += "   [OBSERVACOES] = '" + IndObservacoes + "', ";
                query += "   [IND_PREENCHIDO] = '" + IndPreenchido + "', ";
                query += "   [IND_ENCARREGADO] = '" + IndEncarregado + "' ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
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
        /// Deleta Escopo 18_1
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo18(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_18_1] ";
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
