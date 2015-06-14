namespace PagoElectronico.login
{
    partial class Login
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
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.grpDatosUsuario = new System.Windows.Forms.GroupBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.grpNuevoUsuario = new System.Windows.Forms.GroupBox();
            this.btnNuevoUsuario = new System.Windows.Forms.Button();
            this.grpDatosUsuario.SuspendLayout();
            this.grpNuevoUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.Location = new System.Drawing.Point(7, 12);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(251, 13);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenido al Sistema de Pago Electrónico";
            this.lblBienvenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpDatosUsuario
            // 
            this.grpDatosUsuario.Controls.Add(this.btnIngresar);
            this.grpDatosUsuario.Controls.Add(this.txtPassword);
            this.grpDatosUsuario.Controls.Add(this.txtNombreUsuario);
            this.grpDatosUsuario.Location = new System.Drawing.Point(15, 41);
            this.grpDatosUsuario.Name = "grpDatosUsuario";
            this.grpDatosUsuario.Size = new System.Drawing.Size(243, 137);
            this.grpDatosUsuario.TabIndex = 1;
            this.grpDatosUsuario.TabStop = false;
            this.grpDatosUsuario.Text = "Si ya estas registrado, ingresa tus datos";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(40, 101);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(167, 23);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.AccessibleDescription = "";
            this.txtPassword.AccessibleName = "";
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(40, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "Contraseña";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(40, 28);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(167, 20);
            this.txtNombreUsuario.TabIndex = 2;
            this.txtNombreUsuario.Text = "Nombre de Usuario";
            // 
            // grpNuevoUsuario
            // 
            this.grpNuevoUsuario.Controls.Add(this.btnNuevoUsuario);
            this.grpNuevoUsuario.Location = new System.Drawing.Point(15, 185);
            this.grpNuevoUsuario.Name = "grpNuevoUsuario";
            this.grpNuevoUsuario.Size = new System.Drawing.Size(243, 64);
            this.grpNuevoUsuario.TabIndex = 2;
            this.grpNuevoUsuario.TabStop = false;
            this.grpNuevoUsuario.Text = "¿No estas registrado?";
            // 
            // btnNuevoUsuario
            // 
            this.btnNuevoUsuario.Location = new System.Drawing.Point(40, 24);
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.Size = new System.Drawing.Size(167, 23);
            this.btnNuevoUsuario.TabIndex = 0;
            this.btnNuevoUsuario.Text = "Nuevo Usuario";
            this.btnNuevoUsuario.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 261);
            this.Controls.Add(this.grpNuevoUsuario);
            this.Controls.Add(this.grpDatosUsuario);
            this.Controls.Add(this.lblBienvenido);
            this.Name = "Login";
            this.Text = "Sistema de Pago Electrónico";
            this.grpDatosUsuario.ResumeLayout(false);
            this.grpDatosUsuario.PerformLayout();
            this.grpNuevoUsuario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.GroupBox grpDatosUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox grpNuevoUsuario;
        private System.Windows.Forms.Button btnNuevoUsuario;
    }
}