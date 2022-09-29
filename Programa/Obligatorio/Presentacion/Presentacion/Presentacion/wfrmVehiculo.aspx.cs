using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmVehiculo : System.Web.UI.Page
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
            this.lstVehiculo.DataSource = null;
            this.lstVehiculo.DataSource = unaControladoraWeb.listaVehiculo();
            this.lstVehiculo.DataBind();
        }

        private bool VehiculosAsignados()
        {
            int id = int.Parse(this.txtVehiculoCod.Text);
            DominioClases.Vehiculo unVehiculo = unaControladoraWeb.buscarVehiculo(id);
            foreach (DominioClases.Cliente_Vehiculo unCV in unaControladoraWeb.listaClienteVehiculo())
            {
                if (unVehiculo.VehiculoCod == unCV.VehiculoCod)
                {
                    return true;
                }
            }
            foreach (DominioClases.Reparacion unaRep in unaControladoraWeb.listarReparacion())
            {
                if (unVehiculo.VehiculoCod == unaRep.VehiculoCod)
                {
                    return true;
                }
            }
            return false;
        }
        private bool FaltanDatos()
        {
            if (this.txtVehiculoCod.Text == "" || this.txtMatricula.Text == "" || this.txtMarca.Text == "" || this.txtModelo.Text == "" || this.txtAnio.Text == "" || this.txtColor.Text == "")
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
            this.txtMatricula.Text = null;
            this.txtMarca.Text = null;
            this.txtModelo.Text = null;
            this.txtAnio.Text = null;
            this.txtColor.Text = null;
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                if (!VehiculosAsignados())
                {
                    int id = int.Parse(this.txtVehiculoCod.Text);
                    if (unaControladoraWeb.bajaVehiculo(id))
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

        protected void lstVehiculo_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstVehiculo.SelectedIndex > -1)
            {
                string linea = this.lstVehiculo.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int Id = int.Parse(partes[0]);

                DominioClases.Vehiculo unVehiculo = unaControladoraWeb.buscarVehiculo(Id);
                this.txtVehiculoCod.Text = Convert.ToString(unVehiculo.VehiculoCod);
                this.txtMatricula.Text = Convert.ToString(unVehiculo.Matricula);
                this.txtMarca.Text = Convert.ToString(unVehiculo.Marca);
                this.txtModelo.Text = Convert.ToString(unVehiculo.Modelo);
                this.txtAnio.Text = Convert.ToString(unVehiculo.Anio);
                this.txtColor.Text = Convert.ToString(unVehiculo.Color);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                int id = int.Parse(this.txtVehiculoCod.Text);
                string matricula = this.txtMatricula.Text;
                string marca = this.txtMarca.Text;
                string modelo = this.txtModelo.Text;
                int anio = int.Parse(this.txtAnio.Text);
                string color = this.txtColor.Text;

                DominioClases.Vehiculo vehiculo = new DominioClases.Vehiculo(id, matricula, marca, modelo, anio, color);
                if (unaControladoraWeb.modificarVehiculo(vehiculo))
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