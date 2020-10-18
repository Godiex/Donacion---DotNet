using System;
using System.Data.SqlClient;
namespace Datos
{
    public class AdmistradorConexion
    {
        internal SqlConnection _conexion;
        public AdmistradorConexion(string cadenaConexion)
        {
            _conexion = new SqlConnection(cadenaConexion);
        }
        public void Abrir()
        {
            _conexion.Open();
        }
        public void Cerrar()
        {
            _conexion.Close();
        }
    }
}
