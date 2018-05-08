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
    public partial class frmAbout : Form
    {
        public static frmAbout objInstance;

        public frmAbout()
        {
            InitializeComponent();
        }

        public static frmAbout GetInstance()
        {
            if (objInstance == null)
                objInstance = new frmAbout();
            return objInstance;
        }
    }
}
