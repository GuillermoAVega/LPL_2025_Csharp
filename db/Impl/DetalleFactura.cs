using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class DetalleFactura : BaseClass, IAccessDB<DetalleFactura>
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionDetalleFacturaGuardar;
        public List<DetalleFactura> FindAll()
        {
            return this.FindAll(null);
        }
        public List<DetalleFactura> FindAll(string criterio)
        {
            return ORMDB<DetalleFactura>.FindAll(criterio); 
        }
        public DetalleFactura FindbyKey(params object[] key)
        {
            var fac = ORMDB<DetalleFactura>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.CodFactura = fac.CodFactura;
            this.Cantidad = fac.Cantidad;
            this.CodProducto = fac.CodProducto;
            this.PrecioUnit=fac.PrecioUnit;
            this.Renglon = fac.Renglon;            
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionDetalleFacturaGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    
                }
            }
            return ORMDB<DetalleFactura>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-DetalleFactura
        public static List<DetalleFactura> FindAllStatic(string criterio=null, Comparison<DetalleFactura> compara=null)
        {
            var lista = ORMDB<DetalleFactura>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static DetalleFactura FindByKeyStatic(params object[] key)
        {
            return ORMDB<DetalleFactura>.FindbyKey(key);
        }
    }
}
