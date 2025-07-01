<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteAppUsr.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.CompraView>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Compras realizadas
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Content/vendor/datatables/jquery.dataTables.min.js"> </script>
    <script src="../../Content/vendor/datatables/dataTables.bootstrap4.min.js"> </script>

<div class="d-sm-flex align-items-center  mb-4">
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


<asp:Content ID="Content3" ContentPlaceHolderID="MenuContent" runat="server">
<%if (ViewData["SesionIniciada"] != null)
  {%>
  <div class="sidebar-heading">
    usuario: <%: ViewData["usuario"] %>
   </div>
<div class="sidebar-heading">
    Gesti&oacute;n
</div>
<li class="nav-item active">
    <a class="nav-link" href="/Usuario/CambioClave">
        <i class="fas fa-fw fa-key"></i>
        <span>Cambio de clave</span></a>
</li>
<li class="nav-item active">
    <a class="nav-link" href="/Usuario/Comprar">   
		<i class="fas fa-fw fa-wallet"></i>
        <span>Mis Compras</span></a>
</li>

<!-- Divider -->
<hr class="sidebar-divider d-none d-md-block">

<!-- Sidebar Toggler (Sidebar) -->
<div class="text-center d-none d-md-inline">
    <button class="rounded-circle border-0" id="sidebarToggle"></button>
</div>            
<hr class="sidebar-divider">            
<li class="nav-item">
    <a class="nav-link" href="/">   				
        <span>Salir</span></a>            
</li>
<% } %>
</asp:Content>
