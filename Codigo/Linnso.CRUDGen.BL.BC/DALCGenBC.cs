using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Linnso.CRUDGen.BL.BE;

namespace Linnso.CRUDGen.BL.BC
{
    public class DALCGenBC
    {
        public String _Ruta { get; set; }
        public int _DataSource { get; set; }
        public bool _Tool { get; set; } //Indica si la cadena de conexión viene de Tool.cs o no
        public String _Tag { get; set; } //Tag de la cadena de conexion;
        public TablaBE _objTablaBE { get; set; }
        public List<ColumnaBE> _lstColumnaBE { get; set; }
        public string _CampoUsuarioCreacion { get; set; }
        public string _CampoUsuarioModificacion { get; set; }
        public string _CampoFechaCreacion { get; set; }
        public string _CampoFechaModificacion { get; set; }
        public string _CampoHabilitado { get; set; }

        #region SQL Server
        public void SQLGenerarInsert()
        {
            StreamWriter dalc = File.AppendText(_Ruta);

            int n_creador = (from c in _lstColumnaBE where c.Nombre == _CampoUsuarioCreacion select c).Count();
            int n_modificador = (from c in _lstColumnaBE where c.Nombre == _CampoUsuarioModificacion select c).Count();
            int n_parametros = (from c in _lstColumnaBE where !c.Es_Identity && c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoFechaModificacion && c.Nombre != _CampoHabilitado select c).Count();
            int n_identity = (from c in _lstColumnaBE where c.Es_Identity select c).Count();

            if (n_creador == 1 && n_modificador == 1)
                n_parametros--;

            dalc.WriteLine("        public " + (n_identity == 1 ? "int" : "void") + " Insert_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE)");
            dalc.WriteLine("        {");
            dalc.WriteLine("            String cadena;");
            dalc.WriteLine("            String sql = \"" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Insert\";");
            dalc.WriteLine("            SqlParameter[] arrParameters = new SqlParameter[" + n_parametros.ToString() + "];");
            if (n_identity == 1)
                dalc.WriteLine("            int codigo = 0;");
            dalc.WriteLine("");
            dalc.WriteLine("            try");
            dalc.WriteLine("            {");
            dalc.WriteLine("                cadena = " + (_Tool ? ToolGenBC.GetNombreFuncion() : ToolGenBC.GetCadenaConexion(_Tag)));
            dalc.WriteLine("");
            dalc.WriteLine("                using(SqlConnection conn = new SqlConnection(cadena))");
            dalc.WriteLine("                {");
            dalc.WriteLine("                    using(SqlCommand cmd = conn.CreateCommand())");
            dalc.WriteLine("                    {");
            dalc.WriteLine("                        cmd.CommandText = sql;");
            dalc.WriteLine("                        cmd.CommandType = CommandType.StoredProcedure;");
            dalc.WriteLine("");

            int index = 0;

            foreach (ColumnaBE c in _lstColumnaBE)
            {
                if (!c.Es_Identity && c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoFechaModificacion && c.Nombre != _CampoHabilitado)
                {
                    if (c.Nombre == _CampoUsuarioModificacion)
                    {
                        if (!(n_creador == 1 && n_modificador == 1))
                        {
                            dalc.WriteLine("                        arrParameters[" + index.ToString() + "] = new SqlParameter(\"@" + ToolBC.StandarizarNombreParametro(c.Nombre) + "\", obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE." + ToolBC.StandarizarNombreClase(c.Nombre) + ");");
                            index++;
                        }
                    }
                    else
                    {
                        dalc.WriteLine("                        arrParameters[" + index.ToString() + "] = new SqlParameter(\"@" + ToolBC.StandarizarNombreParametro(c.Nombre) + "\", obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE." + ToolBC.StandarizarNombreClase(c.Nombre) + ");");
                        index++;
                    }
                }
            }

            dalc.WriteLine("");
            dalc.WriteLine("                        for (int i = 0; i < arrParameters.Length; i++)");
            dalc.WriteLine("                            cmd.Parameters.Add(arrParameters[i]);");
            dalc.WriteLine("");
            dalc.WriteLine("                        cmd.Connection.Open();");
            dalc.WriteLine("");
            if (n_identity == 1)
            {
                dalc.WriteLine("                        codigo = Convert.ToInt32(cmd.ExecuteScalar());");
            }
            else
            {
                dalc.WriteLine("                        cmd.ExecuteNonQuery();");
            }
            dalc.WriteLine("                    }");
            dalc.WriteLine("                }");
            dalc.WriteLine("");
            if (n_identity == 1)
                dalc.WriteLine("                return codigo;");
            dalc.WriteLine("            }");
            dalc.WriteLine("            catch(Exception)");
            dalc.WriteLine("            {");
            dalc.WriteLine("                throw;");
            dalc.WriteLine("            }");
            dalc.WriteLine("        }");
            dalc.WriteLine("");
            dalc.Close();
        }

