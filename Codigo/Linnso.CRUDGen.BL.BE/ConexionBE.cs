using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linnso.CRUDGen.BL.BE
{
    public class ConexionBE
    {
        public int DataSource { get; set; }
        public String Server { get; set; }
        public String DataBase { get; set; }
        public String User { get; set; }
        public String Password { get; set; }
    }
}
