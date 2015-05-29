using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Linnso.CRUDGen.PL.Win
{
    public class Tools
    {
        public static void GetPostName(out string dalc, out string bc, out string be)
        {
            string path = Application.StartupPath + @"\datos\config.xml";
            var xml = XDocument.Load(path);
            dalc = bc = be = "";

            var postNames = from postName in xml.Descendants("postname") select postName;

            foreach (var p in postNames)
            {
                switch (p.Attribute("nombre").Value)
                {
                    case "BC": bc = p.Attribute("valor").Value; break;
                    case "BE": be = p.Attribute("valor").Value; break;
                    case "DALC": dalc = p.Attribute("valor").Value; break;
                }
            }
        }

        public static void GetCamposAuditoria(out string usuarioCreacion, out string usuarioModificacion, out string fechaCreacion, out string fechaModificacion)
        {
            string path = Application.StartupPath + @"\datos\config.xml";
            var xml = XDocument.Load(path);
            usuarioCreacion = usuarioModificacion = fechaCreacion = fechaModificacion = "";

            var auditorias = from auditoria in xml.Descendants("auditoria") select auditoria;

            foreach (var p in auditorias)
            {
                switch (p.Attribute("nombre").Value)
                {
                    case "UsuarioCreacion": usuarioCreacion = p.Attribute("valor").Value; break;
                    case "UsuarioModificacion": usuarioModificacion = p.Attribute("valor").Value; break;
                    case "FechaCreacion": fechaCreacion = p.Attribute("valor").Value; break;
                    case "FechaModificacion": fechaModificacion = p.Attribute("valor").Value; break;
                }
            }
        }
    }
}
