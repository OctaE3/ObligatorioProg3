using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{

    public partial class wfrmReparacionCompleta : System.Web.UI.Page
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
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
                this.ListarReparacionesCompletas();
                this.ListarReparacionesPendiente();
                this.ListarMecanico();
                this.ListarVehiculo();
            }
        }

        private void Limpiar()
        {
            this.ddlMecanico.Text = null;
            this.ddlVehiculo.Text = null;
            this.txtFchEntrada.Text = null;
            this.txtFchSalida.Text = null;
            this.txtKmsEntrada.Text = null;
            this.txtRepDscEntrada.Text = null;
            this.txtRepDscSalida.Text = null;
        }

        private bool ReparacionesAsignadas()
        {
            int id = int.Parse(this.txtRepCod.Text);
            int anio = int.Parse(this.txtRepAnio.Text);
            DominioClases.Reparacion unaReparacion = unaControladoraWeb.buscarReparacion(id, anio);
            foreach (DominioClases.Reparacion_Repuestos unaRep in unaControladoraWeb.listarReparacionRepuestos())
            {
                if (unaReparacion.RepCod == unaRep.RepCod && unaReparacion.RepAnio == unaRep.RepAnio)
                {
                    return true;
                }
            }
            foreach (DominioClases.Reparacion_Horas unaRepH in unaControladoraWeb.listarReparacionHoras())
            {
                if (unaReparacion.RepCod == unaRepH.RepCod && unaReparacion.RepAnio == unaRepH.RepAnio)
                {
                    return true;
                }
            }
            return false;
        }
        private bool FaltanDatos()
        {
            if (this.ddlMecanico.Text == "" || this.ddlVehiculo.Text == "" || this.txtFchEntrada.Text == "" || this.txtFchSalida.Text == "" || this.txtKmsEntrada.Text == "" || this.txtRepDscEntrada.Text == "" || this.txtRepDscSalida.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ListarVehiculo()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.ddlVehiculo.DataSource = null;
            this.ddlVehiculo.DataSource = unaControladoraWeb.listaVehiculo();
            this.ddlVehiculo.DataBind();
        }

        private void ListarMecanico()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.ddlMecanico.DataSource = null;
            this.ddlMecanico.DataSource = unaControladoraWeb.listarMecanicoActivo();
            this.ddlMecanico.DataBind();
        }

        private void ListarReparacionesPendiente()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstReparacionPendiente.DataSource = null;
            this.lstReparacionPendiente.DataSource = unaControladoraWeb.listarReparacionPendiente();
            this.lstReparacionPendiente.DataBind();
        }

        private void ListarReparacionesCompletas()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstReparacionCompleta.DataSource = null;
            this.lstReparacionCompleta.DataSource = unaControladoraWeb.listarReparacionCompleta();
            this.lstReparacionCompleta.DataBind();
        }

        protected void lstReparacionPendiente_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstReparacionPendiente.SelectedIndex > -1)
            {
                string linea = this.lstReparacionPendiente.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = int.Parse(partes[0]);
                int anio = int.Parse(partes[2]);

                DominioClases.Reparacion reparacion = unaControladoraWeb.buscarReparacion(id, anio);
                DominioClases.Mecanico mecanico = unaControladoraWeb.buscarMecanico(reparacion.MecCod);
                DominioClases.Vehiculo vehiculo = unaControladoraWeb.buscarVehiculo(reparacion.VehiculoCod);

                this.txtRepCod.Text = Convert.ToString(reparacion.RepCod);
                this.txtRepAnio.Text = Convert.ToString(reparacion.RepAnio);
                this.ddlMecanico.Text = Convert.ToString(mecanico);
                this.ddlVehiculo.Text = Convert.ToString(vehiculo);
                this.txtFchEntrada.Text = reparacion.FchEntrada.ToString("yyyy-MM-dd");
                this.txtRepDscEntrada.Text = Convert.ToString(reparacion.RepDscEntrada);
                this.txtKmsEntrada.Text = Convert.ToString(reparacion.KmsEntrada);
            }
        }

        protected void lstReparacionCompleta_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstReparacionCompleta.SelectedIndex > -1)
            {
                string linea = this.lstReparacionCompleta.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = int.Parse(partes[0]);
                int anio = int.Parse(partes[2]);

                DominioClases.Reparacion reparacion = unaControladoraWeb.buscarReparacion(id, anio);
                DominioClases.Mecanico mecanico = unaControladoraWeb.buscarMecanico(reparacion.MecCod);
                DominioClases.Vehiculo vehiculo = unaControladoraWeb.buscarVehiculo(reparacion.VehiculoCod);

                this.txtRepCod.Text = Convert.ToString(reparacion.RepCod);
                this.txtRepAnio.Text = Convert.ToString(reparacion.RepAnio);
                this.ddlMecanico.Text = Convert.ToString(mecanico);
                this.ddlVehiculo.Text = Convert.ToString(vehiculo);
                this.txtFchEntrada.Text = reparacion.FchEntrada.ToString("yyyy-MM-dd");
                this.txtFchSalida.Text = reparacion.FchSalida.ToString("yyyy-MM-dd");
                this.txtRepDscEntrada.Text = Convert.ToString(reparacion.RepDscEntrada);
                this.txtRepDscSalida.Text = Convert.ToString(reparacion.RepDscSalida);
                this.txtKmsEntrada.Text = Convert.ToString(reparacion.KmsEntrada);
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!FaltanDatos())
            {
                int rc = 0;
                int ra = 0;

                string linea = this.ddlMecanico.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int mec = int.Parse(partes[0]);

                string linea2 = this.ddlVehiculo.SelectedItem.ToString();
                string[] partes2 = linea2.Split(' ');
                int vhi = int.Parse(partes2[0]);

                DateTime fch = Convert.ToDateTime(this.txtFchEntrada.Text);
                DateTime fch2 = Convert.ToDateTime(this.txtFchSalida.Text);
                string desc = this.txtRepDscEntrada.Text;
                string desc2 = this.txtRepDscSalida.Text;
                int kms = int.Parse(this.txtKmsEntrada.Text);

                DominioClases.Reparacion reparacion = new DominioClases.Reparacion(rc, ra, mec, vhi, fch, fch2, desc, desc2, kms);
                if (unaControladoraWeb.altaReparacion(reparacion))
                {
                    this.visibilidad3.Visible = false;
                    this.visibilidad2.Visible = true;
                    this.visibilidad1.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                    this.Limpiar();
                    this.ListarReparacionesPendiente();
                    this.ListarReparacionesCompletas();
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
                if (!ReparacionesAsignadas())
                {
                    int rcod = int.Parse(this.txtRepCod.Text);
                    int ranio = int.Parse(this.txtRepAnio.Text);

                    if (unaControladoraWeb.bajaReparacion(rcod, ranio))
                    {
                        this.visibilidad3.Visible = false;
                        this.visibilidad2.Visible = true;
                        this.visibilidad1.Visible = false;
                        ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                        this.Limpiar();
                        this.ListarReparacionesPendiente();
                        this.ListarReparacionesCompletas();
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
                int rc = int.Parse(this.txtRepCod.Text);
                int ra = int.Parse(this.txtRepAnio.Text);

                string linea = this.ddlMecanico.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int mec = int.Parse(partes[0]);

                string linea2 = this.ddlVehiculo.SelectedItem.ToString();
                string[] partes2 = linea2.Split(' ');
                int vhi = int.Parse(partes2[0]);

                DateTime fch = Convert.ToDateTime(this.txtFchEntrada.Text);
                DateTime fch2 = Convert.ToDateTime(this.txtFchSalida.Text);
                string desc = this.txtRepDscEntrada.Text;
                string desc2 = this.txtRepDscSalida.Text;
                int kms = int.Parse(this.txtKmsEntrada.Text);
                DominioClases.Reparacion reparacion = new DominioClases.Reparacion(rc, ra, mec, vhi, fch, fch2, desc, desc2, kms);
                if (unaControladoraWeb.modificarReparacion(reparacion))
                {
                    this.visibilidad3.Visible = false;
                    this.visibilidad2.Visible = true;
                    this.visibilidad1.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                    this.Limpiar();
                    this.ListarReparacionesPendiente();
                    this.ListarReparacionesCompletas();
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