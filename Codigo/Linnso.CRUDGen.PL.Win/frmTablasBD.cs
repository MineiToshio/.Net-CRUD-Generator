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
using System.IO;

namespace Linnso.CRUDGen.PL.Win
{
    public partial class frmTablasBD : Form
    {
        public static frmTablasBD objInstance;

        public frmTablasBD()
        {
            InitializeComponent();
            //LlenarGrilla();
        }

        public static frmTablasBD GetInstance()
        {
            if (objInstance == null)
                objInstance = new frmTablasBD();
            return objInstance;
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

        private ConexionBE ObtenerConexion()
        {
            frmAccesoBD objfrmAccesoBD = frmAccesoBD.GetInstance();

            ConexionBE objConexionBE = new ConexionBE();
            objConexionBE.Server = objfrmAccesoBD._Server;
            objConexionBE.DataBase = objfrmAccesoBD._BD;
            objConexionBE.User = objfrmAccesoBD._Usuario;
            objConexionBE.Password = objfrmAccesoBD._Contrasena;
            objConexionBE.DataSource = objfrmAccesoBD._DataSource;

            return objConexionBE;
        }

        public void LlenarGrilla()
        {
            SystemBC objSystemBC = new SystemBC();
            frmAccesoBD objfrmAccesoBD = frmAccesoBD.GetInstance();
            List<TablaBE> lstTablaBE = new List<TablaBE>();
            

            try
            {
                switch (Convert.ToInt32(objfrmAccesoBD._DataSource))
                {
                    case (int)DataSource.SQLServer:
                        lstTablaBE = objSystemBC.Select_SQL_Table(ObtenerConexion());
                        break;
                }

                dgvTablas.Columns.Clear();

                dgvTablas.DataSource = lstTablaBE;

                dgvTablas.Columns["Nombre"].Width = 200;
                dgvTablas.Columns["Nombre"].ReadOnly = true;
                dgvTablas.Columns["Nombre"].HeaderText = "Tabla";

                dgvTablas.Columns["Esquema"].Width = 115;
                dgvTablas.Columns["Esquema"].ReadOnly = true;

                dgvTablas.Columns["Nombre_Sin_Espacios"].Visible = false;

                AgregarCheckColumn("DALC");
                AgregarCheckColumn("BC");
                AgregarCheckColumn("BE");
                AgregarCheckColumn("SP");

                SeleccionarTodo(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AgregarCheckColumn(String header)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = header;
            chk.HeaderText = header;
            chk.Width = 50;
            chk.ReadOnly = false;
            chk.FillWeight = 10;
            dgvTablas.Columns.Add(chk);
        }

        private void SeleccionarTodo(bool habilitado)
        {
            foreach (DataGridViewRow r in dgvTablas.Rows)
            {
                r.Cells["DALC"].Value = habilitado;
                r.Cells["BC"].Value = habilitado;
                r.Cells["BE"].Value = habilitado;
                r.Cells["SP"].Value = habilitado;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdFileOutpot.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                String ruta = fbdFileOutpot.SelectedPath;
                SystemBC objSystemBC = new SystemBC();
                ConexionBE objConexionBE = ObtenerConexion();

                //frmAccesoBD objfrmAccesoBD = frmAccesoBD.GetInstance();

                String dir = ruta;
                String dir_bd = dir + "/" + objConexionBE.DataBase + "_CRUD_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                Directory.CreateDirectory(dir_bd);

                String dir_dalc = dir_bd + "/DALC";
                String dir_bc = dir_bd + "/BC";
                String dir_be = dir_bd + "/BE";
                String dir_sp = dir_bd + "/SP";

                Boolean sp_header = false;

                foreach (DataGridViewRow r in dgvTablas.Rows)
                {
                    TablaBE objTablaBE = new TablaBE();
                    objTablaBE.Nombre = r.Cells["Nombre"].Value.ToString();
                    objTablaBE.Esquema = r.Cells["Esquema"].Value.ToString();
                    objTablaBE.Nombre_Sin_Espacios = r.Cells["Nombre"].Value.ToString().Replace(" ", "_");

                    List<ColumnaBE> lstColumnaBE = objSystemBC.Select_SQL_Columna(objConexionBE, objTablaBE);

                    if ((bool)r.Cells["DALC"].Value == true)
                    {
                        CrearCarpeta(dir_dalc);

                        String archivo_dalc = dir_dalc + "/" + objTablaBE.Nombre_Sin_Espacios + "DALC.cs";
                        File.Create(archivo_dalc).Dispose();

                        DALCGenBC objDALCGen = new DALCGenBC();
                        objDALCGen._Ruta = archivo_dalc;
                        objDALCGen._DataSource = objConexionBE.DataSource;
                        objDALCGen._Tool = chkGenerarTool.Checked;
                        objDALCGen._Tag = txtCSTag.Text;
                        objDALCGen._lstColumnaBE = lstColumnaBE;
                        objDALCGen._objTablaBE = objTablaBE;

                        objDALCGen.GenerarHeader(txtNamespaceDALC.Text, txtNamespaceBE.Text);

                        if (chkInsert.Checked) objDALCGen.GenerarInsert();
                        if (chkUpdate.Checked) objDALCGen.GenerarUpdate();
                        if (chkInsertUpdate.Checked) objDALCGen.GenerarInsertUpdate();
                        if (chkSelect.Checked) objDALCGen.GenerarSelect();
                        if (chkGet.Checked) objDALCGen.GenerarGet();
                        if (chkDelete.Checked) objDALCGen.GenerarDelete();

                        objDALCGen.GenerarFooter();
                    }
                    if ((bool)r.Cells["BC"].Value == true)
                    {
                        CrearCarpeta(dir_bc);

                        String archivo_bc = dir_bc + "/" + objTablaBE.Nombre_Sin_Espacios + "BC.cs";
                        File.Create(archivo_bc).Dispose();

                        BCGenBC objBCGenBC = new BCGenBC();
                        objBCGenBC._Ruta = archivo_bc;
                        objBCGenBC._lstColumnaBE = lstColumnaBE;
                        objBCGenBC._objTablaBE = objTablaBE;

                        objBCGenBC.GenerarHeader(txtNamespaceBC.Text, txtNamespaceDALC.Text, txtNamespaceBE.Text);

                        if (chkInsert.Checked) objBCGenBC.GenerarInsert();
                        if (chkUpdate.Checked) objBCGenBC.GenerarUpdate();
                        if (chkInsertUpdate.Checked) objBCGenBC.GenerarInsertUpdate();
                        if (chkSelect.Checked) objBCGenBC.GenerarSelect();
                        if (chkGet.Checked) objBCGenBC.GenerarGet();
                        if (chkDelete.Checked) objBCGenBC.GenerarDelete();

                        objBCGenBC.GenerarFooter();
                    }
                    if ((bool)r.Cells["BE"].Value == true)
                    {
                        CrearCarpeta(dir_be);

                        String archivo_be = dir_be + "/" + objTablaBE.Nombre_Sin_Espacios + "BE.cs";
                        File.Create(archivo_be).Dispose();

                        BEGenBC objBEGenBC = new BEGenBC();
                        objBEGenBC._Ruta = archivo_be;
                        objBEGenBC._lstColumnaBE = lstColumnaBE;
                        objBEGenBC._objTablaBE = objTablaBE;

                        objBEGenBC.GenerarHeader(txtNamespaceBE.Text);
                        objBEGenBC.GenerarClase();
                        objBEGenBC.GenerarFooter();
                    }
                    if ((bool)r.Cells["SP"].Value == true)
                    {
                        CrearCarpeta(dir_sp);

                        String archivo_sp = dir_sp + "/script.sql";
                        if(!File.Exists(archivo_sp))
                            File.Create(archivo_sp).Dispose();

                        SPGenBC objSPGenBC = new SPGenBC();
                        objSPGenBC._DataSource = objConexionBE.DataSource;
                        objSPGenBC._lstColumnaBE = lstColumnaBE;
                        objSPGenBC._objTablaBE = objTablaBE;
                        objSPGenBC._Ruta = archivo_sp;
                        objSPGenBC._DataBase = objConexionBE.DataBase;

                        if (!sp_header)
                        {
                            objSPGenBC.GenerarHeader();
                            sp_header = true;
                        }

                        if (chkInsert.Checked) objSPGenBC.GenerarInsert();
                        if (chkUpdate.Checked) objSPGenBC.GenerarUpdate();
                        if (chkInsertUpdate.Checked) objSPGenBC.GenerarInsertUpdate();
                        if (chkSelect.Checked) objSPGenBC.GenerarSelect();
                        if (chkGet.Checked) objSPGenBC.GenerarGet();
                        if (chkDelete.Checked) objSPGenBC.GenerarDelete();
                    }
                }

                if (chkGenerarTool.Checked)
                {
                    CrearCarpeta(dir_dalc);

                    String archivo_tool = dir_dalc + "/Tool.cs";
                    File.Create(archivo_tool).Dispose();

                    ToolGenBC objToolBC = new ToolGenBC();
                    objToolBC._Ruta = archivo_tool;
                    objToolBC.CrearArchivo(txtNamespaceDALC.Text, txtCSTag.Text);
                }

                MessageBox.Show("Los archivos se generaros satisfacotoriamente.", "Generar CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CrearCarpeta(String dir)
        {
            if (!File.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            SeleccionarTodo(true);
        }

        private void btnNinguno_Click(object sender, EventArgs e)
        {
            SeleccionarTodo(false);
        }
    }
}
