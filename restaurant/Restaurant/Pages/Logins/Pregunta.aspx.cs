using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Negocio;
using Restaurant.Clases;

namespace Restaurant.Pages.Logins
{
    public partial class Pregunta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string stPregunta = string.Empty;
            stPregunta = clUsuario.GetPregunta(TBoxUsuario.Text);
            if (string.IsNullOrEmpty(stPregunta))
            {
                clExcepcion.Error(this, "Usuario incorrecto");
            }
            else
            {
                TBoxPregunta.Text = stPregunta;
            }
            
        }

        protected void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (clUsuario.ValidaPregunta(TBoxUsuario.Text, TBoxRespuesta.Text))
            {
                clExcepcion.Success(this, "Respuesta correcta");
            }
            else
            {
                clExcepcion.Error(this, "Respuesta incorrecta y/o usuario incorrecto");
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Información", "bootbox.alert('Error!. <br />Respuesta incorrecta y/o usuario incorrecto', 'Ok','btn-danger');", true);
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Logins/Login.aspx");
        }

     
    }
}