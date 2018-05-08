using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Linnso.CRUDGen.BL.BE;

namespace Linnso.CRUDGen.BL.BC
{
    public class BCGenBC
    {
        public String _Ruta { get; set; }
        public TablaBE _objTablaBE { get; set; }
        public List<ColumnaBE> _lstColumnaBE { get; set; }
        public int _DataSource { get; set; }
        public string _CampoHabilitado { get; set; }

        public void GenerarHeader(String nsBC, String nsDALC, String nsBE)
        {
            StreamWriter bc = File.AppendText(_Ruta);

            bc.WriteLine("using System;");
            bc.WriteLine("using System.Collections.Generic;");
            bc.WriteLine("using System.Linq;");
            bc.WriteLine("using System.Text;");
            bc.WriteLine("using " + nsDALC + ";");
            bc.WriteLine("using " + nsBE + ";");

            bc.WriteLine("");
            bc.WriteLine("namespace " + nsBC);
            bc.WriteLine("{");
            bc.WriteLine("    public class " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BC");
            bc.WriteLine("    {");
            bc.WriteLine("        " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC = new " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC();");
            bc.WriteLine("");

            bc.Close();
        }

        public void GenerarFooter()
        {
            StreamWriter bc = File.AppendText(_Ruta);

            bc.WriteLine("    }");
            bc.WriteLine("}");

            bc.Close();
        }

        public void GenerarInsert()
        {
            StreamWriter bc = File.AppendText(_Ruta);

            try
            {
                int n_identity = (from c in _lstColumnaBE where c.Es_Identity select c).Count();

                bc.WriteLine("        public " + (n_identity == 1 ? "int" : "void") + " Insert_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE)");
                bc.WriteLine("        {");
                bc.WriteLine("            try");
                bc.WriteLine("            {");
                bc.WriteLine("                " + (n_identity == 1 ? "return " : "") + "obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC.Insert_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE);");
                bc.WriteLine("            }");
                bc.WriteLine("            catch(Exception)");
                bc.WriteLine("            {");
                bc.WriteLine("                throw;");
                bc.WriteLine("            }");
                bc.WriteLine("        }");
                bc.WriteLine("");

                bc.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GenerarUpdate()
        {
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            if (n_no_pk != 0 && n_pk != 0)
            {
                StreamWriter bc = File.AppendText(_Ruta);

                try
                {
                    bc.WriteLine("        public void Update_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE)");
                    bc.WriteLine("        {");
                    bc.WriteLine("            try");
                    bc.WriteLine("            {");
                    bc.WriteLine("                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC.Update_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE);");
                    bc.WriteLine("            }");
                    bc.WriteLine("            catch(Exception)");
                    bc.WriteLine("            {");
                    bc.WriteLine("                throw;");
                    bc.WriteLine("            }");
                    bc.WriteLine("        }");
                    bc.WriteLine("");

                    bc.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void GenerarInsertUpdate()
        {
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            if (n_no_pk != 0 && n_pk != 0)
            {
                StreamWriter bc = File.AppendText(_Ruta);

                try
                {
                    int n_identity = (from c in _lstColumnaBE where c.Es_Identity select c).Count();

                    bc.WriteLine("        public " + (n_identity == 1 ? "int" : "void") + " Insert_Update_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE)");
                    bc.WriteLine("        {");
                    bc.WriteLine("            try");
                    bc.WriteLine("            {");
                    bc.WriteLine("                " + (n_identity == 1 ? "return " : "") + "obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC.Insert_Update_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE);");
                    bc.WriteLine("            }");
                    bc.WriteLine("            catch(Exception)");
                    bc.WriteLine("            {");
                    bc.WriteLine("                throw;");
                    bc.WriteLine("            }");
                    bc.WriteLine("        }");
                    bc.WriteLine("");

                    bc.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void GenerarDelete()
        {
            StreamWriter bc = File.AppendText(_Ruta);

            try
            {
                bc.WriteLine("        public void Delete_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.KeyParameters(_lstColumnaBE, _DataSource) + ")");
                bc.WriteLine("        {");
                bc.WriteLine("            try");
                bc.WriteLine("            {");
                bc.WriteLine("                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC.Delete_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.KeyVariables(_lstColumnaBE) + ");");
                bc.WriteLine("            }");
                bc.WriteLine("            catch(Exception)");
                bc.WriteLine("            {");
                bc.WriteLine("                throw;");
                bc.WriteLine("            }");
                bc.WriteLine("        }");
                bc.WriteLine("");

                bc.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GenerarSelect()
        {
            StreamWriter bc = File.AppendText(_Ruta);

            try
            {
                bc.WriteLine("        public List<" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE> Select_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "()");
                bc.WriteLine("        {");
                bc.WriteLine("            try");
                bc.WriteLine("            {");
                bc.WriteLine("                return obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC.Select_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "();");
                bc.WriteLine("            }");
                bc.WriteLine("            catch(Exception)");
                bc.WriteLine("            {");
                bc.WriteLine("                throw;");
                bc.WriteLine("            }");
                bc.WriteLine("        }");
                bc.WriteLine("");

                bc.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GenerarGet()
        {
            StreamWriter bc = File.AppendText(_Ruta);

            try
            {
                bc.WriteLine("        public " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE Get_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.KeyParameters(_lstColumnaBE, _DataSource) + ")");
                bc.WriteLine("        {");
                bc.WriteLine("            try");
                bc.WriteLine("            {");
                bc.WriteLine("                return obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC.Get_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.KeyVariables(_lstColumnaBE) + ");");
                bc.WriteLine("            }");
                bc.WriteLine("            catch(Exception)");
                bc.WriteLine("            {");
                bc.WriteLine("                throw;");
                bc.WriteLine("            }");
                bc.WriteLine("        }");
                bc.WriteLine("");

                bc.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GenerarChangeState()
        {
            try
            {
                int n_activo = (from c in _lstColumnaBE where c.Nombre == _CampoHabilitado select c).Count();

                if (n_activo > 0)
                {
                    int n_habilitado = (from c in _lstColumnaBE where c.Nombre == _CampoHabilitado select c).Count();
                    StreamWriter bc = File.AppendText(_Ruta);

                    bc.WriteLine("        public void Change_State_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.KeyParameters(_lstColumnaBE, _DataSource) + ")");
                    bc.WriteLine("        {");
                    bc.WriteLine("            try");
                    bc.WriteLine("            {");
                    bc.WriteLine("                obj" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "DALC.Change_State_" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "(" + ToolBC.KeyVariables(_lstColumnaBE) + ");");
                    bc.WriteLine("            }");
                    bc.WriteLine("            catch(Exception)");
                    bc.WriteLine("            {");
                    bc.WriteLine("                throw;");
                    bc.WriteLine("            }");
                    bc.WriteLine("        }");
                    bc.WriteLine("");

                    bc.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
