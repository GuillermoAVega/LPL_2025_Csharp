<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebDemo.Models.MedioPagoMasUsadoView>>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Medios de Pago
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />  
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1> Medios de pago mas usados</h1>
    </div>


    <table id="list-medios-de-pago-mas-usados" class="table table-striped">
        <thead>
            <tr>
                <th>Codigo</th>
                <th>Descripcion</th>
                <th>Banco</th>
                <th>Veces Usado</th>           
            </tr>
        </thead>
        <tbody></tbody>
    </table>


    <h2>Exportar listado</h2>

    <form method="post" action="/MedioPago/ExportarListado">
    <select id="formato" name="formato">
        <option value="csv"> CSV </option>
        <option value="txt" selected> TXT </option>
    </select>
    <label for="nombreArchivo"></label>
    <input id="Text1" name="nombreArchivo" type="text" placeholder="Nombre del archivo" />
    <button type="submit" style="background-color: #007bff; color: white; border-radius: 5px;">
        Descargar
    </button>

    </form>



    <script type="text/javascript" >
        window.setTimeout(function () {
            var table = $('#list-medios-de-pago-mas-usados').DataTable({
                "language": { "url": "/Content/js/Spanish.json" },
                "ajax": '/MedioPago/ListarMedios',
                "columns": [{ "data": "Codigo" }, { "data": "Descripcion" }, { "data": "Banco" }, { "data": "VecesUsado"}],
                "columnDefs": [{ "targets": 0, "render": function (data, type, row, meta) { return "<a href='/MedioPago/Show?codigo=" + data.Codigo + "'>editar</a>"; } }, { "targets": [0], "visible": false}],
                "searching": false,
                "lengthChange": false,
                "paging": false,
                "info": ""
            });
        }, 150);

    </script>
</asp:Content>