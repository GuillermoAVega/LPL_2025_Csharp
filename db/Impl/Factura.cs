using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class Factura : BaseClass, IAccessDB<Factura>
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionFacturaGuardar;
        public List<Factura> FindAll()
        {
            return this.FindAll(null);
        }
        public List<Factura> FindAll(string criterio)
        {
            return ORMDB<Factura>.FindAll(criterio); 
        }
        public Factura FindbyKey(params object[] key)
        {
            var fac = ORMDB<Factura>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.Nro = fac.Nro;
            this.Serie = fac.Serie;
            this.Letra = fac.Letra;
            this.Fecha = fac.Fecha;
            this.CodCliente= fac.CodCliente;
            this.CodMedioPago = fac.CodMedioPago;
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionFacturaGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    
                }
            }
            return ORMDB<Factura>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-Factura
        public static List<Factura> FindAllStatic(string criterio=null, Comparison<Factura> compara=null)
        {
            var lista = ORMDB<Factura>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static Factura FindByKeyStatic(params object[] key)
        {
            return ORMDB<Factura>.FindbyKey(key);
        }
    }
}
