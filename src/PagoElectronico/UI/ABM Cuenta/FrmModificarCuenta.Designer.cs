namespace PagoElectronico.UI.ABM_Cuenta
{
    partial class FrmModificarCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificarCuenta));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAltaCuenta = new System.Windows.Forms.Button();
            this.grpAltaCuenta = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grpAltaCuenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(433, 111);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 38);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAltaCuenta
            // 
            this.btnAltaCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaCuenta.Image")));
            this.btnAltaCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaCuenta.Location = new System.Drawing.Point(545, 111);
            this.btnAltaCuenta.Name = "btnAltaCuenta";
            this.btnAltaCuenta.Size = new System.Drawing.Size(123, 38);
            this.btnAltaCuenta.TabIndex = 10;
            this.btnAltaCuenta.Text = "Modificar Cuenta";
            this.btnAltaCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAltaCuenta.UseVisualStyleBackColor = true;
            // 
            // grpAltaCuenta
            // 
            this.grpAltaCuenta.Controls.Add(this.dateTimePicker1);
            this.grpAltaCuenta.Controls.Add(this.label2);
            this.grpAltaCuenta.Controls.Add(this.checkBox1);
            this.grpAltaCuenta.Controls.Add(this.label1);
            this.grpAltaCuenta.Controls.Add(this.comboBox1);
            this.grpAltaCuenta.Location = new System.Drawing.Point(12, 12);
            this.grpAltaCuenta.Name = "grpAltaCuenta";
            this.grpAltaCuenta.Size = new System.Drawing.Size(676, 80);
            this.grpAltaCuenta.TabIndex = 9;
            this.grpAltaCuenta.TabStop = false;
            this.grpAltaCuenta.Text = "Dar de Alta Cuenta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(456, 31);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(258, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Habilitada";
            this.checkBox1.UseVisualStyleBackColor = true;
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(105, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // FrmModificarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 165);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAltaCuenta);
            this.Controls.Add(this.grpAltaCuenta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarCuenta";
            this.Text = "Modificar Cuenta Existente";
            this.grpAltaCuenta.ResumeLayout(false);
            this.grpAltaCuenta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAltaCuenta;
        private System.Windows.Forms.GroupBox grpAltaCuenta;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}