using ProyectoI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoI.Clases
{
    public class Automovil : Vehiculo
    {
        //Atributos
        private const int LIMITE_MANTENIMIENTO = 7000;
        private const int CAPACIDAD_MAXIMA = 20;

        private bool mantenimientoPendiente = false;
        private int kilometrajeUltimoMantenimiento = 0;

        //Constructor heredado
        public Automovil(int capacidadMaxima) : base(ValidarCapacidad(capacidadMaxima)) { }

        //Método abstracto heredado
        //Este método sirve para registrar el matenimiento del automovil, si el auto super los 7.000km entonce se pone su Estado en "Mantenimiento" y no permite usarlo hasta que se haga el servicio.
        public override void RecordatorioMantenimiento()
        {
            int KmUltimoMantenimiento = ObtenerKilometrajeTotal() - kilometrajeUltimoMantenimiento;

            if (!mantenimientoPendiente && KmUltimoMantenimiento >= LIMITE_MANTENIMIENTO)
            {
                Estado = Enums.EstadoVehiculo.Mantenimiento;
                mantenimientoPendiente = true;
                Console.WriteLine("Mantenimiento requerido: Se alcanzaron 7.000KM desde el último mantenimiento.");
            }

            if (Estado == EstadoVehiculo.Mantenimiento)
            {
                Console.WriteLine("El automovil está en mantenimiento. Realice el servicio para continuar.");
            }
            else
            {
                Console.WriteLine($"Auto operativo. \n Próximo mantenimiento en {LIMITE_MANTENIMIENTO - KmUltimoMantenimiento} Km.");
            }
        }

        //Este método se utiliza para hacer el mantenimiento al vehiculo, resetea el kilometraje a 0 nuevamente y pone su estado en operativo haciendo que ya nos deje disponer nuevamente del automovil.
        public void RealizarMantenimiento()
        {
            if (Estado == EstadoVehiculo.Mantenimiento)
            {
                Estado = EstadoVehiculo.Operativo;
                Kilometraje = 0;
                kilometrajeUltimoMantenimiento = ObtenerKilometrajeTotal();
                Console.WriteLine("Mantenimiento realizado. Automovil Operativo nuevamente. ");
            }
            else
            {
                Console.WriteLine("El automovil no necesita mantenimiento por ahora. ");
            }
        }

        //Este método sirve para validar la capacidad máxima de transporte de paquetes.
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
