using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Restaurant.Negocio;
using System.Reflection;

namespace Restaurant.Pages.Pantalla
{
    public partial class Cocina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarOrden();
                
            }
        }
    

        private void PushButton()
        {
            Type t = typeof(Button);
            object[] p = new object[1];
            p[0] = EventArgs.Empty;
            MethodInfo m = t.GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
            m.Invoke(BtnActualizar, p);
        }

        private void CrearDataTable()
        {
            // Initialize a DataTable
            DataTable myDataTable = new DataTable();

            // Initialize DataColumn
            DataColumn myDataColumn = new DataColumn();

            // Add First DataColumn
            // AllowDBNull property

            myDataColumn.ColumnName = "id_pedido";
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "id_suplementos";
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.AllowDBNull = true;
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "id_horario";
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "id_mesas";
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "pedido_silla";
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "id_platillos";
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "pedido_activo";
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "id_usuarios";
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "pedido_cerrarpedido";
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "platillos_nombre";
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "suplementos_nombre";
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "pedido_cocina";
            myDataColumn.DataType = System.Type.GetType("System.Boolean");
            myDataTable.Columns.Add(myDataColumn);

            Session["myDataTableCocina"] = myDataTable;

        }
        private void LlenarOrden()
        {
            DataTable myDataTable;
            CrearDataTable();
             
            myDataTable = clCocina.GetPedidos();
           Session["myDataTableCocina"] = myDataTable;
            GViewPedido.DataSource = myDataTable;
            GViewPedido.DataBind();

        }
        protected void GViewPedido_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            DataTable myDataTable;
            bool boolvalor;
            myDataTable=(DataTable)Session["myDataTableCocina"];
            boolvalor = clCocina.PedidoTerminado(myDataTable.Rows[e.RowIndex]["id_pedido"].ToString());
            myDataTable = clCocina.GetPedidos();
            Session["myDataTableCocina"] = myDataTable;
            GViewPedido.DataSource = myDataTable;
            GViewPedido.DataBind();
           
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            LlenarOrden();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            LlenarOrden();
            //PushButton();
            //  ClientScript.RegisterClientScriptBlock(this.GetType(),"Autoposteate","__doPostBack('','');");
           // Response.Redirect("/Pages/Pantalla/Cocina.aspx");
        }
    }
}