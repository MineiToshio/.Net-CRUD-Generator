namespace Linnso.CRUDGen.PL.Win
{
    partial class frmAccesoBD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbDataSource = new System.Windows.Forms.ComboBox();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.grbLogOn = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSQL = new System.Windows.Forms.RadioButton();
            this.rbWindows = new System.Windows.Forms.RadioButton();
            this.grbBD = new System.Windows.Forms.GroupBox();
            this.cmbBD = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grbLogOn.SuspendLayout();
            this.grbBD.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDataSource
            // 
            this.cmbDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataSource.FormattingEnabled = true;
            this.cmbDataSource.Location = new System.Drawing.Point(22, 92);
            this.cmbDataSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDataSource.Name = "cmbDataSource";
            this.cmbDataSource.Size = new System.Drawing.Size(384, 28);
            this.cmbDataSource.Sorted = true;
            this.cmbDataSource.TabIndex = 0;
            this.cmbDataSource.SelectedIndexChanged += new System.EventHandler(this.cmbDataSource_SelectedIndexChanged);
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(18, 68);
            this.lblDataSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(99, 20);
            this.lblDataSource.TabIndex = 1;
            this.lblDataSource.Text = "Data Source";
            // 
            // lblIntro
            // 
            this.lblIntro.Location = new System.Drawing.Point(18, 14);
            this.lblIntro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(370, 48);
            this.lblIntro.TabIndex = 2;
            this.lblIntro.Text = "Ingrese la información para poder conectarse a la base de datos correspondiente";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(18, 155);
            this.lblServerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(101, 20);
            this.lblServerName.TabIndex = 3;
            this.lblServerName.Text = "Server Name";
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(22, 182);
            this.cmbServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(384, 28);
            this.cmbServer.TabIndex = 4;
            this.cmbServer.TextChanged += new System.EventHandler(this.cmbServer_TextChanged);
            // 
            // grbLogOn
            // 
            this.grbLogOn.Controls.Add(this.btnTest);
            this.grbLogOn.Controls.Add(this.txtContrasena);
            this.grbLogOn.Controls.Add(this.txtUsuario);
            this.grbLogOn.Controls.Add(this.label2);
            this.grbLogOn.Controls.Add(this.label1);
            this.grbLogOn.Controls.Add(this.rbSQL);
            this.grbLogOn.Controls.Add(this.rbWindows);
            this.grbLogOn.Location = new System.Drawing.Point(22, 242);
            this.grbLogOn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbLogOn.Name = "grbLogOn";
            this.grbLogOn.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbLogOn.Size = new System.Drawing.Size(386, 252);
            this.grbLogOn.TabIndex = 5;
            this.grbLogOn.TabStop = false;
            this.grbLogOn.Text = "Log on to the server";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(166, 191);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(200, 35);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Probar Conexión";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Enabled = false;
            this.txtContrasena.Location = new System.Drawing.Point(166, 151);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.Size = new System.Drawing.Size(198, 26);
            this.txtContrasena.TabIndex = 5;
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(166, 106);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(198, 26);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario:";
            // 
            // rbSQL
            // 
            this.rbSQL.AutoSize = true;
            this.rbSQL.Location = new System.Drawing.Point(27, 65);
            this.rbSQL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbSQL.Name = "rbSQL";
            this.rbSQL.Size = new System.Drawing.Size(261, 24);
            this.rbSQL.TabIndex = 1;
            this.rbSQL.Text = "Usar SQL Server Authentication";
            this.rbSQL.UseVisualStyleBackColor = true;
            this.rbSQL.CheckedChanged += new System.EventHandler(this.rbSQL_CheckedChanged);
            // 
            // rbWindows
            // 
            this.rbWindows.AutoSize = true;
            this.rbWindows.Checked = true;
            this.rbWindows.Location = new System.Drawing.Point(27, 29);
            this.rbWindows.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbWindows.Name = "rbWindows";
            this.rbWindows.Size = new System.Drawing.Size(243, 24);
            this.rbWindows.TabIndex = 0;
            this.rbWindows.TabStop = true;
            this.rbWindows.Text = "Usar Windows Authentication";
            this.rbWindows.UseVisualStyleBackColor = true;
            this.rbWindows.CheckedChanged += new System.EventHandler(this.rbWindows_CheckedChanged);
            // 
            // grbBD
            // 
            this.grbBD.Controls.Add(this.cmbBD);
            this.grbBD.Controls.Add(this.label3);
            this.grbBD.Enabled = false;
            this.grbBD.Location = new System.Drawing.Point(22, 505);
            this.grbBD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbBD.Name = "grbBD";
            this.grbBD.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbBD.Size = new System.Drawing.Size(386, 105);
            this.grbBD.TabIndex = 6;
            this.grbBD.TabStop = false;
            this.grbBD.Text = "Conectar a la BD";
            // 
            // cmbBD
            // 
            this.cmbBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBD.FormattingEnabled = true;
            this.cmbBD.Location = new System.Drawing.Point(32, 57);
            this.cmbBD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBD.Name = "cmbBD";
            this.cmbBD.Size = new System.Drawing.Size(332, 28);
            this.cmbBD.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seleccione la Base de Datos";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 618);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(174, 618);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 35);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmAccesoBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 678);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbBD);
            this.Controls.Add(this.grbLogOn);
            this.Controls.Add(this.cmbServer);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblDataSource);
            this.Controls.Add(this.cmbDataSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(20, 20);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccesoBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Conectar";
            this.grbLogOn.ResumeLayout(false);
            this.grbLogOn.PerformLayout();
            this.grbBD.ResumeLayout(false);
            this.grbBD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDataSource;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.GroupBox grbLogOn;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbSQL;
        private System.Windows.Forms.RadioButton rbWindows;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox grbBD;
        private System.Windows.Forms.ComboBox cmbBD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}