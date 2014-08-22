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
    public partial class frmCRUDGenerator : Form
    {
        public frmCRUDGenerator()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmConectar_Click(object sender, EventArgs e)
        {
            frmAccesoBD form = frmAccesoBD.GetInstance();
            form.MdiParent = this;
            form.Show();
            form.ServerFocus();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout form = frmAbout.GetInstance();
            form.MdiParent = this;
            form.Show();
        }
    }
}
