using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace ORCAMENTOS_FOCKINK
{
    public class AtualizaBases
    {

        /// <summary>
        /// Atualiza a lista de contatos do representante
        /// </summary>
        /// <param name="p_empr_logada">Empresa logada</param>
        /// <param name="p_cod_representante">Código do representante</param>
        public void atualizaContatos(string p_empr_logada, string p_cod_representante)
        {
            int retorno = 0;

            //Chama a classe que de conexão com o SQL Server
            ManipulaBD mBD = new ManipulaBD();
            try
            {
                //Busca a lista de clientes no WebService
                Representantes.Seguranca login = new Representantes.Seguranca(); //Login = Usuário e Senha para acessar o método do WebService
                login.Usuario = "Fockink";
                login.Senha = "fockink147@1!";
                Representantes.RepresentantesSoapClient representante = new Representantes.RepresentantesSoapClient();
                DataSet dsRetorno = new DataSet();
                dsRetorno = representante.listaContatosClientesRepresentante(login, p_empr_logada, p_cod_representante);
                if (dsRetorno != null && dsRetorno.Tables.Count > 0)
                {
                    //Chama o método para deletar os registros da tabela CLIENTE_REPRESENTANTE
                    retorno = mBD.deleteSOF("DELETE FROM DOM_CONTATO WHERE EMPR_CODIGO=@empr_codigo", p_empr_logada, p_cod_representante);
               //     MessageBox.Show("Retorno Contato: " + retorno);
                    foreach (DataRow dr in dsRetorno.Tables[0].Rows)
                    {
                        string sql = "INSERT INTO [DOM_CONTATO] ";
                        sql += "([CODIGO], [DPES_CODIGO], [EMPR_CODIGO], [NOME], [SETOR], [CARGO], [DDD], [TELEFONE], [TELEFONE_RAMAL], [CELULAR_DDD], [CELULAR], [EMAIL], [ATIVO]) ";
                        sql += "VALUES ('" + dr["CODIGO"].ToString() + "', '" + dr["DPES_CODIGO"].ToString() + "', '" + dr["EMPR_CODIGO"].ToString() + "', '" + dr["NOME"].ToString().Replace("'", "''") + "', '" + dr["SETOR"].ToString() + "', '" + dr["CARGO"].ToString() + "', '" + dr["DDD"].ToString() + "', '" + dr["TELEFONE"].ToString() + "', '" + dr["TELEFONE_RAMAL"].ToString() + "', '" + dr["CELULAR_DDD"].ToString() + "', '" + dr["CELULAR"].ToString() + "', '" + dr["EMAIL"].ToString() + "', '" + dr["ATIVO"].ToString() + "')";
                        //MessageBox.Show(sql);
                        retorno = mBD.insertSOF(sql);

                    }
                    MessageBox.Show("Rows Contato: " + dsRetorno.Tables[0].Rows.Count);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Atualiza a lista de clientes do representante
        /// </summary>
        /// <param name="p_empr_codigo">Empresa logada</param>
        /// <param name="p_cod_representante">Código do representante</param>
        public void atualizaClientes(string p_empr_codigo, string p_cod_representante)
        {
            int retorno = 0;
            //Chama a classe que de conexão com o SQL Server
            ManipulaBD mBD = new ManipulaBD();
            try
            {
                //Busca a lista de clientes no WebService
                Representantes.Seguranca login = new Representantes.Seguranca(); //Login = Usuário e Senha para acessar o método do WebService
                login.Usuario = "Fockink";
                login.Senha = "fockink147@1!";
                Representantes.RepresentantesSoapClient clientes = new Representantes.RepresentantesSoapClient();
                DataSet dsRetorno = new DataSet();
                dsRetorno = clientes.listaClientesRepresentante(login, p_empr_codigo, p_cod_representante); //Método que retorna um DataSet com os clientes do representante

                if (dsRetorno != null && dsRetorno.Tables.Count > 0)
                {
                    retorno = mBD.deleteSOF("DELETE FROM DOM_CLIENTE WHERE COD_REPRESENTANTE=@cod_representante AND EMPR_CODIGO_REPRES=@empr_codigo", p_empr_codigo, p_cod_representante);
               //     MessageBox.Show("Retorno Cliente: " + retorno);
                    foreach (DataRow dr in dsRetorno.Tables[0].Rows)
                    {
                        string sql = "INSERT INTO [DOM_CLIENTE] ";
                        sql += "([COD_REPRESENTANTE], [EMPR_CODIGO_REPRES], [COD_CLIENTE], [RAZAO_SOCIAL], [CGC_CPF], [INSCRICAO_ESTADUAL], [CIDADE], [SIGLA_UF], [PAIS]) ";
                        sql += " VALUES ('" + dr["COD_REPRESENTANTE"].ToString() + "', '" + dr["EMPR_CODIGO_REPRES"].ToString() + "', '" + dr["COD_CLIENTE"].ToString() + "', '" + dr["RAZAO_SOCIAL"].ToString().Replace("'", "''") + "', '" + dr["CGC_CPF"].ToString() + "', '" + dr["INSCRICAO_ESTADUAL"].ToString() + "', '" + dr["CIDADE"].ToString().Replace("'", "''") + "', '" + dr["SIGLA_UF"].ToString() + "', '" + dr["PAIS"].ToString() + "' ) ";
                        retorno = mBD.insertSOF(sql);
                    }
               //     MessageBox.Show("Rows Cliente: " + dsRetorno.Tables[0].Rows.Count);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Atualiza a tabela DOM_TIPO_NEGOCIO p/ lista do cabeçalho da solicitação.
        /// </summary>
        public void atualizaTipoNegocio()
        {
            int retorno = 0;
            //Chama a classe que de conexão com o SQL Server
            ManipulaBD mBD = new ManipulaBD();
            try
            {
                //Busca a lista de clientes no WebService
                Representantes.Seguranca login = new Representantes.Seguranca(); //Login = Usuário e Senha para acessar o método do WebService
                login.Usuario = "Fockink";
                login.Senha = "fockink147@1!";
                Representantes.RepresentantesSoapClient tipoNegocio = new Representantes.RepresentantesSoapClient();
                DataSet dsRetorno = new DataSet();
                dsRetorno = tipoNegocio.listaTipoNegocio(login);

                if (dsRetorno != null && dsRetorno.Tables.Count > 0)
                {
                    retorno = mBD.deleteSOF("DELETE FROM DOM_TIPO_NEGOCIO");
                    foreach (DataRow dr in dsRetorno.Tables[0].Rows)
                    {
                        string sql = "INSERT INTO [DOM_TIPO_NEGOCIO] ";
                        sql += "([CODIGO], [DESCRICAO]) ";
                        sql += " VALUES (" + dr["CODIGO"].ToString() + ", '" + dr["DESCRICAO"].ToString() + "') ";
                        retorno = mBD.insertSOF(sql);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Atualiza a tabela DOM_INDICADOR_NEGOCIO p/ lista do cabeçalho da solicitação.
        /// </summary>
        public void atualizaIndicadorNegocio(string p_empr_codigo)
        {
            int retorno = 0;
            //Chama a classe que de conexão com o SQL Server
            ManipulaBD mBD = new ManipulaBD();
            try
            {
                Representantes.Seguranca login = new Representantes.Seguranca(); //Login = Usuário e Senha para acessar o método do WebService
                login.Usuario = "Fockink";
                login.Senha = "fockink147@1!";
                Representantes.RepresentantesSoapClient indicadorNegocio = new Representantes.RepresentantesSoapClient();
                DataSet dsRetorno = new DataSet();
                dsRetorno = indicadorNegocio.listaIndicadorNegocio(login, p_empr_codigo);

                if (dsRetorno != null && dsRetorno.Tables.Count > 0)
                {
                    retorno = mBD.deleteSOF("DELETE FROM DOM_INDICADOR_NEGOCIO WHERE EMPR_CODIGO = '" + p_empr_codigo + "'");
                    foreach (DataRow dr in dsRetorno.Tables[0].Rows)
                    {
                        string sql = "INSERT INTO [DOM_INDICADOR_NEGOCIO] ";
                        sql += "([EMPR_CODIGO], [DPES_CODIGO], [RAZAO_SOCIAL], [COD_RAZAO_SOCIAL]) ";
                        sql += " VALUES ('" + dr["EMPR_CODIGO"].ToString() + "', " + dr["DPES_CODIGO"].ToString() + ", '" + dr["RAZAO_SOCIAL"].ToString() + "', '" + dr["COD_RAZAO_SOCIAL"].ToString() + "') ";
                        retorno = mBD.insertSOF(sql);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Atualiza a tabela DOM_EVENTO_PAGAMENTO
        /// </summary>
        public void atualizaEventoPagamento()
        {
            int retorno = 0;
            //Chama a classe que de conexão com o SQL Server
            ManipulaBD mBD = new ManipulaBD();
            try
            {
                Representantes.Seguranca login = new Representantes.Seguranca();
                login.Usuario = "Fockink";
                login.Senha = "fockink147@1!";
                Representantes.RepresentantesSoapClient eventoPagamento = new Representantes.RepresentantesSoapClient();
                DataSet dsRetorno = new DataSet();
                dsRetorno = eventoPagamento.listaEventoPagamento(login);
                if (dsRetorno != null && dsRetorno.Tables.Count > 0)
                {
                    retorno = mBD.deleteSOF("DELETE FROM DOM_EVENTO_PAGAMENTO");
                    foreach (DataRow dr in dsRetorno.Tables[0].Rows)
                    {
                        string sql = "INSERT INTO [DOM_EVENTO_PAGAMENTO] ";
                        sql += "([CODIGO], [DESCRICAO]) ";
                        sql += "VALUES ";
                        sql += " (" + dr["CODIGO"].ToString() + ", '" + dr["DESCRICAO"].ToString() + "') ";
                        retorno = mBD.insertSOF(sql);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                mBD.closeConnection();
            }
        }


        /// <summary>
        /// Método que atualiza a tabela DOMOBR_REF_CODES
        /// </summary>
        public void atualizaDomRefCodes()
        {
            int retorno = 0;
            //Chama a classe que de conexão com o SQL Server
            ManipulaBD mBD = new ManipulaBD();
            try
            {
                //Busca a lista de clientes no WebService
                Representantes.Seguranca login = new Representantes.Seguranca(); //Login = Usuário e Senha para acessar o método do WebService
                login.Usuario = "Fockink";
                login.Senha = "fockink147@1!";
                Representantes.RepresentantesSoapClient RefCodes = new Representantes.RepresentantesSoapClient();
                DataSet dsRetorno = new DataSet();
                dsRetorno = RefCodes.listaDomobrRefCodes(login, "FORMA_PAGTO");

                if (dsRetorno != null && dsRetorno.Tables.Count > 0)
                {
                    retorno = mBD.deleteSOF("DELETE FROM [DOMOBR_REF_CODES]");
                    foreach (DataRow dr in dsRetorno.Tables[0].Rows)
                    {
                        string sql = "INSERT INTO [DOMOBR_REF_CODES] ";
                        sql += "([VALOR], [DESCRICAO], [RV_DOMAIN]) ";
                        sql += " VALUES ('" + dr["VALOR"].ToString() + "', ";
                        sql += " '" + dr["DESCRICAO"].ToString() + "', ";
                        sql += " '" + dr["RV_DOMAIN"].ToString() + "')  ";
                        retorno = mBD.insertSOF(sql);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                mBD.closeConnection();
            }
        }



    }
}
