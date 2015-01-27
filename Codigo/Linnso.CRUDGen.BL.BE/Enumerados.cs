using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linnso.CRUDGen.BL.BE
{
    public enum DataSource
    { 
        SQLServer = 1,
        MySQL = 2
    }

    public enum Modo
    { 
        Insertar = 1,
        Actualizar = 2,
        Insertar_Actualizar = 3,
        Seleccionar = 4,
        Seleccioar_X_ID = 5,
        Eliminar = 6
    }
}
