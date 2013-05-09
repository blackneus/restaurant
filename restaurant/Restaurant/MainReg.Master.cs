using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Clases;
using Restaurant.Negocio;

namespace Restaurant
{
    public partial class MainReg : MasterPage  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  getContSession(Context);
            if (!IsPostBack)
            {
                clUsuario uUsuario = this.Session["User"] as clUsuario;
                if (uUsuario != null)
                {
                    LblNombre.Text = uUsuario.Name;
                    //LkBAdministracion.Visible = true;
                    LkBBienvenido.Visible = true;
                    LkBConfiguracion.Visible = true;
                }
                else
                {
                    LkBAdministracion.Visible = false;
                    LkBBienvenido.Visible = false;
                    LkBConfiguracion.Visible = false;
                }
            }
        }

        protected void LKBCerrar_Click(object sender, EventArgs e)
        {
            this.Session.RemoveAll();
            Response.Redirect("/Default.aspx");
        }

        protected void LkBConfiguracion_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Configuracion/Config.aspx");
        }

        protected void LkBAdministracion_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Configuracion/Admin.aspx");
        }

        protected void LkBBienvenido_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Configuracion/Inicio.aspx");
        }

        //public static clUsuario getContSession(HttpContext hcSite)
        //{
        //    clUsuario uUsuario = hcSite.Session["uUsuario"] as clUsuario;
        //    if (uUsuario != null)
        //        return uUsuario;

        //    clExcepcion.Error(Page, "Sesión Finalizada o No Iniciada");
        //    clExcepcionExt eeEx = new clExcepcionExt("Sesión Finalizada o No Iniciada");
        //    eeEx.Descripcion = "Para acceder nuevamente:<br>" +
        //    " <a target='_top' class=\"clsLinkBlue\" href='../Principal/Inicio.aspx'>Inicio de sesión </a>";
        //    eeEx.TipoExcepcion = TiposExcepcion.Advertencia;
        //    throw eeEx;
        //}
    }
}