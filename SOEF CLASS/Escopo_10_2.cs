using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_10_2 : Escopo
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_10_2(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }

        //Métodos CRUD Escopo 10_2

        /// <summary>
        /// Grava Escopo 10_2
        /// </summary>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pTipoProduto"></param>
        /// <param name="pDescOutroProduto"></param>
        /// <param name="pInstalSilo"></param>
        /// <param name="pInstalArmazem"></param>
        /// <param name="pCapacidadeSilo"></param>
        /// <param name="pSuportePendulo"></param>
        /// <param name="pCapacidadeArmazem"></param>
        /// <param name="pQtdTransportador"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPreenchido"></param>
        /// <param name="pCaractEspalhadorSilo"></param>
        /// <param name="pCaractEspalhadorArm"></param>
        /// <returns></returns>
        public int gravaEscopo_10_2(string pDadosAmbientais, string pTipoProduto, string pDescOutroProduto, string pInstalSilo, string pInstalArmazem, string pCapacidadeSilo, string pSuportePendulo, string pCapacidadeArmazem, string pQtdTransportador, string pObs, string pIndPreenchido, string pCaractEspalhadorSilo, string pCaractEspalhadorArm)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                if (string.IsNullOrEmpty(pCapacidadeArmazem))
                {
                    pCapacidadeArmazem = "NULL";
                }
                if (string.IsNullOrEmpty(pQtdTransportador))
                {
                    pQtdTransportador = "NULL";
                }
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_10_2] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [DADOS_AMBIENTAIS], ";
                query += "   [TIPO_PRODUTO], ";
                query += "   [DESC_OUTRO_PRODUTO], ";
                query += "   [IND_INSTAL_SILO], ";
                query += "   [IND_INSTAL_ARMAZEM], ";
                query += "   [CAPACIDADE_SILO], ";
                query += "   [IND_SUPORTE_PENDULO], ";
                query += "   [CAPACIDADE_ARMAZEM], ";
                query += "   [QTDE_TRANSPORTADOR], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO], ";
                query += "   [CARACT_ESPALHADOR_ESP_SIL], ";
                query += "   [CARACT_ESPALHADOR_ESP_ARM]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + pDadosAmbientais + "', ";
                query += "   '" + pTipoProduto + "', ";
                query += "   '" + pDescOutroProduto + "', ";
                query += "   '" + pInstalSilo + "', ";
                query += "   '" + pInstalArmazem + "', ";
                query += "   " + pCapacidadeSilo + ", ";
                query += "   '" + pSuportePendulo + "', ";
                query += "   " + pCapacidadeArmazem + ", ";
                query += "   " + pQtdTransportador + ", ";
                query += "   '" + pObs + "', ";
                query += "   '" + pIndPreenchido + "', ";
                query += "   '" + pCaractEspalhadorSilo + "', ";
                query += "   '" + pCaractEspalhadorArm + "') ";
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
        /// Atualiza campos do Escopo 10_2
        /// </summary>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pTipoProduto"></param>
        /// <param name="pDescOutroProduto"></param>
        /// <param name="pInstalSilo"></param>
        /// <param name="pInstalArmazem"></param>
        /// <param name="pCapacidadeSilo"></param>
        /// <param name="pSuportePendulo"></param>
        /// <param name="pCapacidadeArmazem"></param>
        /// <param name="pQtdTransportador"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPreenchido"></param>
        /// <param name="pCaractEspalhadorSilo"></param>
        /// <param name="pCaractEspalhadorArm"></param>
        /// <returns></returns>
        public int updateEscopo_10_2(string pDadosAmbientais, string pTipoProduto, string pDescOutroProduto, string pInstalSilo, string pInstalArmazem, string pCapacidadeSilo, string pSuportePendulo, string pCapacidadeArmazem, string pQtdTransportador, string pObs, string pIndPreenchido, string pCaractEspalhadorSilo, string pCaractEspalhadorArm)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                if (string.IsNullOrEmpty(pCapacidadeArmazem))
                {
                    pCapacidadeArmazem = "NULL";
                }
                if (string.IsNullOrEmpty(pQtdTransportador))
                {
                    pQtdTransportador = "NULL";
                }
                if (string.IsNullOrEmpty(pCapacidadeSilo))
                {
                    pCapacidadeSilo = "NULL";
                }
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_10_2] ";
                query += "   SET [DADOS_AMBIENTAIS] = '" + pDadosAmbientais + "',  ";
                query += "       [TIPO_PRODUTO] = '" + pTipoProduto + "', ";
                query += "       [DESC_OUTRO_PRODUTO] = '" + pDescOutroProduto + "', ";
                query += "       [IND_INSTAL_SILO] = '" + pInstalSilo + "', ";
                query += "       [IND_INSTAL_ARMAZEM] = '" + pInstalArmazem + "', ";
                query += "       [CAPACIDADE_SILO] = " + pCapacidadeSilo + ", ";
                query += "       [IND_SUPORTE_PENDULO] = '" + pSuportePendulo + "', ";
                query += "       [CAPACIDADE_ARMAZEM] = " + pCapacidadeArmazem + ", ";
                query += "       [QTDE_TRANSPORTADOR] = " + pQtdTransportador + ", ";
                query += "       [OBSERVACOES] = '" + pObs + "', ";
                query += "       [IND_PREENCHIDO] = '" + pIndPreenchido + "',  ";
                query += "       [CARACT_ESPALHADOR_ESP_SIL] = '" + pCaractEspalhadorSilo + "', ";
                query += "       [CARACT_ESPALHADOR_ESP_ARM] = '" + pCaractEspalhadorArm + "' ";
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
        /// Busca os dados do Escopo 10_2
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_10_2()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = " SELECT E10_2.[NUMERO_SOLICITACAO], ";
                sql += "   E10_2.[REVISAO_SOLICITACAO], ";
                sql += "   DSOVC.[DADOS_AMBIENTAIS], ";
                sql += "   DSOVC.[TIPO_PRODUTO], ";
                sql += "   DSOVC.[OUTRO_PRODUTO], ";
                sql += "   E10_2.[IND_INSTAL_SILO], ";
                sql += "   E10_2.[IND_INSTAL_ARMAZEM], ";
                sql += "   E10_2.[CAPACIDADE_SILO], ";
                sql += "   E10_2.[IND_SUPORTE_PENDULO], ";
                sql += "   E10_2.[CAPACIDADE_ARMAZEM], ";
                sql += "   E10_2.[QTDE_TRANSPORTADOR], ";
                sql += "   E10_2.[OBSERVACOES], ";
                sql += "   E10_2.[IND_PREENCHIDO], ";
                sql += "   E10_2.[CARACT_ESPALHADOR_ESP_SIL], ";
                sql += "   E10_2.[CARACT_ESPALHADOR_ESP_ARM] ";
                sql += " FROM[DOM_SOLIC_ORC_ESCOPO_10_2] as E10_2 ";
                sql += " INNER JOIN DOM_SOLIC_ORC_VALOR_COMUM as DSOVC ";
                sql += " ON DSOVC.[DADOS_AMBIENTAIS] = E10_2.[DADOS_AMBIENTAIS] ";
                sql += " AND DSOVC.[TIPO_PRODUTO] = E10_2.[TIPO_PRODUTO] ";
                sql += " AND DSOVC.[OUTRO_PRODUTO] = E10_2.[DESC_OUTRO_PRODUTO] ";
                sql += " WHERE E10_2.[NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND E10_2.[REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_10_2");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Apaga o registro do Escopo 10_2
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_10_2(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_10_2] ";
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
