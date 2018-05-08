using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linnso.CRUDGen.BL.BE;

namespace Linnso.CRUDGen.DL.DALC.Tools
{
    public class ConnectionString
    {
        public static String GetSQLServer(ConexionBE objConexionBE)
        {
            //return "Server=SergioTA;Database=taproyecto;Uid=root;Pwd=root;"
            String cadena = "server=" + objConexionBE.Server + ";" +
                (!String.IsNullOrEmpty(objConexionBE.DataBase) ? "Database=" + objConexionBE.DataBase + ";" : "") +
                (!String.IsNullOrEmpty(objConexionBE.User) ? "uid=" + objConexionBE.User + ";pwd=" + objConexionBE.Password + ";" : "Integrated Security=true;");

            return @cadena;
        }

        public static String GetMySQLServer(ConexionBE objConexionBE)
        {
            //return "Server=dellcai;Database=taproyectos;Uid=root;Pwd=root;"
            String cadena = "server=" + objConexionBE.Server + ";" +
                (!String.IsNullOrEmpty(objConexionBE.DataBase) ? "Database=" + objConexionBE.DataBase + ";" : "") +
                (!String.IsNullOrEmpty(objConexionBE.User) ? "uid=" + objConexionBE.User + ";pwd=" + objConexionBE.Password + ";" : "");

            return @cadena;
        }
    }
}
