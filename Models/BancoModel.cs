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
    public class BancoModel
    {
        public int codigo { set; get; }

        [Required]
        [DisplayName("Nombre")]
        public string nombre { set; get; }

        [Required]
        [DisplayName("Direccion")]
        public string direccion { set; get; }

        [Required]
        [DisplayName("Telefono")]
        public string telefono { set; get; }

    }

    public class DataTableBanco
    {
        public List<BancoModel> data { get; set; }
    }

    public class BancoStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return Banco.FindAllStatic().Select(banco => new SelectListItem { Text = banco.Nombre, Value = banco.Codigo.ToString() }).ToList();
        }
    }


}