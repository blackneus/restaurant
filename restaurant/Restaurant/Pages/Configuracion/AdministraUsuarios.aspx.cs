using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Restaurant.Clases;
using Restaurant.Negocio;
namespace Restaurant.Pages.Configuracion
{
    public partial class AdministraUsuarios : clSessionPage
    {
        List<String> Seleccionados
        {
            get
            {
                if (Session["UserSeleccionados"] == null)
                    Session["UserSeleccionados"] = new List<String>();

                return Session["UserSeleccionados"] as List<String>;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarDatos(TBoxBusca.Text);
        }

        private void CargarDatos(string stFiltro)
        {
            clUsuario cluUsuario = new clUsuario();
            DataTable dtResultadoBusqueda = cluUsuario.GetUsuariosAdministrar(stFiltro);

            if (!String.IsNullOrEmpty(ViewState["SortExprValue"] as string))
            {

                String stSortExp = ViewState["SortExprValue"].ToString();

                if (dtResultadoBusqueda.Rows.Count > 0 & !String.IsNullOrEmpty(stSortExp))
                {
                    DataView dataView = new DataView(dtResultadoBusqueda);

                    SortDirection sortDirect = (SortDirection)ViewState["SortDirection"];

                    dataView.Sort = stSortExp + " " + ConvertSortDirectionToSql(sortDirect);

                    dtResultadoBusqueda = dataView.ToTable();

                    dataView.Dispose();
                }
            }

            GViewUsuarios.DataSource = dtResultadoBusqueda;
            GViewUsuarios.DataBind();
            GViewUsuarios.PageIndex = 0;

            //     LblResultadosbusqueda1.Text = String.Format("Resultados obtenidos: {0} ", dtResultadoBusqueda.Rows.Count);

            dtResultadoBusqueda.Dispose();

            //if (GViewUsuarios.Rows.Count == 0)
            //    NoData1.Visible = true;
            //else NoData1.Visible = false;
        }


        protected void GViewUsuarios_Sorting(object sender, GridViewSortEventArgs e)
        {
            GViewUsuarios.PageIndex = 0;

            SortDirection sortDirection = SortDirection.Ascending;

            string sortExpression = ViewState["SortExprValue"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == e.SortExpression.ToString())
                {
                    if (sortExpression == e.SortExpression.ToString())
                    {
                        SortDirection lastDirection = (SortDirection)ViewState["SortDirection"];
                        if (lastDirection == sortDirection)
                        {
                            sortDirection = SortDirection.Descending;
                        }
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExprValue"] = e.SortExpression;

            CargarDatos(TBoxBusca.Text);
        }

        protected void GViewUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarDatos(TBoxBusca.Text);
            GViewUsuarios.PageIndex = e.NewPageIndex;
            GViewUsuarios.DataBind();
        }



        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
 
        }

        protected void BtnBusca_Click(object sender, EventArgs e)
        {
            CargarDatos(TBoxBusca.Text);

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
                        Response.Redirect("/Pages/Configuracion/NuevoUsuario.aspx");
                        break;
                    case 9:
                        Response.Redirect("/Pages/Configuracion/CambiarPermisosRoles.aspx");
                        break;
                    case 2:
                        if (Seleccionados.Count > 0)
                        {
                            foreach (string stid in Seleccionados)
                            {
                                clUsuario.SetActiveOn(Convert.ToInt32(stid), intidAccion);
                            }
                            LblAccion.Text = "Se han activado el/los usuario/s correctamente";
                            clExcepcion.ModalShow(this, "mModBloqueo");

                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar al menos un usuario");
                        }
                       
                        break;
                    case 3:
                        if (Seleccionados.Count > 0)
                        {
                            // "Activar/Desactivar Usuario";
                            foreach (string stid in Seleccionados)
                            {
                                clUsuario.SetActiveOff(Convert.ToInt32(stid), intidAccion);
                            }
                            LblAccion.Text = "Se han desactivado el/los usuario/s correctamente";
                            clExcepcion.ModalShow(this, "mModBloqueo");

                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar al menos un usuario");
                        }
                      
                        break;
                    case 4:
                        if (Seleccionados.Count > 0)
                        {
                            // "Bloquear/Desbloquear Usuario";
                            foreach (string stid in Seleccionados)
                            {
                                clUsuario.SetBloquedOn(Convert.ToInt32(stid), intidAccion);
                            }
                            LblAccion.Text = "Se han bloqueado el/los usuario/s correctamente";
                            clExcepcion.ModalShow(this, "mModBloqueo");
                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar al menos un usuario");
                        }
                       
                        break;
                    case 5:
                        if (Seleccionados.Count > 0)
                        {
                            // "Bloquear/Desbloquear Usuario";
                            foreach (string stid in Seleccionados)
                            {
                                clUsuario.SetBloquedOff(Convert.ToInt32(stid), intidAccion);
                            }
                            LblAccion.Text = "Se han desbloqueado el/los usuario/s correctamente";
                            clExcepcion.ModalShow(this, "mModBloqueo");

                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar al menos un usuario");
                        }
                     
                        break;
                    case 6:
                        if (Seleccionados.Count > 0)
                        {
                            // "Borrar Usuario";
                            foreach (string stid in Seleccionados)
                            {
                                clUsuario.SetDeleted(Convert.ToInt32(stid), intidAccion);
                            }
                            LblAccion.Text = "Se han borrado el/los usuario/s correctamente";
                            clExcepcion.ModalShow(this, "mModBloqueo");
                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar al menos un usuario");
                        }
                      
                        break;
                    case 7:
                        if (Seleccionados.Count > 0)
                        {
                            // "Interno/Externo";
                            foreach (string stid in Seleccionados)
                            {
                                clUsuario.SetInternalOn(Convert.ToInt32(stid), intidAccion);
                            }
                            LblAccion.Text = "El/Los usuario/s son internos";
                            clExcepcion.ModalShow(this, "mModBloqueo");
                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar al menos un usuario");
                        }
                     
                        break;
                    case 8:
                        if (Seleccionados.Count > 0)
                        {
                            // "Interno/Externo";
                            foreach (string stid in Seleccionados)
                            {
                                clUsuario.SetInternalOn(Convert.ToInt32(stid), intidAccion);
                            }
                            LblAccion.Text = "El/Los usuario/s son externo/s";
                            clExcepcion.ModalShow(this, "mModBloqueo");
                        }
                        else
                        {

                            clExcepcion.Error(this, "Debe seleccionar al menos un usuario");
                        }
                      
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                CargarDatos(TBoxBusca.Text);
              
               
            }
            else
            {
                clExcepcion.Error(this, "Debe seleccionar una acción");
                
            }
        }

        protected void checkbox_checkedChanged(object sender, EventArgs e)
        {
            CheckBox cboxTmp = (CheckBox)sender;
            String RowId = cboxTmp.ClientID.Substring(cboxTmp.ClientID.IndexOf('_') + 1);
            String[] lines = RowId.Split('_');
            int intlinea = lines.Length;
            RowId = lines[intlinea - 2];

            object oValue = GViewUsuarios.FindControl(RowId).FindControl("IDValue");
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

    }
}