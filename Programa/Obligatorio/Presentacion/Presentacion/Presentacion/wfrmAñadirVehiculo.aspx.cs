using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmAgendarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["IdUsuario"] == null)
            {
                Response.Redirect("~/Presentacion/wfrmLoginUsuario");
            }

            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
                listarVehiculos();
            }
        }

        private bool FaltanDatos()
        {
            if (this.txtMatricula.Text == "" || this.txtMarca.Text == "" || this.txtModelo.Text == "" || this.txtAnio.Text == "" || this.txtColor.Text == "")
            {
                return true;
            }
            else
            {
                return false;
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
            this.lstVehiculos.DataSource = null;
            this.lstVehiculos.DataSource = this.clienteVehiculos();
            this.lstVehiculos.DataBind();
        }

        protected void lstVehiculo_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstVehiculos.SelectedIndex > -1)
            {
                string linea = this.lstVehiculos.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int Id = int.Parse(partes[0]);

                DominioClases.Vehiculo unVehiculo = controladoraWeb.buscarVehiculo(Id);
                this.txtVehiculoCod.Text = Convert.ToString(unVehiculo.VehiculoCod);
                this.txtMatricula.Text = Convert.ToString(unVehiculo.Matricula);
                this.txtMarca.Text = Convert.ToString(unVehiculo.Marca);
                this.txtModelo.Text = Convert.ToString(unVehiculo.Modelo);
                this.txtAnio.Text = Convert.ToString(unVehiculo.Anio);
                this.txtColor.Text = Convert.ToString(unVehiculo.Color);
            }
        }

        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb controladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!FaltanDatos())
            {
                int id = 0;
                string matricula = this.txtMatricula.Text;
                string marca = this.txtMarca.Text;
                string modelo = this.txtModelo.Text;
                int anio = int.Parse(this.txtAnio.Text);
                string color = this.txtColor.Text;

                DominioClases.Vehiculo vehiculo = new DominioClases.Vehiculo(id, matricula, marca, modelo, anio, color);
                if (controladoraWeb.altaVehiculo(vehiculo))
                {
                    this.visibilidad2.Visible = true;
                    this.visibilidad1.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "Exito Mensaje", "MensajeExito();", true);

                    DominioClases.Vehiculo vehiculo2 = controladoraWeb.buscarVehiculoMatricula(matricula);
                    if (vehiculo2 != null)
                    {
                        int CliCod = int.Parse(Request.Cookies["IdUsuario"].Value); 
                        DominioClases.Cliente_Vehiculo cliente_Vehiculo = new DominioClases.Cliente_Vehiculo(CliCod ,vehiculo2.VehiculoCod);
                        controladoraWeb.AltaClienteVehiculo(cliente_Vehiculo);
                        listarVehiculos();
                    }
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