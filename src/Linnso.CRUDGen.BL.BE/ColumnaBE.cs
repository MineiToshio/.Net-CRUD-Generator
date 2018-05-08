using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linnso.CRUDGen.BL.BE
{
    public class ColumnaBE
    {
        public String Nombre { get; set; }
        public Boolean Acepta_Nulos { get; set; }
        public String Tipo_Dato { get; set; }
        public Boolean Es_PK { get; set; }
        public Boolean Es_Identity { get; set; }
        public long Tamano_Maximo { get; set; }
        public int Precision_Numerica { get; set; }
        public int Precision_Numerica_Base { get; set; }
    }
}
