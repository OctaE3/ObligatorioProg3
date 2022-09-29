using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmZonaAdmin : System.Web.UI.Page
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

            if (!IsPostBack) {
                this.ListarRepuestosVendidos();
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            }
        }

        private void ListarReparacionesCompletas(DateTime pFchIn,DateTime pFchEnd)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstReparacionFinales.DataSource = null;
            this.lstReparacionFinales.DataSource = unaControladoraWeb.ListadoReparacionesFinales(pFchIn, pFchEnd);
            this.lstReparacionFinales.DataBind();
        }
        private void ListarReparacionesPendientes(DateTime pFchIn)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstReparacionesPendientes.DataSource = null;
            this.lstReparacionesPendientes.DataSource = unaControladoraWeb.ListadoReparacionesPendientes(pFchIn);
            this.lstReparacionesPendientes.DataBind();
        }

        private void ListarRepuestosVendidos()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstRepuestosVendidos.DataSource = null;
            this.lstRepuestosVendidos.DataSource = unaControladoraWeb.ListadoRepuestoVendido();
            this.lstRepuestosVendidos.DataBind();
        }

        protected void btnBuscarRF_Click(object sender, EventArgs e)
        {
            DateTime fchin ;
            DateTime fchend ;
            if (this.txtFchEntrada.Text == "")
            {
                fchin = Convert.ToDateTime("1/1/1753");
                this.visibilidad2.Visible = true;
                this.visibilidad1.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
            }
            else 
            {
                fchin = Convert.ToDateTime(this.txtFchEntrada.Text);
                this.visibilidad2.Visible = true;
                this.visibilidad1.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
            }
            if (this.txtFchSalida.Text == "")
            {
                fchend = DateTime.Now;
                this.visibilidad2.Visible = true;
                this.visibilidad1.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
            }
            else
            {
                fchend = Convert.ToDateTime(this.txtFchSalida.Text);
                this.visibilidad2.Visible = true;
                this.visibilidad1.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
            }

            this.ListarReparacionesCompletas(fchin, fchend);

            if (this.lstReparacionFinales.Items.Count <= 0)
            {
                this.visibilidad2.Visible = false;
                this.visibilidad1.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }

        protected void BuscarPN_Click(object sender, EventArgs e)
        {
            DateTime fchin;
            if (this.txtFchPen.Text == "")
            {
                fchin = Convert.ToDateTime("1/1/1753");
                this.visibilidad2.Visible = true;
                this.visibilidad1.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
            }
            else
            {
                fchin = Convert.ToDateTime(this.txtFchPen.Text);
                this.visibilidad2.Visible = true;
                this.visibilidad1.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
            }

            this.ListarReparacionesPendientes(fchin);

            if (this.lstReparacionesPendientes.Items.Count <= 0)
            {
                this.visibilidad2.Visible = false;
                this.visibilidad1.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }
    }
}