namespace PagoElectronico.UI.ABM_Cliente
{
    partial class FrmAltaCliente
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
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.lblNumeroDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblNacionalidad = new System.Windows.Forms.Label();
            this.grpDatosCliente = new System.Windows.Forms.GroupBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.cmbPais = new System.Windows.Forms.ComboBox();
            this.txtCalleNro = new System.Windows.Forms.TextBox();
            this.lblNro = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtNacionalidad = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.lblDepto = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.lblPiso = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblApellidosCliente = new System.Windows.Forms.Label();
            this.lblNombresCliente = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblRoles = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPreguntaSecreta = new System.Windows.Forms.Label();
            this.cmbPreguntaSecreta = new System.Windows.Forms.ComboBox();
            this.lblRespuestaSecreta = new System.Windows.Forms.Label();
            this.txtRespuestaSecreta = new System.Windows.Forms.TextBox();
            this.grpDatosUsuario = new System.Windows.Forms.GroupBox();
            this.txtConfirmarPassword = new System.Windows.Forms.TextBox();
            this.lblRepetirContraseña = new System.Windows.Forms.Label();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.chkAdministrador = new System.Windows.Forms.CheckBox();
            this.pictureCliente = new System.Windows.Forms.PictureBox();
            this.pictureAdministrador = new System.Windows.Forms.PictureBox();
            this.epValidador = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpDatosCliente.SuspendLayout();
            this.grpDatosUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAdministrador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epValidador)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarCampos.Location = new System.Drawing.Point(399, 358);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(121, 38);
            this.btnLimpiarCampos.TabIndex = 3;
            this.btnLimpiarCampos.Text = "Limpiar campos";
            this.btnLimpiarCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCliente.Location = new System.Drawing.Point(526, 358);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(121, 38);
            this.btnAgregarCliente.TabIndex = 2;
            this.btnAgregarCliente.Text = "Agregar cliente";
            this.btnAgregarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(132, 185);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(206, 20);
            this.dtpFechaNacimiento.TabIndex = 0;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(17, 71);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(102, 13);
            this.lblTipoDocumento.TabIndex = 3;
            this.lblTipoDocumento.Text = "Tipo de documento:";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(20, 86);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(106, 21);
            this.cmbTipoDocumento.TabIndex = 4;
            // 
            // lblNumeroDocumento
            // 
            this.lblNumeroDocumento.AutoSize = true;
            this.lblNumeroDocumento.Location = new System.Drawing.Point(159, 71);
            this.lblNumeroDocumento.Name = "lblNumeroDocumento";
            this.lblNumeroDocumento.Size = new System.Drawing.Size(118, 13);
            this.lblNumeroDocumento.TabIndex = 5;
            this.lblNumeroDocumento.Text = "Numero de documento:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(162, 87);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(176, 20);
            this.txtDocumento.TabIndex = 6;
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(20, 40);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(166, 20);
            this.txtNombres.TabIndex = 7;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(201, 40);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(137, 20);
            this.txtApellidos.TabIndex = 8;
            // 
            // lblNacionalidad
            // 
            this.lblNacionalidad.AutoSize = true;
            this.lblNacionalidad.Location = new System.Drawing.Point(17, 125);
            this.lblNacionalidad.Name = "lblNacionalidad";
            this.lblNacionalidad.Size = new System.Drawing.Size(72, 13);
            this.lblNacionalidad.TabIndex = 9;
            this.lblNacionalidad.Text = "Nacionalidad:";
            // 
            // grpDatosCliente
            // 
            this.grpDatosCliente.Controls.Add(this.lblPais);
            this.grpDatosCliente.Controls.Add(this.cmbPais);
            this.grpDatosCliente.Controls.Add(this.txtCalleNro);
            this.grpDatosCliente.Controls.Add(this.lblNro);
            this.grpDatosCliente.Controls.Add(this.lblMail);
            this.grpDatosCliente.Controls.Add(this.txtMail);
            this.grpDatosCliente.Controls.Add(this.txtNacionalidad);
            this.grpDatosCliente.Controls.Add(this.lblLocalidad);
            this.grpDatosCliente.Controls.Add(this.txtLocalidad);
            this.grpDatosCliente.Controls.Add(this.txtDepto);
            this.grpDatosCliente.Controls.Add(this.lblDepto);
            this.grpDatosCliente.Controls.Add(this.txtPiso);
            this.grpDatosCliente.Controls.Add(this.lblPiso);
            this.grpDatosCliente.Controls.Add(this.txtCalle);
            this.grpDatosCliente.Controls.Add(this.lblCalle);
            this.grpDatosCliente.Controls.Add(this.lblFechaNacimiento);
            this.grpDatosCliente.Controls.Add(this.lblApellidosCliente);
            this.grpDatosCliente.Controls.Add(this.lblNombresCliente);
            this.grpDatosCliente.Controls.Add(this.lblNacionalidad);
            this.grpDatosCliente.Controls.Add(this.txtApellidos);
            this.grpDatosCliente.Controls.Add(this.txtNombres);
            this.grpDatosCliente.Controls.Add(this.txtDocumento);
            this.grpDatosCliente.Controls.Add(this.lblNumeroDocumento);
            this.grpDatosCliente.Controls.Add(this.cmbTipoDocumento);
            this.grpDatosCliente.Controls.Add(this.lblTipoDocumento);
            this.grpDatosCliente.Controls.Add(this.dtpFechaNacimiento);
            this.grpDatosCliente.Location = new System.Drawing.Point(289, 14);
            this.grpDatosCliente.Name = "grpDatosCliente";
            this.grpDatosCliente.Size = new System.Drawing.Size(359, 329);
            this.grpDatosCliente.TabIndex = 1;
            this.grpDatosCliente.TabStop = false;
            this.grpDatosCliente.Text = "Datos Cliente";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(17, 155);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(30, 13);
            this.lblPais.TabIndex = 26;
            this.lblPais.Text = "Pais:";
            // 
            // cmbPais
            // 
            this.cmbPais.FormattingEnabled = true;
            this.cmbPais.Location = new System.Drawing.Point(53, 152);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(194, 21);
            this.cmbPais.TabIndex = 25;
            // 
            // txtCalleNro
            // 
            this.txtCalleNro.Location = new System.Drawing.Point(181, 261);
            this.txtCalleNro.Name = "txtCalleNro";
            this.txtCalleNro.Size = new System.Drawing.Size(39, 20);
            this.txtCalleNro.TabIndex = 24;
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Location = new System.Drawing.Point(178, 245);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(34, 13);
            this.lblNro.TabIndex = 23;
            this.lblNro.Text = "Altura";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(17, 222);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 22;
            this.lblMail.Text = "Mail:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(52, 219);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(286, 20);
            this.txtMail.TabIndex = 16;
            // 
            // txtNacionalidad
            // 
            this.txtNacionalidad.Location = new System.Drawing.Point(104, 122);
            this.txtNacionalidad.Name = "txtNacionalidad";
            this.txtNacionalidad.Size = new System.Drawing.Size(234, 20);
            this.txtNacionalidad.TabIndex = 21;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(17, 295);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 20;
            this.lblLocalidad.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(84, 292);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(254, 20);
            this.txtLocalidad.TabIndex = 19;
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(299, 261);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(39, 20);
            this.txtDepto.TabIndex = 18;
            // 
            // lblDepto
            // 
            this.lblDepto.AutoSize = true;
            this.lblDepto.Location = new System.Drawing.Point(296, 245);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(36, 13);
            this.lblDepto.TabIndex = 17;
            this.lblDepto.Text = "Depto";
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(238, 261);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(39, 20);
            this.txtPiso.TabIndex = 16;
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(235, 245);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(27, 13);
            this.lblPiso.TabIndex = 15;
            this.lblPiso.Text = "Piso";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(20, 261);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(145, 20);
            this.txtCalle.TabIndex = 14;
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(17, 245);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(30, 13);
            this.lblCalle.TabIndex = 13;
            this.lblCalle.Text = "Calle";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(17, 188);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(109, 13);
            this.lblFechaNacimiento.TabIndex = 12;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento:";
            // 
            // lblApellidosCliente
            // 
            this.lblApellidosCliente.AutoSize = true;
            this.lblApellidosCliente.Location = new System.Drawing.Point(198, 24);
            this.lblApellidosCliente.Name = "lblApellidosCliente";
            this.lblApellidosCliente.Size = new System.Drawing.Size(49, 13);
            this.lblApellidosCliente.TabIndex = 11;
            this.lblApellidosCliente.Text = "Apellidos";
            // 
            // lblNombresCliente
            // 
            this.lblNombresCliente.AutoSize = true;
            this.lblNombresCliente.Location = new System.Drawing.Point(17, 24);
            this.lblNombresCliente.Name = "lblNombresCliente";
            this.lblNombresCliente.Size = new System.Drawing.Size(49, 13);
            this.lblNombresCliente.TabIndex = 10;
            this.lblNombresCliente.Text = "Nombres";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(19, 25);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(101, 13);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Nombre de Usuario:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(19, 73);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(22, 166);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(37, 13);
            this.lblRoles.TabIndex = 3;
            this.lblRoles.Text = "Roles:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(22, 41);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(221, 20);
            this.txtNombreUsuario.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(22, 89);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(221, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPreguntaSecreta
            // 
            this.lblPreguntaSecreta.AutoSize = true;
            this.lblPreguntaSecreta.Location = new System.Drawing.Point(22, 232);
            this.lblPreguntaSecreta.Name = "lblPreguntaSecreta";
            this.lblPreguntaSecreta.Size = new System.Drawing.Size(91, 13);
            this.lblPreguntaSecreta.TabIndex = 6;
            this.lblPreguntaSecreta.Text = "Pregunta secreta:";
            // 
            // cmbPreguntaSecreta
            // 
            this.cmbPreguntaSecreta.FormattingEnabled = true;
            this.cmbPreguntaSecreta.Location = new System.Drawing.Point(25, 248);
            this.cmbPreguntaSecreta.Name = "cmbPreguntaSecreta";
            this.cmbPreguntaSecreta.Size = new System.Drawing.Size(218, 21);
            this.cmbPreguntaSecreta.TabIndex = 7;
            // 
            // lblRespuestaSecreta
            // 
            this.lblRespuestaSecreta.AutoSize = true;
            this.lblRespuestaSecreta.Location = new System.Drawing.Point(19, 276);
            this.lblRespuestaSecreta.Name = "lblRespuestaSecreta";
            this.lblRespuestaSecreta.Size = new System.Drawing.Size(99, 13);
            this.lblRespuestaSecreta.TabIndex = 8;
            this.lblRespuestaSecreta.Text = "Respuesta secreta:";
            // 
            // txtRespuestaSecreta
            // 
            this.txtRespuestaSecreta.Location = new System.Drawing.Point(22, 292);
            this.txtRespuestaSecreta.Name = "txtRespuestaSecreta";
            this.txtRespuestaSecreta.Size = new System.Drawing.Size(221, 20);
            this.txtRespuestaSecreta.TabIndex = 9;
            // 
            // grpDatosUsuario
            // 
            this.grpDatosUsuario.Controls.Add(this.txtConfirmarPassword);
            this.grpDatosUsuario.Controls.Add(this.lblRepetirContraseña);
            this.grpDatosUsuario.Controls.Add(this.chkCliente);
            this.grpDatosUsuario.Controls.Add(this.chkAdministrador);
            this.grpDatosUsuario.Controls.Add(this.pictureCliente);
            this.grpDatosUsuario.Controls.Add(this.pictureAdministrador);
            this.grpDatosUsuario.Controls.Add(this.txtRespuestaSecreta);
            this.grpDatosUsuario.Controls.Add(this.lblRespuestaSecreta);
            this.grpDatosUsuario.Controls.Add(this.cmbPreguntaSecreta);
            this.grpDatosUsuario.Controls.Add(this.lblPreguntaSecreta);
            this.grpDatosUsuario.Controls.Add(this.txtPassword);
            this.grpDatosUsuario.Controls.Add(this.txtNombreUsuario);
            this.grpDatosUsuario.Controls.Add(this.lblRoles);
            this.grpDatosUsuario.Controls.Add(this.lblContraseña);
            this.grpDatosUsuario.Controls.Add(this.lblNombreUsuario);
            this.grpDatosUsuario.Location = new System.Drawing.Point(13, 13);
            this.grpDatosUsuario.Name = "grpDatosUsuario";
            this.grpDatosUsuario.Size = new System.Drawing.Size(259, 330);
            this.grpDatosUsuario.TabIndex = 0;
            this.grpDatosUsuario.TabStop = false;
            this.grpDatosUsuario.Text = "Datos Usuario";
            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Location = new System.Drawing.Point(22, 139);
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.Size = new System.Drawing.Size(221, 20);
            this.txtConfirmarPassword.TabIndex = 15;
            // 
            // lblRepetirContraseña
            // 
            this.lblRepetirContraseña.AutoSize = true;
            this.lblRepetirContraseña.Location = new System.Drawing.Point(19, 123);
            this.lblRepetirContraseña.Name = "lblRepetirContraseña";
            this.lblRepetirContraseña.Size = new System.Drawing.Size(100, 13);
            this.lblRepetirContraseña.TabIndex = 14;
            this.lblRepetirContraseña.Text = "Repetir contraseña:";
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Location = new System.Drawing.Point(186, 197);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(58, 17);
            this.chkCliente.TabIndex = 13;
            this.chkCliente.Text = "Cliente";
            this.chkCliente.UseVisualStyleBackColor = true;
            // 
            // chkAdministrador
            // 
            this.chkAdministrador.AutoSize = true;
            this.chkAdministrador.Location = new System.Drawing.Point(58, 197);
            this.chkAdministrador.Name = "chkAdministrador";
            this.chkAdministrador.Size = new System.Drawing.Size(89, 17);
            this.chkAdministrador.TabIndex = 12;
            this.chkAdministrador.Text = "Administrador";
            this.chkAdministrador.UseVisualStyleBackColor = true;
            // 
            // pictureCliente
            // 
            this.pictureCliente.Location = new System.Drawing.Point(153, 188);
            this.pictureCliente.Name = "pictureCliente";
            this.pictureCliente.Size = new System.Drawing.Size(27, 30);
            this.pictureCliente.TabIndex = 11;
            this.pictureCliente.TabStop = false;
            // 
            // pictureAdministrador
            // 
            this.pictureAdministrador.Location = new System.Drawing.Point(25, 188);
            this.pictureAdministrador.Name = "pictureAdministrador";
            this.pictureAdministrador.Size = new System.Drawing.Size(27, 30);
            this.pictureAdministrador.TabIndex = 10;
            this.pictureAdministrador.TabStop = false;
            // 
            // epValidador
            // 
            this.epValidador.ContainerControl = this;
            // 
            // FrmAltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 411);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.grpDatosCliente);
            this.Controls.Add(this.grpDatosUsuario);
            this.Name = "FrmAltaCliente";
            this.Text = "Nuevo cliente";
            this.Load += new System.EventHandler(this.FrmAltaCliente_Load);
            this.grpDatosCliente.ResumeLayout(false);
            this.grpDatosCliente.PerformLayout();
            this.grpDatosUsuario.ResumeLayout(false);
            this.grpDatosUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAdministrador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epValidador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.Label lblNumeroDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblNacionalidad;
        private System.Windows.Forms.GroupBox grpDatosCliente;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPreguntaSecreta;
        private System.Windows.Forms.ComboBox cmbPreguntaSecreta;
        private System.Windows.Forms.Label lblRespuestaSecreta;
        private System.Windows.Forms.TextBox txtRespuestaSecreta;
        private System.Windows.Forms.GroupBox grpDatosUsuario;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Label lblApellidosCliente;
        private System.Windows.Forms.Label lblNombresCliente;
        private System.Windows.Forms.PictureBox pictureAdministrador;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.CheckBox chkAdministrador;
        private System.Windows.Forms.PictureBox pictureCliente;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.ErrorProvider epValidador;
        private System.Windows.Forms.TextBox txtConfirmarPassword;
        private System.Windows.Forms.Label lblRepetirContraseña;
        private System.Windows.Forms.TextBox txtNacionalidad;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtCalleNro;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.ComboBox cmbPais;

    }
}