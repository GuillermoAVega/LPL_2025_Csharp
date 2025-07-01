<%@ Page Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.SucursalModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear nueva sucursal
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row static-top shadow" > 
        <div class="col-md-12">
    <h2>Nueva Sucursal</h2>
    </div>
</div>
<br />
    <% using (Html.BeginForm("Create","Sucursal", FormMethod.Post )) { %>
    <%: Html.ValidationSummary( "Verificar Sucursal no creada.") %>
    <fieldset>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Nombre) %></div>
        <div class="col-md-2"><%: Html.TextBoxFor(m => m.Nombre) %>
        <%: Html.ValidationMessageFor(m => m.Nombre)%></div>
    </div>   

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.CodPostal) %></div>
        <div class="col-md-2">
        <%: @Html.DropDownListFor(m =>  m.CodPostal,Model.LocalidadesList, "Seleccione...", new { @style = "width:250px; text-align: left", @class = "btn btn-default dropdown-toggle" })%>
        <%: Html.ValidationMessageFor(m => m.CodPostal)%></div>
    </div>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Direccion) %></div>
        <div class="col-md-2">
        <%: Html.TextBoxFor(m => m.Direccion)%>
        <%: Html.ValidationMessageFor(m => m.Direccion)%></div>
    </div>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Telefono) %></div>
        <div class="col-md-2">
        <%: Html.TextBoxFor(m => m.Telefono)%>
        <%: Html.ValidationMessageFor(m => m.Telefono)%></div>
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
    <script> document.getElementById("CodPostal").focus(); </script>
    <script src="../../Content/js/sweetalert2.js"></script>
</asp:Content>
