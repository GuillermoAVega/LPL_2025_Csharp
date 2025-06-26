<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.ProductoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear nuevo producto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row static-top shadow" > 
        <div class="col-md-12">
            <h2>Nuevo Producto</h2>
        </div>
    </div>
    
    
    <br />
            <% using (Html.BeginForm("Create","Producto", FormMethod.Post )) { %>
            <%: Html.ValidationSummary( "Verificar Producto no creado.") %>
            <fieldset>

            <div class="row">
            <%: Html.HiddenFor(p => p.Codigo)%>
            </div>

            <div class="row">
                <div class="col-md-2"><%: Html.LabelFor(p => p.Descripcion) %></div>
                <div class="col-md-2"><%: Html.TextBoxFor(p => p.Descripcion)%>
                <%: Html.ValidationMessageFor(p => p.Descripcion)%></div>
            </div>    

            <div class="row">
                <div class="col-md-2"><%: Html.LabelFor(p => p.CodMarca) %></div>
                <div class="col-md-2">
                    <%: @Html.DropDownListFor(p =>  p.CodMarca, Model.MarcaList, "Seleccione...", new { @style = "width:250px; text-align: left", @class = "btn btn-default dropdown-toggle" })%>
                    <%: Html.ValidationMessageFor(p => p.CodMarca)%>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2"><%: Html.LabelFor(p => p.CodCategoria) %></div>
                <div class="col-md-2">
                    <%: @Html.DropDownListFor(p =>  p.CodCategoria, Model.CategoriaList, "Seleccione...", new { @style = "width:250px; text-align: left", @class = "btn btn-default dropdown-toggle" })%>
                    <%: Html.ValidationMessageFor(p => p.CodCategoria)%>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2"><%: Html.LabelFor(p => p.Precio) %></div>
                <div class="col-md-2"><%: Html.TextBoxFor(p => p.Precio)%>
                <%: Html.ValidationMessageFor(p => p.Precio)%></div>
            </div>    


            <div class="row">
                <div class="col-md-2"><%: Html.LabelFor(p => p.Stock) %></div>
                <div class="col-md-2"><%: Html.TextBoxFor(p => p.Stock)%>
                <%: Html.ValidationMessageFor(p => p.Stock)%></div>
            </div>    

            <div class="row">
                <div class="col-md-2"><%: Html.LabelFor(p => p.Disponibilidad) %></div>
                <div class="col-md-2"><%: Html.TextBoxFor(p => p.Disponibilidad)%>
                <%: Html.ValidationMessageFor(p => p.Disponibilidad)%></div>
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
