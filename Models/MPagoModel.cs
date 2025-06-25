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
    public class MPagoModel
    {
        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        public int Codigo { get; set; }

    }
    public class DataTableMpago
    {
        public List<MPagoModel> data { get; set; }
    }
    public class MPagoStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return MedioPago.FindAllStatic().Select(mp => new SelectListItem { Text = mp.Descripcion, Value = mp.Codigo.ToString() }).ToList();
        }
    }

}