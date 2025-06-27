<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Medios de Pago
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="d-sm-flex align-items-center justify-content-between mb-4">
<h1 class="h3 mb-0 text-gray-800">Medios de Pago</h1>
</div>
<table id="list-medios-de-pago" class="table table-striped">
<thead>
<tr>
    <th>Codigo</th>
    <th>Descripcion</th>
    <th>Banco</th>
    <th>Acciones</th>

</tr>
</thead>
<tbody></tbody>
</table>
<script type="text/javascript" >
    window.setTimeout(function () {
        var table = $('#list-medios-de-pago').DataTable({
            "language": { "url": "/Content/js/Spanish.json" },
            "ajax": '/MedioPago/Listar',
            "columns": [{ "data": "Codigo" }, { "data": "Descripcion" }, { "data": "Banco" }, { "data": null}],
            "columnDefs": [{ "targets": 3, "render": function (data, type, row, meta) { return "<a href='/MedioPago/Show?codigo=" + data.Codigo + "'>editar</a>"; } }, { "targets": [0], "visible": false}]
        });
    }, 150);

</script>
<a href="<%: Url.Action("Create", "MedioPago") %>">
    <img src="/Content/img/add.png" style="width:30px;height:30px" /> Agregar
</a>>
</asp:Content>