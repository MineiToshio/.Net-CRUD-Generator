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
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkGet = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.chkInsertUpdate = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.txtNamespaceDALC = new System.Windows.Forms.TextBox();
            this.txtNamespaceBC = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNamespaceBE = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkGenerarTool = new System.Windows.Forms.CheckBox();
            this.txtCSTag = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbCSConfigFile = new System.Windows.Forms.RadioButton();
            this.ttGenerarTool = new System.Windows.Forms.ToolTip(this.components);
            this.btnNinguno = new System.Windows.Forms.Button();
            this.btnTodo = new System.Windows.Forms.Button();
            this.bwTablasBD = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTablas
            // 
            this.dgvTablas.AllowUserToAddRows = false;
            this.dgvTablas.AllowUserToDeleteRows = false;
            this.dgvTablas.AllowUserToResizeRows = false;
            this.dgvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvTablas.Location = new System.Drawing.Point(12, 41);
            this.dgvTablas.Name = "dgvTablas";
            this.dgvTablas.RowHeadersVisible = false;
            this.dgvTablas.Size = new System.Drawing.Size(518, 200);
            this.dgvTablas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DALC: Data Access Layer Component";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BL: Business Layer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "BE: Business Entity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "SP: Store Procedure";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 138);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leyenda";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(404, 457);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(126, 29);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar CRUD";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDelete);
            this.groupBox2.Controls.Add(this.chkGet);
            this.groupBox2.Controls.Add(this.chkSelect);
            this.groupBox2.Controls.Add(this.chkInsertUpdate);
            this.groupBox2.Controls.Add(this.chkUpdate);
            this.groupBox2.Controls.Add(this.chkInsert);
            this.groupBox2.Location = new System.Drawing.Point(12, 391);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 95);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(114, 66);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(57, 17);
            this.chkDelete.TabIndex = 5;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkGet
            // 
            this.chkGet.AutoSize = true;
            this.chkGet.Checked = true;
            this.chkGet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGet.Location = new System.Drawing.Point(114, 43);
            this.chkGet.Name = "chkGet";
            this.chkGet.Size = new System.Drawing.Size(84, 17);
            this.chkGet.TabIndex = 4;
            this.chkGet.Text = "Select by ID";
            this.chkGet.UseVisualStyleBackColor = true;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Checked = true;
            this.chkSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelect.Location = new System.Drawing.Point(114, 20);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(70, 17);
            this.chkSelect.TabIndex = 3;
            this.chkSelect.Text = "Select All";
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // chkInsertUpdate
            // 
            this.chkInsertUpdate.AutoSize = true;
            this.chkInsertUpdate.Checked = true;
            this.chkInsertUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsertUpdate.Location = new System.Drawing.Point(7, 66);
            this.chkInsertUpdate.Name = "chkInsertUpdate";
            this.chkInsertUpdate.Size = new System.Drawing.Size(92, 17);
            this.chkInsertUpdate.TabIndex = 2;
            this.chkInsertUpdate.Text = "Insert/Update";
            this.chkInsertUpdate.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(7, 43);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(61, 17);
            this.chkUpdate.TabIndex = 1;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Checked = true;
            this.chkInsert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsert.Location = new System.Drawing.Point(7, 20);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(52, 17);
            this.chkInsert.TabIndex = 0;
            this.chkInsert.Text = "Insert";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // txtNamespaceDALC
            // 
            this.txtNamespaceDALC.Location = new System.Drawing.Point(52, 19);
            this.txtNamespaceDALC.Name = "txtNamespaceDALC";
            this.txtNamespaceDALC.Size = new System.Drawing.Size(221, 20);
            this.txtNamespaceDALC.TabIndex = 10;
            // 
            // txtNamespaceBC
            // 
            this.txtNamespaceBC.Location = new System.Drawing.Point(52, 46);
            this.txtNamespaceBC.Name = "txtNamespaceBC";
            this.txtNamespaceBC.Size = new System.Drawing.Size(221, 20);
            this.txtNamespaceBC.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtNamespaceBE);
            this.groupBox3.Controls.Add(this.txtNamespaceDALC);
            this.groupBox3.Controls.Add(this.txtNamespaceBC);
            this.groupBox3.Location = new System.Drawing.Point(251, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 103);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Namespace";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "BE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "BC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "DALC";
            // 
            // txtNamespaceBE
            // 
            this.txtNamespaceBE.Location = new System.Drawing.Point(52, 72);
            this.txtNamespaceBE.Name = "txtNamespaceBE";
            this.txtNamespaceBE.Size = new System.Drawing.Size(221, 20);
            this.txtNamespaceBE.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkGenerarTool);
            this.groupBox4.Controls.Add(this.txtCSTag);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.rbCSConfigFile);
            this.groupBox4.Location = new System.Drawing.Point(251, 356);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(279, 95);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cadena de Conexión";
            // 
            // chkGenerarTool
            // 
            this.chkGenerarTool.AutoSize = true;
            this.chkGenerarTool.Checked = true;
            this.chkGenerarTool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerarTool.Location = new System.Drawing.Point(82, 67);
            this.chkGenerarTool.Name = "chkGenerarTool";
            this.chkGenerarTool.Size = new System.Drawing.Size(102, 17);
            this.chkGenerarTool.TabIndex = 3;
            this.chkGenerarTool.Tag = "";
            this.chkGenerarTool.Text = "Generar Tool.cs";
            this.ttGenerarTool.SetToolTip(this.chkGenerarTool, "Genera un archivo Tool.cs en donde se creará una función que jale los datos de ls" +
        " cadena de coneción");
            this.chkGenerarTool.UseVisualStyleBackColor = true;
            // 
            // txtCSTag
            // 
            this.txtCSTag.Location = new System.Drawing.Point(82, 40);
            this.txtCSTag.Name = "txtCSTag";
            this.txtCSTag.Size = new System.Drawing.Size(191, 20);
            this.txtCSTag.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tag";
            // 
            // rbCSConfigFile
            // 
            this.rbCSConfigFile.AutoSize = true;
            this.rbCSConfigFile.Checked = true;
            this.rbCSConfigFile.Location = new System.Drawing.Point(22, 19);
            this.rbCSConfigFile.Name = "rbCSConfigFile";
            this.rbCSConfigFile.Size = new System.Drawing.Size(74, 17);
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
            this.btnNinguno.Location = new System.Drawing.Point(455, 12);
            this.btnNinguno.Name = "btnNinguno";
            this.btnNinguno.Size = new System.Drawing.Size(75, 23);
            this.btnNinguno.TabIndex = 14;
            this.btnNinguno.Text = "Ninguno";
            this.btnNinguno.UseVisualStyleBackColor = true;
            this.btnNinguno.Click += new System.EventHandler(this.btnNinguno_Click);
            // 
            // btnTodo
            // 
            this.btnTodo.Location = new System.Drawing.Point(374, 12);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(75, 23);
            this.btnTodo.TabIndex = 15;
            this.btnTodo.Text = "Todo";
            this.btnTodo.UseVisualStyleBackColor = true;
            this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);
            // 
            // frmTablasBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 498);
            this.Controls.Add(this.btnTodo);
            this.Controls.Add(this.btnNinguno);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTablas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
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
        private System.Windows.Forms.CheckBox chkInsertUpdate;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.TextBox txtNamespaceDALC;
        private System.Windows.Forms.TextBox txtNamespaceBC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNamespaceBE;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkGenerarTool;
        private System.Windows.Forms.TextBox txtCSTag;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbCSConfigFile;
        private System.Windows.Forms.ToolTip ttGenerarTool;
        private System.Windows.Forms.Button btnNinguno;
        private System.Windows.Forms.Button btnTodo;
        private System.ComponentModel.BackgroundWorker bwTablasBD;
    }
}