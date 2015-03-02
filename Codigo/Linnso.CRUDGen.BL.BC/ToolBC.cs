using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linnso.CRUDGen.BL.BE;
using System.IO;

namespace Linnso.CRUDGen.BL.BC
{
    public class ToolBC
    {
        public static String TypeFromSQL(String SqlType)
        {
            switch (SqlType.ToLower())
            {
                case "bigint":
                    return "long";

                case "binary":
                case "image":
                case "timestamp":
                case "varbinary":
                    return "byte[]";

                case "bit":
                    return "bool";

                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "string";

                case "datetime":
                case "smalldatetime":
                case "date":
                case "time":
                case "datetime2":
                    return "DateTime";

                case "decimal":
                case "money":
                case "smallmoney":
                case "numeric":
                    return "Decimal";

                case "float":
                    return "double";

                case "int":
                    return "int";

                case "real":
                    return "float";

                case "uniqueidentifier":
                    return "Guid";

                case "smallint":
                    return "short";

                case "tinyint":
                    return "byte";

                case "variant":
                case "udt":
                    return "object";

                case "structured":
                    return "DataTable";

                case "datetimeoffset":
                    return "DateTimeOffset";

                default:
                    return SqlType;
            }
        }

        public static String StandarizarNombreClase(String nombre)
        {
            nombre = nombre.Replace(" ", "_");
            String[] separado = nombre.Split('_');
            String nombre_estandarizado = "";

            foreach (String s in separado)
            {
                nombre_estandarizado += char.ToUpper(s[0]) + s.Substring(1) + "_";
            }
            nombre_estandarizado = nombre_estandarizado.TrimEnd('_');

            return nombre_estandarizado;
        }

        public static String StandarizarNombreParametro(String nombre)
        {
            nombre = nombre.ToLower().Replace(" ", "_");
            return nombre;
        }

        public static String KeyParametersSQL(List<ColumnaBE> lstColumnaBE)
        {
            String parametros = "";

            foreach (ColumnaBE c in lstColumnaBE)
            {
                if(c.Es_PK)
                    parametros += TypeFromSQL(c.Tipo_Dato) + " " + StandarizarNombreParametro(c.Nombre) + ", ";
            }

            if(!String.IsNullOrEmpty(parametros))
                parametros = parametros.Substring(0, parametros.Length - 2);
            
            return parametros;
        }

        public static String KeyVariables(List<ColumnaBE> lstColumnaBE)
        {
            String parametros = "";

            foreach (ColumnaBE c in lstColumnaBE)
            {
                if (c.Es_PK)
                    parametros += StandarizarNombreParametro(c.Nombre) + ", ";
            }

            if (!String.IsNullOrEmpty(parametros))
                parametros = parametros.Substring(0, parametros.Length - 2);

            return parametros;
        }

        public static String ConvertFromSQLNULL(String SqlType, String variable)
        {
            switch (SqlType.ToLower())
            {
                case "bigint":
                    return "dr[\"" + variable + "\"] as long?";

                case "binary":
                case "image":
                case "timestamp":
                case "varbinary":
                    return "(byte[])dr[\"" + variable + "\"]";

                case "bit":
                    return "dr[\"" + variable + "\"] as bool?";

                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "dr[\"" + variable + "\"] as string";

                case "datetime":
                case "smalldatetime":
                case "date":
                case "time":
                case "datetime2":
                    return "dr[\"" + variable + "\"] as DateTime?";

                case "decimal":
                case "money":
                case "smallmoney":
                case "numeric":
                    return "dr[\"" + variable + "\"] as decimal?";

                case "float":
                    return "dr[\"" + variable + "\"] as double?";

                case "int":
                    return "dr[\"" + variable + "\"] as int?";

                case "real":
                    return "dr.GetFloat(dr.GetOrdinal(\"" + variable + "\"))";

                case "uniqueidentifier":
                    return "dr.GetGuid(dr.GetOrdinal(\"" + variable + "\"))";

                case "smallint":
                    return "dr[\"" + variable + "\"] as short?";

                case "tinyint":
                    return "dr[\"" + variable + "\"] as byte?";

                case "variant":
                case "udt":
                    return "(object)dr[\"" + variable + "\"]";

                case "structured":
                    return "DataTable";

                case "datetimeoffset":
                    return "DateTimeOffset.Parse(dr[\"" + variable + "\"])";

                default:
                    return "(dr[\"" + SqlType + ")" + variable + "\"])";
            }
        }

