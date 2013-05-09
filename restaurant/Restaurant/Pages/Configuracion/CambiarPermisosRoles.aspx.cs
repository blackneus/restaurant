using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Restaurant.Negocio;
using Restaurant.Clases;
using System.Text;
namespace Restaurant.Pages.Configuracion
{
    public partial class CambiarPermisosRoles : clSessionPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.Params["idrol"]))
                {
                    CargarDDL();
                    BtnAplicar.Visible = false;
                }
                else
                {
                    CargarDDL();
                    DDLRoles.SelectedValue = Request.Params["idrol"].ToString();
                    BindGrid(Convert.ToInt32 (Request.Params["idrol"]));
                    BtnAplicar.Visible = true;
                }

            }
        }

        private void CargarDDL()
        {
            clPermisos cluPermiso = new clPermisos();
            DDLRoles.DataSource = cluPermiso.GetRoles();
            DDLRoles.DataTextField = "Role_Label";
            DDLRoles.DataValueField = "id_Role";
            DDLRoles.DataBind();
            DDLRoles.Items.Insert(0, new ListItem());

        }
        private void BindGrid(int intRole)
        {

            //Binding Gridview with some data
            clPermisos clUPermisos = new clPermisos();
            DataTable dtTabla = clUPermisos.GetAllPerm(intRole);

            if (dtTabla.Rows.Count > 0)
            {

                GridviewBatch.DataSource = dtTabla;
                GridviewBatch.DataBind();
                //StringBuilder sb = new StringBuilder();
                //sb.Append("<div class=\"accordion\" id=\"accordion2\">");
                //sb.Append("<div class=\"accordion-group\">");
                //sb.Append("<div class=\"accordion-heading\">");
                //sb.Append("<a class=\"accordion-toggle\" href=\"#collapseOne\" data-parent=\"#accordion2\" data-toggle=\"collapse\"> Collapsible Group Item #1 </a>");
                //sb.Append("</div>");
                //sb.Append("<div id=\"collapseOne\" class=\"accordion-body collapse\" style=\"height: 0px;\">");
                //sb.Append("<div class=\"accordion-inner\"> Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. </div>");
                //sb.Append("</div>");
                //sb.Append("</div>");
                //sb.Append("<div class=\"accordion-group\">");
                //sb.Append("<div class=\"accordion-heading\">");
                //sb.Append("<a class=\"accordion-toggle\" href=\"#collapseTwo\" data-parent=\"#accordion2\" data-toggle=\"collapse\"> Collapsible Group Item #2 </a>");
                //sb.Append("</div>");
                //sb.Append("<div id=\"collapseTwo\" class=\"accordion-body collapse\">");
                //sb.Append("<div class=\"accordion-inner\"> Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. </div>");
                //sb.Append("</div>");
                //sb.Append("</div>");
                //sb.Append("<div class=\"accordion-group\">");
                //sb.Append("<div class=\"accordion-heading\">");
                //sb.Append("<a class=\"accordion-toggle\" href=\"#collapseThree\" data-parent=\"#accordion2\" data-toggle=\"collapse\"> Collapsible Group Item #3 </a>");
                //sb.Append("</div>");
                //sb.Append("<div id=\"collapseThree\" class=\"accordion-body collapse\">");
                //sb.Append("<div class=\"accordion-inner\"> Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. </div>");
                //sb.Append("</div>");
                //sb.Append("</div>");
                //sb.Append("</div>");
                //sb.Append("</div>");
                //sb.Append("</div>");
                //Literal1.Text = sb.ToString();
            }
            else
            {
                GridviewBatch.DataSource = new DataTable();
                GridviewBatch.DataBind();
                clExcepcion.Error(this, "No hay permisos para etse Rol");
            }

        }
        protected void GridviewBatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //Binding checkbox list to Gridview    
            clPermisos clUPermisos = new clPermisos();
            if (DDLRoles.SelectedIndex > 0)
            {
                DataTable dtRolePerm = clUPermisos.GetRolePerm(Convert.ToInt32(DDLRoles.SelectedValue));
                if (e.Row.RowIndex != -1 && e.Row.DataItem != null)
                {

                    List<string> lsList = new List<string>();
                    for (int i = 4; i < dtRolePerm.Columns.Count; i++)
                    {
                        lsList.Add(dtRolePerm.Columns[i].ToString());
                    }
                    //Itendifying checkboxlist in gridview template column  

                    CheckBoxList chklist = (CheckBoxList)e.Row.Cells[0].FindControl("cblstMenuItems");




                    //Assigning DataSource to checkboxlist   

                    chklist.DataSource = lsList;
                    chklist.DataBind();
                    chklist.Items.Insert(0, new ListItem("All", "All"));


                    for (int i = 1; i < chklist.Items.Count; i++)
                    {
                        DataRow[] dtrow = dtRolePerm.Select("Perm_Code='" + ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[2] + "'");
                        Boolean booselected = false;
                        int intselrow = Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[0]);

                        if (Convert.ToInt32(dtRolePerm.Rows[intselrow - 1][chklist.Items[i].Text]) == 1)
                            booselected = true;
                        else
                            booselected = false;

                        chklist.Items[i].Selected = booselected;

                    }


                    chklist.Attributes.Add("onclick", "chkboxlistchecking('" + chklist.ClientID.ToString() + "','" + chklist.Items.Count + "')");
                }
            }
            else
            {
                clExcepcion.Error(this, "Debe elegir un rol");
            }
        }

        protected void DDLRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(((DropDownList)sender).SelectedIndex);
            BtnAplicar.Visible = true;
        }

        protected void BtnAplicar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow erow in GridviewBatch.Rows)
            {
                if (erow.RowIndex != -1 )
                {

                    //Itendifying checkboxlist in gridview template column  
                    Label lblText = (Label)erow.Cells[0].FindControl("Label1");
                    CheckBoxList chklist = (CheckBoxList)erow.Cells[0].FindControl("cblstMenuItems");

                    //Assigning DataSource to checkboxlist   

                    string strValor = string.Empty;

                    for (int i = 1; i < chklist.Items.Count; i++)
                    {
                        if (chklist.Items[i].Selected)
                            strValor += "1";
                        else
                            strValor += "0";
                    }
                    Int32 intValor = BintoDec(ReverseString(strValor));
                    clPermisos clUPermisos= new clPermisos();
                    Boolean result=clUPermisos.SetPerm(lblText.Text,intValor);
                    if (result)
                    {
                        clExcepcion.SuccessFunction(this, "Se han cambiado con exito", "function() { window.location='/Pages/Configuracion/AgregarRol.aspx'}");
                    }
                    else
                    {
                        clExcepcion.Error(this, "No se guardo correctamente");
                    }
                }

            }

        
        }
        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private int BintoDec(string strValor)
        {
              // my binary "number" as a string
            int dec = 0;
            for (int i = 0; i < strValor.Length; i++)
            {
                // we start with the least significant digit, and work our way to the left
                if (strValor[strValor.Length - i - 1] == '0') continue;
                dec += (int)Math.Pow(2, i);
            }
            return dec;
        }
    }
}