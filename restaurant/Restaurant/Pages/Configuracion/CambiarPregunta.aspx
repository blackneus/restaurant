<%@ Page Title="" Language="C#" MasterPageFile="~/PropertiesReg.master" AutoEventWireup="true"
    CodeBehind="CambiarPregunta.aspx.cs" Inherits="Restaurant.Pages.Configuracion.CambiarPregunta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PropertiesContentPlaceHolder" runat="server">
   <div style="margin-left: 5%; margin-right: 5%; margin-top:1%">
            
           <div class="muted titulos">

   CAMBIO DE PREGUNTA

            </div>
           <br />
        <table >
            <br>
            <tr>
                <td class="border-round">
                    <div>
                        <div>
                            <asp:Label ID="LblPregunta" runat="server" Text="Pregunta secreta" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:DropDownList ID="DDLPregunta" runat="server" AutoPostBack="true" />
                        </div>
                        <div>
                            <asp:Label ID="LblRespuesta" runat="server" Text="Respuesta" Font-Bold="true"></asp:Label>*
                        </div>
                        <div>
                            <asp:TextBox ID="TBoxRespuesta" runat="server" CssClass="input-large" />
                        </div>
                    </div>
                </td>
                <td>
                    <asp:Image ID="ImagenCuadros" runat="server" ImageUrl="/images/pantallas_img/5actualizar_datos/imagen_cuadros.png" />
                </td>
            </tr>
            <br>
        </table>
        <div class="modal-footer">
            <asp:Button ID="BtnSave" runat="server" Text="Guardar" CssClass="btn btn-large btn-primary"
                OnClick="BtnSave_Click" />
        </div>
    </div>
</asp:Content>
