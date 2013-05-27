using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Restaurant.Datos;
namespace Restaurant.Negocio
{
    public class clReportes
    {
        static string NombreConexion = "Restaurant";

        public static DataTable GetMeseros()
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);

            DataTable dtUsuario = obConn.GetSPDataTable("USP_GetMeseros", diParametros);

            return dtUsuario;

        }
        public static DataTable GetTurnos()
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);

            DataTable dtUsuario = obConn.GetSPDataTable("USP_GetTurnos", diParametros);

            return dtUsuario;

        }
        public static DataTable GetBebidas()
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);

            DataTable dtUsuario = obConn.GetSPDataTable("USP_GetBebidas", diParametros);

            return dtUsuario;

        }
        public static DataTable GetPlatillos()
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);

            DataTable dtUsuario = obConn.GetSPDataTable("USP_GetPlatillos", diParametros);

            return dtUsuario;

        }
        public static DataTable GetSuplementos()
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);

            DataTable dtUsuario = obConn.GetSPDataTable("USP_GetSuplementos", diParametros);

            return dtUsuario;

        }
        public static Boolean SetUpdatePedido(string id_pedido, string id_suplementos, string id_horario, string id_mesas, string id_platillos, bool pedido_activo, string id_usuarios, bool pedido_cerrarpedido, string pedido_silla)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@sid_pedidos", id_pedido);
            diParametros.Add("@sid_suplementos", id_suplementos);
            diParametros.Add("@sid_horario", id_horario);
            diParametros.Add("@sid_mesas", id_mesas);
            diParametros.Add("@sid_platillos", id_platillos);
            diParametros.Add("@spedido_activo", pedido_activo);
            diParametros.Add("@sid_usuarios", id_usuarios);
            diParametros.Add("@spedido_cerrarpedido", pedido_cerrarpedido);
            diParametros.Add("@spedido_silla", pedido_silla);

            DataTable dtUsuario = obConn.GetSPDataTable("USP_SetUpdatePedido", diParametros);

            return (dtUsuario.Rows.Count > 0);

        }
        public static DataTable GetClientes(string clientes_rfc)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@sclientes_rfc", clientes_rfc);
            DataTable dtUsuario = obConn.GetSPDataTable("USP_GetCliente", diParametros);

            return dtUsuario;

        }
        public static DataTable GetPedido(string id_mesa)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_mesa", id_mesa);
            DataTable dtUsuario = obConn.GetSPDataTable("USP_GetPedido", diParametros);

            return dtUsuario;

        }
  
        public static DataTable GetCuenta(string sid_mesa)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@sid_mesa", sid_mesa);
            DataTable dtUsuario = obConn.GetSPDataTable("USP_GetCuenta", diParametros);

            return dtUsuario;

        }
        public static bool CancelPedido(string id_pedido)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@sid_pedidos", id_pedido);
            DataTable dtUsuario = obConn.GetSPDataTable("USP_CancelPedido", diParametros);

            return (dtUsuario.Rows.Count>0);

        }
        public static Int32 SetUpdateCliente(string id_clientes, string clientes_razonsocial,string sclientes_direccion, string clientes_colonia, string clientes_delegacion, string clientes_ciudad, string clientes_cp, string clientes_rfc)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            if (string.IsNullOrEmpty(id_clientes))
                id_clientes = "0";
            diParametros.Add("@sid_clientes", id_clientes);
            diParametros.Add("@sclientes_razonsocial", clientes_razonsocial);
            diParametros.Add("@sclientes_direccion", sclientes_direccion);
            diParametros.Add("@sclientes_colonia", clientes_colonia);
            diParametros.Add("@sclientes_delegacion", clientes_delegacion);
            diParametros.Add("@sclientes_ciudad", clientes_ciudad);
            diParametros.Add("@sclientes_cp", clientes_cp);
            diParametros.Add("@sclientes_rfc", clientes_rfc);

            
            DataTable dtUsuario = obConn.GetSPDataTable("USP_SetUpdateCliente", diParametros);

            return Convert.ToInt32(dtUsuario.Rows[0][0]);

        }
        public static Int32 SetFactura(string sfactura_montototal, bool sfactura_bit, string sid_clientes, string sid_iva)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@sfactura_montototal", sfactura_montototal);
            diParametros.Add("@sfactura_bit", sfactura_bit);
            diParametros.Add("@sid_clientes", sid_clientes);
            diParametros.Add("@sid_iva", sid_iva);
 

            DataTable dtUsuario = obConn.GetSPDataTable("USP_SetFactura", diParametros);

            return Convert.ToInt32(dtUsuario.Rows[0][0]);

        }
        public static void CerrarCuenta(string id_mesa, string id_factura)
        {
            Dictionary<string, object> diParametros = new Dictionary<string, object>();
            clConexionMySQL obConn = new clConexionMySQL(NombreConexion);
            diParametros.Add("@id_mesa", id_mesa);
            diParametros.Add("@id_factura", id_factura);
            DataTable dtUsuario = obConn.GetSPDataTable("USP_CerrarCuenta", diParametros);


        }

    }
}

