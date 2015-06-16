using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.BusinessRules;
using PagoElectronico.Exceptions;

namespace PagoElectronico.UI.ABM_Cliente
{
    public partial class FrmModificarCliente : Form
    {
        #region Metodos privados

        private void CargarCombos() 
        {
            this.CargarComboPaises();
            this.CargarComboPreguntasSecretas();
            this.CargarComboTipoDocumento();
            this.CargarRoles();
        }

        private void CargarRoles()
        {
            CommonBusinessRule oCommonBR = new CommonBusinessRule();

            try
            {
                //Limpio el combo
                chkRoles.Items.Clear();

                //Busco los paises en la base
                DataTable dtRoles = oCommonBR.BuscarRoles();

                if (dtRoles.Rows.Count > 0)
                {
                    chkRoles.DataSource = dtRoles.DefaultView;
                    chkRoles.ValueMember = "Rol_ID";
                    chkRoles.DisplayMember = "Rol_Nombre";
                }

            }
            catch (Exception ex)
            {
                throw new BaseDatosException();
            }

        }

        private void CargarComboPaises()
        {
            CommonBusinessRule oCommonBR = new CommonBusinessRule();

            try
            {
                //Limpio el combo
                cmbPaises.Items.Clear();

                //Busco los paises en la base
                DataTable dtPaises = oCommonBR.BuscarPaises();

                if (dtPaises.Rows.Count > 0)
                {
                    cmbPaises.DataSource = dtPaises.DefaultView;
                    cmbPaises.ValueMember = "Pais_ID";
                    cmbPaises.DisplayMember = "Pais_Desc";
                }

            }
            catch (Exception ex)
            {
                throw new BaseDatosException();
            }



        }

        private void CargarComboTipoDocumento()
        {
            CommonBusinessRule oCommonBR = new CommonBusinessRule();

            try
            {
                //Limpio el combo
                cmbTipoDoc.Items.Clear();

                //Busco los paises en la base
                DataTable dtTipoDocumentos = oCommonBR.BuscarTiposDocumentos();

                if (dtTipoDocumentos.Rows.Count > 0)
                {
                    cmbTipoDoc.DataSource = dtTipoDocumentos.DefaultView;
                    cmbTipoDoc.ValueMember = "Tipo_Documento_ID";
                    cmbTipoDoc.DisplayMember = "Tipo_Documento_Desc";
                }

            }
            catch (Exception ex)
            {
                throw new BaseDatosException();
            }

        }

        private void CargarComboPreguntasSecretas()
        {
          
        }

        #endregion

        #region Constructor

        public FrmModificarCliente()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void FrmAltaCliente_Load(object sender, EventArgs e)
        {
                   
            this.CargarCombos();
        }
        #endregion

        private void btnAlta_Click(object sender, EventArgs e)
        {

        }

    }
}
