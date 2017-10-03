using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_18_2 : Escopo
    {
        /// <summary>
        /// Construtor do Escopo 18_2
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_18_2(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }

        //Atributos
        private string IndTecnicoObras { get; set; }
        private string IndAlmoxarife { get; set; }
        private string IndMontador { get; set; }
        private string IndAuxiliarMontador { get; set; }
        private string IndSoldador { get; set; }
        private string IndOutroProfissional { get; set; }
        private string DescOutroProfissional { get; set; }
        private string IndPlataformaElevetoria { get; set; }
        private string IndMunk { get; set; }
        private string IndFerramental { get; set; }
        private string Observacoes { get; set; }
        private string IndPreenchido { get; set; }

        
        /// <summary>
        /// Grava Escopo 18_2
        /// </summary>
        /// <param name="IndTecnicoObras"></param>
        /// <param name="IndAlmoxarife"></param>
        /// <param name="IndMontador"></param>
        /// <param name="IndAuxiliarMontador"></param>
        /// <param name="IndSoldador"></param>
        /// <param name="IndOutroProfissional"></param>
        /// <param name="DescOutroProfissional"></param>
        /// <param name="IndPlataformaElevetoria"></param>
        /// <param name="IndMunck"></param>
        /// <param name="IndFerramental"></param>
        /// <param name="IndObservacoes"></param>
        /// <param name="IndPreenchido"></param>
        /// <returns></returns>
        public int gravaEscopo18_2(string IndTecnicoObras, string IndAlmoxarife, string IndMontador, string IndAuxiliarMontador, string IndSoldador, string IndOutroProfissional, string DescOutroProfissional, string IndPlataformaElevetoria, string IndMunck, string IndFerramental, string IndObservacoes, string IndPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_18_2] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [IND_TECNICO_OBRAS], ";
                query += "   [IND_ALMOXARIFE], ";
                query += "   [IND_MONTADOR], ";
                query += "   [IND_AUXILIAR_MONTADOR], ";
                query += "   [IND_SOLDADOR], ";
                query += "   [IND_OUTRO_PROFISSIONAL], ";
                query += "   [DESC_OUTRO_PROFISSIONAL], ";
                query += "   [IND_PLATAFORMA_ELEVATORIA], ";
                query += "   [IND_MUNCK], ";
                query += "   [IND_FERRAMENTAL], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + IndTecnicoObras + "', ";
                query += "   '" + IndAlmoxarife + "', ";
                query += "   '" + IndMontador + "', ";
                query += "   '" + IndAuxiliarMontador + "', ";
                query += "   '" + IndSoldador + "', ";
                query += "   '" + IndOutroProfissional + "', ";
                query += "   '" + DescOutroProfissional + "', ";
                query += "   '" + IndPlataformaElevetoria + "', ";
                query += "   '" + IndMunck + "', ";
                query += "   '" + IndFerramental + "', ";
                query += "   '" + IndObservacoes + "', ";
                query += "   '" + IndPreenchido + "') ";
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
        /// Busca dados Escopo 18_2
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public DataTable getEscopo18_2()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_18_2] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_18_2");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta Escopo 18_2
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo18_2(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_18_2] ";
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


        /// <summary>
        /// Atualiza Escopo 18_02
        /// </summary>
        /// <param name="IndTecnicoObras"></param>
        /// <param name="IndAlmoxarife"></param>
        /// <param name="IndMontador"></param>
        /// <param name="IndAuxiliarMontador"></param>
        /// <param name="IndSoldador"></param>
        /// <param name="IndOutroProfissional"></param>
        /// <param name="DescOutroProfissional"></param>
        /// <param name="IndPlataformaElevetoria"></param>
        /// <param name="IndMunck"></param>
        /// <param name="IndFerramental"></param>
        /// <param name="IndObservacoes"></param>
        /// <param name="IndPreenchido"></param>
        /// <returns></returns>
        public int atualizaEscopo18_2(string IndTecnicoObras, string IndAlmoxarife, string IndMontador, string IndAuxiliarMontador, string IndSoldador, string IndOutroProfissional, string DescOutroProfissional, string IndPlataformaElevetoria, string IndMunck, string IndFerramental, string IndObservacoes, string IndPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_18_2] ";
                query += " SET [IND_TECNICO_OBRAS] = '" + IndTecnicoObras + "',";
                query += "   [IND_ALMOXARIFE] = '" + IndAlmoxarife + "' ,";
                query += "   [IND_MONTADOR] = '" + IndMontador + "',";
                query += "   [IND_AUXILIAR_MONTADOR] = '" + IndAuxiliarMontador + "',";
                query += "   [IND_SOLDADOR] = '" + IndSoldador + "',";
                query += "   [IND_OUTRO_PROFISSIONAL] = '" + IndOutroProfissional + "',";
                query += "   [DESC_OUTRO_PROFISSIONAL] = '" + DescOutroProfissional + "',";
                query += "   [IND_PLATAFORMA_ELEVATORIA] = '" + IndPlataformaElevetoria + "',";
                query += "   [IND_MUNCK] = '" + IndMunck + "' ,";
                query += "   [IND_FERRAMENTAL] = '" + IndFerramental + "',";
                query += "   [OBSERVACOES] = '" + IndObservacoes + "', ";
                query += "   [IND_PREENCHIDO] = '" + IndOutroProfissional + "'";
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


    }
}
