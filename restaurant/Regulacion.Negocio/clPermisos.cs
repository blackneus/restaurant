using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Restaurant.Datos;

namespace Restaurant.Negocio
{
    public class clPermisos
    {


        public DataTable GetAllPerm(int intRoles)
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@id_Rol", intRoles);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_AllPerm", diParametros);
            
            return dtresult;

        }
        public Boolean SetPerm(string intRolePerm,int intValue)
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@id_RolePerm", intRolePerm);
            diParametros.Add("@RolePerm_Value", intValue);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_C_Perm", diParametros);

            return (dtresult.Rows.Count>0);

        }
        public DataTable GetRolePerm(int intRoles)
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            diParametros.Add("@RolePerm_IdRole", intRoles);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_RolePerm", diParametros);

            return dtresult;

        }
        public DataTable GetRoles()
        {
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_S_Roles", diParametros);
            
            return dtresult;

        }
        //public static class Permission
        //{
        //    public static int CanREAD = 1;
        //    public static int CanADD = 2;
        //    public static int CanWRITE = 3;   // Editar
        //    public static int CanDELETE = 4;
            
        //}


        private static Dictionary<int, String> _AllPermisions;

        public static Dictionary<int, String> AllPermisions
        {
            get { return clPermisos._AllPermisions; }
            set { clPermisos._AllPermisions = value; }
        }

        public void LLenarPermisos()
        {
            AllPermisions.Add(1, "CanRead");
            AllPermisions.Add(2, "CanAdd");
            AllPermisions.Add(3, "CanWrite");
            AllPermisions.Add(4, "CanDelete");
        
        }
        public static Boolean SetActiveOn(int intid)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            diParametros.Add("@id_Role", intid);
            diParametros.Add("@Role_Active", true);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_ABC_Roles", diParametros);
            return (dtresult.Rows.Count > 0);

        }
        public static Boolean SetActiveOff(int intid)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            diParametros.Add("@id_Role", intid);
            diParametros.Add("@Role_Active", false);
            DataTable dtresult = obConn.GetSPDataTable("REG_SP_ABC_Roles", diParametros);
            return (dtresult.Rows.Count > 0);

        }
    }
}
