using System;
using System.Collections.Generic;

class Pilas_Ejercicios
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== VERIFICACIÓN DE PARÉNTESIS BALANCEADOS ===");
        string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        VerificarBalanceo(expresion);

        Console.WriteLine("\n=== TORRES DE HANOI USANDO PILAS ===");
        int discos = 3;
        ResolverHanoi(discos);

        Console.ReadKey();
    }

    // EJERCICIO 1: VERIFICAR PARÉNTESIS BALANCEADOS
    static void VerificarBalanceo(string expresion)
    {
        Stack<char> pila = new Stack<char>();
        bool balanceado = true;

        foreach (char c in expresion)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0)
                {
                    balanceado = false;
                    break;
                }

                char tope = pila.Pop();

                if (!Coincide(tope, c))
                {
                    balanceado = false;
                    break;
                }
            }
        }

        if (pila.Count > 0)
            balanceado = false;

        Console.WriteLine("Expresión: " + expresion);
        Console.WriteLine(balanceado ? "Resultado: Fórmula balanceada." : "Resultado: Fórmula NO balanceada.");
    }

    static bool Coincide(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }

    // EJERCICIO 2: TORRES DE HANOI CON PILAS
    static void ResolverHanoi(int n)
    {
        Stack<int> origen = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();
        Stack<int> destino = new Stack<int>();

        for (int i = n; i >= 1; i--)
        {
            origen.Push(i);
        }

        MoverDiscos(n, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar");
    }

    static void MoverDiscos(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                            string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            return;
        }

        MoverDiscos(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

        int discoActual = origen.Pop();
        destino.Push(discoActual);
        Console.WriteLine($"Mover disco {discoActual} de {nombreOrigen} a {nombreDestino}");

        MoverDiscos(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
    }
}
