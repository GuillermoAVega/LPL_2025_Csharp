using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "det_factura")]
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
        public Factura FacturaObj
        {
            get
            {
                if (_factura == null && _cod_factura != 0)
                {
                    _factura = Factura.FindByKeyStatic(_cod_factura);
                }
                return _factura;
            }
        }

        public Producto ProductoObj
        {
            get
            {
                if (_producto == null && _cod_producto != 0)
                {
                    _producto = Producto.FindByKeyStatic(_cod_producto);
                }
                return _producto;
            }
        }
        #endregion
    }

}
