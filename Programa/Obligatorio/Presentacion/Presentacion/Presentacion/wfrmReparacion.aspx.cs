using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmReparacion : System.Web.UI.Page
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
                this.ListarVehiculo();
                this.ListarMecanico();
                this.ListarReservas();
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            }
        }

        private void Listar()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstReparacion.DataSource = null;
            this.lstReparacion.DataSource = unaControladoraWeb.listarReparacionPendiente();
            this.lstReparacion.DataBind();
        }

        private void ListarVehiculo()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.ddlVehiculo.DataSource = null;
            this.ddlVehiculo.DataSource = unaControladoraWeb.listaVehiculo();
            this.ddlVehiculo.DataBind();
        }

        private void ListarReservas()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.lstReserva.DataSource = null;
            this.lstReserva.DataSource = unaControladoraWeb.listarReservas();
            this.lstReserva.DataBind();
        }

        private void ListarMecanico()
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            this.ddlMecanico.DataSource = null;
            this.ddlMecanico.DataSource = unaControladoraWeb.listarMecanicoActivo();
            this.ddlMecanico.DataBind();
        }

        private void Limpiar()
        {
            this.ddlMecanico.Text = null;
            this.ddlVehiculo.Text = null;
            this.txtFchEntrada.Text = null;
            this.txtKmsEntrada.Text = null;
            this.txtRepDscEntrada.Text = null;
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
            if (this.ddlMecanico.Text == "" || this.ddlVehiculo.Text == "" || this.txtFchEntrada.Text == "" || this.txtKmsEntrada.Text == "" || this.txtRepDscEntrada.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            int id = int.Parse(txtId.Text);
            if (unaControladoraWeb.bajaReserva(id))
            {
                this.visibilidad3.Visible = false;
                this.visibilidad2.Visible = true;
                this.visibilidad1.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);
                ListarReservas();
            }
            else
            {
                this.visibilidad3.Visible = false;
                this.visibilidad2.Visible = false;
                this.visibilidad1.Visible = true;
                ClientScript.RegisterStartupScript(GetType(), "Error Mensaje", "MensajeError();", true);
            }
        }

        protected void lstReservas_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstReserva.SelectedIndex > -1)
            {
                string linea = this.lstReserva.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = int.Parse(partes[0]);
                this.txtId.Text = Convert.ToString(id);

                DominioClases.Reserva reserva = unaControladoraWeb.buscarReserva(id);
                DominioClases.Vehiculo vehiculo = unaControladoraWeb.buscarVehiculo(reserva.VehiculoCod);

                this.txtRepDscEntrada.Text = Convert.ToString(reserva.ReservaDsc);
                this.txtFchEntrada.Text = reserva.ReservaFch.ToString("yyyy-MM-dd");
                this.ddlVehiculo.Text = Convert.ToString(vehiculo);
            }
        }

        protected void lstReparacion_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstReparacion.SelectedIndex > -1)
            {
                string linea = this.lstReparacion.SelectedItem.ToString();
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
                DateTime fch2 = Convert.ToDateTime("1/1/1753");
                string desc = this.txtRepDscEntrada.Text;
                string desc2 = "NULL";
                int kms = int.Parse(this.txtKmsEntrada.Text);

                DominioClases.Reparacion reparacion = new DominioClases.Reparacion(rc, ra, mec, vhi, fch, fch2, desc, desc2, kms);
                if (unaControladoraWeb.altaReparacion(reparacion))
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
                int rc = int.Parse(this.txtRepCod.Text);
                int ra = int.Parse(this.txtRepAnio.Text);

                string linea = this.ddlMecanico.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int mec = int.Parse(partes[0]);

                string linea2 = this.ddlVehiculo.SelectedItem.ToString();
                string[] partes2 = linea2.Split(' ');
                int vhi = int.Parse(partes2[0]);

                DateTime fch = Convert.ToDateTime(this.txtFchEntrada.Text);
                DateTime fch2 = Convert.ToDateTime("1/1/1753");
                string desc = this.txtRepDscEntrada.Text;
                string desc2 = "NULL";
                int kms = int.Parse(this.txtKmsEntrada.Text);
                DominioClases.Reparacion reparacion = new DominioClases.Reparacion(rc, ra, mec, vhi, fch, fch2, desc, desc2, kms);
                if (unaControladoraWeb.modificarReparacion(reparacion))
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