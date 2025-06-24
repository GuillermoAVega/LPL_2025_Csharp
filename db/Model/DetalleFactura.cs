using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "detalle_factura")]
    public partial class DetalleFactura
    {
        #region variables locales
        private int _cod_factura;
        private int _renglon;
        private int _cod_producto;
        private float _precio_unit;
        private int _cantidad;
        private Factura _factura = null;
        private Producto _producto = null;
        #endregion

        #region propiedades publicas

        [Propiedad(Name = "cod_factura", Tipo = typeof(int), EsAutoGenerado = false, EsClave = true)]
        public int CodFactura
        {
            get { return _cod_factura; }
            set { _cod_factura = value; }
        }
             
        [Propiedad(Name = "renglon", Tipo = typeof(int))]
        public int Renglon
        {
            get { return _renglon; }
            set { _renglon = value; }
        }

        [Propiedad(Name = "cod_producto", Tipo = typeof(int))]
        public int CodProducto
        {
            get { return _cod_producto; }
            set { _cod_producto = value; }
        }
       
        [Propiedad(Name = "precio_unit", Tipo = typeof(float))]
        public float PrecioUnit
        {
            get { return _precio_unit; }
            set { _precio_unit = value; }
        }

        [Propiedad(Name = "cantidad", Tipo = typeof(int))]
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
     
        #endregion       
 
        #region Relaciones con otras entidades
        //Factura
        //Producto
        #endregion
    }

}
