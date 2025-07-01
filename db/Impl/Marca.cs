using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class Marca : BaseClass, IAccessDB<Marca>, IImpleCodigo
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionMarcaGuardar;
        public List<Marca> FindAll()
        {
            return this.FindAll(null);
        }
        public List<Marca> FindAll(string criterio)
        {
            return ORMDB<Marca>.FindAll(criterio); 
        }
        public Marca FindbyKey(params object[] key)
        {
            var agn = ORMDB<Marca>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.Codigo = agn.Codigo;
            this.Descripcion = agn.Descripcion;            
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionMarcaGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    if(Descripcion == "" )
                        ValidacionMarcaGuardar("No se puede poner Nombre vacio");
                }
            }
            return ORMDB<Marca>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-Marca
        public static List<Marca> FindAllStatic(string criterio=null, Comparison<Marca> compara=null)
        {
            var lista = ORMDB<Marca>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static Marca FindByKeyStatic(params object[] key)
        {
            return ORMDB<Marca>.FindbyKey(key);
        }
    }
}
