using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class MedioPago : BaseClass, IAccessDB<MedioPago>, IImpleCodigo
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionMedioPagoGuardar;
        public List<MedioPago> FindAll()
        {
            return this.FindAll(null);
        }
        public List<MedioPago> FindAll(string criterio)
        {
            return ORMDB<MedioPago>.FindAll(criterio); 
        }
        public MedioPago FindbyKey(params object[] key)
        {
            var forma = ORMDB<MedioPago>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.Codigo= forma.Codigo;
            this.Descripcion= forma.Descripcion;
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionMedioPagoGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    if(Descripcion == "" )
                        ValidacionMedioPagoGuardar("No se puede poner Descripcion vacia");
                }
            }
            return ORMDB<MedioPago>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-MedioPago
        public static List<MedioPago> FindAllStatic(string criterio=null, Comparison<MedioPago> compara=null)
        {
            var lista = ORMDB<MedioPago>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static MedioPago FindByKeyStatic(params object[] key)
        {
            return ORMDB<MedioPago>.FindbyKey(key);
        }
    }
}
