using System;
using System.Collections.Generic;
using System.Data;
using Restaurant.Datos;
using System.Web;

// ----------------------------------------------------------------------------------------
// Author:                    Armando Saavedra
// Company:                   SistemasCBT
// Assembly version:          
// Date:                      07/10/2011
// Time:                      13:20
// Project Item Name:         clUsuario.cs
// Project Item Filename:     clUsuario.cs
// Project Item Kind:         Código
// Class FullName:            clUsuario
// Class Name:                clUsuario
// Class Kind Description:    Clase
// Class Kind Keyword:        class
// Purpose:                   Clase para manejar los usuarios
// --------------------------------------------------------------------------------------
namespace Restaurant.Negocio
{
    public class clUsuario
    {
        const string strKEY = "usuarios_login";
        #region Variables

        clConexionMySQL obConn = new clConexionMySQL("Restaurant");
        private static String NombreConexion = "Restaurant";
        #endregion

        bool boDesactivarRoles = false;
       

        public bool DesactivarRoles
        {
            get { return boDesactivarRoles; }
            set { boDesactivarRoles = value; }
        }

        #region Propiedades

        public Dictionary<String, Boolean> diccionarioModulos = new Dictionary<string, bool>();
        public Dictionary<String, Boolean> diccionarioPermisos = new Dictionary<string, bool>();

        String stIdUsuario = "";
        public String IdUsuario
        {
            get { return stIdUsuario; }
            set { stIdUsuario = value; }
        }

        String stPersonalData_Name = "";

        public String Name
        {
            get { return stPersonalData_Name; }
            set { stPersonalData_Name = value; }
        }

        String stPersonalData_LastName = "";

        public String LastName
        {
            get { return stPersonalData_LastName; }
            set { stPersonalData_LastName = value; }
        }

        String stPersonalData_MiddleName = "";

        public String MiddleName
        {
            get { return stPersonalData_MiddleName; }
            set { stPersonalData_MiddleName = value; }
        }

        String stPersonalData_FullName = "";

        public String FullName
        {
            get { return stPersonalData_FullName; }
            set { stPersonalData_FullName = value; }
        }

        String stUserLogin = "";
        public String Login
        {
            get { return stUserLogin; }
            set { stUserLogin= value; }
        }
        String stRol = "";
        public String Rol
        {
            get { return stRol; }
            set { stRol = value; }
        }

        private static Boolean _bolactivo;

        public static Boolean Active
        {
            get { return clUsuario._bolactivo; }
            set { clUsuario._bolactivo = value; }
        }
        String stuser_idLang = "";
        public String IdLang
        {
            get { return stuser_idLang; }
            set { stuser_idLang = value; }
        }
        Boolean  stuserInternalEmp = false;
        public Boolean Internal
        {
            get { return stuserInternalEmp; }
            set { stuserInternalEmp = value; }
        }
        String stuserChangePass = "";
        public String ChangePass
        {
            get { return stuserChangePass; }
            set { stuserChangePass = value; }
        }
        String stPassword = "";
        public String Password
        {
            get { return stPassword; }
            set { stPassword = value; }
        }

        String stuserLastAcces = "";
        public String LastAcces
        {
            get { return stuserLastAcces; }
            set { stuserLastAcces = value; }
        }

        private static int _idrol;

        public  int IdRol
        {
            get { return clUsuario._idrol; }
            set { clUsuario._idrol = value; }
        }

        public string TiempoSesion { get; private set; }




        #endregion

        #region Metodos

        public clUsuario()
        {
 
        }
        public clUsuario(String stUserName)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@username", stUserName);

            DataSet dsUsuario = obConn.GetSPDataSet("USP_GetDatosUsuario", diParametros);
            if (dsUsuario.Tables[0].Rows.Count > 0)
            {

                if (dsUsuario.Tables[0].Rows[0]["id_usuarios"] != DBNull.Value)
                    stIdUsuario = dsUsuario.Tables[0].Rows[0]["id_usuarios"].ToString();
                else
                    stIdUsuario = "";
                if (dsUsuario.Tables[0].Rows[0]["usuarios_nombre"] != DBNull.Value)
                    Name = dsUsuario.Tables[0].Rows[0]["usuarios_nombre"].ToString();
                else
                    Name = "";

                if (dsUsuario.Tables[0].Rows[0]["usuarios_apellidopaterno"] != DBNull.Value)
                    LastName = dsUsuario.Tables[0].Rows[0]["usuarios_apellidopaterno"].ToString();
                else
                    LastName = "";
                if (dsUsuario.Tables[0].Rows[0]["usuarios_apellidomaterno"] != DBNull.Value)
                    MiddleName = dsUsuario.Tables[0].Rows[0]["usuarios_apellidomaterno"].ToString();
                else
                    MiddleName = "";
                if (dsUsuario.Tables[0].Rows[0]["usuarios_apellidomaterno"] != DBNull.Value)
                    FullName = Name+ " "+LastName + " " +MiddleName;
                else
                    FullName = "";
                if (dsUsuario.Tables[0].Rows[0]["usuarios_login"] != DBNull.Value)
                    Login = dsUsuario.Tables[0].Rows[0]["usuarios_login"].ToString();
                else
                    Login = "";
                if (dsUsuario.Tables[0].Rows[0]["id_roles"] != DBNull.Value)
                    IdRol = Convert.ToInt32(dsUsuario.Tables[0].Rows[0]["id_roles"]);
                else
                    IdRol = 0;
                if (dsUsuario.Tables[0].Rows[0]["roles_nombre"] != DBNull.Value)
                    Rol = dsUsuario.Tables[0].Rows[0]["roles_nombre"].ToString();
                else
                    Rol = "";
              
            }
            TiempoSesion = BuscarConfiguracion();

        }

