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
            <input id ="CancelarBtn" type="button" value="Cancelar" onclick="window.history.back();" />
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

    <script src="../../Content/js/sweetalert2.js"></script>

</asp:Content>

