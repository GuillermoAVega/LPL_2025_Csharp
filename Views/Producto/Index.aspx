<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Productos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Content/vendor/datatables/jquery.dataTables.min.js"> </script>
    <script src="../../Content/vendor/datatables/dataTables.bootstrap4.min.js"> </script>

<div class="d-sm-flex align-items-center justify-content-between mb-4">
    <h1 class="h3 mb-0 text-gray-800"> Productos </h1>
</div>

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
            <th>Acciones</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<script type="text/javascript" >
    window.setTimeout(function () {
        var table = $('#list-productos').DataTable({
            "language": { "url": "/Content/js/Spanish.json" },
            "ajax": '/Producto/Listar',
            "columns": [{ "data": "Codigo" }, { "data": "Descripcion" }, { "data": "Marca" }, { "data": "Categoria" }, { "data": "Precio" }, { "data": "Stock" }, { "data": "Disponibilidad" }, { "data": null}],
            "columnDefs": [{ "targets": 7, "render": function (data, type, row, meta) { return "<a href='/Producto/Show?codigoProducto=" + data.Codigo + "'>editar</a>"; } }, { "targets": [0], "visible": false}]
        });
    }, 150);

</script>

<a href="/Producto/Create"><img src="/Content/img/add.png" style="width:30px;height:30px"/> Agregar </a>
</asp:Content>
