using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidad;


namespace Datos
{
    public class RepositorioPersona
    {
        private readonly SqlConnection _connection;
        private readonly List<Persona> _personas = new List<Persona>();
        AdmistradorConexion AdmistradorConexion ;
        public RepositorioPersona(AdmistradorConexion admistradorConexion)
        {
            AdmistradorConexion = admistradorConexion;
            _connection = AdmistradorConexion._conexion;
        }
        public void Guardar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                
                command.CommandText = @"Insert Into Persona (Identificacion,Nombres,Apellidos,Sexo,Ciudad,Edad) 
                                        values (@Identificacion,@Nombres,@Apellidos,@Sexo,@Ciudad,@Edad)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Ciudad", persona.Ciudad);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                var filas = command.ExecuteNonQuery();
                RepositorioDonacion repositorioDonacion = new RepositorioDonacion(AdmistradorConexion);
                persona.Donacion.DonacionId = persona.Identificacion;
                repositorioDonacion.Guardar(persona.Donacion);
            }
        }
        public void Eliminar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<Persona> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
            }
            return personas;
        }
        public Persona BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Persona DataReaderMapToPerson(SqlDataReader dataReader)
        {
            
            if(!dataReader.HasRows) return null;
            RepositorioDonacion repositorioDonacion = new RepositorioDonacion(AdmistradorConexion);
            Persona persona = new Persona();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombres = (string)dataReader["Nombres"];
            persona.Apellidos = (string)dataReader["Apellidos"];
            persona.Sexo = (string)dataReader["Sexo"];
            persona.Ciudad = (string)dataReader["Ciudad"];
            persona.Edad = (int)dataReader["Edad"];
            Donacion donacion = repositorioDonacion.BuscarPorIdentificacion(persona.Identificacion);
            persona.Donacion = donacion;
            return persona;
        }
    }
}
