using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmRepuesto : System.Web.UI.Page
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
                ListarProveedor();
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            }
        }

        private void Listar()
        {
            this.lstRepuesto.DataSource = null;
            this.lstRepuesto.DataSource = unaControladoraWeb.listaRepuesto();
            this.lstRepuesto.DataBind();
        }

        private void ListarProveedor()
        {
            this.ddlProveedorCod.DataSource = null;
            this.ddlProveedorCod.DataSource = unaControladoraWeb.listarProveedor();
            this.ddlProveedorCod.DataBind();
        }

        private bool RepuestosAsignados()
        {
            string id = this.txtRepuestoCod.Text;
            DominioClases.Repuesto unRepuesto = unaControladoraWeb.buscarRepuesto(id);
            foreach (DominioClases.Reparacion_Repuestos unaRep in unaControladoraWeb.listarReparacionRepuestos())
            {
                if (unRepuesto.RepuestoCod == unaRep.RepuestoCod)
                {
                    return true;
                }
            }
            return false;
        }


        private bool FaltanDatos()
        {
            if (this.txtRepuestoCod.Text == "" || this.txtRepuestoDsc.Text == "" || this.txtRepuestoCosto.Text == "" || this.txtRepuestoTipo.Text == "" || this.ddlProveedorCod.Text == "")
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
            this.txtRepuestoCod.Text = null;
            this.txtRepuestoDsc.Text = null;
            this.txtRepuestoCosto.Text = null;
            this.txtRepuestoTipo.Text = null;
            this.ddlProveedorCod.Text = null;
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!this.FaltanDatos())
            {
                string repuestoCod = this.txtRepuestoCod.Text;
                string repuestoDsc = this.txtRepuestoDsc.Text;
                int repuestoCosto = int.Parse(this.txtRepuestoCosto.Text);
                string repuestoTipo = this.txtRepuestoTipo.Text;

                string linea = this.ddlProveedorCod.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int proCod = int.Parse(partes[0]);

                DominioClases.Repuesto unRepuesto = new DominioClases.Repuesto(repuestoCod, repuestoDsc, repuestoCosto, repuestoTipo, proCod);
                if (unaControladoraWeb.altaRepuesto(unRepuesto))
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
            if (!FaltanDatos())
            {
                if (!RepuestosAsignados())
                {
                    string repuestoCod = this.txtRepuestoCod.Text;
                    if (unaControladoraWeb.bajaRepuesto(repuestoCod))
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                string repuestoCod = this.txtRepuestoCod.Text;
                string repuestoDsc = this.txtRepuestoDsc.Text;
                int repuestoCosto = int.Parse(this.txtRepuestoCosto.Text);
                string repuestoTipo = this.txtRepuestoTipo.Text;

                string linea = this.ddlProveedorCod.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int proCod = int.Parse(partes[0]);

                DominioClases.Repuesto Repuesto = new DominioClases.Repuesto(repuestoCod, repuestoDsc, repuestoCosto, repuestoTipo, proCod);
                if (unaControladoraWeb.modificarRepuesto(Repuesto))
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

        protected void lstRepuesto_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstRepuesto.SelectedIndex > -1)
            {
                string linea = this.lstRepuesto.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                string repuestoCod = partes[0];

                DominioClases.Repuesto unRepuesto = unaControladoraWeb.buscarRepuesto(repuestoCod);
                DominioClases.Proveedor unProveedor = unaControladoraWeb.buscarProveedor(unRepuesto.ProveedorCod);

                this.txtRepuestoCod.Text = Convert.ToString(unRepuesto.RepuestoCod);
                this.txtRepuestoDsc.Text = Convert.ToString(unRepuesto.RepuestoDsc);
                this.txtRepuestoCosto.Text = Convert.ToString(unRepuesto.RepuestoCosto);
                this.txtRepuestoTipo.Text = unRepuesto.RepuestoTipo;
                this.ddlProveedorCod.Text = Convert.ToString(unProveedor);

            }
        }
    }
}