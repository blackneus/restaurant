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
    public partial class CambiarPregunta : clSessionPage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            CargarPreguntas();
        }

        private void CargarPreguntas()
        {
            
            DDLPregunta.DataSource = clUsuario.GetPreguntas();
            DDLPregunta.DataTextField = "Question";
            DDLPregunta.DataValueField = "id_Question";
            DDLPregunta.DataBind();
            DDLPregunta.Items.Insert(0, new ListItem());
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {   int intidUser=Convert.ToInt32(User.IdUsuario);
            string stRepuesta=string.Empty;
            int intIdPregunta=0;
            string sterror = string.Empty;
            if (DDLPregunta.SelectedIndex>0)
                intIdPregunta = Convert.ToInt32(DDLPregunta.SelectedValue);
            else
                sterror += @"Debe de seleccionar una pregunta<br \>";
            if (!string.IsNullOrEmpty(TBoxRespuesta.Text))
                stRepuesta = TBoxRespuesta.Text;
            else
                sterror += @"Debe de ingresar una respuesta <br \>";
            
            
            
           
            if (string.IsNullOrEmpty(sterror))
            {
                try
                {
                    if (clConfiguracion.SetPregunta(intidUser,intIdPregunta,stRepuesta))
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
