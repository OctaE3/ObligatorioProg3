using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmUsuario : System.Web.UI.Page
    {
        ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
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

            if (!IsPostBack)
            {
                Listar();
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            }
        }

        private void Listar()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstUsuarios.DataSource = null;
            this.lstUsuarios.DataSource = unaControladoraWeb.listaNoAdmin();
            this.lstUsuarios.DataBind();
        }

        private bool UsuariosAsignados()
        {
            int id = int.Parse(this.txtUsuarioCod.Text);
            DominioClases.Cliente unCliente = unaControladoraWeb.buscarCliente(id);
            foreach (DominioClases.Cliente_Vehiculo unCV in unaControladoraWeb.listaClienteVehiculo())
            {
                if (unCliente.CliId == unCV.CliCod)
                {
                    return true;
                }
            }
            return false;
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

        private void Limpiar()
        {
            this.txtUsuarioCod.Text = null;
            this.txtNombre.Text = null;
            this.txtCi.Text = null;
            this.txtTelefono.Text = null;
            this.txtDireccion.Text = null;
            this.txtMail.Text = null;
            this.txtPass.Text = null;
        }

        protected void lstUsuarios_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstUsuarios.SelectedIndex > -1)
            {
                string linea = this.lstUsuarios.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int Id = int.Parse(partes[0]);

                ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
                DominioClases.Cliente Usuario = unaControladoraWeb.buscarCliente(Id);
                this.txtUsuarioCod.Text = Convert.ToString(Usuario.CliId);
                this.txtNombre.Text = Convert.ToString(Usuario.CliNom);
                this.txtCi.Text = Convert.ToString(Usuario.CliCi);
                this.txtTelefono.Text = Convert.ToString(Usuario.CliTel);
                this.txtDireccion.Text = Convert.ToString(Usuario.CliDir);
                this.txtMail.Text = Convert.ToString(Usuario.CliMail);
                this.txtFecha.Text = Usuario.FchRegistro.ToString("yyyy-MM-dd");
                this.txtPass.Attributes.Add("value", Usuario.CliPass);
                this.txtAdmin.Text = Convert.ToString(Usuario.Admin);
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!FaltanDatos())
            {
                int id = 0;
                string nom = this.txtNombre.Text;
                string ci = this.txtCi.Text;
                string tel = this.txtTelefono.Text;
                string dir = this.txtDireccion.Text;
                string mail = this.txtMail.Text;
                string pass = this.txtPass.Text;
                DateTime fecha = DateTime.Now;
                string admin = "No";

                DominioClases.Cliente usuario = new DominioClases.Cliente(id, nom, ci, tel, dir, mail, fecha, pass, admin);
                if (unaControladoraWeb.altaCliente(usuario))
                {
                    this.visibilidad3.Visible = false;
                    this.visibilidad2.Visible = true;
                    this.visibilidad1.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                    this.Limpiar();
                    this.Listar();
                }
                else
                {
                    this.visibilidad3.Visible = false;
                    this.visibilidad2.Visible = false;
                    this.visibilidad1.Visible = true;
                    ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
                }
            }
            else
            {
                this.visibilidad3.Visible = false;
                this.visibilidad2.Visible = false;
                this.visibilidad1.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();

            if (!FaltanDatos())
            {
                if (!UsuariosAsignados())
                {
                    int id = int.Parse(this.txtUsuarioCod.Text);

                    if (unaControladoraWeb.bajaCliente(id))
                    {
                        this.visibilidad3.Visible = false;
                        this.visibilidad2.Visible = true;
                        this.visibilidad1.Visible = false;
                        ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.visibilidad3.Visible = false;
                        this.visibilidad2.Visible = false;
                        this.visibilidad1.Visible = true;
                        ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
                    }
                }
                else 
                {
                    this.visibilidad2.Visible = false;
                    this.visibilidad1.Visible = false;
                    this.visibilidad3.Visible = true;
                    ClientScript.RegisterStartupScript(GetType(), "Otra Mensaje", "MensajeOtra();", true);
                }
                
                }
            else
            {
                this.visibilidad3.Visible = false;
                this.visibilidad2.Visible = false;
                this.visibilidad1.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();

            if (!FaltanDatos())
            {
                int id = int.Parse(this.txtUsuarioCod.Text);
                string nom = this.txtNombre.Text;
                string ci = this.txtCi.Text;
                string tel = this.txtTelefono.Text;
                string dir = this.txtDireccion.Text;
                string mail = this.txtMail.Text;
                string pass = this.txtPass.Text;
                DateTime fecha = DateTime.Parse(this.txtFecha.Text);
                string admin = this.txtAdmin.Text;

                DominioClases.Cliente usuario = new DominioClases.Cliente(id, nom, ci, tel, dir, mail, fecha, pass, admin);
                if (unaControladoraWeb.modificarCliente(usuario))
                {
                    this.visibilidad3.Visible = false;
                    this.visibilidad2.Visible = true;
                    this.visibilidad1.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                    this.Limpiar();
                    this.Listar();
                }
                else
                {
                    this.visibilidad3.Visible = false;
                    this.visibilidad2.Visible = false;
                    this.visibilidad1.Visible = true;
                    ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
                }
            }
            else
            {
                this.visibilidad3.Visible = false;
                this.visibilidad2.Visible = false;
                this.visibilidad1.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }
    }
}