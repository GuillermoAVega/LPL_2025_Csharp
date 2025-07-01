<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Clientes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src="../../Content/vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="../../Content/vendor/datatables/dataTables.bootstrap4.min.js"></script>
<div class="d-sm-flex align-items-center justify-content-between mb-4">
<h1 class="h3 mb-0 text-gray-800">Clientes</h1>
</div>
<table id="list-clientes" class="table table-striped">
<thead>
<tr>
<th>Codigo</th>
<th>Cuil</th>
<th>Usuario</th>
<th>Razon Social</th>
<th>Email</th>
<th>Clave</th>
<th>Direccion</th>
<th>Localidad</th>
<th>Celular</th>
<th>Acciones</th>
</tr>
</thead>
<tbody></tbody>
</table>
<script type="text/javascript" >
    window.setTimeout(function () {
        var table = $('#list-clientes').DataTable({
            "language": { "url": "/Content/js/Spanish.json" },
            "ajax": '/Cliente/Listar',
            "columns": [{ "data": "Codigo" }, { "data": "Cuil" }, { "data": "Usuario" }, { "data": "RazonSocial" }, { "data": "Email" }, { "data": "Clave" }, { "data": "Direccion" }, { "data": "Localidad" }, { "data": "Celular" }, { "data": null}],
            "columnDefs": [{ "targets": 9, "render": function (data, type, row, meta) { return "<a href='/Cliente/Show?codigoUsuario="+data.Codigo+"'>editar</a>"; } }, { "targets": [0,5],"visible":false}]
        });
    }, 150);

</script>
<a href="/Cliente/Create"><img src="/Content/img/add.png" style="width:30px;height:30px"/>Agregar </a>
</asp:Content>
