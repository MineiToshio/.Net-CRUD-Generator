namespace Linnso.CRUDGen.PL.Win
{
    partial class frmTablasBD
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
            this.components = new System.ComponentModel.Container();
            this.dgvTablas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.fbdFileOutpot = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkChangeState = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkGet = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.txtPreNamespace = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkGenerarTool = new System.Windows.Forms.CheckBox();
            this.txtCSTag = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbCSConfigFile = new System.Windows.Forms.RadioButton();
            this.ttGenerarTool = new System.Windows.Forms.ToolTip(this.components);
            this.btnNinguno = new System.Windows.Forms.Button();
            this.btnTodo = new System.Windows.Forms.Button();
            this.bwTablasBD = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkLogErrores = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTablas
            // 
            this.dgvTablas.AllowUserToAddRows = false;
            this.dgvTablas.AllowUserToDeleteRows = false;
            this.dgvTablas.AllowUserToResizeRows = false;
            this.dgvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvTablas.Location = new System.Drawing.Point(18, 63);
            this.dgvTablas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTablas.Name = "dgvTablas";
            this.dgvTablas.RowHeadersVisible = false;
            this.dgvTablas.Size = new System.Drawing.Size(787, 308);
            this.dgvTablas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "DALC: Data Access Layer Component";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "BL: Business Layer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "BE: Business Entity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "SP: Store Procedure";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 380);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(333, 212);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leyenda";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(376, 704);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(418, 44);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar CRUD";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkChangeState);
            this.groupBox2.Controls.Add(this.chkDelete);
            this.groupBox2.Controls.Add(this.chkGet);
            this.groupBox2.Controls.Add(this.chkSelect);
            this.groupBox2.Controls.Add(this.chkUpdate);
            this.groupBox2.Controls.Add(this.chkInsert);
            this.groupBox2.Location = new System.Drawing.Point(18, 602);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(333, 146);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CRUD a Generar";
            // 
            // chkChangeState
            // 
            this.chkChangeState.AutoSize = true;
            this.chkChangeState.Checked = true;
            this.chkChangeState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChangeState.Location = new System.Drawing.Point(10, 102);
            this.chkChangeState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkChangeState.Name = "chkChangeState";
            this.chkChangeState.Size = new System.Drawing.Size(134, 24);
            this.chkChangeState.TabIndex = 6;
            this.chkChangeState.Text = "Change State";
            this.chkChangeState.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(171, 102);
            this.chkDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(82, 24);
            this.chkDelete.TabIndex = 5;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkGet
            // 
            this.chkGet.AutoSize = true;
            this.chkGet.Checked = true;
            this.chkGet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGet.Location = new System.Drawing.Point(171, 66);
            this.chkGet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkGet.Name = "chkGet";
            this.chkGet.Size = new System.Drawing.Size(121, 24);
            this.chkGet.TabIndex = 4;
            this.chkGet.Text = "Select by ID";
            this.chkGet.UseVisualStyleBackColor = true;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Checked = true;
            this.chkSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelect.Location = new System.Drawing.Point(171, 31);
            this.chkSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(101, 24);
            this.chkSelect.TabIndex = 3;
            this.chkSelect.Text = "Select All";
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(10, 66);
            this.chkUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(88, 24);
            this.chkUpdate.TabIndex = 1;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Checked = true;
            this.chkInsert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsert.Location = new System.Drawing.Point(10, 31);
            this.chkInsert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(76, 24);
            this.chkInsert.TabIndex = 0;
            this.chkInsert.Text = "Insert";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // txtPreNamespace
            // 
            this.txtPreNamespace.Location = new System.Drawing.Point(135, 29);
            this.txtPreNamespace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPreNamespace.Name = "txtPreNamespace";
            this.txtPreNamespace.Size = new System.Drawing.Size(273, 26);
            this.txtPreNamespace.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtPreNamespace);
            this.groupBox3.Location = new System.Drawing.Point(376, 380);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(418, 69);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Namespace";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "PreNamespace";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkGenerarTool);
            this.groupBox4.Controls.Add(this.txtCSTag);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.rbCSConfigFile);
            this.groupBox4.Location = new System.Drawing.Point(377, 460);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(418, 132);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cadena de Conexión";
            // 
            // chkGenerarTool
            // 
            this.chkGenerarTool.AutoSize = true;
            this.chkGenerarTool.Checked = true;
            this.chkGenerarTool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerarTool.Location = new System.Drawing.Point(123, 98);
            this.chkGenerarTool.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkGenerarTool.Name = "chkGenerarTool";
            this.chkGenerarTool.Size = new System.Drawing.Size(148, 24);
            this.chkGenerarTool.TabIndex = 3;
            this.chkGenerarTool.Tag = "";
            this.chkGenerarTool.Text = "Generar Tool.cs";
            this.ttGenerarTool.SetToolTip(this.chkGenerarTool, "Genera un archivo Tool.cs en donde se creará una función que jale los datos de ls" +
        " cadena de coneción");
            this.chkGenerarTool.UseVisualStyleBackColor = true;
            // 
            // txtCSTag
            // 
            this.txtCSTag.Location = new System.Drawing.Point(123, 62);
            this.txtCSTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCSTag.Name = "txtCSTag";
            this.txtCSTag.Size = new System.Drawing.Size(284, 26);
            this.txtCSTag.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tag";
            // 
            // rbCSConfigFile
            // 
            this.rbCSConfigFile.AutoSize = true;
            this.rbCSConfigFile.Checked = true;
            this.rbCSConfigFile.Location = new System.Drawing.Point(33, 29);
            this.rbCSConfigFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbCSConfigFile.Name = "rbCSConfigFile";
            this.rbCSConfigFile.Size = new System.Drawing.Size(109, 24);
            this.rbCSConfigFile.TabIndex = 0;
            this.rbCSConfigFile.TabStop = true;
            this.rbCSConfigFile.Text = "Config File";
            this.rbCSConfigFile.UseVisualStyleBackColor = true;
            // 
            // ttGenerarTool
            // 
            this.ttGenerarTool.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttGenerarTool.ToolTipTitle = "Información";
            // 
            // btnNinguno
            // 
            this.btnNinguno.Location = new System.Drawing.Point(693, 18);
            this.btnNinguno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNinguno.Name = "btnNinguno";
            this.btnNinguno.Size = new System.Drawing.Size(112, 35);
            this.btnNinguno.TabIndex = 14;
            this.btnNinguno.Text = "Ninguno";
            this.btnNinguno.UseVisualStyleBackColor = true;
            this.btnNinguno.Click += new System.EventHandler(this.btnNinguno_Click);
            // 
            // btnTodo
            // 
            this.btnTodo.Location = new System.Drawing.Point(572, 18);
            this.btnTodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(112, 35);
            this.btnTodo.TabIndex = 15;
            this.btnTodo.Text = "Todo";
            this.btnTodo.UseVisualStyleBackColor = true;
            this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkLogErrores);
            this.groupBox5.Location = new System.Drawing.Point(377, 602);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(418, 82);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Otras Opciones";
            // 
            // chkLogErrores
            // 
            this.chkLogErrores.AutoSize = true;
            this.chkLogErrores.Checked = true;
            this.chkLogErrores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogErrores.Location = new System.Drawing.Point(12, 31);
            this.chkLogErrores.Name = "chkLogErrores";
            this.chkLogErrores.Size = new System.Drawing.Size(140, 24);
            this.chkLogErrores.TabIndex = 0;
            this.chkLogErrores.Text = "Log de Errores";
            this.chkLogErrores.UseVisualStyleBackColor = true;
            // 
            // frmTablasBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(818, 765);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnTodo);
            this.Controls.Add(this.btnNinguno);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTablas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTablasBD";
            this.Text = "Tablas de Base de Datos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTablas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.FolderBrowserDialog fbdFileOutpot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkGet;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.TextBox txtPreNamespace;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkGenerarTool;
        private System.Windows.Forms.TextBox txtCSTag;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbCSConfigFile;
        private System.Windows.Forms.ToolTip ttGenerarTool;
        private System.Windows.Forms.Button btnNinguno;
        private System.Windows.Forms.Button btnTodo;
        private System.ComponentModel.BackgroundWorker bwTablasBD;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkLogErrores;
        private System.Windows.Forms.CheckBox chkChangeState;
    }
}