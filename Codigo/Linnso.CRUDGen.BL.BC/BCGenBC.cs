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
            bc.WriteLine("    public class " + _objTablaBE.Nombre_Sin_Espacios + "BC");
            bc.WriteLine("    {");
            bc.WriteLine("        " + _objTablaBE.Nombre_Sin_Espacios + "DALC obj" + _objTablaBE.Nombre_Sin_Espacios + "DALC = new " + _objTablaBE.Nombre_Sin_Espacios + "DALC();");
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

                bc.WriteLine("        public " + (n_identity == 1 ? "int" : "void") + " Insert_" + _objTablaBE.Nombre_Sin_Espacios + "(" + _objTablaBE.Nombre_Sin_Espacios + "BE obj" + _objTablaBE.Nombre_Sin_Espacios + "BE)");
                bc.WriteLine("        {");
                bc.WriteLine("            try");
                bc.WriteLine("            {");
                bc.WriteLine("                " + (n_identity == 1 ? "return " : "") + "obj" + _objTablaBE.Nombre_Sin_Espacios + "DALC.Insert_" + _objTablaBE.Nombre_Sin_Espacios + "(obj" + _objTablaBE.Nombre_Sin_Espacios + "BE);");
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
                    bc.WriteLine("        public void Update_" + _objTablaBE.Nombre_Sin_Espacios + "(" + _objTablaBE.Nombre_Sin_Espacios + "BE obj" + _objTablaBE.Nombre_Sin_Espacios + "BE)");
                    bc.WriteLine("        {");
                    bc.WriteLine("            try");
                    bc.WriteLine("            {");
                    bc.WriteLine("                obj" + _objTablaBE.Nombre_Sin_Espacios + "DALC.Update_" + _objTablaBE.Nombre_Sin_Espacios + "(obj" + _objTablaBE.Nombre_Sin_Espacios + "BE);");
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

                    bc.WriteLine("        public " + (n_identity == 1 ? "int" : "void") + " Insert_Update_" + _objTablaBE.Nombre_Sin_Espacios + "(" + _objTablaBE.Nombre_Sin_Espacios + "BE obj" + _objTablaBE.Nombre_Sin_Espacios + "BE)");
                    bc.WriteLine("        {");
                    bc.WriteLine("            try");
                    bc.WriteLine("            {");
                    bc.WriteLine("                " + (n_identity == 1 ? "return " : "") + "obj" + _objTablaBE.Nombre_Sin_Espacios + "DALC.Insert_Update_" + _objTablaBE.Nombre_Sin_Espacios + "(obj" + _objTablaBE.Nombre_Sin_Espacios + "BE);");
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
                bc.WriteLine("        public void Delete_" + _objTablaBE.Nombre_Sin_Espacios + "(" + ToolBC.KeyParametersSQL(_lstColumnaBE) + ")");
                bc.WriteLine("        {");
                bc.WriteLine("            try");
                bc.WriteLine("            {");
                bc.WriteLine("                obj" + _objTablaBE.Nombre_Sin_Espacios + "DALC.Delete_" + _objTablaBE.Nombre_Sin_Espacios + "(" + ToolBC.KeyVariables(_lstColumnaBE) + ");");
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
                bc.WriteLine("        public List<" + _objTablaBE.Nombre_Sin_Espacios + "BE> Select_" + _objTablaBE.Nombre_Sin_Espacios + "()");
                bc.WriteLine("        {");
                bc.WriteLine("            try");
                bc.WriteLine("            {");
                bc.WriteLine("                return obj" + _objTablaBE.Nombre_Sin_Espacios + "DALC.Select_" + _objTablaBE.Nombre_Sin_Espacios + "();");
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
                bc.WriteLine("        public " + _objTablaBE.Nombre_Sin_Espacios + "BE Get_" + _objTablaBE.Nombre_Sin_Espacios + "(" + ToolBC.KeyParametersSQL(_lstColumnaBE) + ")");
                bc.WriteLine("        {");
                bc.WriteLine("            try");
                bc.WriteLine("            {");
                bc.WriteLine("                return obj" + _objTablaBE.Nombre_Sin_Espacios + "DALC.Get_" + _objTablaBE.Nombre_Sin_Espacios + "(" + ToolBC.KeyVariables(_lstColumnaBE) + ");");
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
}
