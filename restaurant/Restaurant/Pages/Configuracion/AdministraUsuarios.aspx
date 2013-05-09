<%@ Page Title="" Language="C#" MasterPageFile="~/AdministracionReg.master" AutoEventWireup="true"
    CodeBehind="AdministraUsuarios.aspx.cs" Inherits="Restaurant.Pages.Configuracion.AdministraUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PropertiesContentPlaceHolder" runat="server">
    <div style="margin-left: 5%; margin-right: 5%; margin-top:1%">
     <div class="muted titulos">
             
             
            ADMINISTRAR USUARIOS
           
        
           
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
                    </div>
                    <div class="span2">
                        <asp:Button ID="BtnBusca" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="BtnBusca_Click" />
                    </div>
                    <div class="span3 center">

                        <asp:DropDownList ID="DDLComando" runat="server" AutoPostBack="true">
                            <asp:ListItem Value="0">Selecione alguna acción</asp:ListItem>
                            <asp:ListItem Value="1">Agregar Usuario</asp:ListItem>
                            <asp:ListItem Value="2">Activar Usuario</asp:ListItem>
                            <asp:ListItem Value="3">Desactivar Usuario</asp:ListItem>
                            <asp:ListItem Value="4">Bloquear Usuario</asp:ListItem>
                            <asp:ListItem Value="5">Desbloquear Usuario</asp:ListItem>
                            <asp:ListItem Value="6">Borrar Usuario</asp:ListItem>
                            <asp:ListItem Value="7">Interno</asp:ListItem>
                            <asp:ListItem Value="8">Externo</asp:ListItem>
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:GridView ID="GViewUsuarios" runat="server" BackColor="White" BorderColor="#E7E7FF"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3"
                        GridLines="Horizontal" OnPageIndexChanging="GViewUsuarios_PageIndexChanging"
                        OnSorting="GViewUsuarios_Sorting" AllowPaging="True"
                        AutoGenerateColumns="False" AllowSorting="True" EnableModelValidation="true">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
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
                            <asp:BoundField DataField="id_PersonalData" HeaderText="id_PersonalData" ItemStyle-HorizontalAlign="Center"
                                Visible="false">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="user_Login" HeaderText="Ficha" ItemStyle-HorizontalAlign="Center"
                                SortExpression="user_Login">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Fullname" HeaderText="Nombre" SortExpression="Fullname"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PersonalData_Level" HeaderText="Nivel"
                                ItemStyle-HorizontalAlign="Center" SortExpression="PersonalData_Level">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="user_Mail" HeaderText="Email"
                                ItemStyle-HorizontalAlign="Center" SortExpression="user_Mail">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="user_LastAcces" HeaderText="Último Acceso"
                                ItemStyle-HorizontalAlign="Center" SortExpression="user_LastAcces">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="user_InternalEmp" HeaderText="Interno"
                                ItemStyle-HorizontalAlign="Center" SortExpression="user_InternalEmp">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="user_Active" HeaderText="Activo"
                                ItemStyle-HorizontalAlign="Center" SortExpression="user_Active">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="user_Bloqued" HeaderText="Bloqueado"
                                ItemStyle-HorizontalAlign="Center" SortExpression="user_Bloqued">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="user_LoginAttempts" HeaderText="Intentos fallidos"
                                ItemStyle-HorizontalAlign="Center" SortExpression="user_LoginAttempts">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                              <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" BackColor="White"
                                ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="GridViewHeaderStyle " BackColor="#777777"
                                Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridViewPagerStyle" BackColor="#777777" ForeColor="White"
                                HorizontalAlign="Center" />
                            <RowStyle CssClass="GridViewRowStyle" BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" BackColor="#E2DED6"
                                Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
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
