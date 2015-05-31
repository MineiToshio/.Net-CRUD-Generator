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

        public void CrearToolDALC(String nsDALC, String tag)
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

        public void CrearLogBC(String nsBC)
        {
            StreamWriter bc = File.AppendText(_Ruta);

            bc.WriteLine("using System;");
            bc.WriteLine("using System.IO;");
            bc.WriteLine("");
            bc.WriteLine("namespace " + nsBC);
            bc.WriteLine("{");

            bc.WriteLine("    public static void EscribirLog(Exception ex)");
            bc.WriteLine("    {");
            bc.WriteLine("        StreamWriter log;");
            bc.WriteLine("        String ruta = Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory) + @\"\\Error\\ErrorLog.txt\";");
            bc.WriteLine("");
            bc.WriteLine("        if (!File.Exists(@ruta))");
            bc.WriteLine("        {");
            bc.WriteLine("            log = new StreamWriter(@ruta);");
            bc.WriteLine("        }");
            bc.WriteLine("        else");
            bc.WriteLine("        {");
            bc.WriteLine("            log = File.AppendText(@ruta);");
            bc.WriteLine("        }");
            bc.WriteLine("");
            bc.WriteLine("        DateTime now = HelperTools.GetDate();");
            bc.WriteLine("");
            bc.WriteLine("        log.WriteLine(\"Tipo: \" + ex.GetType().FullName);");
            bc.WriteLine("        log.WriteLine(\"Mensaje: \" + ex.Message);");
            bc.WriteLine("        log.WriteLine(\"Fuente: \" + ex.Source);");
            bc.WriteLine("        log.WriteLine(\"StackTrace: \" + ex.StackTrace);");
            bc.WriteLine("        EscribirInner(ex, log, 1);");
            bc.WriteLine("        log.WriteLine(\"Día/Hora: \" + now);");
            bc.WriteLine("        log.WriteLine(\"===========================================================================================\");");
            bc.WriteLine("");
            bc.WriteLine("        log.Close();");
            bc.WriteLine("}");
            bc.WriteLine("");

            bc.WriteLine("    public static void EscribirInner(Exception ex, StreamWriter log, int nroInner)");
            bc.WriteLine("    {");
            bc.WriteLine("        if (ex.InnerException != null)");
            bc.WriteLine("        {");
            bc.WriteLine("            log.WriteLine(\"Inner StackTrace \" + nroInner + \": \" + ex.InnerException.StackTrace);");
            bc.WriteLine("            EscribirInner(ex.InnerException, log, nroInner++);");
            bc.WriteLine("        }");
            bc.WriteLine("        else");
            bc.WriteLine("            return;");
            bc.WriteLine("    }");

            bc.WriteLine("}");

            bc.Close();
        }

        public void CrearToolBC(String nsBC)
        {
            StreamWriter bc = File.AppendText(_Ruta);

            bc.WriteLine("using System;");
            bc.WriteLine("");
            bc.WriteLine("namespace " + nsBC);
            bc.WriteLine("{");

            bc.WriteLine("    public static DateTime GetDate()");
            bc.WriteLine("    {");
            bc.WriteLine("        string zoneId = \"SA Pacific Standard Time\";");
            bc.WriteLine("        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(zoneId);");
            bc.WriteLine("        DateTime now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);");
            bc.WriteLine("");
            bc.WriteLine("        return now;");
            bc.WriteLine("    }");
            bc.WriteLine("");

            bc.WriteLine("    public static DateTime UtcToLocal(DateTime utcTime)");
            bc.WriteLine("    {");
            bc.WriteLine("        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById(\"SA Pacific Standard Time\");");
            bc.WriteLine("        return TimeZoneInfo.ConvertTimeFromUtc(utcTime, cstZone);");
            bc.WriteLine("    }");
            bc.WriteLine("");

            bc.WriteLine("    public static DateTime? UtcToLocal(DateTime? utcTime)");
            bc.WriteLine("    {");
            bc.WriteLine("        if (utcTime != null)");
            bc.WriteLine("        {");
            bc.WriteLine("            return UtcToLocal((DateTime)utcTime);");
            bc.WriteLine("        }");
            bc.WriteLine("        else");
            bc.WriteLine("            return null;");
            bc.WriteLine("    }");
           
            bc.WriteLine("}");

            bc.Close();
        }
    }
}
