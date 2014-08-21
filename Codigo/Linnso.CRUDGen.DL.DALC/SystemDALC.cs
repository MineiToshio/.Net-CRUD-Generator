﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Linnso.CRUDGen.DL.DALC.Tools;
using Linnso.CRUDGen.BL.BE;

namespace Linnso.CRUDGen.DL.DALC
{
    public class SystemDALC
    {
        public List<String> Select_SQL_Databases(ConexionBE objConexionBE)
        {
            SqlCommand command = new SqlCommand();
            List<String> lstTables = new List<String>();
            SqlDataReader dr = null;

            try
            {
                SqlConnection SqlCon = new SqlConnection(ConnectionString.GetSQLServer(objConexionBE));
                SqlCon.Open();

                command.Connection = SqlCon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_databases";

                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    lstTables.Add(dr.GetString(0));
                }

                return lstTables;
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                command.Dispose();
                dr.Close();
                dr.Dispose();
            }
        }

        public List<TablaBE> Select_SQL_Table(ConexionBE objConexionBE)
        {
            SqlCommand command = new SqlCommand();
            List<TablaBE> lstTablaBE = new List<TablaBE>();
            TablaBE objTablaBE = new TablaBE();
            SqlDataReader dr = null;

            try
            {
                SqlConnection SqlCon = new SqlConnection(ConnectionString.GetSQLServer(objConexionBE));
                SqlCon.Open();

                command.Connection = SqlCon;
                command.CommandType = CommandType.Text;
                command.CommandText = "Select distinct TABLE_NAME, TABLE_SCHEMA From INFORMATION_SCHEMA.Tables where TABLE_TYPE = 'BASE TABLE'";

                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    objTablaBE = new TablaBE();
                    objTablaBE.Nombre = dr["TABLE_NAME"].ToString();
                    objTablaBE.Esquema = dr["TABLE_SCHEMA"].ToString();
                    objTablaBE.Nombre_Sin_Espacios = dr["TABLE_NAME"].ToString().Replace(" ", "_");
                    lstTablaBE.Add(objTablaBE);
                }

                return lstTablaBE;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                command.Dispose();
                dr.Close();
                dr.Dispose();
            }
        }

        public List<ColumnaBE> Select_SQL_Columna(ConexionBE objConexionBE, TablaBE objTablaBE)
        {
            List<ColumnaBE> lstColumnaBE = new List<ColumnaBE>();
            SqlCommand command = new SqlCommand();
            ColumnaBE objColumnaBE = new ColumnaBE();
            SqlDataReader dr = null;

            try
            {
                SqlConnection SqlCon = new SqlConnection(ConnectionString.GetSQLServer(objConexionBE));
                SqlCon.Open();

                command.Connection = SqlCon;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT distinct c.COLUMN_NAME, " +
                                        "c.IS_NULLABLE, " + 
                                        "c.DATA_TYPE, " + 
                                        "case when k.COLUMN_NAME is null then 'NO' else 'YES' end 'IS_PK', " + 
                                        "case when columnproperty(object_id(c.table_name), c.column_name,'IsIdentity') = 1 then 'YES' else 'NO' end 'IS_IDENTITY', " +
                                        "c.CHARACTER_MAXIMUM_LENGTH, " +
                                        "c.NUMERIC_PRECISION, " +
                                        "c.NUMERIC_PRECISION_RADIX " + 
                                        "FROM INFORMATION_SCHEMA.COLUMNS c left join INFORMATION_SCHEMA.KEY_COLUMN_USAGE k on c.COLUMN_NAME = k.COLUMN_NAME " + 
                                        "where c.TABLE_NAME = '" + objTablaBE.Nombre + "' and c.TABLE_SCHEMA = '" + objTablaBE.Esquema + "'";

                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    objColumnaBE = new ColumnaBE();
                    objColumnaBE.Nombre = dr["COLUMN_NAME"].ToString();
                    objColumnaBE.Acepta_Nulos = dr["IS_NULLABLE"].ToString().Equals("NO") ? false : true;
                    objColumnaBE.Tipo_Dato = dr["DATA_TYPE"].ToString();
                    objColumnaBE.Es_PK = dr["IS_PK"].ToString().Equals("NO") ? false : true;
                    objColumnaBE.Es_Identity = dr["IS_IDENTITY"].ToString().Equals("NO") ? false : true;
                    objColumnaBE.Tamano_Maximo = dr["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value ? Convert.ToInt32(dr["CHARACTER_MAXIMUM_LENGTH"]) : -1;
                    objColumnaBE.Precision_Numerica = dr["NUMERIC_PRECISION"] != DBNull.Value ? Convert.ToInt32(dr["NUMERIC_PRECISION"]) : -1;
                    objColumnaBE.Precision_Numerica_Base = dr["NUMERIC_PRECISION_RADIX"] != DBNull.Value ? Convert.ToInt32(dr["NUMERIC_PRECISION_RADIX"]) : -1;
                    lstColumnaBE.Add(objColumnaBE);
                }

                return lstColumnaBE;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
                dr.Close();
                dr.Dispose();
            }

            
        }
    }
}