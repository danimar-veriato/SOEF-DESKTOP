using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOEFC;


namespace SOEF_CLASS
{
    class Escopo_19 : Escopo
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
        public void gravaEscopo19(string indAberturaFechamentoValas, string indCaixaInspecao, string indBasePostes, string indBaseSubestacao, string indCasaBombas, string indOutroEscopo, string descricaOutroEscopo, string observacao)
        {
            SqlCE sqlce = new SqlCE();
            try
            {
                string query = "";
                query += "  INSERT INTO[DOM_SOLIC_ORC_ESCOPO_19] ";
                query += " ([NUMERO_SOLICITACAO], ";
                query += " [REVISAO_SOLICITACAO], ";
                query += " [IND_ABERTURA_FEC_VALAS], ";
                query += " [IND_CAIXA_INSPECAO], ";
                query += " [IND_BASE_POSTES], ";
                query += " [IND_BASE_SUBESTACAO], ";
                query += " [IND_CASA_BOMBAS], ";
                query += " [IND_OUTRO_ESCOPO], ";
                query += " [DESC_OUTRO_ESCOPO], ";
                query += " [OBSERVACOES]) ";
                query += "";


            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
