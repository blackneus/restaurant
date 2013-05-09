<%@ Page Title="" Language="C#" MasterPageFile="~/MainReg.Master" AutoEventWireup="true"
    CodeBehind="Pagar.aspx.cs" Inherits="Restaurant.Pages.Pantalla.Pagar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">

    <div class="container-fluid badge-warning">
        <div class="row-fluid ">
            <div class="span3">
                <asp:Literal ID="LtlPago" runat="server"></asp:Literal>
            </div>
            <div class="span9">
            </div>
        </div>
        <div class="row-fluid ">
            <div class="span2">
                <asp:Label ID="Label1" runat="server" Text="Mesa"></asp:Label>
            </div>
            <div class="span4">
                <asp:DropDownList ID="DDLMesa" runat="server" 
                    onselectedindexchanged="DDLMesa_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <div class="span2">
                <asp:Label ID="Label2" runat="server" Text="Saldo"></asp:Label>
            </div>
            <div class="span4">
                <asp:TextBox ID="TBoxSaldo" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row-fluid">
            <div class="span2">
                <asp:Label ID="Label6" runat="server" Text="Cliente"></asp:Label>
            </div>
            <div class="span4">
                <asp:Label ID="LblCliente" runat="server" Text=""></asp:Label>
            </div>

            <div class="span2">
                <asp:Label ID="Label3" runat="server" Text="Tipo de pago"></asp:Label>
            </div>
            <div class="span4">
                <asp:DropDownList ID="DDLTipoPago" runat="server" 
                    onselectedindexchanged="DDLTipoPago_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </div>
           
        </div>
              <div class="row-fluid">
               <div class="span2">
                <asp:Label ID="Label4" runat="server" Text="Pago"></asp:Label>
            </div>
            <div class="span4">
                <asp:TextBox ID="TBoxApagar" runat="server"></asp:TextBox>
            </div>
            <div class="span2">
                <asp:Label ID="Label5" runat="server" Text="Cambio"></asp:Label>
            </div>
            <div class="span4">
                <asp:TextBox ID="TBoxCambio" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        
          
        </div>
          <div class="row-fluid">
          
          <div class="span6">
                <asp:Button ID="BtnPagar" runat="server" Text="Pagar" 
                    CssClass="btn btn-primary btn-large" Enabled="False" onclick="BtnPagar_Click"
                 />
            </div>
          <div class="span6">
           <asp:Button ID="BtnFactura" runat="server" Text="VerFactura" 
                  CssClass="btn btn-primary btn-large" onclick="BtnFactura_Click"
                 />
              <asp:HiddenField ID="HFieldFactura" runat="server" />
          </div>
          
          
          </div>
    </div>
</asp:Content>
