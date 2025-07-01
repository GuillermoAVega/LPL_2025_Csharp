<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteAppUsr.Master" Inherits="System.Web.Mvc.ViewPage<List<WebDemo.Models.DetalleFacturaView>>" %>

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
        <span>Compras</span></a>
</li>

           
<!-- Divider -->
<hr class="sidebar-divider d-none d-md-block">

<!-- Sidebar Toggler (Sidebar) -->
<div class="text-center d-none d-md-inline">
    <button class="rounded-circle border-0" id="sidebarToggle"></button>
</div>            
<hr class="sidebar-divider">            
<li class="nav-item">
    <a class="nav-link" href="/Home/About">   				
        <span>Salir</span></a>            
</li>
<% } %>
</asp:Content>
    
    
    

