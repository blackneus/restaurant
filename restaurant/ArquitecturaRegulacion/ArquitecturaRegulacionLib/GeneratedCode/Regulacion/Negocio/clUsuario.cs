﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó mediante una herramienta.
//     Los cambios del archivo se perderán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Regulacion.Negocio
{
	using Regulacion.Datos;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Text;

	public class clUsuario
	{
		public virtual bool DesactivarRoles
		{
			get;
			set;
		}

		public virtual string IdUsuario
		{
			get;
			set;
		}

		public virtual string Name
		{
			get;
			set;
		}

		public virtual string LastName
		{
			get;
			set;
		}

		public virtual string MiddleName
		{
			get;
			set;
		}

		public virtual string FullName
		{
			get;
			set;
		}

		public virtual string Login
		{
			get;
			set;
		}

		public virtual string Mail
		{
			get;
			set;
		}

		public static bool Active
		{
			get;
			set;
		}

		public virtual string IdLang
		{
			get;
			set;
		}

		public virtual bool Internal
		{
			get;
			set;
		}

		public virtual string ChangePass
		{
			get;
			set;
		}

		public virtual string Password
		{
			get;
			set;
		}

		public virtual string LastAcces
		{
			get;
			set;
		}

		public virtual string Language
		{
			get;
			set;
		}

		public static int Intentos
		{
			get;
			set;
		}

		public static bool Bloqued
		{
			get;
			set;
		}

		public virtual string Level
		{
			get;
			set;
		}

		private clConexionSQL obConn;

		private static string NombreConexion;

		private bool boDesactivarRoles;

		public Dictionary<string, bool> diccionarioModulos;

		public Dictionary<string, bool> diccionarioPermisos;

		private string stIdUsuario;

		private string stPersonalData_Name;

		private string stPersonalData_LastName;

		private string stPersonalData_MiddleName;

		private string stPersonalData_FullName;

		private string stUserLogin;

		private string stUserMail;

		private static bool _bolactivo;

		private string stuser_idLang;

		private bool stuserInternalEmp;

		private string stuserChangePass;

		private string stPassword;

		private string stuserLastAcces;

		private string stLanguage;

		private static int _inIntentos;

		private static bool _bobloqued;

		private static string _inLevel;

		public clUsuario()
		{
		}

		public clUsuario(string stUserName)
		{
		}

		public static bool SetBloquedOn(int intid, int intaccion)
		{
			throw new System.NotImplementedException();
		}

		public static bool SetBloquedOff(int intid, int intaccion)
		{
			throw new System.NotImplementedException();
		}

		public static bool SetActiveOn(int intid, int intaccion)
		{
			throw new System.NotImplementedException();
		}

		public static bool SetActiveOff(int intid, int intaccion)
		{
			throw new System.NotImplementedException();
		}

		public static bool SetDeleted(int intid, int intaccion)
		{
			throw new System.NotImplementedException();
		}

		public static bool SetInternalOn(int intid, int intaccion)
		{
			throw new System.NotImplementedException();
		}

		public static bool SetInternalOff(int intid, int intaccion)
		{
			throw new System.NotImplementedException();
		}

		public static clUsuario getUsuario(string stUserName)
		{
			throw new System.NotImplementedException();
		}

		public static bool ValidaPregunta(string stUserName, string stAnswer)
		{
			throw new System.NotImplementedException();
		}

		public static string GetPregunta(string stUserName)
		{
			throw new System.NotImplementedException();
		}

		public virtual DataTable GetUsuariosAdministrar(string stUserName)
		{
			throw new System.NotImplementedException();
		}

		public virtual DataTable GetLanguage()
		{
			throw new System.NotImplementedException();
		}

		public static DataTable GetPreguntas()
		{
			throw new System.NotImplementedException();
		}

		public static DataTable GetBloqued(int intid)
		{
			throw new System.NotImplementedException();
		}

		public clUsuario()
		{
		}

		public virtual void Operation1()
		{
			throw new System.NotImplementedException();
		}

	}
}
