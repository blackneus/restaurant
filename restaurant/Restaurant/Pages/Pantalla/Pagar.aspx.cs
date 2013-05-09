using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Negocio;
using Restaurant.Clases;
using System.Data;
namespace Restaurant.Pages.Pantalla
{
    public partial class Pagar : clSessionPage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            LlenarDDL();
        }

        private void LlenarDDL()
        {
            DDLMesa.DataSource = clMeseros.GetTable();
            DDLMesa.DataTextField = "mesas_nombre";
            DDLMesa.DataValueField = "id_mesas";
            DDLMesa.DataBind();
            DDLMesa.Items.Insert(0, new ListItem());

            DDLTipoPago.DataSource = clPagar.GetTipoPago();
            DDLTipoPago.DataTextField = "tipopago";
            DDLTipoPago.DataValueField = "id_tipopago";
            DDLTipoPago.DataBind();
            DDLTipoPago.Items.Insert(0, new ListItem());
        }

        protected void DDLMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dttabla= clPagar.GetCuenta(DDLMesa.SelectedValue);

            if (dttabla.Rows.Count > 0)
            {
                TBoxSaldo.Text = dttabla.Rows[0]["factura_montototal"].ToString();
                LblCliente.Text = dttabla.Rows[0]["clientes_razonsocial"].ToString();
                HFieldFactura.Value = dttabla.Rows[0]["id_factura"].ToString();
                BtnPagar.Enabled = true;
            }
            else
            {
                clExcepcion.Error(this, "Todavia no se ha cerrado la cuenta");
            }
        }

        protected void DDLTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTipoPago.SelectedItem.ToString() == "1")
            {
               
            }
            else
            {
                TBoxApagar.Text = TBoxSaldo.Text;
            }
        }

        protected void BtnFactura_Click(object sender, EventArgs e)
        {
            string stscript = string.Format("javascript:window.open('{0}','Factura', 'width=960,height=768,toolbar=0,status=0,location=0,menubar=0,directories=0,resizable=1,scrollbars=1');", string.Format("http://isolorio/ReportServer_SQL2012/Pages/ReportViewer.aspx?%2fFactura&rs:Command=Render&rs:Format=HTML4.0&rc:Parameters=false&id_factura={0}", HFieldFactura.Value.ToString()));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Factura",stscript , true);
        }

        protected void BtnPagar_Click(object sender, EventArgs e)
        {
            if (DDLTipoPago.SelectedIndex > 0)
            {
                clPagar.SetPago(TBoxSaldo.Text, DDLTipoPago.SelectedValue.ToString(), HFieldFactura.Value.ToString());
                BtnPagar.Enabled = false;
                string stscript = string.Format("javascript:window.open('{0}','Factura', 'width=960,height=768,toolbar=0,status=0,location=0,menubar=0,directories=0,resizable=1,scrollbars=1');", string.Format("http://isolorio/ReportServer_SQL2012/Pages/ReportViewer.aspx?%2fFactura&rs:Command=Render&rs:Format=HTML4.0&rc:Parameters=false&id_factura={0}", HFieldFactura.Value.ToString()));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Factura", stscript, true);
                Response.Redirect("/Pages/Logins/Pagar.aspx");
            }
            else
            {
                clExcepcion.Error(this, "Debe elegir una forma de pago");
            }
        }
    }
}