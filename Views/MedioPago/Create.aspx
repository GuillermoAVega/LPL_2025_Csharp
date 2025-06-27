<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.MedioPagoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear nuevo medio de pago
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="row static-top shadow" > 
    <div class="col-md-12">
        <h2>Nuevo Medio de Pago</h2>
    </div>
</div>
<br />
    <% using (Html.BeginForm("Create","MedioPago", FormMethod.Post )) { %>
    <%: Html.ValidationSummary( "Verificar MedioPago no creado.") %>
    <fieldset>
  
    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Descripcion ) %></div>
        <div class="col-md-2"><%: Html.TextBoxFor(m => m.Descripcion)%>
        <%: Html.ValidationMessageFor(m => m.Descripcion)%></div>
    </div>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.CodBanco) %></div>
        <div class="col-md-2">
        <%: @Html.DropDownListFor(m =>  m.CodBanco,Model.BancosList, "Seleccione...", new { @style = "width:250px; text-align: left", @class = "btn btn-default dropdown-toggle" })%>
        <%: Html.ValidationMessageFor(m => m.CodBanco)%></div>
    </div>

    <hr />
    <div class="row">
        <div class="col-md-2">
            <input id ="CancelarBtn" type="button" value="Cancelar" />
        </div>
        <div class="col-md-2">
            <input id ="GuardarBtn" type="submit" value="Guardar" />
        </div>
    </div>
    </fieldset>

    <% } %>    
    <script src="../../Content/js/sweetalert2.js"></script>
</asp:Content>
