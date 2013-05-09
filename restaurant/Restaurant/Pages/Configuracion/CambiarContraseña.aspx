<%@ Page Title="" Language="C#" MasterPageFile="~/PropertiesReg.master" AutoEventWireup="true"
    CodeBehind="CambiarContraseña.aspx.cs" Inherits="Restaurant.Pages.Configuracion.CambiarContraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PropertiesContentPlaceHolder" runat="server">
    <div style="margin-left: 5%; margin-right: 5%; margin-top:1%">
       
           <div class="muted titulos">

            CAMBIO DE CONTRASEÑA

            </div>
           <br />
       <table >
            <br>
            <tr>
                <td class="border-round">
                    <div >
                        <div>
                            <asp:Label ID="LblContraseñaant" runat="server" Text="Contraseña anterior:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxContraseñaant" runat="server" CssClass="input-large" TextMode="Password" />
                        </div>
                        <div>
                            <asp:Label ID="LblContraseña1" runat="server" Text="Contraseña nueva:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxContraseña1" runat="server" CssClass="input-large" TextMode="Password" />
                        </div>
                        <div>
                            <asp:Label ID="LblContraseña2" runat="server" Text="Reingresar contraseña:" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxContraseña2" runat="server" CssClass="input-large" TextMode="Password" />
                        </div>
                    </div>
                </td>
               
                <td style="right">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/pantallas_img/6cambio_de_contraseña/imagen_cuadros.png" />
                </td>
            </tr>
            <br>
        </table>
        <div class="modal-footer">
            <asp:Button ID="BtnSave" runat="server" Text="Aplicar" CssClass="btn btn-large btn-primary"
                OnClick="BtnSave_Click" />
        </div>
    </div>
       <div class="brand-footer-blue" align="right">
                                </div>
</asp:Content>
