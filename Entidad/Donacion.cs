using System;

namespace Entidad
{
    public class Donacion
    {
        public string DonacionId { get; set; }
        public string Modalidad { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ValorDonacion { get; set; }
        public Donacion()
        {
            
        }
        public Donacion(string modalidad, DateTime fecha, decimal valorDonacion)
        {
            Modalidad = modalidad;
            Fecha = fecha;
            ValorDonacion = valorDonacion;
        }
    }
}
