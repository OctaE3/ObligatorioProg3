using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["IdUsuario"] == null)
            {
                Response.Redirect("~/Presentacion/wfrmLoginUsuario");
            }

            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
                this.listarVehiculos();
            }
        }

        private List<DominioClases.Vehiculo> clienteVehiculos()
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            int id = int.Parse(Request.Cookies["IdUsuario"].Value);
            List<DominioClases.Vehiculo> vehiculosDeCliente = new List<DominioClases.Vehiculo>();
            foreach (DominioClases.Cliente_Vehiculo unClienteVehiculo in controladoraWeb.listaClienteVehiculo())
            {
                foreach (DominioClases.Vehiculo unVehiculo in controladoraWeb.listaVehiculo())
                {
                    if (unClienteVehiculo.CliCod == id && unClienteVehiculo.VehiculoCod == unVehiculo.VehiculoCod)
                    {
                        vehiculosDeCliente.Add(unVehiculo);
                    }
                }
            }
            return vehiculosDeCliente;
        }
        private void listarVehiculos()
        {
            this.ddlVehiculo.DataSource = null;
            this.ddlVehiculo.DataSource = this.clienteVehiculos();
            this.ddlVehiculo.DataBind();
        }

        private bool FaltanDatos()
        {
            if (this.txtReservaFch.Text == "" || this.txtReservaDsc.Text == "" || this.ddlVehiculo.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnAgendar_Click(object sender, EventArgs e)   
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!this.FaltanDatos())
            {
                int rcod = 0;
                DateTime rfecha = DateTime.Parse(this.txtReservaFch.Text);
                string rdesc = this.txtReservaDsc.Text;
                int cli = int.Parse(Request.Cookies["IdUsuario"].Value);

                string linea = this.ddlVehiculo.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int vhi = int.Parse(partes[0]);
                DominioClases.Reserva reserva = new DominioClases.Reserva(rcod, rfecha, rdesc, cli, vhi);
                if (controladoraWeb.altaReserva(reserva))
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