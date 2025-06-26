using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel;
using AltaLlantaCo.db;
using System.Web.Mvc;

namespace WebDemo.Models
{

    public class ProductoModel
    {
        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public int CodCategoria { get; set; }
        public List<SelectListItem> CategoriaList { get; set; }

        [Required]
        [DisplayName("Marca")]
        public int CodMarca { get; set; }
        public List<SelectListItem> MarcaList { get; set; }

        [Required]
        [DisplayName("Precio")]
        public float Precio { get; set; }

        [Required]
        [DisplayName("Stock")]
        public float Stock { get; set; }

        [DisplayName("Disponibilidad")]
        public bool Disponibilidad { get; set; }

        public int Codigo { get; set; }
    }


    public class ProductoModelViewList
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public float Precio { get; set; }
        public float Stock { get; set; }
        public string Disponibilidad { get; set; }
    }

    public class DataTableProducto
    {
        public List<ProductoModelViewList> data { get; set; }
    }


}