using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Configuration;
using System.Windows.Forms;

namespace SOEF_CLASS
{
    class SqlCE
    {
        private static SqlCeConnection objSqlCeConnection = null;
        private static SqlCE objSqlServerCe = null;
        private static SqlCE objManipulaBD;
        private static string stringConn;

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public SqlCE()
        {
            SqlCeConnection conn = new SqlCeConnection();
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory);
            SqlCeConnection c = new SqlCeConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SOFDB"].ToString());
        }


    }
}