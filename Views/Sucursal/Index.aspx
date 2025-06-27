<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listado de sucursales
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="d-sm-flex align-items-center justify-content-between mb-4">
<h1 class="h3 mb-0 text-gray-800">Sucursales</h1>
</div>
<table id="list-sucursales" class="table table-striped">
<thead>
<tr>
<th>Nombre</th>
<th>Telefono</th>
<th>Direccion</th>
<th>Localidad</th>
<th>Acciones</th>

</tr>
</thead>
<tbody></tbody>
</table>
<script type="text/javascript" >
    window.setTimeout(function () {
        var table = $('#list-sucursales').DataTable({
            "language": { "url": "/Content/js/Spanish.json" },
            "ajax": '/Sucursal/Listar',
            "columns": [{ "data": "Nombre" }, { "data": "Telefono" }, { "data": "Direccion" }, { "data": "Localidad" }, { "data": null}],
            "columnDefs": [{ "targets": 4, "render": function (data, type, row, meta) { return '<a href="/Sucursal/Show?codigo=' + row.Codigo + '" class="btn btn-sm btn-primary">Editar</a>'; } }]
        });
    }, 150);

</script>
<a href="<%: Url.Action("Create", "Sucursal") %>">
    <img src="/Content/img/add.png" style="width:30px;height:30px" /> Agregar
</a>
</asp:Content>
