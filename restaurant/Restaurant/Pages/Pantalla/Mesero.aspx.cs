using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Negocio;
using Restaurant.Clases;
using System.Data;

namespace Restaurant.Pages.Pantalla
{
    public partial class Mesero : clSessionPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (IsPostBack)
            {
                LlenarMenu();   // Se sobreescribe el metodo y se crea el evento para que se realice
            }
        }
        //protected override void OnLoad(EventArgs e)
        //{
        //    if (IsPostBack)
        //    {
        //        LlenarMenu();   // Se sobreescribe el metodo y se crea el evento para que se realice
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarMenu();
                LlenarDDL();
                BtnAceptar.Visible = false;
                //PnlDatosUsuario.Enabled = false;
            }
        }

        private void CrearDataTable(string mesa)
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
            Session["myDataTable" + mesa] = myDataTable;

        }

        private void LlenarDDL()
        {
            DDLTurno.DataSource = clMeseros.GetTurnos();
            DDLTurno.DataTextField = "horario_nombre";
            DDLTurno.DataValueField = "id_horario";
            DDLTurno.DataBind();
            DDLTurno.Items.Insert(0, new ListItem());

            DDLBebida.DataSource = clMeseros.GetBebidas();
            DDLBebida.DataTextField = "platillos_nombre";
            DDLBebida.DataValueField = "id_platillos";
            DDLBebida.DataBind();
            DDLBebida.Items.Insert(0, new ListItem());

            DDLPlatillo.DataSource = clMeseros.GetPlatillos();
            DDLPlatillo.DataTextField = "platillos_nombre";
            DDLPlatillo.DataValueField = "id_platillos";
            DDLPlatillo.DataBind();
            DDLPlatillo.Items.Insert(0, new ListItem());

            DDLGuarnicion.DataSource = clMeseros.GetSuplementos();
            DDLGuarnicion.DataTextField = "suplementos_nombre";
            DDLGuarnicion.DataValueField = "id_suplementos";
            DDLGuarnicion.DataBind();
            DDLGuarnicion.Items.Insert(0, new ListItem());
        }

        private void LlenarMenu()
        {
            Accordion1.DataSource = clMeseros.GetTable().DefaultView;
            Accordion1.DataBind();
        }

        protected void Accordion1_ItemDataBound(object sender, AjaxControlToolkit.AccordionItemEventArgs e)
        {
            if (e.ItemType == AjaxControlToolkit.AccordionItemType.Content)
            {
                HiddenField hdfid = (HiddenField)e.AccordionItem.FindControl("hdfCodigo");
                HiddenField hdfsillas = (HiddenField)e.AccordionItem.FindControl("hdfsillas");
                Panel pnlInside = (Panel)e.AccordionItem.FindControl("PnlInside");

                //'se crea un ciclo for que añade un texto por cada fila en el dataset
                for (int i = 0; i < Convert.ToInt32(hdfsillas.Value); i++)
                {

                    LinkButton lkButon = new LinkButton();
                    Literal ltl = new Literal();
                    lkButon.ID = "lkButon" + i.ToString();
                    lkButon.CssClass = "icon-retweet";
                    lkButon.Text = "Silla" + (i + 1).ToString();
                    lkButon.CommandArgument = hdfid.Value + ":" + (i + 1).ToString();
                    lkButon.Click += new EventHandler(lkButon_Click);
                    pnlInside.Controls.Add(lkButon);
                    ltl.Text = "<br />";
                    pnlInside.Controls.Add(ltl);
                }


            }
        }

        void lkButon_Click(object sender, EventArgs e)
        {
            DataTable myDataTable = new DataTable();


            HdFMesaSilla.Value = ((LinkButton)(sender)).CommandArgument;
            String Valorevaluar = HdFMesaSilla.Value;
            String[] Valorevaluado = Valorevaluar.Split(':');

            LblMesa.Text = Valorevaluado[0];
            LblSilla.Text = Valorevaluado[1];
            if (Session["myDataTable" + LblMesa.Text] != null)
            {
                if(((DataTable)Session["myDataTable" + LblMesa.Text]).Rows.Count==0)
                    LlenarOrden(LblMesa.Text);
                else
                     LlenarOrdenSession(LblMesa.Text);
            }
            else
            {
                LlenarOrden(LblMesa.Text);
            }



        }

        private void LlenarOrden(string stmesa)
        {
            DataTable myDataTable;
            CrearDataTable(LblMesa.Text);
            myDataTable = clMeseros.GetPedido(LblMesa.Text);
            Session["myDataTable" + LblMesa.Text] = myDataTable;
            GViewPedido.DataSource = myDataTable;
            GViewPedido.DataBind();

        }
        private void LlenarOrdenSession(string stmesa)
        {
            DataTable myDataTable;

            myDataTable = clMeseros.GetPedido(LblMesa.Text);
            if (myDataTable.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(myDataTable.Rows[0]["pedido_cocina"].ToString()))
                    myDataTable = (DataTable)Session["myDataTable" + LblMesa.Text];
            }

            GViewPedido.DataSource = myDataTable;
            GViewPedido.DataBind();

        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            DataTable myDataTable;
            if (Session["myDataTable" + LblMesa.Text] == null)
            {
                CrearDataTable(LblMesa.Text);
                myDataTable = (DataTable)Session["myDataTable" + LblMesa.Text];
            }
            else
            {
                myDataTable = (DataTable)Session["myDataTable" + LblMesa.Text];
            }


            DataRow dataRow = myDataTable.NewRow();
            if (!string.IsNullOrWhiteSpace(LblMesa.Text))
            {
                if (DDLPlatillo.SelectedIndex > 0 || DDLBebida.SelectedIndex > 0)
                {
                    if (DDLPlatillo.SelectedIndex > 0)
                    {
                        if (DDLGuarnicion.SelectedIndex > 0)
                        {
                            dataRow["id_suplementos"] = DDLGuarnicion.SelectedValue;
                            dataRow["suplementos_nombre"] = DDLGuarnicion.SelectedItem;
                        }
                        else
                        {
                            dataRow["id_suplementos"] = 1;
                            dataRow["suplementos_nombre"] = "";
                        }
                        if (DDLTurno.SelectedIndex > 0)
                        {
                            dataRow["id_horario"] = DDLTurno.SelectedValue;

                        }
                        else
                        {
                            dataRow["id_horario"] = 1;
                        }

                        dataRow["id_mesas"] = LblMesa.Text;
                        dataRow["pedido_silla"] = LblSilla.Text;
                        if (DDLPlatillo.SelectedIndex > 0)
                        {
                            dataRow["id_platillos"] = DDLPlatillo.SelectedValue;
                            dataRow["platillos_nombre"] = DDLPlatillo.SelectedItem;
                        }



                        dataRow["pedido_activo"] = true;
                        dataRow["id_usuarios"] = User.IdUsuario;
                        dataRow["pedido_cerrarpedido"] = false;
                        myDataTable.Rows.Add(dataRow);

                    }


                    if (DDLBebida.SelectedIndex > 0)
                    {
                        dataRow = myDataTable.NewRow();
                        dataRow["id_suplementos"] = 1;
                        dataRow["suplementos_nombre"] = "";

                        if (DDLTurno.SelectedIndex > 0)
                        {
                            dataRow["id_horario"] = DDLTurno.SelectedValue;

                        }
                        else
                        {
                            dataRow["id_horario"] = 1;
                        }

                        dataRow["id_mesas"] = LblMesa.Text;
                        dataRow["pedido_silla"] = LblSilla.Text;
                        dataRow["id_platillos"] = DDLBebida.SelectedValue;
                        dataRow["platillos_nombre"] = DDLBebida.SelectedItem;
                        dataRow["pedido_activo"] = true;

                        dataRow["id_usuarios"] = User.IdUsuario;
                        dataRow["pedido_cerrarpedido"] = false;
                        myDataTable.Rows.Add(dataRow);
                    }
                    Session["myDataTable" + LblMesa.Text] = myDataTable;
                    GViewPedido.DataSource = myDataTable;
                    GViewPedido.DataBind();
                    BorrarSeleccion();
                }
                else
                {
                    clExcepcion.Error(this, "Debe seleccionar un platillo");

                }
            }
            else
            {
                clExcepcion.Error(this, "Debe seleccionar la mesa y la silla");

            }

        }

        private void BorrarSeleccion()
        {
            DDLPlatillo.SelectedIndex = 0;
            DDLGuarnicion.SelectedIndex = 0;
            DDLBebida.SelectedIndex = 0;

        }

        protected void BtnPedirCocina_Click(object sender, EventArgs e)
        {
            CreaPedido();
            DataTable myDataTable;

            CrearDataTable(LblMesa.Text);
            myDataTable = (DataTable)Session["myDataTable" + LblMesa.Text];
            GViewPedido.DataSource = myDataTable;
            GViewPedido.DataBind();
            BorrarSeleccion();
            clExcepcion.Success(this, "Orden enviada correctamente");
        }

        private void CreaPedido()
        {
            DataTable myDataTable;
            bool valorOk = false;

            if (Session["myDataTable" + LblMesa.Text] == null)
            {
                clExcepcion.Error(this, "Debe crear una orden para esta mesa");
            }
            else
            {
                myDataTable = (DataTable)Session["myDataTable" + LblMesa.Text];

                for (int i = 0; i < myDataTable.Rows.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(myDataTable.Rows[i]["id_pedido"].ToString()))
                    {
                        myDataTable.Rows[i]["id_pedido"] = 0;
                    }
                    valorOk = clMeseros.SetUpdatePedido(myDataTable.Rows[i]["id_pedido"].ToString(), myDataTable.Rows[i]["id_suplementos"].ToString(), myDataTable.Rows[i]["id_horario"].ToString(), myDataTable.Rows[i]["id_mesas"].ToString(), myDataTable.Rows[i]["id_platillos"].ToString(), Convert.ToBoolean(myDataTable.Rows[i]["pedido_activo"]), User.IdUsuario.ToString(), false, myDataTable.Rows[i]["pedido_silla"].ToString());
                }


            }
        }

        protected void BtnCerrarPedido_Click(object sender, EventArgs e)
        {

            LblTotal.Text = clMeseros.GetCuenta(LblMesa.Text).Rows[0][0].ToString();
            ModalPopupExtender1.Show();
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            bool boolFactura = false;
            if (DDLNota.SelectedIndex > 0)
            {
                if (DDLNota.SelectedValue == "1")
                    boolFactura = false;
                else
                    boolFactura = true;

            }
            int intFactura = clMeseros.SetFactura(LblTotal.Text, boolFactura, HdFid_Cliente.Value.ToString(), "1");
            try
            {
                clMeseros.CerrarCuenta(LblMesa.Text, intFactura.ToString());
            }
            catch (Exception ex)
            {
                clExcepcion.Error(this, "Hubo un error al cerrar la cuenta: " + ex.Message.ToString());
            }
            finally
            {
                BtnAceptar.Visible = false;
                DataTable myDataTable;
                CrearDataTable(LblMesa.Text);
                myDataTable = clMeseros.GetPedido(LblMesa.Text);
                Session["myDataTable" + LblMesa.Text] = myDataTable;
                GViewPedido.DataSource = myDataTable;
                GViewPedido.DataBind();
                BorrarSeleccion();
                clExcepcion.Success(this, "Se cerro correctamente");
            }

        }


        //protected void DDLNota_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DDLNota.SelectedValue == "1")
        //    {
        //        PnlDatosUsuario.Enabled = false;
        //        HdFid_Cliente.Value = "1";
        //    }
        //    else
        //    {
        //        PnlDatosUsuario.Enabled = true;
        //    }
        //}

 

        protected void GViewPedido_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable myDataTable;
            bool boolvalor = false;
            if (Session["myDataTable" + LblMesa.Text] == null)
            {
                CrearDataTable(LblMesa.Text);
                myDataTable = (DataTable)Session["myDataTable" + LblMesa.Text];
            }
            else
            {
                myDataTable = (DataTable)Session["myDataTable" + LblMesa.Text];
            }
            if (string.IsNullOrEmpty(myDataTable.Rows[e.RowIndex]["id_pedido"].ToString()))
                myDataTable.Rows.RemoveAt(e.RowIndex);
            else
            {
                boolvalor = clMeseros.CancelPedido(myDataTable.Rows[e.RowIndex]["id_pedido"].ToString());
                myDataTable = clMeseros.GetPedido(LblMesa.Text);
                Session["myDataTable" + LblMesa.Text] = myDataTable;
            }
            GViewPedido.DataSource = myDataTable;
            GViewPedido.DataBind();
            BorrarSeleccion();
        }

     

        protected void BtnCancelarPedido_Click(object sender, EventArgs e)
        {
            DataTable myDataTable;

            if (Session["myDataTable" + LblMesa.Text] == null)
            {
                CrearDataTable(LblMesa.Text);
                myDataTable = (DataTable)Session["myDataTable" + LblMesa.Text];
            }
            else
            {
                myDataTable = (DataTable)Session["myDataTable" + LblMesa.Text];
            }
            for (int i = 0; i < myDataTable.Rows.Count; i++)
            {
                clMeseros.CancelPedido(myDataTable.Rows[i]["id_pedido"].ToString());
            }
            myDataTable = clMeseros.GetPedido(LblMesa.Text);
            Session["myDataTable" + LblMesa.Text] = myDataTable;
            GViewPedido.DataSource = myDataTable;
            GViewPedido.DataBind();
            BorrarSeleccion();
        }

        protected void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            HdFid_Cliente.Value = clMeseros.SetUpdateCliente(HdFid_Cliente.Value, TBoxRazonSocial.Text.ToUpper(), TBoxDireccion.Text.ToUpper(), TBoxColonia.Text.ToUpper(), TBoxDelegacion.Text.ToUpper(), TBoxCiudad.Text.ToUpper(), TBoxCP.Text.ToUpper(), TBoxRFC.Text.ToUpper()).ToString();
            BtnAceptar.Visible = true;
            Boolean bolval = false;
            if (DDLNota.SelectedValue == "2")
                bolval = true;
           int stfactura= clMeseros.SetFactura(LblTotal.Text, bolval, HdFid_Cliente.Value, "1");
           clMeseros.CerrarCuenta(LblMesa.Text, stfactura.ToString());
            ModalPopupExtender1.Hide();
            clExcepcion.Success(this, "Se ha cerrado la cuenta exitosamente");
            BorrarSeleccion();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dtCliente = clMeseros.GetClientes(TBoxRFC.Text);
            if (dtCliente.Rows.Count > 0)
            {
                HdFid_Cliente.Value = dtCliente.Rows[0]["id_clientes"].ToString();
                TBoxRazonSocial.Text = dtCliente.Rows[0]["clientes_razonsocial"].ToString();
                TBoxDireccion.Text = dtCliente.Rows[0]["clientes_direccion"].ToString();
                TBoxColonia.Text = dtCliente.Rows[0]["clientes_colonia"].ToString();
                TBoxDelegacion.Text = dtCliente.Rows[0]["clientes_delegacion"].ToString();
                TBoxCiudad.Text = dtCliente.Rows[0]["clientes_ciudad"].ToString();
                TBoxCP.Text = dtCliente.Rows[0]["clientes_cp"].ToString();


            }
            ModalPopupExtender1.Show();
        }




    }
}