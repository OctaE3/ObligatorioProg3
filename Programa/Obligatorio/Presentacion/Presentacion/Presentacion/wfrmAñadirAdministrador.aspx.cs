using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmAñadirAdministrador : System.Web.UI.Page
    {
        ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
        int AdminId = 4;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Admin"] == null)
            {
                Response.Redirect("~/Presentacion/wfrmInicio");
            }
            else
            {
                if (Request.Cookies["Admin"].Value == "No")
                {
                    Response.Redirect("~/Presentacion/wfrmInicio");
                }
            }

            if (!this.IsPostBack)
            {
                ListarUsuarios();
                ListarAdministradores();
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            }
        }

        private void ListarUsuarios()
        {
            this.lstUsuario.DataSource = null;
            this.lstUsuario.DataSource = unaControladoraWeb.listaNoAdmin();
            this.lstUsuario.DataBind();
        }

        private void ListarAdministradores()
        {
            this.lstAdministrador.DataSource = null;
            this.lstAdministrador.DataSource = unaControladoraWeb.listaAdmin();
            this.lstAdministrador.DataBind();
        }

        private void Añadir(int pId)
        {
            DominioClases.Cliente unCliente = unaControladoraWeb.buscarCliente(pId);

            int id = pId;
            string nom = Convert.ToString(unCliente.CliNom);
            string ci = Convert.ToString(unCliente.CliCi);
            string tel = Convert.ToString(unCliente.CliTel);
            string dir = Convert.ToString(unCliente.CliDir);
            string mail = Convert.ToString(unCliente.CliMail);
            DateTime fch = unCliente.FchRegistro;
            string pass = Convert.ToString(unCliente.CliPass);
            string admin = "Si";

            DominioClases.Cliente unCliente2 = new DominioClases.Cliente(id, nom, ci, tel, dir, mail, fch, pass, admin);
            if (unaControladoraWeb.modificarCliente(unCliente2))
            {
                this.visibilidad2.Visible = true;
                this.visibilidad1.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                ListarUsuarios();
                ListarAdministradores();
            }
            else
            {
                this.visibilidad2.Visible = false;
                this.visibilidad1.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstUsuario.SelectedIndex > -1)
            {
                string linea = this.lstUsuario.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int clienteId = int.Parse(partes[0]);
                this.Añadir(clienteId);
            }
            else
            {
                this.visibilidad1.Visible = true;
                this.visibilidad2.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }

        private void Eliminar(int pId)
        {
            DominioClases.Cliente unCliente = unaControladoraWeb.buscarCliente(pId);

            int id = pId;
            string nom = Convert.ToString(unCliente.CliNom);
            string ci = Convert.ToString(unCliente.CliCi);
            string tel = Convert.ToString(unCliente.CliTel);
            string dir = Convert.ToString(unCliente.CliDir);
            string mail = Convert.ToString(unCliente.CliMail);
            DateTime fch = unCliente.FchRegistro;
            string pass = Convert.ToString(unCliente.CliPass);
            string admin = "No";
            if (this.AdminId == int.Parse(Request.Cookies["IdUsuario"].Value) && id != 4)
            {
                DominioClases.Cliente unCliente2 = new DominioClases.Cliente(id, nom, ci, tel, dir, mail, fch, pass, admin);
                if (unaControladoraWeb.modificarCliente(unCliente2))
                {
                    this.visibilidad2.Visible = true;
                    this.visibilidad1.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                    ListarUsuarios();
                    ListarAdministradores();
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
                this.visibilidad1.Visible = true;
                this.visibilidad2.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstAdministrador.SelectedIndex > -1)
            {
                string linea = this.lstAdministrador.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int clienteId = int.Parse(partes[0]);
                this.Eliminar(clienteId);
            }
            else
            {
                this.visibilidad1.Visible = true;
                this.visibilidad2.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }
    }
}