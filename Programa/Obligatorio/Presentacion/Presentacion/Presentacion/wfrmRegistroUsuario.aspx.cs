using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmRegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            }
        }

        private bool FaltanDatos()
        {
            if (this.txtNombre.Text == "" || this.txtCi.Text == "" || this.txtTelefono.Text == "" || this.txtDireccion.Text == "" || this.txtMail.Text == "" || this.txtPass.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            Response.Redirect("wfrmLoginUsuario.aspx");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!this.FaltanDatos())
            {
                int cliId = 1;
                string cliNom = this.txtNombre.Text;
                string cliCi = this.txtCi.Text;
                string cliTel = this.txtTelefono.Text;
                string cliDir = this.txtDireccion.Text;
                string cliMail = this.txtMail.Text;
                DateTime fchRegistro = DateTime.Now;
                string cliPass = this.txtPass.Text;
                string admin = "No";

                DominioClases.Cliente unCliente = new DominioClases.Cliente(cliId, cliNom, cliCi, cliTel, cliDir, cliMail, fchRegistro, cliPass, admin);
                if (unaControladoraWeb.altaCliente(unCliente))
                {
                    this.visibilidad2.Visible = true;
                    this.visibilidad1.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                }
                else
                {
                    this.visibilidad2.Visible = false;
                    this.visibilidad1.Visible = true;
                    ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
                }
            }
            else
            {
                this.visibilidad2.Visible = false;
                this.visibilidad1.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }
    }
}