        public static String ConvertFromSQL(String SqlType, String variable)
        {
            switch (SqlType.ToLower())
            {
                case "bigint":
                    return "Convert.ToInt64(dr[\"" + variable + "\"])";

                case "binary":
                case "image":
                case "timestamp":
                case "varbinary":
                    return "(byte[])dr[\"" + variable + "\"]";

                case "bit":
                    return "Convert.ToBoolean(dr[\"" + variable + "\"])";

                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "dr[\"" + variable + "\"].ToString()";

                case "datetime":
                case "smalldatetime":
                case "date":
                case "time":
                case "datetime2":
                    return "Convert.ToDateTime(dr[\"" + variable + "\"])";

                case "decimal":
                case "money":
                case "smallmoney":
                case "numeric":
                    return "Convert.ToDecimal(dr[\"" + variable + "\"])";

                case "float":
                    return "Convert.ToDouble(dr[\"" + variable + "\"])";

                case "int":
                    return "Convert.ToInt32(dr[\"" + variable + "\"])";

                case "real":
                    return "dr.GetFloat(dr.GetOrdinal(\"" + variable + "\"))";

                case "uniqueidentifier":
                    return "dr.GetGuid(dr.GetOrdinal(\"" + variable + "\"))";

                case "smallint":
                    return "Convert.ToInt16(dr[\"" + variable + "\"])";

                case "tinyint":
                    return "Convert.ToByte(dr[\"" + variable + "\"])";

                case "variant":
                case "udt":
                    return "(object)dr[\"" + variable + "\"]";

                case "structured":
                    return "DataTable";

                case "datetimeoffset":
                    return "DateTimeOffset.Parse(dr[\"" + variable + "\"])"; 

                default:
                    return "(dr[\"" + SqlType + ")" + variable + "\"])";
            }
        }

        public static String SQLParameter(ColumnaBE objColumnaBE)
        {
            switch (objColumnaBE.Tipo_Dato.ToLower())
            {
                //case "bigint":
                //case "bit":
                //case "date":
                //case "datetime":
                //case "float":
                //case "geography":
                //case "geometry":
                //case "hierarchyid":
                //case "image":
                //case "int":
                //case "money":
                //case "ntext":
                //case "real":
                //case "smalldatetime":
                //case "smallint":
                //case "smallmoney":
                //case "sql_variant":
                //case "text":
                //case "money":
                //    break;
                case "binary":
                case "char":
                case "datetime2":
                case "datetimeoffset":
                case "nchar":
                case "nvarchar":
                case "time":
                case "varbinary":
                case "varchar":
                    return objColumnaBE.Tipo_Dato + "(" + (objColumnaBE.Tamano_Maximo == -1 ? "MAX" : objColumnaBE.Tamano_Maximo.ToString()) + ")";
                case "decimal":
                case "numeric":
                    return objColumnaBE.Tipo_Dato + "(" + objColumnaBE.Precision_Numerica + ", " + objColumnaBE.Precision_Numerica_Base + ")";
                default:
                    return objColumnaBE.Tipo_Dato;

            }
        }

        public static Boolean ClaseNull(String clase)
        {
            Boolean acepta_null = false;

            if (clase.ToLower().Equals("string")
                || clase.Contains("[]"))
                acepta_null = true;

            return acepta_null;
        }
    }
}
