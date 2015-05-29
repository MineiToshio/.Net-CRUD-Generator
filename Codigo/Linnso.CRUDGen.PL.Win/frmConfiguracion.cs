using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Linnso.CRUDGen.PL.Win
{
    public partial class frmConfiguracion : Form
    {
        public static frmConfiguracion objInstance;

        public frmConfiguracion()
        {
            InitializeComponent();
            CargarDatos();
        }

        public static frmConfiguracion GetInstance()
        {
            if (objInstance == null)
                objInstance = new frmConfiguracion();
            return objInstance;
        }

        public void CargarDatos()
        {
            string dalc, bc, be = "";
            Tools.GetPostName(out dalc, out bc, out be);
            txtDALC.Text = dalc; 
            txtBC.Text = bc; 
            txtBE.Text = be;

            string usuarioCreacion, usuarioModificacion, fechaCreacion, fechaModificacion = "";
            Tools.GetCamposAuditoria(out usuarioCreacion, out usuarioModificacion, out fechaCreacion, out fechaModificacion);
            txtUsuarioCreacion.Text = usuarioCreacion;
            txtUsuarioModificacion.Text = usuarioModificacion;
            txtFechaCreacion.Text = fechaCreacion;
            txtFechaModificacion.Text = fechaModificacion;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            FormClosingEventArgs ce = e as FormClosingEventArgs;
            if (ce != null)
            {
                if (ce.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    this.Visible = false;
                }
                else
                    this.Close();
            }

            base.OnClosing(e);
        }

        //protected override void OnLoad(CancelEventArgs e)
        //{
        //    CargarDatos();

        //    base.OnLoad(e);
        //}

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmConfiguracion_Shown(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
