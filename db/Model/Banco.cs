using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "banco")]
    public partial class Banco
    {
        #region variables locales
        private int _Codigo;
        private string _nombre;
        private string _direccion;
        private string _telefono;        
        #endregion

        #region propiedades publicas

        [Propiedad(Name = "codigo", Tipo = typeof(int), EsAutoGenerado = true, EsClave = true)]
        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        [Propiedad(Name = "nombre", Tipo = typeof(string), Longitud = 50)]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        [Propiedad(Name = "direccion", Tipo = typeof(string), Longitud = 90)]
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        [Propiedad(Name = "telefono", Tipo = typeof(string), Longitud = 25)]
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        
        #endregion        
       
    }

}
