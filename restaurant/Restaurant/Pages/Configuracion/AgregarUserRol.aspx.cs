using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Negocio;
using Restaurant.Clases;

namespace Restaurant.Pages.Configuracion
{
    public partial class AgregarUserRol : System.Web.UI.Page
    {
        List<String> Seleccionados
        {
            get
            {
                if (Session["Seleccion"] == null)
                    Session["Seleccion"] = new List<String>();

                return Session["Seleccion"] as List<String>;
            }
        }

        String IdRol
        {
            get
            {
                if (Session["IdRol"] == null)
                    Session["IdRol"] = "";

                return Session["IdRol"] as String;
            }
            set { Session["IdRol"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IdRol = Request.Params["IdRol"].ToString();
                CargarGrid();
            }

        }

        private void CargarGrid()
        {
            GViewUserRoles.DataSource = clConfiguracion.GetUserRoles(TBoxBusca.Text);
            GViewUserRoles.DataBind();
        }







        protected void checkbox_checkedChanged(object sender, EventArgs e)
        {
            CheckBox cboxTmp = (CheckBox)sender;
            String RowId = cboxTmp.ClientID.Substring(cboxTmp.ClientID.IndexOf('_') + 1);
            String[] lines = RowId.Split('_');
            int intlinea = lines.Length;
            RowId = lines[intlinea - 2];

            object oValue = GViewUserRoles.FindControl(RowId).FindControl("IDValue");

            if (oValue != null)
            {
                if (cboxTmp.Checked && !String.IsNullOrEmpty(((Label)oValue).Text))
                {
                    if (!Seleccionados.Contains(((Label)oValue).Text))
                        Seleccionados.Add(((Label)oValue).Text);
                }
                else
                {
                    if (Seleccionados.Contains(((Label)oValue).Text))
                        Seleccionados.Remove(((Label)oValue).Text);
                }
            }
            LblSeleccionados.Text = String.Format("Seleccionados: {0} ", Seleccionados.Count);
        }

        protected Boolean isSelected(String stID)
        {
            return Seleccionados.Contains(stID);
        }

        protected void BtnBusca_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void BtnAplicar_Click(object sender, EventArgs e)
        {
            if (Seleccionados.Count > 0)
            {
                foreach (string stid in Seleccionados)
                {
                    if (clConfiguracion.SetUserRoles(Convert.ToInt32(stid), Convert.ToInt32(IdRol)))
                    {
                        clExcepcion.SuccessFunction(this, "Se han guardado con exito", "function() { window.location='/Pages/Configuracion/AgregarRol.aspx'}");
                    }
                }



            }
            else
            {
                clExcepcion.Error(this, "Debe seleccionar un usuario");

            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Configuracion/AgregarRol.aspx");

        }

     

    }
}
