namespace PagoElectronico.UI.Retiros
{
    partial class FrmRetiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRetiros));
            this.grpCuentas = new System.Windows.Forms.GroupBox();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.grpDeposito = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRealizarDeposito = new System.Windows.Forms.Button();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.grpCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.grpDeposito.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCuentas
            // 
            this.grpCuentas.Controls.Add(this.dgvCuentas);
            this.grpCuentas.Location = new System.Drawing.Point(16, 12);
            this.grpCuentas.Name = "grpCuentas";
            this.grpCuentas.Size = new System.Drawing.Size(563, 216);
            this.grpCuentas.TabIndex = 1;
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
            this.grpDeposito.Controls.Add(this.btnCancelar);
            this.grpDeposito.Controls.Add(this.btnRealizarDeposito);
            this.grpDeposito.Controls.Add(this.txtImporte);
            this.grpDeposito.Controls.Add(this.lblImporte);
            this.grpDeposito.Location = new System.Drawing.Point(12, 237);
            this.grpDeposito.Name = "grpDeposito";
            this.grpDeposito.Size = new System.Drawing.Size(563, 73);
            this.grpDeposito.TabIndex = 2;
            this.grpDeposito.TabStop = false;
            this.grpDeposito.Text = "Retiro de Efectivo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(433, 17);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 36);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar retiro";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnRealizarDeposito
            // 
            this.btnRealizarDeposito.Image = ((System.Drawing.Image)(resources.GetObject("btnRealizarDeposito.Image")));
            this.btnRealizarDeposito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRealizarDeposito.Location = new System.Drawing.Point(299, 17);
            this.btnRealizarDeposito.Name = "btnRealizarDeposito";
            this.btnRealizarDeposito.Size = new System.Drawing.Size(116, 36);
            this.btnRealizarDeposito.TabIndex = 7;
            this.btnRealizarDeposito.Text = "Realizar retiro";
            this.btnRealizarDeposito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRealizarDeposito.UseVisualStyleBackColor = true;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(80, 26);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(121, 20);
            this.txtImporte.TabIndex = 2;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(29, 29);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(45, 13);
            this.lblImporte.TabIndex = 1;
            this.lblImporte.Text = "Importe:";
            // 
            // FrmRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 324);
            this.Controls.Add(this.grpDeposito);
            this.Controls.Add(this.grpCuentas);
            this.Name = "FrmRetiros";
            this.Text = "FrmRetiros";
            this.Load += new System.EventHandler(this.FrmRetiros_Load);
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
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRealizarDeposito;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblImporte;
    }
}