using ProyectoI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoI.Clases
{
    public abstract class Vehiculo
    {
        //Atributos
        public int Matricula { get; set; }
        public int Kilometraje { get; set; }//kilometraje desde el último mantenimiento.
        public int KilometrajeTotal { get; set; } //Kilometraje Total desde que se crea el vehiculo.
        public EstadoVehiculo Estado { get; set; }
        public int CapacidadMaxima { get; set; }


        //Constructor
        public Vehiculo(int capacidadMaxima)
        {
            Matricula = ObtenerMatricula();
            Kilometraje = 0;
            Estado = EstadoVehiculo.Operativo;
            CapacidadMaxima = capacidadMaxima;
        }


        //Métodos
        //Este método genera una matrícula aleatoria de 6 dígitos entre el 0 y 9
        private int ObtenerMatricula()
        {
            Random random = new Random();
            string matriculastr = "";
            for (int i = 0; i < 6; i++)
            {
                matriculastr += random.Next(0, 10).ToString();
            }
            return int.Parse(matriculastr);
        }


        //Este método registra el kilometraje del vehículo
        public void RegistrarKilometraje(int KilometrosRecorridos)
        {
            Kilometraje += KilometrosRecorridos;
            Console.WriteLine($"Se registraron {KilometrosRecorridos} Km. Total: {Kilometraje} Km. ");
        }


        //Este método obtiene el kilometraje total desde que se crea el vehiculo
        public int ObtenerKilometrajeTotal()
        {
            return KilometrajeTotal;
        }


        //Este método abstracto hace un recordatorio cuando le vehiculo debe ir a mantenimiento.
        public abstract void RecordatorioMantenimiento();


    }
}
