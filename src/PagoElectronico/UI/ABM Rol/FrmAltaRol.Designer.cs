namespace PagoElectronico.UI.ABM_Rol
{
    partial class FrmAltaRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAltaRol));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstFuncionalidadesAsignadas = new System.Windows.Forms.ListBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.lstFuncionalidadesDisponibles = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAltaRol = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstFuncionalidadesAsignadas);
            this.groupBox1.Controls.Add(this.btnAsignar);
            this.groupBox1.Controls.Add(this.btnDesasignar);
            this.groupBox1.Controls.Add(this.lstFuncionalidadesDisponibles);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades";
            // 
            // lstFuncionalidadesAsignadas
            // 
            this.lstFuncionalidadesAsignadas.FormattingEnabled = true;
            this.lstFuncionalidadesAsignadas.Location = new System.Drawing.Point(277, 19);
            this.lstFuncionalidadesAsignadas.Name = "lstFuncionalidadesAsignadas";
            this.lstFuncionalidadesAsignadas.Size = new System.Drawing.Size(163, 121);
            this.lstFuncionalidadesAsignadas.TabIndex = 4;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Image = ((System.Drawing.Image)(resources.GetObject("btnAsignar.Image")));
            this.btnAsignar.Location = new System.Drawing.Point(210, 42);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(41, 30);
            this.btnAsignar.TabIndex = 3;
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnDesasignar
            // 
            this.btnDesasignar.Image = ((System.Drawing.Image)(resources.GetObject("btnDesasignar.Image")));
            this.btnDesasignar.Location = new System.Drawing.Point(210, 88);
            this.btnDesasignar.Name = "btnDesasignar";
            this.btnDesasignar.Size = new System.Drawing.Size(41, 30);
            this.btnDesasignar.TabIndex = 2;
            this.btnDesasignar.UseVisualStyleBackColor = true;
            // 
            // lstFuncionalidadesDisponibles
            // 
            this.lstFuncionalidadesDisponibles.FormattingEnabled = true;
            this.lstFuncionalidadesDisponibles.Location = new System.Drawing.Point(21, 23);
            this.lstFuncionalidadesDisponibles.Name = "lstFuncionalidadesDisponibles";
            this.lstFuncionalidadesDisponibles.Size = new System.Drawing.Size(163, 121);
            this.lstFuncionalidadesDisponibles.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkHabilitado);
            this.groupBox2.Controls.Add(this.txtNombreRol);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo Rol";
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(277, 24);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 2;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(90, 22);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(165, 20);
            this.txtNombreRol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Rol:";
            // 
            // btnAltaRol
            // 
            this.btnAltaRol.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaRol.Image")));
            this.btnAltaRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaRol.Location = new System.Drawing.Point(389, 240);
            this.btnAltaRol.Name = "btnAltaRol";
            this.btnAltaRol.Size = new System.Drawing.Size(83, 38);
            this.btnAltaRol.TabIndex = 7;
            this.btnAltaRol.Text = "Alta Rol";
            this.btnAltaRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAltaRol.UseVisualStyleBackColor = true;
            this.btnAltaRol.Click += new System.EventHandler(this.btnAltaRol_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarCampos.Image")));
            this.btnLimpiarCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarCampos.Location = new System.Drawing.Point(265, 240);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(118, 39);
            this.btnLimpiarCampos.TabIndex = 8;
            this.btnLimpiarCampos.Text = "Limpiar campos";
            this.btnLimpiarCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            // 
            // FrmAltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 290);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnAltaRol);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAltaRol";
            this.Text = "FrmAltaRol";
            this.Load += new System.EventHandler(this.FrmAltaRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstFuncionalidadesDisponibles;
        private System.Windows.Forms.ListBox lstFuncionalidadesAsignadas;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.Button btnAltaRol;
        private System.Windows.Forms.Button btnLimpiarCampos;
    }
}