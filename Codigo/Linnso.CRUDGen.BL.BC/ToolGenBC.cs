using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Linnso.CRUDGen.BL.BC
{
    public class ToolGenBC
    {
        public String _Ruta { get; set; }

        public void CrearArchivo(String nsDALC, String tag)
        {
            StreamWriter dalc = File.AppendText(_Ruta);

            dalc.WriteLine("using System;");
            dalc.WriteLine("using System.Configuration;");
            dalc.WriteLine("");
            dalc.WriteLine("namespace " + nsDALC);
            dalc.WriteLine("{");
            dalc.WriteLine("    public class Tool");
            dalc.WriteLine("    {");
            dalc.WriteLine("        public static String GetCadenaConexion()");
            dalc.WriteLine("        {");
            dalc.WriteLine("            return ConfigurationManager.ConnectionStrings[\"" + tag + "\"].ToString();");
            dalc.WriteLine("        }");
            dalc.WriteLine("    }");
            dalc.WriteLine("}");

            dalc.Close();
        }

        public static String GetNombreFuncion()
        {
            return "Tool.GetCadenaConexion();";
        }

        public static String GetCadenaConexion(String tag)
        {
            return "ConfigurationManager.ConnectionStrings[\"" + tag + "\"].ToString();";
        }
    }
}
