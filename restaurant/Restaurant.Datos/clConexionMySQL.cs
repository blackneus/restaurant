
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace Restaurant.Datos
{
   

    // ----------------------------------------------------------------------------------------
    // Author:                    Irving Solorio
    // Company:                   NeusCo
    // Assembly version:          
    // Date:                      07/10/2011
    // Time:                      13:20
    // Project Item Name:         MySQLConection.cs
    // Project Item Filename:     MySQLConection.cs
    // Project Item Kind:         Código
    // Class FullName:            MySQLConection
    // Class Name:                MySQLConection
    // Class Kind Description:    Clase
    // Class Kind Keyword:        class
    // Purpose:                   Clase para la interaccion con la Base de Datos en SQL
    // ----------------------------------------------------------------------------------------
         public class clConexionMySQL
        {
            #region Variables

            /// <summary>
            /// Variable de conexión MySQL.
            /// </summary>
            private MySqlConnection cn_Connection;
            /// <summary>
            /// Variable para ejecución  de comandos SQL.
            /// </summary>
            
            private MySqlCommand  cm_Command;
            /// <summary>
            /// Variable intermedia para rellener un dataset.
            /// </summary>
             
            private MySqlDataAdapter da_Connector;
            /// <summary>
            /// Variable que contiene un RecordSet con el resultado de una consulta.
            /// </summary>
           
            private MySqlDataReader  dr_Recordset;
            /// <summary>
            /// Variable Dataset para devolver el resultado de las consultas.
            /// </summary>
            private DataSet ds_Recordset = new DataSet();

            #endregion

            #region Metodos

            ///<summary>Constructor </summary>
            ///<remarks></remarks>
            ///<returns></returns>
            ///<param name="stConexion">Nombre de la cadena de conexion almacenada en el Webconfig en la seccion de conection Strings</param>
            public clConexionMySQL(string sConexion)
            {
                try
                {
                    cn_Connection = new   MySqlConnection(WebConfigurationManager.ConnectionStrings[sConexion].ConnectionString);
                }
                catch (Exception ex)
                {
                    //System.Diagnostics.Debug.Write(ex.Message.ToString());
                    throw ex;
                }
            }

            public clConexionMySQL(string sConexion, Boolean boWebConfig)
            {
                try
                {
                    if (boWebConfig)
                        cn_Connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings[sConexion].ConnectionString);
                    else cn_Connection = new MySqlConnection(sConexion);
                }
                catch (Exception ex)
                {
                    //System.Diagnostics.Debug.Write(ex.Message.ToString());
                    throw ex;
                }
            }

            private MySqlCommand  GetCommand(string stConsulta)
            {
                cm_Command = new MySqlCommand (stConsulta, cn_Connection);
                return cm_Command;
            }

            private MySqlDataAdapter GetDataAdapter(string stConsulta)
            {
                da_Connector = new MySqlDataAdapter(GetCommand(stConsulta));
                return da_Connector;
            }

            #region Stored Procedures

            public DataSet GetSPDataSet(string stSPNombre)
            {
                cm_Command = GetCommand(stSPNombre);
                cm_Command.CommandType = CommandType.StoredProcedure;
                da_Connector = new MySqlDataAdapter(cm_Command);
                ds_Recordset.Clear();
                da_Connector.Fill(ds_Recordset);
                return ds_Recordset;
            }

            public DataTable GetSPDataTable(string stConsulta, Dictionary<string, object> diParametros)
            {
                DataTable dt = new DataTable();
                cm_Command = GetCommand(stConsulta);
                cm_Command.CommandType = CommandType.StoredProcedure;
                foreach (KeyValuePair<string, object> key_parameter in diParametros)
                    cm_Command.Parameters.AddWithValue(key_parameter.Key, key_parameter.Value);
                da_Connector = new MySqlDataAdapter(cm_Command);
                try
                {
                    da_Connector.Fill(dt);
                }
                catch (Exception ex) { throw ex; }
                return dt;
            }

            public DataSet GetSPDataSet(string stSPNombre, Dictionary<string, object> diParametros)
            {
                cm_Command = GetCommand(stSPNombre);
                cm_Command.CommandType = CommandType.StoredProcedure;
                foreach (KeyValuePair<string, object> key_parameter in diParametros)
                    cm_Command.Parameters.AddWithValue(key_parameter.Key, key_parameter.Value);
                da_Connector = new MySqlDataAdapter(cm_Command);
                try
                {
                    ds_Recordset.Clear();
                    da_Connector.Fill(ds_Recordset);
                }
                catch (Exception ex) { throw ex; }
                return ds_Recordset;
            }

            public MySqlDataReader  GetSPDataReader(string stSPNombre)
            {
                cn_Connection.Open();
                cm_Command = GetCommand(stSPNombre); 
                cm_Command.CommandType = CommandType.StoredProcedure;
                try
                {
                    dr_Recordset = cm_Command.ExecuteReader();
                }
                catch (Exception ex) { throw ex; }
                finally { cn_Connection.Close(); }
                return dr_Recordset;
            }

            public MySqlDataReader  GetSPDataReader(string stSPNombre, Dictionary<string, string> diParametros)
            {
                cn_Connection.Open();
                cm_Command = GetCommand(stSPNombre);
                cm_Command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, string> key_parameter in diParametros)
                    cm_Command.Parameters.AddWithValue(key_parameter.Key, key_parameter.Value);
                try
                {
                    dr_Recordset = cm_Command.ExecuteReader();
                }
                catch (Exception ex) { throw ex; }
                finally { cn_Connection.Close(); }
                return dr_Recordset;
            }

            public int ExeCommandSP(string stSPNombre, Dictionary<string, object> diParametros)
            {
                int in_Temp;
                cn_Connection.Open();
                cm_Command = GetCommand(stSPNombre);
                cm_Command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> key_parameter in diParametros)
                    cm_Command.Parameters.AddWithValue(key_parameter.Key, key_parameter.Value);
                try
                {
                    in_Temp = cm_Command.ExecuteNonQuery();
                }
                catch (Exception ex) { throw ex; }
                finally { cn_Connection.Close(); }

                return in_Temp;
            }

            public object ExeScalarSP(string stSPNombre, Dictionary<string, object> diParametros)
            {
                cn_Connection.Open();
                cm_Command = GetCommand(stSPNombre);
                cm_Command.CommandType = CommandType.StoredProcedure;
                cm_Command.CommandTimeout = 60;
                object in_Temp;
                foreach (KeyValuePair<string, object> key_parameter in diParametros)
                    cm_Command.Parameters.AddWithValue(key_parameter.Key, key_parameter.Value);
                try
                {
                    in_Temp = cm_Command.ExecuteScalar();
                }
                catch (Exception ex) { throw ex; }
                finally { cn_Connection.Close(); }
                return in_Temp;
            }

            #endregion

            #region Consultas

            public DataSet GetDataSet(string stConsulta, Dictionary<string, object> diParametros)
            {
                DataSet ds_Recordset = new DataSet();
                cm_Command = GetCommand(stConsulta);
                cm_Command.CommandTimeout = 100;
                cm_Command.CommandType = CommandType.Text;

                foreach (KeyValuePair<string, object> key_parameter in diParametros)
                    cm_Command.Parameters.AddWithValue(key_parameter.Key, key_parameter.Value);
                try
                {
                    da_Connector = new MySqlDataAdapter(cm_Command);
                    da_Connector.Fill(ds_Recordset);
                    return ds_Recordset;
                }
                catch (Exception ex) { throw ex; }

            }

            public DataSet GetDataSet(string stConsulta, string s_Name)
            {
                da_Connector = GetDataAdapter(stConsulta);
                ds_Recordset.Clear();
                da_Connector.Fill(ds_Recordset, s_Name);
                return ds_Recordset;
            }

            public DataTable GetDataTable(string stConsulta)
            {
                DataTable dt = new DataTable();
                da_Connector = GetDataAdapter(stConsulta);
                da_Connector.Fill(dt);
                return dt;
            }

            public DataTable GetDataTable(string stConsulta, Dictionary<string, object> diParametros)
            {
                DataTable dt = new DataTable();
                cm_Command = GetCommand(stConsulta);
                cm_Command.CommandType = CommandType.Text;
                foreach (KeyValuePair<string, object> key_parameter in diParametros)
                    cm_Command.Parameters.AddWithValue(key_parameter.Key, key_parameter.Value);
                da_Connector = new MySqlDataAdapter(cm_Command);
                try
                {
                    da_Connector.Fill(dt);
                }
                catch (Exception ex) { throw ex; }
                return dt;
            }

            public MySqlDataReader  GetDataReader(string stConsulta)
            {
                cn_Connection.Open();
                dr_Recordset = GetCommand(stConsulta).ExecuteReader();
                return dr_Recordset;
            }

            public int ExeCommand(string stConsulta, Dictionary<string, object> diParametros)
            {
                int in_Temp;
                cn_Connection.Open();
                cm_Command = GetCommand(stConsulta);
                cm_Command.CommandType = CommandType.Text;

                foreach (KeyValuePair<string, object> key_parameter in diParametros)
                    cm_Command.Parameters.AddWithValue(key_parameter.Key, key_parameter.Value);
                try
                {
                    in_Temp = cm_Command.ExecuteNonQuery();
                }
                catch (Exception ex) { throw ex; }
                finally { cn_Connection.Close(); }
                return in_Temp;
            }

            public int ExeCommand(string stConsulta)
            {
                int in_Temp;
                cn_Connection.Open();
                cm_Command = GetCommand(stConsulta);
                cm_Command.CommandType = CommandType.Text;
                try
                {
                    in_Temp = cm_Command.ExecuteNonQuery();
                }
                catch (Exception ex) { throw ex; }
                finally { cn_Connection.Close(); }
                return in_Temp;
            }

            public object ExeScalar(string stConsulta, Dictionary<string, object> diParametros)
            {
                cn_Connection.Open();
                cm_Command = GetCommand(stConsulta);
                cm_Command.CommandType = CommandType.Text;
                object in_Temp;
                foreach (KeyValuePair<string, object> key_parameter in diParametros)
                    cm_Command.Parameters.AddWithValue(key_parameter.Key, key_parameter.Value);
                try
                {
                    in_Temp = cm_Command.ExecuteScalar();
                }
                catch (Exception ex) { throw ex; }
                finally { cn_Connection.Close(); }
                return in_Temp;
            }

            public object ExeScalar(string stConsulta)
            {
                cn_Connection.Open();
                cm_Command = GetCommand(stConsulta);
                cm_Command.CommandType = CommandType.Text;

                object in_Temp;
                try
                {
                    in_Temp = cm_Command.ExecuteScalar();
                }
                catch (Exception ex) { throw ex; }
                finally { cn_Connection.Close(); }
                return in_Temp;
            }

            public void CloseConnection()
            {
                if (cn_Connection.State == ConnectionState.Open)
                    cn_Connection.Close();
            }

            #endregion

            #endregion
        }
    }


