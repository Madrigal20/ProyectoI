using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoI.Clases
{
    public string Origen { get; set; }
    public string Destino { get; set; }
    public double Distancia { get; set; }
    public string VehiculoAsignado { get; set; }
    public string ConductorAsignado { get; set; }

    public Ruta(string origen, string destino, double distancia, string vehiculoAsignado, string conductorAsignado)
    {
        Origen = origen;
        Destino = destino;
        Distancia = distancia;
        VehiculoAsignado = vehiculoAsignado;
        ConductorAsignado = conductorAsignado;

    }
}