        private string BuscarConfiguracion()
        {
            string valor = HttpContext.Current.Session.Timeout.ToString();
            return valor;
        }

        public static clUsuario ObtenerUsuarioSesion()
        {
            return HttpContext.Current.Session["User"] as clUsuario;
        }

        public static void CrearSesionUsuario(clUsuario Persona)
        {
            HttpContext.Current.Session[strKEY] = Persona;
        }

        public static Boolean SetBloquedOn(int intid, int intaccion)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_User", intid);
            diParametros.Add("@accion", intaccion);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_C_UserProperties", diParametros);
            return (dtresult.Rows.Count > 0);

        }
        public static Boolean SetBloquedOff(int intid, int intaccion)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_User", intid);
            diParametros.Add("@accion", intaccion);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_C_UserProperties", diParametros);
            return (dtresult.Rows.Count > 0);

        }
        public static Boolean SetActiveOn(int intid, int intaccion)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_User", intid);
            diParametros.Add("@accion", intaccion);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_C_UserProperties", diParametros);
            return (dtresult.Rows.Count > 0);

        }
        public static Boolean SetActiveOff(int intid, int intaccion)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_User", intid);
            diParametros.Add("@accion", intaccion);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_C_UserProperties", diParametros);
            return (dtresult.Rows.Count > 0);

        }
        public static Boolean SetDeleted(int intid, int intaccion)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_User", intid);
            diParametros.Add("@accion", intaccion);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_C_UserProperties", diParametros);
            return (dtresult.Rows.Count > 0);

        }
        public static Boolean SetInternalOn(int intid, int intaccion)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_User", intid);
            diParametros.Add("@accion", intaccion);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_C_UserProperties", diParametros);
            return (dtresult.Rows.Count > 0);

        }
        public static Boolean SetInternalOff(int intid, int intaccion)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_User", intid);
            diParametros.Add("@accion", intaccion);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_C_UserProperties", diParametros);
            return (dtresult.Rows.Count > 0);

        }
        public static clUsuario getUsuario(String stUserName)
        {

            return new clUsuario(stUserName);
        }
        public static Boolean CambiarContraseña(String stUserName, String stNuevaContraseña)
        {
            Dictionary<String, object> diParametros = new Dictionary<String, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_User", stUserName);
            diParametros.Add("@user_Password", stNuevaContraseña);

            DataTable dtUsuario = obConn.GetSPDataTable("REG_SP_C_Password", diParametros);

            return Convert.ToBoolean(dtUsuario.Rows.Count > 0);

        }

        public static Boolean ValidaAcceso(String stUserName, String stContraseña)
        {
           
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Boolean validacion = false;
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@UserName", stUserName);
          

            DataTable dtresult = obConn.GetSPDataTable("USP_GetPassword", diParametros);
            string password = dtresult.Rows[0]["usuarios_password"].ToString();

            if (stContraseña == clEncryption.DecodeFrom64(password))
                
            {
               // clEncryption.EncodePasswordToBase64(stContraseña);
                validacion = true;
            }


            return validacion;
        }
        public static Boolean ValidaPregunta(String stUserName, String stAnswer)
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@UserName", stUserName);
            diParametros.Add("@Answer", stAnswer);

            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_ValidaPregunta", diParametros);

            return Convert.ToBoolean(dtresult.Rows[0]["Answer"]);
        }
        public static string GetPregunta(string stUserName)
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@UserName", stUserName);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_Question", diParametros);
            string stresult = string.Empty;
            if (dtresult.Rows.Count > 0)
                stresult = dtresult.Rows[0]["Question"].ToString();
            return stresult;

        }

        public DataTable GetUsuariosAdministrar(string stUserName)
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@palabra", stUserName);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_BusquedaUsuarios", diParametros);

            return dtresult;

        }
        public DataTable GetLanguage()
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_Language", diParametros);
            return dtresult;

        }
        public static DataTable GetPreguntas()
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_Preguntas", diParametros);
            string stresult = string.Empty;
            if (dtresult.Rows.Count > 0)
                return dtresult;
            else
                return new DataTable();

        }
        public static DataTable GetBloqued(int intid)
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");

            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@id_User", intid);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_Bloqued", diParametros);

            if (dtresult.Rows.Count > 0)
                return dtresult;
            else
                return new DataTable();

        }
        #endregion


       
    } 
}
