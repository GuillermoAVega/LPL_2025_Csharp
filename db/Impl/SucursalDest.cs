using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class SucursalDest : BaseClass, IAccessDB<SucursalDest>
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionSucursalDestGuardar;
        public List<SucursalDest> FindAll()
        {
            return this.FindAll(null);
        }
        public List<SucursalDest> FindAll(string criterio)
        {
            return ORMDB<SucursalDest>.FindAll(criterio); 
        }
        public SucursalDest FindbyKey(params object[] key)
        {
            var agn = ORMDB<SucursalDest>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.CodigoSucDestino = agn.CodigoSucDestino;
            this.CodigoSucOrigen = agn.CodigoSucOrigen;
            this.Km = agn.Km;
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionSucursalDestGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    
                }
            }
            return ORMDB<SucursalDest>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-SucursalDest
        public static List<SucursalDest> FindAllStatic(string criterio=null, Comparison<SucursalDest> compara=null)
        {
            var lista = ORMDB<SucursalDest>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static SucursalDest FindByKeyStatic(params object[] key)
        {
            return ORMDB<SucursalDest>.FindbyKey(key);
        }
    }
}
