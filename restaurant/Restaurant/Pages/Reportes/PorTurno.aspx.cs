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
    public partial class PorTurno : System.Web.UI.Page
    {
        String stServidorReportingServices = "";
        String stInstanciaReportingServices="";
        protected void Page_Load(object sender, EventArgs e)
        {
             stServidorReportingServices = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("ServidorReportingServices");
             stInstanciaReportingServices = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("InstanciaReportingServices");
       
            if (!IsPostBack)
            LlenarDDL();
        }

        private void LlenarDDL()
        {
            DDLTurno.DataSource = clReportes.GetTurnos();
            DDLTurno.DataTextField = "horario_nombre";
            DDLTurno.DataValueField = "id_horario";
            DDLTurno.DataBind();
            DDLTurno.Items.Insert(0, new ListItem());
        }


        protected void BtnReporte_Click(object sender, EventArgs e)
        {
            if (DDLTurno.SelectedIndex > 0 || string.IsNullOrEmpty(TxtFechaInicio.Text))
            {
                string stscript = string.Format("javascript:window.open('{0}','PorTurno', 'width=960,height=768,toolbar=0,status=0,location=0,menubar=0,directories=0,resizable=1,scrollbars=1');", string.Format("http://{0}/{1}/Pages/ReportViewer.aspx?%2fPorTurno&rs:Command=Render&rs:Format=HTML4.0&rc:Parameters=false&id_horario={2}&fecha={3}", stServidorReportingServices, stInstanciaReportingServices, DDLTurno.SelectedValue.ToString(), Convert.ToDateTime(TxtFechaInicio.Text).ToString("yyyy-MM-dd")));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Reporte por Turno", stscript, true);
            }
            else
            {
                clExcepcion.Error(this, "Debe seleccionar un mesero y /o una fecha");
            }
         
        }
    }
}