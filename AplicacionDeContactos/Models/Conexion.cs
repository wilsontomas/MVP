using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionDeContactos.Models
{
    class Conexion
    {
        private SqlConnection _conexion { get; set; }

        public SqlConnection conexion
        {
            get
            {
                if (this._conexion == null) { this._conexion = new SqlConnection(@"Data Source=DESKTOP-V32QJTJ\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True"); }
                return this._conexion;
            }
        }
    }
}
