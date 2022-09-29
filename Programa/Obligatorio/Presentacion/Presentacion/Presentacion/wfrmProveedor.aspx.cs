using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmProveedor : System.Web.UI.Page
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
                this.Listar();
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            }
        }

        private void Listar()
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstProveedor.DataSource = null;
            this.lstProveedor.DataSource = controladoraWeb.listarProveedor();
            this.lstProveedor.DataBind();
        }

        private void Limpiar()
        {
            this.txtProveedorCod.Text = null;
            this.txtProveedorNom.Text = null;
            this.txtProveedorRut.Text = null;
        }

        private bool ProveedorAsignados()
        {
            int id = int.Parse(this.txtProveedorCod.Text);
            DominioClases.Proveedor unProveedor = unaControladoraWeb.buscarProveedor(id);
            foreach (DominioClases.Repuesto unRep in unaControladoraWeb.listaRepuesto())
            {
                if (unProveedor.ProveedorCod == unRep.ProveedorCod)
                {
                    return true;
                }
            }
            return false;
        }

        private bool FaltanDatos()
        {
            if (this.txtProveedorNom.Text == "" || this.txtProveedorNom.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void lstProveedor_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (lstProveedor.SelectedIndex > -1)
            {
                string linea = this.lstProveedor.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int ProvCod = int.Parse(partes[0]);

                DominioClases.Proveedor proveedor = controladoraWeb.buscarProveedor(ProvCod);

                this.txtProveedorCod.Text = Convert.ToString(proveedor.ProveedorCod);
                this.txtProveedorNom.Text = Convert.ToString(proveedor.ProveedorNom);
                this.txtProveedorRut.Text = Convert.ToString(proveedor.ProveedorRut);
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!FaltanDatos())
            {
                int provCod = 0;
                string provNom = this.txtProveedorNom.Text;
                string provRut = this.txtProveedorRut.Text;

                DominioClases.Proveedor proveedor = new DominioClases.Proveedor(provCod, provNom, provRut);
                if (controladoraWeb.altaProveedor(proveedor))
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
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!FaltanDatos())
            {
                if (!ProveedorAsignados())
                {
                    int provCod = int.Parse(this.txtProveedorCod.Text);
                    if (controladoraWeb.bajaProveedor(provCod))
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
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!FaltanDatos())
            {
                int provCod = int.Parse(this.txtProveedorCod.Text);
                string provNom = this.txtProveedorNom.Text;
                string provRut = this.txtProveedorRut.Text;

                DominioClases.Proveedor proveedor = new DominioClases.Proveedor(provCod, provNom, provRut);
                if (controladoraWeb.modificarProveedor(proveedor))
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