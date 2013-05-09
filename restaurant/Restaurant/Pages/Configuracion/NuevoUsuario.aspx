<%@ Page Title="" Language="C#" MasterPageFile="~/MainReg.Master" AutoEventWireup="true"
    CodeBehind="NuevoUsuario.aspx.cs" Inherits="Restaurant.Pages.Configuracion.NuevoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div style="margin-left: 1%; margin-right: 5%; margin-top: 1%;background-color:White">
        <div class="muted titulos">
            Agregar Usuario
        </div>
        <br />
        <table>
            <br>
            <tr>
                <td class="border-round">
                    <div >
                        <div>
                            <asp:Label ID="LblRol" runat="server" Text="Rol:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:DropDownList ID="DDLRol" runat="server" AutoPostBack="true" />
                        </div>
                        <div>
                            <asp:Label ID="LbluserLogin" runat="server" Text="Ficha:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxuserLogin" runat="server" CssClass="input-large" />
                        </div>
                        <div>
                            <asp:Label ID="LblPassword" runat="server" Text="Password:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxPassword" runat="server" CssClass="input-large" />
                        </div>
                        <div>
                            <asp:Label ID="LblName" runat="server" Text="Nombre:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxName" runat="server" CssClass="input-large" />
                        </div>
                        <div>
                            <asp:Label ID="LblLastName" runat="server" Text="Apellido paterno:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxLastName" runat="server" CssClass="input-large" />
                        </div>
                        <div>
                            <asp:Label ID="LblMiddleName" runat="server" Text="Apellido materno:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxMiddleName" runat="server" CssClass="input-large" />
                        </div>
                        </div>
                        </td>
                        <td class="border-round">
                      <div>
                        <div>
                            <asp:Label ID="LbluserMail" runat="server" Text="Mail:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxuserMail" runat="server" CssClass="input-large" />
                        </div>
                        <div>
                            <asp:Label ID="LblLevel" runat="server" Text="Nivel:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxLevel" runat="server" CssClass="input-large" />
                        </div>
                        <div>
                            <asp:Label ID="LblLanguage" runat="server" Text="Lenguaje:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:DropDownList ID="DDLLanguage" runat="server" AutoPostBack="true" />
                        </div>
                        <div>
                            <asp:Label ID="LblInterno" runat="server" Text="Interno:" Font-Bold="True"></asp:Label>*
                        </div>
                        <div>
                            <asp:CheckBox ID="ChBoxInterno" runat="server" Text="Interno" class="checkbox inline" />
                        </div>
                    </div>
                </td>
                
            </tr>
            <br>
        </table>
        <div class="modal-footer">
            <asp:Button ID="BtnSave" runat="server" Text="Guardar" CssClass="btn btn-large btn-primary"
                OnClick="BtnSave_Click" />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" CssClass="btn btn-large btn-danger"
                OnClick="BtnCancel_Click" />
        </div>
    </div>
           <div class="brand-footer-blue" align="right">
                                </div>
</asp:Content>
