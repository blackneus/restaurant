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
    public partial class ActualizaDatosPersonales : clSessionPage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (User != null)
            {
                TBoxuserLogin.Text = User.Login;
                TBoxName.Text = User.Name;
                TBoxLastName.Text = User.LastName;
                TBoxMiddleName.Text = User.MiddleName;

            }
            else
            {
                Response.Redirect("~/Pages/Logins/Login.aspx");
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            clUsuario cluUsuario = new clUsuario();
            cluUsuario.IdUsuario = User.IdUsuario;
            string sterror = string.Empty;
            if (!string.IsNullOrEmpty(TBoxuserLogin.Text))
                cluUsuario.Login = TBoxuserLogin.Text;
            else
                sterror += @"Debe de ingresar la ficha <br \>";
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
           
            if (string.IsNullOrEmpty(sterror))
            {
                try
                {
                    if (clConfiguracion.ActualizarDatos(cluUsuario))
                    {
                        clExcepcion.SuccessFunction(this, "Se han guardado con exito", "function() { window.location='/Pages/Configuracion/Config.aspx'}");
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

        
    }
}