<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<List<WebDemo.Models.MejorCompradorView>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Clientes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Content/vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="../../Content/vendor/datatables/dataTables.bootstrap4.min.js"></script>

    <br />
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1> Mejores compradores </h1>
    </div>

    <table id="list-mejores-compradores" class="table table-striped">
        <thead>
            <tr>
                <th>Codigo</th>
                <th>Cuil</th>
                <th>Usuario</th>
                <th>Razon Social</th>
                <th>Email</th>
                <th>Direccion</th>
                <th>Localidad</th>
                <th>Celular</th>
                <th>Compras Realizadas</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>

    <br />
    <h2>Exportar listado</h2>

    <input id="nombreArchivo" type="text" placeholder="Nombre del archivo" />

    <button id="btnDescargar" style="background-color: #007bff; color: white; border-radius: 5px;">
        Descargar
    </button>


    <script type="text/javascript" >
        window.setTimeout(function () {
            var table = $('#list-mejores-compradores').DataTable({
                "language": { "url": "/Content/js/Spanish.json" },
                "ajax": '/Cliente/ListarCompradores',
                "columns": [{ "data": "Codigo" }, { "data": "Cuil" }, { "data": "Usuario" }, { "data": "RazonSocial" }, { "data": "Email" }, { "data": "Direccion" }, { "data": "Localidad" }, { "data": "Celular" }, { "data": "CantidadCompras"}],
                "columnDefs": [{ "targets": 0, "render": function (data, type, row, meta) { return "<a href='/Cliente/Show?codigoUsuario=" + data.Codigo + "'>editar</a>"; } }, { "targets": [0], "visible": false}],
                "searching": false,
                "lengthChange": false,
                "paging": false,
                "info": ""
            });
        }, 150);

    </script>
</asp:Content>
