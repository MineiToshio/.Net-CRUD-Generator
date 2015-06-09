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
        #region SQL Server
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
                    return "dr[\"" + variable + "\"] as float?";

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
                    return "dr[\"" + variable + "\"] as DateTimeOffset?";

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
        #endregion

        #region MySQL
        public static String TypeFromMySQL(String MySqlType)
        {
            switch (MySqlType.ToLower())
            {
                case "bool":
                case "boolean":
                case "bit":
                    return "bool";

                case "tinyint":
                    return "sbyte";

                case "smallint":
                case "year":
                    return "short";

                case "int": 
                case "integer": 
                case "mediumint":
                    return "int";

                case "bigint":
                    return "long";

                case "float":
                    return "Single";

                case "double": 
                case "real":
                    return "double";

                case "decimal": 
                case "numeric": 
                case "dec": 
                case "fixed": 
                case "serial":
                    return "decimal";

                case "date": 
                case "timestamp": 
                case "datetime":
                    return "DateTime";

                case "time":
                    return "TimeSpan";

                case "char": 
                case "varchar": 
                case "tinytext": 
                case "text": 
                case "mediumtext": 
                case "longtext": 
                case "set":
                case "enum": 
                case "nchar": 
                case "nvarchar":
                    return "string";

                case "binary": 
                case "varbinary": 
                case "tinyblob": 
                case "blob": 
                case "mediumblob": 
                case "longblob":
                    return "byte[]";

                default:
                    return MySqlType;
            }
        }

        public static String KeyParametersMySQL(List<ColumnaBE> lstColumnaBE)
        {
            String parametros = "";

            foreach (ColumnaBE c in lstColumnaBE)
            {
                if (c.Es_PK)
                    parametros += TypeFromMySQL(c.Tipo_Dato) + " " + StandarizarNombreParametro(c.Nombre) + ", ";
            }

            if (!String.IsNullOrEmpty(parametros))
                parametros = parametros.Substring(0, parametros.Length - 2);

            return parametros;
        }

        public static String ConvertFromMySQLNULL(String MySqlType, String variable)
        {
            switch (MySqlType.ToLower())
            {
                case "bool":
                case "boolean":
                case "bit":
                    return "dr[\"" + variable + "\"] as bool?";

                case "tinyint":
                    return "dr[\"" + variable + "\"] as sbyte?";

                case "smallint":
                case "year":
                    return "dr[\"" + variable + "\"] as short?";

                case "int":
                case "integer":
                case "mediumint":
                    return "dr[\"" + variable + "\"] as int?";

                case "bigint":
                    return "dr[\"" + variable + "\"] as long?";

                case "float":
                    return "dr[\"" + variable + "\"] as float?";

                case "double":
                case "real":
                    return "dr[\"" + variable + "\"] as double?";

                case "decimal":
                case "numeric":
                case "dec":
                case "fixed":
                case "serial":
                    return "dr[\"" + variable + "\"] as decimal?";

                case "date":
                case "timestamp":
                case "datetime":
                    return "dr[\"" + variable + "\"] as DateTime?";

                case "time":
                    return "dr[\"" + variable + "\"] as TimeSpan?";

                case "char":
                case "varchar":
                case "tinytext":
                case "text":
                case "mediumtext":
                case "longtext":
                case "set":
                case "enum":
                case "nchar":
                case "nvarchar":
                    return "dr[\"" + variable + "\"] as string";

                case "binary":
                case "varbinary":
                case "tinyblob":
                case "blob":
                case "mediumblob":
                case "longblob":
                    return "(byte[])dr[\"" + variable + "\"]";

                default:
                    return "(dr[\"" + MySqlType + ")" + variable + "\"])";
            }
        }

        public static String ConvertFromMySQL(String MySqlType, String variable)
        {
            switch (MySqlType.ToLower())
            {
                case "bool":
                case "boolean":
                case "bit":
                    return "Convert.ToBoolean(dr[\"" + variable + "\"])";

                case "tinyint":
                    return "Convert.ToSByte(dr[\"" + variable + "\"])";

                case "smallint":
                case "year":
                    return "Convert.ToInt16(dr[\"" + variable + "\"])";

                case "int":
                case "integer":
                case "mediumint":
                    return "Convert.ToInt32(dr[\"" + variable + "\"])";

                case "bigint":
                    return "Convert.ToInt64(dr[\"" + variable + "\"])";

                case "float":
                    return "Convert.ToSingle(dr[\"" + variable + "\"])";

                case "double":
                case "real":
                    return "Convert.ToDouble(dr[\"" + variable + "\"])";

                case "decimal":
                case "numeric":
                case "dec":
                case "fixed":
                case "serial":
                    return "Convert.ToDecimal(dr[\"" + variable + "\"])";

                case "date":
                case "timestamp":
                case "datetime":
                    return "Convert.ToDateTime(dr[\"" + variable + "\"])";

                case "time":
                    return "TimeSpan.Parse(dr[\"" + variable + "\"])";

                case "char":
                case "varchar":
                case "tinytext":
                case "text":
                case "mediumtext":
                case "longtext":
                case "set":
                case "enum":
                case "nchar":
                case "nvarchar":
                    return "dr[\"" + variable + "\"].ToString()";

                case "binary":
                case "varbinary":
                case "tinyblob":
                case "blob":
                case "mediumblob":
                case "longblob":
                    return "(byte[])dr[\"" + variable + "\"]";

                default:
                    return "(dr[\"" + MySqlType + ")" + variable + "\"])";
            }
        }

        public static String MySQLParameter(ColumnaBE objColumnaBE)
        {
            switch (objColumnaBE.Tipo_Dato.ToLower())
            {
                case "char":
                case "time":
                case "varbinary":
                case "varchar":
                    return objColumnaBE.Tipo_Dato + "(" + (objColumnaBE.Tamano_Maximo == -1 ? "MAX" : objColumnaBE.Tamano_Maximo.ToString()) + ")";
                case "decimal":
                    return objColumnaBE.Tipo_Dato + "(" + objColumnaBE.Precision_Numerica + ", " + objColumnaBE.Precision_Numerica_Base + ")";
                default:
                    return objColumnaBE.Tipo_Dato;
            }
        }
        #endregion

        #region General
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

        public static Boolean ClaseNull(String clase)
        {
            Boolean acepta_null = false;

            if (clase.ToLower().Equals("string")
                || clase.Contains("[]"))
                acepta_null = true;

            return acepta_null;
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

        public static String KeyParameters(List<ColumnaBE> lstColumnaBE, int datasource)
        {
            String parametros = "";

            switch (datasource)
            { 
                case (int)DataSource.SQLServer:
                    parametros = KeyParametersSQL(lstColumnaBE);
                    break;
                case (int)DataSource.MySQL:
                    parametros = KeyParametersMySQL(lstColumnaBE);
                    break;
            }

            return parametros;
        }

        #endregion
    }
}