        public void SQLGenerarUpdate()
        {
            int n_parametros = (from c in _lstColumnaBE 
                                where !c.Es_PK && c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoFechaModificacion && c.Nombre != _CampoUsuarioCreacion && c.Nombre != _CampoHabilitado select c).Count();
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            if (n_parametros != 0 && n_pk != 0)
            {
                StreamWriter dalc = File.AppendText(_Ruta);

                dalc.WriteLine("        public void Update_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE)");
                dalc.WriteLine("        {");
                dalc.WriteLine("            String cadena;");
                dalc.WriteLine("            String sql = \"" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Update\";");
                dalc.WriteLine("            SqlParameter[] arrParameters = new SqlParameter[" + (n_parametros + n_pk) + "];");
                dalc.WriteLine("");
                dalc.WriteLine("            try");
                dalc.WriteLine("            {");
                dalc.WriteLine("                cadena = " + (_Tool ? ToolGenBC.GetNombreFuncion() : ToolGenBC.GetCadenaConexion(_Tag)));
                dalc.WriteLine("");
                dalc.WriteLine("                using(SqlConnection conn = new SqlConnection(cadena))");
                dalc.WriteLine("                {");
                dalc.WriteLine("                    using(SqlCommand cmd = conn.CreateCommand())");
                dalc.WriteLine("                    {");
                dalc.WriteLine("                        cmd.CommandText = sql;");
                dalc.WriteLine("                        cmd.CommandType = CommandType.StoredProcedure;");
                dalc.WriteLine("");

                int index = 0;
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (c.Nombre != _CampoUsuarioCreacion && c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoFechaModificacion && c.Nombre != _CampoHabilitado)
                    {
                        dalc.WriteLine("                        arrParameters[" + index.ToString() + "] = new SqlParameter(\"@" + ToolBC.StandarizarNombreParametro(c.Nombre) + "\", obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE." + ToolBC.StandarizarNombreClase(c.Nombre) + ");");
                        index++;
                    }
                }

                dalc.WriteLine("");
                dalc.WriteLine("                        for (int i = 0; i < arrParameters.Length; i++)");
                dalc.WriteLine("                            cmd.Parameters.Add(arrParameters[i]);");
                dalc.WriteLine("");
                dalc.WriteLine("                        cmd.Connection.Open();");
                dalc.WriteLine("                        cmd.ExecuteNonQuery();");
                dalc.WriteLine("                    }");
                dalc.WriteLine("                }");
                dalc.WriteLine("            }");
                dalc.WriteLine("            catch(Exception)");
                dalc.WriteLine("            {");
                dalc.WriteLine("                throw;");
                dalc.WriteLine("            }");
                dalc.WriteLine("        }");
                dalc.WriteLine("");
                dalc.Close();
            }
        }

