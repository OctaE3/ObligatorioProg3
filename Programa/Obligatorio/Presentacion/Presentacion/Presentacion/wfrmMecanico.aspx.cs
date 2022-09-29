using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Presentacion
{
    public partial class wfrmMecanico : System.Web.UI.Page
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

        private bool MecanicosAsignados()
        {
            int id = int.Parse(this.txtMecanicoCod.Text);
            DominioClases.Mecanico unMecanico = unaControladoraWeb.buscarMecanico(id);
            foreach (DominioClases.Reparacion unaRep in unaControladoraWeb.listarReparacion())
            {
                if (unMecanico.MecCod == unaRep.MecCod)
                {
                    return true;
                }
            }
            foreach (DominioClases.Reparacion_Horas unaRepH in unaControladoraWeb.listarReparacionHoras())
            {
                if (unMecanico.MecCod == unaRepH.Mecanico)
                {
                    return true;
                }
            }
            return false;
        }


        private void Listar()
        {
            this.lstMecanicos.DataSource = null;
            this.lstMecanicos.DataSource = unaControladoraWeb.listaMecanico();
            this.lstMecanicos.DataBind();
        }

        private bool FaltanDatos()
        {
            if (this.txtMecNom.Text == "" || this.txtMecCi.Text == "" || this.txtMecTel.Text == "" || this.txtMecFchIng.Text == "" || this.txtMecValorHora.Text == "" || this.txtMecActivo.Text == "")
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
            this.txtMecanicoCod.Text = null;
            this.txtMecNom.Text = null;
            this.txtMecCi.Text = null;
            this.txtMecTel.Text = null;
            this.txtMecFchIng.Text = null;
            this.txtMecValorHora.Text = null;
            this.txtMecActivo.Text = null;
        }

        protected void lstMecanicos_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Inicio Mensaje", "MensajeInicio();", true);
            if (this.lstMecanicos.SelectedIndex > -1)
            {
                string linea = this.lstMecanicos.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int mecCod = int.Parse(partes[0]);

                DominioClases.Mecanico unMecanico = unaControladoraWeb.buscarMecanico(mecCod);

                this.txtMecanicoCod.Text = Convert.ToString(unMecanico.MecCod);
                this.txtMecNom.Text = Convert.ToString(unMecanico.MecNom);
                this.txtMecCi.Text = Convert.ToString(unMecanico.MecCi);
                this.txtMecTel.Text = Convert.ToString(unMecanico.MecTel);
                this.txtMecFchIng.Text = unMecanico.MecFchIng.ToString("yyyy-MM-dd");
                this.txtMecValorHora.Text = Convert.ToString(unMecanico.MecValorHora);
                this.txtMecActivo.Text = unMecanico.MecActivo;
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            ControladoraPresentacion.ControladoraWeb unaControladoraWeb = new ControladoraPresentacion.ControladoraWeb();
            if (!this.FaltanDatos())
            {
                int mecCod = 0;
                string mecNom = this.txtMecNom.Text;
                string mecCi = this.txtMecCi.Text;
                string mecTel = this.txtMecTel.Text;
                DateTime mecFchIng = DateTime.Parse(this.txtMecFchIng.Text);
                int mecValorHora = int.Parse(this.txtMecValorHora.Text);
                string mecActivo = this.txtMecActivo.Text;

                DominioClases.Mecanico unMecanico = new DominioClases.Mecanico(mecCod, mecNom, mecCi, mecTel, mecFchIng, mecValorHora, mecActivo);
                if (unaControladoraWeb.altaMecanico(unMecanico))
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
                if (!MecanicosAsignados())
                {
                    int mecCod = int.Parse(txtMecanicoCod.Text);
                    if (unaControladoraWeb.bajaMecanico(mecCod))
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
                    this.visibilidad3.Visible = true;
                    this.visibilidad2.Visible = false;
                    this.visibilidad1.Visible = false;
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
            if (!FaltanDatos())
            {
                int mecCod = int.Parse(this.txtMecanicoCod.Text);
                string mecNom = this.txtMecNom.Text;
                string mecCi = this.txtMecCi.Text;
                string mecTel = this.txtMecTel.Text;
                DateTime mecFchIng = DateTime.Parse(this.txtMecFchIng.Text);
                int mecValorHora = int.Parse(this.txtMecValorHora.Text);
                string mecActivo = this.txtMecActivo.Text;

                DominioClases.Mecanico unMecanico = new DominioClases.Mecanico(mecCod, mecNom, mecCi, mecTel, mecFchIng, mecValorHora, mecActivo);
                if (unaControladoraWeb.modificarMecanico(unMecanico))
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