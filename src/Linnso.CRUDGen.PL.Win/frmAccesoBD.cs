using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Linnso.CRUDGen.BL.BC;
using Linnso.CRUDGen.BL.BE;

namespace Linnso.CRUDGen.PL.Win
{
    public partial class frmAccesoBD : Form
    {
        public static frmAccesoBD objInstance;
        public int _DataSource { get; set; }
        public String _Server { get; set; }
        public String _Usuario { get; set; }
        public String _Contrasena { get; set; }
        public String _BD { get; set; }

        public frmAccesoBD()
        {
            InitializeComponent();
            LlenarDataSource();
        }

        public void ServerFocus()
        {
            cmbServer.Focus();
        }

        public static frmAccesoBD GetInstance()
        {
            if (objInstance == null)
                objInstance = new frmAccesoBD();
            return objInstance;
        }

        private void LlenarDataSource()
        {
            var items = new BindingList<KeyValuePair<string, string>>();

            items.Add(new KeyValuePair<string, string>("1", "Microsoft SQL Server"));
            items.Add(new KeyValuePair<string, string>("2", "Oracle MySQL Server"));

            cmbDataSource.DataSource = items;
            cmbDataSource.ValueMember = "Key";
            cmbDataSource.DisplayMember = "Value";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            List<String> lstBD = new List<String>();
            SystemBC objSystemBC = new SystemBC();
            ConexionBE objConexionBE = new ConexionBE();
            objConexionBE.Server = cmbServer.Text;
            objConexionBE.User = txtUsuario.Text;
            objConexionBE.Password = txtContrasena.Text;

            try
            {
                if (ValidarTest())
                {
                    switch (Convert.ToInt32(cmbDataSource.SelectedValue))
                    {
                        case (int)DataSource.SQLServer:
                            lstBD = objSystemBC.Select_SQL_Databases(objConexionBE);
                            break;
                        case (int)DataSource.MySQL:
                            lstBD = objSystemBC.Select_MySQL_Databases(objConexionBE);
                            break;
                    }

                    cmbBD.DataSource = lstBD;
                    //cmbDataSource.ValueMember = "Key";
                    //cmbDataSource.DisplayMember = "Value";

                    HabilitarBD(true);

                    MessageBox.Show("Conexión exitosa", "Probar Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, complete todo los campos solicitados.", "Probar Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lo sentimos, ha ocurrido un error al conectarse con la base de datos. Revise los parámetros de conexión.", "Probar Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }

        private void HabilitarBD(bool habilitar)
        {
            grbBD.Enabled = habilitar;
            btnOk.Enabled = habilitar;

            if (!habilitar)
            {
                cmbBD.DataSource = null;
            }
        }

        private bool ValidarTest()
        {
            if (rbSQL.Checked && (String.IsNullOrEmpty(txtContrasena.Text) || String.IsNullOrEmpty(txtContrasena.Text))
                || String.IsNullOrEmpty(cmbServer.Text))
                return false;

            return true;
        }

        private void rbWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWindows.Checked)
            {
                HabilitarSQLAuth(false);
                HabilitarBD(false);
            }
        }

        private void rbSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSQL.Checked)
            {
                HabilitarSQLAuth(true);
                HabilitarBD(false);
            }
        }

        private void HabilitarSQLAuth(bool habilitar)
        {
            txtContrasena.Enabled = habilitar;
            txtUsuario.Enabled = habilitar;

            txtContrasena.Text = "";
            txtUsuario.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void cmbServer_TextChanged(object sender, EventArgs e)
        {
            HabilitarBD(false);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            HabilitarBD(false);
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            HabilitarBD(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _Server = cmbServer.Text;
            _DataSource = Convert.ToInt32(cmbDataSource.SelectedValue);
            _Usuario = txtUsuario.Text;
            _Contrasena = txtContrasena.Text;
            _BD = cmbBD.Text;

            frmTablasBD objfrmTablasBD = frmTablasBD.GetInstance();
            objfrmTablasBD.MdiParent = this.MdiParent;
            objfrmTablasBD.Show();
            objfrmTablasBD.LlenarGrilla();
            this.Hide();
        }

        private void cmbDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor;
            bool esNumero = int.TryParse(cmbDataSource.SelectedValue.ToString(), out valor);

            if (esNumero)
            {
                switch (Convert.ToInt32(valor))
                {
                    case (int)DataSource.SQLServer:
                        rbWindows.Enabled = true;
                        rbWindows.Checked = true;
                        rbSQL.Checked = false;
                        break;
                    case (int)DataSource.MySQL:
                        rbWindows.Enabled = false;
                        rbSQL.Checked = true;
                        txtUsuario.Focus();
                        break;
                }
            }
        }
    }
}
