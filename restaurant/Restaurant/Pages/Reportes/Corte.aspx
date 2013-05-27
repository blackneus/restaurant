<%@ Page Title="" Language="C#" MasterPageFile="~/ReportesMaster.master" AutoEventWireup="true"
    CodeBehind="Corte.aspx.cs" Inherits="Restaurant.Pages.Reportes.Corte" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PropertiesContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <div class="span2">
        <asp:Label ID="Label1" Visible="True" runat="server" Text="Fecha"></asp:Label>
    </div>
    <div class="span10">
        <cc1:CalendarExtender ID="CalFechaInicio" runat="server" PopupButtonID="ImgFechaInicio"
            TargetControlID="TxtFechaInicio" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        <asp:TextBox Visible="True" ID="TxtFechaInicio" runat="server"></asp:TextBox>
        <asp:ImageButton Visible="True" ID="ImgFechaInicio" runat="server" ImageUrl="~/images/calendar.jpg" />
    </div>
    <div class="span12">
        <asp:Button ID="BtnReporte" runat="server" Text="Reporte" CssClass="btn btn-primary"
            OnClick="BtnReporte_Click" />
    </div>
</asp:Content>
