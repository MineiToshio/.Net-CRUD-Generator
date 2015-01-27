using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Linnso.CRUDGen.PL.Win
{
    public partial class frmConfiguracion : Form
    {
        public static frmConfiguracion objInstance;

        public frmConfiguracion()
        {
            InitializeComponent();
        }

        public static frmConfiguracion GetInstance()
        {
            if (objInstance == null)
                objInstance = new frmConfiguracion();
            return objInstance;
        }
    }
}
