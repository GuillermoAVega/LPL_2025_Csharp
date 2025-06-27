<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<List<AltaLlantaCo.db.Localidad>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listado de localidades
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="d-sm-flex align-items-center justify-content-between mb-4">
<h1 class="h3 mb-0 text-gray-800">Localidades</h1>
</div>
<table id="list-localidades" class="table table-striped">
<thead>
<tr>
<th>Codigo Postal</th>
<th>Nombre</th>
<th>Acciones</th>
</tr>
</thead>
<tbody></tbody>
</table>
<script type="text/javascript" >
    window.setTimeout(function () {
        var table = $('#list-localidades').DataTable({
            "language": { "url": "/Content/js/Spanish.json" },
            "ajax": '/Localidad/Listar',
            "columns": [{ "data": "CodigoPostal" }, { "data": "Nombre" }, { "data": null}],
            "columnDefs": [{ "targets": 2, "render": function (data, type, row, meta) { return "<a href='/Localidad/Show?Codigo=" + data.CodigoPostal + "'>editar</a>"; } }]
        });
    }, 150);
</script>

<a href="/Localidad/Create"><img src="/Content/img/add.png" style="width:30px;height:30px"/>Agregar </a>
</asp:Content>

