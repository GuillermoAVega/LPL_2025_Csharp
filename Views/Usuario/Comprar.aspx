<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteAppUsr.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.CompraView>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Compras realizadas
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Content/vendor/datatables/jquery.dataTables.min.js"> </script>
    <script src="../../Content/vendor/datatables/dataTables.bootstrap4.min.js"> </script>

<div class="d-sm-flex align-items-center  mb-4">
    <a href="/Usuario/Inicio" style="margin-right: 50px; "> Volver </a>
    <h1 class="h3 mb-0 text-gray-800"> Compras realizadas </h1>
</div>

<table id="list-compras" class="table table-striped">
    <thead>
        <tr>
            <th>Codigo Factura</th>
            <th>Numero compra</th>
            <th>Fecha</th>
            <th>Entregado</th>
            <th>Factura</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>

<script type="text/javascript" >
    window.setTimeout(function () {
        var table = $('#list-compras').DataTable({
            "language": { "url": "/Content/js/Spanish.json" },
            "ajax": '/Usuario/Listar',
            "columns": [{ "data": "CodFactura" }, { "data": "Codigo" }, { "data": "Fecha" }, { "data": "Entregado" }, { "data": null}],
            "columnDefs": [{ "targets": 4, "render": function (data, type, row, meta) { return "<a href='/Factura/Show?CodFactura=" + data.CodFactura + "'> Ver </a>"; } }, { "targets": [0], "visible": false}]
        });
    }, 150);

</script>

</asp:Content>
