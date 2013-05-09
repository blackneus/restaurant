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
using System;

namespace Restaurant.Negocio
{
    [Serializable]
    public class clExcepcionExt : Exception
    {
        #region Propiedades

        static string stDescripcion;
        public String Descripcion
        {
            get { return stDescripcion; }
            set { stDescripcion = value; }
        }

        static TiposExcepcion teTipoExcepcion = TiposExcepcion.ErrorFuncional;
        public TiposExcepcion TipoExcepcion
        {
            get { return clExcepcionExt.teTipoExcepcion; }
            set { clExcepcionExt.teTipoExcepcion = value; }
        }


        #endregion

        #region Metodos

        public clExcepcionExt() { }
        public clExcepcionExt(String stMensaje) : base(stMensaje) { }
        public clExcepcionExt(String stMensaje, String stDescripcion, TiposExcepcion teTipo)
            : base(stMensaje)
        {
            TipoExcepcion = teTipo;
            Descripcion = stDescripcion;
        }
        public clExcepcionExt(Exception ex)
            : base(ex.Message)
        {
            TipoExcepcion = TiposExcepcion.ErrorFuncional;
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