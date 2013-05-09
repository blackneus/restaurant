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
    public partial class AgregarRol : System.Web.UI.Page
    {
        Dictionary<String,String> Seleccionados
        {
            get
            {
                if (Session["Seleccionados"] == null)
                    Session["Seleccionados"] = new Dictionary<String, String>();

                return Session["Seleccionados"] as Dictionary<String, String>;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGrid();

        }

        private void CargarGrid()
        {
            GViewRoles.DataSource = clConfiguracion.GetRoles(TBoxBusca.Text);
            GViewRoles.DataBind();
        }



        protected void Borrar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            clConfiguracion.SetRoles(Convert.ToInt32(btn.CommandArgument), null);
            CargarGrid();
        }




        protected void checkbox_checkedChanged(object sender, EventArgs e)
        {
            CheckBox cboxTmp = (CheckBox)sender;
            String RowId = cboxTmp.ClientID.Substring(cboxTmp.ClientID.IndexOf('_') + 1);
            String[] lines = RowId.Split('_');
            int intlinea = lines.Length;
            RowId = lines[intlinea - 2];

            object oValue = GViewRoles.FindControl(RowId).FindControl("IDValue");
            object TextValue = GViewRoles.FindControl(RowId).FindControl("TextValue");
            if (oValue != null)
            {
                if (cboxTmp.Checked && !String.IsNullOrEmpty(((Label)oValue).Text))
                {
                    if (!Seleccionados.ContainsKey(((Label)oValue).Text))
                        Seleccionados.Add(((Label)oValue).Text,((Label)TextValue).Text);
                }
                else
                {
                    if (Seleccionados.ContainsKey(((Label)oValue).Text))
                        Seleccionados.Remove(((Label)oValue).Text);
                }
            }
            LblSeleccionados.Text = String.Format("Seleccionados: {0} ", Seleccionados.Count);
        }

        protected Boolean isSelected(String stID)
        {
            return Seleccionados.ContainsKey(stID);
        }

        protected void BtnBusca_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void BtnAplicar_Click(object sender, EventArgs e)
        {
            int intidAccion = 0;
            intidAccion = Convert.ToInt32(DDLComando.SelectedValue);
            if (DDLComando.SelectedIndex > 0)
            {

                switch (intidAccion)
                {
                    case 1:
                        if (Seleccionados.Count > 0)
                        {
                            foreach (string stid in Seleccionados.Keys )
                            {
                                clPermisos.SetActiveOn(Convert.ToInt32(stid));
                            }
                            LblAccion.Text = "El/Los perfil/es es/son activado/s";
                            clExcepcion.ModalShow(this, "mModBloqueo");

                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar al menos un usuario");
                        }
                        break;

                    case 2:
                        if (Seleccionados.Count > 0)
                        {

                            foreach (string stid in Seleccionados.Keys)
                            {
                                clPermisos.SetActiveOff(Convert.ToInt32(stid));
                            }
                            LblAccion.Text = "El/Los perfil/es es/son desactivado/s";
                            clExcepcion.ModalShow(this, "mModBloqueo");

                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar al menos un usuario");
                        }

                        break;
                    case 3:
                        if (Seleccionados.Count == 1)
                        {

                            foreach (string stid in Seleccionados.Keys)
                            {
                                Response.Redirect("/Pages/Configuracion/CambiarPermisosRoles.aspx?idrol=" + stid);
                            }


                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar solo un usuario");
                        }
                        break;
                    case 4:
                        BtnAplicar.Text = "Aplicar";
                        
                        if (!string.IsNullOrEmpty(TBoxBusca.Text))
                        {
                            if (clConfiguracion.SetRoles(0, TBoxBusca.Text))
                                CargarGrid();
                            else
                                clExcepcion.Error(this, "Ocurrio un error");
                        }
                        else
                            clExcepcion.Error(this, "Debe escribir el rol");
                        TBoxBusca.Text = string.Empty;
                        break;
                    case 5:
                        BtnAplicar.Text = "Aplicar";

                        if (Seleccionados.Count == 1)
                        {
                            clConfiguracion.SetRoles(Convert.ToInt32(Seleccionados.Keys.First()), TBoxBusca.Text);
                            CargarGrid();
                            DDLComando.SelectedIndex = 0;
                        }
                        else
                        {
                            DDLComando.SelectedIndex = 0;
                            clExcepcion.Error(this, "Debe seleccionar solo un rol");

                        }
                        TBoxBusca.Text = string.Empty;
                        break;

                    case 6:
                        Response.Redirect("/Pages/Configuracion/AgregarUserRol.aspx?IdRol="+Seleccionados.Keys.First());

                        break;



                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                CargarGrid();


            }
            else
            {
                clExcepcion.Error(this, "Debe seleccionar una acción");

            }
        }

        protected void DDLComando_SelectedIndexChanged(object sender, EventArgs e)
        {
           

                switch (Convert.ToInt32(((DropDownList)sender).SelectedValue))
                {
                    case 4:
                        TBoxBusca.Text = string.Empty;
                        BtnAplicar.Text = "Guardar";
                        break;
                    case 5:
                        TBoxBusca.Text = Seleccionados.Values.First();
                        BtnAplicar.Text = "Guardar";
                        break;

                }
            }
            
        }
    }
