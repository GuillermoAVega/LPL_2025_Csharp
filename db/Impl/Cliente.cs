using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    // ICOmparable
    public partial class Cliente : BaseClass, IAccessDB<Cliente>
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionClienteGuardar;
        public List<Cliente> FindAll()
        {
            return this.FindAll(null);
        }
        public List<Cliente> FindAll(string criterio)
        {
            return ORMDB<Cliente>.FindAll(criterio); 
        }
        public Cliente FindbyKey(params object[] key)
        {
            var tur = ORMDB<Cliente>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.Codigo= tur.Codigo;
            this.CodPostal = tur.CodPostal;
            this.Direccion = tur.Direccion;
            this.Email = tur.Email;
            this.Cuil = tur.Cuil;
            this.Celular = tur.Celular;
            this.Clave = tur.Clave;
            this.RazonSocial = tur.RazonSocial;
            this.Usuario = tur.Usuario;
            
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionClienteGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    if(RazonSocial == "" )
                        ValidacionClienteGuardar("No se puede poner Nombre vacio");
                }
            }
            return ORMDB<Cliente>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-Cliente
        public static List<Cliente> FindAllStatic(string criterio=null, Comparison<Cliente> compara=null)
        {
            var lista = ORMDB<Cliente>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }        

        public static Cliente FindByKeyStatic(params object[] key)
        {
            return ORMDB<Cliente>.FindbyKey(key);
        }
    }
    
}
