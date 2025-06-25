<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.MarcaModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Actualizar Marca
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="row static-top shadow" > 
    <div class="col-md-12">
        <h2>Datos Marca</h2>
    </div>
</div>

<% using (Html.BeginForm("Update","Marca", FormMethod.Post )) { %>
    <%: Html.ValidationSummary( "Verificar Marca no creada.") %>
    <fieldset>
    <div class="row">
    <%: Html.HiddenFor(m => m.Codigo)%>
    </div>
    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Descripcion) %></div>
        <div class="col-md-2"><%: Html.TextBoxFor(m => m.Descripcion)%>
        <%: Html.ValidationMessageFor(m => m.Descripcion)%></div>
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
