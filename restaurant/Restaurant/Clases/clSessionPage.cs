using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Negocio;

namespace Restaurant.Clases
{
    public class clSessionPage : System.Web.UI.Page
    {

        public  clUsuario User
        {
            get { clUsuario objempPK = HttpContext.Current.Session["User"] == null ? null : HttpContext.Current.Session["User"] as clUsuario; return objempPK; }
            set { HttpContext.Current.Session["User"] = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            clUsuario clsPersona = clUsuario.ObtenerUsuarioSesion();
            if (clsPersona == null)
                Response.Redirect("~/Default.aspx");
            else
                Session["User"] = clsPersona;
        }

        protected string ConvertSortDirectionToSql(System.Web.UI.WebControls.SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case System.Web.UI.WebControls.SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case System.Web.UI.WebControls.SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

        public static void crearArchivoExcelDesdeDataTable(DataTable dt, String nombreDelArchivo)
        {
            string attachment = "attachment; filename=" + nombreDelArchivo + ".xls";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";

            string tab = "";

            foreach (DataColumn dc in dt.Columns)
            {
                HttpContext.Current.Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            HttpContext.Current.Response.Write("\n");

            int i;

            foreach (DataRow dr in dt.Rows)
            {
                tab = "";

                for (i = 0; i < dt.Columns.Count; i++)
                {
                    
                    string stRenglonSinHTML = eliminarEtiquetasHTML(dr[i].ToString());

                    if(stRenglonSinHTML.Contains("True"))
                      stRenglonSinHTML = stRenglonSinHTML.Replace("True", "Si");
                    else if(stRenglonSinHTML.Contains("False"))
                       stRenglonSinHTML = stRenglonSinHTML.Replace("False", "No");

                    HttpContext.Current.Response.Write(tab + stRenglonSinHTML);
                    tab = "\t";
                }
                HttpContext.Current.Response.Write("\n");
            }
            HttpContext.Current.Response.End();
        }

        public static string eliminarEtiquetasHTML(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
        public object PosicionInicialOrganigramaPlaneacion
        {
            get { return Session["PosicionInicialOrganigramaPlaneacion"] as String; }
            set { Session["PosicionInicialOrganigramaPlaneacion"] = value; }
        }
    } 
}