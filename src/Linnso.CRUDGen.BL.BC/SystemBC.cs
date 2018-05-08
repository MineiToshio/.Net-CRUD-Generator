using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linnso.CRUDGen.DL.DALC;
using Linnso.CRUDGen.BL.BE;

namespace Linnso.CRUDGen.BL.BC
{
    public class SystemBC
    {
        SystemDALC objSystemDALC = new SystemDALC();

        #region SQL
        public List<String> Select_SQL_Databases(ConexionBE objConexionBE)
        {
            try
            {
                return objSystemDALC.Select_SQL_Databases(objConexionBE);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<TablaBE> Select_SQL_Table(ConexionBE objConexionBE)
        {
            try
            {
                return objSystemDALC.Select_SQL_Table(objConexionBE);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ColumnaBE> Select_SQL_Columna(ConexionBE objConexionBE, TablaBE objTablaBE)
        {
            try
            {
                return objSystemDALC.Select_SQL_Columna(objConexionBE, objTablaBE);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region MySQL
        public List<String> Select_MySQL_Databases(ConexionBE objConexionBE)
        {
            try
            {
                return objSystemDALC.Select_MySQL_Databases(objConexionBE);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TablaBE> Select_MySQL_Table(ConexionBE objConexionBE)
        {
            try
            {
                return objSystemDALC.Select_MySQL_Table(objConexionBE);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ColumnaBE> Select_MySQL_Columna(ConexionBE objConexionBE, TablaBE objTablaBE)
        {
            try
            {
                return objSystemDALC.Select_MySQL_Columna(objConexionBE, objTablaBE);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
