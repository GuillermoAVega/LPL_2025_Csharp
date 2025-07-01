<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.BancoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear nuevo Banco
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row static-top shadow" > 
    
    <div class="col-md-12">
        <h2>Nuevo Banco</h2>
    
    </div>
</div>

<br />
    <% using (Html.BeginForm("Create","Banco", FormMethod.Post )) { %>
    <%: Html.ValidationSummary( "Verificar Banco no creado.") %>
    <fieldset>


    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(b => b.nombre) %></div>
        <div class="col-md-2"><%: Html.TextBoxFor(b => b.nombre) %>
        <%: Html.ValidationMessageFor(b => b.nombre)%></div>
    </div>


    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(b => b.direccion) %></div>
        <div class="col-md-2"><%: Html.TextBoxFor(b => b.direccion) %>
        <%: Html.ValidationMessageFor(b => b.direccion)%></div>
    </div>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(b => b.telefono) %></div>
        <div class="col-md-2"><%: Html.TextBoxFor(b => b.telefono) %>
        <%: Html.ValidationMessageFor(b => b.telefono)%></div>
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
