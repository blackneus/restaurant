<%@ Page Title="" Language="C#" MasterPageFile="~/MainReg.Master" AutoEventWireup="true"
    CodeBehind="Pregunta.aspx.cs" Inherits="Restaurant.Pages.Logins.Pregunta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div class="">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="panScheduleSearch" runat="server" UpdateMode="Always">
            <ContentTemplate>
             <div class="border-round">
             <div class="muted titulos">
             
             
             RECUPERAR CONTRASEÑA
           
        
           
            </div>
          
          
                    <div class="row offset3" >
                    
               
                    <table  class="border-round" style="margin-left:2%; margin-right:2%; margin-bottom:2%; margin-top:2%">
                    
                    <tr>
                    <td style="vertical-align:middle">
                        <asp:Image ID="Image1" runat="server" 
                            ImageUrl="~/images/candado.png" />
                             </td>
                    <td class="input-xlarge">
                        <div>
                        <br />
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Usuario:" Font-Bold="true"></asp:Label>*
                    </div>
                    <div>
                        <asp:TextBox ID="TBoxUsuario" CssClass="input-large" runat="server" Text="" />
                    </div>
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-medium btn-primary"
                        OnClick="btnBuscar_Click" />
                    <br />
                    <div>
                        <asp:Label ID="LblPregunta" runat="server" Text="Pregunta:" Font-Bold="true"></asp:Label>*
                    </div>
                    <div>
                        <asp:TextBox ID="TBoxPregunta" CssClass="input-large" runat="server" Text="" ReadOnly="true" />
                    </div>
                    <div>
                        <asp:Label ID="LblRespuesta" runat="server" Text="Respuesta:" Font-Bold="true"></asp:Label>*
                    </div>
                    <div>
                        <asp:TextBox ID="TBoxRespuesta" CssClass="input-large" runat="server" Text="" />
                    </div>
                </div>
                <div>
                    <asp:Button ID="BtnRestaurar" runat="server" Text="Restaurar" CssClass="btn btn-medium btn-primary"
                        OnClick="btnRestaurar_Click" />
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-medium btn-danger"
                        OnClick="BtnCancelar_Click" />
                </div>
                <br />
                    </td>

                    </tr>
                    </table>
       
                   </div>
                    
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="brand-footer-blue" align="right">
                                </div>
    </div>
            
</asp:Content>
