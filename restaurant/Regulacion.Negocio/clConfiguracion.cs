using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Datos;
using System.Data;

namespace Restaurant.Negocio
{
    public class clConfiguracion
    {
        #region Variables

        clConexionMySQL obConn = new clConexionMySQL("Restaurant");
        private static String NombreConexion = "Restaurant";
        #endregion

        #region Metodos


        public static Boolean ActualizarDatos(clUsuario cluUsuario)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_PersonalData", cluUsuario.IdUsuario );
            diParametros.Add("@PersonalData_Name", cluUsuario.Name);
            diParametros.Add("@PersonalData_LastName",cluUsuario.LastName);
            diParametros.Add("@PersonalData_MiddleName", cluUsuario.MiddleName);
            diParametros.Add("@PersonalData_Level",cluUsuario.Rol);
            diParametros.Add("@user_Login", cluUsuario.Login);
            diParametros.Add("@user_Mail",cluUsuario.Rol);
            
            DataTable dtUsuario = obConn.GetSPDataTable("REG_SP_AC_DatosPersonales", diParametros);

            return (dtUsuario.Rows.Count > 0);

        }
        public static Boolean NuevoUsuario(clUsuario cluUsuario)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_PersonalData", cluUsuario.IdUsuario);
            diParametros.Add("@PersonalData_Name", cluUsuario.Name);
            diParametros.Add("@PersonalData_LastName", cluUsuario.LastName);
            diParametros.Add("@PersonalData_MiddleName", cluUsuario.MiddleName);
            diParametros.Add("@PersonalData_Level", cluUsuario.Rol);
            diParametros.Add("@user_Login", cluUsuario.Login);
            diParametros.Add("@user_Password", cluUsuario.Password);
            diParametros.Add("@user_Mail", cluUsuario.Rol);
            diParametros.Add("@user_InternalEmp", cluUsuario.Internal);
            diParametros.Add("@user_idLang", cluUsuario.IdLang);
            diParametros.Add("@rel_IdRole", cluUsuario.IdRol);

            DataTable dtUsuario = obConn.GetSPDataTable("REG_SP_AC_DatosPersonales", diParametros);

            return (dtUsuario.Rows.Count > 0);

        }
        public static Boolean SetPregunta(int intidUser,int intPregunta,string stRespuesta)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_User", intidUser);
            diParametros.Add("@user_idQuestion", intPregunta);
            diParametros.Add("@user_Answer", stRespuesta);

            DataTable dtUsuario = obConn.GetSPDataTable("REG_SP_C_Preguntas", diParametros);

            return (dtUsuario.Rows.Count > 0);

        }
        public static Boolean SetUserRoles(int intidUser, int intRol)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@rel_idUser", intidUser);
            diParametros.Add("@rel_idRole", intRol);
            

            DataTable dtUsuario = obConn.GetSPDataTable("REG_SP_AC_UserRoles", diParametros);

            return (dtUsuario.Rows.Count > 0);

        }
        public static DataTable  GetRoles(string stBusca)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@Role_label", stBusca);
            DataTable dtUsuario = obConn.GetSPDataTable("REG_SP_S_Roles", diParametros);

            return dtUsuario;

        }
        public static DataTable GetUserRoles(string stBusca)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@palabra", stBusca);
            DataTable dtUsuario = obConn.GetSPDataTable("REG_SP_S_BusquedaUsuarios", diParametros);

            return dtUsuario;

        }
        public static DataTable GetRolesActivos()
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            
            DataTable dtUsuario = obConn.GetSPDataTable("REG_SP_S_RolesActivos", diParametros);

            return dtUsuario;

        }
        public static Boolean SetRoles(int idRole,string RoleLabel)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_Role", idRole);
            diParametros.Add("@Role_label", RoleLabel);

            DataTable dtUsuario = obConn.GetSPDataTable("REG_SP_ABC_Roles", diParametros);

            return (dtUsuario.Rows.Count > 0);

        }
        public static DataTable GetCatalogo()
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@tabla", "cat_catalogo");
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_Select", diParametros);

            return dtresult;

        }
        public static DataTable GetTabla(String stTabla,String stFiltro)
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@tabla", stTabla);
            if (!String.IsNullOrEmpty(stFiltro))
                diParametros.Add("@wherefts", stFiltro);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_Select", diParametros);

            return dtresult;
        }
        public static int ActualizarInsertar(string[] stValores, String stUsuarioID, String stTabla)
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            switch (stValores.Length)
            {
                case 1:
                    diParametros.Add("@dato1", stValores[0]);
                    break;
                case 3:
                    diParametros.Add("@dato1", stValores[0]);
                    diParametros.Add("@int1", stValores[1]);
                    diParametros.Add("@active", stValores[3]);
                    break;
                case 4:
                    diParametros.Add("@dato1", stValores[1]);
                    diParametros.Add("@where", String.Format("{0}={1}", stValores[2], stValores[0]));
                    diParametros.Add("@active", stValores[3]);
                    break;
                case 5:
                    diParametros.Add("@dato1", stValores[1]);
                    diParametros.Add("@int1", stValores[2]);
                    diParametros.Add("@where", String.Format("{0}={1}", stValores[3], stValores[0]));
                    diParametros.Add("@active", stValores[3]);
                    break;
            }


            diParametros.Add("@tabla", stTabla);
            diParametros.Add("@id_usuario", stUsuarioID);

            int inumRows = obConn.ExeCommandSP("REG_SP_AC_Catalogos", diParametros);
            return inumRows;
        }
        #endregion
    }
}
