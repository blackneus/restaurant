<%@ Page Title="" Language="C#" MasterPageFile="~/MainReg.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Restaurant.Pages.Configuracion.Inicio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
  

    <div class="row-fluid" >
        <div class="span4" align="center">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/botones/btn_01.png"  PostBackUrl="~/Pages/Pantalla/Mesero.aspx"/>
        </div>
        <div class="span4" align="center">
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/botones/btn_02.png" PostBackUrl="~/Pages/Pantalla/Pagar.aspx"/>
        </div>
        <div class="span4" align="center">
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/botones/btn_03.png" PostBackUrl="~/Pages/Pantalla/Cocina.aspx"/>
        </div>
    </div>
    
    

</asp:Content>
