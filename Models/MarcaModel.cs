using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AltaLlantaCo.db;

namespace WebDemo.Models
{
    public class MarcaModel
    {
        public int Codigo { get; set; }

        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
    }

    public class DataTableMarca
    {
        public List<MarcaModel> data { get; set; }
    }

    public class MarcaStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return Marca.FindAllStatic().Select(marca => new SelectListItem { Text = marca.Descripcion, Value = marca.Codigo.ToString() }).ToList();
        }
    }




}