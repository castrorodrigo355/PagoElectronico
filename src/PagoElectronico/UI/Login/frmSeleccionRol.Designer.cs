using PagoElectronico.BusinessEntities;
using System.Drawing;
namespace PagoElectronico.UI.Login
{
    partial class frmSeleccionRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionRol));
            this.grpRoles = new System.Windows.Forms.GroupBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.grpRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRoles
            // 
            this.grpRoles.Controls.Add(this.btnCliente);
            this.grpRoles.Controls.Add(this.btnAdministrador);
            this.grpRoles.Controls.Add(this.lblCliente);
            this.grpRoles.Controls.Add(this.lblAdministrador);
            this.grpRoles.Location = new System.Drawing.Point(13, 12);
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Size = new System.Drawing.Size(559, 337);
            this.grpRoles.TabIndex = 0;
            this.grpRoles.TabStop = false;
            this.grpRoles.Text = "Seleccione el perfil para ingresar al sistema";
            // 
            // btnCliente
            // 
            this.btnCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnCliente.Image")));
            this.btnCliente.Location = new System.Drawing.Point(316, 64);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(200, 200);
            this.btnCliente.TabIndex = 7;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.Image = ((System.Drawing.Image)(resources.GetObject("btnAdministrador.Image")));
            this.btnAdministrador.Location = new System.Drawing.Point(51, 64);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(200, 200);
            this.btnAdministrador.TabIndex = 6;
            this.btnAdministrador.UseVisualStyleBackColor = true;
            this.btnAdministrador.Click += new System.EventHandler(this.btnAdministrador_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(395, 267);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 5;
            this.lblCliente.Text = "Cliente";
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.AutoSize = true;
            this.lblAdministrador.Location = new System.Drawing.Point(116, 267);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(70, 13);
            this.lblAdministrador.TabIndex = 4;
            this.lblAdministrador.Text = "Administrador";
            // 
            // frmSeleccionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.grpRoles);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeleccionRol";
            this.Text = "Sistema Pago Electronico";
            this.grpRoles.ResumeLayout(false);
            this.grpRoles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRoles;
        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.Button btnCliente;
    }
}