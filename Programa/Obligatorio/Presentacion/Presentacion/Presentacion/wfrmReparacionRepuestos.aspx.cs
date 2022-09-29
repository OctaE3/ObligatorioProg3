using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmReparacionRepuestos : System.Web.UI.Page
    {
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
                this.ListarReparaciones();
                this.ListarReparacionRepuestos();
                this.ListarRepuestos();
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            }
        }

        private void ListarReparaciones()
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstReparacion.DataSource = null;
            this.lstReparacion.DataSource = controladoraWeb.listarReparacionCompleta();
            this.lstReparacion.DataBind();
        }

        private void ListarReparacionRepuestos()
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstReparacionRepuesto.DataSource = null;
            this.lstReparacionRepuesto.DataSource = controladoraWeb.listarReparacionRepuestos();
            this.lstReparacionRepuesto.DataBind();
        }

        private void ListarRepuestos()
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.ddlRepuesto.DataSource = null;
            this.ddlRepuesto.DataSource = controladoraWeb.listaRepuesto();
            this.ddlRepuesto.DataBind();
        }

        private bool FaltanDatos()
        {
            if (this.txtRepCod.Text == "" || this.txtRepAnio.Text == "" || this.ddlRepuesto.Text == "" || this.txtCantidad.Text == "" || this.txtCosto.Text == "")
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
            this.txtRepCod.Text = null;
            this.txtRepAnio.Text = null;
            this.ddlRepuesto.Text = null;
            this.txtCantidad.Text = null;
            this.txtCosto.Text = null;
        }

        protected void lstReparacion_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstReparacion.SelectedIndex > -1)
            {
                string linea = this.lstReparacion.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int RepCod = int.Parse(partes[0]);
                int RepAnio = int.Parse(partes[2]);
                
                DominioClases.Reparacion reparacion = unaControladoraWeb.buscarReparacion(RepCod, RepAnio);

                this.txtRepCod.Text = Convert.ToString(reparacion.RepCod);
                this.txtRepAnio.Text = Convert.ToString(reparacion.RepAnio);
            }
        }

        protected void lstReparacionRepuesto_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstReparacionRepuesto.SelectedIndex > -1)
            {
                string linea = this.lstReparacionRepuesto.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int RepCod = int.Parse(partes[0]);
                int RepAnio = int.Parse(partes[2]);

                DominioClases.Reparacion_Repuestos reparacion_Repuestos = unaControladoraWeb.buscarReparacionRepuestos(RepCod, RepAnio);
                DominioClases.Repuesto repuesto = unaControladoraWeb.buscarRepuesto(reparacion_Repuestos.RepuestoCod);

                this.txtRepCod.Text = Convert.ToString(reparacion_Repuestos.RepCod);
                this.txtRepAnio.Text = Convert.ToString(reparacion_Repuestos.RepAnio);
                this.ddlRepuesto.Text = Convert.ToString(repuesto);
                this.txtCantidad.Text = Convert.ToString(reparacion_Repuestos.Cantidad);
                this.txtCosto.Text = Convert.ToString(reparacion_Repuestos.CostoUnitario);
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                int repCod = int.Parse(this.txtRepCod.Text);
                int repAnio = int.Parse(this.txtRepAnio.Text);

                string linea = this.ddlRepuesto.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                string repuestoCod = partes[0];

                int cantidad = int.Parse(this.txtCantidad.Text);
                int costoUnitario = int.Parse(this.txtCosto.Text);

                ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
                DominioClases.Reparacion_Repuestos reparacion_Repuestos = new DominioClases.Reparacion_Repuestos(repCod, repAnio, repuestoCod, cantidad, costoUnitario);
                if (controladoraWeb.altaReparacionRepuestos(reparacion_Repuestos))
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

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                int rcod = int.Parse(this.txtRepCod.Text);
                int ranio = int.Parse(this.txtRepAnio.Text);

                ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();

                if (controladoraWeb.bajaReparacionRepuestos(rcod, ranio))
                {
                    this.visibilidad2.Visible = true;
                    this.visibilidad1.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                    this.Limpiar();
                    this.ListarReparacionRepuestos();
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                int repCod = int.Parse(this.txtRepCod.Text);
                int repAnio = int.Parse(this.txtRepAnio.Text);

                string linea = this.ddlRepuesto.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                string repuestoCod = partes[0];

                int cantidad = int.Parse(this.txtCantidad.Text);
                int costoUnitario = int.Parse(this.txtCosto.Text);

                ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
                DominioClases.Reparacion_Repuestos reparacion_Repuestos = new DominioClases.Reparacion_Repuestos(repCod, repAnio, repuestoCod, cantidad, costoUnitario);
                if (controladoraWeb.modificarReparacionRepuestos(reparacion_Repuestos))
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