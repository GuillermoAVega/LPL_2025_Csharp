<%@ Page Title="Listado Mas Vendidos" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<List<WebDemo.Models.ProductoVendidoView>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Productos mas vendidos
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Content/vendor/datatables/jquery.dataTables.min.js"> </script>
    <script src="../../Content/vendor/datatables/dataTables.bootstrap4.min.js"> </script>

    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800"> Productos mas vendidos </h1>
    </div>

    <table id="list-productos-mas-vendidos" class="table table-striped">
        <thead>
            <tr>
                <th>Codigo</th>
                <th>Descripcion</th>
                <th>Marca</th>
                <th>Categoria</th>
                <th>Cantidad Vendida</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
    <script type="text/javascript" >
        window.setTimeout(function () {
            var table = $('#list-productos-mas-vendidos').DataTable({
                "language": { "url": "/Content/js/Spanish.json" },
                "ajax": '/Producto/ListarMasVendidos',
                "columns": [{ "data": "Codigo" }, { "data": "Descripcion" }, { "data": "Marca" }, { "data": "Categoria" }, {"data": "Cantidad"}],
                "columnDefs": [{ "targets": 0, "render": function (data, type, row, meta) { return "<a href='/Producto/Show?codigoProducto=" + data.Codigo + "'>editar</a>"; } }, { "targets": [0], "visible": false}],
                "searching": false,
                "lengthChange": false
            });
        }, 150);

    </script>





</asp:Content>
