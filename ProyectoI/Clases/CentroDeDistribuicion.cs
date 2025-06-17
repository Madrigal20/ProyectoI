using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoI.Clases
{
    public class CentroDistribucion
    {
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }
        public List<Paquete> PaquetesAlmacenados { get; set; }

        public CentroDistribucion()
        {
            PaquetesAlmacenados = new List<Paquete>();
        }
    }

}
