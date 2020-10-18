using System;

namespace Entidad
{
    public class Persona
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Ciudad { get; set; }
        public int Edad { get; set; }
        public Donacion Donacion { get; set; }
        public Persona()
        {
            
        }
        public Persona(string identificacion, string nombres, string apellidos, string sexo, string ciudad, int edad)
        {
            Identificacion = identificacion;
            Nombres = nombres;
            Apellidos = apellidos;
            Sexo = sexo;
            Ciudad = ciudad;
            Edad = edad;
        }
    }
}
