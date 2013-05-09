<%@ Page Title="" Language="C#" MasterPageFile="~/PropertiesReg.master" AutoEventWireup="true"
    CodeBehind="ActualizaDatosPersonales.aspx.cs" Inherits="Restaurant.Pages.Configuracion.ActualizaDatosPersonales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PropertiesContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div style="margin-left: 5%; margin-right: 5%; margin-top:1%">
    <asp:UpdatePanel ID="panScheduleSearch" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div >
                         <div class="muted titulos">
             
             
           ACTUALIZAR DATOS PERSONALES
           
        
           
            </div>
           <br />
                <table >
                    <br>
                    <tr>
                      <td class="border-round">
                            <div >
                                <div>
                                    <asp:Label ID="LbluserLogin" runat="server" Text="Ficha:" Font-Bold="true"></asp:Label>*
                                </div>
                                <div>
                                    <asp:TextBox ID="TBoxuserLogin" runat="server" CssClass="input-large" />
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
                                </div>
                        </td>
                        <td>
                            <asp:Image ID="ImagenCuadros" runat="server" ImageUrl="/images/pantallas_img/5actualizar_datos/imagen_cuadros.png" />
                        </td>
                        </div>
                    </tr>
                    <br>
                </table>

                <%--<div>
        <asp:Label ID="LblLanguage" runat="server" Text="Lenguaje:" Font-Bold="true"></asp:Label>*
    </div>
    <div>
        <asp:DropDownList ID="DDLLanguage" runat="server" AutoPostBack="true" />
    </div>--%>
                <div class="modal-footer">
                    <asp:Button ID="BtnSave" runat="server" Text="Aplicar" CssClass="btn btn-large btn-primary"
                        OnClick="BtnSave_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>



