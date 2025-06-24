using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class Categoria : BaseClass, IAccessDB<Categoria>, IImpleCodigo
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionCategoriaGuardar;
        public List<Categoria> FindAll()
        {
            return this.FindAll(null);
        }
        public List<Categoria> FindAll(string criterio)
        {
            return ORMDB<Categoria>.FindAll(criterio); 
        }
        public Categoria FindbyKey(params object[] key)
        {
            var agn = ORMDB<Categoria>.FindbyKey(key);
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
                if (this.ValidacionCategoriaGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    if(Descripcion == "" )
                        ValidacionCategoriaGuardar("No se puede poner Nombre vacio");
                }
            }
            return ORMDB<Categoria>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-Categoria
        public static List<Categoria> FindAllStatic(string criterio=null, Comparison<Categoria> compara=null)
        {
            var lista = ORMDB<Categoria>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static Categoria FindByKeyStatic(params object[] key)
        {
            return ORMDB<Categoria>.FindbyKey(key);
        }
    }
}
