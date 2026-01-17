using System;

namespace ListaEnlazadaBusqueda
{
    // Clase Nodo
    class Nodo
    {
        public int Dato;
        public Nodo Siguiente;

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Clase Lista Enlazada
    class Lista
    {
        private Nodo cabeza;

        public Lista()
        {
            cabeza = null;
        }

        // Método para insertar datos al final de la lista
        public void Insertar(int dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        // Método de búsqueda
        public int Buscar(int valor)
        {
            Nodo actual = cabeza;
            int contador = 0;

            while (actual != null)
            {
                if (actual.Dato == valor)
                {
                    contador++;
                }
                actual = actual.Siguiente;
            }

            if (contador == 0)
            {
                Console.WriteLine("El dato no fue encontrado en la lista.");
            }

            return contador;
        }

        // Mostrar lista
        public void Mostrar()
        {
            Nodo actual = cabeza;
            Console.Write("Lista: ");
            while (actual != null)
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }
    }

    // Clase Principal
    class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();

            // Insertar datos
            lista.Insertar(5);
            lista.Insertar(3);
            lista.Insertar(5);
            lista.Insertar(7);
            lista.Insertar(5);

            lista.Mostrar();

            Console.Write("Ingrese el valor a buscar: ");
            int valor = int.Parse(Console.ReadLine());

            int resultado = lista.Buscar(valor);

            if (resultado > 0)
            {
                Console.WriteLine("El dato se encontró " + resultado + " veces en la lista.");
            }

            Console.ReadKey();
        }
    }
}
//Ejersicio2
using System;

namespace ListaEnlazadaRango
{
    // Clase Nodo
    class Nodo
    {
        public int Dato;
        public Nodo Siguiente;

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Clase Lista Enlazada
    class Lista
    {
        private Nodo cabeza;

        public Lista()
        {
            cabeza = null;
        }

        // Insertar al final
        public void Insertar(int dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        // Eliminar nodos fuera del rango
        public void EliminarFueraDeRango(int minimo, int maximo)
        {
            // Eliminar nodos del inicio si están fuera del rango
            while (cabeza != null && (cabeza.Dato < minimo || cabeza.Dato > maximo))
            {
                cabeza = cabeza.Siguiente;
            }

            Nodo actual = cabeza;

            while (actual != null && actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato < minimo || actual.Siguiente.Dato > maximo)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }
        }

        // Mostrar lista
        public void Mostrar()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }
    }

    // Clase Principal
    class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();
            Random random = new Random();

            // Crear lista con 50 números aleatorios entre 1 y 999
            for (int i = 0; i < 50; i++)
            {
                lista.Insertar(random.Next(1, 1000));
            }

            Console.WriteLine("Lista original:");
            lista.Mostrar();

            Console.Write("\nIngrese el valor mínimo del rango: ");
            int minimo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor máximo del rango: ");
            int maximo = int.Parse(Console.ReadLine());

            lista.EliminarFueraDeRango(minimo, maximo);

            Console.WriteLine("\nLista después de eliminar los nodos fuera del rango:");
            lista.Mostrar();

            Console.ReadKey();
        }
    }
}
