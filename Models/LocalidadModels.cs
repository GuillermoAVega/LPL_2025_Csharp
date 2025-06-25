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
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,CodPostalProperty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);

             // Si es edición, no validamos
             object esCreacionValue = properties.Find("EsCreacion", true).GetValue(value);
             if (esCreacionValue != null && esCreacionValue is bool && !(bool)esCreacionValue)
                return true;

            object originalValue = properties.Find(CodPostalProperty, true).GetValue(value);

            if (originalValue == null)
                return false;

            int codigo;
            if (!int.TryParse(originalValue.ToString(), out codigo))
                return false;

            var Loc = Localidad.FindByKeyStatic(codigo);
            return Loc == null;
          
        }
    }

    [UniqueCodPostal("CodigoPostal", ErrorMessage = "Debe ingresar codigo postal unico.")]


    public class LocalidadModel
    {
        public bool EsCreacion { get; set; }


        [Required]
        [DisplayName("Codigo Postal")]
        public int CodigoPostal { get; set; }

        [Required]        
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        public List<SelectListItem> LocalidadesList { get; set; }
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