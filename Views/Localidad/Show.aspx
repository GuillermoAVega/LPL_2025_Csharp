<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.LocalidadModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Actualizar Localidad
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="row static-top shadow" > 
    <div class="col-md-12">
        <h2>Datos Localidad</h2>
    </div>
</div>

<% using (Html.BeginForm("Update","Localidad", FormMethod.Post )) { %>
    <%: Html.ValidationSummary( "Verificar Localidad no creada.") %>
    <fieldset>

<div class="row">
    <div class="col-md-2"><%: Html.LabelFor(m => m.CodigoPostal) %></div>
    <div class="col-md-2"><%: Html.TextBoxFor(m => m.CodigoPostal) %>
    <%: Html.ValidationMessageFor(m => m.CodigoPostal)%></div>
</div>

<div class="row">
    <div class="col-md-2"><%: Html.LabelFor(m => m.Nombre) %></div>
    <div class="col-md-2"><%: Html.TextBoxFor(m => m.Nombre)%>
    <%: Html.ValidationMessageFor(m => m.Nombre)%></div>
</div>  

    
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
    <script type="text/javascript">
        window.setTimeout(function () {
            $("#Clave, #ConfirmaClave").val($("#hdnClave").val());
        }, 150);
    </script>


<script src="../../Content/js/sweetalert2.js"></script>



</asp:Content>
