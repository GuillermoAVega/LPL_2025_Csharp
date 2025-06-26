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
    public class SucursalDestModel
    {
        [Required]
        [DisplayName("Sucursal Origen")]
        public int CodSucOrigen { get; set; }
        public List<SelectListItem> SucursalesOrigenList { get; set; }

        [Required]
        [DisplayName("Sucursal Destino")]
        public int CodSucDestino { get; set; }
        public List<SelectListItem> SucursalesDestList { get; set; }

        [Required]
        [DisplayName("Kilometraje")]
        public int Km { get; set; }
        
    }

    public class RutaModelViewList 
    {
        public int Km { set; get; }
        public string SucursalOrigen { set; get; }
        public string SucursalDestino { set; get; }

    }

    public class DataTableRuta
    {
        public List<RutaModelViewList> data { get; set; }
    }
        

}