using ProyectoI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoI.Clases
{
    public class Motocicleta : Vehiculo
    {
        //Atributos
        private const int LIMITE_MANTENIMIENTO = 2000;
        private const int CAPACIDAD_MAXIMA = 5;

        private bool mantenimientoPendiente = false;
        private int kilometrajeUltmoMantenimiento = 0;

        //Constructor heredado
        public Motocicleta(int capacidadMaxima) : base(ValidarCapacidad(capacidadMaxima)) { }

        //Método abstracto heredado
        public override void RecordatorioMantenimiento()
        {
            int KmUltimoMantenimiento = ObtenerKilometrajeTotal() - kilometrajeUltmoMantenimiento;

            if (!mantenimientoPendiente && KmUltimoMantenimiento >= LIMITE_MANTENIMIENTO)
            {
                Estado = Enums.EstadoVehiculo.Mantenimiento;
                mantenimientoPendiente = true;
                Console.WriteLine("Mantenimiento requerido: Se alcanzaron 2.000Km desde el último mantenimiento.");
            }

            if (Estado == EstadoVehiculo.Mantenimiento)
            {
                Console.WriteLine("La motocicleta está en mantenimiento. Realice el servicio para continuar.");
            }
            else
            {
                Console.WriteLine($"Motocicleta operativa. \n Próximo mantenimiento en {LIMITE_MANTENIMIENTO - KmUltimoMantenimiento} Km.");
            }
        }

        //Método para realizar mantenimiento.
        public void RealizarMantenimiento()
        {
            if (Estado == EstadoVehiculo.Mantenimiento)
            {
                Estado = EstadoVehiculo.Operativo;
                Kilometraje = 0;
                kilometrajeUltmoMantenimiento = ObtenerKilometrajeTotal();
                Console.WriteLine("Mantenimiento realizado. Motocicleta Operativa nuevamente. ");
            }
            else
            {
                Console.WriteLine("La motocicleta no necesita mantenimiento por ahora. ");
            }
        }

        //Método para validar la capidad maxima de carga
        private static int ValidarCapacidad(int capacidad)
        {
            if (capacidad > CAPACIDAD_MAXIMA)
            {
                Console.WriteLine($"La capacidad máxima permitida es de: {CAPACIDAD_MAXIMA} paquetes. Solo se llenará con el valor máximo.");
                return CAPACIDAD_MAXIMA;
            }
            return capacidad;
        }

    }
}
