<%@ Page Title="" Language="C#" MasterPageFile="~/PropertiesReg.master" AutoEventWireup="true"
    CodeBehind="AgregarUserRol.aspx.cs" Inherits="Restaurant.Pages.Configuracion.AgregarUserRol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PropertiesContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row-fluid">
        <div class="span1">
            <asp:Label ID="LblBusca" runat="server" Text="Palabra"></asp:Label>
        </div>
        <div class="span2">
            <asp:TextBox ID="TBoxBusca" CssClass="input-medium" runat="server"></asp:TextBox>
            <asp:Label ID="LblidRol" runat="server" Text="" Visible="false"></asp:Label>
        </div>
        <div class="span2">
            <asp:Button ID="BtnBusca" runat="server" CssClass="btn btn-primary" Text="Buscar"
                OnClick="BtnBusca_Click" />
        </div>
        <div class="span4 left">
            <asp:Button ID="BtnAplicar" runat="server" Text="Aplicar" CssClass="btn btn-primary"
                OnClick="BtnAplicar_Click" />
                            <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" CssClass="btn btn-danger"
                OnClick="BtnCancelar_Click" />
        </div>
        <div class="span2 right">
            <asp:Label ID="LblSeleccionados" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div>
        <asp:GridView ID="GViewUserRoles" runat="server" BackColor="White" BorderColor="#E7E7FF"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False"
            >
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
            <Columns>
                <asp:TemplateField HeaderText="Sel">
                    <ItemTemplate>
                        <asp:CheckBox ID="Select" runat="server" AutoPostBack="true" OnCheckedChanged="checkbox_checkedChanged"
                            Checked='<%# isSelected(DataBinder.Eval(Container.DataItem, "id_PersonalData").ToString()) %>'
                            ForeColor="White" />
                        <asp:Label ID="IDValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id_PersonalData")%>'
                            Visible="false"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="1%" />
                    <HeaderStyle CssClass="clsTableHeadingCell" />
                </asp:TemplateField>
                <asp:BoundField DataField="user_Login" HeaderText="Ficha" ItemStyle-HorizontalAlign="Center"
                    SortExpression="user_Login">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="fullname" HeaderText="Nombre completo" ItemStyle-HorizontalAlign="Center"
                    SortExpression="fullname">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Role_Label" HeaderText="Rol" ItemStyle-HorizontalAlign="Center"
                    SortExpression="Role_Label">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <!-- Modal -->
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="mModBloqueo" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                aria-hidden="true">
                <div class="modal-body">
                    <div class="hero-unit btn-success">
                        <asp:Label ID="LblAccion" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn-success" data-dismiss="modal" aria-hidden="true">
                        OK</button>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
