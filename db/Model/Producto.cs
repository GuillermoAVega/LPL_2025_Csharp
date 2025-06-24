using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltaLlantaCo.db
{
    [Table(Name = "producto")]
    public partial class Producto
    {
        #region variables locales
        private int _codigo;
        private int _cod_categoria;
        private int _cod_marca;
        private float _precio;
        private float _stock;
        private bool _disponible;
        // usado para relacion con la clase marca, carga Lazy
        private Marca _marca = null;
        private Categoria _categoria= null;        
        #endregion        

        #region propiedades publicas

        [Propiedad(Name = "codigo", Tipo = typeof(int),EsAutoGenerado=true, EsClave=true)]
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        [Propiedad(Name = "cod_categoria", Tipo = typeof(int))]
        public int CodCategoria
        {
            get { return _cod_categoria; }
            set
            {
                if (value != _cod_categoria && value > 0)
                    this._categoria = null;
                _cod_categoria = value;
            }
        }
        
        [Propiedad(Name = "cod_marca", Tipo = typeof(int))]
        public int CodMarca
        {
            get { return _cod_marca; }
            set {
                if (value != _cod_marca && value > 0)
                    this._marca = null;
                _cod_marca = value;
            }
        }

        [Propiedad(Name = "precio", Tipo = typeof(float))]
        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        [Propiedad(Name = "stock", Tipo = typeof(float))]
        public float Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        [Propiedad(Name = "disponible", Tipo = typeof(bool))]
        public bool Disponible
        {
            get { return _disponible; }
            set { _disponible = value; }
        }

        #endregion  

        #region Relaciones con otras entidades
        //Marca
        //Categoria
        #endregion

    }
}
