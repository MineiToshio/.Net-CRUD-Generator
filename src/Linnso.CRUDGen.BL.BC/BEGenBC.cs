using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Linnso.CRUDGen.BL.BE;

namespace Linnso.CRUDGen.BL.BC
{
    public class BEGenBC
    {
        public String _Ruta { get; set; }
        public TablaBE _objTablaBE { get; set; }
        public List<ColumnaBE> _lstColumnaBE { get; set; }
        public int _DataSource { get; set; }

        public void GenerarHeader(String nsBE)
        {
            StreamWriter be = File.AppendText(_Ruta);

            be.WriteLine("using System;");
            be.WriteLine("using System.Collections.Generic;");
            be.WriteLine("using System.Linq;");
            be.WriteLine("using System.Text;");

            be.WriteLine("");
            be.WriteLine("namespace " + nsBE);
            be.WriteLine("{");

            be.Close();
        }

        public void GenerarFooter()
        {
            StreamWriter be = File.AppendText(_Ruta);

            be.WriteLine("}");

            be.Close();
        }

        public void GenerarClase()
        {
            StreamWriter be = File.AppendText(_Ruta);

            be.WriteLine("    public class " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE");
            be.WriteLine("    {");
            foreach (ColumnaBE c in _lstColumnaBE)
            {
                switch (_DataSource)
                {
                    case (int)DataSource.SQLServer:
                        be.WriteLine("        public " + ToolBC.TypeFromSQL(c.Tipo_Dato) + (c.Acepta_Nulos && !ToolBC.ClaseNull(ToolBC.TypeFromSQL(c.Tipo_Dato)) ? "?" : "") + " " + ToolBC.StandarizarNombreClase(c.Nombre) + " { get; set; }");
                        break;
                    case (int)DataSource.MySQL:
                        be.WriteLine("        public " + ToolBC.TypeFromMySQL(c.Tipo_Dato) + (c.Acepta_Nulos && !ToolBC.ClaseNull(ToolBC.TypeFromMySQL(c.Tipo_Dato)) ? "?" : "") + " " + ToolBC.StandarizarNombreClase(c.Nombre) + " { get; set; }");
                        break;
                }
            }
            be.WriteLine("    }");

            be.Close();
        }

        public void GenerarConstructorBase()
        {
            StreamWriter be = File.AppendText(_Ruta);

            be.WriteLine("    public " + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "BE()");
            be.WriteLine("    { }");

            be.Close();
        }
    }
}
