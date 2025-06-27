<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<List<WebDemo.Models.DetalleFacturaView>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Factura 
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3> Productos Comprados </h3>

    <table id="list-productos-factura" class="table table-striped">
        <thead>
            <tr>
                <th> Producto </th>
                <th> Precio </th>
                <th> Cantidad </th>
                <th></th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>

    <script type="text/javascript" >
        window.setTimeout(function () {
            var table = $('#list-productos-factura').DataTable({
                "language": { "url": "/Content/js/Spanish.json" },
                "ajax": '/Factura/Listar',
                "columns": [{ "data": "Producto" }, { "data": "Precio" }, { "data": "Cantidad" }, { "data": null}],
                "columnDefs": [{ "targets": 3, "render": function (data, type, row, meta) {
                    return "";
                } 
                }]
            });
        }, 150);

    </script>    
    
    <script src="../../Content/js/sweetalert2.js"></script>
</asp:Content>    
    
    
    

