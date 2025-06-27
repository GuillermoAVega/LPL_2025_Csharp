<%@ Page Title="Listado de Clientes" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<List<SelectListItem>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Listado de Clientes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% using (Html.BeginForm("Listado", "Cliente", FormMethod.Post)) { %>

        <fieldset>
            <legend>Filtrar por Localidad</legend>

            <div>
                <label for="codpostal">Localidad:</label>
                <%= Html.DropDownList(
                        "CodigoPostal",
                        (List<SelectListItem>)Model,
                        "-- Todas las localidades --"
                    ) %>

            </div>
            <div style="align-self: flex-end; ">
                    <input type="button" id="btnfiltrar" value="Filtrar" class="btn btn-primary" style="flex-end"/>
            </div>

        </fieldset>

    <% } %>

    <h3>Clientes</h3>

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
<th></th>
</tr>
</thead>
<tbody></tbody>
</table>
<script type="text/javascript" >
    window.setTimeout(function () {
        var table = $('#list-clientes').DataTable({
            "language": { "url": "/Content/js/Spanish.json" },
            "ajax": {
                "url": '<%= Url.Action("Listar", "Cliente") %>',
                "data": function (d) {
                    d.codPostal = $('#CodigoPostal').val();
                }
            },
            "columns": [{ "data": "Codigo" }, { "data": "Cuil" }, { "data": "Usuario" }, { "data": "RazonSocial" }, { "data": "Email" }, { "data": "Clave" }, { "data": "Direccion" }, { "data": "Localidad" }, { "data": "Celular" }, { "data": null}],
            "columnDefs": [{ "targets": 9, "render": function (data, type, row, meta) { return "<a href='/Cliente/Show?codigoUsuario=" + data.Codigo + "'>editar</a>"; } }, { "targets": [0, 5], "visible": false}]
        });
        
        // Recargar con nuevo filtro al hacer clic en "Filtrar"
        $('#btnfiltrar').on('click', function () {
            table.ajax.reload();
        });
    }, 150);

</script>



</asp:Content>
