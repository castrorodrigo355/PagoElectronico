namespace PagoElectronico.UI.ABM_Cuenta
{
    partial class FrmAltaCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAltaCuenta));
            this.grpListadoClientes = new System.Windows.Forms.GroupBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.grpAltaCuenta = new System.Windows.Forms.GroupBox();
            this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkHabilitada = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoCuenta = new System.Windows.Forms.ComboBox();
            this.btnAltaCuenta = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpListadoClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.grpAltaCuenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpListadoClientes
            // 
            this.grpListadoClientes.Controls.Add(this.dgvClientes);
            this.grpListadoClientes.Location = new System.Drawing.Point(12, 12);
            this.grpListadoClientes.Name = "grpListadoClientes";
            this.grpListadoClientes.Size = new System.Drawing.Size(676, 317);
            this.grpListadoClientes.TabIndex = 1;
            this.grpListadoClientes.TabStop = false;
            this.grpListadoClientes.Text = "Listado de Clientes";
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(19, 20);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(637, 278);
            this.dgvClientes.TabIndex = 0;
            // 
            // grpAltaCuenta
            // 
            this.grpAltaCuenta.Controls.Add(this.dtpFechaCierre);
            this.grpAltaCuenta.Controls.Add(this.label2);
            this.grpAltaCuenta.Controls.Add(this.chkHabilitada);
            this.grpAltaCuenta.Controls.Add(this.label1);
            this.grpAltaCuenta.Controls.Add(this.cmbTipoCuenta);
            this.grpAltaCuenta.Location = new System.Drawing.Point(12, 336);
            this.grpAltaCuenta.Name = "grpAltaCuenta";
            this.grpAltaCuenta.Size = new System.Drawing.Size(676, 80);
            this.grpAltaCuenta.TabIndex = 2;
            this.grpAltaCuenta.TabStop = false;
            this.grpAltaCuenta.Text = "Dar de Alta Cuenta";
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.Location = new System.Drawing.Point(456, 31);
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaCierre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha de cierre:";
            // 
            // chkHabilitada
            // 
            this.chkHabilitada.AutoSize = true;
            this.chkHabilitada.Location = new System.Drawing.Point(258, 32);
            this.chkHabilitada.Name = "chkHabilitada";
            this.chkHabilitada.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitada.TabIndex = 2;
            this.chkHabilitada.Text = "Habilitada";
            this.chkHabilitada.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Cuenta:";
            // 
            // cmbTipoCuenta
            // 
            this.cmbTipoCuenta.FormattingEnabled = true;
            this.cmbTipoCuenta.Location = new System.Drawing.Point(105, 30);
            this.cmbTipoCuenta.Name = "cmbTipoCuenta";
            this.cmbTipoCuenta.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoCuenta.TabIndex = 0;
            // 
            // btnAltaCuenta
            // 
            this.btnAltaCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaCuenta.Image")));
            this.btnAltaCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaCuenta.Location = new System.Drawing.Point(571, 435);
            this.btnAltaCuenta.Name = "btnAltaCuenta";
            this.btnAltaCuenta.Size = new System.Drawing.Size(97, 38);
            this.btnAltaCuenta.TabIndex = 7;
            this.btnAltaCuenta.Text = "Alta cuenta";
            this.btnAltaCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAltaCuenta.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(455, 435);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 38);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmAltaCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 487);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAltaCuenta);
            this.Controls.Add(this.grpAltaCuenta);
            this.Controls.Add(this.grpListadoClientes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAltaCuenta";
            this.Text = "Nueva Cuenta";
            this.Load += new System.EventHandler(this.FrmAltaCuenta_Load);
            this.grpListadoClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.grpAltaCuenta.ResumeLayout(false);
            this.grpAltaCuenta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpListadoClientes;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.GroupBox grpAltaCuenta;
        private System.Windows.Forms.DateTimePicker dtpFechaCierre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkHabilitada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoCuenta;
        private System.Windows.Forms.Button btnAltaCuenta;
        private System.Windows.Forms.Button btnCancelar;
    }
}