        public void SQLGenerarInsertUpdate()
        {
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            if (n_no_pk != 0 && n_pk != 0)
            {
                StreamWriter dalc = File.AppendText(_Ruta);

                int n_identity = (from c in _lstColumnaBE where c.Es_Identity select c).Count();

                dalc.WriteLine("        public " + (n_identity == 1 ? "int" : "void") + " Insert_Update_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE)");
                dalc.WriteLine("        {");
                dalc.WriteLine("            String cadena;");
                dalc.WriteLine("            String sql = \"" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Insert_Update\";");
                if (n_identity == 1)
                    dalc.WriteLine("            int codigo = 0;");
                dalc.WriteLine("            SqlParameter[] arrParameters = new SqlParameter[" + _lstColumnaBE.Count + "];");
                dalc.WriteLine("");
                dalc.WriteLine("            try");
                dalc.WriteLine("            {");
                dalc.WriteLine("                cadena = " + (_Tool ? ToolGenBC.GetNombreFuncion() : ToolGenBC.GetCadenaConexion(_Tag)));
                dalc.WriteLine("");
                dalc.WriteLine("                using(SqlConnection conn = new SqlConnection(cadena))");
                dalc.WriteLine("                {");
                dalc.WriteLine("                    using(SqlCommand cmd = conn.CreateCommand())");
                dalc.WriteLine("                    {");
                dalc.WriteLine("                        cmd.CommandText = sql;");
                dalc.WriteLine("                        cmd.CommandType = CommandType.StoredProcedure;");
                dalc.WriteLine("");

                int index = 0;

                String identity = "";
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    dalc.WriteLine("                        arrParameters[" + index.ToString() + "] = new SqlParameter(\"@" + ToolBC.StandarizarNombreParametro(c.Nombre) + "\", obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE." + ToolBC.StandarizarNombreClase(c.Nombre) + ");");
                    index++;
                    if (c.Es_Identity)
                        identity = c.Nombre;
                }

                dalc.WriteLine("");
                dalc.WriteLine("                        for (int i = 0; i < arrParameters.Length; i++)");
                dalc.WriteLine("                            cmd.Parameters.Add(arrParameters[i]);");
                dalc.WriteLine("");
                dalc.WriteLine("                        cmd.Connection.Open();");
                if (n_identity == 1)
                {
                    dalc.WriteLine("                        codigo = Convert.ToInt32(cmd.ExecuteScalar());");
                }
                else
                {
                    dalc.WriteLine("                        cmd.ExecuteNonQuery();");
                }
                dalc.WriteLine("                    }");
                dalc.WriteLine("                }");
                dalc.WriteLine("");
                if (n_identity == 1)
                    dalc.WriteLine("                return codigo;");
                dalc.WriteLine("            }");
                dalc.WriteLine("            catch(Exception)");
                dalc.WriteLine("            {");
                dalc.WriteLine("                throw;");
                dalc.WriteLine("            }");
                dalc.WriteLine("        }");
                dalc.WriteLine("");
                dalc.Close();
            }
        }

        public void SQLGenerarDelete()
        {
            StreamWriter dalc = File.AppendText(_Ruta);

            int n_key = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            dalc.WriteLine("        public void Delete_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.KeyParametersSQL(_lstColumnaBE) + ")");
            dalc.WriteLine("        {");
            dalc.WriteLine("            String cadena;");
            dalc.WriteLine("            String sql = \"" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Delete\";");
            dalc.WriteLine("            SqlParameter[] arrParameters = new SqlParameter[" + n_key + "];");
            dalc.WriteLine("");
            dalc.WriteLine("            try");
            dalc.WriteLine("            {");
            dalc.WriteLine("                cadena = " + (_Tool ? ToolGenBC.GetNombreFuncion() : ToolGenBC.GetCadenaConexion(_Tag)));
            dalc.WriteLine("");
            dalc.WriteLine("                using(SqlConnection conn = new SqlConnection(cadena))");
            dalc.WriteLine("                {");
            dalc.WriteLine("                    using(SqlCommand cmd = conn.CreateCommand())");
            dalc.WriteLine("                    {");
            dalc.WriteLine("                        cmd.CommandText = sql;");
            dalc.WriteLine("                        cmd.CommandType = CommandType.StoredProcedure;");
            dalc.WriteLine("");
            KeyParameters(dalc);
            dalc.WriteLine("");
            dalc.WriteLine("                        for (int i = 0; i < arrParameters.Length; i++)");
            dalc.WriteLine("                            cmd.Parameters.Add(arrParameters[i]);");
            dalc.WriteLine("");
            dalc.WriteLine("                        cmd.Connection.Open();");
            dalc.WriteLine("                        cmd.ExecuteNonQuery();");
            dalc.WriteLine("                    }");
            dalc.WriteLine("                }");
            dalc.WriteLine("            }");
            dalc.WriteLine("            catch(Exception)");
            dalc.WriteLine("            {");
            dalc.WriteLine("                throw;");
            dalc.WriteLine("            }");
            dalc.WriteLine("        }");
            dalc.WriteLine("");
            dalc.Close();
        }

        public void SQLGenerarSelect()
        {
            StreamWriter dalc = File.AppendText(_Ruta);

            dalc.WriteLine("        public List<" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE> Select_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "()");
            dalc.WriteLine("        {");
            dalc.WriteLine("            String cadena;");
            dalc.WriteLine("            String sql = \"" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Select\";");
            dalc.WriteLine("            " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE = null;");
            dalc.WriteLine("            List<" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE> lst" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE = null;");
            dalc.WriteLine("");
            dalc.WriteLine("            try");
            dalc.WriteLine("            {");
            dalc.WriteLine("                cadena = " + (_Tool ? ToolGenBC.GetNombreFuncion() : ToolGenBC.GetCadenaConexion(_Tag)));
            dalc.WriteLine("");
            dalc.WriteLine("                using(SqlConnection conn = new SqlConnection(cadena))");
            dalc.WriteLine("                {");
            dalc.WriteLine("                    using(SqlCommand cmd = conn.CreateCommand())");
            dalc.WriteLine("                    {");
            dalc.WriteLine("                        cmd.CommandText = sql;");
            dalc.WriteLine("                        cmd.CommandType = CommandType.StoredProcedure;");
            dalc.WriteLine("");
            dalc.WriteLine("                        cmd.Connection.Open();");
            dalc.WriteLine("");
            dalc.WriteLine("                        using(SqlDataReader dr = cmd.ExecuteReader())");
            dalc.WriteLine("                        {");
            dalc.WriteLine("                            while(dr.Read())");
            dalc.WriteLine("                            {");
            dalc.WriteLine("                                if(lst" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE == null)");
            dalc.WriteLine("                                    lst" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE = new List<" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE>();");
            dalc.WriteLine("");
            dalc.WriteLine("                                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE = new " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE();");
            SQLClassFromDR(dalc);
            dalc.WriteLine("");
            dalc.WriteLine("                                lst" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE.Add(obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE);");
            dalc.WriteLine("                            }");
            dalc.WriteLine("                        }");
            dalc.WriteLine("                    }");
            dalc.WriteLine("                }");
            dalc.WriteLine("");
            dalc.WriteLine("                return lst" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE;");
            dalc.WriteLine("            }");
            dalc.WriteLine("            catch(Exception)");
            dalc.WriteLine("            {");
            dalc.WriteLine("                throw;");
            dalc.WriteLine("            }");
            dalc.WriteLine("        }");
            dalc.WriteLine("");

            dalc.Close();
        }

        public void SQLGenerarGet()
        {
            StreamWriter dalc = File.AppendText(_Ruta);

            int n_key = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            dalc.WriteLine("        public " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE Get_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.KeyParametersSQL(_lstColumnaBE) + ")");
            dalc.WriteLine("        {");
            dalc.WriteLine("            String cadena;");
            dalc.WriteLine("            String sql = \"" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Get\";");
            dalc.WriteLine("            SqlParameter[] arrParameters = new SqlParameter[" + n_key + "];");
            dalc.WriteLine("            " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE = null;");
            dalc.WriteLine("");
            dalc.WriteLine("            try");
            dalc.WriteLine("            {");
            dalc.WriteLine("                cadena = " + (_Tool ? ToolGenBC.GetNombreFuncion() : ToolGenBC.GetCadenaConexion(_Tag)));
            dalc.WriteLine("");
            dalc.WriteLine("                using(SqlConnection conn = new SqlConnection(cadena))");
            dalc.WriteLine("                {");
            dalc.WriteLine("                    using(SqlCommand cmd = conn.CreateCommand())");
            dalc.WriteLine("                    {");
            dalc.WriteLine("                        cmd.CommandText = sql;");
            dalc.WriteLine("                        cmd.CommandType = CommandType.StoredProcedure;");
            dalc.WriteLine("");
            KeyParameters(dalc);
            dalc.WriteLine("");
            dalc.WriteLine("                        for (int i = 0; i < arrParameters.Length; i++)");
            dalc.WriteLine("                            cmd.Parameters.Add(arrParameters[i]);");
            dalc.WriteLine("");
            dalc.WriteLine("                        cmd.Connection.Open();");
            dalc.WriteLine("");
            dalc.WriteLine("                        using(SqlDataReader dr = cmd.ExecuteReader())");
            dalc.WriteLine("                        {");
            dalc.WriteLine("                            while(dr.Read())");
            dalc.WriteLine("                            {");
            dalc.WriteLine("                                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE = new " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE();");
            SQLClassFromDR(dalc);
            dalc.WriteLine("                            }");
            dalc.WriteLine("                        }");
            dalc.WriteLine("                    }");
            dalc.WriteLine("                }");
            dalc.WriteLine("                return obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE;");
            dalc.WriteLine("            }");
            dalc.WriteLine("            catch(Exception)");
            dalc.WriteLine("            {");
            dalc.WriteLine("                throw;");
            dalc.WriteLine("            }");
            dalc.WriteLine("        }");
            dalc.WriteLine("");

            dalc.Close();
        }

        private void SQLClassFromDR(StreamWriter dalc)
        {
            foreach (ColumnaBE c in _lstColumnaBE)
            {
                if (!c.Acepta_Nulos)
                    if (c.Nombre == _CampoFechaCreacion || c.Nombre == _CampoFechaModificacion)
                        dalc.WriteLine("                                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE." + ToolBC.StandarizarNombreClase(c.Nombre) + " = HelperTools.UtcToLocal(" + ToolBC.ConvertFromSQL(c.Tipo_Dato, c.Nombre) + ");");
                    else
                        dalc.WriteLine("                                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE." + ToolBC.StandarizarNombreClase(c.Nombre) + " = " + ToolBC.ConvertFromSQL(c.Tipo_Dato, c.Nombre) + ";");
                else
                {
                    switch (ToolBC.TypeFromSQL(c.Tipo_Dato))
                    {
                        case "object":
                            dalc.WriteLine("                                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE." + ToolBC.StandarizarNombreClase(c.Nombre) + " = dr[\"" + c.Nombre + "\"] != DBNull.Value ? (" + ToolBC.TypeFromSQL(c.Tipo_Dato) + "?)dr[\"" + c.Nombre + "\"]" + " : null;");
                            break;
                        default:
                            if(c.Nombre == _CampoFechaCreacion || c.Nombre == _CampoFechaModificacion)
                                dalc.WriteLine("                                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE." + ToolBC.StandarizarNombreClase(c.Nombre) + " = HelperTools.UtcToLocal(" + ToolBC.ConvertFromSQLNULL(c.Tipo_Dato, c.Nombre) + ");");
                            else
                                dalc.WriteLine("                                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE." + ToolBC.StandarizarNombreClase(c.Nombre) + " = " + ToolBC.ConvertFromSQLNULL(c.Tipo_Dato, c.Nombre) + ";");
                            break;
                    }
                }
            }
        }
        #endregion

        #region MySQL

        #endregion

        #region General
        public void GenerarHeader(String nsDALC, String nsBE, String nsHelper)
        {
            StreamWriter dalc = File.AppendText(_Ruta);

            dalc.WriteLine("using System;");
            dalc.WriteLine("using System.Collections.Generic;");
            dalc.WriteLine("using System.Linq;");
            dalc.WriteLine("using System.Text;");
            dalc.WriteLine("using System.Data;");

            switch (_DataSource)
            {
                case (int)DataSource.SQLServer:
                    dalc.WriteLine("using System.Data.SqlClient;");
                    break;
                case (int)DataSource.MySQL:
                    dalc.WriteLine("using MySql.Data.MySqlClient;");
                    break;
            }
            dalc.WriteLine("using " + nsBE + ";");
            dalc.WriteLine("using " + nsHelper + ";");

            dalc.WriteLine("");
            dalc.WriteLine("namespace " + nsDALC);
            dalc.WriteLine("{");
            dalc.WriteLine("    public class " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC");
            dalc.WriteLine("    {");
            dalc.Close();
        }

        public void GenerarFooter()
        {
            StreamWriter dalc = File.AppendText(_Ruta);

            dalc.WriteLine("    }");
            dalc.WriteLine("}");

            dalc.Close();
        }

        private void KeyParameters(StreamWriter dalc)
        {
            int index = 0;
            foreach (ColumnaBE c in _lstColumnaBE)
            {
                if (c.Es_PK)
                {
                    dalc.WriteLine("                        arrParameters[" + index.ToString() + "] = new SqlParameter(\"@" + ToolBC.StandarizarNombreParametro(c.Nombre) + "\", " + ToolBC.StandarizarNombreParametro(c.Nombre) + ");");
                    index++;
                }
            }
        }
        #endregion
    }
}
