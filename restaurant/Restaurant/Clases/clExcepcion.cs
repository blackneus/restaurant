using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
    // ----------------------------------------------------------------------------------------
// Author:                    Armando Saavedra
// Company:                   SistemasCBT
// Assembly version:          
// Date:                      07/10/2011
// Time:                      19:07
// Project Name:              F:\Documentos\Proyectos\Modelo de Gestion de Talento Tecnico\Modelo de Gestion Talento Tecnico\
// Project Filename:          
// Project Item Name:         ExcepcionExt.cs
// Project Item Filename:     ExcepcionExt.cs
// Project Item Kind:         Código
// Purpose:                   Clase que extiende las propiedades de una excepcion para el control y presentacion de errores
// ----------------------------------------------------------------------------------------
namespace Restaurant.Clases
{
    [Serializable]
    public class clExcepcion
    {
 
        #region Propiedades

        static String stDescripcion;
        public String Descripcion
        {
            get { return stDescripcion; }
            set { stDescripcion = value; }
        }

       


        #endregion

        #region Metodos

        public clExcepcion() { }
        public clExcepcion(String stMensaje) { }
        public clExcepcion(String stMensaje, String stDescripcion)
        {
            
        }
        public static void Error(Page hcSite,String stMensaje, String stDescripcion)
            
        {
            //ScriptManager.RegisterStartupScript(hcSite, hcSite.GetType(), "Información", "bootbox.alert('" + stMensaje + " <br /> " + stDescripcion + "', 'Ok');", true);
            ScriptManager.RegisterStartupScript(hcSite, hcSite.GetType(), "Información", "bootbox.alert('" + stMensaje + " <br /> " + stDescripcion + "', 'Ok','label-important');", true);
        }
        public static void Error(Page hcSite, String stMensaje)
        {
            //ScriptManager.RegisterStartupScript(hcSite, hcSite.GetType(), "Información", "bootbox.alert('" + stMensaje + "', 'Ok');", true);
            ScriptManager.RegisterStartupScript(hcSite, hcSite.GetType(), "Info", "bootbox.alert('Error!. <br />" + stMensaje + "', 'Ok','label-important');", true);
        }
        public static void Success(Page hcSite, String stMensaje)
        {
            ScriptManager.RegisterStartupScript(hcSite, hcSite.GetType(), "InfoCorrecto", "bootbox.alert('Correcto.! <br />" + stMensaje + " <br /> " + "', 'Ok','label-success');", true);
        }
        public static void SuccessFunction(Page hcSite, String stMensaje,String stFunction)
        {
            ScriptManager.RegisterStartupScript(hcSite, hcSite.GetType(), "InfoCorrecto", "bootbox.alert('Correcto.! <br />" + stMensaje + " <br /> " + "', 'Ok','label-success'," + stFunction + ");", true);
        }
        public static void ModalShow(Page hcSite, String stModal)
        {
            ScriptManager.RegisterStartupScript(hcSite, hcSite.GetType(), "InfoModal", "$('#" + stModal + "').modal('show');", true);
        }
        public clExcepcion(Exception ex)
           
        {
            
            Descripcion = ex.StackTrace;
        }

        #endregion
    }

    public enum TiposExcepcion
    {
        Advertencia,
        ErrorBaseDatos,
        ErrorFuncional,
        Informacion
    } 
}
