using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Clases;
using Restaurant.Negocio;
namespace Restaurant.Pages.Logins
{
    public partial class Login : System.Web.UI.Page
    {
        public string error = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRestaurar_Click(object sender, EventArgs e)
        {

        }

        protected void LKBRecuperar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Logins/Pregunta.aspx");
        }

        protected void BtnAcceder_Click(object sender, EventArgs e)
        {
            string sterror1 = "Error!.";
            string sterror2 = string.Empty;
            if (string.IsNullOrEmpty(TBoxUsuario.Text) || string.IsNullOrEmpty(TBoxPassword.Text))
            {
                if (string.IsNullOrEmpty(TBoxUsuario.Text))
                    sterror2 = "Debe escribir el usuario.";

                if (string.IsNullOrEmpty(TBoxPassword.Text))
                    if (string.IsNullOrEmpty(sterror2))
                        sterror2 = "Debe escribir el password.";
                    else
                        sterror2 = sterror2 + "<br />" + "Debe escribir el password.";
                clExcepcion.Error(this, sterror1, sterror2 + "<br />" + error);
            }
            else
            {
                if (clUsuario.ValidaAcceso(TBoxUsuario.Text, TBoxPassword.Text))
                {
                    CargarSession(TBoxUsuario.Text);
                    Response.Redirect("/Pages/Configuracion/Inicio.aspx");
                }
                else
                {
                    if (clUsuario.Active)
                        clExcepcion.Error(this, "El nombre de usuario o la contraseña introducidos no son correctos."+"<br />"+" Tu cuenta se bloqueará después del tercer intento");
                    else
                        clExcepcion.Error(this, "Su cuenta no se encuentra activa contacte a su Administrador");
                }

            }

        }

        private void CargarSession(string stUsuario)
        {

            clUsuario uUsuario = clUsuario.getUsuario(stUsuario);

            this.Session.Add("User", uUsuario);
        }
    }
}
