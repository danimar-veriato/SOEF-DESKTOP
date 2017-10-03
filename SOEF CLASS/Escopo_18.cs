using SOEFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SOEF_CLASS
{
   public class Escopo_18 : Escopo
    {
        /// <summary>
        /// Construtor do Escopo 18
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_18 (string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }


        //Atributos do Escopo 18
        private string IndHraExtra { get; set; }
        private string IndMaterialConsumo { get; set; }
        private string IndTransladoObra { get; set; }
        private string IndFornecAlimentacao { get; set; }
        private string IndFornecEstadia { get; set; }
        private string IndObservacoes { get; set; }
        private string IndPreenchido { get; set; }


        //Métodos CRUD
        /// <summary>
        /// Grava Escopo 18
        /// </summary>
        /// <param name="IndHraExtra"></param>
        /// <param name="IndMaterialConsumo"></param>
        /// <param name="IndTransladoObra"></param>
        /// <param name="IndFornecAlimentacao"></param>
        /// <param name="IndFornecEstadia"></param>
        /// <param name="IndObservacoes"></param>
        /// <param name="IndPreenchido"></param>
        /// <returns></returns>
        public int gravaEscopo18(string IndHraExtra, string IndMaterialConsumo, string IndTransladoObra, string IndFornecAlimentacao, string IndFornecEstadia, string IndObservacoes, string IndPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_18] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [IND_HORA_EXTRA], ";
                query += "   [IND_MATERIAL_CONSUMO], ";
                query += "   [IND_TRANSLADO_OBRA], ";
                query += "   [IND_FORNEC_ALIMENTACAO], ";
                query += "   [IND_FORNEC_ESTADIA], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + IndHraExtra + "', ";
                query += "   '" + IndMaterialConsumo + "', ";
                query += "   '" + IndTransladoObra + "', ";
                query += "   '" + IndFornecAlimentacao + "', ";
                query += "   '" + IndFornecEstadia + "', ";
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


        public DataTable getEscopo18()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                string query = "";
                query += " SELECT [IND_HORA_EXTRA], ";
                query += "   [IND_MATERIAL_CONSUMO], ";
                query += "   [IND_TRANSLADO_OBRA], ";
                query += "   [IND_FORNEC_ALIMENTACAO], ";
                query += "   [IND_FORNEC_ESTADIA], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO] ";
                query += " FROM [DOM_SOLIC_ORC_ESCOPO_18] ";
                query += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                query += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                return sqlce.selectListaSOF(query, "[DOM_SOLIC_ORC_ESCOPO_18]");
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Atualiza o registro do Escopo 18
        /// </summary>
        /// <param name="IndHraExtra"></param>
        /// <param name="IndMaterialConsumo"></param>
        /// <param name="IndTransladoObra"></param>
        /// <param name="IndFornecAlimentacao"></param>
        /// <param name="IndFornecEstadia"></param>
        /// <param name="IndObservacoes"></param>
        /// <param name="IndPreenchido"></param>
        /// <returns></returns>
        public int atualizaEscopo18(string IndHraExtra, string IndMaterialConsumo, string IndTransladoObra, string IndFornecAlimentacao, string IndFornecEstadia, string IndObservacoes, string IndPreenchido)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_18] ";
                query += "   SET [IND_HORA_EXTRA] = '" + IndHraExtra + "', ";
                query += "   [IND_MATERIAL_CONSUMO] = '" + IndMaterialConsumo + "', ";
                query += "   [IND_TRANSLADO_OBRA] = '" + IndTransladoObra + "', ";
                query += "   [IND_FORNEC_ALIMENTACAO] = '" + IndFornecAlimentacao + "', ";
                query += "   [IND_FORNEC_ESTADIA] = '" + IndFornecEstadia + "', ";
                query += "   [OBSERVACOES] = '" + IndObservacoes + "', ";
                query += "   [IND_PREENCHIDO] = '" + IndPreenchido + "' ";
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
        /// Delete Escopo 18
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
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_18] ";
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
