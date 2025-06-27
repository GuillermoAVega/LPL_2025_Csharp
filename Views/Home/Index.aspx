<%@ Page Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Inicio
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

    <div class="text-center">
        <h1 class="display-4 text-primary font-weight-bold mt-4">¡Bienvenido a Alta Llanta!</h1>
        <h5 class="text-secondary mb-4">Marcelo agachate y conocelo!!!</h5>

        <img src="../../Content/img/taller-llantas.jpg" alt="Taller Alta Llanta" style="max-width: 500px; width: 100%; height: auto; border-radius: 15px; box-shadow: 0 0 20px rgba(0,0,0,0.2);" />

        <p class="mt-4 lead text-dark" style="max-width: 700px; margin: auto;">
            Somos líderes en productos y servicios para talleres mecánicos, ofreciendo las mejores llantas, herramientas y accesorios para mantener tu vehículo en óptimas condiciones. 
            En <strong>Alta Llanta</strong>, combinamos calidad, atención personalizada y compromiso con el cliente.
        </p>

        <div class="mt-5">
            <a href="/Producto/Listado" class="btn btn-primary btn-lg">Ver productos</a>
            <a href="/Cliente/Create" class="btn btn-outline-primary btn-lg ml-2">Registrate</a>
        </div>
    </div>

</asp:Content>
