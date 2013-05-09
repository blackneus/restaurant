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
    public partial class CambiarContraseña : clSessionPage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string sterror = string.Empty;
            clPasswordPolicy pw = new clPasswordPolicy();
            if (clUsuario.ValidaAcceso(User.Login, TBoxContraseñaant.Text))
            {
                if (clPasswordPolicy.IsValid(TBoxContraseña1.Text))
                {
                    if (TBoxContraseña1.Text == TBoxContraseña2.Text)
                    {
                        clUsuario.CambiarContraseña(User.Login, TBoxContraseña1.Text);
                        clExcepcion.SuccessFunction(this, "Se han cambiado con exito", "function() { window.location='/Pages/Configuracion/Config.aspx'}");
                    }
                    else
                    {
                        TBoxContraseña1.Text = string.Empty;
                        TBoxContraseña2.Text = string.Empty;
                        sterror += @"Las contraseñas no coinciden ingreselas de nuevo" + @"<br \>";
                        
                    }
                }
                else
                {
                    clExcepcion.Error(this, pw.StError);
                }
               

            }
            else
            {
                sterror += @"Contraseña incorrecta"+@"<br \>";
            }

            clExcepcion.Error(this, sterror);
        }
    }
}