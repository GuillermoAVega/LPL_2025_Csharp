using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltaLlantaCo.db;
using WebDemo.Models;
using Newtonsoft.Json;

namespace WebDemo.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new ProductoModel();
            model.CategoriaList = Categoria.FindAllStatic().Select(categoria => new SelectListItem { Text = categoria.Descripcion, Value = categoria.Codigo.ToString() }).ToList();
            model.MarcaList = MarcaStatic.GetListado();
            return View(model);
        }


        public ActionResult Show(int codigoProducto)
        {
            var producto = Producto.FindByKeyStatic(codigoProducto);

            if (producto == null)
                return Redirect("/Producto");

            var model = new ProductoModel
            {
                CategoriaList = Categoria.FindAllStatic().Select(categoria => new SelectListItem { Text = categoria.Descripcion, Value = categoria.Codigo.ToString() }).ToList(),
                MarcaList = MarcaStatic.GetListado(),
                Descripcion = producto.Descripcion,
                CodCategoria = producto.CodCategoria,
                CodMarca = producto.CodCategoria,
                Precio = producto.Precio,
                Stock = producto.Stock,
                Disponibilidad = producto.Disponible
            };

            model.Codigo = codigoProducto;

            return View(model);
        }



        [HttpPost]
        public ActionResult Create(ProductoModel model)
        {
            model.CategoriaList = Categoria.FindAllStatic().Select(categoria => new SelectListItem { Text = categoria.Descripcion, Value = categoria.Codigo.ToString() }).ToList();
            model.MarcaList = MarcaStatic.GetListado();


            if (!ModelState.IsValid)
                return View(model);

            Producto producto = new Producto
            {
                CodCategoria = model.CodCategoria,
                CodMarca = model.CodMarca,
                Precio = model.Precio,
                Stock = model.Stock,
                Disponible = model.Disponibilidad,
                Descripcion = model.Descripcion
            };

            if (producto.SaveObj())
                Redirect("/Producto");

            return RedirectToAction("/Create");
        }



        [HttpPost]
        public ActionResult Update(ProductoModel model)
        {
            model.CategoriaList = Categoria.FindAllStatic().Select(categoria => new SelectListItem { Text = categoria.Descripcion, Value = categoria.Codigo.ToString() }).ToList();
            model.MarcaList = MarcaStatic.GetListado();

            if (!ModelState.IsValid)
                return View(model);

            Producto producto = Producto.FindByKeyStatic(model.Codigo);
            producto.Precio = model.Precio;
            producto.CodCategoria = model.CodCategoria;
            producto.CodMarca = model.CodMarca;
            producto.Stock = model.Stock;
            producto.Disponible = model.Disponibilidad;
            producto.Descripcion = model.Descripcion;


            if (!producto.SaveObj())
                Redirect("/ProductoError"); //Implementar.

            return RedirectToAction("/");
        }


        public ActionResult ProductoError()
        {
            return View();
        }

        /*
        public ActionResult Listar()
        {
            var datatable = new DataTableProducto { data = Producto.FindAllStatic().Select(e => new ProductoModelViewList {
                Descripcion = e.Descripcion,
                Marca = e.MarcaObj.Descripcion,
                Categoria = e.CategoriaObj.Descripcion,
                Precio = e.Precio,
                Stock = e.Stock,
                Disponibilidad = e.Disponible
            }).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }
        */




        public ActionResult Listar()
        {
            var datatable = new DataTableProducto { data = Producto.FindAllStatic().Select(e => new ProductoModelViewList { Codigo = e.Codigo, Descripcion = e.Descripcion, Marca = e.MarcaObj.Descripcion, Categoria = e.CategoriaObj.Descripcion, Precio = e.Precio, Stock = e.Stock, Disponibilidad = e.Disponible.ToString() }).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }
    }


}
