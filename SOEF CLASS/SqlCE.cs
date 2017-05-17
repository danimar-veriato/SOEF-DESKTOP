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
    public class SqlCE
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

        /// <summary>
        /// Método que pega a instância da classe
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static SqlCE GetInstance(string connString)
        {
            if (objManipulaBD == null)
            {
                objManipulaBD = new SqlCE();
            }
            return objManipulaBD;
        }


        /// <summary>
        /// Método que abre a conexão com o BD
        /// </summary>
        public void openConnection()
        {
            try
            {
                if (objSqlCeConnection.State == ConnectionState.Closed)
                {
                    objSqlCeConnection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Método que encerra a conexão com o BD
        /// </summary>
        public void closeConnection()
        {
            try
            {
                if (objSqlCeConnection.State != ConnectionState.Closed)
                {
                    objSqlCeConnection.Close();
                    objSqlCeConnection.Dispose();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Carrega os registros de uma tabela em um DataGridView
        /// </summary>
        /// <param name="sql">Consulta SQL</param>
        /// <param name="table">Tabela</param>
        /// <returns></returns>
        public DataSet selectSOF1(string sql, string tabela, string codigo = null)
        {
            SqlCE objManipulaBD = SqlCE.GetInstance(stringConn);
            objManipulaBD.openConnection();
            SqlCeDataAdapter dad = new SqlCeDataAdapter(sql, objSqlCeConnection);
            dad.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            try
            {
                dad.Fill(ds, tabela);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <param name="sql">Consulta SQL</param>
        /// <param name="table">Tabela</param>
        /// <returns></returns>
        public DataTable selectListaSOF(string sql, string table)
        {
            SqlCE objManipulaBD = SqlCE.GetInstance(stringConn);
            objManipulaBD.openConnection();
            SqlCeDataAdapter dad = new SqlCeDataAdapter(sql, objSqlCeConnection);
            dad.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            try
            {
                dad.Fill(ds, table);
                if (ds.Tables[table].Rows.Count > 0)
                {
                    return ds.Tables[table];
                }
                else
                {
                    return ds.Tables[table];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Faz um select no banco retornando um registro em específico
        /// </summary>
        /// <param name="sql">Consulta SQL</param>
        /// <returns></returns>
        public string selectSOF(string sql)
        {
            try
            {
                SqlCE objManipulaBD = SqlCE.GetInstance(stringConn);
                objManipulaBD.openConnection();
                SqlCeCommand cmd = new SqlCeCommand(sql, objSqlCeConnection);
                SqlCeDataReader reader = cmd.ExecuteReader();
                string num = "";
                while (reader.Read())
                {
                    num = reader[0].ToString();
                }
                return num;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Método que apaga um ou todos os registos de uma tabela
        /// </summary>
        /// <param name="sql">Código SQL</param>
        /// <returns></returns>
        public int deleteSOF(string sql, string p_empr_codigo = null, string p_cod_representante = null)
        {
            try
            {
                SqlCE objManipulaBD = SqlCE.GetInstance(stringConn);
                objManipulaBD.openConnection();
                SqlCeCommand cmd = new SqlCeCommand(sql, objSqlCeConnection);
                cmd.CommandType = CommandType.Text;
                if (!string.IsNullOrEmpty(p_empr_codigo))
                {
                    cmd.Parameters.AddWithValue("@empr_codigo", p_empr_codigo);
                }
                if (!string.IsNullOrEmpty(p_cod_representante))
                {
                    cmd.Parameters.AddWithValue("@cod_representante", p_cod_representante);
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Método que faz a inserção de dados no banco
        /// </summary>
        /// <param name="sql">Código SQL</param>
        /// <returns></returns>
        public int insertSOF(string sql, string p_data1 = null, string p_data2 = null)
        {
            try
            {
                SqlCE objManipulaBD = SqlCE.GetInstance(stringConn);
                objManipulaBD.openConnection();
                SqlCeCommand cmd = new SqlCeCommand(sql, objSqlCeConnection);
                if ((!string.IsNullOrEmpty(p_data1)) && (!string.IsNullOrEmpty(p_data2)))
                {
                    //Converte as datas informadas para o formato de inserção no banco
                    System.Globalization.DateTimeFormatInfo dateInfoBr = new System.Globalization.DateTimeFormatInfo();
                    dateInfoBr.ShortDatePattern = "dd/MM/yyyy";
                    DateTime data1 = Convert.ToDateTime(p_data1, dateInfoBr);
                    DateTime data2 = Convert.ToDateTime(p_data2, dateInfoBr);
                    cmd.Parameters.Add("@p_data1", SqlDbType.DateTime).Value = data1;
                    cmd.Parameters.Add("@p_data2", SqlDbType.DateTime).Value = data2;
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                MessageBox.Show("SQL ERRO: " + sql);
                MessageBox.Show("ERRO INSERT: " + exc.ToString());
                throw;
            }
        }




    }
}