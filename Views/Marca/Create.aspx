<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.MarcaModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear nueva marca
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row static-top shadow" > 
    <div class="col-md-12">
    <h2>Nueva Marca</h2>
    </div>
</div>
<br />

    <% using (Html.BeginForm("Create","Marca", FormMethod.Post )) { %>
    <%: Html.ValidationSummary( "Verificar Marca no creada.") %>
    <fieldset>


    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Descripcion) %></div>
        <div class="col-md-2"><%: Html.TextBoxFor(m => m.Descripcion) %>
        <%: Html.ValidationMessageFor(m => m.Descripcion)%></div>
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

