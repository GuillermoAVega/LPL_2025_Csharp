using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class Sucursal : BaseClass, IAccessDB<Sucursal>, IImpleCodigo
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionSucursalGuardar;
        public List<Sucursal> FindAll()
        {
            return this.FindAll(null);
        }
        public List<Sucursal> FindAll(string criterio)
        {
            return ORMDB<Sucursal>.FindAll(criterio); 
        }
        public Sucursal FindbyKey(params object[] key)
        {
            var agn = ORMDB<Sucursal>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.Codigo = agn.Codigo;
            this.CodigoPostal = agn.CodigoPostal;
            this.Direccion = agn.Direccion;
            this.Nombre = agn.Nombre;
            this.Telefono = agn.Telefono;            
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionSucursalGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    if (Nombre == "")
                        ValidacionSucursalGuardar("No se puede poner Nombre vacio");
                }
            }
            return ORMDB<Sucursal>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-Sucursal
        public static List<Sucursal> FindAllStatic(string criterio=null, Comparison<Sucursal> compara=null)
        {
            var lista = ORMDB<Sucursal>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static Sucursal FindByKeyStatic(params object[] key)
        {
            return ORMDB<Sucursal>.FindbyKey(key);
        }
    }
}
