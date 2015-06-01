using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linnso.CRUDGen.BL.BE;
using System.IO;

namespace Linnso.CRUDGen.BL.BC
{
    public class SPGenBC
    {
        public String _Ruta { get; set; }
        public int _DataSource { get; set; }
        public TablaBE _objTablaBE { get; set; }
        public List<ColumnaBE> _lstColumnaBE { get; set; }
        public String _DataBase { get; set; }
        public string _CampoUsuarioCreacion { get; set; }
        public string _CampoUsuarioModificacion { get; set; }
        public string _CampoFechaCreacion { get; set; }
        public string _CampoFechaModificacion { get; set; }
        public string _CampoHabilitado { get; set; }

        #region SQL Server
        public void SQLGenerarHeader()
        {
            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                sp.WriteLine("USE [" + _DataBase + "]");
                sp.WriteLine("");
            }
        }

        public void SQLGenerarHeaderSP(StreamWriter sp, Modo modo)
        {
            sp.WriteLine("GO");
            sp.WriteLine("SET ANSI_NULLS ON");
            sp.WriteLine("GO");
            sp.WriteLine("SET QUOTED_IDENTIFIER ON");
            sp.WriteLine("GO");
            sp.WriteLine("");
            sp.WriteLine("-- =============================================");
            sp.WriteLine("-- Author:	 Store procedure autogenerado Por CRUDGen");
            sp.WriteLine("-- Create date: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "");

            switch(modo)
            {
                case Modo.Actualizar:
                    sp.WriteLine("-- Description: Actualiza un " + _objTablaBE.Nombre);
                    break;
                case Modo.Eliminar:
                    sp.WriteLine("-- Description: Elimina un " + _objTablaBE.Nombre);
                    break;
                case Modo.Insertar:
                    sp.WriteLine("-- Description: Inserta un " + _objTablaBE.Nombre);
                    break;
                case Modo.Insertar_Actualizar:
                    sp.WriteLine("-- Description: Inserta y/o actualizar un " + _objTablaBE.Nombre);
                    break;
                case Modo.Seleccioar_X_ID:
                    sp.WriteLine("-- Description: Obtiene un " + _objTablaBE.Nombre + " por su ID");
                    break;
                case Modo.Seleccionar:
                    sp.WriteLine("-- Description: Selecciona todos los elementos de la tabla " + _objTablaBE.Nombre);
                    break;
            }
            
            sp.WriteLine("-- =============================================");
        }

        public void SQLGenerarInsert()
        {
            int n_identity = (from c in _lstColumnaBE where c.Es_Identity select c).Count();
            int n_no_identity = (from c in _lstColumnaBE where !c.Es_Identity select c).Count();
            int n_iteraciones = 0;

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                SQLGenerarHeaderSP(sp, Modo.Insertar);
                
                sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Insert] (");

                var creador = from c in _lstColumnaBE where c.Nombre == _CampoUsuarioCreacion select c;

                foreach(ColumnaBE c in _lstColumnaBE)
                {
                    if (!c.Es_Identity && c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoFechaModificacion && c.Nombre != _CampoHabilitado)
                    {
                        if (c.Nombre != _CampoUsuarioModificacion)
                            sp.WriteLine("    @" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.SQLParameter(c) + (c.Acepta_Nulos ? " = null" : "") + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        else
                        {
                            if(creador.Count() == 0) //existe campo creador
                                sp.WriteLine("    @" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.SQLParameter(c) + (c.Acepta_Nulos ? " = null" : "") + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        }
                        n_iteraciones++;
                    }
                }
                sp.WriteLine(")");
                sp.WriteLine("AS");
                sp.WriteLine("BEGIN");
                sp.WriteLine("");
                sp.WriteLine("    SET NOCOUNT ON;");
                sp.WriteLine("");
                sp.WriteLine("    insert into [" + _objTablaBE.Esquema  + "].[" + _objTablaBE.Nombre + "]");
                sp.WriteLine("    (");
                n_iteraciones = 0;
                
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (!c.Es_Identity)
                    {
                        sp.WriteLine("        [" + c.Nombre + "]" + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine("    )");
                sp.WriteLine("    values");
                sp.WriteLine("    (");
                n_iteraciones = 0;
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (!c.Es_Identity)
                    {
                        if (c.Nombre == _CampoFechaCreacion || c.Nombre == _CampoFechaModificacion)
                            sp.WriteLine("        GETUTCDATE()" + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        else if (c.Nombre == _CampoHabilitado)
                            sp.WriteLine("        1" + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        else if (c.Nombre == _CampoUsuarioModificacion)
                        {
                            if(creador.Count() > 0) //Existe usuario creación
                                sp.WriteLine("        @" + ToolBC.StandarizarNombreParametro(_CampoUsuarioCreacion) + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                            else
                                sp.WriteLine("        @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        }
                        else
                            sp.WriteLine("        @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine("    )");
                if (n_identity == 1)
                {
                    sp.WriteLine("");
                    sp.WriteLine("    select @@IDENTITY as '" + ToolBC.StandarizarNombreParametro((from c in _lstColumnaBE where c.Es_Identity select c.Nombre).ToList()[0]) + "'");
                }
                sp.WriteLine("END");
                sp.WriteLine("GO");
                sp.WriteLine("");
            }
        }

        public void SQLGenerarUpdate()
        {
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            if (n_no_pk != 0  && n_pk != 0)
            {
                int n_iteraciones = 0;

                using (StreamWriter sp = File.AppendText(_Ruta))
                {
                    SQLGenerarHeaderSP(sp, Modo.Actualizar);
                    sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Update] (");
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoFechaModificacion && c.Nombre != _CampoUsuarioCreacion && c.Nombre != _CampoHabilitado)
                        {
                            sp.WriteLine("    @" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.SQLParameter(c) + (c.Acepta_Nulos ? " = null" : "") + (n_iteraciones != _lstColumnaBE.Count - 1 ? "," : ""));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine(")");
                    sp.WriteLine("AS");
                    sp.WriteLine("BEGIN");
                    sp.WriteLine("");
                    sp.WriteLine("    SET NOCOUNT ON;");
                    sp.WriteLine("");
                    sp.WriteLine("    update [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre + "]");
                    sp.WriteLine("    set");
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (!c.Es_PK && c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoUsuarioCreacion && c.Nombre != _CampoHabilitado)
                        {
                            if(c.Nombre == _CampoFechaModificacion)
                                sp.WriteLine("        [" + c.Nombre + "] = GETUTCDATE()" + (n_iteraciones != n_no_pk - 1 ? "," : ""));
                            else
                                sp.WriteLine("        [" + c.Nombre + "] = @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_no_pk - 1 ? "," : ""));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine("    where");
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (c.Es_PK)
                        {
                            sp.WriteLine("        [" + c.Nombre + "] = @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_pk - 1 ? " and " : ""));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine("END");
                    sp.WriteLine("GO");
                    sp.WriteLine("");
                }
            }
        }

        public void SQLGenerarInsertUpdate()
        {
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            if (n_no_pk != 0 && n_pk != 0)
            {
                int n_iteraciones = 0;
                int n_identity = (from c in _lstColumnaBE where c.Es_Identity select c).Count();
                int n_no_identity = (from c in _lstColumnaBE where !c.Es_Identity select c).Count();

                using (StreamWriter sp = File.AppendText(_Ruta))
                {
                    SQLGenerarHeaderSP(sp, Modo.Insertar_Actualizar);
                    sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre_Sin_Espacios + "_Insert_Update] (");
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        sp.WriteLine("    @" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.SQLParameter(c) + (c.Acepta_Nulos ? " = null" : "") + (n_iteraciones != _lstColumnaBE.Count - 1 ? "," : ""));
                        n_iteraciones++;
                    }
                    sp.WriteLine(")");
                    sp.WriteLine("AS");
                    sp.WriteLine("BEGIN");
                    sp.WriteLine("");
                    sp.WriteLine("    SET NOCOUNT ON;");
                    //sp.WriteLine("");
                    //sp.WriteLine("    declare @count int");

                    //String count_pk = "";
                    //foreach (ColumnaBE c in _lstColumnaBE)
                    //{
                    //    if (c.Es_PK)
                    //    {
                    //        count_pk += "[" + c.Nombre + "] = @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_pk - 1 ? "," : "");
                    //        n_iteraciones++;
                    //    }
                    //}

                    //sp.WriteLine("    set @count = (select count(*) from [" + _objTablaBE.Nombre + "] " + "where " + count_pk + ")");
                    //sp.WriteLine("");
                    String if_pk = "";
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (c.Es_PK)
                        {
                            if_pk += "@" + ToolBC.StandarizarNombreParametro(c.Nombre) + " = 0" + (n_iteraciones != n_pk - 1 ? " or " : "");
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine("");
                    sp.WriteLine("    if(" + if_pk + ")");
                    sp.WriteLine("    begin");
                    sp.WriteLine("        insert into [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre + "]");
                    sp.WriteLine("        (");
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (!c.Es_Identity)
                        {
                            sp.WriteLine("            [" + c.Nombre + "]" + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine("        )");
                    sp.WriteLine("        values");
                    sp.WriteLine("        (");
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (!c.Es_Identity)
                        {
                            sp.WriteLine("            @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine("        )");
                    if (n_identity == 1)
                    {
                        sp.WriteLine("");
                        sp.WriteLine("        select @@IDENTITY as '" + ToolBC.StandarizarNombreParametro((from c in _lstColumnaBE where c.Es_Identity select c.Nombre).ToList()[0]) + "'");
                    }
                    sp.WriteLine("    end");
                    sp.WriteLine("    else");
                    sp.WriteLine("    begin");
                    sp.WriteLine("        update [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre + "]");
                    sp.WriteLine("        set");
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (!c.Es_PK)
                        {
                            sp.WriteLine("            [" + c.Nombre + "] = @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_no_pk - 1 ? "," : ""));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine("        where");
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (c.Es_PK)
                        {
                            sp.WriteLine("            [" + c.Nombre + "] = @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_pk - 1 ? " and " : ""));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine("");
                    if (n_identity == 1)
                    {
                        String nombre_parametro = ToolBC.StandarizarNombreParametro((from c in _lstColumnaBE where c.Es_Identity select c.Nombre).ToList()[0]);
                        sp.WriteLine("        select @" + nombre_parametro + " as '" + nombre_parametro + "'");
                    }
                    sp.WriteLine("    end");
                    sp.WriteLine("END");
                    sp.WriteLine("GO");
                    sp.WriteLine("");
                }
            }
        }

        public void SQLGenerarDelete()
        {
            int n_iteraciones = 0;
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                SQLGenerarHeaderSP(sp, Modo.Eliminar);
                sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Delete] (");
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (c.Es_PK)
                    {
                        sp.WriteLine("    @" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.SQLParameter(c) + (n_iteraciones != n_pk - 1 ? "," : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine(")");
                sp.WriteLine("AS");
                sp.WriteLine("BEGIN");
                sp.WriteLine("");
                sp.WriteLine("    SET NOCOUNT ON;");
                sp.WriteLine("");
                sp.WriteLine("    delete from [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre + "]");
                sp.WriteLine("    where");
                n_iteraciones = 0;
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (c.Es_PK)
                    {
                        sp.WriteLine("        [" + c.Nombre + "] = @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_pk - 1 ? " and " : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine("END");
                sp.WriteLine("GO");
                sp.WriteLine("");
            }
        }

        public void SQLGenerarSelect()
        {
            String inicial_tabla = _objTablaBE.Nombre.First().ToString().ToLower();
            bool primero = true;

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                SQLGenerarHeaderSP(sp, Modo.Seleccionar);
                sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Select]");
                sp.WriteLine("AS");
                sp.WriteLine("BEGIN");
                sp.WriteLine("");
                sp.WriteLine("    SET NOCOUNT ON;");
                sp.WriteLine("");
                sp.WriteLine("    select ");
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    sp.WriteLine("        " + (primero ? "" : ",") + inicial_tabla + ".[" + c.Nombre + "]");
                    primero = false;
                }
                sp.WriteLine("    from [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre + "] " + inicial_tabla);
                sp.WriteLine("END");
                sp.WriteLine("GO");
                sp.WriteLine("");
            }
        }

        public void SQLGenerarGet()
        {
            String inicial_tabla = _objTablaBE.Nombre.First().ToString().ToLower();
            bool primero = true;
            int n_iteraciones = 0;
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                SQLGenerarHeaderSP(sp, Modo.Seleccioar_X_ID);
                sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Get](");
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (c.Es_PK)
                    {
                        sp.WriteLine("    @" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.SQLParameter(c) + (n_iteraciones != n_pk - 1 ? "," : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine(")");
                sp.WriteLine("AS");
                sp.WriteLine("BEGIN");
                sp.WriteLine("");
                sp.WriteLine("    SET NOCOUNT ON;");
                sp.WriteLine("");
                sp.WriteLine("    select ");
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    sp.WriteLine("        " + (primero ? "" : ",") + inicial_tabla + ".[" + c.Nombre + "]");
                    primero = false;
                }
                sp.WriteLine("    from [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre + "] " + inicial_tabla);
                sp.WriteLine("    where");
                n_iteraciones = 0;
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (c.Es_PK)
                    {
                        sp.WriteLine("        " + inicial_tabla + ".[" + c.Nombre + "] = @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_pk - 1 ? " and " : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine("END");
                sp.WriteLine("GO");
                sp.WriteLine("");
            }
        }
        #endregion

        #region
        public void MySQLGenerarHeader()
        {
            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                sp.WriteLine("USE `" + _DataBase + "`;");
                sp.WriteLine("");
            }
        }

        public void MySQLGenerarHeaderSP(StreamWriter sp)
        {
            sp.WriteLine("DELIMITER $$");
        }

        public void MySQLGenerarInsert()
        {
            int n_identity = (from c in _lstColumnaBE where c.Es_Identity select c).Count();
            int n_no_identity = (from c in _lstColumnaBE where !c.Es_Identity select c).Count();
            int n_iteraciones = 0;

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                MySQLGenerarHeaderSP(sp);

                sp.WriteLine("CREATE PROCEDURE `" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Insert` (");

                var creador = from c in _lstColumnaBE where c.Nombre == _CampoUsuarioCreacion select c;

                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (!c.Es_Identity && c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoFechaModificacion && c.Nombre != _CampoHabilitado)
                    {
                        if (c.Nombre != _CampoUsuarioModificacion)
                            sp.WriteLine("    in v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.SQLParameter(c) + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        else
                        {
                            if (creador.Count() == 0) //existe campo creador
                                sp.WriteLine("    in v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.SQLParameter(c) + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        }
                        n_iteraciones++;
                    }
                }
                sp.WriteLine(")");
                sp.WriteLine("BEGIN");
                sp.WriteLine("    insert `" + _objTablaBE.Nombre + "`");
                sp.WriteLine("    (");
                n_iteraciones = 0;

                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (!c.Es_Identity)
                    {
                        sp.WriteLine("        `" + c.Nombre + "`" + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine("    )");
                sp.WriteLine("    values");
                sp.WriteLine("    (");
                n_iteraciones = 0;
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (!c.Es_Identity)
                    {
                        if (c.Nombre == _CampoFechaCreacion || c.Nombre == _CampoFechaModificacion)
                            sp.WriteLine("        UTC_TIMESTAMP()" + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        else if (c.Nombre == _CampoHabilitado)
                            sp.WriteLine("        1" + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        else if (c.Nombre == _CampoUsuarioModificacion)
                        {
                            if (creador.Count() > 0) //Existe usuario creación
                                sp.WriteLine("        v_" + ToolBC.StandarizarNombreParametro(_CampoUsuarioCreacion) + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                            else
                                sp.WriteLine("        v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        }
                        else
                            sp.WriteLine("        v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_no_identity - 1 ? "," : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine("    );");
                if (n_identity == 1)
                {
                    sp.WriteLine("");
                    sp.WriteLine("    select @@IDENTITY as '" + ToolBC.StandarizarNombreParametro((from c in _lstColumnaBE where c.Es_Identity select c.Nombre).ToList()[0]) + "';");
                }
                sp.WriteLine("END $$");
                sp.WriteLine("");
            }
        }

        public void MySQLGenerarUpdate()
        {
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            if (n_no_pk != 0 && n_pk != 0)
            {
                int n_iteraciones = 0;

                using (StreamWriter sp = File.AppendText(_Ruta))
                {
                    MySQLGenerarHeaderSP(sp);
                    sp.WriteLine("CREATE PROCEDURE `" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Update` (");
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoFechaModificacion && c.Nombre != _CampoUsuarioCreacion && c.Nombre != _CampoHabilitado)
                        {
                            sp.WriteLine("    v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.MySQLParameter(c) + (n_iteraciones != _lstColumnaBE.Count - 1 ? "," : ""));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine(")");
                    sp.WriteLine("BEGIN");
                    sp.WriteLine("    update `" + _objTablaBE.Nombre + "`");
                    sp.WriteLine("    set");
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (!c.Es_PK && c.Nombre != _CampoFechaCreacion && c.Nombre != _CampoUsuarioCreacion && c.Nombre != _CampoHabilitado)
                        {
                            if (c.Nombre == _CampoFechaModificacion)
                                sp.WriteLine("        `" + c.Nombre + "` = UTC_TIMESTAMP()" + (n_iteraciones != n_no_pk - 1 ? "," : ""));
                            else
                                sp.WriteLine("        `" + c.Nombre + "` = v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_no_pk - 1 ? "," : ""));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine("    where");
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (c.Es_PK)
                        {
                            sp.WriteLine("        `" + c.Nombre + "` = v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_pk - 1 ? " and " : ";"));
                            n_iteraciones++;
                        }
                    }
                    sp.WriteLine("END $$");
                    sp.WriteLine("");
                }
            }
        }

        public void MySQLGenerarDelete()
        {
            int n_iteraciones = 0;
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                MySQLGenerarHeaderSP(sp);
                sp.WriteLine("CREATE PROCEDURE `" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Delete` (");
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (c.Es_PK)
                    {
                        sp.WriteLine("    in v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.MySQLParameter(c) + (n_iteraciones != n_pk - 1 ? "," : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine(")");
                sp.WriteLine("BEGIN");
                sp.WriteLine("    delete from `" + _objTablaBE.Nombre + "`");
                sp.WriteLine("    where");
                n_iteraciones = 0;
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (c.Es_PK)
                    {
                        sp.WriteLine("        `" + c.Nombre + "` = v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_pk - 1 ? " and " : ";"));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine("END $$");
                sp.WriteLine("");
            }
        }

        public void MySQLGenerarSelect()
        {
            String inicial_tabla = _objTablaBE.Nombre.First().ToString().ToLower();
            bool primero = true;

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                MySQLGenerarHeaderSP(sp);
                sp.WriteLine("CREATE PROCEDURE `" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Select`()");
                sp.WriteLine("BEGIN");
                sp.WriteLine("    select ");
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    sp.WriteLine("        " + (primero ? "" : ",") + inicial_tabla + ".`" + c.Nombre + "`");
                    primero = false;
                }
                sp.WriteLine("    from `" + _objTablaBE.Nombre + "` " + inicial_tabla + ";");
                sp.WriteLine("END $$");
                sp.WriteLine("");
            }
        }

        public void MySQLGenerarGet()
        {
            String inicial_tabla = _objTablaBE.Nombre.First().ToString().ToLower();
            bool primero = true;
            int n_iteraciones = 0;
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                MySQLGenerarHeaderSP(sp);
                sp.WriteLine("CREATE PROCEDURE `" + ToolBC.StandarizarNombreClase(_objTablaBE.Nombre) + "_Get`(");
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (c.Es_PK)
                    {
                        sp.WriteLine("    in v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.MySQLParameter(c) + (n_iteraciones != n_pk - 1 ? "," : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine(")");
                sp.WriteLine("BEGIN");
                sp.WriteLine("    select ");
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    sp.WriteLine("        " + (primero ? "" : ",") + inicial_tabla + ".`" + c.Nombre + "`");
                    primero = false;
                }
                sp.WriteLine("    from `" + _objTablaBE.Nombre + "` " + inicial_tabla);
                sp.WriteLine("    where");
                n_iteraciones = 0;
                foreach (ColumnaBE c in _lstColumnaBE)
                {
                    if (c.Es_PK)
                    {
                        sp.WriteLine("        " + inicial_tabla + ".`" + c.Nombre + "` = v_" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_pk - 1 ? " and " : ";"));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine("END $$");
                sp.WriteLine("");
            }
        }
        #endregion
    }
}
