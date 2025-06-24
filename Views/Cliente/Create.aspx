<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.ClienteModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear nuevo cliente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="row static-top shadow" > 
    <div class="col-md-12">
        <h2>Nuevo Cliente</h2>
    </div>
</div>
<br />
    <% using (Html.BeginForm("Create","Cliente", FormMethod.Post )) { %>
    <%: Html.ValidationSummary( "Verificar Cliente no creado.") %>
    <fieldset>
    
    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Usuario) %></div>
        <div class="col-md-2"><%: Html.TextBoxFor(m => m.Usuario)%>
        <%: Html.ValidationMessageFor(m => m.Usuario)%></div>
    </div>    

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Clave) %></div>
        <div class="col-md-2">
        <%: Html.PasswordFor(m => m.Clave)%>
        <%: Html.ValidationMessageFor(m => m.Clave)%></div>
    </div>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.ConfirmaClave) %></div>
        <div class="col-md-2">
        <%: Html.PasswordFor(m => m.ConfirmaClave)%>
        <%: Html.ValidationMessageFor(m => m.ConfirmaClave)%></div>
    </div>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Cuil) %></div>
        <div class="col-md-2">
        <%: Html.TextBoxFor(m => m.Cuil)%>
        <%: Html.ValidationMessageFor(m => m.Cuil)%></div>
    </div>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.RazonSocial) %></div>
        <div class="col-md-2">
        <%: Html.TextBoxFor(m => m.RazonSocial)%>
        <%: Html.ValidationMessageFor(m => m.RazonSocial)%></div>
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
        <div class="col-md-2"><%: Html.LabelFor(m => m.Email) %></div>
        <div class="col-md-2">
        <%: Html.TextBoxFor(m => m.Email)%>
        <%: Html.ValidationMessageFor(m => m.Email)%></div>
    </div>
        <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Celular) %></div>
        <div class="col-md-2">
        <%: Html.TextBoxFor(m => m.Celular)%>
        <%: Html.ValidationMessageFor(m => m.Celular)%></div>
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
