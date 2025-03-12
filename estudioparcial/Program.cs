using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Inicializar las colas de los cajeros
        List<Queue<int>> cajeros = new List<Queue<int>>()
        {
            new Queue<int>(new[] { 1, 1, 1 }),
            new Queue<int>(new[] { 1, 1 }),
            new Queue<int>(new[] { 1 }),
            new Queue<int>(new[] { 1, 1 })
        };

        // Mostrar el estado inicial de las colas
        MostrarEstadoCajeros(cajeros);

        // Simular la entrada de una nueva persona
        IngresarPersona(cajeros);

        // Mostrar el estado de las colas después de ingresar una persona
        MostrarEstadoCajeros(cajeros);

        // Simular que el cajero 1 despacha a una persona
        DespacharPersona(cajeros, 0);

        // Mostrar el estado final de las colas
        MostrarEstadoCajeros(cajeros);
    }

    static void IngresarPersona(List<Queue<int>> cajeros)
    {
        // Encontrar la cola con menos personas
        int cajeroConMenosPersonas = 0;
        int menorCantidad = cajeros[0].Count;

        for (int i = 1; i < cajeros.Count; i++)
        {
            if (cajeros[i].Count < menorCantidad)
            {
                cajeroConMenosPersonas = i;
                menorCantidad = cajeros[i].Count;
            }
        }

        // Agregar una persona a la cola con menos personas
        cajeros[cajeroConMenosPersonas].Enqueue(1);
        Console.WriteLine($"Una persona ingresó a la cola del cajero {cajeroConMenosPersonas + 1}");
    }

    static void DespacharPersona(List<Queue<int>> cajeros, int cajeroIndex)
    {
        if (cajeros[cajeroIndex].Count > 0)
        {
            cajeros[cajeroIndex].Dequeue();
            Console.WriteLine($"El cajero {cajeroIndex + 1} despachó a una persona");
        }
        else
        {
            Console.WriteLine($"El cajero {cajeroIndex + 1} no tiene personas para despachar");
        }
    }

    static void MostrarEstadoCajeros(List<Queue<int>> cajeros)
    {
        for (int i = 0; i < cajeros.Count; i++)
        {
            Console.Write($"Cajero {i + 1} (");
            foreach (var persona in cajeros[i])
            {
                Console.Write($"{persona} ");
            }
            Console.WriteLine(")");
        }
        Console.WriteLine();
    }
}

