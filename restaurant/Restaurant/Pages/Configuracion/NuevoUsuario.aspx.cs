using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Clases;
using Restaurant.Negocio;

namespace Restaurant.Pages.Configuracion
{
    public partial class NuevoUsuario : clSessionPage 
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLenguaje();
                CargarRol();
            }
        }

        private void CargarRol()
        {

            DDLRol.DataSource = clConfiguracion.GetRolesActivos();
            DDLRol.DataTextField = "Role_label";
            DDLRol.DataValueField = "id_Role";
            DDLRol.DataBind();
            DDLRol.Items.Insert(0, new ListItem());
        }

        private void CargarLenguaje()
        {
            clUsuario cluUsuario  = new clUsuario();
            DDLLanguage.DataSource = cluUsuario.GetLanguage();
            DDLLanguage.DataTextField = "Language";
            DDLLanguage.DataValueField = "id_Lang";
            DDLLanguage.DataBind();
            DDLLanguage.Items.Insert(0, new ListItem());
        }

         protected void BtnSave_Click(object sender, EventArgs e)
        {
            clUsuario cluUsuario = new clUsuario();
            
            string sterror = string.Empty;
            if (!string.IsNullOrEmpty(TBoxuserLogin.Text))
                cluUsuario.Login = TBoxuserLogin.Text;
            else
                sterror += @"Debe de ingresar la ficha <br \>";
            if (!string.IsNullOrEmpty(TBoxPassword.Text))
                cluUsuario.Password = TBoxPassword.Text;
            else
                sterror += @"Debe de ingresar el password <br \>";
            if (!string.IsNullOrEmpty(TBoxName.Text))
            cluUsuario.Name = TBoxName.Text;
            else
                sterror += @"Debe de ingresar el nombre <br \>";
            if (!string.IsNullOrEmpty(TBoxLastName.Text))
            cluUsuario.LastName = TBoxLastName.Text;
            else
                sterror += @"Debe de ingresar el apellido paterno <br \>";
            if (!string.IsNullOrEmpty(TBoxMiddleName.Text))
            cluUsuario.MiddleName=TBoxMiddleName.Text;
            else
                sterror += @"Debe de ingresar el apellido materno <br \>";
           
            if (DDLLanguage.SelectedIndex>0)
                cluUsuario.IdLang = DDLLanguage.SelectedValue;
            else
                sterror += @"Debe de seleccionar un idioma <br \>";
            if (DDLRol.SelectedIndex > 0)
                cluUsuario.IdRol = Convert.ToInt32(DDLLanguage.SelectedValue);
            else
                sterror += @"Debe de seleccionar un idioma <br \>";
            cluUsuario.Internal = ChBoxInterno.Checked;
            if (string.IsNullOrEmpty(sterror))
            {
                try
                {
                    if (clConfiguracion.NuevoUsuario(cluUsuario))
                    {
                        Response.Redirect("/Pages/Configuracion/AdministraUsuarios.aspx");
                    }

                }
                catch (Exception ex)
                {

                    clExcepcion.Error(this, ex.Message.ToString());
                }

            }
            else
            {
                clExcepcion.Error(this, sterror);
            }
        }

         protected void BtnCancel_Click(object sender, EventArgs e)
         {
             Response.Redirect("/Pages/Configuracion/AdministraUsuarios.aspx");
         }

        
    }
}