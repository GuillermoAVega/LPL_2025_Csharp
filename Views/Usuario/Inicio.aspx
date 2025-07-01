<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteAppUsr.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Inicio
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Inicio</h2>

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