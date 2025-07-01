<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteAppUsr.Master" Inherits="System.Web.Mvc.ViewPage<WebDemo.Models.UsuarioClaveCambioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Inicio Usuario
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row static-top shadow" > 
    <div class="col-md-12">
    <h2>Iniciar Sesion</h2>
    </div>
</div>
<br />


    <% using (Html.BeginForm( "Login", "Usuario", FormMethod.Post))
       { %>
    
    <fieldset>
    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Usuario) %></div>
        <div class="col-md-2">
        <%: Html.TextBoxFor(m => m.Usuario) %>
        <%: Html.ValidationMessageFor(m => m.Usuario)%></div>
    </div>

    <div class="row">
        <div class="col-md-2"><%: Html.LabelFor(m => m.Clave) %></div>
        <div class="col-md-2"><%: Html.PasswordFor(m => m.Clave) %>
        <%: Html.ValidationMessageFor(m => m.Clave)%></div>
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
    <script src="../../Content/js/sweetalert2.js"></script>

</asp:Content>


