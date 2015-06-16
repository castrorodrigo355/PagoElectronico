namespace PagoElectronico.UI.ABM_Cuenta
{
    partial class FrmABMCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmABMCuenta));
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnDarBajaCuenta = new System.Windows.Forms.Button();
            this.btnModificarCuenta = new System.Windows.Forms.Button();
            this.btnAltaCuenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Location = new System.Drawing.Point(17, 29);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.Size = new System.Drawing.Size(727, 289);
            this.dgvCuentas.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiarFiltros);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCuentas);
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 333);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuentas";
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarFiltros.Image")));
            this.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(510, 86);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(105, 38);
            this.btnLimpiarFiltros.TabIndex = 44;
            this.btnLimpiarFiltros.Text = "Limpiar filtros";
            this.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(623, 86);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(121, 38);
            this.btnFiltrar.TabIndex = 43;
            this.btnFiltrar.Text = "Filtrar resultados";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // btnDarBajaCuenta
            // 
            this.btnDarBajaCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnDarBajaCuenta.Image")));
            this.btnDarBajaCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDarBajaCuenta.Location = new System.Drawing.Point(635, 511);
            this.btnDarBajaCuenta.Name = "btnDarBajaCuenta";
            this.btnDarBajaCuenta.Size = new System.Drawing.Size(126, 38);
            this.btnDarBajaCuenta.TabIndex = 8;
            this.btnDarBajaCuenta.Text = "Inhabilitar cuenta";
            this.btnDarBajaCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDarBajaCuenta.UseVisualStyleBackColor = true;
            // 
            // btnModificarCuenta
            // 
            this.btnModificarCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarCuenta.Image")));
            this.btnModificarCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarCuenta.Location = new System.Drawing.Point(506, 511);
            this.btnModificarCuenta.Name = "btnModificarCuenta";
            this.btnModificarCuenta.Size = new System.Drawing.Size(121, 38);
            this.btnModificarCuenta.TabIndex = 7;
            this.btnModificarCuenta.Text = "Modificar cuenta";
            this.btnModificarCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarCuenta.UseVisualStyleBackColor = true;
            // 
            // btnAltaCuenta
            // 
            this.btnAltaCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaCuenta.Image")));
            this.btnAltaCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaCuenta.Location = new System.Drawing.Point(403, 511);
            this.btnAltaCuenta.Name = "btnAltaCuenta";
            this.btnAltaCuenta.Size = new System.Drawing.Size(97, 38);
            this.btnAltaCuenta.TabIndex = 6;
            this.btnAltaCuenta.Text = "Alta cuenta";
            this.btnAltaCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAltaCuenta.UseVisualStyleBackColor = true;
            // 
            // FrmABMCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnDarBajaCuenta);
            this.Controls.Add(this.btnModificarCuenta);
            this.Controls.Add(this.btnAltaCuenta);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmABMCuenta";
            this.Text = "FrmABMCuenta";
            this.Load += new System.EventHandler(this.FrmABMCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnDarBajaCuenta;
        private System.Windows.Forms.Button btnModificarCuenta;
        private System.Windows.Forms.Button btnAltaCuenta;
    }
}