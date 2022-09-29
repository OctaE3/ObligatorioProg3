using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Conexion
    {
        protected static string CadenaDeConexion
        {
            get { return @"Server=OCTA\SQLEXPRESS;Initial Catalog=taller_mecanico; Integrated Security=True"; }
        }
    }
}
