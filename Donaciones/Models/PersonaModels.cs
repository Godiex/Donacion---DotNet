using Entidad;

namespace Donaciones.Models
{
    public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Ciudad { get; set; }
        public int Edad { get; set; }
        public Donacion Donacion { get; set; }
    }
    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombres = persona.Nombres;
            Apellidos = persona.Apellidos;
            Ciudad = persona.Ciudad;
            Edad = persona.Edad;
            Sexo = persona.Sexo;
            Donacion = persona.Donacion;
        }
    }
    
}