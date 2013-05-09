using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Datos;
using System.Data;

namespace Restaurant.Negocio
{
    public class clCocina
    {
        
            #region Variables

            clConexionMySQL obConn = new clConexionMySQL("Restaurant");
            private static String NombreConexion = "Restaurant";
            #endregion

            #region Metodos


            public static DataTable GetPedidos()
            {
                Dictionary<string, object> diParametros = new Dictionary<string, object>();
                clConexionMySQL obConn = new clConexionMySQL(NombreConexion);

                DataTable dtUsuario = obConn.GetSPDataTable("USP_GetPedidos", diParametros);

                return dtUsuario;

            }
            public static bool PedidoTerminado(string id_pedido)
            {
                Dictionary<string, object> diParametros = new Dictionary<string, object>();
                clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
                diParametros.Add("@sid_pedidos", id_pedido);
                DataTable dtUsuario = obConn.GetSPDataTable("USP_PedidoTerminado", diParametros);

                return (dtUsuario.Rows.Count > 0);

            }
            #endregion
        }
    
}
