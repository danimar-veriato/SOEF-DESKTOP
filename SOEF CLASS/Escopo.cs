using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOEFC
{   /// <summary>
    /// Classe pai do Escopo. A partir dessa classe, os escopos vão herdar as propriedades padrões
    /// </summary>
    public class Escopo
    {
        //Atributos padrão entre os escopos
        public string Numero { get; set; }
        public string Revisao { get; set; }
        protected string Observacoes { get; set; }
        

    }
}
