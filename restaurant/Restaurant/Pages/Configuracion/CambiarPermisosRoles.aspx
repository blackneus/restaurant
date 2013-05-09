<%@ Page Title="" Language="C#" MasterPageFile="~/PropertiesReg.master" AutoEventWireup="true"
    CodeBehind="CambiarPermisosRoles.aspx.cs" Inherits="Restaurant.Pages.Configuracion.CambiarPermisosRoles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PropertiesContentPlaceHolder" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script type="text/javascript">
        function chkboxlistchecking(clientids, checkedval) {
            var a = document.getElementById(clientids);
            var ar = a.getElementsByTagName("input");
            var cnt = 0;
            var notchecked = 0;
            var flag = "false";
            var flag1 = "false";
            for (i = 0; i < ar.length; i++) {
                var arc = a.getElementsByTagName("label");

                for (k = 1; k < ar.length; k++) {

                    if (ar[k].checked)
                        cnt = parseInt(cnt, 10) + 1;
                    else
                        notchecked = parseInt(notchecked, 10) + 1;
                }
                if (ar[i].checked == true) {
                    if (arc[i].innerText == 'All' && parseInt(cnt, 10) == 0) {

                        for (k = 1; k < ar.length; k++) {
                            ar[k].checked = true;
                        }
                        flag = "true";
                        flag1 = "false";
                    }
                    else if (arc[i].innerText == 'All' && parseInt(notchecked, 10) > 0 && flag1 == "false") {
                        ar[0].checked = false;
                        flag1 = "true";
                        flag = "false";
                    }
                    else if (arc[i].innerText == 'All' && parseInt(notchecked, 10) > 0 && flag1 == "true") {

                        for (f = 0; f < ar.length; f++) {
                            ar[f].checked = true;
                        }
                        flag1 = "false";
                        flag = "true";
                    }
                }
                else if (ar[i].checked == false) {
                    if (arc[i].innerText == 'All' && (parseInt(cnt, 10) == ar.length - 1) && flag == "false") {
                        ar[0].checked = true;
                        flag = "true";
                        flag1 = "false";
                    }
                    else if (arc[i].innerText == 'All' && flag == "true") {
                        for (k = 0; k < ar.length; k++) {
                            ar[k].checked = false;
                        }
                        flag = "false";
                        flag1 = "false";
                    }
                }

            }
        }
    </script>

    <div class="container">
        <div class="row-fluid">
            <asp:DropDownList ID="DDLRoles" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLRoles_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <%--<div id="accordion2">--%>
        <%-- <asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
        <div>
        <asp:GridView ID="GridviewBatch" runat="server" Width="248px" BorderWidth="0px" PageSize="2"
            Height="250px" CellPadding="0" AutoGenerateColumns="False" OnRowDataBound="GridviewBatch_RowDataBound"
            ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderText="UserGroupName" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                     <asp:Panel ID="pHeader" runat="server" CssClass="cpHeader">
                       <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id_RolePerm")%>'
                            CssClass="btn-primary" ></asp:Label>
                   </asp:Panel>
                        
                
                        <asp:Panel ID="pBody" runat="server">
                            <br />
                            <asp:Label ID="LblPermiso" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Perm_Label")%>'
                                CssClass="badge"></asp:Label>
                            <br />
                            <asp:CheckBoxList ID="cblstMenuItems" runat="server" BorderWidth="1px" Visible="True"
                                BorderColor="Black" AutoPostBack="False" Height="40px" RepeatDirection="Horizontal"
                                CssClass="btn-navbar">
                            </asp:CheckBoxList>
                            <br />
                        </asp:Panel>
                        <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pBody"
                            CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="Label1"
                            CollapsedText='<%# DataBinder.Eval(Container.DataItem, "Perm_Code")%>' ExpandedText='<%# DataBinder.Eval(Container.DataItem, "Perm_Code")%>'
                            CollapsedSize="0" AutoCollapse="False">
                        </cc1:CollapsiblePanelExtender>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
        <div>
            <asp:Button ID="BtnAplicar" runat="server" CssClass="btn btn-primary btn-large" 
                Text="Aplicar" onclick="BtnAplicar_Click" />
        </div>
        <%-- </div>--%>
    </div>
</asp:Content>
