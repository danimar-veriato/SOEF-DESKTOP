using SOEFC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEF_CLASS
{
    public class Escopo_17_3: Escopo
    {
        /// <summary>
        /// Construtor Escopo 17_3
        /// </summary>
        /// <param name="numSolicitacao"></param>
        /// <param name="revSolicitacao"></param>
        public Escopo_17_3(string numSolicitacao, string revSolicitacao)
        {
            Numero = numSolicitacao;
            Revisao = revSolicitacao;
        }


        //Métodos CRUD Escopo 17_3

        /// <summary>
        /// Grava os dados do Escopo 17_3
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int gravaEscopo_17_3(string pPpciCompleto, string pAprovBombeiros, string pInstalHidrantes, string pInstalSprinklers, string pInstalExtintores, string pInstalAlarme, string pInstalIluminacao, string pInstalSinalizacao, string pInstalAr, string pInstalAguaP, string pInstalAguaInd, string pInstalAguaGel, string pInstalAguaQuente, string pInstalVaporCond, string pInstalGas, string pMemorialDesc, string pListaMateriais, string indOutro, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " INSERT INTO [DOM_SOLIC_ORC_ESCOPO_17_3] ";
                query += "   ([NUMERO_SOLICITACAO], ";
                query += "   [REVISAO_SOLICITACAO], ";
                query += "   [IND_PPCI_COMPLETO], ";
                query += "   [IND_APROV_BOMBEIROS], ";
                query += "   [IND_INSTAL_HIDRANTES], ";
                query += "   [IND_INSTAL_SPRINKLERS], ";
                query += "   [IND_INSTAL_EXTINTORES], ";
                query += "   [IND_INSTAL_ALARME_INCENDIO], ";
                query += "   [IND_INSTAL_ILUMINACAO_EMERG], ";
                query += "   [IND_INSTAL_SINALIZACAO_EMERG], ";
                query += "   [IND_INSTAL_AR_COMPRIMIDO], ";
                query += "   [IND_INSTAL_AGUA_POTAVEL], ";
                query += "   [IND_INSTAL_AGUA_INDUSTRIAL], ";
                query += "   [IND_INSTAL_AGUA_GELADA], ";
                query += "   [IND_INSTAL_AGUA_QUENTE], ";
                query += "   [IND_INSTAL_VAPOR_CONDENSADO], ";
                query += "   [IND_INSTAL_GAS], ";
                query += "   [IND_MEMORIAL_DESCRITIVO], ";
                query += "   [IND_LISTA_MATERIAIS], ";
                query += "   [IND_OUTRO], ";
                query += "   [OBSERVACOES], ";
                query += "   [IND_PREENCHIDO]) ";
                query += " VALUES ";
                query += "   (" + Numero + ", ";
                query += "   '" + Revisao + "', ";
                query += "   '" + pPpciCompleto + "', ";
                query += "   '" + pAprovBombeiros + "', ";
                query += "   '" + pInstalHidrantes + "', ";
                query += "   '" + pInstalSprinklers + "', ";
                query += "   '" + pInstalExtintores + "', ";
                query += "   '" + pInstalAlarme + "', ";
                query += "   '" + pInstalIluminacao + "', ";
                query += "   '" + pInstalSinalizacao + "', ";
                query += "   '" + pInstalAr + "', ";
                query += "   '" + pInstalAguaP + "', ";
                query += "   '" + pInstalAguaInd + "', ";
                query += "   '" + pInstalAguaGel + "', ";
                query += "   '" + pInstalAguaQuente + "', ";
                query += "   '" + pInstalVaporCond + "', ";
                query += "   '" + pInstalGas + "', ";
                query += "   '" + pMemorialDesc + "', ";
                query += "   '" + pListaMateriais + "', ";
                query += "   '" + indOutro + "', ";
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
        /// Atualiza os dados do Escopo 17_3
        /// </summary>
        /// <param name="pDescServico"></param>
        /// <param name="pIndPre"></param>
        /// <returns></returns>
        public int updateEscopo_17_3(string pPpciCompleto, string pAprovBombeiros, string pInstalHidrantes, string pInstalSprinklers, string pInstalExtintores, string pInstalAlarme, string pInstalIluminacao, string pInstalSinalizacao, string pInstalAr, string pInstalAguaP, string pInstalAguaInd, string pInstalAguaGel, string pInstalAguaQuente, string pInstalVaporCond, string pInstalGas, string pMemorialDesc, string pListaMateriais, string indOutro, string pObs, string pIndPre)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " UPDATE [DOM_SOLIC_ORC_ESCOPO_17_3] ";
                query += "   SET [IND_PPCI_COMPLETO] = '" + pPpciCompleto + "', ";
                query += "       [IND_APROV_BOMBEIROS] = '" + pAprovBombeiros + "', ";
                query += "       [IND_INSTAL_HIDRANTES] = '" + pInstalHidrantes + "', ";
                query += "       [IND_INSTAL_SPRINKLERS] = '" + pInstalSprinklers + "', ";
                query += "       [IND_INSTAL_EXTINTORES] = '" + pInstalExtintores + "', ";
                query += "       [IND_INSTAL_ALARME_INCENDIO] = '" + pInstalAlarme + "', ";
                query += "       [IND_INSTAL_ILUMINACAO_EMERG] = '" + pInstalIluminacao + "', ";
                query += "       [IND_INSTAL_SINALIZACAO_EMERG] = '" + pInstalSinalizacao + "', ";
                query += "       [IND_INSTAL_AR_COMPRIMIDO] = '" + pInstalAr + "', ";
                query += "       [IND_INSTAL_AGUA_POTAVEL] = '" + pInstalAguaP + "', ";
                query += "       [IND_INSTAL_AGUA_INDUSTRIAL] = '" + pInstalAguaInd + "', ";
                query += "       [IND_INSTAL_AGUA_GELADA] = '" + pInstalAguaGel + "', ";
                query += "       [IND_INSTAL_AGUA_QUENTE] = '" + pInstalAguaQuente + "', ";
                query += "       [IND_INSTAL_VAPOR_CONDENSADO] = '" + pInstalVaporCond + "', ";
                query += "       [IND_INSTAL_GAS] = '" + pInstalGas + "', ";
                query += "       [IND_MEMORIAL_DESCRITIVO] = '" + pMemorialDesc + "', ";
                query += "       [IND_LISTA_MATERIAIS] = '" + pListaMateriais + "', ";
                query += "       [IND_OUTRO] = '" + indOutro + "', ";
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
        /// Busca os dados do Escopo 17_3
        /// </summary>
        /// <returns></returns>
        public DataTable getEscopo_17_3()
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                DataTable dt = new DataTable();
                string sql;
                sql = "SELECT * FROM [DOM_SOLIC_ORC_ESCOPO_17_3] ";
                sql += " WHERE [NUMERO_SOLICITACAO] = " + Numero + " ";
                sql += " AND [REVISAO_SOLICITACAO] = '" + Revisao + "' ";
                dt = sqlce.selectListaSOF(sql, "DOM_SOLIC_ORC_ESCOPO_17_3");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Apaga os dados do Escopo 17_3
        /// </summary>
        /// <param name="pNumero"></param>
        /// <param name="pRevisao"></param>
        /// <returns></returns>
        public int deleteEscopo_17_3(string pNumero, string pRevisao)
        {
            SqlCE sqlce = new SqlCE();
            sqlce.openConnection();
            try
            {
                int retorno;
                string query = "";
                query += " DELETE FROM [DOM_SOLIC_ORC_ESCOPO_17_3] ";
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
