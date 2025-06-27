<%@ Page Title="Listado de Productos" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.ListadoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Listado de Productos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Productos</h3>

    <% using (Html.BeginForm("Listado", "Producto", FormMethod.Post)) { %>
        <fieldset style="display: flex; align-items: center;  margin: 20px 0;">


            <div>
                <label for="CodCategoria"> Categorias </label>
                <%= Html.DropDownList(
                    "CodCategoria",
                    Model.Categorias,
                    "-- Todas las marcas --"

                ) %>
                
            </div>

            <div>
                <label for="CodMarca" style="padding-left:100px" > Marcas </label>
                <%= Html.DropDownList(
                    "CodMarca",
                    Model.Marcas,
                    "-- Todas las marcas --"
                ) %>
               
            </div>

            <div style="align-self: flex-end; padding-left:100px" >
                <input type="button" id="btnfiltrar" value="Filtrar" class="btn btn-primary" />
            </div>

        </fieldset>
    <% } %>

    <table id="list-productos" class="table table-striped">
        <thead>
            <tr>
                <th>Codigo</th>
                <th>Descripcion</th>
                <th>Marca</th>
                <th>Categoria</th>
                <th>Precio</th>
                <th>Stock</th>
                <th>Disponibilidad</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>

    <script type="text/javascript" >
        window.setTimeout(function () {
            var table = $('#list-productos').DataTable({
                "language": { "url": "/Content/js/Spanish.json" },
                "ajax": {
                    "url": '<%= Url.Action("Listar", "Producto") %>',
                    "data": function (d) {
                        d.CodMarca = $('#CodMarca').val();
                        d.CodCategoria = $('#CodCategoria').val();
                    }
                },
                "columns": [{ "data": "Codigo" }, { "data": "Descripcion" }, { "data": "Marca" }, { "data": "Categoria" }, { "data": "Precio" }, { "data": "Stock" }, { "data": "Disponibilidad" }],
                "columnDefs": [{ "targets": 0, "render": function (data, type, row, meta) { return "<a href='/Producto/Show?codigoProducto=" + data.Codigo + "'>editar</a>"; } }, { "targets": [0], "visible": false}],
                "searching":false,
                "lengthChange": false
            });

            // Recargar con nuevo filtro al hacer clic en "Filtrar"
            $('#btnfiltrar').on('click', function () {
                table.ajax.reload();
            });


        }, 150);

    </script>

</asp:Content>