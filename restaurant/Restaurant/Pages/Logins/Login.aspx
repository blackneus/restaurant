<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Restaurant.Pages.Logins.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" />
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script type="text/javascript">
        function AbrirPopup() {
            window.showModalDialog("/Pages/Logins/Pregunta.aspx", "", "toolbar=no, scrollbars=no, resizeable=yes, width=550, height=600, left=10, top=50");
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 252px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <!-- Header insertion -->
    <div class="container-fluid hero-unit">
        <table style="width: 100%">
            <tr>
                <td>
                    <div class="brand-header-blue" class="right">
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <!-- ContentPlaceHolder -->
                    <div id="divFondo2" class="row-fluid">
                        <div class="span6 offset6">
                            <table class="hero-unit" style="margin:5%;padding:20%">
                                <tr>
                                    <td colspan="2" class="font-gray-bold">
                                        <br />
                                        <br />
                                        Iniciar sesión
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp
                                    </td>
                                </tr>
                                <tr>
                                    <td class="font-gray-medium-bold">
                                        Usuario:
                                    </td>
                                    <td class="pull-right">
                                        <asp:TextBox ID="TBoxUsuario" runat="server" CssClass="input-large"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="font-gray-medium-bold">
                                        Contraseña:
                                    </td>
                                    <td class="pull-right">
                                        <asp:TextBox ID="TBoxPassword" runat="server" CssClass="input-large" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="right">
                                        <asp:LinkButton ID="LKBRecuperar" CssClass="font-gray-medium-bold" runat="server"
                                            OnClick="LKBRecuperar_Click">Recuperar contraseña</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="right">
                                            <asp:Button ID="BtnAcceder" runat="server" AlternateText="Entrar" CssClass="btn btn-medium label-large"
                                                Text="Entrar" ToolTip="Entrar" OnClick="BtnAcceder_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
