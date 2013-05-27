using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Negocio;
using Restaurant.Clases;
namespace Restaurant.Pages.Reportes
{
    public partial class Corte : System.Web.UI.Page
    {
        String stServidorReportingServices;
        String stInstanciaReportingServices;
        protected void Page_Load(object sender, EventArgs e)
        {
             stServidorReportingServices = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("ServidorReportingServices");
             stInstanciaReportingServices = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("InstanciaReportingServices");
            
        }

      


        protected void BtnReporte_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtFechaInicio.Text))
            {
                string stscript = string.Format("javascript:window.open('{0}','Corte', 'width=960,height=768,toolbar=0,status=0,location=0,menubar=0,directories=0,resizable=1,scrollbars=1');", string.Format("http://{0}/{1}/Pages/ReportViewer.aspx?%2fCorte&rs:Command=Render&rs:Format=HTML4.0&rc:Parameters=false&fecha={2}", stServidorReportingServices, stInstanciaReportingServices, Convert.ToDateTime(TxtFechaInicio.Text).ToString("yyyy-MM-dd")));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Corte", stscript, true);
            }
            else
            {
                clExcepcion.Error(this, "Debe seleccionar un mesero y /o una fecha");
            }
         
        }
    }
}