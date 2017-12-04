﻿using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_01 : Escopo
    {

        /// <summary>
        /// Construtor do Escopo 01
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_01(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }


        //Métodos CRUD do Escopo

        /// <summary>
        /// Grava Escopo 01
        /// </summary>
        /// <param name="pTensaoMedia"></param>
        /// <param name="pIndTipoInstalacao"></param>
        /// <param name="pIndEnsaio"></param>
        /// <param name="pTipoPintura"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPreenchido"></param>
        /// <param name="pFrequencia"></param>
        /// <param name="pDescOutraFrequencia"></param>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pIndDiagramaUnifilar"></param>
        /// <param name="pDescricaoSolucao"></param>
        /// <param name="pDescOutroEnsaio"></param>
        /// <returns></returns>
        public int gravaEscopo_01(string pTensaoMedia, string pIndTipoInstalacao, string pIndEnsaio, string pTipoPintura, string pObs, string pIndPreenchido, string pFrequencia, string pDescOutraFrequencia, string pDadosAmbientais, string pIndDiagramaUnifilar, string pDescricaoSolucao, string pDescOutroEnsaio, string pDescOutraTensao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";

                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_01] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [TENSAO_MEDIA], ";
                query += "   [DESC_OUTRA_TENSAO], ";
                query += "   [IND_TIPO_INSTALACAO], ";
                query += "   [IND_ENSAIO], ";
                query += "   [TIPO_PINTURA], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO], ";
                query += "   [FREQUENCIA], ";
                query += "   [DESC_OUTRA_FREQUENCIA], ";
                query += "   [DADOS_AMBIENTAIS], ";
                query += "   [IND_DIAGRAMA_UNIFILAR], ";
                query += "   [DESCRICAO_SOLUCAO], ";
                query += "   [DESC_OUTRO_ENSAIO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   " + pTensaoMedia + ", ";
                query += "   '" + pDescOutraTensao + "', ";
                query += "   '" + pIndTipoInstalacao + "', ";
                query += "   '" + pIndEnsaio + "', ";
                query += "   '" + pTipoPintura + "', ";
                query += "   '" + pObs + "', ";
                query += "   '" + pIndPreenchido + "', ";
                query += "   " + pFrequencia + ", ";
                query += "   '" + pDescOutraFrequencia + "', ";
                query += "   '" + pDadosAmbientais + "', ";
                query += "   '" + pIndDiagramaUnifilar + "', ";
                query += "   '" + pDescricaoSolucao + "', ";
                query += "   '" + pDescOutroEnsaio + "') ";
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
        /// Atualiza Escopo 01
        /// </summary>
        /// <param name="pTensaoMedia"></param>
        /// <param name="pIndTipoInstalacao"></param>
        /// <param name="pIndEnsaio"></param>
        /// <param name="pTipoPintura"></param>
        /// <param name="pObs"></param>
        /// <param name="pIndPreenchido"></param>
        /// <param name="pFrequencia"></param>
        /// <param name="pDescOutraFrequencia"></param>
        /// <param name="pDadosAmbientais"></param>
        /// <param name="pIndDiagramaUnifilar"></param>
        /// <param name="pDescricaoSolucao"></param>
        /// <param name="pDescOutroEnsaio"></param>
        /// <returns></returns>
        public int updateEscopo_01(string pTensaoMedia, string pIndTipoInstalacao, string pIndEnsaio, string pTipoPintura, string pObs, string pIndPreenchido, string pFrequencia, string pDescOutraFrequencia, string pDadosAmbientais, string pIndDiagramaUnifilar, string pDescricaoSolucao, string pDescOutroEnsaio, string pDescOutraTensao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_01] ";
                query += "      SET [TENSAO_MEDIA] = " + pTensaoMedia;
                query += "      ,[DESC_OUTRA_TENSAO] = '" + pDescOutraTensao + "'";
                query += "      ,[IND_TIPO_INSTALACAO] = '" + pIndTipoInstalacao + "'";
                query += "      ,[IND_ENSAIO] =  '" + pIndEnsaio + "'";
                query += "      ,[TIPO_PINTURA] = '" + pTipoPintura + "'";
                query += "      ,[OBSERVACOES] =  '" + pObs + "'";
                query += "      ,[IND_PREENCHIDO] =  '" + pIndPreenchido + "'";
                query += "      ,[FREQUENCIA] =  " + pFrequencia;
                query += "      ,[DESC_OUTRA_FREQUENCIA] =  '" + pDescOutraFrequencia + "'";
                query += "      ,[DADOS_AMBIENTAIS] =  '" + pDadosAmbientais + "'";
                query += "      ,[IND_DIAGRAMA_UNIFILAR] = '" + pIndDiagramaUnifilar + "'";
                query += "      ,[DESCRICAO_SOLUCAO] = '" + pDescricaoSolucao + "'";
                query += "      ,[DESC_OUTRO_ENSAIO] = '" + pDescOutroEnsaio + "'";
                query += "  WHERE [NUMERO_SOLICITACAO] = " + Numero + " AND  [REVISAO_SOLICITACAO] = '" + Revisao + "'";    
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
        /// Busca dados Escopo 01
        /// </summary>
        /// <param name="pNumSolic"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public DataTable getEscopo_01()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_01] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_01");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta o Escopo 01
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_01(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_01] ";
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
