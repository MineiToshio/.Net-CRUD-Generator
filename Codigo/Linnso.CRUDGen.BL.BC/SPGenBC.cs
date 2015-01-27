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

        public void GenerarHeader()
        {
            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                sp.WriteLine("USE [" + _DataBase + "]");
                sp.WriteLine("");
            }
        }

        public void GenerarHeaderSP(StreamWriter sp, Modo modo)
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

        public void GenerarInsert()
        {
            int n_identity = (from c in _lstColumnaBE where c.Es_Identity select c).Count();
            int n_no_identity = (from c in _lstColumnaBE where !c.Es_Identity select c).Count();
            int n_iteraciones = 0;

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                GenerarHeaderSP(sp, Modo.Insertar);
                
                sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre_Sin_Espacios + "_Insert] (");
                foreach(ColumnaBE c in _lstColumnaBE)
                {
                    if (!c.Es_Identity)
                    {
                        sp.WriteLine("    @" + ToolBC.StandarizarNombreParametro(c.Nombre) + " " + ToolBC.SQLParameter(c) + (c.Acepta_Nulos ? " = null" : "") + (n_iteraciones != n_no_identity - 1 ? "," : ""));
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

        public void GenerarUpdate()
        {
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();

            if (n_no_pk != 0  && n_pk != 0)
            {
                int n_iteraciones = 0;

                using (StreamWriter sp = File.AppendText(_Ruta))
                {
                    GenerarHeaderSP(sp, Modo.Actualizar);
                    sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre_Sin_Espacios + "_Update] (");
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
                    sp.WriteLine("");
                    sp.WriteLine("    update [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre + "]");
                    sp.WriteLine("    set");
                    n_iteraciones = 0;
                    foreach (ColumnaBE c in _lstColumnaBE)
                    {
                        if (!c.Es_PK)
                        {
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

        public void GenerarInsertUpdate()
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
                    GenerarHeaderSP(sp, Modo.Insertar_Actualizar);
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

        public void GenerarDelete()
        {
            int n_iteraciones = 0;
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                GenerarHeaderSP(sp, Modo.Eliminar);
                sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre_Sin_Espacios + "_Delete] (");
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

        public void GenerarSelect()
        {
            String inicial_tabla = _objTablaBE.Nombre.First().ToString().ToLower();
            bool primero = true;

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                GenerarHeaderSP(sp, Modo.Seleccionar);
                sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre_Sin_Espacios + "_Select]");
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

        public void GenerarGet()
        {
            String inicial_tabla = _objTablaBE.Nombre.First().ToString().ToLower();
            bool primero = true;
            int n_iteraciones = 0;
            int n_pk = (from c in _lstColumnaBE where c.Es_PK select c).Count();
            int n_no_pk = (from c in _lstColumnaBE where !c.Es_PK select c).Count();

            using (StreamWriter sp = File.AppendText(_Ruta))
            {
                GenerarHeaderSP(sp, Modo.Seleccioar_X_ID);
                sp.WriteLine("CREATE PROCEDURE [" + _objTablaBE.Esquema + "].[" + _objTablaBE.Nombre_Sin_Espacios + "_Get](");
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
                        sp.WriteLine("        " + inicial_tabla + ".[" + c.Nombre + "] = @" + ToolBC.StandarizarNombreParametro(c.Nombre) + (n_iteraciones != n_pk - 1 ? " or " : ""));
                        n_iteraciones++;
                    }
                }
                sp.WriteLine("END");
                sp.WriteLine("GO");
                sp.WriteLine("");
            }
        }
    }
}
