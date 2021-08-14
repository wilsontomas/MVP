using AplicacionDeContactos.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionDeContactos.Presenter
{
    class ContactosPresenter
    {
        public IContactos contactos;
        public ContactosPresenter(IContactos view) 
        {
            contactos = view;
        }
        public IEnumerable<Contactos> VerContactos() {
            var conexion = new Conexion();
            var listadoContactos = conexion.conexion.Query<Contactos>("VerContactos", null, commandType: CommandType.StoredProcedure);
            if (listadoContactos.Count() > 0) return listadoContactos;
            return null;
        }

        public bool AgregarContacto() {
            try
            {
            var conexion = new Conexion();
            var parametros = new { @Nombre = contactos.Nombre, @Apellido = contactos.Apellido, @Numero = contactos.Numero };
            conexion.conexion.Query<Contactos>("InsertarContacto", parametros, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarContacto()
        {
            try
            {
                var conexion = new Conexion();
                var parametros = new { @id = contactos.Id};
                conexion.conexion.Execute("EliminarContacto", parametros, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Contactos VerContactosPorId()
        {
            try
            {
                var conexion = new Conexion();
                var parametros = new { @id = contactos.Id };
               var resultado = conexion.conexion.QueryFirstOrDefault<Contactos>("VerContactosPorId", parametros, commandType: CommandType.StoredProcedure);
                return resultado;
            }
            catch
            {
                return null;
            }
        }
        
             public bool EditarContacto()
        {
            try
            {
                var conexion = new Conexion();
                var parametros = new { @id = contactos.Id, @Nombre=contactos.Nombre, @Apellido=contactos.Apellido, @Numero=contactos.Numero };
               conexion.conexion.Execute("EditarContacto", parametros, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
