using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.BusinessEntities;

namespace PagoElectronico.UI.Login
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Rol rolCliente = Sesion.GetRolCliente();
            int offsetX = 50;
            int offsetY = 50;

            for (int i = 0; i < rolCliente.Funcionalidades.Count; i++)
            {
                GenerarBoton(i, rolCliente.Funcionalidades[i], rolCliente.Funcionalidades.Count, ref offsetX, ref offsetY);
            }
        }

        private void GenerarBoton(int i, Funcionalidad oFuncionalidad, int length, ref int offsetX, ref int offsetY)
        {
            if (i < (length +1)/ 2)
            {
                Button btnFuncionalidad = new Button();
                btnFuncionalidad.Image = new Bitmap("../../Recursos/" + "ABM de Cuenta" + ".png");

                // btnFuncionalidad.Image = ((System.Drawing.Image)(resources.GetObject("btnABMCuenta.Image")));
                btnFuncionalidad.Location = new System.Drawing.Point(offsetX, offsetY);
                btnFuncionalidad.Name = oFuncionalidad.Descripcion.Replace(" ", "");
                btnFuncionalidad.Size = new System.Drawing.Size(150, 150);
                btnFuncionalidad.TabIndex = 0;
                btnFuncionalidad.UseVisualStyleBackColor = true;
                this.Controls.Add(btnFuncionalidad);

                offsetX = offsetX + 150 + 33;
            }

            if (i > (length+1) / 2)
            {
                offsetY = offsetY + 150 + 33;
                offsetX = 50;

                Button btnFuncionalidad = new Button();
                btnFuncionalidad.Image = new Bitmap("../../Recursos/" + "ABM de Cuenta" + ".png");

                // btnFuncionalidad.Image = ((System.Drawing.Image)(resources.GetObject("btnABMCuenta.Image")));
                btnFuncionalidad.Location = new System.Drawing.Point(offsetX, offsetY);
                btnFuncionalidad.Name = oFuncionalidad.Descripcion.Replace(" ", "");
                btnFuncionalidad.Size = new System.Drawing.Size(150, 150);
                btnFuncionalidad.TabIndex = 0;
                btnFuncionalidad.UseVisualStyleBackColor = true;
                this.Controls.Add(btnFuncionalidad);

                offsetX = offsetX + 150 + 33;
            }

        }
    }
}
