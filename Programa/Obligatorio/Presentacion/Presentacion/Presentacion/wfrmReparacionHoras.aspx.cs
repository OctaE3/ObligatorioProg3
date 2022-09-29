using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmReparacionHoras : System.Web.UI.Page
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
                this.ListarMecanico();
                this.ListarReparaciones();
                this.ListarReparacionHoras();
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

        private void ListarReparacionHoras()
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstReparacionHoras.DataSource = null;
            this.lstReparacionHoras.DataSource = controladoraWeb.listarReparacionHoras();
            this.lstReparacionHoras.DataBind();
        }

        private void ListarMecanico()
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.ddlMecanico.DataSource = null;
            this.ddlMecanico.DataSource = controladoraWeb.listaMecanico();
            this.ddlMecanico.DataBind();
        }

        private bool FaltanDatos()
        {
            if (this.txtRepCod.Text == "" || this.txtRepAnio.Text == "" || this.ddlMecanico.Text == "" || this.txtHoras.Text == "" || this.txtCosto.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool FaltanRepCod()
        {
            if (this.txtRepCod.Text == "" || this.txtRepAnio.Text == "" )
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
            this.ddlMecanico.Text = null;
            this.txtHoras.Text = null;
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
            if (this.lstReparacionHoras.SelectedIndex > -1)
            {
                string linea = this.lstReparacionHoras.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int RepCod = int.Parse(partes[0]);
                int RepAnio = int.Parse(partes[2]);

                DominioClases.Reparacion_Horas reparacion_Horas = unaControladoraWeb.buscarReparacionHoras(RepCod, RepAnio);
                DominioClases.Mecanico mecanico = unaControladoraWeb.buscarMecanico(reparacion_Horas.Mecanico);

                this.txtRepCod.Text = Convert.ToString(reparacion_Horas.RepCod);
                this.txtRepAnio.Text = Convert.ToString(reparacion_Horas.RepAnio);
                this.ddlMecanico.Text = Convert.ToString(mecanico);
                this.txtHoras.Text = Convert.ToString(reparacion_Horas.Horas);
                this.txtCosto.Text = Convert.ToString(reparacion_Horas.CostoHora);
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                int repCod = int.Parse(this.txtRepCod.Text);
                int repAnio = int.Parse(this.txtRepAnio.Text);

                string linea = this.ddlMecanico.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int mecCod = int.Parse(partes[0]);

                int horas = int.Parse(this.txtHoras.Text);
                int costoHora = int.Parse(this.txtCosto.Text);

                ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
                DominioClases.Reparacion_Horas reparacion_Horas = new DominioClases.Reparacion_Horas(repCod, repAnio, mecCod, horas, costoHora);
                if (controladoraWeb.altaReparacionHoras(reparacion_Horas))
                {
                    this.Limpiar();
                    this.ListarReparacionHoras();
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
            if (!FaltanRepCod())
            {
                int rcod = int.Parse(this.txtRepCod.Text);
                int ranio = int.Parse(this.txtRepAnio.Text);

                ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();

                if (controladoraWeb.bajaReparacionHoras(rcod, ranio))
                {
                    this.visibilidad2.Visible = true;
                    this.visibilidad1.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                    this.Limpiar();
                    this.ListarReparacionHoras();
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

                string linea = this.ddlMecanico.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int mecCod = int.Parse(partes[0]);

                int horas = int.Parse(this.txtHoras.Text);
                int costoHora = int.Parse(this.txtCosto.Text);

                ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
                DominioClases.Reparacion_Horas reparacion_Horas = new DominioClases.Reparacion_Horas(repCod, repAnio, mecCod, horas, costoHora);
                if (controladoraWeb.modificarReparacionHoras(reparacion_Horas))
                {
                    this.Limpiar();
                    this.ListarReparacionHoras();
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