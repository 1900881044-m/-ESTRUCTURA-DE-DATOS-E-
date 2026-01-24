using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ParqueDiversiones
{
    // Clase Persona
    class Persona
    {
        public string Nombre { get; set; }
        public int Asiento { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
            Asiento = 0;
        }
    }

    // Clase Atraccion
    class Atraccion
    {
        private Queue<Persona> cola;
        private int capacidad;

        public Atraccion(int capacidad)
        {
            this.capacidad = capacidad;
            cola = new Queue<Persona>();
        }

        // Agregar persona a la cola
        public void AgregarPersona(string nombre)
        {
            if (cola.Count < capacidad)
            {
                cola.Enqueue(new Persona(nombre));
                Console.WriteLine($"Persona {nombre} agregada a la cola.");
            }
            else
            {
                Console.WriteLine("⚠️ Todos los asientos están vendidos.");
            }
        }

        // Asignar asientos
        public void AsignarAsientos()
        {
            int numeroAsiento = 1;

            Console.WriteLine("\n🎢 ASIGNACIÓN DE ASIENTOS\n");

            while (cola.Count > 0)
            {
                Persona p = cola.Dequeue();
                p.Asiento = numeroAsiento;
                Console.WriteLine($"Asiento {p.Asiento}: {p.Nombre}");
                numeroAsiento++;
            }
        }

        // Reporte
        public void Reporte()
        {
            Console.WriteLine($"\n📊 Personas restantes en la cola: {cola.Count}");
        }
    }

    // Clase principal
    class Program
    {
        static void Main(string[] args)
        {
            Atraccion atraccion = new Atraccion(30);

            Stopwatch tiempo = new Stopwatch();
            tiempo.Start();

            // Simulación de llegada de personas
            for (int i = 1; i <= 30; i++)
            {
                atraccion.AgregarPersona("Persona " + i);
            }

            atraccion.AsignarAsientos();
            atraccion.Reporte();

            tiempo.Stop();
            Console.WriteLine($"\n⏱️ Tiempo de ejecución: {tiempo.ElapsedTicks} ticks");

            Console.ReadKey();
        }
    }
}
