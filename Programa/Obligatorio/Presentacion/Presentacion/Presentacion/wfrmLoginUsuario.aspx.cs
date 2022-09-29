using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmLoginUsuario : System.Web.UI.Page
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
            if (this.txtCi.Text == "" || this.txtPass.Text == "")
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
            if (!this.FaltanDatos())
            {
                ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
                string ci = this.txtCi.Text;
                string pass = this.txtPass.Text;

                DominioClases.Cliente cliente = controladoraWeb.buscarUsuarioLogueado(ci, pass);

                if (cliente != null)
                {
                    int id = cliente.CliId;
                    string admin = cliente.Admin;
                    HttpCookie cookieU = new HttpCookie("IdUsuario", id.ToString());
                    HttpCookie cookieA = new HttpCookie("Admin", admin.ToString());
                    this.Response.Cookies.Add(cookieU);
                    this.Response.Cookies.Add(cookieA);
                    Response.Redirect("wfrmInicio.aspx");
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