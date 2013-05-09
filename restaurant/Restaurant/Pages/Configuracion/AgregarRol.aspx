<%@ Page Title="" Language="C#" MasterPageFile="~/AdministracionReg.master" AutoEventWireup="true"
    CodeBehind="AgregarRol.aspx.cs" Inherits="Restaurant.Pages.Configuracion.AgregarRol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PropertiesContentPlaceHolder" runat="server">
    <div style="margin-left: 5%; margin-right: 5%; margin-top:1%">
           <div class="muted titulos">

            ADMINISTRAR ROLES

            </div>
           <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="border-round">
            <div style="margin-top: 2%; margin-left:2%">
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
                    <div class="span3 center">
                        <asp:DropDownList ID="DDLComando" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLComando_SelectedIndexChanged">
                            <asp:ListItem Value="0">Selecione alguna acción</asp:ListItem>
                            <asp:ListItem Value="1">Activar Rol</asp:ListItem>
                            <asp:ListItem Value="2">Desactivar Rol</asp:ListItem>
                            <asp:ListItem Value="3">Editar permisos de roles</asp:ListItem>
                            <asp:ListItem Value="4">Agregar rol</asp:ListItem>
                            <asp:ListItem Value="5">Editar rol</asp:ListItem>
                            <asp:ListItem Value="6">Agregar rol a Usuarios</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="span2 left">
                        <asp:Button ID="BtnAplicar" runat="server" Text="Aplicar" CssClass="btn btn-primary"
                            OnClick="BtnAplicar_Click" />
                    </div>
                    <div class="span2 right">
                        <asp:Label ID="LblSeleccionados" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <br>
        <div>
            <asp:GridView ID="GViewRoles" runat="server" BackColor="White" BorderColor="#E7E7FF"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False"
                DataKeyNames="id_Role">
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle CssClass="GridViewHeaderStyle " BackColor="#777777" Font-Bold="True"
                    ForeColor="White" />
                <PagerStyle CssClass="GridViewPagerStyle" BackColor="#777777" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle CssClass="GridViewRowStyle" BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" BackColor="#E2DED6" Font-Bold="True"
                    ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                <Columns>
                    <asp:TemplateField HeaderText="Sel">
                        <ItemTemplate>
                            <asp:CheckBox ID="Select" runat="server" AutoPostBack="true" OnCheckedChanged="checkbox_checkedChanged"
                                Checked='<%# isSelected(DataBinder.Eval(Container.DataItem, "id_Role").ToString()) %>'
                                ForeColor="White" />
                            <asp:Label ID="IDValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id_Role")%>'
                                Visible="false"></asp:Label>
                            <asp:Label ID="TextValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Role_label")%>'
                                Visible="false"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="1%" />
                        <HeaderStyle CssClass="clsTableHeadingCell" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="id_Role" HeaderText="id_Role" ItemStyle-HorizontalAlign="Center"
                        Visible="false">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Role_label" HeaderText="Rol" ItemStyle-HorizontalAlign="Center"
                        SortExpression="Role_label">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Role_Active" HeaderText="Activo" ItemStyle-HorizontalAlign="Center"
                        SortExpression="Role_Active">
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
    </div>
</asp:Content>
