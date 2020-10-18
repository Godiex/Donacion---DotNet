using System;
using System.Collections.Generic;
using Entidad;
using Datos;

namespace Logica
{
    public class ServicioPersona
    {
        private readonly AdmistradorConexion  _conexion;
        private readonly RepositorioPersona _repositorio;
        public ServicioPersona(string cadenaConexion)
        {
            _conexion = new AdmistradorConexion(cadenaConexion);
            _repositorio = new RepositorioPersona(_conexion);
        }
        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                _conexion.Abrir();
                _repositorio.Guardar(persona);
                _conexion.Cerrar();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Cerrar(); }
        }
        public ConsultarPersonaResponse ConsultarTodos()
        {
            try 
            {
                _conexion.Abrir();
                List<Persona> personas = _repositorio.ConsultarTodos();
                _conexion.Cerrar();
                return new ConsultarPersonaResponse(personas);
            }
            catch(Exception e)
            {
                return new ConsultarPersonaResponse(e.Message);
            }
            finally {_conexion.Cerrar();}

        }

    }

    public class GuardarPersonaResponse 
        {
            public GuardarPersonaResponse(Persona persona)
            {
                Error = false;
                Persona = persona;
            }
            public GuardarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Persona Persona { get; set; }
        }
        public class ConsultarPersonaResponse 
        {
            public ConsultarPersonaResponse(List<Persona> personas)
            {
                Error = false;
                Personas = personas;
            }
            public ConsultarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Personas { get; set; }
        }
}
