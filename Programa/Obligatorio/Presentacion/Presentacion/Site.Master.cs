using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Admin"] == null || Request.Cookies["IdUsuario"] == null)
                {
                    this.login.InnerText = "Iniciar Sesion";
                }
                else
                {
                    this.login.InnerText = "Cerrar Sesion";
                }
            }
        }

        protected void Login(object sender, EventArgs e)
        {
            if (this.login.InnerText == "Iniciar Sesion")
            {
                Response.Redirect("~/Presentacion/wfrmLoginUsuario");
            }
            if (this.login.InnerText == "Cerrar Sesion")
            {
                if (Request.Cookies["IdUsuario"] != null || Request.Cookies["Admin"] != null)
                {
                    Response.Cookies["IdUsuario"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Admin"].Expires = DateTime.Now.AddDays(-1);
                    Response.Redirect("~/Presentacion/wfrmInicio");
                }
            }
        }
    }
}