using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltaLlantaCo.db
{
    [Table(Name = "cliente")]
    public partial class Cliente
    {
        #region variables locales
        private int _codigo;
        private string _usuario;
        private string _clave;
        private string _cuil;
        private string _razon_social;
        private string _direccion;
        private int _cod_postal;
        private string _email;
        private string _celular;
        // usado para relacion con la clase Localidad, carga Lazy
        private Localidad _localidad = null;        
        #endregion        

        #region propiedades publicas

        [Propiedad(Name = "codigo", Tipo = typeof(int),EsAutoGenerado=true, EsClave=true) ]
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
             
        [Propiedad(Name = "usuario", Tipo = typeof(string), Longitud = 90)]
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        [Propiedad(Name = "clave", Tipo = typeof(string), Longitud = 120)]
        public string Clave
        {
            get { return _clave; }
            set { _clave= value; }
        }

        [Propiedad(Name = "cuil", Tipo = typeof(string), Longitud = 20)]
        public string Cuil
        {
            get { return _cuil; }
            set { _cuil = value; }
        }

        [Propiedad(Name = "razon_social", Tipo = typeof(string), Longitud = 90)]        
        public string RazonSocial
        {
            get { return _razon_social; }
            set { _razon_social = value; }
        }

        [Propiedad(Name = "direccion", Tipo = typeof(string), Longitud = 120)]
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        [Propiedad(Name = "cod_postal", Tipo = typeof(int))]
        public int CodPostal
        {
            get { return _cod_postal; }
            set {
                if (value != _cod_postal && value > 0)
                    this._localidad = null;
                _cod_postal = value;
            }
        }

        [Propiedad(Name = "email", Tipo = typeof(string), Longitud = 90)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [Propiedad(Name = "celular", Tipo = typeof(string), Longitud = 200)]
        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }
        #endregion  

        #region Relaciones con otras entidades
        public Localidad LocalidadObj
        {
            get {
                if (_localidad == null && _cod_postal != 0)
                {
                    _localidad = Localidad.FindByKeyStatic(_cod_postal);
                }
                return _localidad;
            }
        }    
        
        #endregion

    }
}
