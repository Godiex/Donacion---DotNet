using System;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class RepositorioDonacion
    {
        private readonly SqlConnection _connection;
        public RepositorioDonacion(AdmistradorConexion admistradorConexion)
        {
            _connection = admistradorConexion._conexion;
        }
        public void Guardar(Donacion donacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Donacion (Modalidad,Fecha,ValorDonacion,PersonaId) 
                                        values (@Modalidad,@Fecha,@ValorDonacion,@PersonaId)";
                command.Parameters.AddWithValue("@Modalidad",donacion.Modalidad);
                command.Parameters.AddWithValue("@Fecha", donacion.Fecha);
                command.Parameters.AddWithValue("@ValorDonacion", donacion.ValorDonacion);
                command.Parameters.AddWithValue("@PersonaId", donacion.DonacionId);
                var filas = command.ExecuteNonQuery();
            }
        }

        public Donacion BuscarPorIdentificacion(string donacionId)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Donacion where PersonaId=@donacionId";
                command.Parameters.AddWithValue("@donacionId", donacionId);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToDonacion(dataReader);
            }
        }

        private Donacion DataReaderMapToDonacion(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Donacion donacion = new Donacion();
            donacion.Modalidad = (string)dataReader["Modalidad"];
            donacion.Fecha = (DateTime)dataReader["Fecha"];
            donacion.ValorDonacion = (decimal)dataReader["ValorDonacion"];
            donacion.DonacionId = (string)dataReader["PersonaId"];
            return donacion;
        }
    }
}
