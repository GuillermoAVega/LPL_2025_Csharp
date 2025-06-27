<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteAppUsr.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.UsuarioClaveCambioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cambio Clave
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row static-top shadow" > 
    <div class="col-md-12">
    <h2> Cambiar Clave </h2>
    </div>



</div>



<br />


    <% using (Html.BeginForm( "CambioClave", "Usuario", FormMethod.Post))
       { %>
    
    <fieldset>


    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Clave) %></div>
        <div class="col-md-2"><%: Html.PasswordFor(m => m.Clave) %>
        <%: Html.ValidationMessageFor(m => m.Clave)%></div>
    </div>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.ConfirmaClave) %></div>
        <div class="col-md-2">
        <%: Html.PasswordFor(m => m.ConfirmaClave)%>
        <%: Html.ValidationMessageFor(m => m.ConfirmaClave)%></div>
    </div>

    <hr />

    <div class="row">
        <div class="col-md-2">
            <input id ="CancelarBtn" type="button" value="Cancelar" />
        </div>
        <%if (ViewData["SesionIniciada"] != null)
          {%>
       <div class="col-md-2">
            <input id ="LoginBtn" type="submit" value="Guardar" />
        </div>
        <% }
          else
          { %>
        <div class="col-md-2">
            <input id ="Submit1" type="submit" value="Login" />
        </div>
        <%} %>
    </div>
    </fieldset>

    <% } %>

    <script type="text/javascript">
            window.setTimeout(function () {
                $("#Clave, #ConfirmaClave").val($("#hdnClave").val());
            }, 150);
    </script>


    <script src="../../Content/js/sweetalert2.js"></script>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MenuContent" runat="server">
<%if (ViewData["SesionIniciada"] != null)
  {%>
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