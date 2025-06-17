using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoI
{
    public class Conductor
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Licencia { get; private set; }
        public int Experiencia { get; private set; }
        private List<Ruta> historialRutas;

        public Conductor(int id, string nombre, string licencia, int experiencia)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(licencia)) throw new ArgumentException("La licencia no puede estar vacía.");
            if (experiencia < 0) throw new ArgumentException("La experiencia no puede ser negativa.");

            Id = id;
            Nombre = nombre;
            Licencia = licencia;
            Experiencia = experiencia;
            historialRutas = new List<Ruta>();
        }

        public void AgregarRuta(Ruta ruta)
        {
            if (ruta == null) throw new ArgumentNullException(nameof(ruta), "La ruta no puede estar vacía.");
            historialRutas.Add(ruta);
        }

        public bool EstaDisponible()
        {
            // Se considera que el conductor está ocupado si tiene una ruta activa
            return !historialRutas.Any(r => r.Estado == EstadoRuta.Activa);
        }

        public List<Ruta> ObtenerHistorial()
        {
            return new List<Ruta>(historialRutas); // Devolver copia para evitar modificación externa
        }

        public void MostrarHistorial()
        {
            Console.WriteLine($"Historial de rutas del conductor {Nombre}:");
            if (!historialRutas.Any())
            {
                Console.WriteLine("  No tiene rutas registradas.");
                return;
            }

            foreach (var ruta in historialRutas)
            {
                Console.WriteLine($"  - {ruta}");
            }
        }

        public override string ToString()
        {
            return $"ID: {Id} | Nombre: {Nombre} | Licencia: {Licencia} | Experiencia: {Experiencia} años | Rutas registradas: {historialRutas.Count}";
        }
    }

}
