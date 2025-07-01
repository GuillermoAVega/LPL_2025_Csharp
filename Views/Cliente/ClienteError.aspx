<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteApp.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Error 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Error </h2>
    <script type="text/javascript">
    window.setTimeout(function(){
    Swal.fire({
                        title: 'Oops!...',
                        text: 'Se encontro un error!',
                        type: 'error',
                        showCancelButton: false,
                        confirmButtonColor: '#3085d6',
                        //cancelButtonColor: '#d33',
                        confirmButtonText: 'Aceptar'
                    }).then((result) => {
                        if (result.value) {
                            
							}
                    });
                    },200);
</script>
</asp:Content>
