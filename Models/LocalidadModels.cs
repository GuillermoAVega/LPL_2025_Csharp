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
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class UniqueCodPostalAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' ya existe registrado!";
        private readonly object _typeId = new object();

        public UniqueCodPostalAttribute(string codpostalProperty)
            : base(_defaultErrorMessage)
        {
            CodPostalProperty = codpostalProperty;
        }

        public string CodPostalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, CodPostalProperty);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(CodPostalProperty, true).GetValue(value);
            var Loc = Localidad.FindByKeyStatic(originalValue);
            return Loc == null;
            // Buscar en la Base
            //return false;
        }
    }

    [UniqueCodPostal("CodigoPostal", ErrorMessage = "Debe ingresar codigo postal unico.")]
    public class LocalidadModel
    {
        [Required]
        [DisplayName("Codigo Postal")]
        public int CodigoPostal { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
    }
    public class DataTableLocalidad
    {
        public List<LocalidadModel> data { get; set; }
    }
    public class LocalidadStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return Localidad.FindAllStatic().Select(loc => new SelectListItem { Text = loc.Nombre, Value = loc.Codigo.ToString() }).ToList();
        }
    }
}
 