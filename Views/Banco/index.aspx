<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<List<AltaLlantaCo.db.Banco>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listado de Bancos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="d-sm-flex align-items-center justify-content-between mb-4">
    <h1 class="h3 mb-0 text-gray-800">Bancos</h1>
</div>

<table id="list-bancos" class="table table-striped">
        <thead>
            <tr>
                <th>Codigo</th>
                <th>Nombre</th>
                <th>Direccion</th>
                <th>Telefono</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody></tbody>
</table>

<script type="text/javascript" >
    window.setTimeout(function () {
        var table = $('#list-bancos').DataTable({
            "language": { "url": "/Content/js/Spanish.json" },
            "ajax": '/Banco/Listar',
            "columns": [{ "data": "codigo" }, { "data": "nombre" }, { "data": "direccion" }, { "data": "telefono" }, { "data": null}],
            "columnDefs": [{ "targets": 4, "render": function (data, type, row, meta) { return "<a href='/Banco/Show?codigoBanco=" + data.codigo + "'>editar</a>"; } }, { "targets": [0], "visible": false}]
        });
    }, 150);
</script>

<a href="/Banco/Create"><img src="/Content/img/add.png" style="width:30px;height:30px"/> Agregar </a>
</asp:Content>

