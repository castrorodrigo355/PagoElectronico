namespace PagoElectronico.UI.ABM_Rol
{
    partial class FrmABMRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmABMRol));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.btnInhabilitarRol = new System.Windows.Forms.Button();
            this.btnModificarRol = new System.Windows.Forms.Button();
            this.btnAltaRol = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRoles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Roles";
            // 
            // dgvRoles
            // 
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(16, 19);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Size = new System.Drawing.Size(422, 154);
            this.dgvRoles.TabIndex = 0;
            // 
            // btnInhabilitarRol
            // 
            this.btnInhabilitarRol.Image = ((System.Drawing.Image)(resources.GetObject("btnInhabilitarRol.Image")));
            this.btnInhabilitarRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInhabilitarRol.Location = new System.Drawing.Point(358, 221);
            this.btnInhabilitarRol.Name = "btnInhabilitarRol";
            this.btnInhabilitarRol.Size = new System.Drawing.Size(109, 38);
            this.btnInhabilitarRol.TabIndex = 8;
            this.btnInhabilitarRol.Text = "Inhabilitar Rol";
            this.btnInhabilitarRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInhabilitarRol.UseVisualStyleBackColor = true;
            // 
            // btnModificarRol
            // 
            this.btnModificarRol.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarRol.Image")));
            this.btnModificarRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarRol.Location = new System.Drawing.Point(245, 221);
            this.btnModificarRol.Name = "btnModificarRol";
            this.btnModificarRol.Size = new System.Drawing.Size(107, 38);
            this.btnModificarRol.TabIndex = 7;
            this.btnModificarRol.Text = "Modificar Rol";
            this.btnModificarRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarRol.UseVisualStyleBackColor = true;
            // 
            // btnAltaRol
            // 
            this.btnAltaRol.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaRol.Image")));
            this.btnAltaRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaRol.Location = new System.Drawing.Point(156, 221);
            this.btnAltaRol.Name = "btnAltaRol";
            this.btnAltaRol.Size = new System.Drawing.Size(83, 38);
            this.btnAltaRol.TabIndex = 6;
            this.btnAltaRol.Text = "Alta Rol";
            this.btnAltaRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAltaRol.UseVisualStyleBackColor = true;
            this.btnAltaRol.Click += new System.EventHandler(this.btnAltaRol_Click);
            // 
            // FrmABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 281);
            this.Controls.Add(this.btnInhabilitarRol);
            this.Controls.Add(this.btnModificarRol);
            this.Controls.Add(this.btnAltaRol);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmABMRol";
            this.Text = "FrmABMRol";
            this.Load += new System.EventHandler(this.FrmABMRol_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnInhabilitarRol;
        private System.Windows.Forms.Button btnModificarRol;
        private System.Windows.Forms.Button btnAltaRol;
    }
}