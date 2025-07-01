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
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class ExisteUsuarioAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' ya existe registrado!";
        private readonly object _typeId = new object();

        public ExisteUsuarioAttribute(string usuarioProperty, string claveProperty)
            : base(_defaultErrorMessage)
        {
            UsuarioProperty = usuarioProperty;
            ClaveProperty = claveProperty;
        }

        public string UsuarioProperty { get; private set; }
        public string ClaveProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, UsuarioProperty);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object userValue = properties.Find(UsuarioProperty, true).GetValue(value);
            object claveValue = properties.Find(ClaveProperty, true).GetValue(value);
            var listusers = Cliente.FindAllStatic("usuario ='" + userValue + "' and clave = '" + claveValue+ "'");
            if (listusers != null)
                if (listusers.Count > 0)
                    return true;
            return false;
            // Buscar en la Base
            //return false;
        }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class ClaveValidaUsuarioAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' and '{1}' no coinciden.";
        private readonly object _typeId = new object();

        public ClaveValidaUsuarioAttribute(string originalProperty, string confirmProperty)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            object confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            if (confirmValue == null)
                return true;
            return Object.Equals(originalValue, confirmValue);
        }
    }
    [ExisteUsuario("Usuario", "Clave", ErrorMessage = "Credenciales no validas")]
    [ClaveValidaUsuario("Clave", "ConfirmaClave", ErrorMessage = "La clave y la confirmacion no coinciden.")]
    public class UsuarioClaveCambioModel
    {
        [Required]
        [DisplayName("Usuario")]
        public string Usuario { get; set; }

        [Required]
        [DisplayName("Clave")]
        public string Clave { get; set; }

        [Required]
        [DisplayName("Confirma Clave")]
        public string ConfirmaClave { get; set; }


    }

    public class UsuarioModel
    {
        [Required]
        [DisplayName("Usuario")]
        public string Usuario { get; set; }

        [Required]
        [DisplayName("Clave")]
        public string Clave { get; set; }

        [Required]
        [DisplayName("Confirma Clave")]
        public string ConfirmaClave { get; set; }

        private List<Compra> compras;

        public List<Compra> Compras
        {
            get { return UsuarioModel.GetListadoCompras(this.Usuario); }


            set { compras = value; }
        }

        public static Cliente GetCliente(string nombreUsuario) 
        {
            List<Cliente> usuarios = Cliente.FindAllStatic(String.Format("usuario = '{0}'", nombreUsuario));
            return usuarios[0];
        }


        public static List<Compra> GetListadoCompras(string nombreUsuario) {

            var cliente = UsuarioModel.GetCliente(nombreUsuario);

            var listaFacturas = Factura.FindAllStatic(String.Format("cod_cliente = {0}", cliente.Codigo)); 

            List<Compra> listaCompras = new List<Compra>();

            foreach(var factura in listaFacturas)
            {

                var compras = Compra.FindAllStatic(String.Format("cod_factura = {0}", factura.Codigo));
                listaCompras.Add(compras[0]);
            
            }
            
            return listaCompras;
        }
    }
}