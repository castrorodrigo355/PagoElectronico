namespace PagoElectronico.UI.Depositos
{
    partial class FrmDepositos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepositos));
            this.grpCuentas = new System.Windows.Forms.GroupBox();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.grpDeposito = new System.Windows.Forms.GroupBox();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRealizarDeposito = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.cmbTarjetaCredito = new System.Windows.Forms.ComboBox();
            this.grpCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.grpDeposito.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCuentas
            // 
            this.grpCuentas.Controls.Add(this.dgvCuentas);
            this.grpCuentas.Location = new System.Drawing.Point(12, 12);
            this.grpCuentas.Name = "grpCuentas";
            this.grpCuentas.Size = new System.Drawing.Size(563, 216);
            this.grpCuentas.TabIndex = 0;
            this.grpCuentas.TabStop = false;
            this.grpCuentas.Text = "Cuentas";
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Location = new System.Drawing.Point(17, 19);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.Size = new System.Drawing.Size(528, 179);
            this.dgvCuentas.TabIndex = 0;
            // 
            // grpDeposito
            // 
            this.grpDeposito.Controls.Add(this.btnLimpiarCampos);
            this.grpDeposito.Controls.Add(this.label2);
            this.grpDeposito.Controls.Add(this.btnRealizarDeposito);
            this.grpDeposito.Controls.Add(this.label1);
            this.grpDeposito.Controls.Add(this.txtImporte);
            this.grpDeposito.Controls.Add(this.cmbMoneda);
            this.grpDeposito.Controls.Add(this.lblImporte);
            this.grpDeposito.Controls.Add(this.cmbTarjetaCredito);
            this.grpDeposito.Location = new System.Drawing.Point(12, 234);
            this.grpDeposito.Name = "grpDeposito";
            this.grpDeposito.Size = new System.Drawing.Size(563, 118);
            this.grpDeposito.TabIndex = 1;
            this.grpDeposito.TabStop = false;
            this.grpDeposito.Text = "Deposito";
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarCampos.Image")));
            this.btnLimpiarCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarCampos.Location = new System.Drawing.Point(411, 62);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(134, 36);
            this.btnLimpiarCampos.TabIndex = 8;
            this.btnLimpiarCampos.Text = "Limpiar campos";
            this.btnLimpiarCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tarjeta de credito:";
            // 
            // btnRealizarDeposito
            // 
            this.btnRealizarDeposito.Image = ((System.Drawing.Image)(resources.GetObject("btnRealizarDeposito.Image")));
            this.btnRealizarDeposito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRealizarDeposito.Location = new System.Drawing.Point(411, 17);
            this.btnRealizarDeposito.Name = "btnRealizarDeposito";
            this.btnRealizarDeposito.Size = new System.Drawing.Size(134, 36);
            this.btnRealizarDeposito.TabIndex = 7;
            this.btnRealizarDeposito.Text = "Realizar deposito";
            this.btnRealizarDeposito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRealizarDeposito.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione moneda:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(293, 26);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(95, 20);
            this.txtImporte.TabIndex = 2;
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(124, 26);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(95, 21);
            this.cmbMoneda.TabIndex = 3;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(242, 29);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(45, 13);
            this.lblImporte.TabIndex = 1;
            this.lblImporte.Text = "Importe:";
            // 
            // cmbTarjetaCredito
            // 
            this.cmbTarjetaCredito.FormattingEnabled = true;
            this.cmbTarjetaCredito.Location = new System.Drawing.Point(124, 71);
            this.cmbTarjetaCredito.Name = "cmbTarjetaCredito";
            this.cmbTarjetaCredito.Size = new System.Drawing.Size(264, 21);
            this.cmbTarjetaCredito.TabIndex = 0;
            // 
            // FrmDepositos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 367);
            this.Controls.Add(this.grpDeposito);
            this.Controls.Add(this.grpCuentas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDepositos";
            this.Text = "FrmDepositos";
            this.Load += new System.EventHandler(this.FrmDepositos_Load);
            this.grpCuentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.grpDeposito.ResumeLayout(false);
            this.grpDeposito.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCuentas;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.GroupBox grpDeposito;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.ComboBox cmbTarjetaCredito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnRealizarDeposito;
    }
}