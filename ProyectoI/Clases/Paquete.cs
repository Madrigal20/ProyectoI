using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoI.Clases
{
    public class Paquete
    {
        public string Id { get; set; }
        public double Peso { get; set; }
        public string Dimensiones { get; set; }
        public string DireccionDestino { get; set; }
        public EstadoPaquete Estado { get; set; }  // Para linkear con Enum EstadoPaquete
        public PrioridadPaquete Prioridad { get; set; } // Para linkear con Enum PrioridadPaquete
    }
}
