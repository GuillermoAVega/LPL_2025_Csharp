using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltaLlantaCo.db;
using WebDemo.Models;
using Newtonsoft.Json;
using System.Text;

namespace WebDemo.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View();
        }        
        public ActionResult Create()
        {            
            var model = new ClienteModel();
            model.LocalidadesList = LocalidadStatic.GetListado();
            return View(model);
        }
        
        public ActionResult Show(int codigoUsuario)
        {            
            var cli = Cliente.FindByKeyStatic(codigoUsuario);
            if (cli == null)
                return Redirect("/Cliente");
            var model = new ClienteModel { Cuil = cli.Cuil,RazonSocial = cli.RazonSocial,Celular=cli.Celular,Direccion=cli.Direccion, CodPostal=cli.CodPostal,Clave=cli.Clave,ConfirmaClave=cli.Clave, Email=cli.Email,
                                           LocalidadesList = LocalidadStatic.GetListado(), Usuario=cli.Usuario};
            model.Codigo = codigoUsuario;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ClienteModel model)        
        {
            model.LocalidadesList = LocalidadStatic.GetListado();         
            if (!ModelState.IsValid)
                return View(model);
            
            Cliente cli = new Cliente
            {
                Usuario = model.Usuario,
                Clave = model.Clave,
                Cuil = model.Cuil,
                RazonSocial = model.RazonSocial,
                Direccion = model.Direccion,
                CodPostal = model.CodPostal,
                Email = model.Email,
                Celular = model.Celular
            };

            if (cli.SaveObj())
                Redirect("/Cliente");

            return RedirectToAction("/Create");            
        }

        [HttpPost]
        public ActionResult Update(ClienteModel model)
        {
            model.LocalidadesList = LocalidadStatic.GetListado();


            if (ModelState.IsValid)
                return Redirect("/Cliente");

            Cliente cli = Cliente.FindByKeyStatic(model.Codigo);
            cli.Usuario = model.Usuario;
            cli.Clave = model.Clave;
            cli.RazonSocial = model.RazonSocial;
            cli.Direccion = model.Direccion;
            cli.CodPostal = model.CodPostal;
            cli.Email = model.Email;
            cli.Celular = model.Celular;

            if (!cli.SaveObj())
                Redirect("/ClienteError");
            return RedirectToAction("/");            
        }

        public ActionResult ClienteError()
        {
            return View(); 
        }

        public ActionResult Listar(int? codPostal)
        {
            List<Cliente> clientes = Cliente.FindAllStatic();
            List<Cliente> filtrados = new List<Cliente>();

            if (codPostal.HasValue && codPostal.Value != 0)
            {
                foreach (Cliente c in clientes)
                {
                    if (c.CodPostal == codPostal.Value)
                    {
                        filtrados.Add(c);
                    }
                }
            }
            else
            {
                filtrados = clientes;
            }

            List<ClienteModelViewList> resultado = new List<ClienteModelViewList>();

            foreach (Cliente e in filtrados)
            {
                ClienteModelViewList item = new ClienteModelViewList(); item.Codigo = e.Codigo;item.Cuil = e.Cuil;item.Usuario = e.Usuario;item.RazonSocial = e.RazonSocial;
                item.Email = e.Email; item.Clave = e.Clave;item.Direccion = e.Direccion;item.Celular = e.Celular;item.Localidad = (e.LocalidadObj != null) ? e.LocalidadObj.Nombre : "";

                resultado.Add(item);
            }

            DataTableCliente datatable = new DataTableCliente();
            datatable.data = resultado;

            return Content(JsonConvert.SerializeObject(datatable), "application/json");
        }

        public ActionResult Listado()
        {
            var model = new List<SelectListItem>();

            model = LocalidadStatic.GetListado();

            return View(model);
        }


        //Listado mejores compradores

        public ActionResult ListadoCompradores() 
        {
            var model = ClienteModelStatic.GetListadoMejoresCompradores();

            return View(model); 
        }

        public ActionResult ListarCompradores() 
        {
            var datatable = new DataTableComprador {
                data = ClienteModelStatic.GetListadoMejoresCompradores().Select(e => new MejorCompradorView{

                    Codigo = e.Codigo,
                    Cuil = e.Cuil,
                    Usuario = e.Usuario,
                    RazonSocial = e.RazonSocial,
                    Email = e.Email,
                    Direccion = e.Direccion,
                    Localidad = e.Localidad,
                    Celular = e.Celular,
                    CantidadCompras = e.CantidadCompras

            }).ToList() };

            return Content(JsonConvert.SerializeObject(datatable));
        }



        public ActionResult ExportarListado(string nombreArchivo, string formato)
        {
            // Assuming you have a method to get the file data as a byte array
            var clientes = ClienteModelStatic.GetListadoMejoresCompradores();
            byte[] archivoBytes;
            string fileName;

            if (formato == "csv")
            {
                // Generar archivo CSV
                var csv = new StringBuilder();
                csv.AppendLine("Cuil, Usuario , RazonSocial, Email, Direccion, Localidad, Celular, Compras Realizadas");

                foreach (var cliente in clientes)
                {
                    csv.AppendLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", 
                        cliente.Cuil,
                        cliente.Usuario,
                        cliente.RazonSocial, 
                        cliente.Email,
                        cliente.Direccion,
                        cliente.Localidad,
                        cliente.Celular,
                        cliente.CantidadCompras
                        ));
                }

                archivoBytes = System.Text.Encoding.UTF8.GetBytes(csv.ToString());
                fileName = String.Format("{0}.csv", nombreArchivo);
            }
            else
            {
                // Generar archivo TXT
                var txt = new StringBuilder();
                txt.AppendLine(string.Format("{0,-15} {1,-15} {2,-20} {3,-25} {4,15} {5,20} {6,20} {7,25}", "Cuil", "Usuario", "RazonSocial", "Email", "Direccion", "Localidad", "Celular", "Compras Realizadas"));

                txt.AppendLine(new string('-', 170)); // Separador

                foreach (var cliente in clientes)
                {
                    txt.AppendLine(string.Format("{0,-15} {1,-15} {2,-20} {3,-25} {4,20} {5,20} {6,20} {7,10}",
                        cliente.Cuil,
                        cliente.Usuario,
                        cliente.RazonSocial,
                        cliente.Email,
                        cliente.Direccion,
                        cliente.Localidad,
                        cliente.Celular,
                        cliente.CantidadCompras
                        ));
                }

                archivoBytes = System.Text.Encoding.UTF8.GetBytes(txt.ToString());
                fileName = String.Format("{0}.txt", nombreArchivo);
            }


            return File(archivoBytes, "text/csv", fileName);
        }


        [HttpPost]
        public ActionResult ExportarTxt(int? CodigoPostal)
        {
            List<Cliente> clientes;

            if (CodigoPostal != null)
                clientes = Cliente.FindAllStatic(String.Format("cod_postal = {0}", CodigoPostal));
            else
                clientes = Cliente.FindAllStatic();

            byte[] archivoBytes;
            string fileName;

            var txt = new StringBuilder();
            txt.AppendLine(string.Format("{0,-15} {1,-15} {2,-20} {3,-25} {4,15} {5,20} {6,20} ", "Cuil", "Usuario", "RazonSocial", "Email", "Direccion", "Localidad", "Celular"));

            txt.AppendLine(new string('-', 170)); // Separador

            foreach (var cliente in clientes)
            {
                txt.AppendLine(string.Format("{0,-15} {1,-15} {2,-20} {3,-25} {4,20} {5,20} {6,20}",
                    cliente.Cuil,
                    cliente.Usuario,
                    cliente.RazonSocial,
                    cliente.Email,
                    cliente.Direccion,
                    cliente.LocalidadObj.Nombre,
                    cliente.Celular
                    ));
            }

            archivoBytes = System.Text.Encoding.UTF8.GetBytes(txt.ToString());
            fileName = String.Format("{0}.txt", "archivo");

            return File(archivoBytes, "text/csv", fileName);
        }



    }
}
