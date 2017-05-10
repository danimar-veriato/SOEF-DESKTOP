using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORCAMENTOS_FOCKINK
{
    public class ClientesRepresentante
    {
        //Atributos pertinentes aos clientes do representante

        public string cod_representante { get; set; }
        public string empr_codigo_repres { get; set; }
        public string cod_cliente { get; set; }
        public string razao_social { get; set; }
        public string cgc_cpf { get; set; }
        public string inscricao_estadual { get; set; }
        public string cidade { get; set; }
        public string sigla_uf { get; set; }
        public string pais { get; set; }

    }
}
