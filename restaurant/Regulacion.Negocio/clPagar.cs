using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Datos;
using System.Data;

namespace Restaurant.Negocio
{
    public class clPagar
    {
        
            #region Variables

            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            private static String NombreConexion = "Restaurant";
            #endregion

            #region Metodos


            public static DataTable GetTipoPago()
            {
                Dictionary<string, object> diParametros = new Dictionary<string, object>();
                clConexionMySQL obConn = new clConexionMySQL(NombreConexion);

                DataTable dtUsuario = obConn.GetSPDataTable("USP_GetTipoPago", diParametros);

                return dtUsuario;

            }
            public static string Get_ClienteMesa(string id_mesa)
            {
                Dictionary<string, object> diParametros = new Dictionary<string, object>();
                clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
                diParametros.Add("@id_mesa", id_mesa);
                DataTable dtUsuario = obConn.GetSPDataTable("USP_GetClienteMesa", diParametros);

                return dtUsuario.Rows[0][0].ToString();

            }
            public static DataTable GetCuenta(string sid_mesa)
            {
                Dictionary<string, object> diParametros = new Dictionary<string, object>();
                clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
                diParametros.Add("@id_mesa", sid_mesa);
                DataTable dtUsuario = obConn.GetSPDataTable("USP_GetCuentaFactura", diParametros);

                return dtUsuario;

            }
            public static Boolean SetPago(string spago_monto, string sid_tipopago, string sid_factura)
            {
                Dictionary<string, object> diParametros = new Dictionary<string, object>();
                clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
                diParametros.Add("@spago_monto", spago_monto);
                diParametros.Add("@sid_tipopago", sid_tipopago);
                diParametros.Add("@sid_factura", sid_factura);
      

                DataTable dtUsuario = obConn.GetSPDataTable("USP_SetPago", diParametros);

                return (dtUsuario.Rows.Count > 0);

            }
            #endregion
        }
    
}
